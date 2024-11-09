using apiassignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiassignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly shopcontext _context;

        public OrderController(shopcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<order> GetAllOrders()
        {
            return _context.Orders.ToArray();
        }

    }
}