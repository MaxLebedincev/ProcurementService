using ProcurementService.API.Controllers.MemberDanceGroupInteraction;
using ProcurementService.API.DAL.Interfaces;
using ProcurementService.API.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ProcurementService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberDanceGroupController : ControllerBase
    {
        private readonly AppSettings _conf;
        private readonly IUnitOfWork _unitOfWork;

        public MemberDanceGroupController(IOptions<AppSettings> conf, IUnitOfWork unitOfWork)
        {
            _conf = conf.Value;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] MemberDanceGroupRequest request)
        {
            var rep = _unitOfWork.GetRepository<MemberDanceGroup>();

            var newEntity = new MemberDanceGroup()
            {
                DanceGroupId = request.DanceGroupId,
                GuidPhotoFile = request.GuidPhotoFile,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                City = request.City,
                Category = request.Category,
                Score = request.Score ?? 0
            };

            rep.Create(newEntity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Get")]
        public async Task<ActionResult<List<MemberDanceGroupResponse>>> Get([FromBody] MemberDanceGroupDTO request)
        {
            var rep = _unitOfWork.GetRepository<MemberDanceGroup>();

            var list = rep.GetAll();

            list = list.OrderBy(e => e.Id);

            if (request.DanceGroupId is not null)
                list = list.Where(e => e.DanceGroupId == request.DanceGroupId);

            if (!string.IsNullOrEmpty(request.FirstName))
                list = list.Where(e => EF.Functions.Like(e.FirstName, $"%{request.FirstName}%"));

            if (!string.IsNullOrEmpty(request.LastName))
                list = list.Where(e => EF.Functions.Like(e.LastName, $"%{request.LastName}%"));

            if (!string.IsNullOrEmpty(request.MiddleName))
                list = list.Where(e => EF.Functions.Like(e.MiddleName, $"%{request.MiddleName}%"));

            if (!string.IsNullOrEmpty(request.City))
                list = list.Where(e => EF.Functions.Like(e.City, $"%{request.City}%"));

            if (!string.IsNullOrEmpty(request.Category))
                list = list.Where(e => EF.Functions.Like(e.Category, $"%{request.Category}%"));

            if (request.Score is not null)
                list = list.Where(e => e.Score == request.Score);


            list = list
                    .Skip(request.Offset)
                    .Take(request.Number);

            var paginatedList = await list.ToListAsync();

            var resopnse = new List<MemberDanceGroupResponse>();

            foreach (var item in paginatedList)
                resopnse.Add(new MemberDanceGroupResponse()
                {
                    Id = item.Id,
                    DanceGroupId = item.DanceGroupId,
                    GuidPhotoFile = item.GuidPhotoFile,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    MiddleName = item.MiddleName,
                    City = item.City,
                    Category = item.Category,
                    Score = item.Score,
                });

            return resopnse;
        }

        [HttpGet("Get/{id:int}")]
        public async Task<ActionResult<MemberDanceGroupResponse?>> GetById(int id)
        {
            var rep = _unitOfWork.GetRepository<MemberDanceGroup>();

            var entity = await rep.GetAll().Where(r => r.Id == id).FirstAsync();

            if (entity is null)
                return NotFound();

            var response = new MemberDanceGroupResponse()
            {
                Id = entity.Id,
                DanceGroupId = entity.DanceGroupId,
                GuidPhotoFile = entity.GuidPhotoFile,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                MiddleName = entity.MiddleName,
                City = entity.City,
                Category = entity.Category,
                Score = entity.Score,
            };

            return response;
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var rep = _unitOfWork.GetRepository<MemberDanceGroup>();

            var entity = await rep.GetAll().Where(r => r.Id == id).FirstAsync();

            if (entity is null)
                return NotFound();

            rep.Delete(entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Update/{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] MemberDanceGroupRequest newEntity)
        {
            var rep = _unitOfWork.GetRepository<MemberDanceGroup>();

            var entity = await rep.GetAll().Where(r => r.Id == id).FirstAsync();

            if (entity is null)
                return NotFound();

            entity.DanceGroupId = newEntity.DanceGroupId;
            entity.GuidPhotoFile = newEntity.GuidPhotoFile;
            entity.FirstName = newEntity.FirstName;
            entity.LastName = newEntity.LastName;
            entity.MiddleName = newEntity.MiddleName;
            entity.City = newEntity.City;
            entity.Category = newEntity.Category;
            entity.Score = newEntity.Score ?? 0;

            rep.Update(entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}
