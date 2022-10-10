using System.ComponentModel.DataAnnotations;
using USFH.Models.Base;

namespace USFH.Models
{
    public class AboutUs:BaseModel
    {
        [Required]
        [Display(Name ="Title")]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Image")]
        public string? ImagePath { get; set; }
    }
}
