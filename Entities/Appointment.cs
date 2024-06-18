using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Appointment
    {
        [Key]
        public Guid Id { get; set; }

        public DateOnly DateCreated { get; set; }

        public string Notes { get; set; }

        public string CustomerName { get; set; }

        public bool IsCheckedUp { get; set; } = false;

        public bool IsCancelled { get; set; } = false;

        // Reference entity
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
    }
}
