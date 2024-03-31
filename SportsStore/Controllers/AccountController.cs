using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
