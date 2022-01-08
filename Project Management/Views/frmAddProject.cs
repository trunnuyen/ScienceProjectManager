using Project_Management.Controllers;
using Project_Management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Management
{
    public partial class frmAddProject : Form
    {
        public Project project;
        private Dictionary<string, string> dicStudent;    // key: MSSV, value: name
        private Dictionary<string, string> dicInstructor;   // key: MGV , value: name
        List<ErrorProvider> listError;
        public bool edit = false;
        string sID = "";

        public frmAddProject()
        {
            InitializeComponent();
            project = new Project();

        }

        public frmAddProject(ref Project proj)
        {
            // Chức năng sửa
            InitializeComponent();
            project = proj;
            sID = project.idProject;
            edit = true;

        }
        private void frmAddProject_Load(object sender, EventArgs e)
        {
            this.cbCourse.SelectedIndex = 0;
            this.cbSubject.SelectedIndex = 0;
            List<Subject> sub = SubjectController.GetListSubject();
            foreach (Subject item in sub)
            {
                this.cbSubject.Items.Add(item.subject);
            }

            // Dùng dictionary để hiển thị
            dicStudent = new Dictionary<string, string>();
            dicInstructor = new Dictionary<string, string>();

            listError = new List<ErrorProvider>();
            for (int i = 0; i < 8; i++)
            {
                ErrorProvider err = new ErrorProvider();
                listError.Add(err);
            }

            // chế độ add
            if (project.idProject==null)
            {
                this.listboxResultStudent.Visible = false;
                this.listboxStudent.Visible = false;
                this.listboxInstructor.Visible = false;
                this.listboxResultInstructor.Visible = false;
            }
            else
            {
                this.btnAdd.Text = "Lưu";
                this.lblName.Text = "CHỈNH SỬA ĐỀ TÀI";

                this.listboxStudent.Visible = false;
                this.listboxInstructor.Visible = false;

                this.txbID.Text = project.idProject;
                this.txbProjectName.Text = project.name;

                foreach (Student item in project.listStudent)
                {
                    this.listboxResultStudent.Items.Add(item.name);
                    dicStudent.Add(item.MSSV, item.name);
                }
                foreach (Instructor item in project.listInstructor)
                {
                    this.listboxResultInstructor.Items.Add(item.name);
                    dicInstructor.Add(item.id, item.name);
                }

                this.cbSubject.Text = project.subject;
                this.cbCourse.Text = project.course;

               
            }
        }
        private bool checkError()
        {
            bool add = true;

            //Note : lỗi trùng ID , dùng database 

            if (this.txbProjectName.Text.Trim() == "" || this.txbProjectName.Text == "Nhập tên đề tài")
            {
                listError[0].SetError(this.txbProjectName, " Phải nhập nội dung ");
                add = false;
            }

            // kiểm tra listStudent
            if (this.listboxResultStudent.Items.Count == 0)
            {
                listError[1].SetError(this.txbStudents, "Chưa nhập danh sách sinh viên ");
                add = false;
            }

            // kiểm tra listInstructor
            if (this.listboxResultInstructor.Items.Count == 0)
            {
                listError[2].SetError(this.txbInstructors, " Chưa nhập danh sách GVHD ");
                add = false;
            }

            if (this.cbSubject.Text == "Chọn môn")
            {
                listError[3].SetError(this.cbSubject, " Phải chọn nội dung ");
                add = false;
            }
            if (this.txbID.Text.Trim() == "" || this.txbID.Text == "Nhập mã đề tài")
            {
                listError[4].SetError(this.txbID, "Phải nhập nội dung");
                add = false;
            }

            // Thiếu error cho MGV
            if (this.txbID.Text.Trim() == "" || this.txbID.Text == "Nhập mã đề tài")
            {
                this.listError[5].SetError(this.txbID, "Chưa nhập mã đề tài");
                add = false;
            }

            else if (ProjectController.CheckID(sID, this.txbID.Text, edit) == true)
            {
                this.listError[5].SetError(this.txbID, "Mã đề tài đã tồn tại");
                add = false;
            }
            if(this.cbCourse.SelectedIndex==0)
            {
                this.listError[6].SetError(this.txbID, "Chưa chọn niên khóa");
                add = false;
            }
            return add;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Có error thì return
            if (checkError() == false)
            {
                return;
            }

            project.idProject = this.txbID.Text.Trim();
            project.name = this.txbProjectName.Text.Trim();

            // get list Student trong database bằng listbox
            for (int i = 0; i < this.listboxResultStudent.Items.Count; i++)
            {
                // find Stundent in database
                List<string> MSSV = new List<string>();

                foreach(KeyValuePair<string, string> item in dicStudent)
                {
                    MSSV.Add(item.Key);
                }
                project.listStudent = ProjectController.GetListStudent(MSSV);
            }

            project.expense = 0;

            // get list Instructor trong database bằng listbox
            for (int i=0;i<this.listboxInstructor.Items.Count;i++)
            {
                List<string> MGV = new List<string>();
                foreach (KeyValuePair<string, string> item in dicInstructor)
                {
                    MGV.Add(item.Key);
                }
                project.listInstructor = ProjectController.GetListInstructor(MGV);
            }
            project.expense = 0;
            project.subject = this.cbSubject.Text;
            project.course = this.cbCourse.Text;
            project.dateStart = DateTime.Now.AddDays(1);
            project.dateEnd = DateTime.Now.AddDays(1);
            project.type = this.textBox1.Text.Trim();
            project.rank = this.textBox2.Text.Trim();
            project.host = this.textBox3.Text.Trim();

            // get list instructor in database 
            for (int i = 0; i < this.listboxResultInstructor.Items.Count; i++)
            {
                // find instructor in database
            }
           
            this.Close();

        }
        public void ChangeLanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            InitializeComponent();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        #region Thiết lập textbox với các text hướng dẫn
        private void txbProjectName_Click(object sender, EventArgs e)
        {
            if (this.txbProjectName.Text == "Nhập tên đề tài")
            {
                this.txbProjectName.Clear();
                this.txbProjectName.ForeColor = Color.Black;
            }
        }
        private void txbProjectName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txbProjectName.Text == "Nhập tên đề tài")
            {
                this.txbProjectName.Clear();
                this.txbProjectName.ForeColor = Color.Black;
            }

            if (e.KeyChar == '\b')
            {
                if (this.txbProjectName.Text.Count() <= 1)
                {
                    this.txbProjectName.Text = "Nhập tên đề tài";
                }
            }
        }
        
        
        private void txbStudents_Click(object sender, EventArgs e)
        {
            if (this.txbStudents.Text == "Nhập mã số sinh viên")
            {
                this.txbStudents.Clear();
            }
        }
        private void txbStudents_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (this.txbStudents.Text == "Nhập mã số sinh viên")
            {
                this.txbStudents.Clear();
            }
            if (e.KeyChar == '\b' && this.txbStudents.Text.Count() < 1)
            {
                this.txbStudents.Text = "Nhập mã số sinh viên";
            }

            this.listboxStudent.Items.Clear();
            string key = this.txbStudents.Text;
            if (e.KeyChar != '\b')
            {
                key = this.txbStudents.Text + e.KeyChar;
            }
        
            List<Student> std = StudentController.Search(key);
            if (std.Count != 0)
            {
                string s = "";
                this.listboxStudent.Visible = true;
                foreach (Student item in std)
                {
                    s = item.MSSV + " -" + item.name;
                    this.listboxStudent.Items.Add(s);
                    s = "";
                }
            }


        }
        private void txbInstructors_Click(object sender, EventArgs e)
        {
            if (this.txbInstructors.Text == "Nhập mã giáo viên")
            {
                this.txbInstructors.Clear();
               
            }
        }
        private void txbInstructors_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txbInstructors.Text == "Nhập mã giáo viên")
            {
                this.txbInstructors.Clear();
            }
            if (e.KeyChar == '\b' && this.txbInstructors.Text.Count() <= 1)
            {
                this.txbInstructors.Text = "Nhập mã giáo viên";
            }
            
            this.listboxInstructor.Items.Clear();
            string key = this.txbInstructors.Text;
            if(e.KeyChar!='\b')
            {
                key = this.txbInstructors.Text + e.KeyChar;
            }
            List<Instructor> gv = GVController.Search(key);
            if (gv.Count != 0)
            {
                string temp = "";
                this.listboxInstructor.Visible = true;
                foreach (Instructor item in gv)
                {
                    temp = item.id + " -" + item.name;
                    this.listboxInstructor.Items.Add(temp);
                    temp = "";
                }
            }

        }

        private void txbID_Click(object sender, EventArgs e)
        {
            if (this.txbID.Text == "Nhập mã đề tài")
            {
                this.txbID.Clear();
                this.txbID.ForeColor = Color.Black;
            }

        }
        private void txbID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txbID.Text == "Nhập mã đề tài")
            {
                this.txbID.Clear();
                this.txbID.ForeColor = Color.Black;
            }
            
            if (e.KeyChar == '\b')
            {
                if (this.txbID.Text.Count() <= 1)
                {
                    this.txbID.Text = "Nhập mã đề tài";
                }
            }
        }

        #endregion


        #region Tìm kiếm và add student, instructor
        private void txbStudents_TextChanged(object sender, EventArgs e)
        {
            
            
        }
        private void listboxStudent_Click(object sender, EventArgs e)
        {
            // Thêm student vào danh sách chọn (listbox Result)

            if (this.listboxStudent.SelectedItem == null)
            {
                return;
            }
            // nếu đã được add rồi thì không add nữa
            string[] str = this.listboxStudent.SelectedItem.ToString().Split('-');
            for (int i = 0; i < this.listboxResultStudent.Items.Count; i++)
            {
                // có exception
                if (this.listboxResultStudent.Items[i].ToString() == str[1].Trim())
                {
                    return;
                }
            }
            // Tìm lại Student 
            this.listboxResultStudent.Visible = true;
            
            dicStudent.Add(str[0], str[1]);
            this.listboxResultStudent.Items.Add(str[1]);
            this.listboxStudent.Visible = false;
        }
        private void listboxResultStudent_DoubleClick(object sender, EventArgs e)
        {
            // Xóa student khỏi danh sách chọn
            // Khi xóa 1 item, txb sẽ =""
            if(this.listboxResultStudent.SelectedIndices.Count<=0)
            {
                return;
            }
            for (int i = 0; i < dicStudent.Count; i++)
            {
                // có exception
                if (dicStudent[dicStudent.Keys.ElementAt(i)] == this.listboxResultStudent.SelectedItem.ToString())
                {
                    dicStudent.Remove(dicStudent.Keys.ElementAt(i));
                    break;
                }
            }
           
            this.listboxResultStudent.Items.RemoveAt(this.listboxResultStudent.SelectedIndex);
            this.txbStudents.Text = "";
        }

        private void listboxResultStudent_Click(object sender, EventArgs e)
        {
            // Khi click vào listbox Result thì listbox Student ẩn đi để dễ xem
            this.listboxStudent.Visible = false;
        }
        private void listboxResultStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hiển thị lại MSSV tương ứng với selected index
            try
            {
                this.txbStudents.Text = dicStudent.ElementAt(this.listboxResultStudent.SelectedIndex).Key.ToString();
            }
            catch
            {
                this.txbStudents.Text = "";
            }
        }
        private void txbInstructors_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        private void listboxInstructor_Click(object sender, EventArgs e)
        {
            // Thêm instructor vào danh sách chọn (listbox Result)
            if (this.listboxInstructor.SelectedItem == null)
            {
                return;
            }
            // nếu đã được add rồi thì không add nữa
            string[] str = this.listboxInstructor.SelectedItem.ToString().Split('-');
            for (int i = 0; i < this.listboxResultInstructor.Items.Count; i++)
            {
                // có exception
                if (this.listboxResultInstructor.Items[i].ToString() == str[1].ToString())
                {
                    return;
                }
            }
            this.listboxResultInstructor.Visible = true;

            
            dicInstructor.Add(str[0], str[1]);
            this.listboxResultInstructor.Items.Add(str[1]);
            this.listboxInstructor.Visible = false;
        }

        private void listboxResultInstructor_Click(object sender, EventArgs e)
        {
            // Khi listbox Result được chọn thì listbox Instructor ẩn đi để dễ xem
            this.listboxInstructor.Visible = false;
            
            if(this.listboxResultInstructor.SelectedIndex==-1)
            {
                return;
            }
            for (int i = 0; i < dicInstructor.Count; i++)
            {
                if (dicInstructor[dicInstructor.Keys.ElementAt(i)] == this.listboxResultInstructor.SelectedItem.ToString())
                {
                    this.txbInstructors.Text = dicInstructor.Keys.ElementAt(i).ToString();
                    break;
                }
            }
        }

        private void listboxResultInstructor_DoubleClick(object sender, EventArgs e)
        {
            // Xóa instructor ra khỏi danh sách chọn
            if(this.listboxResultInstructor.SelectedIndices.Count<=0)
            {
                return;
            }
            dicInstructor.Remove(this.listboxResultInstructor.SelectedItem.ToString());
            this.listboxResultInstructor.Items.Remove(this.listboxResultInstructor.SelectedItem);
        }
        private void listboxResultInstructor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dicInstructor.Count; i++)
                {
                    if (dicInstructor[dicInstructor.Keys.ElementAt(i)] == this.listboxResultInstructor.SelectedItem.ToString())
                    {
                        this.txbInstructors.Text = dicInstructor.Keys.ElementAt(i).ToString();
                        break;
                    }
                }
            }
            catch
            {
                this.txbInstructors.Text = "";
            }
        }
        #endregion
        private void cbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmAddProject_MdiChildActivate(object sender, EventArgs e)
        {

        }

        private void txbInstructors_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void txbStudents_TextChanged_1(object sender, EventArgs e)
        {
            
        }
    }
}
