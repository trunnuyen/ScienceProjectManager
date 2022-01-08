using Project_Management.Controllers;
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

namespace Project_Management.Views
{
    public partial class frmManageStudent : Form
    {
        private int STT;
        public frmManageStudent()
        {
            InitializeComponent();
            DisplayListView();
        }
        public void DisplayListView()
        {
            this.lstStudent.Items.Clear();
            STT = this.lstStudent.Items.Count + 1;

            List<Student> listStudent = StudentController.getAllSTD();

            foreach (Student ST in listStudent)
            {
                ListViewItem St = new ListViewItem(STT.ToString());
                St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.MSSV.ToString()));
                St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.name.ToString()));
                St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.gender.ToString()));
                St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.birthday.ToShortDateString()));
                St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.address.ToString()));
                St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.numberPhone.ToString()));
                St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.faculty.ToString()));
                St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.major.ToString()));
                St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.Class.ToString()));
                St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.course.ToString()));
                this.lstStudent.Items.Add(St);
                
                STT++;
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {

            frmAdd_Edit frmadd = new frmAdd_Edit();
            DialogResult rs = frmadd.ShowDialog();
            if (frmadd.student.MSSV == null)
                return;

            // Mỗi lần Add là mỗi lần load cả List , có nên không nhỉ ???
            ListViewItem St = new ListViewItem(STT.ToString());
            St.SubItems.Add(new ListViewItem.ListViewSubItem(St, frmadd.student.MSSV.ToString()));
            St.SubItems.Add(new ListViewItem.ListViewSubItem(St, frmadd.student.name.ToString()));
            St.SubItems.Add(new ListViewItem.ListViewSubItem(St, frmadd.student.gender.ToString()));
            St.SubItems.Add(new ListViewItem.ListViewSubItem(St, frmadd.student.birthday.ToShortDateString()));
            St.SubItems.Add(new ListViewItem.ListViewSubItem(St, frmadd.student.address.ToString()));
            St.SubItems.Add(new ListViewItem.ListViewSubItem(St, frmadd.student.numberPhone.ToString()));
            St.SubItems.Add(new ListViewItem.ListViewSubItem(St, frmadd.student.faculty.ToString()));
            St.SubItems.Add(new ListViewItem.ListViewSubItem(St, frmadd.student.major.ToString()));
            St.SubItems.Add(new ListViewItem.ListViewSubItem(St, frmadd.student.Class.ToString()));
            St.SubItems.Add(new ListViewItem.ListViewSubItem(St, frmadd.student.course.ToString()));

            this.lstStudent.Items.Add(St);
            StudentController.AddStudent(frmadd.student);
            STT++;

        }

        private void frmMange_Load(object sender, EventArgs e)
        {
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            // Dùng để kiểm tra edit có bị trung MSSV không
           
            if (this.lstStudent.SelectedItems.Count <= 0)        //???
            {
                MessageBox.Show("Bạn chưa chọn đối tượng?", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.lstStudent.Items.Count == 0)
                return;

            // Tìm ST với MSSV tương ứng trong database
            Student ST = new Student();
            ST = StudentController.GetStudentbyID(this.lstStudent.SelectedItems[0].SubItems[1].Text);

            if(ST.MSSV==null)
            {
                return;
            }
            string oldMSSV = this.lstStudent.SelectedItems[0].SubItems[1].Text;
            frmAdd_Edit frmedit = new frmAdd_Edit( ref ST);
            DialogResult rs = frmedit.ShowDialog();

            if (frmedit.edit == true)
            {
                // Tìm STT cho ST
                for (int i = 0; i < this.lstStudent.Items.Count; i++)
                {
                    if (lstStudent.Items[i].SubItems[1].Text == ST.MSSV)
                    {
                        STT = i + 1;
                        break;
                    }
                }
                
                ListViewItem St = new ListViewItem(STT.ToString());
                St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.MSSV.ToString()));
                St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.name.ToString()));
                St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.gender.ToString()));
                St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.birthday.ToShortDateString()));
                St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.address.ToString()));
                St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.numberPhone.ToString()));
                St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.faculty.ToString()));
                St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.major.ToString()));
                St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.Class.ToString()));
                St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.course.ToString()));

                //Update
                StudentController.UpdateStudent(ST,oldMSSV);
                this.lstStudent.Items[this.lstStudent.SelectedItems[0].Index] = St;

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.lstStudent.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Bạn chưa chọn đối tượng đối tượng?", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dlr = MessageBox.Show("Bạn có muốn xóa đối tượng?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.No)
            {
                return;
            }
            // CODE Y
            //Student std = StudentController.GetStudentbyID(this.lstStudent.SelectedItems[0].SubItems[1].Text);
            ////listStudent.Remove(std);
            //StudentController.Delete(std);
            //this.lstStudent.Items.RemoveAt(this.lstStudent.SelectedItems[0].Index);

            string getMssv = this.lstStudent.SelectedItems[0].SubItems[1].Text;

            this.lstStudent.SelectedItems[0].Remove();

            Student deleteStd = StudentController.getMssvStd(getMssv);
            try
            {
                StudentController.Delete(deleteStd);
            }
            catch
            {
                MessageBox.Show("err delete");
            }
            DisplayListView();
        }

        private void listviewStudent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmManageStudent_MdiChildActivate(object sender, EventArgs e)
        {

        }

        private void btnStudentDetail_Click(object sender, EventArgs e)
        {
            if (this.lstStudent.SelectedItems.Count == 0)
                return;
            Student st = StudentController.GetStudentbyID(this.lstStudent.SelectedItems[0].SubItems[1].Text);
            frmStudentDetail frmDetail = new frmStudentDetail(st);
            frmDetail.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(this.txtSearch.Text== "Nhập MSSV")
            {
                this.txtSearch.Clear();
            }
            if(e.KeyChar=='\b')
            {
                if(this.txtSearch.Text.Count()==1)
                {
                    this.txtSearch.Text = "Nhập MSSV";
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtSearch.Text.Trim() == "")
                {
                    DisplayListView();
                }
                else
                {
                    this.lstStudent.Items.Clear();
                    List<Student> lstudent = StudentController.Search(this.txtSearch.Text.Trim());
                    int ID = 1;
                    foreach (Student ST in lstudent)
                    {
                        ListViewItem St = new ListViewItem(ID.ToString());
                        St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.MSSV.ToString()));
                        St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.name.ToString()));
                        St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.gender.ToString()));
                        St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.birthday.ToShortDateString().ToString()));
                        St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.address.ToString()));
                        St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.numberPhone.ToString()));
                        St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.faculty.ToString()));
                        St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.major.ToString()));
                        St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.Class.ToString()));
                        St.SubItems.Add(new ListViewItem.ListViewSubItem(St, ST.course.ToString()));
                        this.lstStudent.Items.Add(St);
                    }
                }
            }
            catch
            {
                DisplayListView();
                MessageBox.Show("Không tìm thấy", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            DisplayListView();
        }
    }
}
