using Project_Management.Controllers;
using Project_Management.Models;
using System;
using System.CodeDom;
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
    public partial class frmSearchProject : Form
    {

        public List<string> listYear;
        private List<Subject> listSubject;
        public List<Project> project = new List<Project>();
        public List<Progress> progress = new List<Progress>();
        

        public frmSearchProject()
        {
            InitializeComponent();
            listSubject = SubjectController.GetListSubject();
            foreach (Subject item in listSubject)
            {
                this.cbSubject.Items.Add(item.subject);
            }
        }
        private void frmSearchProject_Load(object sender, EventArgs e)
        {
            
        }

        public void ChangeLanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            InitializeComponent();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                
                    using (var _context = new DBentityProject())
                    {


                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         select t)
                                         .Select(x => new Project()
                                         {
                                             idProject = x.idProject,
                                             name = x.name,
                                             listStudent = x.listStudent,
                                             listInstructor = x.listInstructor,
                                             subject = x.subject,
                                             course = x.course,
                                             dateEnd = x.dateEnd,
                                         }).ToList();
                        if (idProject.Count > 0)
                        {
                            Project listPro = new Project();
                            for (int i = 0; i < idProject.Count; i++)
                            {
                                
                                
                                    if ( idProject[i].dateEnd > DateTime.Now)
                                    {
                                              
                                                listPro = idProject[i];
                                                project.Add(listPro);
                                            
                                        

                                    }
                                    
                                
                            }
                        }
                    else
                    {
                        MessageBox.Show("Không có đề tài phù hợp");
                        return;
                    }

                    if (project.Count > 0)
                        {
                            this.Close();
                            return;
                        }
                        else
                            MessageBox.Show("không có đề tài phù hợp");
                    }
                
            }
            if (checkBox3.Checked == true)
            {
                List<Progress> listProgress;
                Progress pro = new Progress();
                listProgress = ProgressController.getAllProgress();

                using (var _context = new DBentityProject())
                {


                    var idProject = (from t in _context.tbProject.AsEnumerable()
                                     select t)
                                     .Select(x => new Project()
                                     {
                                         idProject = x.idProject,
                                         name = x.name,
                                         listStudent = x.listStudent,
                                         listInstructor = x.listInstructor,
                                         subject = x.subject,
                                         course = x.course,
                                         dateEnd = x.dateEnd,
                                     }).ToList();
                    var idProgress = (from u in _context.tbProgress.AsEnumerable()
                                      where u.finished == true
                                      select u)
                                      .Select(x => new Progress()
                                      {
                                          idProject = x.idProject,
                                          Name = x.Name,
                                          dateStart = x.dateStart,
                                          finishTime = x.finishTime,
                                          submitTime = x.submitTime,
                                          expense = x.expense,
                                          finished = x.finished,
                                      }
                                      ).ToList();

                    if (idProgress.Count > 0)
                    {

                        Progress listPro = new Progress();


                        for (int j = 0; j < idProgress.Count; j++)
                        {



                            listPro = idProgress[j];
                            progress.Add(listPro);



                        }
                    }
                    else
                    {
                        MessageBox.Show("Không có đề tài phù hợp");
                        return;
                    }
                            
                        
                                
                                

                            
                        
                    

                    if (progress.Count > 0)
                    {
                        this.Close();
                        return;
                    }
                    else
                        MessageBox.Show("không có đề tài phù hợp");


                    

                    
                }

            }
            if (checkBox2.Checked == true)
            {
                List<Progress> listProgress;
                Progress pro = new Progress();
                listProgress = ProgressController.getAllProgress();

                using (var _context = new DBentityProject())
                {


                    var idProject = (from t in _context.tbProject.AsEnumerable()
                                     select t)
                                     .Select(x => new Project()
                                     {
                                         idProject = x.idProject,
                                         name = x.name,
                                         listStudent = x.listStudent,
                                         listInstructor = x.listInstructor,
                                         subject = x.subject,
                                         course = x.course,
                                         dateEnd = x.dateEnd,
                                     }).ToList();
                    var idProgress = (from u in _context.tbProgress.AsEnumerable()
                                      where u.finished == false
                                      select u)
                                      .Select(x => new Progress()
                                      {
                                          idProject = x.idProject,
                                          Name = x.Name,
                                          dateStart = x.dateStart,
                                          finishTime = x.finishTime,
                                          submitTime = x.submitTime,
                                          expense = x.expense,
                                          finished = x.finished,
                                      }
                                      ).ToList();

                    if (idProgress.Count > 0)
                    {

                        Progress listPro = new Progress();


                        for (int j = 0; j < idProgress.Count; j++)
                        {



                            listPro = idProgress[j];
                            progress.Add(listPro);



                        }
                    }
                    else
                    {
                        MessageBox.Show("Không có đề tài phù hợp");
                        return;
                    }









                    if (progress.Count > 0)
                    {
                        this.Close();
                        return;
                    }
                    else
                        MessageBox.Show("không có đề tài phù hợp");





                }

            }

            #region tìm kiếm nếu lĩnh vực được nhập 
            if (cbSubject.Text.Length > 0)
            {

                if (cbCourse.Text.Length > 0)
                {
                    using (var _context = new DBentityProject())
                    {

                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         where t.subject == cbSubject.SelectedItem.ToString() && t.course == cbCourse.SelectedItem.ToString()
                                         select t)
                                         .Select(x => new Project()
                                         {
                                             idProject = x.idProject,
                                             name = x.name,
                                             listStudent = x.listStudent,
                                             listInstructor = x.listInstructor,
                                             subject = x.subject,
                                             course = x.course,
                                         }).ToList();
                        if (idProject.Count == 0)
                        {
                            MessageBox.Show("Không có đề tài phù hợp");
                            return;
                        }
                        else
                        {
                            project = idProject;
                        }
                    }
                    if (txbGVHD.Text.Length > 0)
                    {
                        //Th nhập lĩnh vực , khóa , gvhd ,  student
                        if (txbStudentName.Text.Length > 0)
                        {
                            using (var _context = new DBentityProject())
                            {


                                var idProject = (from t in _context.tbProject.AsEnumerable()
                                                 where t.subject == cbSubject.SelectedItem.ToString()
                                                 && t.course == cbCourse.SelectedItem.ToString()
                                                 select t)
                                                 .Select(x => new Project()
                                                 {
                                                     idProject = x.idProject,
                                                     name = x.name,
                                                     listStudent = x.listStudent,
                                                     listInstructor = x.listInstructor,
                                                     subject = x.subject,
                                                     course = x.course,
                                                 }).ToList();
                                if (idProject.Count > 0)
                                {
                                    Project listPro = new Project();
                                    for (int i = 0; i < idProject.Count; i++)
                                    {
                                        string s = "";
                                        foreach (var GV in idProject[i].listInstructor)
                                        {
                                            if (GV.name == txbGVHD.Text)
                                            {
                                                foreach (var std in idProject[i].listStudent)
                                                {
                                                    s = s + std.name + " ";
                                                    if (s.Trim() == txbStudentName.Text.Trim())
                                                    {
                                                        listPro = idProject[i];
                                                        project.Add(listPro);
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                MessageBox.Show("Không có đề tài phù hợp");
                                                return;
                                            }
                                        }
                                    }
                                }

                                if (project.Count > 0)
                                {
                                    this.Close();
                                    return;
                                }
                                else
                                    MessageBox.Show("không có đề tài phù hợp");
                            }
                        }
                        // TH nhập đủ lĩnh vực ,  GVHD , khóa
                        else
                        {
                            using (var _context = new DBentityProject())
                            {


                                var idProject = (from t in _context.tbProject.AsEnumerable()
                                                 where t.subject == cbSubject.SelectedItem.ToString()
                                                 && t.course == cbCourse.SelectedItem.ToString()
                                                 select t)
                                                 .Select(x => new Project()
                                                 {
                                                     idProject = x.idProject,
                                                     name = x.name,
                                                     listStudent = x.listStudent,
                                                     listInstructor = x.listInstructor,
                                                     subject = x.subject,
                                                     course = x.course,
                                                 }).ToList();

                                if (idProject.Count > 0)
                                {
                                    foreach (var item in idProject)
                                    {
                                        foreach (var GV in item.listInstructor)
                                        {
                                            if (GV.name == txbGVHD.Text)
                                                project = idProject;
                                            else
                                                MessageBox.Show("không có đề tài phù hợp");

                                        }
                                    }

                                }
                                this.Close();
                                return;
                            }
                        }
                    }
                    //TH nhập lĩnh vực,  khóa 
                    /*else
                    {
                        using (var _context = new DBentityProject())
                        {


                            var idProject = (from t in _context.tbProject.AsEnumerable()
                                             where t.subject == cbSubject.SelectedItem.ToString()
                                             where t.course == cbCourse.SelectedItem.ToString()
                                             select t)
                                             .Select(x => new Project()
                                             {
                                                 idProject = x.idProject,
                                                 name = x.name,
                                                 listStudent = x.listStudent,
                                                 listInstructor = x.listInstructor,
                                                 subject = x.subject,
                                                 course = x.course,
                                             }).ToList();

                            if (idProject.Count > 0)
                                project = idProject;
                            else
                                MessageBox.Show("Không có đề tài phù hợp");
                        }
                    }*/
                    // TH nhập  lĩnh vực và Khóa 
                    
                }
                // TH nhập lĩnh vực và GVHD
                else if (txbGVHD.Text.Length > 0)
                {
                    using (var _context = new DBentityProject())
                    {

                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         where t.subject == cbSubject.SelectedItem.ToString()
                                         select t)
                                         .Select(x => new Project()
                                         {
                                             idProject = x.idProject,
                                             name = x.name,
                                             listStudent = x.listStudent,
                                             listInstructor = x.listInstructor,
                                             subject = x.subject,
                                             course = x.course,
                                         }).ToList();
                        if (idProject.Count > 0)
                        {
                            foreach (var item in idProject)
                            {
                                foreach (var GV in item.listInstructor)
                                {
                                    if (GV.name == txbGVHD.Text)
                                        project = idProject;
                                    else
                                    {
                                        MessageBox.Show("không có đề tài phù hợp");
                                        return;
                                    }

                                }
                            }
                        }

                    }
                }
               
                //Th nhập lĩnh vực và Student 
                else if(txbStudentName.Text.Length > 0)
                {
                    using (var _context = new DBentityProject())
                    {

                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         where t.subject == cbSubject.SelectedItem.ToString()
                                         select t)
                                         .Select(x => new Project()
                                         {
                                             idProject = x.idProject,
                                             name = x.name,
                                             listStudent = x.listStudent,
                                             listInstructor = x.listInstructor,
                                             subject = x.subject,
                                             course = x.course,
                                         }).ToList();

                        if (idProject.Count < 0)
                        {
                            MessageBox.Show("Không có đề tài phù hợp");
                            return;
                        }

                        Project listPro = new Project();
                        if (idProject.Count > 0)
                        {
                            for (int i = 0; i < idProject.Count; i++)
                            {
                                string s = "";
                                foreach (var std in idProject[i].listStudent)
                                {
                                    s = s + std.name + " ";

                                    if (s.Trim() == txbStudentName.Text.Trim())
                                    {
                                        listPro = idProject[i];
                                        project.Add(listPro);
                                    }
                                }

                            }
                        }
                        try
                        {
                            if (project.Count > 0)
                            {
                                this.Close();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Không có đề tài phù hợp");
                                return;
                            }
                        }
                        catch
                        {
                            return;
                        }
                    }

                
            }

                // Trường hợp chỉ nhập  lĩnh vực
                else
                {
                    using (var _context = new DBentityProject())
                    {

                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         where t.subject == cbSubject.SelectedItem.ToString()
                                         select t)
                                         .Select(x => new Project()
                                         {
                                             idProject = x.idProject,
                                             name = x.name,
                                             listStudent = x.listStudent,
                                             listInstructor = x.listInstructor,
                                             subject = x.subject,
                                             course = x.course,
                                         }).ToList();
                        if (idProject.Count == 0)
                        {
                            MessageBox.Show("Không có đề tài phù hợp");
                            return;
                        }
                        else
                        {
                            project = idProject;
                        }
                    }
                }
                this.Close();
            }

           
            #endregion
            #region tìm kiếm nếu chỉ nhập khóa 
            if (cbCourse.Text.Length > 0)
            {
                if (txbGVHD.Text.Length > 0)
                {
                    // TH nhập khóa student , GVHD 
                    if (txbStudentName.Text.Length > 0)
                    {
                        using (var _context = new DBentityProject())
                        {
                            var idProject = (from t in _context.tbProject.AsEnumerable()
                                             where t.course == cbCourse.SelectedItem.ToString()
                                             select t)
                                             .Select(x => new Project()
                                             {
                                                 idProject = x.idProject,
                                                 name = x.name,
                                                 listStudent = x.listStudent,
                                                 listInstructor = x.listInstructor,
                                                 subject = x.subject,
                                                 course = x.course,
                                             }).ToList();
                            if (idProject.Count > 0)
                            {
                                Project listPro = new Project();
                                for (int i = 0; i < idProject.Count; i++)
                                {
                                    string s = "";
                                    foreach (var GV in idProject[i].listInstructor)
                                    {
                                        if (GV.name == txbGVHD.Text)
                                        {
                                            foreach (var std in idProject[i].listStudent)
                                            {
                                                s = s + std.name + " ";
                                                if (s.Trim() == txbStudentName.Text.Trim())
                                                {
                                                    listPro = idProject[i];
                                                    project.Add(listPro);
                                                }
                                            }

                                        }
                                        else
                                        {
                                            MessageBox.Show("Không có đề tài phù hợp");
                                            return;
                                        }
                                    }
                                }
                            }

                            if (project.Count > 0)
                            {
                                this.Close();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("không có đề tài phù hợp");
                                return;
                            }
                        }
                    }
                    //TH nhập khóa và GVHD 
                    else
                    {
                        using (var _context = new DBentityProject())
                        {

                            var idProject = (from t in _context.tbProject.AsEnumerable()
                                             where t.course == cbCourse.SelectedItem.ToString()
                                             select t)
                                             .Select(x => new Project()
                                             {
                                                 idProject = x.idProject,
                                                 name = x.name,
                                                 listStudent = x.listStudent,
                                                 listInstructor = x.listInstructor,
                                                 subject = x.subject,
                                                 course = x.course,
                                             }).ToList();
                            if (idProject.Count > 0)
                            {
                                foreach (var item in idProject)
                                {
                                    foreach (var GV in item.listInstructor)
                                    {
                                        if (GV.name == txbGVHD.Text)
                                            project = idProject;
                                        else
                                        {
                                            MessageBox.Show("Không có đề tài phù hợp");
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
  
                //TH nhập khóa, Student 
                if (txbStudentName.Text.Length > 0)
                {
                    using (var _context = new DBentityProject())
                    {

                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         where t.course == cbCourse.SelectedItem.ToString()
                                         select t)
                                         .Select(x => new Project()
                                         {
                                             idProject = x.idProject,
                                             name = x.name,
                                             listStudent = x.listStudent,
                                             listInstructor = x.listInstructor,
                                             subject = x.subject,
                                             course = x.course,
                                         }).ToList();

                        if (idProject.Count == 0)
                        {
                            MessageBox.Show("Không có đề tài phù hợp");
                            return;
                        }

                        Project listPro = new Project();
                        if (idProject.Count > 0)
                        {
                            for (int i = 0; i < idProject.Count; i++)
                            {
                                string s = "";
                                foreach (var std in idProject[i].listStudent)
                                {
                                    s = s + std.name + " ";

                                    if (s.Trim() == txbStudentName.Text.Trim())
                                    {
                                        listPro = idProject[i];
                                        project.Add(listPro);
                                    }
                                }

                            }
                        }
                        try
                        {
                            if (project.Count > 0)
                            {
                                this.Close();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Không có đề tài phù hợp");
                                return;
                            }
                        }
                        catch
                        {
                            return;
                        }
                    }
                }
                //TH nhập khóa 
                else
                {
                    using (var _context = new DBentityProject())
                    {

                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         where t.course == cbCourse.SelectedItem.ToString()
                                         select t)
                                         .Select(x => new Project()
                                         {
                                             idProject = x.idProject,
                                             name = x.name,
                                             listStudent = x.listStudent,
                                             listInstructor = x.listInstructor,
                                             subject = x.subject,
                                             course = x.course,
                                         }).ToList();
                        if (idProject.Count == 0)
                        {
                            MessageBox.Show("Không có đề tài phù hợp");
                            return;
                        }
                        else
                        {
                            project = idProject;
                        }
                    }
                }

            }
            #endregion
            #region tìm kiếm nếu  nhập GVHD và SV
            if (txbGVHD.Text.Length > 0)
            {
                //TH nhập GVHD , Sinh Viên
                if (txbStudentName.Text.Length > 0)
                {
                    using (var _context = new DBentityProject())
                    {


                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         select t)
                                         .Select(x => new Project()
                                         {
                                             idProject = x.idProject,
                                             name = x.name,
                                             listStudent = x.listStudent,
                                             listInstructor = x.listInstructor,
                                             subject = x.subject,
                                             course = x.course,
                                         }).ToList();
                        if (idProject.Count > 0)
                        {
                            Project listPro = new Project();
                            for (int i = 0; i < idProject.Count; i++)
                            {
                                string s = "";
                                foreach (var GV in idProject[i].listInstructor)
                                {
                                    if (GV.name == txbGVHD.Text)
                                    {
                                        foreach (var std in idProject[i].listStudent)
                                        {
                                            s = s + std.name + " ";
                                            if (s.Trim() == txbStudentName.Text.Trim())
                                            {
                                                listPro = idProject[i];
                                                project.Add(listPro);
                                            }
                                        }

                                    }
                                }
                            }
                        }

                        if (project.Count > 0)
                        {
                            
                            this.Close();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("không có đề tài phù hợp");
                            return;
                        }

                    }
                }
                //TH nhập GVHD 
                else
                {
                    using (var _context = new DBentityProject())
                    {
                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         select t)
                                         .Select(x => new Project()
                                         {
                                             idProject = x.idProject,
                                             name = x.name,
                                             listStudent = x.listStudent,
                                             listInstructor = x.listInstructor,
                                             subject = x.subject,
                                             course = x.course,
                                         }).ToList();

                        Project listPro = new Project();
                        for (int i = 0; i < idProject.Count; i++)
                        {
                            foreach (var GV in idProject[i].listInstructor)
                            {
                                if (GV.name == txbGVHD.Text)
                                {
                                    listPro = idProject[i];
                                    project.Add(listPro);
                                    break;
                                }
                                
                            }
                        }
                        if(project.Count==0)
                        {
                            MessageBox.Show("không có đề tài phù hợp");
                            return;
                        }

                    }
                }
                
            }
            #endregion

            #region tìm kiếm theo tên Sv
            // TH nhập student
            if (txbStudentName.Text.Length > 0)
            {
                using (var _context = new DBentityProject())
                {

                    var idProject = (from t in _context.tbProject.AsEnumerable()
                                     select t)
                                     .Select(x => new Project()
                                     {
                                         idProject = x.idProject,
                                         name = x.name,
                                         listStudent = x.listStudent,
                                         listInstructor = x.listInstructor,
                                         subject = x.subject,
                                         course = x.course,
                                     }).ToList();

                    if (idProject.Count < 0)
                    {
                        MessageBox.Show("Không có đề tài phù hợp");
                        return;
                    }

                    Project listPro = new Project();
                    if (idProject.Count > 0)
                    {
                        for (int i = 0; i < idProject.Count; i++)
                        {
                            string s = "";
                            foreach (var std in idProject[i].listStudent)
                            {
                                s = s + std.name + " ";

                                if (s.Trim() == txbStudentName.Text.Trim())
                                {
                                    listPro = idProject[i];
                                    project.Add(listPro);
                                }
                            }

                        }
                    }
                    try
                    {
                        if (project.Count > 0)
                        {
                            this.Close();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Không có đề tài phù hợp");
                            return;
                        }
                    }
                    catch
                    {
                        return;
                    }
                }

            }

            

            #endregion
            this.Close();
        }

    
        #region Thiết lập textbox

        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
