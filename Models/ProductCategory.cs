using System.ComponentModel.DataAnnotations;
using USFH.Models.Base;

namespace USFH.Models
{
    public class ProductCategory:BaseModel
    {
        [Required]
        [Display(Name = "Title")]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Image")]
        public string? ImagePath { get; set; }
        [Display(Name = "Parent Category")]
        public int ParentId { get; set; } = 0;
        [Display(Name = "Slug")]
        public string? Slug { get; set; }
        [Display(Name = "Products")]
        public List<Product>? Products { get; set; }
        [Display(Name = "Status")]
        public bool Status { get; set; }
    }
}
