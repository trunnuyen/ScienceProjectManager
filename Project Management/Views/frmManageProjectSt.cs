using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_Management.Controllers;
using Project_Management.Models;
using System.Data.Entity;
using System.Threading;

namespace Project_Management.Views
{
    public partial class frmManageProjectSt : Form
    {
        private int STT;
        public Student student;
        public frmManageProjectSt(Student st)
        {
            InitializeComponent();
            STT = this.lstProject.Items.Count + 1;
            student = st;
        }

        public void DisplayListProject(Student st)
        {

            this.lstProject.Items.Clear();
            STT = 1;
            List<Project> listProject = ProjectController.getAllProject();


            var cc = new List<Instructor>();
            var zz = new List<Student>();
            using (var db = new DBentityProject())
            {
                cc = db.tbInstructor.Include(c => c.project).ToList();
                zz = db.tbStudent.Include(c => c.project).ToList();
            }
            
                foreach (Student std in zz)
                {
                    if (std.MSSV == st.MSSV)
                    {
                        foreach (Project item in std.project)
                        {
                            ListViewItem proj = new ListViewItem(STT.ToString());
                            proj.SubItems.Add(new ListViewItem.ListViewSubItem(proj, item.idProject.ToString()));
                            proj.SubItems.Add(new ListViewItem.ListViewSubItem(proj, item.name.ToString()));
                            string sStudent = "";
                            sStudent += std.name.ToString() + " - ";
                            
                            proj.SubItems.Add(new ListViewItem.ListViewSubItem(proj, sStudent));


                            string sInstructor = "";
                            foreach (Instructor ins in cc)
                            {
                                foreach (Project pj in ins.project)
                                {
                                    {
                                        if (item.idProject == pj.idProject)
                                            sInstructor += ins.name.ToString() + " ";
                                    }
                                }
                            }
                            proj.SubItems.Add(new ListViewItem.ListViewSubItem(proj, sInstructor));

                            proj.SubItems.Add(new ListViewItem.ListViewSubItem(proj, item.subject.ToString()));
                            proj.SubItems.Add(new ListViewItem.ListViewSubItem(proj, item.course.ToString()));
                            proj.SubItems.Add(new ListViewItem.ListViewSubItem(proj, item.type.ToString()));
                            proj.SubItems.Add(new ListViewItem.ListViewSubItem(proj, item.rank.ToString()));
                            proj.SubItems.Add(new ListViewItem.ListViewSubItem(proj, item.host.ToString()));
                            this.lstProject.Items.Add(proj);
                            STT++;
                        }
                    }



                }
            

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmManageProjectSt_Load(object sender, EventArgs e)
        {
            DisplayListProject(student);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            DisplayListProject(student);
        }
        public void ChangeLanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            InitializeComponent();
        }

        private void btnProjectDetail_Click(object sender, EventArgs e)
        {
            if (this.lstProject.SelectedItems.Count == 0)
                return;
            Project proj = ProjectController.GetProject(this.lstProject.SelectedItems[0].SubItems[1].Text);
            frmProjectDetail frmDetail = new frmProjectDetail(proj);
            frmDetail.ShowDialog();
        }
    }
}
