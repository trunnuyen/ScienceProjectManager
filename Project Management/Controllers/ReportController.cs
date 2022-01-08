using Project_Management.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Controllers
{
    public class ReportController
    {
        public static  bool AddReport(Report report)
        {
            using( var _context = new DBentityProject())
            {
                _context.tbReport.Add(report);
                _context.SaveChanges();
                return true;
            }
        }
        public static bool Delete(string id)
        {
            using(var _context = new DBentityProject())
            {
                var rp = (from r in _context.tbReport.AsEnumerable()
                          where r.id.Contains(id)
                          select r).ToList();
                foreach (var item in rp)
                {
                    _context.tbReport.Remove(item);
                    _context.SaveChanges();
                }
                return true;
            }
        }

    }
}
