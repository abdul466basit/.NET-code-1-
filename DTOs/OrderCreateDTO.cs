namespace EFCrud.DTOs
{
    public class OrderCreateDTO
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<ProductOrderDTO> Products { get; set; }
    }

    public class ProductOrderDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
