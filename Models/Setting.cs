using System.ComponentModel.DataAnnotations;
using USFH.Models.Base;

namespace USFH.Models
{
    public class Setting:BaseModel
    {
        [Display(Name = "Key")]
        public string? Key { get; set; }
        [Display(Name = "Value")]
        public string? Value { get; set; }
    }
}
