using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace HMS.Models
{
    public class Blog
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the title of the blog post")]
        public string Title { get; set; }
        //        [Required(ErrorMessage = "AuthorId is required")]
        [ScaffoldColumn(false)]
        public string AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public ApplicationUser Author { get; set; }
        [Required(ErrorMessage = "Please enter the content of the blog post")]
        [AllowHtml]
        public string Content { get; set; }
        [ScaffoldColumn(false)]
        [HiddenInput]
        [Required(ErrorMessage = "Please enter a feature image for the post", AllowEmptyStrings = true)]

        public string FeatureImagePath  { get; set; }
        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; set; }

    }
}