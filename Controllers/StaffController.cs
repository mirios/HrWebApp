using HrWebApp.Data;
using HrWebApp.Interfaces;
using HrWebApp.Models;
using HrWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace HrWebApp.Controllers
{
    public class StaffController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IPhotoService _photoService;

        public StaffController(ApplicationDbContext context, IPhotoService photoService)
        {
            _photoService = photoService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.staffs = await _context.Staffs.ToListAsync();
            ViewBag.addresses = await _context.Addresses.ToListAsync();
            ViewBag.count = 0;
            return View();
        }

        [HttpPost]
        public ActionResult DeleteStaff(int id)
        {
            Console.WriteLine(id);
            Staff delStaffAddress = _context.Staffs.Include(a => a.Address).Where(o => o.Id == id).FirstOrDefault();
            _context.Remove(delStaffAddress.Address);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditStaff(int id)
        {
            Staff editStaff = _context.Staffs.Include(a => a.Address).Where(o => o.Id == id).FirstOrDefault();
            return View(editStaff);
        }

        [HttpPost]
        public ActionResult SaveEditStaff(
            int Id,
            string FirstName, 
            string LastName, 
            string City, 
            int ZipCode, 
            string State, 
            string Streets,
            string PhoneNumber,
            int Day,
            int Mount,
            int Year,
            string PassportCode,
            string TaxpayerCode,
            string Department,
            string RoleInDepartment)
        {
            var staff = _context.Staffs.Include(a => a.Address).Where(o => o.Id == Id).FirstOrDefault();
            staff.FirstName = FirstName;
            staff.LastName = LastName;
            staff.Address.City = City;
            staff.Address.ZipCode = ZipCode;
            staff.Address.State = State;
            staff.Address.Street = Streets;
            staff.PhoneNumber = PhoneNumber;
            staff.DateStaff = new DateOnly((int)Year, (int)Mount, (int)Day);
            staff.PassportCode = PassportCode;
            staff.TaxpayerCode = TaxpayerCode;
            staff.Department = Department;
            staff.RoleInDepartment = RoleInDepartment;
            _context.SaveChanges();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImg(UploadImgViewModel staffVM)
        {
            Console.Write(staffVM.UserId);
            var staff = _context.Staffs.Where(o => o.Id == staffVM.UserId).FirstOrDefault();
            var result = await _photoService.AddPhotoAsync(staffVM.Image);
            staff.Image = result.Url.ToString();
            _context.SaveChanges();
            return RedirectToAction("Index", "Staff");
        }
    }
}
