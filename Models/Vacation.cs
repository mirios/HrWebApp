using System.ComponentModel.DataAnnotations;

namespace HrWebApp.Models
{
    public class Vacation
    {
        [Key]
        public int Id { get; set; }
        public int StaffId { get; set; }
        public DateOnly StartDate{ get; set; }
        public DateOnly EndDate { get; set; }
        public bool? success { get; set; }
    }
}
