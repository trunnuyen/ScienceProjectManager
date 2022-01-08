using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_Management.Controllers;
using Project_Management.Models;

namespace Project_Management.Views
{
    public partial class frmStudentDetail : Form
    {
        // dùng dictionary để hiển thị list tương ứng với project
        Dictionary<string, float> dicProject;
        List<string> idProject;
        Dictionary<string, string> dicReport;

        public frmStudentDetail(Student st)
        {
            InitializeComponent();
            dicReport = new Dictionary<string, string>();
            dicProject = new Dictionary<string, float>();
            idProject = new List<string>();

            txtName.Text = st.name.ToString();
            txtMSSV.Text = st.MSSV.ToString();
            txtBirthday.Text = st.birthday.ToShortDateString();
            txtGender.Text = st.gender.ToString();
            txtAddress.Text = st.address.ToString();
            txtMajor.Text = st.major.ToString();
            
            txtClass.Text = st.Class.ToString();
            txtFaculty.Text = st.faculty.ToString();

            // Nếu có project
            if(st.project.Count!=0)
            {
                foreach (Project item in st.project)
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
                // SV chưa có project
                cbListProject.Text = "";
                
            }

            txtPhone.Text = st.numberPhone.ToString();
        }
        public void ChangeLanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            InitializeComponent();
        }
        private void frmStudentDetail_Load(object sender, EventArgs e)
        {
            

       

        }

        private void cbListProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Chọn đồ án
            if (dicProject.Count > 0)
            {

                //  exception khi trùng tên đề tài
                
                this.rbComment.Clear();
                // Tạo listReport tương ứng
                List<Report> listReport = ProjectController.GetListReport(idProject[this.cbListProject.SelectedIndex]);

                if (listReport != null)
                {
                    dicReport.Clear();
                    cbTimes.Items.Clear();

                    for (int i = 0; i < listReport.Count; i++)
                    {
                        dicReport.Add("Lần" + (i + 1).ToString(), listReport[i].comment);   //Lần 1
                        this.cbTimes.Items.Add(dicReport.Keys.ElementAt(i));  // Lần 1,2,3...
                    }
                }
            }
        }

        private void cbTimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.rbComment.Text = dicReport[dicReport.Keys.ElementAt(this.cbTimes.SelectedIndex)];
        }
    }
}
