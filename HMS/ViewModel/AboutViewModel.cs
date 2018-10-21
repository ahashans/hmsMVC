using System.Collections.Generic;
using HMS.Models;

namespace HMS.ViewModel
{
    public class AboutViewModel
    {
        public IEnumerable<DoctorDepartment> DoctorDepartments { get; set; }
        public IEnumerable<Department> Departments { get; set; }    
    }
}