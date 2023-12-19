using Microsoft.AspNetCore.Mvc;

namespace nov30task.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
