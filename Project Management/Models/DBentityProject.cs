using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Models
{
    public partial class DBentityProject : DbContext
    {   
        public DBentityProject() : base("name=DBentitiesProject")
        {

        }
        public  DbSet<Instructor> tbInstructor{ set; get; }
        public  DbSet<Project> tbProject { set; get; }

        public  DbSet<Student> tbStudent { set; get; }

        public  DbSet<Faculty> tbFaculty { set; get; }
        public DbSet<Subject> tbSubject { set; get; }
        public DbSet<Progress> tbProgress { set; get; }
        public DbSet<Report> tbReport { set; get; }

    }
}
