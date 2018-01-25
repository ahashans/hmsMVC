using System;
using System.ComponentModel.DataAnnotations;

namespace HMS.ViewModel
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Full Name is Required!")]
        [Display(Name = "Full Name")]
        [StringLength(50)]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Gender is Required!")]
        [StringLength(6)]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Date Of Birth is Required!")]
        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Address is Required!")]
        [StringLength(450)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Mobile Number is Required!")]
        [Display(Name = "Mobile Number")]
        [StringLength(11)]
        public string Mobile { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Role is Required!")]
        public string Role { get; set; }
    }
}