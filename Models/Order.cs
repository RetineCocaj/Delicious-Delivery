using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodProject.Models
{
    public class Order
    {
        public string OrderId { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Value must be a Currency ex. $20")]
        [Display(Name = "Sum")]
        public double TotalAmount { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Order Destination")]
        public string Destination { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = "Pending";

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<CartItem> Items { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}