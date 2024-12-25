using HrWebApp.Data;
using HrWebApp.Models;
using HrWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HrWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ApplicationDbContext context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var user = await _userManager.FindByEmailAsync(loginViewModel.EmailAddress);

            if (user != null)
            {
                //User is found, check password
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (passwordCheck)
                {
                    //Password correct, sign in
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        //IdentityUser User = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);


                        return RedirectToAction("Index", "Dashboards");
                    }
                }
                //Password is incorrect
                TempData["Error"] = "Wrong credentials. Please try again";
                return View(loginViewModel);
            }
            //User not found
            TempData["Error"] = "Wrong credentials. Please try again";
            return View(loginViewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            var user = await _userManager.FindByEmailAsync(registerViewModel.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerViewModel);
            }
            var newUser = new AppUser()
            {
                Email = registerViewModel.EmailAddress,
                UserName = registerViewModel.EmailAddress,
                Staff = new Staff()
                {
                    Email = registerViewModel.EmailAddress,
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    Address = new Address()
                    {
                        Street = registerViewModel.Streets,
                        City = registerViewModel.City,
                        State = registerViewModel.State,
                        ZipCode = registerViewModel.ZipCode
                    },
                    AllDay = 15,
                    Hired = DateOnly.FromDateTime(DateTime.Now),
                    DateStaff = new DateOnly((int)registerViewModel.Year, (int)registerViewModel.Mount, (int)registerViewModel.Day),
                    PhoneNumber = registerViewModel.PhoneNumber,
                    PassportCode = registerViewModel.PassportCode,
                    TaxpayerCode = registerViewModel.TaxpayerCode,
                    Department = registerViewModel.Department,
                    RoleInDepartment = registerViewModel.RoleInDepartment
                }
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return RedirectToAction("Index", "Staff");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
