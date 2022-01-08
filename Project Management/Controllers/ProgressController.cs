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
    class ProgressController
    {
        public static bool AddProgress(Progress Pro)
        {
            try
            {
                using (var _context = new DBentityProject())
                {
                    _context.tbProgress.Add(Pro);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static List<Progress> getAllProgress()
        {
            try
            {
                using (var _context = new DBentityProject())
                {
                    var Allprogress = (from t in _context.tbProgress
                                       select t).ToList();
                    return Allprogress;
                }
            }
            catch
            {
                return new List<Progress>();
            }
        }
        public static bool UpdateProgress(Progress pro)
        {
            try
            {
                using (var _context = new DBentityProject())
                {
                    var progress = (from u in _context.tbProgress.AsEnumerable()
                                   where u.idProject == pro.idProject
                                   select u)
                                   .Select(x => new Progress
                                   {
                                       idProject =pro.idProject,
                                       Name = pro.Name,
                                       dateStart = pro.dateStart,
                                       finishTime = pro.finishTime,
                                       submitTime = pro.submitTime,
                                       listStudent = pro.listStudent,
                                       expense = pro.expense,
                                       finished = pro.finished
                                   }).SingleOrDefault();
                    _context.tbProgress.AddOrUpdate(progress);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static Progress GetProgressByID(string idprogress)
        {
            // exception
            using (var _context = new DBentityProject())
            {
                var progress = (from p in _context.tbProgress
                                where p.idProject == idprogress
                                select p).ToList();
                if (progress.Count == 1)
                {
                    return progress[0];
                }
                else
                    return null;
            }
        }
        public static List<Progress> Search(string id)
        {
            using (var _context = new DBentityProject())
            {
                var list = (from p in _context.tbProgress.AsEnumerable()
                            where p.idProject.Contains(id)
                            select p)
                            .Select(x => new Progress()
                            {
                                idProject = x.idProject,
                                Name = x.Name,                                                       
                                dateStart = x.dateStart,
                                finishTime = x.finishTime,
                                submitTime = x.submitTime,                             
                                expense = x.expense,
                                finished = x.finished
                            }).ToList();
                return list;
            }
        }
    }
}
