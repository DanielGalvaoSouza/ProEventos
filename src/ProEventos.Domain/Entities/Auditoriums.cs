using System;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Domain.Entities
{
    public sealed class Auditoriums
    {
        [Key]
        public int IdAuditorium { get; private set; }
        public string Name { get; private set; }
        public string LocationAddress { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public int NumberOfSeats { get; private set; }
        public bool HasBusesToTransportVisitors { get; private set; }
    }
}