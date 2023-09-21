using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTTTN.Models
{
    public class Account_voucher
    {
        [Key]
        public Guid Id { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime Last_modified_date { get; set; }
        [ForeignKey("Account")]
        public Guid Id_Account { get; set; }
        [ForeignKey("Voucher")]
        public Guid Id_Voucher { get; set; }
        public virtual Voucher? Voucher { get; set; }
        public virtual Account? Account { get; set; }
    }
}
