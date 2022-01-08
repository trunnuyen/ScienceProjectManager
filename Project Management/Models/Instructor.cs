using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Models
{
    [Table("Teacher")]
    public class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string id { get; set; }
        public string password { get; set; }
        public string name { set; get; }
        public string gender { set; get; }
        public string phone { set; get; }
        public string address { set; get; }
        public DateTime birthday { set; get; }
        public string subject { set; get; }   
        public string access { get; set; }
        public virtual  ICollection<Project> project { set; get; }

    }
}
