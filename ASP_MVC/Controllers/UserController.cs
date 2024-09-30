using Microsoft.AspNetCore.Mvc;
using ASP_MVC.Models;
namespace ASP_MVC.Controllers
{
    public class UserController : Controller
    {
        List<User> _users = new List<User>
        {
            new User { Name = "John Doe", Age = 30, Position = "Developer", Salary = 60000 },
            new User { Name = "Jane Doe", Age = 25, Position = "Designer", Salary = 50000 },
            new User { Name = "Sammy Doe", Age = 35, Position = "Manager", Salary = 70000 },
            new User { Name = "Ron Doe", Age = 40, Position = "Developer", Salary = 80000 },
            new User { Name = "Don Doe", Age = 45, Position = "CEO", Salary = 100000 },
        };

        public IActionResult Index()
        {
            var user = new User
            {
                Name = "John Doe",
                Age = 30
            };

            ViewBag.User = user;
            ViewData["User"] = user;

            return View(user);
        }

        public IActionResult Users(string name, string position, string sortBy)
        {
            var filteredUsers = _users.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                filteredUsers = filteredUsers.Where(u => u.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(position))
            {
                filteredUsers = filteredUsers.Where(u => u.Position.Contains(position));
            }

            filteredUsers = sortBy switch
            {
                "Age" => filteredUsers.OrderBy(u => u.Age),
                "Salary" => filteredUsers.OrderBy(u => u.Salary),
                _ => filteredUsers
            };

            return View(filteredUsers.ToList());
        }
    
    }
}
