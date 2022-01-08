using Project_Management.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Controllers
{
    class GVController
    {
        public static bool AddGV(Instructor GV)
        {
            try
            {
                using (var _context = new DBentityProject())
                {
                    _context.tbInstructor.Add(GV);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static List<Instructor> Search(string MGV)
        {
            //Tìm gợi ý GV
           // List<Instructor> ins = new List<Instructor>();
            using (var _context = new DBentityProject())
            {
                var gv = (from g in _context.tbInstructor.AsEnumerable()
                          where g.id.Contains(MGV)
                          select g).ToList();
                if(gv != null)
                {
                    return gv;
                }
                return null;
            }
        }
        public static List<Instructor> getAllGV()
        {
            /// duy
            using (var _context = new DBentityProject())
            {
                var AllGV = (from t in _context.tbInstructor
                             select t).ToList();
                return AllGV;
            }
        }
        public static bool Instructor(string MGV, string MK)
        {
            using (var _context = new DBentityProject())
            {
                var AllGV = (from t in _context.tbInstructor
                             where t.id == MGV && t.password == MK
                             select t).ToList();
                if (AllGV.Count == 1)
                {
                    return true;
                }
                return false;
            }
        }
       

        public static Instructor GetInstructor(string MGV)
        {
            using(var _context = new DBentityProject())
            {
                var ins = (from i in _context.tbInstructor
                           where i.id == MGV
                           select i).ToList();
                if(ins.Count==1)
                {
                    return ins[0];
                }
                return null;
            }
        }


        public static bool Update(Instructor ins,string oldID)
        {
            try
            {
                using (var _context = new DBentityProject())
                {

                    var dbins = (from i in _context.tbInstructor.AsEnumerable()
                                 where i.id == ins.id
                                 select i)
                                .Select(x => new Instructor
                                {
                                    id = ins.id,
                                    name = ins.name,
                                    gender = ins.gender,
                                    phone = ins.phone,
                                    address=ins.address,
                                    birthday = ins.birthday,
                                    subject=ins.subject,
                                    password = ins.password,
                                    access = ins.access

                                }).SingleOrDefault();
                    if(dbins==null)
                    {
                        var db = (from i in _context.tbInstructor.AsEnumerable()
                                  where i.id == oldID
                                  select i).Single();
                        _context.tbInstructor.Remove(db);
                        _context.tbInstructor.Add(ins);
                        _context.SaveChanges();
                        return true;
                    }
                    _context.tbInstructor.AddOrUpdate(dbins);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static Instructor getIDformGV(string idgv)
        {
            using (var _context = new DBentityProject())
            {

                var mgv = (from t in _context.tbInstructor
                           where t.id == idgv
                           select t).ToList();
                if (mgv.Count() == 1)
                    return mgv[0];
                else
                    return null;

            }
        }
        public static bool CheckMGV(string oldMGV, string MGV, bool edit)
        {
            using(var _context = new DBentityProject())
            {
                // không chỉnh sửa MSSV
                if (edit == true && MGV == oldMGV)
                {
                    return false;
                }
                var gv = (from g in _context.tbInstructor
                          where g.id == MGV
                          select g).Count();
                if(edit== true && gv>0)
                {
                    return true; // trùng
                }
                else if(edit==false && gv>0)
                {
                    return true;

                }
                return false;
            }
        }
        public static bool Delete(Instructor gv)
        {
            try
            {
                using (var _context = new DBentityProject())
                {
                    var dbTeacher = (from t in _context.tbInstructor
                                     where t.id == gv.id
                                     select t).SingleOrDefault();
                    _context.tbInstructor.Remove(dbTeacher);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
