using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCrud.Data
{
    public class Product
    {
        [Key]
        public int productId { get; set; }
        public string productname { get; set; }

        public decimal price { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}


