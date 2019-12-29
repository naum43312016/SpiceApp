using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpiceApp.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public ShoppingCart()
        {
            Count = 1;
        }

        public string ApplicationUserId { get; set; }

        [NotMapped]
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int MenuItemId { get; set; }

        [NotMapped]
        [ForeignKey("MenuItemId")]
        public virtual MenuItem MenuItem { get; set; }


        [Range(1,int.MaxValue,ErrorMessage ="Please enter value greater than {0}")]
        public int Count { get; set; }
    }
}
