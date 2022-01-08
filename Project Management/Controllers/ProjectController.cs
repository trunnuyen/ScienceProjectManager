using Project_Management.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Management.Controllers
{
    class ProjectController
    {
        public static bool AddProject(Project project)
        {
            try
            {
                using (var _context = new DBentityProject())
                {

                    foreach (var student in project.listStudent)
                    {
                        var std = (from s in _context.tbStudent
                                   where s.MSSV == student.MSSV
                                   select s).Single();

                        std.project.Add(project);

                    }
                    project.listStudent.Clear();

                    foreach (var ins in project.listInstructor)
                    {
                        var dbins = (from i in _context.tbInstructor
                                     where i.id == ins.id
                                     select i).Single();
                        dbins.project.Add(project);
                    }
                    project.listInstructor.Clear();

                    _context.tbProject.Add(project);
                    // EXCEPTION
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        public static List<Project> getAllProject()
        {
            try
            {
                using (var _context = new DBentityProject())
                {
                    // code đúng
                    var Allprojects = (from t in _context.tbProject.AsEnumerable()
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
                                           dateStart = x.dateStart,
                                           source = x.source,
                                           expense = x.expense,
                                           type = x.type,
                                           rank = x.rank,
                                           host = x.host
                                       }).ToList();

                    return Allprojects;
                }
            }
            catch
            {
                return new List<Project>();
            }
        }

        public static List<Student> GetListStudent(List<string> lstStudent)
        {
            // Dùng cho form Add Project
            List<Student> listStudent = new List<Student>();

            using( var _context = new DBentityProject())
            {
                foreach (string std in lstStudent)
                {
                    var dbstd = (from s in _context.tbStudent
                                 where s.MSSV == std
                                 select s).Single();
                    listStudent.Add(dbstd);
                }
                return listStudent;
            }
                
        }
        public static List<Instructor> GetListInstructor(List<string> lstInstructor)
        {
            List<Instructor> listInstructor = new List<Instructor>();
            using( var _context = new DBentityProject())
            {
                foreach (string instructor in lstInstructor)
                {
                    var dbins = (from ins in _context.tbInstructor
                                 where ins.id == instructor
                                 select ins).Single();
                    listInstructor.Add(dbins);
                }
                return listInstructor;
            }
        }

        public static Project GetProject(string id)
        {
            using(var _context= new DBentityProject())
            {
                var proj = (from p in _context.tbProject.AsEnumerable()
                            where p.idProject == id
                            select p)
                            .Select(x => new Project()
                            {
                                idProject = x.idProject,
                                name = x.name,
                                listStudent = x.listStudent,
                                listInstructor = x.listInstructor,
                                subject = x.subject,
                                course = x.course,
                                dateStart = x.dateStart,
                                dateEnd = x.dateEnd,
                                expense = x.expense,
                                source = x.source,
                                type = x.type,
                                rank = x.rank,
                                host = x.host
                            }).ToList();
                if(proj.Count==1)
                {
                    return proj[0];
                }
                return null;

            }
        }

        public static bool Update(Project proj, string oldID)
        {
            using(var _context = new DBentityProject())
            {
                // Xóa proj cũ
                var oldP = (from p in _context.tbProject
                            where p.idProject == oldID
                            select p).SingleOrDefault();
                _context.tbProject.Remove(oldP);

                // cập nhật lại cho progress
                var progress = (from pr in _context.tbProgress.AsEnumerable()
                                where pr.idProject == oldID
                                select pr)
                                .Select(x=> new Progress()
                                {
                                    idProject = proj.idProject,
                                    Name = proj.name,
                                    dateStart = x.dateStart,
                                    finishTime = x.finishTime,
                                    submitTime = x.submitTime,
                                    expense = x.expense,
                                    finished = x.finished
                                }).SingleOrDefault();
                _context.tbProgress.AddOrUpdate(progress);


                // Add lại
                //add task cho user
                foreach (var student in proj.listStudent)
                {
                    var std = (from s in _context.tbStudent
                               where s.MSSV == student.MSSV
                               select s).Single();

                    std.project.Add(proj);

                }
                proj.listStudent.Clear();

                foreach (var ins in proj.listInstructor)
                {
                    var dbins = (from i in _context.tbInstructor
                                 where i.id == ins.id
                                 select i).Single();
                    dbins.project.Add(proj);
                }
                proj.listInstructor.Clear();

                _context.tbProject.Add(proj);
                _context.SaveChanges();
                return true;

            }
        }

        public static bool UpdateProject(Project proj)
        {   // TOÀN
            try
            {
                using (var _context = new DBentityProject())
                {
                    var project = (from u in _context.tbProject.AsEnumerable()
                                   where u.idProject == proj.idProject
                                   select u)
                                   .Select(x => new Project
                                   {
                                       idProject = proj.idProject,
                                       name = proj.name,
                                       dateStart = proj.dateStart,
                                       dateEnd = proj.dateEnd,
                                       listStudent = proj.listStudent,
                                       expense = proj.expense,
                                       source = proj.source,
                                       listInstructor = proj.listInstructor,
                                       subject = proj.subject,
                                       course = proj.course,
                                       report = proj.report,
                                       type = x.type,
                                       rank = x.rank,
                                       host = x.host
                                   }).SingleOrDefault();
                    _context.tbProject.AddOrUpdate(project);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool Delete(string id)
        {
            using( var _context = new DBentityProject())
            {
                
                

                var progress = (from pr in _context.tbProgress
                          where pr.idProject == id
                          select pr).SingleOrDefault();

                _context.tbProgress.Remove(progress);

                var db = (from p in _context.tbProject
                          where p.idProject == id
                          select p).SingleOrDefault();
 
                _context.tbProject.Remove(db);
                _context.SaveChanges();
                return true;
            }
        }

        public static List<Project> Search(string id)
        {
            using(var _context = new DBentityProject())
            {
                var list = (from p in _context.tbProject.AsEnumerable()
                            where p.idProject.Contains(id)
                            select p)
                            .Select(x => new Project()
                            {
                                idProject = x.idProject,
                                name = x.name,
                                listStudent = x.listStudent,
                                listInstructor = x.listInstructor,
                                subject = x.subject,
                                course = x.course,
                                type = x.type,
                                rank = x.rank,
                                host = x.host
                            }).ToList();
                return list;
            }
        }

        public static List<Report> GetListReport(string idProject)
        {
            using(var _context = new DBentityProject())
            {
                var rp = (from r in _context.tbReport.AsEnumerable()
                          where r.id.Contains(idProject)
                          select r).ToList();
                return rp;
            }
        }

        public static bool CheckID(string oldid, string id, bool edit)
        {
            using (var _context = new DBentityProject())
            {
                // không chỉnh sửa ID
                if (edit == true && id == oldid)
                {
                    return false;
                }
                var std1 = (from p in _context.tbProject.AsEnumerable()
                            where p.idProject==id
                            select p).Count();
                // Nếu add
                if (edit == false && std1 > 0)
                {
                    return true; // trùng
                }
                // Chỉnh sửa nhưng trùng
                else if (edit == true && std1 > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }

       
    
}
