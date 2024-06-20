using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MedicalRecord
    {
        [Key]
        public Guid MedId {  get; set; }
        [Required]
        [StringLength(200)]
        public string Symptoms { get; set; }

        [Required]
        [StringLength(200)]
        public string CustomerName { get; set; }
        [StringLength(200)]
        public string Diagnosis { get; set; }
        [StringLength(200)]
        public string? Note {  get; set; }

        [ForeignKey(nameof(appointmentId))]
        public Appointment appointment { get; set; }
        public Guid appointmentId {  get; set; }
    }
}
