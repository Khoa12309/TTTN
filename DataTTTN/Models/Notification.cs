using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTTTN.Models
{
    public  class Notification
    {
        [Key]
        public Guid Id { get; set; }
        public string Noti_conten { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime Last_modified_date { get; set; }
        [ForeignKey("Account")]
        public Guid Id_account { get; set; }
        public virtual Account? Account { get; set; }
    }
}
