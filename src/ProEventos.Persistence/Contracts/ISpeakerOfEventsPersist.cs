using ProEventos.Domain.Entities;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Contracts
{
    public interface ISpeakerOfEventPersist
    {
        //related with SpeakerOfEvents
        Task<SpeakerOfEvent> GetAllSpeakerOfEventByIdAsync(int IdSpeakerOfEvent, bool includeEvents = false);
        Task<SpeakerOfEvent[]> GetAllSpeakerOfEvents(bool includeEvents = false);
        Task<SpeakerOfEvent[]> GetAllSpeakerOfEventsByNameAsync(string tema, bool includeEvents = false);
        
        

    }
}
