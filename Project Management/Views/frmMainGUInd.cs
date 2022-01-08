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
using System.Threading;

namespace Project_Management.Views
{
    public partial class frmMainGUInd : Form
    {
        frmManageProject formProject;
        frmManageInstructor formInstructor;
        frmManageStudent formStudent;
        frmManageProgress formProgress;
        frmProgressManageSt formProgressSt;
        frmManageProjectSt formProjectSt;
        public string id;
        public string ID;
        public frmMainGUInd(string s)
        {

            InitializeComponent();
            timer1.Start();
            List<Instructor> lstGV = GVController.getAllGV();

            foreach (Instructor infGV in lstGV)
            {
                if (infGV.id == s && infGV.access == "User")
                {

                    label2.Text = infGV.name;
                    panel16.Visible = false;

                    panel3.Visible = false;
                }

            }

            List<Student> lstSV = StudentController.getAllSTD();

            foreach (Student infSV in lstSV)
            {
                if (infSV.MSSV == s)
                {

                    label2.Text = infSV.name;
                    panel16.Visible = false;
                    panel4.Visible = false;
                    panel3.Visible = false;
                    panel7.Visible = false;

                }

            }
            ID = s;
            id = s;
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            Instructor ins = new Instructor();

            //Lấy GV từ database với key tương ứng (id)

            ins = GVController.GetInstructor(id);
            this.lbFirst.Visible = false;
            if (this.formStudent is null || this.formStudent.IsDisposed)
            {
                this.formStudent = new frmManageStudent(ins);
                this.formStudent.MdiParent = this;
                this.formStudent.Show();
            }
            else
            {
                this.formStudent.Select();
                this.formStudent.DisplayListView();
            }
        }
        public void ChangeLanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            InitializeComponent();
        }
        private void btnGV_Click(object sender, EventArgs e)
        {
            this.lbFirst.Visible = false;
            if (this.formInstructor is null || this.formInstructor.IsDisposed)
            {
                Instructor ins = new Instructor();

                //Lấy GV từ database với key tương ứng (id)

                ins = GVController.GetInstructor(id);
                this.formInstructor = new frmManageInstructor(ref ins);
                this.formInstructor.MdiParent = this;
                this.formInstructor.Show();
            }
            else
            {
                this.formInstructor.Select();
                this.formInstructor.DisplayListGV();
            }
        }
        private void btnProject_Click(object sender, EventArgs e)
        {
            Instructor ins = new Instructor();
            ins = GVController.GetInstructor(id);
            Student st = new Student();
            st = StudentController.GetStudentbyID(ID);
            this.lbFirst.Visible = false;
            if (ins != null)
            {
                if (this.formProject is null || this.formProject.IsDisposed)
                {

                    this.formProject = new frmManageProject(ins);
                    this.formProject.MdiParent = this;
                    this.formProject.Show();
                }
                else
                {

                    this.formProject.Select();
                    this.formProject.DisplayListProject(ins);

                }
            }
            else
            {
                if (this.formProjectSt is null || this.formProjectSt.IsDisposed)
                {

                    this.formProjectSt = new frmManageProjectSt(st);
                    this.formProjectSt.MdiParent = this;
                    this.formProjectSt.Show();
                }
                else
                {

                    this.formProjectSt.Select();
                    this.formProjectSt.DisplayListProject(st);

                }
            }
        }

        private void frmMainGUInd_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                return;
            }
            this.ActiveMdiChild.WindowState = FormWindowState.Maximized;
            if (this.ActiveMdiChild.Tag == null)
            {
                TabPage tp = new TabPage(this.ActiveMdiChild.Text);
                tp.Tag = this.ActiveMdiChild;
                //tp.Parent = this.tabMain;
                //this.tabMain.SelectedTab = tp;
                this.ActiveMdiChild.Tag = tp;
                this.ActiveMdiChild.FormClosed += ActiveMdiChild_FormClosed;
            }
        }

        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
        }

        /*private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.tabMain.SelectedTab != null && this.tabMain.SelectedTab.Tag !=null)
            {
                (this.tabMain.SelectedTab.Tag as Form).Select();
            }
            else
            {
                this.lbFirst.Visible = true;
            }
        }*/

        private void frmMainGUInd_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            this.lbFirst.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.lbFirst.Visible = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label4.Text = DateTime.Now.Date.ToLongDateString().ToString();
            this.label5.Text = DateTime.Now.ToLongTimeString().ToString();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResize_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Click(object sender, EventArgs e)
        {
            this.lbFirst.Visible = true;
        }

        private void btnProgress_Click(object sender, EventArgs e)
        {
            Instructor ins = new Instructor();

            //Lấy GV từ database với key tương ứng (id)

            ins = GVController.GetInstructor(id);

            Student st = new Student();

            st = StudentController.GetStudentbyID(ID);

            this.lbFirst.Visible = false;
            if (ins != null)
            {
                if (this.formProgress is null || this.formProgress.IsDisposed)
                {

                    this.formProgress = new frmManageProgress(ins);
                    this.formProgress.MdiParent = this;
                    this.formProgress.Show();
                }
                else
                {
                    this.formProgress.Select();
                    this.formProgress.DisplayProgress(ins);
                }
            }
            else
            {
                if (this.formProgressSt is null || this.formProgressSt.IsDisposed)
                {

                    this.formProgressSt = new frmProgressManageSt(st);
                    this.formProgressSt.MdiParent = this;
                    this.formProgressSt.Show();
                }
                else
                {
                    this.formProgressSt.Select();
                    this.formProgressSt.DisplayProgress(st);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMainSearch formSearch = new frmMainSearch();
            formSearch.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSettings formSetting = new frmSettings();
            formSetting.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Instructor ins = new Instructor();
            Student st = new Student();
            //Lấy GV từ database với key tương ứng (id)

            ins = GVController.GetInstructor(id);
            st = StudentController.GetStudentbyID(ID);

            if (ins != null)
            {
                if (ins.access.ToString() == "Admin" || ins.access.ToString() == "User")
                {
                    string oldID = ins.id;
                    //Dùng form frmAddGV với chức năng sửa
                    frmAddGV addform = new frmAddGV(ref ins);
                    addform.ShowDialog();

                    // Sửa trên database( tìm index và sửa)
                    GVController.Update(ins, oldID);
                }
            }
            else
            {
                string oldIDSV = st.MSSV;
                //Dùng form frmAddGV với chức năng sửa
                frmAdd_Edit addform = new frmAdd_Edit(ref st);
                addform.ShowDialog();

                // Sửa trên database( tìm index và sửa)
                StudentController.UpdateStudent(st, oldIDSV);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        } 
    }
            
    
}
