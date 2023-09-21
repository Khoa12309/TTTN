using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTTTN.Models
{
    public class OrderHistory
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Order")]
        public Guid Id_order { get; set; }
        public string ActionDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime Last_modified_date { get; set; }
        public virtual Order? Order { get; set; }
    }
}
