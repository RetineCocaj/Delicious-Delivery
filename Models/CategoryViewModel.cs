using System.Collections.Generic;

namespace FoodProject.Models
{
    public class CategoryViewModel
    {
        public ICollection<Category> Categories { get; set; }
        public ICollection<FoodItem> FoodItems { get; set; }
    }
}