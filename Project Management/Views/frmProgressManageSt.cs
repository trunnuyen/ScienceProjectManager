using Project_Management.Models;
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
using System.Data.Entity;
using System.Threading;

namespace Project_Management.Views
{
    public partial class frmProgressManageSt : Form
    {
        List<Progress> listProgress;
        public TimeSpan timeDown;
        public Student student;
        int STT;
        public frmProgressManageSt(Student st)
        {
            InitializeComponent();
            DisplayProgress(st);
            student = st;
            
        }

        private void listViewProgress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewProgress.SelectedItems.Count == 0)
                return;
            Progress pro = new Progress();
            listProgress = ProgressController.getAllProgress();
            foreach (Progress item in listProgress)
            {
                if (item.idProject.ToString() == this.listViewProgress.SelectedItems[0].SubItems[1].Text)
                    pro = item;
            }
            if (pro.finished == true)
                this.radFinished.Checked = true;
            else
                this.radNotFinished.Checked = true;
            this.lbProjectName.Text = pro.Name.ToString();
            timeDown = pro.finishTime - DateTime.Now;
            this.timedown.Start();
        }
        public void DisplayProgress(Student st)
        {
            this.listViewProgress.Items.Clear();
            int STT = 1;
            List<Progress> listProgress = ProgressController.getAllProgress();
            var cc = new List<Instructor>();
            var zz = new List<Student>();

            using (var db = new DBentityProject())
            {
                cc = db.tbInstructor.Include(c => c.project).ToList();
                zz = db.tbStudent.Include(c => c.project).ToList();

            }
            
           
                Progress pro = new Progress();
                foreach (Student std in zz)
                {
                    if (std.MSSV == st.MSSV)
                    {
                        foreach (Project item in std.project)
                        {
                            foreach (Progress pg in listProgress)
                            {
                                if (item.idProject.ToString() == pg.idProject.ToString())
                                {
                                    pro = pg;
                                    ListViewItem Pr = new ListViewItem(STT.ToString());
                                    Pr.SubItems.Add(new ListViewItem.ListViewSubItem(Pr, pro.idProject.ToString()));
                                    Pr.SubItems.Add(new ListViewItem.ListViewSubItem(Pr, pro.Name.ToString()));

                                    Project p = ProjectController.GetProject(pro.idProject);
                                    string sStudent = "";
                                   
                                    sStudent += std.name.ToString() + " - ";
                                    
                                    Pr.SubItems.Add(new ListViewItem.ListViewSubItem(Pr, sStudent));

                                    Pr.SubItems.Add(new ListViewItem.ListViewSubItem(Pr, pro.dateStart.ToShortDateString()));//Ngày bắt đầu
                                    Pr.SubItems.Add(new ListViewItem.ListViewSubItem(Pr, pro.finishTime.ToShortDateString()));//Ngày kết thúc
                                    if (pro.finished == true)
                                        Pr.SubItems.Add(new ListViewItem.ListViewSubItem(Pr, pro.submitTime.ToString()));//Ngày xác nhận
                                    else
                                        Pr.SubItems.Add(new ListViewItem.ListViewSubItem(Pr, ""));//Ngày xác nhận
                                    Pr.SubItems.Add(new ListViewItem.ListViewSubItem(Pr, pro.expense.ToString()));
                                    listViewProgress.Items.Add(Pr);
                                    STT++;
                                }
                            }
                        }
                    }
                }
            
        }
        private void timedown_Tick(object sender, EventArgs e)
        {
            if (timeDown.TotalDays < 1)
            {
                this.lbtimedown.Text = "Time remaining: " + timeDown.Hours.ToString() + " hours";
                this.lbtimedown.ForeColor = Color.Green;
                if (timeDown.Hours.ToString().Contains("-"))
                {
                    this.lbtimedown.Text = "Hết hạn";
                    this.lbtimedown.ForeColor = Color.Red;
                }
            }
            else if (timeDown.TotalHours < 1)
            {
                this.lbtimedown.Text = "Time remaining: " + timeDown.Minutes.ToString() + " minutes";
                this.lbtimedown.ForeColor = Color.Red;
            }
            else if (timeDown.TotalMinutes < 1)
            {
                this.lbtimedown.Text = "Time remaining: " + timeDown.Seconds.ToString() + " seconds";
                this.lbtimedown.ForeColor = Color.Red;
            }
            else
            {
                this.lbtimedown.Text = "Time remaining: " + timeDown.Days.ToString() + " days";
                this.lbtimedown.ForeColor = Color.Green;
                if (timeDown.Hours.ToString().Contains("-"))
                {
                    this.lbtimedown.Text = "Hết hạn";
                    this.lbtimedown.ForeColor = Color.Red;
                }
            }
        }
        public void ChangeLanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.listViewProgress.SelectedItems.Count == 0)
                return;

            Progress pro = new Progress();

            listProgress = ProgressController.getAllProgress();
            foreach (Progress item in listProgress)
            {
                if (item.idProject.ToString() == this.listViewProgress.SelectedItems[0].SubItems[1].Text)
                {
                    pro = item;
                    break;
                }
            }

            frmEditProgress formAdd = new frmEditProgress(pro, student);
            formAdd.ShowDialog();

            if (formAdd.edit == true)
            {
                for (int i = 0; i < this.listViewProgress.Items.Count; i++)
                {
                    if (listViewProgress.Items[i].SubItems[1].Text == pro.idProject)
                    {
                        STT = i + 1;
                        break;
                    }
                }
                ListViewItem Pr = new ListViewItem(STT.ToString());
                Pr.SubItems.Add(new ListViewItem.ListViewSubItem(Pr, pro.idProject.ToString()));
                Pr.SubItems.Add(new ListViewItem.ListViewSubItem(Pr, pro.Name.ToString()));

                Project p = ProjectController.GetProject(pro.idProject);
                string sStudent = "";
                foreach (Student st in p.listStudent)
                {
                    sStudent += st.name.ToString() + " - ";
                }
                Pr.SubItems.Add(new ListViewItem.ListViewSubItem(Pr, sStudent));

                Pr.SubItems.Add(new ListViewItem.ListViewSubItem(Pr, pro.dateStart.ToShortDateString()));//Ngày bắt đầu
                Pr.SubItems.Add(new ListViewItem.ListViewSubItem(Pr, pro.finishTime.ToShortDateString()));//Ngày kết thúc
                if (pro.finished == true)
                    Pr.SubItems.Add(new ListViewItem.ListViewSubItem(Pr, pro.submitTime.ToString()));//Ngày xác nhận
                else
                    Pr.SubItems.Add(new ListViewItem.ListViewSubItem(Pr, ""));//Ngày xác nhận
                Pr.SubItems.Add(new ListViewItem.ListViewSubItem(Pr, pro.expense.ToString()));
                
                
            }
        }
    }
}
