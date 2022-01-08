using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Models
{
    [Table("Progress")]
    public class Progress
    {
        [Key]
        public string idProject { set; get; }
        public ICollection<Student> listStudent { set; get; }
        public string Name { set; get; }
        public DateTime dateStart { set; get; }
        public DateTime finishTime { set; get; }
        public DateTime submitTime { set; get; }
        public float expense { set; get; }
        public bool finished { set; get; }
    }
}
