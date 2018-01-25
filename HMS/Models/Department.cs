using System;
using System.ComponentModel.DataAnnotations;

namespace HMS.Models
{
    public class Department
    {
        [Required(ErrorMessage = "Department Id is required")]
        public Guid DepartmentId { get; set; }
        [Required(ErrorMessage = "Department Name is required")]
        [StringLength(30, ErrorMessage = "Deartment Name length is 30 character")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Department Fee is required")]
        public int? Fee { get; set; }

    }
}