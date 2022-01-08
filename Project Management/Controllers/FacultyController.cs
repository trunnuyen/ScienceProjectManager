using Microsoft.SqlServer.Server;
using Project_Management.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Controllers
{
     class FacultyController
     {
        public static bool AddFaculty(Faculty f)
        {
            try
            {
                using (var _context = new DBentityProject())
                {
                    _context.tbFaculty.Add(f);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static List<Faculty> GetAllFaculty()
        {
            using(var _context = new DBentityProject())
            {
                var allf = (from f in _context.tbFaculty.AsEnumerable()
                            select f).ToList();
                return allf;
            }
        }
        public static string GetListMajor(string name)
        {
            using(var _context = new DBentityProject())
            {
                var sub = (from s in _context.tbFaculty.AsEnumerable()
                           where s.name == name
                           select s).SingleOrDefault();
                return sub.listMajor;
            }
        }

        public static bool Update( Faculty faculty)
        {
            try
            {
                using (var _context = new DBentityProject())
                {
                    var fal = (from f in _context.tbFaculty.AsEnumerable()
                               where f.name == faculty.name
                               select f)
                               .Select(x => new Faculty()
                               {
                                   name = faculty.name,
                                   listMajor = faculty.listMajor
                               }).SingleOrDefault();
                    _context.tbFaculty.AddOrUpdate(fal);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool Delete(string name)
        {
            using(var _context = new DBentityProject())
            {
                var fa = (from f in _context.tbFaculty
                          where f.name == name
                          select f).Single();
                _context.tbFaculty.Remove(fa);
                _context.SaveChanges();
                return true;
            }
        }
     }
}
