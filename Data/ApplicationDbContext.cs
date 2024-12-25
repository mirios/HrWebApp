using HrWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HrWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
    }
}
