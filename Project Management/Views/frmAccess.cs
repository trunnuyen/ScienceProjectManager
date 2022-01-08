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
using Project_Management.Controllers;
using Project_Management.Models;

namespace Project_Management.Views
{
    public partial class frmAccess : Form
    {
        public Instructor instuctor;
        public frmAccess(ref Instructor Instuctor)
        {
            InitializeComponent();
            this.instuctor = Instuctor;           
        }

        private void frmAccess_Load(object sender, EventArgs e)
        {
            this.comboBox1.Text = this.instuctor.access;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            instuctor.access = this.comboBox1.Text.Trim();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ChangeLanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            InitializeComponent();
        }
    }
}
