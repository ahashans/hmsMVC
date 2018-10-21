using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HMS.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        [Required(ErrorMessage = "Please enter a service name!")]
        [HiddenInput(DisplayValue = false)]
        [Remote("CheckEmail", "Account", HttpMethod = "POST", ErrorMessage = "A service with this name already exists! Try another name.")]
        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }
        [Required(ErrorMessage = "Please enter the duration of the service!")]
        public int Duration { get; set; }
        [Required(ErrorMessage = "Please enter the price of the service!")]

        public int Price { get; set; }
    }
}