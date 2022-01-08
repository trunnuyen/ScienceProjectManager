using Project_Management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;

namespace Project_Management.Views
{
    public partial class frmMainSearch : Form
    {
        private int ID = 1;
        public frmMainSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.lstViewSearh.Items.Clear();
            this.listView1.Items.Clear();
            
            frmSearchProject formSearchProject = new frmSearchProject();
            formSearchProject.ShowDialog();
            if (formSearchProject.project is null)
                return;
            List<Project> SearhPros = formSearchProject.project;
            List<Progress> SearchProg = formSearchProject.progress;
            if (formSearchProject.checkBox3.Checked == true || formSearchProject.checkBox2.Checked == true)
            {
                lstViewSearh.Visible = false;
                listView1.Visible = true;
                foreach (var SearhPro in SearchProg)
                {
                    ListViewItem infoPro = new ListViewItem(ID.ToString());
                    infoPro.SubItems.Add(new ListViewItem.ListViewSubItem(infoPro, SearhPro.idProject.ToString()));
                    infoPro.SubItems.Add(new ListViewItem.ListViewSubItem(infoPro, SearhPro.Name.ToString()));
                    

                    
                    
                    infoPro.SubItems.Add(new ListViewItem.ListViewSubItem(infoPro, SearhPro.dateStart.ToString()));
                    infoPro.SubItems.Add(new ListViewItem.ListViewSubItem(infoPro, SearhPro.finishTime.ToString()));
                    infoPro.SubItems.Add(new ListViewItem.ListViewSubItem(infoPro, SearhPro.submitTime.ToString()));
                    infoPro.SubItems.Add(new ListViewItem.ListViewSubItem(infoPro, SearhPro.expense.ToString()));
                    this.listView1.Items.Add(infoPro);
                }
            }
            else
            {
                lstViewSearh.Visible = true;
                listView1.Visible = false;
                foreach (var SearhPro in SearhPros)
                {
                    ListViewItem infoPro = new ListViewItem(ID.ToString());
                    infoPro.SubItems.Add(new ListViewItem.ListViewSubItem(infoPro, SearhPro.idProject.ToString()));
                    infoPro.SubItems.Add(new ListViewItem.ListViewSubItem(infoPro, SearhPro.name.ToString()));
                    string sStudent = "";
                    foreach (Student st in SearhPro.listStudent)
                    {
                        sStudent += st.name.ToString() + " ";
                    }
                    infoPro.SubItems.Add(new ListViewItem.ListViewSubItem(infoPro, sStudent));

                    string sInstructor = "";
                    foreach (Instructor gv in SearhPro.listInstructor)
                    {
                        sInstructor += gv.name.ToString() + " ";
                    }
                    infoPro.SubItems.Add(new ListViewItem.ListViewSubItem(infoPro, sInstructor));
                    infoPro.SubItems.Add(new ListViewItem.ListViewSubItem(infoPro, SearhPro.subject.ToString()));
                    infoPro.SubItems.Add(new ListViewItem.ListViewSubItem(infoPro, SearhPro.course.ToString()));

                    this.lstViewSearh.Items.Add(infoPro);
                }
            }



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmMainSearch_Load(object sender, EventArgs e)
        {

        }
        public void ChangeLanguage()
        {
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
   
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var ExcelApp = new Excel.Application();

            ExcelApp.Visible = true;
            var wb = ExcelApp.Workbooks.Add(1); // déclaration variable WorkBooks
            var ws = wb.Worksheets[1]; // déclaration variable WorkSheets
            int Columns = 1;
            int Rows = 1;
            if (listView1.Visible == true)
            {
                foreach (ListViewItem lvi in listView1.Items)
                {
                    Columns = 1;
                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                    {
                        ws.Cells[Rows, Columns] = lvs.Text;
                        Columns++; // incrémente les colonnes
                    }
                    Rows++; // incrémente les rangées
                }
            }
            else
            {
                foreach(ListViewItem lvi in lstViewSearh.Items)
                {
                    Columns = 1;
                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                    {
                        ws.Cells[Rows, Columns] = lvs.Text;
                        Columns++; // incrémente les colonnes
                    }
                    Rows++; // incrémente les rangées
                }
            }    
        }
    }
}
