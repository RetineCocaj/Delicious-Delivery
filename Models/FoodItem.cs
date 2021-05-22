using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodProject.Models
{
    public class FoodItem
    {
        [Key]
        public string FoodItemId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "You did not enter a valid currency value ex. $15.6")]
        public double Price { get; set; }
        public bool? isEnabled { get; set; } = true;
        public int? CategoryId { get; set; }

        public Category Category { get; set; }
        
        [Required]
        [StringLength(128)]
        public string Discriminator { get; set; } = "FoodItem";

        public string CartItemId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}