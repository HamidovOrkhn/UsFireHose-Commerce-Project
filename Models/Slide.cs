using System.ComponentModel.DataAnnotations;
using USFH.Models.Base;

namespace USFH.Models
{
    public class Slide:BaseModel
    {
        [Required]
        [Display(Name = "Main Title")]
        public string? MainTitle { get; set; }
        [Required]
        [Display(Name = "Top Title")]
        public string? TopTitle { get; set; }
        [Required]
        [Display(Name = "Sub Title")]
        public string? SubTitle { get; set; }
        [Display(Name = "Slug")]
        public string? Slug { get; set; }
        [Required]
        [Display(Name = "Image")]
        public string? Image { get; set; }
        [Display(Name = "Button Title")]
        public string? ButtonTitle { get; set; }
        [Display(Name = "Order")]
        public int Order { get; set; }
        [Display(Name = "Status")]
        public bool Status { get; set; }
    }
}
