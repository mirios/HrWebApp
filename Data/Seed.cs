using HrWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace HrWebApp.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                //Staff
                if (!context.Staffs.Any())
                {
                    context.Staffs.AddRange(new List<Staff>()
                    {
                        new Staff()
                        {
                            FirstName = "Taras",
                            LastName = "Shevchenko",
                            Email = "miroslawwlasenko@gmail.com",
                            Image = "address...",
                            AddressId = 1,
                            Address = new Address()
                            {
                                Street = "Kondratyk st.",
                                City = "Poltava",
                                State = "Poltava",
                                ZipCode = 3700
                            },
                            DateStaff = new DateOnly(2001, 01, 29),
                            PhoneNumber = "+38 066 008 4480",
                            PassportCode = "CT567567",
                            TaxpayerCode = "11112321234",
                            Department = "IT",
                            RoleInDepartment = "Web Developer",
                            Hired = DateOnly.FromDateTime(DateTime.Now),
                            AllDay = 20
                        }
                    });
                    context.SaveChanges();
                }
                //Vacation
                if (!context.Vacations.Any())
                {
                    context.Vacations.AddRange(new List<Vacation>()
                    {
                        new Vacation()
                        {
                            StaffId = 1,
                            StartDate = DateOnly.FromDateTime(DateTime.Now),
                            EndDate = DateOnly.FromDateTime(DateTime.Now),
                            success = true
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {



                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "miroslawwlasenko@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "miroslawwlasenko",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        StaffId = 1
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }
            }
        }
    }
}
