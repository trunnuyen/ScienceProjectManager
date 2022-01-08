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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Management.Views
{
    public partial class frmSearchProject : Form
    {

        public List<string> listYear;
        private List<Subject> listSubject;
        public List<Project> project = new List<Project>();

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
            List<Subject> listSubject = SubjectController.GetListSubject();
            foreach (Subject item in listSubject)
            {
                this.cbCourse.Items.Add(item.subject);
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            #region tìm kiếm nếu tên Đề Án được nhập
            if (txbProjectName.Text.Length > 0)
            {
                if (cbSubject.Text.Length > 0)
                {
                    if (cbCourse.Text.Length > 0)
                    {
                        if (dtpSearchStart.Value.ToShortDateString().Length > 0 && dtpSearchEnd.Value.ToShortDateString().Length > 0)
                        {

                            if (txbGVHD.Text.Length > 0)
                            {
                                //TH nhập đủ tất cả
                                if (txbStudentName.Text.Length > 0)
                                {
                                    using (var _context = new DBentityProject())
                                    {


                                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                                         where t.name == txbProjectName.Text
                                                         where t.subject == cbSubject.Text
                                                         where t.course == cbCourse.Text
                                                         where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                                         where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                                                        MessageBox.Show("Không có đồ án phù hợp");
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
                                            MessageBox.Show("không có đồ án phù hợp");
                                    }
                                }
                                // TH nhập Name , Khóa , MÔn ,Ngày , GVHD
                                else
                                {
                                    using (var _context = new DBentityProject())
                                    {


                                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                                         where t.name == txbProjectName.Text
                                                         where t.subject == cbSubject.Text
                                                         where t.course == cbCourse.Text
                                                         where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                                         where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                                    }
                                }    
                            }
             
                            // TH nhập đủ Name , Khóa , Môn, Ngày
                            else
                            {
                                //TH nhập Name Khóa Môn Ngày Student
                                if (txbStudentName.Text.Length > 0)
                                {
                                    using (var _context = new DBentityProject())
                                    {


                                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                                         where t.name == txbProjectName.Text
                                                         where t.subject == cbSubject.Text
                                                         where t.course == cbCourse.Text
                                                         where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                                         where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                                                this.Close();
                                            }
                                        }
                                        catch
                                        {
                                            
                                            return;
                                        }
                                    }

                                }
                                else
                                {
                                    using (var _context = new DBentityProject())
                                    {


                                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                                         where t.name == txbProjectName.Text
                                                         where t.subject == cbSubject.Text
                                                         where t.course == cbCourse.Text
                                                         where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                                         where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                                            MessageBox.Show("Không có đồ án phù hợp");
                                    }
                                }
                            }
                        }
                        // TH nhập đủ Name , Khóa ,Môn
                        else
                        {
                          
                            using (var _context = new DBentityProject())
                            {
                                var idProject = (from t in _context.tbProject.AsEnumerable()
                                                 where t.name == txbProjectName.Text
                                                 where t.subject == cbSubject.Text
                                                 where t.course == cbCourse.Text
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
                                    MessageBox.Show("Không có đề tài phù hợp");
                                else
                                {
                                    project = idProject;
                                }
                            }
                        }
                    }
                    // TH nhập đủ Name , Môn
                    else
                    {
                        using (var _context = new DBentityProject())
                        {

                            var idProject = (from t in _context.tbProject.AsEnumerable()
                                             where t.name == txbProjectName.Text
                                             where t.subject == cbSubject.Text
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
                                MessageBox.Show("Không có đề tài phù hợp");
                            else
                            {
                                project = idProject;
                            }
                        }
                    }

                }
                // TH nhập Project Name và Khóa
                else if (cbCourse.Text.Length > 0)
                {
                    using (var _context = new DBentityProject())
                    {

                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         where t.name == txbProjectName.Text
                                         where t.course == cbCourse.Text
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
                            MessageBox.Show("Không có đề tài phù hợp");
                        else
                        {
                            project = idProject;
                        }
                    }
                }
                //TH nhập projectName và GVHD
                else if (txbGVHD.Text.Length > 0)
                {
                    using (var _context = new DBentityProject())
                    {

                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         where t.name == txbProjectName.Text
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
                                        MessageBox.Show("Không có đồ án phù hợp");
                                }
                            }
                        }



                    }
                }
                //TH nhập Project name và Student
                else if (txbStudentName.Text.Length > 0)
                {
                    using (var _context = new DBentityProject())
                    {
                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         where t.name == txbProjectName.Text
                                         where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                         where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                            MessageBox.Show("Không có đồ án phù hợp");
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
                            this.Close();
                            MessageBox.Show("Không có đề tài phù hợp");
                        }
                    }
                    catch
                    {
                        return;
                    }

                }
                //TH nhập Project name và date start
                else if (dtpSearchStart.Value.ToShortDateString().Length > 0 && dtpSearchEnd.Value.ToString().Length > 0
                  )
                {
                    using (var _context = new DBentityProject())
                    {

                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         where t.name == txbProjectName.Text
                                         where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                         where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                            MessageBox.Show("Không có đề tài phù hợp");
                        else
                        {
                            project = idProject;
                        }
                    }
                }
              
                // Trường hợp chỉ nhập Project Name , ngày              

                this.Close();
                return;
            }




            #endregion
            #region tìm kiếm nếu tên môn được nhập 
            if (cbSubject.Text.Length > 0)
            {

                if (cbCourse.Text.Length > 0)
                {
                    if (dtpSearchStart.Value.ToShortDateString().Length > 0 && dtpSearchEnd.Value.ToString().Length > 0)
                    {
                        
                        if (txbGVHD.Text.Length > 0)
                        {
                            //Th nhập môn , khóa , gvhd , ngày  , student
                            if (txbStudentName.Text.Length > 0)
                            {
                                using (var _context = new DBentityProject())
                                {


                                    var idProject = (from t in _context.tbProject.AsEnumerable()                          
                                                     where t.subject == cbSubject.Text
                                                     where t.course == cbCourse.Text
                                                     where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                                     where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                                                    MessageBox.Show("Không có đồ án phù hợp");
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
                                        MessageBox.Show("không có đồ án phù hợp");
                                }
                            }
                            // TH nhập đủ môn , ngày , GVHD , khóa
                            else
                            {
                                using (var _context = new DBentityProject())
                                {


                                    var idProject = (from t in _context.tbProject.AsEnumerable()
                                                     where t.subject == cbSubject.Text
                                                     where t.course == cbCourse.Text
                                                     where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                                     where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                        //TH nhập môn, ngày , khóa 
                        else
                        {
                            using (var _context = new DBentityProject())
                            {


                                var idProject = (from t in _context.tbProject.AsEnumerable()
                                                 where t.subject == cbSubject.Text
                                                 where t.course == cbCourse.Text
                                                 where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                                 where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                                    MessageBox.Show("Không có đồ án phù hợp");
                            }
                        }
                    }
                    // TH nhập môn , khóa , GVHD, ngày
                    else if (txbGVHD.Text.Length > 0)
                    {
                        using (var _context = new DBentityProject())
                        {


                            var idProject = (from t in _context.tbProject.AsEnumerable()
                                             where t.subject == cbSubject.Text
                                             where t.course == cbCourse.Text
                                             where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                             where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                                MessageBox.Show("Không có đồ án phù hợp");
                        }
                    }
                    // TH nhập  môn và Khóa , ngày 
                    else
                    {
                        using (var _context = new DBentityProject())
                        {

                            var idProject = (from t in _context.tbProject.AsEnumerable()
                                             where t.subject == cbSubject.Text
                                             where t.course == cbCourse.Text
                                             where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                             where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                                MessageBox.Show("Không có đề tài phù hợp");
                            else
                            {
                                project = idProject;
                            }
                        }
                    }
                }
                // TH nhập môn và GVHD , ngày
                else if (txbGVHD.Text.Length > 0)
                {
                    using (var _context = new DBentityProject())
                    {

                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         where t.subject == cbSubject.Text
                                         where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                         where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                                        MessageBox.Show("không có đồ án phù hợp");

                                }
                            }
                        }

                    }
                }
               
                //Th nhập môn và Student và ngày
                else if(txbStudentName.Text.Length > 0)
                {
                    using (var _context = new DBentityProject())
                    {

                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         where t.subject == cbSubject.Text
                                         where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                         where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()

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
                            MessageBox.Show("Không có đồ án phù hợp");
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
                                this.Close();
                            }
                        }
                        catch
                        {
                            return;
                        }
                    }

                
            }

                // Trường hợp chỉ nhập  môn, ngày
                else
                {
                    using (var _context = new DBentityProject())
                    {

                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         where t.subject == cbSubject.Text
                                         where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                         where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                            MessageBox.Show("Không có đề tài phù hợp");
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
                if (dtpSearchStart.Value.ToShortDateString().Length > 0 && dtpSearchEnd.Value.ToString().Length > 0)
                {
                   
                    if (txbGVHD.Text.Length > 0)
                    {
                        // TH nhập khóa student , GVHD , ngày
                        if (txbStudentName.Text.Length > 0)
                        {
                            using (var _context = new DBentityProject())
                            {
                                var idProject = (from t in _context.tbProject.AsEnumerable()
                                                 where t.course == cbCourse.Text
                                                 where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                                 where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                                                MessageBox.Show("Không có đồ án phù hợp");
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
                                    MessageBox.Show("không có đồ án phù hợp");
                            }
                        }
                        //TH nhập khóa và GVHD , ngày
                        else
                        {
                            using (var _context = new DBentityProject())
                            {

                                var idProject = (from t in _context.tbProject.AsEnumerable()
                                                 where t.course == cbCourse.Text
                                                 where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                                 where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                                            MessageBox.Show("Không có đồ án phù hợp");
                                        }
                                    }
                                }
                            }
                        }
                    }
                  
                }
                // TH nhập GVHD , khóa , ngày
                else if (txbGVHD.Text.Length > 0)
                {
                    using (var _context = new DBentityProject())
                    {

                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         where t.course == cbCourse.Text
                                         where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                         where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                                    MessageBox.Show("Không có đồ án phù hợp");
                                }
                            }
                        }
                    }
                }
                //TH nhập khóa, Student , ngày
                if (txbStudentName.Text.Length > 0)
                {
                    using (var _context = new DBentityProject())
                    {

                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         where t.course == cbCourse.Text
                                         where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                         where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                            MessageBox.Show("Không có đồ án phù hợp");
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
                                this.Close();
                            }
                        }
                        catch
                        {
                            return;
                        }
                    }
                }
                //TH nhập khóa , ngày
                else
                {
                    using (var _context = new DBentityProject())
                    {

                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         where t.course == cbCourse.Text
                                         where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                         where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                            MessageBox.Show("Không có đề tài phù hợp");
                        else
                        {
                            project = idProject;
                        }
                    }
                }

            }
            #endregion
            #region tìm kiếm nếu chỉ nhập GVHD
            if (txbGVHD.Text.Length > 0)
            {                
                if (dtpSearchStart.Value.ToString().Length > 0 && dtpSearchEnd.Value.ToString().Length > 0)
                {
                    //TH nhập GVHD , Ngày , Sinh Viên
                    if (txbStudentName.Text.Length > 0)
                    {
                        using (var _context = new DBentityProject())
                        {


                            var idProject = (from t in _context.tbProject.AsEnumerable()
                                             where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                             where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                                            MessageBox.Show("Không có đồ án phù hợp");
                                            return;
                                        }
                                    }
                                }
                            }

                            if (project.Count > 0)
                                return;
                            else
                                MessageBox.Show("không có đồ án phù hợp");

                        }
                    }
                    //TH nhập GVHD và Ngày
                    else
                    {
                        using (var _context = new DBentityProject())
                        {


                            var idProject = (from t in _context.tbProject.AsEnumerable()
                                             where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                             where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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

                            for (int i = 0; i < idProject.Count; i++)
                            {
                                foreach (var GV in idProject[i].listInstructor)
                                {
                                    if (GV.name == txbGVHD.Text)
                                        project = idProject;
                                    else
                                        MessageBox.Show("không có đề tài phù hợp");
                                }
                            }
                        
                        }
                    }
                }
                // TH chỉ nhập tên GV,ngày
                else
                {
                    using (var _context = new DBentityProject())
                    {


                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                         where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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

                }
            }
            #endregion

            #region tìm kiếm nếu nhập ngày bắt đầu và ngày kết thúc
            if (dtpSearchStart.Value.ToString().Length > 0 && dtpSearchEnd.Value.ToString().Length > 0)
            {
                // TH nhập student và ngày
                if (txbStudentName.Text.Length > 0)
                {
                    using (var _context = new DBentityProject())
                    {

                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                         where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                            MessageBox.Show("Không có đồ án phù hợp");
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
                                this.Close();
                            }
                        }
                        catch
                        {
                            return;
                        }
                    }
                    
                }

                //TH chỉ nhập ngày
                else
                {
                    using (var _context = new DBentityProject())
                    {

                        var idProject = (from t in _context.tbProject.AsEnumerable()
                                         where t.dateStart.Value.ToShortDateString() == dtpSearchStart.Value.ToShortDateString()
                                         where t.dateEnd.Value.ToShortDateString() == dtpSearchEnd.Value.ToShortDateString()
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
                            MessageBox.Show("Không có đề tài phù hợp");
                        else
                        {
                            project = idProject;
                        }
                    }
                }

                #endregion
                this.Close();
            }
        }

    
        #region Thiết lập textbox
        private void txbProjectName_Click(object sender, EventArgs e)
        {
           
        }
        private void txbProjectName_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            
        }
        private void txbGVHD_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }

        private void txbGVHD_Click(object sender, EventArgs e)
        {
    
            
        }

        #endregion

        private void txbStudentName_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void txbStudentName_Click(object sender, EventArgs e)
        {
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txbStudentName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
