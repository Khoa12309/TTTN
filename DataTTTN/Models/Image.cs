﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTTTN.Models
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Product_details")]
        public Guid Id_Product_details { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime Last_modified_date { get; set; }
        public virtual Product_details? Product_Details { get; set; }
    }
}
