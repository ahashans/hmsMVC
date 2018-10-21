using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using Microsoft.AspNet.Identity;

namespace HMS.Models
{
    public class Diagnosis
    {
        public Diagnosis()
        {
            DiagnosisTimeStamp=DateTime.Now;
            //DoctorUserId = HttpContext.Current.User.Identity.GetUserId();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiagnosisId { get; set; }
        [Display(Name = "Ticket")]
        public int TicketId { get; set; }
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }

        [Display(Name = "Doctor")]
//        [Required(ErrorMessage = "Doctor Is Required!")]
        public string DoctorUserId { get; set; }
        [ForeignKey("DoctorUserId")]
        public ApplicationUser DoctorUser { get; set; }

        [Required(ErrorMessage = "Diagnosis Is Required!")]
        [Display(Name = "Diagnosis")]
        [StringLength(1000)]
        public string DiagnosisProvided { get; set; }

        [Required(ErrorMessage = "Treatment Is Required!")]
        [Display(Name = "Treatment")]
        [StringLength(1000)]
        public string TreatmentProvided { get; set; }

        [Required(ErrorMessage = "Enter 'None' If no test is required")]
        [Display(Name = "Required Tests")]
        [StringLength(1000)]
        public string RequiredTests { get; set; }

        [Display(Name = "Diagnosis Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:YYYY MMM DD}")]
        public DateTime DiagnosisTimeStamp { get; set; }
    }
}