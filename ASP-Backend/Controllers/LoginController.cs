using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_Backend.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Backend.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly DataContext _context;
        public LoginController(DataContext context)
        {
            _context = context;
        }

        // POST api/login
        [HttpPost]
        public async Task<ActionResult<User>> Login(User user)
        {
            var users = _context.Users.ToList();
            
            foreach (var u in users)
            {
                if(u.UserName == user.UserName && u.Password == user.Password)
                {
                    return u;
                }
            }
            return Unauthorized();
        }
    }
}
