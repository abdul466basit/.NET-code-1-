namespace EFCrud.DTOs
{
    public class CustomerDetailsDTO
    {
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public CustomerDetailsDTO Details { get; set; }
    }
}
