namespace EFCrud.DTOs
{
    public class CustomerDetailsDTO
    {
        public int customerId { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
    }

    public class CustomerDTO
    {
        public int customerId { get; set; }
        public string customerName { get; set; }
        public CustomerDetailsDTO Details { get; set; }
    }
}


