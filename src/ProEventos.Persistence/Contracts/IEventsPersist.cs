using ProEventos.Domain.Entities;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Contracts
{
    public interface IEventsPersist
    {
        //related with events
        Task<Events> GetAllEventByIdAsync(int IdEvent, bool includeSpeakerOfEvents = false);
        Task<Events[]> GetAllEventsAsync(bool includeSpeakerOfEvents = false);
        Task<Events[]> GetAllEventsByThemeAsync(string tema, bool includeSpeakerOfEvents = false);
        
    }
}
