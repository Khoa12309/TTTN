using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTTTN.Models
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Create_at { get; set; }
        [ForeignKey("Account")]
        public Guid Id_account { get; set; }
        public virtual Account? Account { get; set; }
    }
}
