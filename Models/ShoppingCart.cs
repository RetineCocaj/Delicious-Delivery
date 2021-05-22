using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodProject.Models
{
    public class ShoppingCart
    {
        [Required]
        public string ShoppingCartId { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Value must be a Currency ex. $20")]
        public double Sum { get; set; }
        public string UserId { get; set; }
        public ICollection<CartItem> Items { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}