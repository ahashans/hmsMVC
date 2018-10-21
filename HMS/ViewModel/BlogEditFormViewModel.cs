using System.Web;
using HMS.Models;

namespace HMS.ViewModel
{
    public class BlogEditFormViewModel
    {
        public Blog BlogPost { get; set; }
        public HttpPostedFileBase FeatureImage { get; set; }
    }
}