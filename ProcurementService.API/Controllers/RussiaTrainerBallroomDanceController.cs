using ProcurementService.API.Controllers.RussiaTrainerBallroomDanceInteraction;
using ProcurementService.API.Controllers.TypeBallroomDanceInteraction;
using ProcurementService.API.DAL.Interfaces;
using ProcurementService.API.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ProcurementService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RussiaTrainerBallroomDanceController : ControllerBase
    {
        private readonly AppSettings _conf;
        private readonly IUnitOfWork _unitOfWork;

        public RussiaTrainerBallroomDanceController(IOptions<AppSettings> conf, IUnitOfWork unitOfWork)
        {
            _conf = conf.Value;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] RussiaTrainerBallroomDanceRequest request)
        {
            var rep = _unitOfWork.GetRepository<RussiaTrainerBallroomDance>();


            var newEntity = new RussiaTrainerBallroomDance()
            {
                TypeBallroomDanceId = request.TypeBallroomDanceId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
            };

            rep.Create(newEntity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Get")]
        public async Task<ActionResult<List<RussiaTrainerBallroomDanceResponse>>> Get([FromBody] RussiaTrainerBallroomDanceDTO request)
        {
            var rep = _unitOfWork.GetRepository<RussiaTrainerBallroomDance>();

            var list = rep.GetAll();

            list = list.OrderBy(e => e.Id);

            if (!string.IsNullOrEmpty(request.FirstName))
                list = list.Where(e => EF.Functions.Like(e.FirstName, $"%{request.FirstName}%"));

            if (!string.IsNullOrEmpty(request.LastName))
                list = list.Where(e => EF.Functions.Like(e.LastName, $"%{request.LastName}%"));

            if (!string.IsNullOrEmpty(request.MiddleName))
                list = list.Where(e => EF.Functions.Like(e.MiddleName, $"%{request.MiddleName}%"));

            if(request.TypeBallroomDanceId is not null)
                list = list.Where(e => e.TypeBallroomDanceId == request.TypeBallroomDanceId);

            list = list
                    .Skip(request.Offset)
                    .Take(request.Number);

            var paginatedList = await list.ToListAsync();

            var resopnse = new List<RussiaTrainerBallroomDanceResponse>();

            foreach (var item in paginatedList)
                resopnse.Add(new RussiaTrainerBallroomDanceResponse()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    MiddleName = item.MiddleName,
                });

            return resopnse;
        }

        [HttpGet("Get/{id:int}")]
        public async Task<ActionResult<RussiaTrainerBallroomDanceResponse?>> GetById(int id)
        {
            var rep = _unitOfWork.GetRepository<RussiaTrainerBallroomDance>();

            var entity = await rep.GetAll().Where(r => r.Id == id).FirstAsync();

            if (entity is null)
                return NotFound();

            var response = new RussiaTrainerBallroomDanceResponse()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                MiddleName = entity.MiddleName,
            };

            return response;
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var rep = _unitOfWork.GetRepository<RussiaTrainerBallroomDance>();

            var entity = await rep.GetAll().Where(r => r.Id == id).FirstAsync();

            if (entity is null)
                return NotFound();

            rep.Delete(entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Update/{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] RussiaTrainerBallroomDanceRequest newEntity)
        {
            var rep = _unitOfWork.GetRepository<RussiaTrainerBallroomDance>();

            var entity = await rep.GetAll().Where(r => r.Id == id).FirstAsync();

            if (entity is null)
                return NotFound();

            entity.FirstName = newEntity.FirstName;
            entity.LastName = newEntity.LastName;
            entity.MiddleName = newEntity.MiddleName;

            rep.Update(entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}
