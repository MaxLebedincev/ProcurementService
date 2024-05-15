using ProcurementService.API.Controllers.DanceGroupInteraction;
using ProcurementService.API.DAL.Interfaces;
using ProcurementService.API.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ProcurementService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DanceGroupController : ControllerBase
    {
        private readonly AppSettings _conf;
        private readonly IUnitOfWork _unitOfWork;

        public DanceGroupController(IOptions<AppSettings> conf, IUnitOfWork unitOfWork)
        {
            _conf = conf.Value;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] DanceGroupRequest request)
        {
            var rep = _unitOfWork.GetRepository<DanceGroup>();

            var newEntity = new DanceGroup()
            {
                RussiaTrainerBallroomDanceId = request.RussiaTrainerBallroomDanceId,
                Name = request.Name,
                Created = request.Created,
            };

            rep.Create(newEntity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Get")]
        public async Task<ActionResult<List<DanceGroupResponse>>> Get([FromBody] DanceGroupDTO? request)
        {
            var rep = _unitOfWork.GetRepository<DanceGroup>();

            var list = rep.GetAll();

            list = list.OrderBy(e => e.Id);

            int count = 1;

            if (request is not null)
            {
                if (!string.IsNullOrEmpty(request.Name))
                    list = list.Where(e => EF.Functions.Like(e.Name, $"%{request.Name}%"));

                if (!string.IsNullOrEmpty(request.Created))
                    list = list.Where(e => e.Created >= DateTime.Parse(request.Created));

                if (!string.IsNullOrEmpty(request.Finish))
                    list = list.Where(e => e.Created <= DateTime.Parse(request.Finish));

                count = list.Count();

                list = list
                        .Skip((request.Offset-1)* request.Number)
                        .Take(request.Number);
                    
                count = (count % request.Number != 0) ? (count / request.Number) + 1 : (count / request.Number);
            }
            else
            {
                list = list
                        .Skip(0)
                        .Take(10);
            }

            var paginatedList = await list.ToListAsync();

            var resopnse = new List<DanceGroupResponse>();

            foreach (var item in paginatedList)
                resopnse.Add(new DanceGroupResponse()
                {
                    Id = item.Id,
                    Name = item.Name,
                    RussiaTrainerBallroomDanceId = item.RussiaTrainerBallroomDanceId,
                    Created = item.Created,
                });

            return new JsonResult(new { 
                list = resopnse, 
                count = count
            });
        }

        [HttpGet("Get/{id:int}")]
        public async Task<ActionResult<DanceGroupResponse?>> GetById(int id)
        {
            var rep = _unitOfWork.GetRepository<DanceGroup>();

            var entity = await rep.GetAll().Where(r => r.Id == id).FirstAsync();

            if (entity is null)
                return NotFound();

            var response = new DanceGroupResponse()
            {
                Id = entity.Id,
                Name = entity.Name,
                RussiaTrainerBallroomDanceId = entity.RussiaTrainerBallroomDanceId,
                Created = entity.Created,
            };

            return response;
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var rep = _unitOfWork.GetRepository<DanceGroup>();

            var entity = await rep.GetAll().Where(r => r.Id == id).FirstAsync();

            if (entity is null)
                return NotFound();

            rep.Delete(entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Update/{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] DanceGroupRequest newEntity)
        {
            var rep = _unitOfWork.GetRepository<DanceGroup>();

            var entity = await rep.GetAll().Where(r => r.Id == id).FirstAsync();

            if (entity is null)
                return NotFound();

            entity.Name = newEntity.Name;
            entity.RussiaTrainerBallroomDanceId = newEntity.RussiaTrainerBallroomDanceId;
            entity.Created = newEntity.Created;

            rep.Update(entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}
