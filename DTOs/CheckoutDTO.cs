using System.ComponentModel.DataAnnotations;

namespace USFH.DTOs
{
    public class CheckoutDTO
    {
        [Required]
        [MaxLength(500)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string? Surname { get; set; }
        [Required]
        [MaxLength(500)]
        public string? Address { get; set; }
        [Required]
        [MaxLength(500)]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MaxLength(500)]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Order Notes field is required.")]
        [MaxLength(1000)]
        public string? Desc { get; set; }
    }
}
