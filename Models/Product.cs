using System.ComponentModel.DataAnnotations;
using USFH.Models.Base;

namespace USFH.Models
{
    public class Product:BaseModel
    {
        [Required]
        [Display(Name = "Title")]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; } = 0;
        [Display(Name = "Discount")]
        public bool Discount { get; set; }
        [Display(Name = "Discount Rate")]
        public double DiscountRate { get; set; } = 0;
        [Display(Name = "Stock Status")]
        public bool StockStatus { get; set; }
        [Display(Name = "Stock Level")]
        public string? StockLevel { get; set; }
        [Required]
        [Display(Name = "Item Number")]
        public string? ItemNumber { get; set; }
        [Required]
        [Display(Name = "Weight")]
        public decimal? Weight { get;set; }
        [Display(Name = "Product Features")]
        public string? ProductFeatures { get; set; }
        [Required]
        [Display(Name = "Image")]
        public string? ImageLink { get; set; }
        [Required]
        [Display(Name = "Slug")]
        public string? Slug { get; set; }
        [Required]
        [Display(Name = "Status")]
        public bool Status { get; set; }
        [Display(Name = "Product Images")]
        public List<ProductImage>? ProductImages { get; set; }
        [Display(Name = "Product Category")]
        public ProductCategory? ProductCategory { get; set; }
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        [Display(Name = "Selling Count")]
        public int? SellingCount { get; set; } = 0;
        public List<OrderProduct>? OrderProducts { get; set; }
    }
}
