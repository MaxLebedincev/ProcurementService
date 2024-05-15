using ProcurementService.API.Controllers.ServerFileInteraction;
using ProcurementService.API.DAL.Interfaces;
using ProcurementService.API.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ProcurementService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServerFileController : ControllerBase
    {
        private readonly AppSettings _conf;
        private readonly IUnitOfWork _unitOfWork;

        public ServerFileController(IOptions<AppSettings> conf, IUnitOfWork unitOfWork)
        {
            _conf = conf.Value;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] ServerFileRequest request)
        {
            var rep = _unitOfWork.GetRepository<ServerFile>();


            var newEntity = new ServerFile()
            {
                Name = request.Name,
                Size = request.Size,
            };

            rep.Create(newEntity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Get")]
        public async Task<ActionResult<List<ServerFileResponse>>> Get([FromBody] ServerFileDTO request)
        {
            var rep = _unitOfWork.GetRepository<ServerFile>();

            var list = rep.GetAll();

            if (!string.IsNullOrEmpty(request.Name))
                list = list.Where(e => EF.Functions.Like(e.Name, $"%{request.Name}%"));

            list = list.Where(e => e.Size == request.Size);

            list = list
                    .Skip(request.Offset)
                    .Take(request.Number);

            var paginatedList = await list.ToListAsync();

            var resopnse = new List<ServerFileResponse>();

            foreach (var item in paginatedList)
                resopnse.Add(new ServerFileResponse()
                {
                    Guid = item.Guid,
                    Name = item.Name,
                });

            return resopnse;
        }

        [HttpGet("Get/{guid:guid}")]
        public async Task<ActionResult<ServerFileResponse?>> GetById(Guid guid)
        {
            var rep = _unitOfWork.GetRepository<ServerFile>();

            var entity = await rep.GetAll().Where(r => r.Guid == guid).FirstAsync();

            if (entity is null)
                return NotFound();

            var response = new ServerFileResponse()
            {
                Guid = entity.Guid,
                Name = entity.Name,
                Size = entity.Size,
            };

            return response;
        }

        [HttpDelete("Delete/{guid:guid}")]
        public async Task<ActionResult> Delete(Guid guid)
        {
            var rep = _unitOfWork.GetRepository<ServerFile>();

            var entity = await rep.GetAll().Where(r => r.Guid == guid).FirstAsync();

            if (entity is null)
                return NotFound();

            rep.Delete(entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Update/{guid:guid}")]
        public async Task<ActionResult> Update(Guid guid, [FromBody] ServerFileRequest newEntity)
        {
            var rep = _unitOfWork.GetRepository<ServerFile>();

            var entity = await rep.GetAll().Where(r => r.Guid == guid).FirstAsync();

            if (entity is null)
                return NotFound();

            entity.Name = newEntity.Name;
            entity.Size = newEntity.Size;

            rep.Update(entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}
