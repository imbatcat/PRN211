namespace Core.Accounts
{
    public class DoctorDTO
    {
        public string DoctorName { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public bool IsMale { get; set; }

        public DateOnly JoinDate { get; set; }

        public string Department { get; set; }

        public string Email { get; set; }
    }
}
