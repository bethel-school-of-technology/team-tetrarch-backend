using System.ComponentModel.DataAnnotations;

namespace BitCrunch.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string StoreName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }

    }
}