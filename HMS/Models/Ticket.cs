using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Models
{
    public class Ticket
    {
        public Ticket()
        {
            PaymentTimeStamp = DateTime.Now;
        }
        [Required(ErrorMessage = "Ticket Id is required")]
        [Display(Name = "Ticket Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }
        [Required(ErrorMessage = "Bill Amount is required")]
        [Display(Name = "Bill Amount")]
        public int? BillAmount { get; set; }
        [Required(ErrorMessage = "Payment Method is Required")]
        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; }
        [Required]
        public DateTime PaymentTimeStamp { get; set; }
        [DefaultValueAttribute("Open")]
        [Display(Name = "Ticket Status")]

        public string TicketStatus { get; set; }

        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "Department is Required")]
        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        [Display(Name="Patient")]
        [Required(ErrorMessage = "Patient Is Required!")]
        public string PatientUserId { get; set; }
        [ForeignKey("PatientUserId")]
        public ApplicationUser PatientUser { get; set; }

        [Display(Name = "Receptionist")]
        public string ReceptionistUserId { get; set; }
        [ForeignKey("ReceptionistUserId")]
        public ApplicationUser ReceptionistUser { get; set; }


    }
}