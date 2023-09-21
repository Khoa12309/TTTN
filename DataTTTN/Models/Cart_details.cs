using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTTTN.Models
{
    public class Cart_details
    {
        [Key]
        public Guid ID { get; set; }
        [ForeignKey("Product_details")]
        public Guid Id_productdetails { get; set; }
        [ForeignKey("Cart")]
        public Guid Id_Cart { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime Last_modified_date { get; set; }

        public virtual Cart? Cart { get; set; }
        public virtual Product_details? Product_Details { get; set; }

    }
}
