﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpiceApp.Models
{
    public class MenuItem
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Spicyness { get; set; }

        public enum Espicy { NA=0,NotSpicy=1,Spicy=2,VerySpicy=3}

        public string Image { get; set; }

        [Display(Name="Category")]
        public int CategoryId { get; set; }
        [Display(Name = "SubCategory")]
        public int SubCategoryId { get; set; }

        [Range(1,int.MaxValue,ErrorMessage ="Price should be greater")]
        public double price { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { get; set; }
    }
}
