using System.Collections.Generic;
using HMS.Models;

namespace HMS.ViewModel
{
    public class DoctorListViewModel
    {
        public IEnumerable<DoctorDepartment> Doctors { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public int DepartmentId { get; set; }

    }
}