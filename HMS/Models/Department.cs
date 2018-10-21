using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace HMS.Models
{
    public class Department
    {
        [Required(ErrorMessage = "Department Id is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Department Name is required")]
        [StringLength(30, ErrorMessage = "Deartment Name length is 30 character")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Department Short Description is required!")]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
//        [Required(ErrorMessage = "Department Icon is required!")]
        [Display(Name = "IconCode")]
        public string IconCode { get; set; }
        [Required(ErrorMessage = "Department Fee is required")]
        public int? Fee { get; set; }

    }
}