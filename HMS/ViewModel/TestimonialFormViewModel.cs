using System.ComponentModel.DataAnnotations;
using System.Web;
using HMS.Models;

namespace HMS.ViewModel
{
    public class TestimonialCreateFormViewModel
    {
        public Testimonial Testimonial { get; set; }
        [Required(ErrorMessage = "Please select a profile picture")]
        public HttpPostedFileBase ProfilePicture { get; set; }
    }
    public class TestimonialEditFormViewModel
    {
        public Testimonial Testimonial { get; set; }
        public HttpPostedFileBase ProfilePicture { get; set; }
    }
}