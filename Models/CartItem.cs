using System;
using System.ComponentModel.DataAnnotations;

namespace FoodProject.Models
{
    public class CartItem
    {
        public string CartItemId { get; set; } = Guid.NewGuid().ToString();
        [Range(1, 20)]
        public int? Quantity { get; set; }
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "You did not enter a valid currency value ex. $15.6")]
        public double Price { get; set; }
        public bool? isEnabled { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Value must be a Currency ex. $20")]
        public double TotalAmount { get; set; }
        
        [Required]
        [StringLength(128)]
        public string Discriminator { get; set; }

        public string OrderId { get; set; }
        public int? CategoryId { get; set; }

        public Category Category { get; set; }

        public string ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}