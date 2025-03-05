using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCrud.Data
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int customerId { get; set; }
        public string customerName { get; set; }
        
        public CustomerDetails CustomerDetails { get; set; }    
        public ICollection<Order> Orders { get; set; }
    }
}


