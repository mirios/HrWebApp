namespace HrWebApp.ViewModels
{
    public class RegisterViewModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Streets { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? ZipCode { get; set; }
        public string? PhoneNumber { get; set; }
        public int? Year { get; set; }
        public int? Mount { get; set; }
        public int? Day { get; set; }
        public string? PassportCode { get; set; }
        public string? TaxpayerCode { get; set; }
        public string? Department { get; set; }
        public string? RoleInDepartment { get; set; }
    }
}
