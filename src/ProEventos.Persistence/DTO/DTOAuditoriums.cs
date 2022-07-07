namespace ProEventos.Persistence.DTO
{
    public class DTOAuditoriums
    {
        public System.Nullable<int> IdAuditorium { get; set; }
        public string Name { get; set; }
        public string LocationAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public System.Nullable<int> NumberOfSeats { get; set; }
        public System.Nullable<bool> HasBusesToTransportVisitors { get; set; }
    }
}
