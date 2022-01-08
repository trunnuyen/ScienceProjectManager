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
    public partial class frmSettings : Form
    {
        public Color backColor;
        // Dùng để get list value theo khoa
        List<Faculty> faculty;
        List<ErrorProvider> listError = new List<ErrorProvider>();
        List<Subject> subject;
        private bool add;
        private int ID;
        private int index;

        public frmSettings()
        {
            InitializeComponent();
            // bật tắt button
            this.btnAdd.Enabled = false;
            this.btnAddSubject.Enabled = false;
            ID = this.cbSubject.Items.Count + 1;

            faculty = FacultyController.GetAllFaculty();

            if (faculty.Count!= 0)
            {
                foreach (Faculty item in faculty)
                {
                    this.cbFaculty.Items.Add(item.name);
                }
            }

            add = false;


            subject = SubjectController.GetListSubject();
            foreach (Subject item in subject)
            {
                this.cbSubject.Items.Add(item.subject);
                ID++;
            }
            index = 0;

        }
        private void cbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nếu thêm khoa mới
            if (this.cbFaculty.SelectedIndex == 0)
            {
                this.rbMajor.Clear();
                this.btnAdd.Enabled = true;
                return;
            }
            // Hiển thị list ngành tương ứng
            
            this.rbMajor.Text = FacultyController.GetListMajor(this.cbFaculty.SelectedItem.ToString());
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(this.cbFaculty.SelectedIndex!=-1)
            {
                return;
            }
            if(checkError(this.cbFaculty.SelectedIndex) ==true)
            {
                return;
            }
            // lấy danh sách các ngành
            
            this.cbFaculty.Items.Add(this.cbFaculty.Text.Trim());
            Faculty f = new Faculty();
            f.name = this.cbFaculty.Text.Trim();
            f.listMajor = this.rbMajor.Text;

            FacultyController.AddFaculty(f);
            this.btnAdd.Enabled = false;
            
            
        }
        private bool checkError(int index)
        {
            listError.Clear();

            bool error = false;
            if(this.cbFaculty.Text.Trim()=="" || this.cbFaculty.Text.Trim()=="Thêm khoa")
            {
                listError.Add(new ErrorProvider());
                listError[listError.Count - 1].SetError(cbFaculty, "Chưa nhập tên khoa");
                error = true;
            }
            // Tên khoa bị trùng
            int count = this.faculty.Where(x => x.name == this.cbFaculty.Text.Trim()).Count();
            if (count > 0 && index ==-1)
            {
                listError.Add(new ErrorProvider());
                listError[listError.Count - 1].SetError(cbFaculty, "Tên khoa đã tồn tại");
                error = true;
            }

            if (this.rbMajor.Text.Trim()=="")
            {
                listError.Add(new ErrorProvider());
                listError[listError.Count - 1].SetError(this.rbMajor, "Chưa nhập danh sách ngành");
                error = true;
            }
            return error;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           // int X1 = this.faculty.Count;
            // Sai khi combobox được mở

            if (this.cbFaculty.SelectedIndex==0 )
            {
                return;
            }
            if(this.rbMajor.Text.Trim()=="")
            {
                ErrorProvider eRR = new ErrorProvider();
                eRR.SetError(this.rbMajor, "Chưa nhập danh sách ngành");
                return;
            }
            if(checkError(this.cbFaculty.SelectedIndex)==true)
            {
                return;
            }

            // lấy danh sách các ngành
            Faculty f = new Faculty();
            f.name = this.cbFaculty.Text;
            f.listMajor = this.rbMajor.Text.Trim();
            FacultyController.Update(f);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(this.cbFaculty.SelectedIndex==0)
            {
                return;
            }
            DialogResult dlr = MessageBox.Show("Bạn có muốn xóa đối tượng?", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            if(dlr== DialogResult.No)
            {
                return;
            }
            FacultyController.Delete(this.cbFaculty.SelectedItem.ToString());
            
            this.cbFaculty.Items.Remove(this.cbFaculty.SelectedItem);
            this.cbFaculty.SelectedIndex = 0;
            this.rbMajor.Text = "";

        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            if(index!=0)
            {
                return;
            }

            if(SubjectController.CheckSubject(this.cbSubject.Text)==true)
            {
                return;
            }
            if (add == true )
            {
                Subject s = new Subject();
                s.id = ID;
                s.subject = this.cbSubject.Text.Trim();
                SubjectController.AddSubject(s);
                ID++;

                this.cbSubject.Items.Add(this.cbSubject.Text.Trim());
            }
            this.btnAddSubject.Enabled = false;
        }

        private void btnEditSubject_Click(object sender, EventArgs e)
        {
            if (this.cbSubject.SelectedIndex == 0)
            {
                return;
            }
            Subject s = new Subject();
            s.id = index;
            s.subject = this.cbSubject.Text.Trim();
            SubjectController.Update(s);
            this.cbSubject.Items[index] = this.cbSubject.Text.Trim();
        }

        private void btnDelSubject_Click(object sender, EventArgs e)
        {
            if (this.cbSubject.SelectedIndex == 0 || this.cbSubject.SelectedIndex==-1)
            {
                return;
            }
            Subject s = new Subject();
            s.id = this.cbSubject.SelectedIndex;
            s.subject = this.cbSubject.Text.Trim();
            SubjectController.Delete(s);

            this.cbSubject.Items.Remove(this.cbSubject.Text.Trim());
        }

        private void cbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.cbSubject.SelectedIndex==0)
            {
                add = true;
                index = 0;
                this.btnAddSubject.Enabled = true;
            }
            else
            {
                add = false;
                index = this.cbSubject.SelectedIndex;
            }
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {

        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }
    }
}
