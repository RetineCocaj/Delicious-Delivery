using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace FoodProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public ICollection<Order> Orders { get; set; }


        [NotMapped]
        [Display(Name = "Name")]
        public string FullName { 
            get
            {
                return this.FirstName +" "+ this.LastName;
            } 
        }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}