using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProEventos.Domain
{
	public sealed class Events
    {
        private const int MAX_PEOPLE_FOR_AUDITORIUM = 900;
        private const int MIN_TEXT_TO_INPUT = default;
        private const int MAX_TEXT_TO_INPUT = 255;
        private const int MIN_ROW_ID_TO_REGISTRY = default;
        private const int MAX_ROW_ID_TO_REGISTRY = 32767;

        [Key]
        public int IdEvent { get; private set; }
        public string AddressCity { get; private set; }
        public string DateOfTheEvent { get; private set; }
        public string ThemeOfEvent { get; private set; }
        public int NumberOfPeople { get; private set; }
        public string LotOfEvent { get; private set; }
        public string FlyerPictureFile { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public IEnumerable<Lot> Lots { get; private set; }
        public IEnumerable<SocialMedia> SocialMedias { get; private set; }
        public IEnumerable<SpeakerOfEvent> SpeakerOfEvents { get; private set; }

        [JsonIgnore]
        public EventsAndSpeakerOfEvent[] EventsAndSpeakerOfEvent { get; private set; }

        public Events(int idEvent,
            string addressCity,
            string dateOfTheEvent,
            string themeOfEvent,
            int numberOfPeople,
            string lotOfEvent,
            string flyerPictureFile)
        {
            IdEvent = idEvent;
            AddressCity = addressCity;
            DateOfTheEvent = dateOfTheEvent;
            ThemeOfEvent = themeOfEvent;
            NumberOfPeople = numberOfPeople;
            LotOfEvent = lotOfEvent;
            FlyerPictureFile = flyerPictureFile;

            ValidadeDomain();

        }

        public void EditEvent(int idEvent,
            string addressCity,
            string dateOfTheEvent,
            string themeOfEvent,
            int numberOfPeople,
            string lotOfEvent,
            string flyerPictureFile,
            Events eventsInDataStore = null)
        {
            IdEvent = (idEvent != eventsInDataStore.IdEvent && idEvent != default) ? 
                idEvent : eventsInDataStore.IdEvent;
            AddressCity = (addressCity is not null && !addressCity.Equals(eventsInDataStore.AddressCity)) ? 
                addressCity : eventsInDataStore.AddressCity;
            DateOfTheEvent = (dateOfTheEvent is not null && !dateOfTheEvent.Equals(eventsInDataStore.DateOfTheEvent)) ? 
                dateOfTheEvent : eventsInDataStore.DateOfTheEvent;
            ThemeOfEvent = (themeOfEvent is not null && !themeOfEvent.Equals(eventsInDataStore.ThemeOfEvent)) ? 
                themeOfEvent : eventsInDataStore.ThemeOfEvent;
            NumberOfPeople = (!numberOfPeople!.Equals(eventsInDataStore.NumberOfPeople) && !numberOfPeople.Equals(default)) ? 
                numberOfPeople : eventsInDataStore.NumberOfPeople;
            LotOfEvent = (lotOfEvent is not null && !lotOfEvent.Equals(eventsInDataStore.LotOfEvent)) ? 
                lotOfEvent : eventsInDataStore.LotOfEvent;
            FlyerPictureFile = (flyerPictureFile is not null && !flyerPictureFile.Equals(eventsInDataStore.FlyerPictureFile)) ? 
                flyerPictureFile : eventsInDataStore.FlyerPictureFile;

            ValidadeDomain();

        }

        private void ValidadeDomain()
        {
            if (!(IdEvent >= MIN_ROW_ID_TO_REGISTRY && IdEvent <= MAX_ROW_ID_TO_REGISTRY))
            {
                throw new ArgumentException($"{nameof(IdEvent)} must have a number between {MIN_ROW_ID_TO_REGISTRY} and {MAX_ROW_ID_TO_REGISTRY}");
            }

            if (AddressCity.Length > MIN_TEXT_TO_INPUT && AddressCity.Length <= MAX_TEXT_TO_INPUT)
            {
                throw new ArgumentException($"The property {nameof(AddressCity)} was a length outside of {MIN_TEXT_TO_INPUT} and {MAX_TEXT_TO_INPUT} character.");
            }

            if (DateTime.TryParse(DateOfTheEvent, out var dateTime))
            {
                throw new ArgumentException($"The property {nameof(DateOfTheEvent)} is not a date type.");
            }

            if (ThemeOfEvent.Length > MIN_TEXT_TO_INPUT && ThemeOfEvent.Length <= MAX_TEXT_TO_INPUT)
            {
                throw new ArgumentException($"The property {nameof(ThemeOfEvent)} was a length outside of {MIN_TEXT_TO_INPUT} and {MAX_TEXT_TO_INPUT} character.");
            }

            if (NumberOfPeople > MAX_PEOPLE_FOR_AUDITORIUM)
            {
                throw new ArgumentException($"This event is impossible to do, because the auditorium comport only {MAX_PEOPLE_FOR_AUDITORIUM} people.");
            }

            if (LotOfEvent.Length > MIN_TEXT_TO_INPUT && LotOfEvent.Length <= MAX_TEXT_TO_INPUT)
            {
                throw new ArgumentException($"The property {nameof(LotOfEvent)} was a length outside of {MIN_TEXT_TO_INPUT} and {MAX_TEXT_TO_INPUT} character.");
            }

            if (FlyerPictureFile.Length > MIN_TEXT_TO_INPUT && FlyerPictureFile.Length <= MAX_TEXT_TO_INPUT)
            {
                throw new ArgumentException($"The property {nameof(FlyerPictureFile)} was a length outside of {MIN_TEXT_TO_INPUT} and {MAX_TEXT_TO_INPUT} character.");
            }

        }

    }
}