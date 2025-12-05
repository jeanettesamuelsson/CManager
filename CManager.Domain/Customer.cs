namespace CManager.Domain
{
    public class Customer

    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Guid Id { get; set; }

    }
}
