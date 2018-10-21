using System.ComponentModel.DataAnnotations;
using System.Web;
using HMS.Models;

namespace HMS.ViewModel
{
    public class BlogFormViewModel
    {
        public Blog BlogPost { get; set; }
        [Required(ErrorMessage = "Please select a feature image")]
        public HttpPostedFileBase FeatureImage { get; set; }    
    }
    
}