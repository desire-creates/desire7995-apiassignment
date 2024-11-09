using apiassignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiassignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly shopcontext _context;

        public UserController(shopcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<user> GetAllUsers()
        {
            return _context.Users.ToArray();
        }
    }
}