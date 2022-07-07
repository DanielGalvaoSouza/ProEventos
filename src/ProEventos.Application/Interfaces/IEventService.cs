using ProEventos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application.Interfaces
{
    public interface IEventService
    {
        Task<Events> AddEvent(Events model);
        Task<Events> UpdateEvent(int IdEvent, Events model);
        Task<bool> DeleteEvent(int IdEvent);

        Task<Events[]> GetAllEventsAsync(bool includeSpeakerOfEvents = false);
        Task<Events[]> GetAllEventsByTheme(string theme, bool includeSpeakerOfEvents = false);
        Task<Events> GetEventById(int IdEvent, bool includeSpeakerOfEvents = false);

    }
}
