using HrWebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace HrWebApp.Controllers
{
    public class StatisticController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StatisticController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("user"))
            {
                return RedirectToAction("Index", "Dashboards");
            }
            ViewBag.vac1 = _context.Vacations.Where(o => o.StartDate.Month == 01).Count();
            ViewBag.vac2 = _context.Vacations.Where(o => o.StartDate.Month == 02).Count();
            ViewBag.vac3 = _context.Vacations.Where(o => o.StartDate.Month == 03).Count();
            ViewBag.vac4 = _context.Vacations.Where(o => o.StartDate.Month == 04).Count();
            ViewBag.vac5 = _context.Vacations.Where(o => o.StartDate.Month == 05).Count();
            ViewBag.vac6 = _context.Vacations.Where(o => o.StartDate.Month == 06).Count();
            ViewBag.vac7 = _context.Vacations.Where(o => o.StartDate.Month == 07).Count();
            ViewBag.vac8 = _context.Vacations.Where(o => o.StartDate.Month == 08).Count();
            ViewBag.vac9 = _context.Vacations.Where(o => o.StartDate.Month == 09).Count();
            ViewBag.vac10 = _context.Vacations.Where(o => o.StartDate.Month == 10).Count();
            ViewBag.vac11 = _context.Vacations.Where(o => o.StartDate.Month == 11).Count();
            ViewBag.vac12 = _context.Vacations.Where(o => o.StartDate.Month == 12).Count();
            return View();
        }


    }
}
