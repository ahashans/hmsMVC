using System.Collections.Generic;
using HMS.Models;

namespace HMS.ViewModel
{
    public class AdminIndexViewModel
    {
        public IEnumerable<UserListViewModel> UserList { get; set; }
        public int StaffCount { get; set; }
        public int DiagnosisCount { get; set; }
        public int DoctorCount { get; set; }
        public int PatientCount { get; set; }
    }
}
