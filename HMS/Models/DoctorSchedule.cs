using System;
using System.ComponentModel.DataAnnotations;

namespace HMS.Models
{
    public class DoctorSchedule
    {
        public int DoctorScheduleId { get; set; }
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "Please enter the week day!")]
        [Display(Name = "Weekday")]
        public string DayOfWeek { get; set; }
        [Required(ErrorMessage = "Please enter the shift starting time!")]
        [DataType(DataType.Time)]
        [Display(Name = "Starting Time")]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Please enter the shift ending time!")]
        [Display(Name = "Ending Time")]
        public DateTime EndTime { get; set; }
//        public DateTime Break { get; set; }
        

    }
}