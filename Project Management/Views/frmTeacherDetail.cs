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
using System.Data.Entity;
using System.Threading;

namespace Project_Management.Views
{
    public partial class frmInstructorDetail : Form
    {
        Dictionary<string, float> dicProject;
        List<string> idProject;
        Dictionary<string, string> dicReport;
        public frmInstructorDetail(Instructor ins)
        {
            
            InitializeComponent();
            dicReport = new Dictionary<string, string>();
            dicProject = new Dictionary<string, float>();
            idProject = new List<string>();

            txtBirthday.Text = ins.birthday.ToShortDateString().ToString();
            txtGender.Text = ins.gender;
            txtAddress.Text = ins.address;
            txtIdInstructor.Text = ins.id;
            txtPhone.Text = ins.phone;
            txtName.Text = ins.name;

            rbSubject.Text = ins.subject.Replace('-','\n');
            var cc = new List<Instructor>();
            using (var db = new DBentityProject())
            {
                cc = db.tbInstructor.Include(c => c.project).ToList();
            }    
            foreach (Instructor ina in cc) 
            {
                if (ins.id == ina.id)
                {
                    if (ina.project.Count != 0)
                    {
                        foreach (Project item in ina.project)
                        {
                            try
                            {
                                dicProject.Add(item.name, item.expense);
                                cbListProject.Items.Add(item.name);
                                idProject.Add(item.idProject);
                            }
                            catch
                            {
                                // trùng tên đề tài

                            }

                        }

                        cbListProject.SelectedIndex = 0;


                    }
                    else
                    {
                        
                        cbListProject.Text = "";
                        
                    }
                }    
            } 
                
            
        }

        private void frmInstructorDetail_Load(object sender, EventArgs e)
        {
           
        }
        public void ChangeLanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            InitializeComponent();
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cbListProject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
