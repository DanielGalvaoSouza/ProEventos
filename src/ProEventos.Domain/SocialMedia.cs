using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class SocialMedia
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public int? EventId { get; set; }
        public Events Event { get; set; }
        public int? SpeakerOfEventId { get; set; }
        public SpeakerOfEvent SpeakerOfEvent{ get; set; }
    }
}
