using System.Collections.Generic;
using HMS.Models;

namespace HMS.ViewModel
{
    public class HomeIndexViewModel
    {
        public IEnumerable<DoctorDepartment> Doctors { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public  IEnumerable<Testimonial> Testimonials { get; set; }
        public IEnumerable<Blog> BlogPosts { get; set; }
        public IEnumerable<ProbableEvent> ProbableEvents { get; set; }

    }
}