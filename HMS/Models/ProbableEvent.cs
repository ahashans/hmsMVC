using System;
using System.ComponentModel.DataAnnotations;

namespace HMS.Models
{
    public class ProbableEvent
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the title of the event")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a short description of the title")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Please enter the event date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:YYYY MMM DD}")]
        public DateTime EventDate { get; set; }

        public string FeatureImagePath { get; set; }

    }
}