using System.ComponentModel.DataAnnotations;
using USFH.Models.Base;

namespace USFH.Models
{
    public class Banner:BaseModel
    {
        [Display(Name = "Main Title")]
        public string? MainTitle { get; set; }
        [Display(Name = "Top Title")]
        public string? TopTitle { get; set; }
        [Display(Name = "Sub Title")]
        public string? SubTitle { get; set; }
        [Display(Name = "Image")]
        public string? ImagePath { get; set; }
        [Display(Name = "Order")]
        public int Order { get; set; }
        [Display(Name = "Status")]
        public bool Status { get; set; }
    }
}
