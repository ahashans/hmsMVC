using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Models
{
    public class DoctorDepartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        [Display(Name = "Doctor")]
        [Required(ErrorMessage = "Doctor User Id is Required")]
        public string DoctorUserId { get; set; }
        [ForeignKey("DoctorUserId")]
        public ApplicationUser DoctorUser { get; set; }

        [Display(Name = "Short Introduction")]
        public string ShortIntro { get; set; }
        [Display(Name = "Long Introduction")]
        public string LongIntro { get; set; }

    }
}