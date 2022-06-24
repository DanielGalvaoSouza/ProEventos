using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models.ResponseAPI;
using ProEventos.Persistence.Contracts;
using ProEventos.Persistence.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuditoriumsController : Controller
    {
        private readonly ILogger<AuditoriumsController> _logger;
        private readonly IRepositoryQueryRS<DTOAuditoriums> _auditoriumsQueryRS;
        private readonly IRepositoryCommandRS<DTOAuditoriums> _auditoriumsCommandRS;

        public AuditoriumsController(
            ILogger<AuditoriumsController> logger,
            IRepositoryQueryRS<DTOAuditoriums> auditoriosQueryRS,
            IRepositoryCommandRS<DTOAuditoriums> auditoriosCommandRS)
        {
            _logger = logger;
            _auditoriumsQueryRS = auditoriosQueryRS;
            _auditoriumsCommandRS = auditoriosCommandRS;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var responseAPI = new ResponseAPI<DTOAuditoriums>();

            await Task.Delay(0);

            try
            {
                responseAPI.ListEntityObject = _auditoriumsQueryRS.ListRepositoryOfDTO;
                responseAPI.IsProcessSucessfuly = true;
                _logger.LogInformation("Process Controller is sucessfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                responseAPI.IsProcessSucessfuly = false;
                responseAPI.MessageProcess = ex.Message;
                return StatusCode(500, responseAPI);
            }

            return Ok(responseAPI);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var responseAPI = new ResponseAPI<DTOAuditoriums>();

            await Task.Delay(0);

            try
            {
                responseAPI.EntityObject = _auditoriumsQueryRS.ListRepositoryOfDTO.FirstOrDefault(x => x.IdAuditorium == id);
                responseAPI.IsProcessSucessfuly = true;
                _logger.LogInformation("Process Controller is sucessfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                responseAPI.IsProcessSucessfuly = false;
                responseAPI.MessageProcess = ex.Message;
                return StatusCode(500, responseAPI);
            }

            return Ok(responseAPI);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DTOAuditoriums eventEntity)
        {
            var responseAPI = new ResponseAPI<DTOAuditoriums>();

            try
            {
                responseAPI.EntityObject = await _auditoriumsCommandRS.PostRegistry(eventEntity);
                responseAPI.IsProcessSucessfuly = true;
                _logger.LogInformation("Process Controller is sucessfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                responseAPI.IsProcessSucessfuly = false;
                responseAPI.MessageProcess = ex.Message;
                return StatusCode(500, responseAPI);
            }

            return Ok(responseAPI);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DTOAuditoriums auditoriumsEntity)
        {
            var responseAPI = new ResponseAPI<DTOAuditoriums>();

            try
            {
                responseAPI.EntityObject = await _auditoriumsCommandRS.PutRegistry(auditoriumsEntity);
                responseAPI.IsProcessSucessfuly = true;
                _logger.LogInformation("Process Controller is sucessfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                responseAPI.IsProcessSucessfuly = false;
                responseAPI.MessageProcess = ex.Message;
                return StatusCode(500, responseAPI);
            }

            return Ok(responseAPI);

        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] DTOAuditoriums auditoriumsEntity)
        {
            var responseAPI = new ResponseAPI<DTOAuditoriums>();

            try
            {
                responseAPI.EntityObject = await _auditoriumsCommandRS.PatchRegistry(auditoriumsEntity);
                responseAPI.IsProcessSucessfuly = true;
                _logger.LogInformation("Process Controller is sucessfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                responseAPI.IsProcessSucessfuly = false;
                responseAPI.MessageProcess = ex.Message;
                return StatusCode(500, responseAPI);
            }

            return Ok(responseAPI);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var responseAPI = new ResponseAPI<DTOAuditoriums>();

            try
            {
                var rowsAffected = await _auditoriumsCommandRS.DeleteRegistry(id);
                responseAPI.IsProcessSucessfuly = (rowsAffected != default);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                responseAPI.IsProcessSucessfuly = false;
                responseAPI.MessageProcess = ex.Message;
                return StatusCode(500, responseAPI);
            }

            return Ok(responseAPI);
        }

    }
}
