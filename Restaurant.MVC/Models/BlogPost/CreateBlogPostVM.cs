using System.ComponentModel.DataAnnotations;

namespace Restaurant.MVC.Models.BlogPost
{
    public class CreateBlogPostVM
    {
        [Required]
        [Display(Name ="Enter the blog title")]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [Display(Name = "Enter the author name")]
        public string Author { get; set; }
    }
}
