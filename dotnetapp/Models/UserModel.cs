using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [MaxLength(10)]
        public string MobileNumber { get; set; }
        [Required]
        public string UserRole { get; set; }
    }
}
