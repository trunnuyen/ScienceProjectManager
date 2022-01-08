using Project_Management.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Controllers
{
    class SubjectController
    {
        public static List<Subject> GetListSubject()
        {
            using(var _context = new DBentityProject())
            {
                var sub = (from s in _context.tbSubject
                           select s).ToList();
                return sub;
            }
        }

        public static bool AddSubject(Subject subject)
        {
            using(var _context = new DBentityProject())
            {
                _context.tbSubject.Add(subject);
                _context.SaveChanges();
                return true;
            }
        }

        public static bool Update(Subject subject)
        {
            using (var _context = new DBentityProject())
            {
                var sub = (from s in _context.tbSubject.AsEnumerable()
                           where s.id == subject.id
                           select s).SingleOrDefault();
                _context.tbSubject.AddOrUpdate(subject);
                _context.SaveChanges();
                return true;
            }
        }

        public static bool Delete(Subject subject)
        {
            try
            {
                using (var _context = new DBentityProject())
                {
                    var sub = (from s in _context.tbSubject.AsEnumerable()
                               where s.id == subject.id
                               select s).SingleOrDefault();
                    _context.tbSubject.Remove(sub);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool CheckSubject(string subject)
        {
            using(var _context= new DBentityProject())
            {
                var sub = (from s in _context.tbSubject.AsEnumerable()
                           where s.subject == subject
                           select s).SingleOrDefault();
                if (sub != null)
                    return true;    //  trùng
                else
                    return false;    // không trùng

            }
        }
    }
}
