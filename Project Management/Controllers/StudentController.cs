using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Project_Management.Models;
namespace Project_Management.Controllers
{
    class StudentController
    {
        public static bool AddStudent(Student std)
        {
            try
            {
                using (var _context = new DBentityProject())
                {
                    _context.tbStudent.Add(std);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static List<Student> getAllSTD()
        {
            using (var _context = new DBentityProject())
            {
                var allStd = (from t in _context.tbStudent
                              select t).ToList();
                return allStd;
            }
        }

        public static bool UpdateStudent(Student std, string oldMSSV)
        {   // done
            try
            {
                using (var _context = new DBentityProject())
                {
                    var student = (from u in _context.tbStudent.AsEnumerable()
                                   where u.MSSV == std.MSSV
                                   select u)
                                   .Select(x => new Student
                                   {
                                       MSSV = std.MSSV,
                                       name = std.name,
                                       gender = std.gender,
                                       birthday = std.birthday,
                                       address = std.address,
                                       numberPhone = std.numberPhone,
                                       faculty = std.faculty,
                                       Class = std.Class,
                                       major = std.major,
                                       course = std.course,
                                       password = x.password,
                                       access = x.access,
                                       project=std.project
                                   }).SingleOrDefault();
                    if(student==null)  // sửa MSSV
                    {
                        
                        var student_del = (from s in _context.tbStudent.AsEnumerable()
                                           where s.MSSV == oldMSSV
                                           select s).SingleOrDefault();
                        _context.tbStudent.Remove(student_del);
                        _context.tbStudent.Add(std);
                        _context.SaveChanges();
                        return true;
                    }
                    _context.tbStudent.AddOrUpdate(student);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static Student GetStudentbyID(string mssv)
        {
            // exception
            using (var _context = new DBentityProject())
            {
                var student = (from s in _context.tbStudent.AsEnumerable()
                               where s.MSSV == mssv
                               select s)
                               .Select(x=>new Student()
                               {
                                   MSSV=x.MSSV,
                                   name=x.name,
                                   address=x.address,
                                   birthday=x.birthday,
                                   gender=x.gender,
                                   numberPhone=x.numberPhone,
                                   Class=x.Class,
                                   course=x.course,
                                   faculty=x.faculty,
                                   major=x.major,
                                   password = x.password,
                                   access = x.access,
                                   project=x.project
                               }).ToList();
                if (student.Count == 1)
                {
                    return student[0];
                }
                else
                    return null;
            }
        }
        public static bool Delete(Student std)
        {
            try
            {
                using (var _context = new DBentityProject())
                {
                    var dbStudent = (from t in _context.tbStudent
                                     where t.MSSV == std.MSSV
                                     select t).SingleOrDefault();
                    // xóa đề tài nếu chỉ có 1 sinh viên
                    foreach (var item in dbStudent.project)
                    {
                        if(item.listStudent.Count==1)
                        {
                            var del = (from p in _context.tbProject.AsEnumerable()
                                       where p.idProject == item.idProject
                                       select p).SingleOrDefault();
                            _context.tbProject.Remove(del);
                            var delProgress = (from p in _context.tbProgress.AsEnumerable()
                                               where p.idProject == item.idProject
                                               select p).SingleOrDefault();
                            _context.tbProgress.Remove(delProgress);
                            break;
                        }
                    }
                    _context.tbStudent.Remove(dbStudent);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static List<Student> Search(string MSSV)
        {
            // Tìm các student gợi ý

            using (var _context = new DBentityProject())
            {
                var std = (from s in _context.tbStudent.AsEnumerable()
                           where s.MSSV.Contains(MSSV)
                           select s).ToList();
                return std;
            }

        }

        public static bool CheckMSSV(string oldMSSV, string MSSV,string name, bool edit)
        {
            using(var _context = new DBentityProject())
            {
                // không chỉnh sửa MSSV
                if(edit==true && MSSV==oldMSSV)
                {
                    return false;
                }
                var std1 = (from s in _context.tbStudent.AsEnumerable()
                           where s.MSSV == MSSV 
                           select s).Count();
                // Nếu add
                if (edit==false && std1>0)
                {
                    return true; // trùng
                }
                // Chỉnh sửa nhưng trùng
                else if(edit==true && std1>0)
                {
                    return true;
                }
                return false;
            }
        }

       
        public static Student getMssvStd(string mssv)
        {
            using (var _context = new DBentityProject())
            {

                var Mssv = (from t in _context.tbStudent
                            where t.MSSV == mssv
                            select t).ToList();
                if (Mssv.Count() == 1)
                    return Mssv[0];
                else
                    return null;

            }
        }
        public static bool Student(string MSV, string MK)
        {
            using (var _context = new DBentityProject())
            {
                var AllSV = (from t in _context.tbStudent
                             where t.MSSV == MSV && t.password == MK
                             select t).ToList();
                if (AllSV.Count == 1)
                {
                    return true;
                }
                return false;
            }
        }

    }
}
