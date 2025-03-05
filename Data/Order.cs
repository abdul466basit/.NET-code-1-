using System.ComponentModel.DataAnnotations;

namespace EFCrud.Data
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }
        public int customerId { get; set; }
        public DateTime orderDate { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }

    }
}


