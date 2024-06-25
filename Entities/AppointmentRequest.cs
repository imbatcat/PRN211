using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class AppointmentRequest
    {
        [Key]
        public Guid appRequestId { get; set; }
        public DateTime requestDate { get; set; }

        [Required]
        [StringLength(100)]
        public string customerName { get; set; }
        public bool isApproved { get; set; } = false;

    }
}
