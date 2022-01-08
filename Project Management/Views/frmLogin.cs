using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_Management.Controllers;
using Project_Management.Models;

namespace Project_Management.Views
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool lstGV = GVController.Instructor(txtUserName.Text,txtpassword.Text) ;
            bool lstSV = StudentController.Student(txtUserName.Text, txtpassword.Text);
            // dùng database
            
                if (lstGV == true || lstSV == true)
                {
                    MessageBox.Show("Login thành công!");                    
                    frmMainGUInd fm = new frmMainGUInd(txtUserName.Text);
                    fm.Show();
                    
                    
                }
                else
                {
                  
                    label4.Visible = true;
                }
            
                    

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtpassword.Clear();
            txtUserName.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
