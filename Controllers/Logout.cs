using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;
using webAPI2.DBContext;

namespace webAPI2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase
    {
        private readonly ILogger<LogoutController> _logger;

        private DatabaseContext _databaseContext;

        public LogoutController(ILogger<LogoutController> logger, DatabaseContext DBContext)
        {
            _logger = logger;
           _databaseContext = DBContext;
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Ok("Logged out successfully");
        }
    }
}
