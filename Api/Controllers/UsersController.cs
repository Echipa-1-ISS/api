using System.Collections.Generic;
using System.Linq;
using Data;
using Data.models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UMSDatabaseContext _context;

        public UsersController(UMSDatabaseContext context)
        {
            _context = context;
        }
        
        [HttpGet()]
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        [HttpPost()]
        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user.Id;
        }
    }
}