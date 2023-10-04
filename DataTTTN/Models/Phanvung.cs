using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTTTN.Models
{
    public class Phanvung
    {
        [Key]
        public Guid Id { get; set; }
        public string Note { get; set; }
        [ForeignKey("User")]
        public Guid Id_User { get; set; } 
        [ForeignKey("Role")]
        public Guid Id_Role { get; set; }
        public virtual User? User { get; set; }
        public virtual Role? Role { get; set; }
    }
}
