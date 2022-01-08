using Project_Management.Controllers;
using Project_Management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Management
{
    public partial class frmAddGV : Form
    {
        public Instructor instuctor;
        public bool edit = false;
        string oldMGV = "";
        private List<ErrorProvider> listError;
        public frmAddGV()
        {
            // Chức năng thêm
            instuctor = new Instructor();
            InitializeComponent();
            this.lblName.Text = "THÊM GIÁO VIÊN";
            
            
                
            
        }
        public frmAddGV( ref Instructor Instuctor)
        {
            // Chức năng sửa 
            InitializeComponent();
            this.instuctor = Instuctor;
            edit = true;            
            oldMGV = instuctor.id;
            this.lblName.Text = "CHỈNH SỬA GIÁO VIÊN";
            this.btnSave.Text = "Lưu";
            
                comboBox1.Visible = false;
                label6.Visible = false;
            
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {

            List<Subject> sub= SubjectController.GetListSubject();
            foreach (Subject item in sub)
            {
                this.cbSubject.Items.Add(item.subject);
            }

            listError = new List<ErrorProvider>();

            for (int i = 0; i < 7; i++)
            {
                listError.Add(new ErrorProvider());
            }
            if(instuctor.id==null)
            {
                //Bật text hướng dẫn cho combobox
                this.cbGender.SelectedIndex = 0;
                this.cbSubject.SelectedIndex = 0;
            }
            else
            {
                this.txbID.Text = this.instuctor.id;
                this.txtPassword.Text = this.instuctor.password;
                this.txbName.Text = this.instuctor.name;
                this.txbPhone.Text = this.instuctor.phone;
                this.cbGender.Text = this.instuctor.gender;
                this.dpBirthday.Value = this.instuctor.birthday;
                this.txbAddress.Text = this.instuctor.address;
                this.cbSubject.Text = this.instuctor.subject;
                this.comboBox1.Text = this.instuctor.access;
                // xử lí chuỗi và hiển thị lại subject
                string[] str = instuctor.subject.Split('-');
                foreach (string item in str)
                {
                    this.listboxSubject.Items.Add(item.Trim());
                }
            }
        }

        public void ChangeLanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            InitializeComponent();
        }
        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkError() == true)
            {
                return;
            }

            instuctor.id = this.txbID.Text.Trim();
            instuctor.password = this.txtPassword.Text.Trim();
            instuctor.name = this.txbName.Text.Trim();
            instuctor.phone = this.txbPhone.Text.Trim();
            instuctor.birthday = this.dpBirthday.Value;
            instuctor.gender = this.cbGender.SelectedItem.ToString();
            instuctor.address = this.txbAddress.Text.Trim();
            instuctor.access = this.comboBox1.Text.Trim();
           

            string subject = this.listboxSubject.Items[0].ToString();
            
            for (int i = 1; i < this.listboxSubject.Items.Count; i++)
            {
                subject +=  "-" + listboxSubject.Items[i].ToString() ;
            }
            instuctor.subject = subject;
           
            this.Close();

        }
        private bool checkError()
        {
            bool error = false;
            if (this.txbName.Text.Trim() == "" || this.txbName.Text== "Nhập tên giảng viên")
            {
                this.listError[0].SetError(this.txbName, "Chưa nhập dữ liệu");
                error = true;
            }
            if (this.txbPhone.Text.Trim() == "" || this.txbPhone.Text== "Nhập số điện thoại")
            {
                this.listError[1].SetError(this.txbPhone, "Chưa nhập dữ liệu");
                error = true;
            }
            
            // Kiểm tra năm
            int year = DateTime.Now.Year - this.dpBirthday.Value.Year;
            if (year < 18)
            {
                this.listError[2].SetError(this.dpBirthday, "Dữ liệu không hợp lệ");
                error = true;
            }
            if (this.listboxSubject.Items.Count == 0)
            {
                this.listError[3].SetError(this.cbSubject, "Chưa chọn môn");
                error = true;
            }

            // Thiếu error cho MGV
            if(this.txbID.Text.Trim()=="" || this.txbID.Text== "Nhập mã giáo viên")
            {
                this.listError[4].SetError(this.txbID, "Chưa nhập MGV");
                error = true;
            }
            if (this.txtPassword.Text.Trim() == "" || this.txbID.Text == "Nhập mật khẩu")
            {
                this.listError[4].SetError(this.txbID, "Chưa nhập mật khẩu");
                error = true;
            }

            else if(GVController.CheckMGV(oldMGV, this.txbID.Text,edit)==true)
            {
                this.listError[4].SetError(this.txbID, "Mã GV đã tồn tại");
                error = true;
            }
            return error;
        }

        private void listboxSubject_DoubleClick(object sender, EventArgs e)
        {
            // Xóa item khi double click
            this.listboxSubject.Items.Remove(this.listboxSubject.SelectedItem);
        }

        private void cbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nếu chọn text hướng dẫn thì return
            if(this.cbSubject.SelectedIndex==0)
            {
                return;
            }
            // Khi chọn item , sẽ add vào listbox
            for (int i = 0; i < this.listboxSubject.Items.Count; i++)
            {
                // Nếu chọn bị trùng thì không add vào listbox
                if (this.listboxSubject.Items[i].ToString() == this.cbSubject.SelectedItem.ToString())
                {
                    return;
                }
            }
            // Add item đã chọn vào listbox
            this.listboxSubject.Items.Add(this.cbSubject.SelectedItem.ToString());
        }

        #region    Thiết lập các textbox, text hướng dẫn
        private void txbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                e.Handled = !char.IsNumber(e.KeyChar); // handle do not receive key differnt number
            }

            if (this.txbPhone.Text == "Nhập số điện thoại")
            {
                this.txbPhone.Clear();
            }
            if (e.KeyChar == '\b')
            {
                if (this.txbPhone.Text.Count() <= 1)
                {
                    this.txbPhone.Text = "Nhập số điện thoại";
                    
                }
            }
        }
        private void txbPhone_Click(object sender, EventArgs e)
        {
            if (this.txbPhone.Text == "Nhập số điện thoại")
            {
                this.txbPhone.Clear();
            }
        }
        private void txbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txbName.Text == "Nhập tên giảng viên")
            {
                this.txbName.Clear();
            }
            if (e.KeyChar == '\b' )
            {
                if(this.txbName.Text.Count()<=1)
                {
                    this.txbName.Text = "Nhập tên giảng viên";
                }
            }  
        }

        private void txbName_Click(object sender, EventArgs e)
        {
            if (this.txbName.Text == "Nhập tên giảng viên")
            {
                this.txbName.Clear();
            }
        }
        private void txbID_Click(object sender, EventArgs e)
        {
            if (this.txbID.Text == "Nhập mã giáo viên")
            {
                this.txbID.Clear();
            }
        }
        private void txbID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txbID.Text == "Nhập mã giáo viên")
            {
                this.txbID.Clear();
            }
            if (e.KeyChar == '\b')
            {
                if (this.txbID.Text.Count() <= 1)
                {
                    this.txbID.Text = "Nhập mã giáo viên";
                }
            }
        }
        private void txbAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txbAddress.Text == "Nhập địa chỉ")
            {
                this.txbAddress.Clear();
            }
            if (e.KeyChar == '\b')
            {
                if (this.txbAddress.Text.Count() <= 1)
                {
                    this.txbAddress.Text = "Nhập địa chỉ";
                }
            }
        }

        private void txbAddress_Click(object sender, EventArgs e)
        {
            if (this.txbAddress.Text == "Nhập địa chỉ")
            {
                this.txbAddress.Clear();
            }
        }

        #endregion

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (this.txbID.Text == "Nhập mật khẩu")
            {
                this.txbID.Clear();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
