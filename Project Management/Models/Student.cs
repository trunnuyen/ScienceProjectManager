using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string MSSV { set; get; }
        public string name { set; get; }
        public string gender { set; get; }
        public DateTime birthday { set; get; }
        public string address { set; get; }
        public string numberPhone { set; get; }
        public string faculty { set; get; }
        
        public string major { set; get; }
        
        public string Class { set; get; }
        public string course { set; get; }
        public string password { set; get; }
        public string access { set; get; }
        public virtual ICollection<Project> project { set; get; }

    }
}
