namespace Core.Accounts
{
    public class AccountDTO
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Discriminator { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}
