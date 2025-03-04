using System.ComponentModel.DataAnnotations;

namespace EFCrud.Data
{
    public class Customer
    {
        [Key]
        public int customerId { get; set; }
        public string customerName { get; set; }
        
        public CustomerDetails CustomerDetails { get; set; }    
        public ICollection<Order> Orders { get; set; }

    }
}


