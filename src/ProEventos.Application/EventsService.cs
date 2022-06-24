using ProEventos.Application.Interfaces;
using ProEventos.Domain.Entities;
using ProEventos.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application
{
    public class EventsService : IEventService
    {
        private readonly IGeneralPersist _generalPersist;
        private readonly IEventsPersist _eventPersist;

        public EventsService(IGeneralPersist generalPersist, IEventsPersist eventPersist)
        {
            this._generalPersist = generalPersist;
            this._eventPersist = eventPersist;
        }

        public async Task<Events> AddEvent(Events model)
        {
            try{
                _generalPersist.Add<Events>(model);
                if(await _generalPersist.SaveChangesAsync())
                {
                    return await _eventPersist.GetAllEventByIdAsync(model.IdEvent, false);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }

        public async Task<Events> UpdateEvent(int IdEvent, Events model)
        {
            try
            {
                var eventItem = await _eventPersist.GetAllEventByIdAsync(IdEvent, false);
                if (eventItem == null) return null;

                model.IdEvent = eventItem.IdEvent;

                _generalPersist.Update(model);

                if(await _generalPersist.SaveChangesAsync())
                {
                    return await _eventPersist.GetAllEventByIdAsync(model.IdEvent, false);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return null;

        }

        public async Task<bool> DeleteEvent(int IdEvent)
        {
            try
            {
                var eventItem = await _eventPersist.GetAllEventByIdAsync(IdEvent, false);
                if (eventItem == null) throw new Exception("Event item not found!");

                _generalPersist.Delete<Events>(eventItem);

                return await _generalPersist.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Events[]> GetAllEventsAsync(bool includeSpeakerOfEvents = false)
        {
            throw new NotImplementedException();
        }

        public async Task<Events[]> GetAllEventsByTheme(string theme, bool includeSpeakerOfEvents = false)
        {
            throw new NotImplementedException();
        }

        public async Task<Events> GetEventById(int IdEvent, bool includeSpeakerOfEvents = false)
        {
            throw new NotImplementedException();
        }

        
    }
}
