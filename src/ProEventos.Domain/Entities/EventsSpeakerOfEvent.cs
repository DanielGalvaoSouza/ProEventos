using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Domain.Entities
{
    public class EventsAndSpeakerOfEvent
    {
        public int SpeakerOfEventId { get; set; }
        public SpeakerOfEvent SpeakerOfEvent { get; set; }
        public int EventId { get; set; }
        public Events Event { get; set; }
    }
}
