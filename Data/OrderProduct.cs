using System.ComponentModel.DataAnnotations;

namespace EFCrud.Data
{
    public class OrderProduct
    {
        public int orderId { get; set; }
        public int productId { get; set; }

        // Navigation properties
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
