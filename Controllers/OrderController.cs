using EFCrud.Data;
using EFCrud.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly EcommerceDBcontext ecommerceDBcontext;

        public OrderController(EcommerceDBcontext ecommerceDBcontext)
        {
            this.ecommerceDBcontext = ecommerceDBcontext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderCreateDTO orderDTO)
        {
            try
            {
                // Create customer
                var customer = new Customer
                {
                    customerName = orderDTO.CustomerName,
                    CustomerDetails = new CustomerDetails
                    {
                        address = orderDTO.Address,
                        phoneNumber = orderDTO.PhoneNumber
                    }
                };

                // Add customer to context
                ecommerceDBcontext.Customers.Add(customer);
                await ecommerceDBcontext.SaveChangesAsync();

                // Create order
                var order = new Order
                {
                    customerId = customer.customerId,
                    orderDate = DateTime.UtcNow
                };

                // Add order products
                var orderProducts = orderDTO.Products.Select(p => new OrderProduct
                {
                    orderId = order.orderId,
                    productId = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Quantity = p.Quantity
                }).ToList();

                ecommerceDBcontext.Orders.Add(order);
                ecommerceDBcontext.OrderProducts.AddRange(orderProducts);

                // Save all changes
                await ecommerceDBcontext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error creating order: " + ex.Message);
            }
        }
    }
