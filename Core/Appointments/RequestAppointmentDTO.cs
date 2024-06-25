namespace Core.Appointments
{
    public class RequestAppointmentDTO
    {
        public Guid ID { get; set; }
        public DateTime RequestDate { get; set; }
        public string CustomerName { get; set; }

    }
}
