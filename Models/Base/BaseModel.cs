using System.ComponentModel.DataAnnotations;

namespace USFH.Models.Base
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
