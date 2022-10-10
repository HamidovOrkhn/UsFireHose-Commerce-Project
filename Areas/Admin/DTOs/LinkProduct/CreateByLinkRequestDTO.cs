using System.ComponentModel.DataAnnotations;

namespace USFH.Areas.Admin.DTOs.LinkProduct
{
    public class CreateByLinkRequestDTO
    {
        [Required]
        public string? Link { get; set; }
        [Required]
        public int? CategoryId { get; set; }
    }
}
