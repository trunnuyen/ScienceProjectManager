namespace Project_Management.Views
{
    partial class frmManageInstructor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageInstructor));
            this.lstInstructor = new System.Windows.Forms.ListView();
            this.clSTT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cGender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cBirthday = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSearchGV = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnDeleteGV = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnEditGV = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddGV = new System.Windows.Forms.Button();
            this.btnTeacherDetail = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstInstructor
            // 
            this.lstInstructor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clSTT,
            this.cID,
            this.cName,
            this.cGender,
            this.cBirthday,
            this.cPhone,
            this.cSubject});
            resources.ApplyResources(this.lstInstructor, "lstInstructor");
            this.lstInstructor.FullRowSelect = true;
            this.lstInstructor.GridLines = true;
            this.lstInstructor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstInstructor.HideSelection = false;
            this.lstInstructor.Name = "lstInstructor";
            this.lstInstructor.UseCompatibleStateImageBehavior = false;
            this.lstInstructor.View = System.Windows.Forms.View.Details;
            this.lstInstructor.SelectedIndexChanged += new System.EventHandler(this.LstviewDataGV_SelectedIndexChanged);
            // 
            // clSTT
            // 
            resources.ApplyResources(this.clSTT, "clSTT");
            // 
            // cID
            // 
            resources.ApplyResources(this.cID, "cID");
            // 
            // cName
            // 
            resources.ApplyResources(this.cName, "cName");
            // 
            // cGender
            // 
            resources.ApplyResources(this.cGender, "cGender");
            // 
            // cBirthday
            // 
            resources.ApplyResources(this.cBirthday, "cBirthday");
            // 
            // cPhone
            // 
            resources.ApplyResources(this.cPhone, "cPhone");
            // 
            // cSubject
            // 
            resources.ApplyResources(this.cSubject, "cSubject");
            // 
            // txtSearchGV
            // 
            resources.ApplyResources(this.txtSearchGV, "txtSearchGV");
            this.txtSearchGV.Name = "txtSearchGV";
            this.txtSearchGV.Click += new System.EventHandler(this.txtSearchGV_Click);
            this.txtSearchGV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchGV_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel6);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackgroundImage = global::Project_Management.Properties.Resources.key_64px;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel12
            // 
            this.panel12.BackgroundImage = global::Project_Management.Properties.Resources.a;
            resources.ApplyResources(this.panel12, "panel12");
            this.panel12.Name = "panel12";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Name = "label1";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.SteelBlue;
            this.panel6.Controls.Add(this.btnSearch);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Controls.Add(this.txtSearchGV);
            this.panel6.Controls.Add(this.btnTeacherDetail);
            this.panel6.Controls.Add(this.btnAll);
            resources.ApplyResources(this.panel6, "panel6");
            this.panel6.Name = "panel6";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(120)))));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnDeleteGV);
            resources.ApplyResources(this.panel7, "panel7");
            this.panel7.Name = "panel7";
            // 
            // btnDeleteGV
            // 
            this.btnDeleteGV.BackColor = System.Drawing.Color.DarkSalmon;
            resources.ApplyResources(this.btnDeleteGV, "btnDeleteGV");
            this.btnDeleteGV.FlatAppearance.BorderSize = 0;
            this.btnDeleteGV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(120)))));
            this.btnDeleteGV.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDeleteGV.Name = "btnDeleteGV";
            this.btnDeleteGV.UseVisualStyleBackColor = false;
            this.btnDeleteGV.Click += new System.EventHandler(this.btnDeleteGV_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnEditGV);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // btnEditGV
            // 
            this.btnEditGV.BackColor = System.Drawing.Color.SlateGray;
            resources.ApplyResources(this.btnEditGV, "btnEditGV");
            this.btnEditGV.FlatAppearance.BorderSize = 0;
            this.btnEditGV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(120)))));
            this.btnEditGV.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditGV.Name = "btnEditGV";
            this.btnEditGV.UseVisualStyleBackColor = false;
            this.btnEditGV.Click += new System.EventHandler(this.btnEditGV_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAddGV);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // btnAddGV
            // 
            this.btnAddGV.BackColor = System.Drawing.Color.SlateGray;
            resources.ApplyResources(this.btnAddGV, "btnAddGV");
            this.btnAddGV.FlatAppearance.BorderSize = 0;
            this.btnAddGV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(120)))));
            this.btnAddGV.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddGV.Name = "btnAddGV";
            this.btnAddGV.UseVisualStyleBackColor = false;
            this.btnAddGV.Click += new System.EventHandler(this.btnAddGV_Click);
            // 
            // btnTeacherDetail
            // 
            this.btnTeacherDetail.BackColor = System.Drawing.Color.SlateGray;
            resources.ApplyResources(this.btnTeacherDetail, "btnTeacherDetail");
            this.btnTeacherDetail.FlatAppearance.BorderSize = 0;
            this.btnTeacherDetail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(120)))));
            this.btnTeacherDetail.ForeColor = System.Drawing.Color.White;
            this.btnTeacherDetail.Name = "btnTeacherDetail";
            this.btnTeacherDetail.UseVisualStyleBackColor = false;
            this.btnTeacherDetail.Click += new System.EventHandler(this.btnTeacherDetail_Click);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lstInstructor);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel2);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // frmManageInstructor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageInstructor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGV_Load);
            this.MdiChildActivate += new System.EventHandler(this.frmManageInstructor_MdiChildActivate);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtSearchGV;
        private System.Windows.Forms.ListView lstInstructor;
        private System.Windows.Forms.ColumnHeader cID;
        private System.Windows.Forms.ColumnHeader cName;
        private System.Windows.Forms.ColumnHeader cBirthday;
        private System.Windows.Forms.ColumnHeader cPhone;
        private System.Windows.Forms.ColumnHeader cSubject;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEditGV;
        private System.Windows.Forms.Button btnDeleteGV;
        private System.Windows.Forms.Button btnAddGV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader clSTT;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnTeacherDetail;
        private System.Windows.Forms.ColumnHeader cGender;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

