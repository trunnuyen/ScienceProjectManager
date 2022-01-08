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
using System.Diagnostics;
using System.Threading;

namespace Project_Management.Views
{
    public partial class frmEditProgress : Form
    {
        public Progress progress;
        public Instructor instructor;
        public bool edit;
        private Dictionary<string, string> dicReport;   // Lần 1 - comment
        private int index;
        public string source;
        public bool sourceEdit;

        public frmEditProgress(Progress pro, Instructor ins)
        {
            InitializeComponent();
            sourceEdit = false;
            progress = pro;
            this.dpSubmitted.Enabled = true;
            List<Project> listProject = new List<Project>();
            listProject = ProjectController.getAllProject();
            Project proj = new Project();
            foreach (Project item in listProject)
            {
                if (item.idProject == pro.idProject)
                {
                    source = item.source;
                    break;
                }
            }
            if (progress.finishTime > DateTime.Now)
            {
                this.txbID.Text = pro.idProject.ToString();
                this.txbID.Enabled = true;
                this.txbName.Text = pro.Name.ToString();
                this.txbName.Enabled = true;
                this.dpStart.Value = pro.dateStart;
                this.dpEnd.Value = pro.finishTime;
                if (source == null)
                    this.richTextBox1.Text = "";
                else
                    this.richTextBox1.Text = source.ToString();
                if (this.richTextBox1.Text == "")
                {
                    this.txtExpense.Enabled = false;
                    this.dpSubmitted.Text = "";
                    this.dpSubmitted.Value = DateTime.Now;
                    this.dpSubmitted.Enabled = false;
                }
                else
                {
                    this.txtExpense.Enabled = true;
                    this.dpSubmitted.Value = pro.submitTime;
                    this.dpSubmitted.Text = pro.submitTime.ToString();
                    this.txtExpense.Text = pro.expense.ToString();
                }
                if (pro.finished == true)
                    this.rbtnComplete.Checked = true;
                else
                    this.rbtnNotComplete.Checked = true;
            }
            else
            {
                this.txbID.Text = pro.idProject.ToString();
                this.txbID.Enabled = true;
                this.txbName.Text = pro.Name.ToString();
                this.txbName.Enabled = true;
                this.dpStart.Value = pro.dateStart;
                this.dpEnd.Value = pro.finishTime;
                this.richTextBox1.Enabled = true;
                if (this.richTextBox1.Text == "")
                {
                    this.txtExpense.Enabled =false;
                    this.dpSubmitted.Text = "";
                }
                this.txtExpense.Text = pro.expense.ToString();
                if (pro.finished == true)
                    this.rbtnComplete.Checked = true;
                else
                    this.rbtnNotComplete.Checked = true;
            }
            if(ins.access.ToString()== "User")
            {
                groupBox3.Visible = false;
            }    
        }
        public void ChangeLanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            InitializeComponent();
        }
        public frmEditProgress(Progress pro, Student st)
        {
            InitializeComponent();
            sourceEdit = false;
            progress = pro;
            this.dpSubmitted.Enabled = true;
            List<Project> listProject = new List<Project>();
            listProject = ProjectController.getAllProject();
            Project proj = new Project();
            foreach (Project item in listProject)
            {
                if (item.idProject == pro.idProject)
                {
                    source = item.source;
                    break;
                }
            }
            
                this.txbID.Text = pro.idProject.ToString();
                this.txbID.Enabled = true;
                this.txbName.Text = pro.Name.ToString();
                this.txbName.Enabled = true;
                this.dpStart.Value = pro.dateStart;
                this.dpEnd.Value = pro.finishTime;
            if (source == null)
            { this.richTextBox1.Text = ""; }
            else
            {
                this.richTextBox1.Text = source.ToString();
            }
                
                    this.dpSubmitted.Value = pro.submitTime;
                    this.dpSubmitted.Text = pro.submitTime.ToString();
                    this.txtExpense.Text = pro.expense.ToString();
                
               
            
            
                if (pro.finished == true)
                    this.rbtnComplete.Checked = true;
                else
                    this.rbtnNotComplete.Checked = true;
            
            
                groupBox3.Visible = false;
            btnCanel.Visible = false;
            btnSave.Visible = false;
            btnDel.Visible = false;
            
        }
        private void frmEditProgress_Load(object sender, EventArgs e)
        {
            dicReport = new Dictionary<string, string>();

            List<Report> listReport=ProjectController.GetListReport(progress.idProject);
            

            if(listReport != null)
            {

                for (int i= 0;i < listReport.Count;i++)
                {
                    dicReport.Add("Lần" +(i+1).ToString(), listReport[i].comment);   //Lần 1
                    this.cbReportTimes.Items.Add(dicReport.Keys.ElementAt(i));  // Lần 1,2,3...
                }
            }

            index = 0;
        }
        #region Thiết lập textbox, text hướng dẫn
        private void txbID_Click(object sender, EventArgs e)
        {
            if (this.txbID.Text == "Nhập mã đồ án")
            {
                this.txbID.Clear();
            }
        }
        private void txbID_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (this.txbID.Text == "Nhập mã đồ án")
            {
                this.txbID.Clear();
            }
            if (e.KeyChar == '\b')
            {
                if (this.txbID.Text.Count() <= 1)
                {
                    this.txbID.Text = "Nhập mã đồ án";
                }
            }
        }
        private void txbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txbName.Text == "Nhập mã đồ án")
            {
                this.txbName.Clear();
            }
            if (e.KeyChar == '\b')
            {
                if (this.txbName.Text.Count() <= 1)
                {
                    this.txbName.Text = "Nhập mã đồ án";
                }
            }
        }

        private void txbName_Click(object sender, EventArgs e)
        {
            if (this.txbName.Text == "Nhập mã đồ án")
            {
                this.txbName.Clear();
            }
        }

        #endregion

        private void cbReportTimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (this.cbReportTimes.SelectedIndex==0)
            {
                if(index !=0)
                {
                    dicReport[dicReport.Keys.ElementAt(index - 1)] = this.rbComment.Text;
                }
                string ss = this.cbReportTimes.Text;
                
                // Add lần
                string s = "Lần " + this.cbReportTimes.Items.Count;
                this.cbReportTimes.Items.Add(s);
                
                this.cbReportTimes.SelectedIndex = this.cbReportTimes.Items.Count - 1;
                this.dicReport.Add("Lần "+ this.cbReportTimes.SelectedIndex.ToString(), "");

                // lưu comment tương ứng với các lần
                this.rbComment.Clear();

            }
            index = this.cbReportTimes.SelectedIndex;

            // hiển thị lại richbox tương ứng với các combobox
            
            if(index!=0)
            {
                for(int i=0;i<this.dicReport.Count;i++)
                {
                    if(dicReport[dicReport.Keys.ElementAt(i)]=="")
                    {
                        dicReport[dicReport.Keys.ElementAt(i)] = this.rbComment.Text;

                    }
                }
            }
            try
            {
                this.rbComment.Text = dicReport[dicReport.Keys.ElementAt(this.cbReportTimes.SelectedIndex - 1)];
            }
            catch
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dpEnd.Value > DateTime.Now)
            {
                if (dpEnd.Value.Date < dpStart.Value.Date)
                {
                    MessageBox.Show("Đặt lại ngày hoàn thành phải lớn hơn ngày bắt đầu");
                    return;
                }
                progress.idProject = this.txbID.Text.Trim();
                progress.Name = this.txbName.Text.Trim();
                //progress.listStudent = null;
                progress.dateStart = this.dpStart.Value;
                progress.finishTime = this.dpEnd.Value;
                //progress.submitTime = this.dpSubmitted.Value;
               
                    
                    progress.submitTime = this.dpSubmitted.Value;
                    source = richTextBox1.Text.Trim();
                if (txtExpense.Text != "")
                {
                    progress.expense = float.Parse(this.txtExpense.Text);
                }
               
                edit = true;
                if(rbtnComplete.Checked == true)
                {
                    progress.finished = true;
                }
                if (rbtnNotComplete.Checked == true)
                {
                    progress.finished = false;
                }
                // thêm các lần Báo cáo
                for (int i = 0; i < dicReport.Count; i++)
                {
                    if (dicReport[dicReport.Keys.ElementAt(i)] == "")
                        dicReport[dicReport.Keys.ElementAt(i)] = this.rbComment.Text;
                }

                ReportController.Delete(progress.idProject);
                // Add rport vào database
                for (int i = 0; i < dicReport.Count; i++)
                {
                    Report rp = new Report();
                    rp.id = progress.idProject + '-' + dicReport.Keys.ElementAt(i);//1811_lẦN 1
                    rp.comment = dicReport[dicReport.Keys.ElementAt(i)];
                    ReportController.AddReport(rp);

                }
            }
            else
            {
                MessageBox.Show("Đề tài quá hạn");
            }
            this.Close();
        }

        private void btnCanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.cbReportTimes.SelectedIndex != 0)
            {
                // xóa lần báo cáo được chọn
                this.dicReport.Remove(this.cbReportTimes.SelectedItem.ToString());
                this.cbReportTimes.Items.Remove(this.cbReportTimes.SelectedItem);
                this.rbComment.Clear();
                index = 0;
                //  Đặt lại tên các lần

                for (int i = 1; i < this.cbReportTimes.Items.Count; i++)
                {
                    this.cbReportTimes.Items[i] = "Lần " + (i).ToString();
                }
            }
        }

        
        private void dpStart_ValueChanged(object sender, EventArgs e)
        {
            if (this.dpStart.Value > DateTime.Now)
                richTextBox1.Enabled = true;
           
        }

        

        private void rbtnComplete_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtnNotComplete_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
                dpSubmitted.Enabled = true;
            else
                dpSubmitted.Enabled = false;
            if (richTextBox1.Text != source)
                sourceEdit = true;
        }
    }
}
