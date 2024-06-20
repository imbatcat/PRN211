using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
