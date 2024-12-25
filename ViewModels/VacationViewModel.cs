using System.Windows.Input;

namespace HrWebApp.ViewModels
{
    public class VacationViewModel
    {
        public int UserId { get; set; }
        public int StartDay { get; set; }
        public int StartMonth { get; set; }
        public int StartYear { get; set; }
        public int LastDay { get; set; }
        public int LastMonth { get; set; }
        public int LastYear { get; set; }
        public int Verdict { get; set; }
    }
}
