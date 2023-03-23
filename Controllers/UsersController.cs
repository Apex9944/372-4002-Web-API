using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using webAPI2.DBContext;
using webAPI2.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace webAPI2.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;

        private DatabaseContext _databaseContext;

        public UsersController(ILogger<UsersController> logger, DatabaseContext DBContext)
        {
            _logger = logger;
           _databaseContext = DBContext;
        }

       

[HttpGet]
public ActionResult<IEnumerable<UserTable>> GetAllUsers()
{
    var userList = _databaseContext.UserTable.ToList();
    if (userList == null)
    {
        return Ok(new { message = "still no user" });
    }
    return userList;
}

[HttpGet("{id}")]
public ActionResult<UserTable> GetUser(int id)
{
    var user = _databaseContext.UserTable.Find(id);
    if (user == null)
    {
        return NotFound();
    }
    return user;
}

[HttpPost]
public ActionResult<UserTable> NewUser(UserTable user)
{
_databaseContext.UserTable.Add(user);
_databaseContext.SaveChanges();
return Ok(user);
}

[HttpPut]
public ActionResult<UserTable> UpdateUser(int id, UserTable updatedUser)
{
    var user = _databaseContext.UserTable.Find(id);

    if (user == null)
    {
        return NotFound();
    }

    user.Id = updatedUser.Id;
    user.Email = updatedUser.Email;
    user.Password = updatedUser.Password;
    
    _databaseContext.UserTable.Update(user);
    _databaseContext.SaveChanges();

    return Ok(user);
}

[HttpDelete("{id}")]
public ActionResult DeleteUser(int id)
{
    var user = _databaseContext.UserTable.FirstOrDefault(u => u.Id == id);
    if (user == null)
    {
        return NotFound();
    }

    _databaseContext.UserTable.Remove(user);
    _databaseContext.SaveChanges();

    return Ok();
}
    }
}