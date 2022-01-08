using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Models
{
    [Table("Project")]
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idProject { get; set; }
        public string name { get; set; }
        public  virtual ICollection<Student> listStudent { set; get; }
        public virtual ICollection<Instructor> listInstructor { set; get; }
        public string subject { set; get; }
        public string course { set; get; }
        public string source { set; get; }
        public DateTime? dateStart { set; get; }
        public DateTime? dateEnd { set; get; }
        // Lần báo cáo bằng index +1
        public virtual ICollection<Report> report { set; get; }
        public float expense { set; get; }
        public string type { set; get; }
        public string rank { set; get; }
        public string host { set; get; }

    }
}
