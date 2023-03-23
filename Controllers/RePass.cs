using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using webAPI2.DBContext;
using webAPI2.Models;

namespace webAPI2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResetPasswordController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public ResetPasswordController(DatabaseContext DBContext)
        {
            _databaseContext = DBContext;
        }

        [HttpPut]
        public IActionResult ResetPassword(FPass model)
        {
            var user = _databaseContext.UserTable.SingleOrDefault(u => u.Email == model.Email && u.Password == model.OldPassword);

            if (user == null)
            {
                return NotFound();
            }

            if (model.NewPassword == model.OldPassword)
            {
                return BadRequest("New password cannot be the same as the old password");
            }

            user.Password = model.NewPassword;

            _databaseContext.SaveChanges();

            return Ok("Password reset successfully");
        }
    }
}
