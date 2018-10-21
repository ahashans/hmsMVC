using System.Web;
using HMS.Models;

namespace HMS.ViewModel
{
    public class EventEditViewModel
    {
        public ProbableEvent ProbableEvent { get; set; }
        public HttpPostedFileBase FeatureImage { get; set; }

    }
}