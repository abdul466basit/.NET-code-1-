namespace EFCrud.DTOs
{

    public class CreateCustomerDTO
    {
        public string customerName { get; set; }
        public CustomerDetailsDTO Details { get; set; }
    }

    public class CreateCustomerDetailsDTO
    {
        public string address { get; set; }
        public string phoneNumber { get; set; }
    }

}
