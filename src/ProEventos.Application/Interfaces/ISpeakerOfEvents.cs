using ProEventos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application.Interfaces
{
    public interface ISpeakerOfEvents
    {
        Task<SpeakerOfEvent> Add(SpeakerOfEvent model);
        Task<SpeakerOfEvent> Update(SpeakerOfEvent model);
        Task<bool> Delete(int IdSpeakerOfEvent);

        Task<SpeakerOfEvent[]> GetAllSpeakerOfEventByNameAsync(string Name, bool includeEvents = false);
        Task<SpeakerOfEvent[]> GetAllSpeakerOfEventAsync(bool includeEvents = false);
        Task<SpeakerOfEvent> GetSpeakerOfEventId(int IdSpeakerOfEvent, bool includeEvents = false);
    }
}
