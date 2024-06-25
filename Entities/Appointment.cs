using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Appointment
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Notes { get; set; }

        public string CustomerName { get; set; }

        public bool IsCheckedUp { get; set; } = false;

        public bool IsCancelled { get; set; } = false;

        // Reference entity
        public Guid AccountId { get; set; }

        public Guid appRequestId { get; set; }
        public Account Account { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
    }
}
