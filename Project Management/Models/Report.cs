using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Models
{
    [Table("Report")]
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string id { set; get; }
        public string comment { set; get; }


    }
}
