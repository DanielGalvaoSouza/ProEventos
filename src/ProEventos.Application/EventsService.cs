using ProEventos.Application.Interfaces;
using ProEventos.Domain.Entities;
using ProEventos.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ProEventos.Application
{
    public class EventsService : IEventService
    {
        private readonly IGeneralPersist _generalPersist;
        private readonly IEventsPersist _eventPersist;
        private readonly ILogger<EventsService> _logger;

        public EventsService(IGeneralPersist generalPersist,
            IEventsPersist eventPersist,
            ILogger<EventsService> logger)
        {
            this._generalPersist = generalPersist;
            this._eventPersist = eventPersist;
            this._logger = logger;
        }

        public async Task<Events> AddEvent(Events model)
        {
            try{
                _generalPersist.Add<Events>(model);
                if(await _generalPersist.SaveChangesAsync())
                {
                    return await _eventPersist.GetEventByIdAsync(model.IdEvent, false);
                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex, ex.Message);
                throw new Exception(ex.Message);
            }

            return null;
        }

        public async Task<Events> UpdateEvent(int IdEvent, Events model)
        {
            try
            {
                var eventItem = await _eventPersist.GetEventByIdAsync(IdEvent, false);
                if (eventItem == null) return null;

                model.IdEvent = eventItem.IdEvent;

                _generalPersist.Update(model);

                if(await _generalPersist.SaveChangesAsync())
                {
                    return await _eventPersist.GetEventByIdAsync(model.IdEvent, false);
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, ex.Message);
                throw new Exception(ex.Message);
            }
            
            return null;

        }

        public async Task<bool> DeleteEvent(int IdEvent)
        {
            try
            {
                var eventItem = await _eventPersist.GetEventByIdAsync(IdEvent, false);
                if (eventItem == null) throw new Exception("Event item not found!");

                _generalPersist.Delete<Events>(eventItem);

                return await _generalPersist.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex, ex.Message);
                throw new Exception(ex.Message);
            }

        }



        public async Task<Events[]> GetAllEventsAsync(bool includeSpeakerOfEvents = false)
        {
            try
            {
                var _eventItem = await _eventPersist.GetAllEventsAsync(includeSpeakerOfEvents);
                if(_eventPersist == null) return null;

                return _eventItem;

            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex, ex.Message);
                throw new Exception(ex.Message);
            }

        }

        public async Task<Events[]> GetAllEventsByTheme(string theme, bool includeSpeakerOfEvents = false)
        {

            try
            {
                var eventItem = await _eventPersist.GetAllEventsByThemeAsync(theme, includeSpeakerOfEvents);
                if (eventItem == null) return null;

                return eventItem;

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<Events> GetEventById(int IdEvent, bool includeSpeakerOfEvents = false)
        {
            try
            {
                var eventItem = await _eventPersist.GetEventByIdAsync(IdEvent, includeSpeakerOfEvents);
                if (eventItem == null) return null;

                return eventItem;

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, ex.Message);
                throw new Exception(ex.Message);
            }
        }

        
    }
}
