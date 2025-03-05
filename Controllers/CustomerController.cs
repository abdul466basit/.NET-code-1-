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

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetCustomerByIdAsync([FromRoute] int id)
        //{
        //    var customer = await this.ecommerceDBcontext.Customers
        //        .Include(c => c.CustomerDetails)
        //        .Include(c => c.Orders)
        //        .FirstOrDefaultAsync(c => c.customerId == id);
        //    return Ok(customer);
        //}

        [HttpGet("{id}")]
        [ActionName(nameof(GetCustomerByIdAsync))]
        public async Task<IActionResult> GetCustomerByIdAsync([FromRoute] int id)
        {
            var customer = await this.ecommerceDBcontext.Customers
                .Include(c => c.CustomerDetails)
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(c => c.customerId == id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCustomers([FromBody] CreateCustomerDTO customerDTO)
        {
            try
            {
                // Create customer
                var customer = new Customer
                {
                    customerName = customerDTO.customerName,
                    CustomerDetails = new CustomerDetails
                    {
                        address = customerDTO.Details.address,
                        phoneNumber = customerDTO.Details.phoneNumber
                    }
                };

                // Add customer to context
                ecommerceDBcontext.Customers.Add(customer);
                await ecommerceDBcontext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetCustomerByIdAsync), new { id = customer.customerId }, customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error creating customer: " + ex.Message);
            }
        }

    }
}



