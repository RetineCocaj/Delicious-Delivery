using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }
        public ICollection<FoodItem> FoodItems { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}