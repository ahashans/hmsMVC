using System;
using System.Collections.Generic;
using HMS.Models;

namespace HMS.ViewModel
{
    public class AppointmentViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public int DoctorDepartmentId { get; set; }
        public IEnumerable<DoctorDepartment> DoctorDepartments { get; set; }
        public string AppointmentDate { get; set; }   
        public string Problem { get; set; }
        public string Remarks { get; set; }

    }
}