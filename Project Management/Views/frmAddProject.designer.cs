namespace Project_Management
{
    partial class frmAddProject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddProject));
            this.txbID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbCourse = new System.Windows.Forms.ComboBox();
            this.cbSubject = new System.Windows.Forms.ComboBox();
            this.txbProjectName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.listboxStudent = new System.Windows.Forms.ListBox();
            this.listboxResultStudent = new System.Windows.Forms.ListBox();
            this.listboxInstructor = new System.Windows.Forms.ListBox();
            this.listboxResultInstructor = new System.Windows.Forms.ListBox();
            this.txbInstructors = new System.Windows.Forms.RichTextBox();
            this.txbStudents = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbID
            // 
            this.txbID.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txbID, "txbID");
            this.txbID.ForeColor = System.Drawing.Color.Black;
            this.txbID.Name = "txbID";
            this.txbID.Click += new System.EventHandler(this.txbID_Click);
            this.txbID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbID_KeyPress);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.Color.SlateGray;
            this.label9.Name = "label9";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.BackColor = System.Drawing.Color.SlateGray;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbCourse
            // 
            this.cbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbCourse, "cbCourse");
            this.cbCourse.ForeColor = System.Drawing.Color.Black;
            this.cbCourse.FormattingEnabled = true;
            this.cbCourse.Items.AddRange(new object[] {
            resources.GetString("cbCourse.Items"),
            resources.GetString("cbCourse.Items1"),
            resources.GetString("cbCourse.Items2"),
            resources.GetString("cbCourse.Items3"),
            resources.GetString("cbCourse.Items4"),
            resources.GetString("cbCourse.Items5"),
            resources.GetString("cbCourse.Items6"),
            resources.GetString("cbCourse.Items7"),
            resources.GetString("cbCourse.Items8"),
            resources.GetString("cbCourse.Items9"),
            resources.GetString("cbCourse.Items10"),
            resources.GetString("cbCourse.Items11"),
            resources.GetString("cbCourse.Items12")});
            this.cbCourse.Name = "cbCourse";
            this.cbCourse.SelectedIndexChanged += new System.EventHandler(this.cbCourse_SelectedIndexChanged);
            // 
            // cbSubject
            // 
            this.cbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbSubject, "cbSubject");
            this.cbSubject.ForeColor = System.Drawing.Color.Black;
            this.cbSubject.FormattingEnabled = true;
            this.cbSubject.Items.AddRange(new object[] {
            resources.GetString("cbSubject.Items")});
            this.cbSubject.Name = "cbSubject";
            this.cbSubject.SelectedIndexChanged += new System.EventHandler(this.cbSubject_SelectedIndexChanged);
            // 
            // txbProjectName
            // 
            this.txbProjectName.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txbProjectName, "txbProjectName");
            this.txbProjectName.ForeColor = System.Drawing.Color.Black;
            this.txbProjectName.Name = "txbProjectName";
            this.txbProjectName.Click += new System.EventHandler(this.txbProjectName_Click);
            this.txbProjectName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbProjectName_KeyPress);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.SlateGray;
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.SlateGray;
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.SlateGray;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.SlateGray;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.SlateGray;
            this.label2.Name = "label2";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.panel12);
            this.panel2.Controls.Add(this.lblName);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // panel12
            // 
            this.panel12.BackgroundImage = global::Project_Management.Properties.Resources.a;
            resources.ApplyResources(this.panel12, "panel12");
            this.panel12.Name = "panel12";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblName.Name = "lblName";
            // 
            // listboxStudent
            // 
            resources.ApplyResources(this.listboxStudent, "listboxStudent");
            this.listboxStudent.FormattingEnabled = true;
            this.listboxStudent.Name = "listboxStudent";
            this.listboxStudent.Click += new System.EventHandler(this.listboxStudent_Click);
            // 
            // listboxResultStudent
            // 
            resources.ApplyResources(this.listboxResultStudent, "listboxResultStudent");
            this.listboxResultStudent.FormattingEnabled = true;
            this.listboxResultStudent.Name = "listboxResultStudent";
            this.listboxResultStudent.Click += new System.EventHandler(this.listboxResultStudent_Click);
            this.listboxResultStudent.SelectedIndexChanged += new System.EventHandler(this.listboxResultStudent_SelectedIndexChanged);
            this.listboxResultStudent.DoubleClick += new System.EventHandler(this.listboxResultStudent_DoubleClick);
            // 
            // listboxInstructor
            // 
            resources.ApplyResources(this.listboxInstructor, "listboxInstructor");
            this.listboxInstructor.FormattingEnabled = true;
            this.listboxInstructor.Name = "listboxInstructor";
            this.listboxInstructor.Click += new System.EventHandler(this.listboxInstructor_Click);
            // 
            // listboxResultInstructor
            // 
            resources.ApplyResources(this.listboxResultInstructor, "listboxResultInstructor");
            this.listboxResultInstructor.FormattingEnabled = true;
            this.listboxResultInstructor.Name = "listboxResultInstructor";
            this.listboxResultInstructor.Click += new System.EventHandler(this.listboxResultInstructor_Click);
            this.listboxResultInstructor.SelectedIndexChanged += new System.EventHandler(this.listboxResultInstructor_SelectedIndexChanged);
            this.listboxResultInstructor.DoubleClick += new System.EventHandler(this.listboxResultInstructor_DoubleClick);
            // 
            // txbInstructors
            // 
            resources.ApplyResources(this.txbInstructors, "txbInstructors");
            this.txbInstructors.ForeColor = System.Drawing.Color.Black;
            this.txbInstructors.Name = "txbInstructors";
            this.txbInstructors.Click += new System.EventHandler(this.txbInstructors_Click);
            this.txbInstructors.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbInstructors_KeyPress);
            // 
            // txbStudents
            // 
            resources.ApplyResources(this.txbStudents, "txbStudents");
            this.txbStudents.ForeColor = System.Drawing.Color.Black;
            this.txbStudents.Name = "txbStudents";
            this.txbStudents.Click += new System.EventHandler(this.txbStudents_Click);
            this.txbStudents.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbStudents_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listboxStudent);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txbInstructors);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txbStudents);
            this.groupBox1.Controls.Add(this.listboxResultStudent);
            this.groupBox1.Controls.Add(this.listboxInstructor);
            this.groupBox1.Controls.Add(this.listboxResultInstructor);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.SlateGray;
            this.label1.Name = "label1";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Name = "textBox1";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.SlateGray;
            this.label7.Name = "label7";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Name = "textBox2";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.SlateGray;
            this.label8.Name = "label8";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.ForeColor = System.Drawing.Color.Black;
            this.textBox3.Name = "textBox3";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbCourse);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.cbSubject);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txbID);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txbProjectName);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // frmAddProject
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmAddProject";
            this.Load += new System.EventHandler(this.frmAddProject_Load);
            this.MdiChildActivate += new System.EventHandler(this.frmAddProject_MdiChildActivate);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbCourse;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.TextBox txbProjectName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txbID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ListBox listboxStudent;
        private System.Windows.Forms.ListBox listboxResultStudent;
        private System.Windows.Forms.ListBox listboxInstructor;
        private System.Windows.Forms.ListBox listboxResultInstructor;
        private System.Windows.Forms.RichTextBox txbInstructors;
        private System.Windows.Forms.RichTextBox txbStudents;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}