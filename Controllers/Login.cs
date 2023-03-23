using Microsoft.AspNetCore.Mvc;
using webAPI2.DBContext;
using webAPI2.Models;
using System.Linq;

namespace webAPI2.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly DatabaseContext _dbContext;

        public LoginController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            // Check if user with email and password exists in database
            UserTable user = _dbContext.UserTable.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);

            if (user != null)
            {
                // Create session or cookie to keep user logged in
                HttpContext.Session.SetString("UserId", user.Id.ToString());

                return Ok("Login successful");
            }
            else
            {
                return BadRequest("Invalid login credentials");
            }
        }
    }
}
