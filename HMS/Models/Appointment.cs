using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Models
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentId { get; set; }
        
        [Display(Name = "Doctor")]
        [Required(ErrorMessage = "Please Select a doctor!")]
        public int DoctorDepartmentId { get; set; }
        [ForeignKey("DoctorDepartmentId")]
        public DoctorDepartment DoctorDepartment { get; set; }
        [ScaffoldColumn(false)]
        public string PatientId { get; set; }
        [ForeignKey("PatientId ")]
        public ApplicationUser Patient { get; set; }
        public DateTime AppointmentDate { get; set; }

//        public int DepartmentId { get; set; }
//
//        [ForeignKey("DepartmentID")]
//        public Department Department { get; set; }
        [Required(ErrorMessage = "Please state your problem!")]
        public string Problem { get; set; }

//        [Required(ErrorMessage = "Please state your ")]
        public string Remarks { get; set; }
//        public DateTime AppointmentTime { get; set; }
    }
}