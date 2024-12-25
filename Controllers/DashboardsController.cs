using HrWebApp.Data;
using HrWebApp.Models;
using HrWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrWebApp.Controllers
{
    public class DashboardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.staffVac = await _context.Vacations.ToListAsync();
            ViewBag.staffVac.Reverse();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddVacation(VacationViewModel vacationVM)
        {
            
            var AddVac = new Vacation()
            {
                StaffId = vacationVM.UserId,
                StartDate = new DateOnly((int)vacationVM.StartYear, (int)vacationVM.StartMonth, (int)vacationVM.StartDay),
                EndDate = new DateOnly((int)vacationVM.LastYear, (int)vacationVM.LastMonth, (int)vacationVM.LastDay)
            };
            _context.Vacations.Add(AddVac);
            _context.SaveChanges();
            return RedirectToAction("Index", "Dashboards");
        }

        [HttpPost]
        public async Task<IActionResult> VacationStatus(VacationViewModel vacationVM)
        {
            Console.WriteLine(vacationVM.Verdict);
            var staff = _context.Staffs.Where(o => o.Id == vacationVM.UserId).FirstOrDefault();
            var vac = _context.Vacations.Where(o => o.StaffId == vacationVM.UserId).FirstOrDefault(o => o.success == null);
            Console.WriteLine(vacationVM.UserId);
            Console.WriteLine(vac.Id);
            Console.WriteLine(staff);
            if (vacationVM.Verdict == 1)
            {
                vac.success = true;
                staff.AllDay = staff.AllDay - (vac.EndDate.Day - vac.StartDate.Day);
                Console.WriteLine(staff.AllDay);
            }
            else if (vacationVM.Verdict == 0) vac.success = false;
            _context.SaveChanges();
            return RedirectToAction("Index", "Dashboards");
        }
    }
}
