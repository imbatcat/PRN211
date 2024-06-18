using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Index(nameof(UserName), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class Account
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(15)]
        public string UserName { get; set; }

        public string FullName { get; set; }

        [PasswordPropertyText]
        [MaxLength(12)]
        public string Password { get; set; }

        public string Discriminator { get; set; }

        public DateOnly DateOfBirth { get; set; }
        public string? Department {  get; set; }
        public bool IsMale {  get; set; }

        public DateOnly JoinDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public string? Department { get; set; }

        public bool IsMale { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        // Reference entity
        public IEnumerable<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
