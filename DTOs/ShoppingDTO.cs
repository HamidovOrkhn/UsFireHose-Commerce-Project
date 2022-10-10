using USFH.Models;

namespace USFH.DTOs
{
    public class ShoppingDTO
    {
        public List<Product>? Products { get; set; }
        public double TotalPrice { get; set; }
        public int? Count { get; set; } = 0;
    }
}
