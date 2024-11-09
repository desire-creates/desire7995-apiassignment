using apiassignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiassignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly shopcontext _context;

        public ProductController(shopcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<product> GetAllProducts()
        {
            return _context.Products.ToArray();
        }
    }
}