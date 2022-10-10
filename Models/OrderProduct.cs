using USFH.Models.Base;

namespace USFH.Models
{
    public class OrderProduct:BaseModel
    {
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int ProductCount { get; set; }
    }
}
