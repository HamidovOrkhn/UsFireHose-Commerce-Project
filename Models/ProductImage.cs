using USFH.Models.Base;

namespace USFH.Models
{
    public class ProductImage:BaseModel
    {
        public string? ImageLink { get; set; }
        public string? Title { get; set; }
        public Product? Product { get; set; }
        public int ProductId { get; set; }
    }
}
