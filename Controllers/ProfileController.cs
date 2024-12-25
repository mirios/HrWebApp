using Microsoft.AspNetCore.Mvc;

namespace HrWebApp.Controllers
{
    public class ProfileController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

    }
}
