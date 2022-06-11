using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models.Contracts;
using ProEventos.API.Models.DTO;
using ProEventos.API.Models.ResponseAPI;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly ILogger<EventsController> _logger;
        private readonly IRepositoryQueryRS<DTOEvents> _eventsQueryRS;
        private readonly IRepositoryCommandRS<DTOEvents> _eventsCommandRS;

        public EventsController(
            ILogger<EventsController> logger,
            IRepositoryQueryRS<DTOEvents> eventsQueryRS,
            IRepositoryCommandRS<DTOEvents> eventsCommandRS)
        {
            _logger = logger;
            _eventsQueryRS = eventsQueryRS;
            _eventsCommandRS = eventsCommandRS;
        }

        ///Requisitar Recursos (Request Resource)
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var responseAPI = new ResponseAPI<DTOEvents>();

            await Task.Delay(0);
            
            try{
                responseAPI.ListEntityObject = _eventsQueryRS.ListRepositoryOfDTO;
                responseAPI.IsProcessSucessfuly = true;

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

        [HttpGet("{idEvent}")]
        public async Task<IActionResult> Get([FromRoute] int idEvent)
        {
            var responseAPI = new ResponseAPI<DTOEvents>();

            await Task.Delay(0);

            try
            {
                responseAPI.EntityObject = _eventsQueryRS.ListRepositoryOfDTO.FirstOrDefault(f => f.IdEvent == idEvent);
                responseAPI.IsProcessSucessfuly = true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                responseAPI.IsProcessSucessfuly = false;
                responseAPI.MessageProcess = ex.Message;
                return StatusCode(500, responseAPI);
            }
            
            return Ok(responseAPI);

        }

        //Criar Recurso (Create Resource)
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DTOEvents eventEntity)
        {
            var responseAPI = new ResponseAPI<DTOEvents>();
            
            try
            {
                responseAPI.EntityObject = await _eventsCommandRS.PostRegistry(eventEntity);
                responseAPI.IsProcessSucessfuly = true;

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

        //Atualizar Recurso (Update Resource)
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DTOEvents eventEntity)
        {
            var responseAPI = new ResponseAPI<DTOEvents>();

            try
            {
                responseAPI.EntityObject = await _eventsCommandRS.PutRegistry(eventEntity);
                await Task.Delay(0);
                responseAPI.IsProcessSucessfuly = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                responseAPI.IsProcessSucessfuly = false;
                responseAPI.MessageProcess = ex.Message;
                return StatusCode(500, responseAPI);
            }

            return Ok(responseAPI);

            //return $"Exemplo de Put id = {id}";
        }

        //Atualizar Recursos Parcial (Update Partial)
        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] DTOEvents eventEntity)
        {
            var responseAPI = new ResponseAPI<DTOEvents>();

            try
            {
                responseAPI.EntityObject = await _eventsCommandRS.PatchRegistry(eventEntity);
                await Task.Delay(0);
                responseAPI.IsProcessSucessfuly = true;
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

        //Deletar Recurso (Delete Resource)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var responseAPI = new ResponseAPI<DTOEvents>();

            try
            {
                var rowsAffected = await _eventsCommandRS.DeleteRegistry(id);
                await Task.Delay(0);
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