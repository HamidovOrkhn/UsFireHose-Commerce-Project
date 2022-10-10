using System.ComponentModel.DataAnnotations;
using USFH.Models.Base;

namespace USFH.Models
{
    public class ContactUs:BaseModel
    {
        [Required]
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string? Address { get; set; }
        [Required]
        [Display(Name = "Main Email")]
        public string? MainEmail { get; set; }
        [Display(Name = "Second Email")]
        public string? SecondEmail { get;set; }
        [Required]
        [Display(Name = "Main Phone")]
        public string? MainPhone { get; set;}
        [Display(Name = "Second Phone")]
        public string? SecondPhone { get; set;}
        [Display(Name = "Map X")]
        public string? MapX { get; set; }
        [Display(Name = "Map Y")]
        public string? MapY { get; set; }
    }
}
