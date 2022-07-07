using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProEventos.Domain.Entities
{
	public class Events
    {
        [Key]
        public int IdEvent { get; set; }
        public string AddressCity { get; set; }
        public string DateOfTheEvent { get; set; }
        public string ThemeOfEvent { get; set; }
        public int NumberOfPeople { get; set; }
        public string LotOfEvent { get; set; }
        public string FlyerPictureFile { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Lot> Lots { get; set; }
        public IEnumerable<SocialMedia> SocialMedias { get; set; }
        public IEnumerable<SpeakerOfEvent> SpeakerOfEvents { get; set; }
        
        [JsonIgnore]
        public EventsAndSpeakerOfEvent[] EventsAndSpeakerOfEvents { get; set; }
        
    }
}