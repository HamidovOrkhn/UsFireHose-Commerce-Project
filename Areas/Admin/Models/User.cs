using System.ComponentModel.DataAnnotations;

namespace USFH.Areas.Admin.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Email { get; set; }
        public bool Status { get; set; }
        [Required]
        public string? Password { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
