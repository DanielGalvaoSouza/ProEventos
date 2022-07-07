using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Domain.Entities
{
    public class SpeakerOfEvent
    {
        [Key]
        public int IdSpeakerOfEvent { get; set; }
        public string Name { get; set; }
        public string SmallCurriculum { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<SocialMedia> SocialMedias { get; set; }
        public IEnumerable<EventsAndSpeakerOfEvent> EventsAndSpeakerOfEvents { get; set; }
    }
}
