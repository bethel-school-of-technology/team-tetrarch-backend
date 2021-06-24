using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

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
        public string Email { get; set; }
        public string StoreName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Range(0,1)]
        public int IsAdmin { get; set; }

    }
}