using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
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
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }    
}