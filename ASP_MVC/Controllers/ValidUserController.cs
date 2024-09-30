using ASP_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASP_MVC.Controllers
{
    public class ValidUserController : Controller
    {
        public IActionResult Register()
        {
         
            if (TempData["User"] is string userJson)
            {
                var user = JsonConvert.DeserializeObject<User>(userJson);
                return View(user);
            }
            return View();
        }
        [HttpPost]
        public IActionResult RegisterPost(User user) {

            TempData["WasValid"] = true;

            if (ModelState.IsValid)
            {
                TempData["User"] = JsonConvert.SerializeObject(user);
            }
            return RedirectToAction("Register");
        }
    }
}
