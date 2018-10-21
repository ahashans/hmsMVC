using System.ComponentModel.DataAnnotations;

namespace HMS.Models
{
    public class Testimonial
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the testimonial user name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the testimonial user designation")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Please enter the testimonial user message")]
        public string Message { get; set; }
        public string ProfileImagePath { get; set; }
    }
}