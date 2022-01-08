using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_Management.Models;
using Project_Management.Controllers;

namespace Project_Management.Views
{
    public partial class frmProjectDetail : Form
    {
        Project project;
        public frmProjectDetail(Project Proj)
        {
            InitializeComponent();
            project = Proj;
        }

        private void frmProjectDetail_Load(object sender, EventArgs e)
        {
            txtName.Text = this.project.name;
            txtSubject.Text = this.project.subject.ToString();
            txtDateStart.Text = this.project.dateStart.ToString();
            if(project.source!=null)
            {
                txtDateEnd.Text = this.project.dateEnd.ToString();
            }

            List<Progress> listProgress = ProgressController.getAllProgress();
            Progress pro = new Progress();

            foreach(Progress item in listProgress)
            {
                if(item.idProject == project.idProject)
                {
                    pro = item;
                    break;
                }
            }
            if (pro.finished == true)
                txtDateSubmit.Text = pro.submitTime.ToString();
            else
                txtDateSubmit.Text = "";
            //list student
            string sStudent = "";
            foreach (Student st in project.listStudent)
            {
                sStudent += st.name.ToString() + "\n";
            }
            rbStudent.Text = sStudent;

            // Hiển thị list Instructor của Project
            // Dùng database chuyển qua 1 string để hiển thị trong 1 ô
            string sInstructor = "";
            foreach (Instructor gv in project.listInstructor)
            {
                sInstructor += gv.name.ToString() + "\n";
            }
            rbInstructor.Text = sInstructor;

            txtIdProject.Text = this.project.idProject;
            if (this.project.mark != 0)
                txtMark.Text = this.project.mark.ToString();
            else
                txtMark.Text = "";
            txtSubmitLink.Text = this.project.source;
            //txtDateSubmit.Text = this.project.report.ToString();
        }

        private void txtDateSubmit_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
