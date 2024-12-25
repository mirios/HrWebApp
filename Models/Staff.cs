using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HrWebApp.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Image { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public DateOnly DateStaff { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportCode { get; set; }
        public string TaxpayerCode { get; set; }
        public string Department { get; set; }
        public string RoleInDepartment { get; set; }
        public DateOnly? Hired { get; set; }
        public int? AllDay { get; set; }
    }
}
