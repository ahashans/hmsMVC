using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Models
{
    public class EducationalQualifications
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EducationalQualificationId { get; set; }
        [Required(ErrorMessage = "Please enter the name of the degree!")]
        [Display(Name = "Degree Name")]
        public string DegreeName { get; set; }
        [Required(ErrorMessage = "Please enter the institute name!")]
        [Display(Name = "Degree Institute")]
        public string InstituteName { get; set; }
        [Display(Name = "Degree Result")]
        [Required(ErrorMessage = "Please enter the result!")]
        public string Result { get; set; }
        [Display(Name = "Degree Obtatined Date")]
        [Required(ErrorMessage = "Please enter the passing year!")]
        [DataType(DataType.Date)]
        public DateTime PassingYear { get; set; }
        [Display(Name = "User")]
        [Required(ErrorMessage = "User Id is Required")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ScaffoldColumn(false)]
        public ApplicationUser User { get; set; }

    }
}