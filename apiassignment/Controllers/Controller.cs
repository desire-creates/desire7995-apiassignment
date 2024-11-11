using apiassignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace apiassignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly shopcontext _context;

        public OrderController(shopcontext context, ILogger<OrderController> logger)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllOrder()
        {
            return Ok(await _context.Orders.ToArrayAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrder(int id)
        {
            var Order = await _context.Orders.FindAsync(id);
            if (Order == null)
            {
                return NotFound();
            }
            return Ok(Order);
        }

        [HttpPost]
        public async Task<ActionResult<order>> PostOrder(order Order)
        {
            if (Order == null)
            {
                return BadRequest("Order cannot be null");
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetOrder",
                new { id = Order.ID },
                Order);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutOrder(int id, order Order)
        {
            if (id != Order.ID)
            {
                return BadRequest();
            }

            _context.Entry(Order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Orders.Any(p => p.ID == id))
                {
                    return NotFound();
                } 
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<order>> DeleteOrder(int id)
        {
            var Order = await _context.Orders.FindAsync(id);
            if (Order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(Order);
            await _context.SaveChangesAsync();

            return Order;
        }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly shopcontext _context;

        public ProductController(shopcontext context, ILogger<ProductController> logger)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProduct()
        {
            return Ok(await _context.Products.ToArrayAsync());  // Corrected to Products
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);  // Corrected to Products
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<product>> PostProduct(product product)  // Corrected variable name
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null");  // Changed message to reflect the entity
            }

            _context.Products.Add(product);  // Corrected to Products
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetProduct",  // Corrected action name
                new { id = product.productID },
                product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutProduct(int id, product product)  // Corrected to Product
        {
            if (id != product.productID)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(p => p.productID == id))  // Corrected to Products
                {
                    return NotFound();
                } 
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<product>> DeleteProduct(int id)  // Corrected variable name
        {
            var product = await _context.Products.FindAsync(id);  // Corrected to Products
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);  // Corrected to Products
            await _context.SaveChangesAsync();

            return product;
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly shopcontext _context;

        public UserController(shopcontext context, ILogger<UserController> logger)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUser()
        {
            return Ok(await _context.Users.ToArrayAsync());  // Corrected to Users
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)  // Corrected method name
        {
            var user = await _context.Users.FindAsync(id);  // Corrected to Users
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<user>> PostUser(user user)  // Corrected to User
        {
            if (user == null)
            {
                return BadRequest("User cannot be null");  // Changed message to reflect the entity
            }

            _context.Users.Add(user);  // Corrected to Users
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetUser",  // Corrected action name
                new { id = user.userID },
                user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(int id, user user)  // Corrected to User
        {
            if (id != user.userID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Users.Any(u => u.userID == id))  // Corrected to Users
                {
                    return NotFound();
                } 
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<user>> DeleteUser(int id)  // Corrected variable name
        {
            var user = await _context.Users.FindAsync(id);  // Corrected to Users
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);  // Corrected to Users
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
