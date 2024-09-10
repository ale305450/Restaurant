using System.ComponentModel.DataAnnotations;

namespace Restaurant.MVC.Models.Category
{
    public class CreateCategoryVM
    {
        [Required]
        [Display(Name ="Enter the category name ")]
        public string Name { get; set; }
    }
}
