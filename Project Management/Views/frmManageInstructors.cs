using Project_Management.Controllers;
using Project_Management.Models;
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

namespace Project_Management.Views
{
    public partial class frmManageInstructor : Form
    {
        public Instructor instuctor;
        public int STT ;  // dùng để đánh STT trên listview
        public frmManageInstructor(ref Instructor Instuctor)
        {
            InitializeComponent();
            DisplayListGV();
            this.instuctor = Instuctor;
            if (this.instuctor.access == "User")
            {
                btnAddGV.Visible = false;
                btnDeleteGV.Visible = false;
                btnEditGV.Visible = false;
                pictureBox1.Visible = false;
            }
        }
        public void ChangeLanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            InitializeComponent();
        }
        public  void DisplayListGV()
        {
            this.lstInstructor.Items.Clear();
            STT = this.lstInstructor.Items.Count+1;

            List<Instructor> lstGV = GVController.getAllGV();

            // dùng database
            foreach (Instructor infGV in lstGV)
            {
                ListViewItem infoGV = new ListViewItem(STT.ToString());
                infoGV.SubItems.Add(new ListViewItem.ListViewSubItem(infoGV, infGV.id.ToString()));
                infoGV.SubItems.Add(new ListViewItem.ListViewSubItem(infoGV, infGV.name.ToString()));
                infoGV.SubItems.Add(new ListViewItem.ListViewSubItem(infoGV, infGV.gender.ToString()));
                infoGV.SubItems.Add(new ListViewItem.ListViewSubItem(infoGV, infGV.birthday.ToShortDateString()));
                infoGV.SubItems.Add(new ListViewItem.ListViewSubItem(infoGV, infGV.phone.ToString()));
                infoGV.SubItems.Add(new ListViewItem.ListViewSubItem(infoGV, infGV.subject));
                
                this.lstInstructor.Items.Add(infoGV);
                STT++;
            }
        }

        private void LstviewDataGV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void frmGV_Load(object sender, EventArgs e)
        {

        }

        private void btnAddGV_Click(object sender, EventArgs e)
        {
            // Dùng form Add_GV
            frmAddGV addform = new frmAddGV();
            addform.ShowDialog();

            // Nếu cancel (instructor ==null) thì return
            if (addform.instuctor.name == null)
                return;

            // Hiển thị lên listview
            Instructor GV = addform.instuctor;

            ListViewItem infoGV = new ListViewItem(STT.ToString());
            infoGV.SubItems.Add(new ListViewItem.ListViewSubItem(infoGV, GV.id.ToString()));
            infoGV.SubItems.Add(new ListViewItem.ListViewSubItem(infoGV, GV.name.ToString()));
            infoGV.SubItems.Add(new ListViewItem.ListViewSubItem(infoGV, GV.gender.ToString())); 
            infoGV.SubItems.Add(new ListViewItem.ListViewSubItem(infoGV, GV.birthday.ToShortDateString()));
            infoGV.SubItems.Add(new ListViewItem.ListViewSubItem(infoGV, GV.phone.ToString()));
            infoGV.SubItems.Add(new ListViewItem.ListViewSubItem(infoGV, GV.subject));

            //Dùng str để đưa danh sách môn học về trong 1 ô
            this.lstInstructor.Items.Add(infoGV);

            //Thêm vào list, dùng database
            //GVController.AddGV(addform.instuctor);

            // Tăng STT
            STT++;


            if (GVController.AddGV(GV) == true)
                GVController.AddGV(GV);
            else
                MessageBox.Show("Err add GV");

        }

