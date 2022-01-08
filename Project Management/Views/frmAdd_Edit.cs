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
    public partial class frmAdd_Edit : Form
    {
        
        public Student student;
        private List<ErrorProvider> listError = new List<ErrorProvider>();  // dùng toàn cục ??
        public bool edit = false;
        string sMSSV = "";
        List<Faculty> faculty;

        public frmAdd_Edit()
        {
            
            student = new Student();
            InitializeComponent();
            this.lblName.Text = "THÊM SINH VIÊN";
        }
        public frmAdd_Edit( ref Student St)
        {
            student = St;
            InitializeComponent();

            edit = true;
            sMSSV = St.MSSV;
            this.lblName.Text = "CHỈNH SỬA SINH VIÊN";
        }

        private void frmQuanLySinhVien_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 11; i++)
            {
                listError.Add(new ErrorProvider());
            }

            faculty = FacultyController.GetAllFaculty();
            foreach (Faculty item in faculty)
            {
                this.cbFaculty.Items.Add(item.name);
                string[] str = item.listMajor.Split('\n');
                foreach (string major in str)
                {
                    this.cbMajor.Items.Add(major);
                }
            }
            if(edit == true)    // chế độ chỉnh sửa
            {
                this.btnAdd.Text = "Lưu";
                this.txbName.Text = student.name.ToString();
                this.txbMSSV.Text = student.MSSV.ToString();
                this.txbAddress.Text = student.address.ToString();
                this.dpBirthday.Value = DateTime.Parse(student.birthday.ToString());
                this.cbFaculty.Text = student.faculty;
                this.cbMajor.Text = student.major.ToString();
                this.txbClass.Text = student.Class.ToString();
                this.cbGender.Text = student.gender.ToString();
                this.cbCourse.Text = student.course.ToString();
                this.txbPhone.Text = student.numberPhone.ToString();
                
                this.textBox1.Text = student.password.ToString();
                    
                
                
            }
            else
            {
                //chế độ add
                // Thiết lập text hướng dẫn cho các combobox
                this.cbFaculty.SelectedIndex = 0;
                this.cbMajor.SelectedIndex = 0;
                this.cbCourse.SelectedIndex = 0;
                this.cbGender.SelectedIndex = 0;
            }

        }
        public void ChangeLanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkError() == true)
            {
                return;
            }
            student.name = this.txbName.Text.Trim();
            student.MSSV = this.txbMSSV.Text.Trim();
            student.Class = this.txbClass.Text.Trim();
            student.course = this.cbCourse.Text.Trim();
            student.birthday = this.dpBirthday.Value;
            student.gender = this.cbGender.Text.Trim();
            student.address = this.txbAddress.Text.Trim();
            student.numberPhone = this.txbPhone.Text.Trim();
            student.major = this.cbMajor.Text.Trim();
            student.faculty = this.cbFaculty.Text.Trim();
            student.password = this.textBox1.Text.Trim();
            student.access = "Student";

            this.Close();

        }
        private bool checkError()
        {
            bool error = false;
            if (this.txbMSSV.Text.Trim().Length <= 0 || this.txbMSSV.Text == "Nhập mã số sinh viên")
            {
                this.listError[0].SetError(this.txbMSSV, "Chưa nhập dữ liệu");
                this.txbMSSV.Text = "Nhập mã số sinh viên";
                error = true;
            }
            // Nếu trùng MSSV 
          
            if (StudentController.CheckMSSV(sMSSV,this.txbMSSV.Text.Trim(), this.txbName.Text.Trim(),edit)==true)
            {
                this.listError[0].SetError(this.txbMSSV, "MSSV đã tồn tại");
                error = true;
            }
            
            int year = DateTime.Now.Year - this.dpBirthday.Value.Year;
            if (year < 18)
            {
                this.listError[1].SetError(this.dpBirthday, "Dữ liệu không hợp lệ");
                error = true;
            }
            if (this.txbName.Text.Trim().Length <= 0 || this.txbName.Text == "Nhập họ tên sinh viên")
            {
                this.listError[2].SetError(this.txbName, "Dữ liệu không hợp lệ");
                this.txbName.Text = "Nhập họ tên sinh viên";
                error = true;
            }
            if (this.txbAddress.Text.Trim().Length <= 0 || this.txbAddress.Text == "Nhập địa chỉ")
            {
                this.listError[3].SetError(this.txbAddress, "Dữ liệu không hợp lệ");
                this.txbAddress.Text = "Nhập địa chỉ";
                error = true;
            }
            if (this.cbCourse.Text == "Chọn khóa")
            {
                this.listError[4].SetError(this.cbCourse, "Chưa chọn khóa");
               // this.cbCourse.Text = "Chọn khóa";
                error = true;
            }
            if (this.cbFaculty.Text == "Chọn khoa")
            {
                this.listError[5].SetError(this.cbFaculty, "Chưa chọn khoa");
                //this.cbFaculty.Text = "Chọn khoa";
                error = true;
            }
            if (this.cbGender.Text == "Chọn giới tính")
            {
                this.listError[6].SetError(this.cbGender, "Chưa chọn giới tính");
                error = true;
            }
            if (this.txbClass.Text.Trim().Length <= 0 || this.txbClass.Text == "Nhập lớp")
            {
                this.listError[7].SetError(this.txbClass, "Chưa nhập dữ liệu");
                this.txbClass.Text = "Nhập lớp";
                error = true;
            }
            if (this.cbMajor.Text == "Chọn ngành" || this.cbMajor.Text=="")
            {
                this.listError[8].SetError(this.cbMajor, "Chưa chọn ngành");
                error = true;
            }
            
            if(this.txbPhone.Text.Trim()=="" || this.txbPhone.Text== "Nhập số điện thoại")
            {
                this.listError[9].SetError(this.txbPhone, "Nhập số điện thoại");
                error = true;
            }
            return error;
        }
        private void btnCanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Thiết lập text hướng dẫn khi Click

        private void txbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txbName.Text == "Nhập họ tên sinh viên")
            {
                this.txbName.Clear();
            }
            if (e.KeyChar == '\b')
            {
                if (this.txbName.Text.Count() <= 1)
                {
                    this.txbName.Text = "Nhập họ tên sinh viên";
                }
            }
        }
        private void txbName_Click(object sender, EventArgs e)
        {
            if(this.txbName.Text== "Nhập họ tên sinh viên")
            {
                this.txbName.Text = "";
            }
        }
        
        private void txbMSSV_Click(object sender, EventArgs e)
        {
            if(this.txbMSSV.Text== "Nhập mã số sinh viên")
            {
                this.txbMSSV.Clear();
            }
        }
        private void txbMSSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txbMSSV.Text == "Nhập mã số sinh viên")
            {
                this.txbMSSV.Clear();
            }
            if (e.KeyChar == '\b')
            {
                if (this.txbMSSV.Text.Count() <= 1)
                {
                    this.txbMSSV.Text = "Nhập mã số sinh viên";
                }
            }
        }
        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txbClass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbClass_Click(object sender, EventArgs e)
        {
            if(this.txbClass.Text== "Nhập lớp")
            {
                this.txbClass.Clear();
            }
        }
        private void txbClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txbClass.Text == "Nhập lớp")
            {
                this.txbClass.Clear();
            }
            if (e.KeyChar == '\b')
            {
                if (this.txbClass.Text.Count() <= 1)
                {
                    this.txbClass.Text = "Nhập lớp";
                }
            }
        }

        private void txtAddress_Click(object sender, EventArgs e)
        {
            if(this.txbAddress.Text== "Nhập địa chỉ")
            {
                this.txbAddress.Clear();
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
        private void txbPhone_Click(object sender, EventArgs e)
        {
            if (this.txbPhone.Text == "Nhập số điện thoại")
            {
                this.txbPhone.Clear();
            }
        }

        private void txbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar!= '\b')
            {
                e.Handled = !char.IsNumber(e.KeyChar);
            }
            if (this.txbPhone.Text == "Nhập số điện thoại")
            {
                this.txbPhone.Clear();
            }
            if (e.KeyChar == '\b')
            {
                if (this.txbPhone.Text.Count() <= 1)
                {
                    this.txbPhone.Text = "Nhập số điện thoại";
                }
            }
        }
        private void cbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbMajor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbMajor.Items.Clear();
            this.cbMajor.Items.Add("Chọn ngành");

            try
            {
                string faculty = this.cbFaculty.SelectedItem.ToString();
                if (faculty != "Chọn khoa")
                {
                    string[] str = FacultyController.GetListMajor(faculty).Split('\n');
                    foreach (string item in str)
                    {
                        this.cbMajor.Items.Add(item);
                    }
                }
                else
                {
                    foreach (Faculty item in FacultyController.GetAllFaculty())
                    {
                        string[] str = item.listMajor.Split('\n');

                        foreach (string major in str)
                        {
                            this.cbMajor.Items.Add(major);
                        }
                    }
                }
            }
            catch
            {

            }
        }






        #endregion

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
