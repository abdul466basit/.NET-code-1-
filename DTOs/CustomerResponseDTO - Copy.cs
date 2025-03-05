namespace EFCrud.DTOs
{
    public class CustomerResponseDTO
    {
        public int customerId { get; set; }
        public string customerName { get; set; }
        public CustomerDetailsResponseDTO Details { get; set; }
    }

    public class CustomerDetailsResponseDTO
    {
        public int customerId { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
    }
}



