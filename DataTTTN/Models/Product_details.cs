﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTTTN.Models
{
    public class Product_details
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Size")]
        public Guid Id_Size { get; set; }
        [ForeignKey("Category")]
        public Guid Id_Category { get; set; }  
        [ForeignKey("Color")]
        public Guid Id_Color { get; set; } 
        [ForeignKey("Brand")]
        public Guid Id_Brand { get; set; } 
        [ForeignKey("Material")]
        public Guid Id_Material { get; set; } 
        [ForeignKey("Sole")]
        public Guid Id_Sole { get; set; } 
        [ForeignKey("Product")]
        public Guid Id_Product { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Gender { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime Last_modified_date { get; set; }
        public virtual Size? Size { get; set; }
        public virtual Color? Color { get; set; }
        public virtual Brand? Brand { get; set; }
        public virtual Category?  Category { get; set; }
        public virtual Material? Material { get; set; }
        public virtual Sole? Sole { get; set; }
        public virtual Product? Product { get; set; }

    }
}
