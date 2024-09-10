using System.ComponentModel.DataAnnotations;

namespace Restaurant.MVC.Models.MenuItem
{
    public class CreateMenuItemVM
    {
        [Required]
        [Display(Name = "Item Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Descripe the item")]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }
        [Required]
        [Display(Name = "Choose Category for the item")]
        public int CategoryId { get; set; }
    }
}
