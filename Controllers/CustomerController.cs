using EFCrud.Data;
using EFCrud.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly EcommerceDBcontext ecommerceDBcontext;

        public CustomerController(EcommerceDBcontext ecommerceDBcontext)
        {
            this.ecommerceDBcontext = ecommerceDBcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await this.ecommerceDBcontext.Customers
                .Include(c => c.CustomerDetails)
                .Select(c => new CustomerDTO
                {
                    customerId = c.customerId,
                    customerName = c.customerName,
                    Details = new CustomerDetailsDTO
                    {
                        customerId = c.CustomerDetails.customerId,
                        address = c.CustomerDetails.address,
                        phoneNumber = c.CustomerDetails.phoneNumber
                    }
                })
                .ToListAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerByIdAsync([FromRoute] int id)
        {
            var customer = await this.ecommerceDBcontext.Customers
                .Include(c => c.CustomerDetails)
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(c => c.customerId == id);
            return Ok(customer);
        }
    }
}



