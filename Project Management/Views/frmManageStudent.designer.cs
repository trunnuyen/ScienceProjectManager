namespace Project_Management.Views
{
    partial class frmManageStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageStudent));
            this.lstStudent = new System.Windows.Forms.ListView();
            this.clSTT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clMSSV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clGender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clBirthday = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clKhoa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clMajor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clClass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clCourse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEditStudent = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnStudentDetail = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstStudent
            // 
            this.lstStudent.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lstStudent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clSTT,
            this.clMSSV,
            this.clName,
            this.clGender,
            this.clBirthday,
            this.clAddress,
            this.cPhone,
            this.clKhoa,
            this.clMajor,
            this.clClass,
            this.clCourse});
            resources.ApplyResources(this.lstStudent, "lstStudent");
            this.lstStudent.FullRowSelect = true;
            this.lstStudent.GridLines = true;
            this.lstStudent.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstStudent.HideSelection = false;
            this.lstStudent.HoverSelection = true;
            this.lstStudent.Name = "lstStudent";
            this.lstStudent.UseCompatibleStateImageBehavior = false;
            this.lstStudent.View = System.Windows.Forms.View.Details;
            this.lstStudent.SelectedIndexChanged += new System.EventHandler(this.listviewStudent_SelectedIndexChanged);
            // 
            // clSTT
            // 
            resources.ApplyResources(this.clSTT, "clSTT");
            // 
            // clMSSV
            // 
            resources.ApplyResources(this.clMSSV, "clMSSV");
            // 
            // clName
            // 
            resources.ApplyResources(this.clName, "clName");
            // 
            // clGender
            // 
            resources.ApplyResources(this.clGender, "clGender");
            // 
            // clBirthday
            // 
            resources.ApplyResources(this.clBirthday, "clBirthday");
            // 
            // clAddress
            // 
            resources.ApplyResources(this.clAddress, "clAddress");
            // 
            // cPhone
            // 
            resources.ApplyResources(this.cPhone, "cPhone");
            // 
            // clKhoa
            // 
            resources.ApplyResources(this.clKhoa, "clKhoa");
            // 
            // clMajor
            // 
            resources.ApplyResources(this.clMajor, "clMajor");
            // 
            // clClass
            // 
            resources.ApplyResources(this.clClass, "clClass");
            // 
            // clCourse
            // 
            resources.ApplyResources(this.clCourse, "clCourse");
            // 
            // txtSearch
            // 
            resources.ApplyResources(this.txtSearch, "txtSearch");
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkSalmon;
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(120)))));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.panel12);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.panel5);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel12
            // 
            this.panel12.BackgroundImage = global::Project_Management.Properties.Resources.a;
            resources.ApplyResources(this.panel12, "panel12");
            this.panel12.Name = "panel12";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Name = "label2";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.Controls.Add(this.btnSearch);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.txtSearch);
            this.panel5.Controls.Add(this.btnStudentDetail);
            this.panel5.Controls.Add(this.btnAll);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(120)))));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEditStudent);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // btnEditStudent
            // 
            this.btnEditStudent.BackColor = System.Drawing.Color.SlateGray;
            resources.ApplyResources(this.btnEditStudent, "btnEditStudent");
            this.btnEditStudent.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.btnEditStudent.FlatAppearance.BorderSize = 0;
            this.btnEditStudent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(120)))));
            this.btnEditStudent.ForeColor = System.Drawing.Color.White;
            this.btnEditStudent.Name = "btnEditStudent";
            this.btnEditStudent.UseVisualStyleBackColor = false;
            this.btnEditStudent.Click += new System.EventHandler(this.btnEditStudent_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button2);
            resources.ApplyResources(this.panel6, "panel6");
            this.panel6.Name = "panel6";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SlateGray;
            resources.ApplyResources(this.button2, "button2");
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(120)))));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // btnStudentDetail
            // 
            this.btnStudentDetail.BackColor = System.Drawing.Color.SlateGray;
            resources.ApplyResources(this.btnStudentDetail, "btnStudentDetail");
            this.btnStudentDetail.FlatAppearance.BorderSize = 0;
            this.btnStudentDetail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(120)))));
            this.btnStudentDetail.ForeColor = System.Drawing.Color.White;
            this.btnStudentDetail.Name = "btnStudentDetail";
            this.btnStudentDetail.UseVisualStyleBackColor = false;
            this.btnStudentDetail.Click += new System.EventHandler(this.btnStudentDetail_Click);
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.SlateGray;
            resources.ApplyResources(this.btnAll, "btnAll");
            this.btnAll.FlatAppearance.BorderSize = 0;
            this.btnAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(120)))));
            this.btnAll.ForeColor = System.Drawing.Color.White;
            this.btnAll.Name = "btnAll";
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.lstStudent);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // frmManageStudent
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageStudent";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMange_Load);
            this.MdiChildActivate += new System.EventHandler(this.frmManageStudent_MdiChildActivate);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView lstStudent;
        private System.Windows.Forms.ColumnHeader clMSSV;
        private System.Windows.Forms.ColumnHeader clBirthday;
        private System.Windows.Forms.ColumnHeader clAddress;
        private System.Windows.Forms.ColumnHeader clCourse;
        private System.Windows.Forms.ColumnHeader clClass;
        private System.Windows.Forms.ColumnHeader clGender;
        private System.Windows.Forms.ColumnHeader clMajor;
        private System.Windows.Forms.ColumnHeader clKhoa;
        private System.Windows.Forms.ColumnHeader clName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ColumnHeader clSTT;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ColumnHeader cPhone;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnEditStudent;
        private System.Windows.Forms.Button btnStudentDetail;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAll;
    }
}