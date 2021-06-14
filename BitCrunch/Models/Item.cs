using System.ComponentModel.DataAnnotations;

namespace BitCrunch.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        [Required]
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        [Required]
        public string StoreName { get; set; }
        public string Console { get; set; }
        public double Price { get; set; }
    }
}