using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCrud.Data
{
    public class CustomerDetails
    {
        [Key]
        [ForeignKey("Customer")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int customerId { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }

        public Customer Customer { get; set; }  
    }
}
