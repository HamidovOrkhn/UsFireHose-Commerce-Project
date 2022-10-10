using System.ComponentModel.DataAnnotations;
using USFH.Models.Base;

namespace USFH.Models
{
    public class Message:BaseModel
    {
        [Required]
        [Display(Name = "Name")]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [Required]
        [Display(Name = "Subject")]
        public string? Subject { get; set; }
        [Required]
        [Display(Name = "Message Text")]
        public string? MessageText { get; set; }
    }
}
