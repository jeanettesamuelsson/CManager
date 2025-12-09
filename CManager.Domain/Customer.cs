namespace CManager.Domain
{
    public class Customer

    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telephone { get; set; } = null!;
        public AddresModel Addres { get; set; }

    }

}
