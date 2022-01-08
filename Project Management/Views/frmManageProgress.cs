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
    public partial class frmManageProgress : Form
    {
        int id;
        public Instructor instructor;
        List<Progress> listProgress;
        int STT;
        public TimeSpan timeDown;
        public frmManageProgress(Instructor ins)
        {
            InitializeComponent();
            DisplayProgress(ins);
            instructor = ins;
            if (ins.access == "User")
            {
                textBox1.Visible = false;
                button1.Visible = false;
            }    
        }

        public void DisplayProgress(Instructor ins)
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
            if (ins.access == "Admin")
            {
                foreach (Progress item in listProgress)
                {
                    ListViewItem progress = new ListViewItem(STT.ToString());
                    progress.SubItems.Add(new ListViewItem.ListViewSubItem(progress, item.idProject.ToString()));
                    progress.SubItems.Add(new ListViewItem.ListViewSubItem(progress, item.Name.ToString()));


                    Project p = ProjectController.GetProject(item.idProject);
                    string sStudent = "";
                    foreach (Student st in p.listStudent)
                    {
                        sStudent += st.name.ToString() + " - ";
                    }
                    progress.SubItems.Add(new ListViewItem.ListViewSubItem(progress, sStudent));

                    progress.SubItems.Add(new ListViewItem.ListViewSubItem(progress, item.dateStart.ToShortDateString()));//Ngày bắt đầu
                    progress.SubItems.Add(new ListViewItem.ListViewSubItem(progress, item.finishTime.ToShortDateString()));//Ngày kết thúc

                    progress.SubItems.Add(new ListViewItem.ListViewSubItem(progress, item.submitTime.ToString()));//Ngày xác nhận

                    progress.SubItems.Add(new ListViewItem.ListViewSubItem(progress, item.expense.ToString()));
                    listViewProgress.Items.Add(progress);
                    STT++;
                }
            }
            else
            {
                Progress pro = new Progress();
                foreach (Instructor ina in cc)
                {
                    if (ins.id == ina.id && ins.access == "User")
                    {
                        foreach (Project item in ina.project)
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
                                    listViewProgress.Items.Add(Pr);
                                    STT++;
                                }
                            }
                        }
                    }
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
            foreach(Progress item in listProgress)
            {
                if (item.idProject.ToString() == this.listViewProgress.SelectedItems[0].SubItems[1].Text)
                { 
                    pro = item; 
                    break;
                }
            }

            frmEditProgress formAdd = new frmEditProgress(pro, instructor);
            formAdd.ShowDialog();

            if(formAdd.edit == true)
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
                //Update
                ProgressController.UpdateProgress(pro);
                this.listViewProgress.Items[this.listViewProgress.SelectedItems[0].Index] = Pr;

                // cập nhật lại cho project tương ứng
                List<Project> listProject = new List<Project>();
                listProject = ProjectController.getAllProject();
                Project proj = new Project();
                foreach (Project item in listProject)
                {
                    if (item.idProject == pro.idProject)
                    {
                        proj = item;
                        proj.idProject = pro.idProject;
                        proj.name = pro.Name;
                        
                        proj.dateStart = pro.dateStart;
                        proj.dateEnd = pro.finishTime;
                        proj.expense = pro.expense;
                        proj.source = formAdd.source;
                        ProjectController.UpdateProject(proj);
                        break;
                    }
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox1.Text.Trim() == "")
                {
                    DisplayProgress(instructor);
                }
                else
                {
                    this.listViewProgress.Items.Clear();
                    List<Progress> lProgress = ProgressController.Search(this.textBox1.Text.Trim());

                    foreach (Progress item in lProgress)
                    {
                        ListViewItem proj = new ListViewItem(STT.ToString());
                        proj.SubItems.Add(new ListViewItem.ListViewSubItem(proj, item.idProject.ToString()));
                        proj.SubItems.Add(new ListViewItem.ListViewSubItem(proj, item.Name.ToString()));
                        Project p = ProjectController.GetProject(item.idProject);
                        string sStudent = "";
                        foreach (Student st in p.listStudent)
                        {
                            sStudent += st.name.ToString() + " - ";
                        }
                        proj.SubItems.Add(new ListViewItem.ListViewSubItem(proj, sStudent));
                     
                        proj.SubItems.Add(new ListViewItem.ListViewSubItem(proj, item.dateStart.ToShortDateString()));//Ngày bắt đầu
                        proj.SubItems.Add(new ListViewItem.ListViewSubItem(proj, item.finishTime.ToShortDateString()));//Ngày kết thúc
                        if (item.finished == true)
                            proj.SubItems.Add(new ListViewItem.ListViewSubItem(proj, item.submitTime.ToString()));//Ngày nộp
                        else
                            proj.SubItems.Add(new ListViewItem.ListViewSubItem(proj, ""));//Ngày xác nhận
                        proj.SubItems.Add(new ListViewItem.ListViewSubItem(proj, item.expense.ToString()));




                        this.listViewProgress.Items.Add(proj);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Không tìm thấy", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbtimedown_Click(object sender, EventArgs e)
        {

        }

        private void radNotFinished_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radFinished_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lbProjectName_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
