using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models.ResponseAPI;
using ProEventos.Application.Interfaces;
using ProEventos.Application.ResponseAPI;
using ProEventos.Domain.Entities;
using ProEventos.Persistence.Contracts;
using ProEventos.Persistence.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly ILogger<EventsController> _logger;
        private readonly IEventService _eventService;

        public EventsController(ILogger<EventsController> logger,
            IEventService eventService)
        {
            _logger = logger;
            _eventService = eventService;
        }

        ///Requisitar Recursos (Request Resource)
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var responseAPI = new ResponseObject<Events>();

            try
            {
                responseAPI.ListEntityObject = await _eventService.GetAllEventsAsync(false);
                responseAPI.IsProcessSucessfuly = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                responseAPI.IsProcessSucessfuly = false;
                responseAPI.MessageProcess = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, responseAPI);
            }

            return Ok(responseAPI);

        }

        [HttpGet("{idEvent}")]
        public async Task<IActionResult> Get([FromRoute] int idEvent)
        {
            var responseAPI = new ResponseObject<Events>();

            try
            {
                responseAPI.EntityObject = await _eventService.GetEventById(idEvent, false);
                responseAPI.IsProcessSucessfuly = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                responseAPI.IsProcessSucessfuly = false;
                responseAPI.MessageProcess = ex.Message;
                return this.StatusCode(StatusCodes.Status500InternalServerError, responseAPI);
            }

            return Ok(responseAPI);

        }

        //Criar Recurso (Create Resource)
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Events eventEntity)
        {
            var responseAPI = new ResponseObject<Events>();

            try
            {
                responseAPI.EntityObject = await _eventService.AddEvent(eventEntity);
                responseAPI.IsProcessSucessfuly = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                responseAPI.IsProcessSucessfuly = false;
                responseAPI.MessageProcess = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, responseAPI);
            }

            return Ok(responseAPI);

        }

        //Atualizar Recurso (Update Resource)
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Events eventEntity)
        {
            var responseAPI = new ResponseAPI<Events>();

            try
            {
                responseAPI.EntityObject = await _eventService.UpdateEvent(id, eventEntity);
                responseAPI.IsProcessSucessfuly = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                responseAPI.IsProcessSucessfuly = false;
                responseAPI.MessageProcess = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, responseAPI);
            }

            return Ok(responseAPI);

        }

        ////Atualizar Recursos Parcial (Update Partial)
        //[HttpPatch]
        //public async Task<IActionResult> Patch([FromBody] Events eventEntity)
        //{
        //    var responseAPI = new ResponseAPI<Events>();

        //    try
        //    {
        //        responseAPI.EntityObject = await _eventService.PatchRegistry(eventEntity);
        //        await Task.Delay(0);
        //        responseAPI.IsProcessSucessfuly = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, ex.Message);
        //        responseAPI.IsProcessSucessfuly = false;
        //        responseAPI.MessageProcess = ex.Message;
        //        return StatusCode(500, responseAPI);
        //    }

        //    return Ok(responseAPI);

        //}

        //Deletar Recurso (Delete Resource)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var responseAPI = new ResponseAPI<Events>();

            try
            {
                responseAPI.IsProcessSucessfuly = await _eventService.DeleteEvent(id);
                if (!responseAPI.IsProcessSucessfuly) return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                responseAPI.IsProcessSucessfuly = false;
                responseAPI.MessageProcess = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, responseAPI);
            }

            return Ok(responseAPI);

        }

    }
}