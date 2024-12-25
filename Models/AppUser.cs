using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrWebApp.Models
{
    public class AppUser : IdentityUser
    {
        [ForeignKey("Staff")]
        public int StaffId { get; set; }
        public Staff? Staff { get; set; }
    }
}
