using System.ComponentModel.DataAnnotations;
using USFH.Models.Base;

namespace USFH.Models
{
    public class Blog:BaseModel
    {
        [Required]
        [Display(Name = "Title")]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "Sub Title")]
        public string ? SubTitle { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Required]
        [Display(Name = "Image")]
        public string? ImagePath { get; set; }
        [Display(Name = "Slug")]
        public string? Slug { get; set; }
        [Display(Name = "Status")]
        public bool Status { get; set; }
    }
}
