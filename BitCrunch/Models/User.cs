using System.ComponentModel.DataAnnotations;

namespace BitCrunch.Models
{
    public class User
    {
        int UserID { get; set; }
        [Required]
        string UserName { get; set; }
        [Required]
        string Password { get; set; }
        [Required]
        string Email { get; set; }
        [Required]
        string StoreName { get; set; }
        [Required]
        string City { get; set; }
        [Required]
        string State { get; set; }

    }
}