        private void btnEditGV_Click(object sender, EventArgs e)
        {
            if (this.lstInstructor.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("Bạn chưa chọn đối tượng !", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(this.lstInstructor.Items.Count==0)
            {
                return;
            }
            Instructor ins = new Instructor();

            //Lấy GV từ database với key tương ứng (id)

            ins = GVController.GetInstructor(this.lstInstructor.SelectedItems[0].SubItems[1].Text);

            string oldID = ins.id;
            //Dùng form frmAddGV với chức năng sửa
            frmAddGV addform = new frmAddGV( ref ins);
            addform.ShowDialog();

            // Sửa trên database( tìm index và sửa)
            GVController.Update(ins,oldID);

            // Update trên listview
            this.lstInstructor.SelectedItems[0].SubItems[1].Text = ins.id.ToString();
            this.lstInstructor.SelectedItems[0].SubItems[2].Text = ins.name.ToString();
            this.lstInstructor.SelectedItems[0].SubItems[3].Text = ins.gender;
            this.lstInstructor.SelectedItems[0].SubItems[5].Text = ins.birthday.ToShortDateString();
            this.lstInstructor.SelectedItems[0].SubItems[4].Text = ins.phone;
            this.lstInstructor.SelectedItems[0].SubItems[6].Text = ins.subject;

        }

        private void btnDeleteGV_Click(object sender, EventArgs e)
        {
            if (this.lstInstructor.Items.Count == 0)
            {
                return;
            }

            if (this.lstInstructor.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn đối tượng!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult dlr = MessageBox.Show("Bạn có muốn xóa đối tượng?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.No)
            {
                return;
            }
            // Xóa trên list, dùng database
            if (lstInstructor.SelectedItems[0].Checked == false)
            {
                string getIdgv = this.lstInstructor.SelectedItems[0].SubItems[1].Text;
                this.lstInstructor.SelectedItems[0].Remove();

                Instructor deleteGv = GVController.getIDformGV(getIdgv);
                try
                {
                    GVController.Delete(deleteGv);
                }
                catch
                {
                    MessageBox.Show("err delete");
                }
            }
            DisplayListGV();

        }

        private void frmManageInstructor_MdiChildActivate(object sender, EventArgs e)
        {

        }

        private void btnTeacherDetail_Click(object sender, EventArgs e)
        {
            if (this.lstInstructor.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn đối tượng!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Instructor ins = GVController.GetInstructor(this.lstInstructor.SelectedItems[0].SubItems[1].Text);
            frmInstructorDetail frmDetail = new frmInstructorDetail(ins);
            frmDetail.ShowDialog();
        }


        private void txtSearchGV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txtSearchGV.Text == "Nhập mã GV")
            {
                this.txtSearchGV.Clear();
            }
            if(e.KeyChar=='\b')
            {
                this.txtSearchGV.Text = "Nhập mã GV";
            }
        }
        private void txtSearchGV_Click(object sender, EventArgs e)
        {
            if (this.txtSearchGV.Text == "Nhập mã GV")
            {
                this.txtSearchGV.Clear();
            }
        }
        private void Search(Instructor ins)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtSearchGV.Text.Trim() == "")
                {
                    DisplayListGV();
                }
                else
                {
                    this.lstInstructor.Items.Clear();
                    List<Instructor> lInstructor = GVController.Search(this.txtSearchGV.Text.Trim());
                    int id = 1;
                    foreach (Instructor ins  in lInstructor)
                    {
                        ListViewItem infoGV = new ListViewItem(id.ToString());
                        infoGV.SubItems.Add(new ListViewItem.ListViewSubItem(infoGV, ins.id.ToString()));
                        infoGV.SubItems.Add(new ListViewItem.ListViewSubItem(infoGV, ins.name.ToString()));
                        infoGV.SubItems.Add(new ListViewItem.ListViewSubItem(infoGV, ins.gender.ToString()));
                        infoGV.SubItems.Add(new ListViewItem.ListViewSubItem(infoGV, ins.birthday.ToShortDateString()));
                        infoGV.SubItems.Add(new ListViewItem.ListViewSubItem(infoGV, ins.phone.ToString()));
                        infoGV.SubItems.Add(new ListViewItem.ListViewSubItem(infoGV, ins.subject));

                        this.lstInstructor.Items.Add(infoGV);
                        id++;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không tìm thấy", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            DisplayListGV();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.lstInstructor.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("Bạn chưa chọn đối tượng !", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.lstInstructor.Items.Count == 0)
            {
                return;
            }
            Instructor ins = new Instructor();

            //Lấy GV từ database với key tương ứng (id)

            ins = GVController.GetInstructor(this.lstInstructor.SelectedItems[0].SubItems[1].Text);

            string oldID = ins.id;
            //Dùng form frmAccess với chức năng sửa
            frmAccess accessform = new frmAccess(ref ins);
            accessform.ShowDialog();

            // Sửa trên database( tìm index và sửa)
            GVController.Update(ins, oldID);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

