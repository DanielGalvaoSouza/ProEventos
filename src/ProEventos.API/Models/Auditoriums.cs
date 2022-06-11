using System;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.API.Models
{
    public sealed class Auditoriums
    {
        private const int MIN_TEXT_TO_INPUT = default;
        private const int MAX_TEXT_TO_INPUT = 255;
        private const int MIN_ROW_ID_TO_REGISTRY = default;
        private const int MAX_ROW_ID_TO_REGISTRY = 32767;
        private const int MIN_SEATS_AUDITORIUM = default;
        private const int MAX_SEATS_AUDITORIUM = 1500;

        [Key]
        public int IdAuditorium { get; private set; }
        public string Name { get; private set; }
        public string LocationAddress { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public int NumberOfSeats { get; private set; }
        public bool HasBusesToTransportVisitors { get; private set; }

        public Auditoriums(int idAuditorium,
            string name,
            string locationAddress,
            string phone,
            string email,
            int numberOfSeats,
            bool hasBusesToTransportVisitors)
        {
            IdAuditorium = idAuditorium;
            Name = name;
            LocationAddress = locationAddress;
            Phone = phone;
            Email = email;
            NumberOfSeats = numberOfSeats;
            HasBusesToTransportVisitors = hasBusesToTransportVisitors;

            ValidateDomain();

        }

        public void EditAuditorium(int idAuditorium,
            string name,
            string locationAddress,
            string phone,
            string email,
            int numberOfSeats,
            bool hasBusesToTransportVisitors, 
            Auditoriums auditoriumsInDataStore = null)
        {
            IdAuditorium = idAuditorium != auditoriumsInDataStore.IdAuditorium ? idAuditorium : auditoriumsInDataStore.IdAuditorium;
            Name = !name.Equals(auditoriumsInDataStore.Name) ? name : auditoriumsInDataStore.Name;
            LocationAddress = locationAddress.Equals(auditoriumsInDataStore.LocationAddress) ? locationAddress : auditoriumsInDataStore.LocationAddress;
            Phone = !phone.Equals(auditoriumsInDataStore.Phone) ? phone : auditoriumsInDataStore.Phone;
            Email = !email.Equals(auditoriumsInDataStore.Email) ? email : auditoriumsInDataStore.Email;
            NumberOfSeats = numberOfSeats.Equals(auditoriumsInDataStore.NumberOfSeats) ? numberOfSeats : auditoriumsInDataStore.NumberOfSeats;
            HasBusesToTransportVisitors = !hasBusesToTransportVisitors.Equals(auditoriumsInDataStore.HasBusesToTransportVisitors) ? hasBusesToTransportVisitors : auditoriumsInDataStore.HasBusesToTransportVisitors;

            ValidateDomain();

        }

        private void ValidateDomain()
        {
            if(!(IdAuditorium >= MIN_ROW_ID_TO_REGISTRY && IdAuditorium <= MAX_ROW_ID_TO_REGISTRY))
            {
                throw new ArgumentException($"Auditorium must have a number between {MIN_ROW_ID_TO_REGISTRY} and {MAX_ROW_ID_TO_REGISTRY}");
            }

            if(!(Name.Length >= MIN_TEXT_TO_INPUT && Name.Length <= MAX_TEXT_TO_INPUT))
            {
                throw new ArgumentException($"The property {nameof(Name)} was a length outside of {MIN_TEXT_TO_INPUT} and {MAX_TEXT_TO_INPUT} character.");
            }

            if (!(LocationAddress.Length >= MIN_TEXT_TO_INPUT && LocationAddress.Length <= MAX_TEXT_TO_INPUT))
            {
                throw new ArgumentException($"The property {nameof(LocationAddress)} was a length outside of {MIN_TEXT_TO_INPUT} and {MAX_TEXT_TO_INPUT} character.");
            }

            if (!(Phone.Length >= MIN_TEXT_TO_INPUT && Phone.Length <= MAX_TEXT_TO_INPUT))
            {
                throw new ArgumentException($"The property {nameof(Phone)} was a length outside of {MIN_TEXT_TO_INPUT} and {MAX_TEXT_TO_INPUT} character.");
            }

            if (!(Email.Length >= MIN_TEXT_TO_INPUT && Email.Length <= MAX_TEXT_TO_INPUT))
            {
                throw new ArgumentException($"The property {nameof(Email)} was a length outside of {MIN_TEXT_TO_INPUT} and {MAX_TEXT_TO_INPUT} character.");
            }

            if (!(NumberOfSeats >= MIN_SEATS_AUDITORIUM && NumberOfSeats <= MAX_SEATS_AUDITORIUM))
            {
                throw new ArgumentException($"The property {nameof(NumberOfSeats)} was a length outside of {MIN_TEXT_TO_INPUT} and {MAX_TEXT_TO_INPUT} character.");
            }

        }



    }
}