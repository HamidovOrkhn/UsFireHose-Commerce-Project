using USFH.Models.Base;

namespace USFH.Models
{
    public class Order:BaseModel
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Desc { get; set; }
        public List<OrderProduct>? OrderProducts { get; set; }
    }
}
