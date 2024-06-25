namespace Core.Accounts
{
    public class LoginAccountDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Discriminator { get; set; }
    }
}
