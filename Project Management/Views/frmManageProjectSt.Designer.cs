
namespace Project_Management.Views
{
    partial class frmManageProjectSt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageProjectSt));
            this.panel3 = new System.Windows.Forms.Panel();
            this.lstProject = new System.Windows.Forms.ListView();
            this.cSTT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cStudents = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cInstructors = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cCourse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cRank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnProjectDetail = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnAll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.lstProject);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // lstProject
            // 
            this.lstProject.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cSTT,
            this.cID,
            this.cName,
            this.cStudents,
            this.cInstructors,
            this.cSubject,
            this.cCourse,
            this.cType,
            this.cRank,
            this.cHost});
            resources.ApplyResources(this.lstProject, "lstProject");
            this.lstProject.FullRowSelect = true;
            this.lstProject.GridLines = true;
            this.lstProject.HideSelection = false;
            this.lstProject.Name = "lstProject";
            this.lstProject.UseCompatibleStateImageBehavior = false;
            this.lstProject.View = System.Windows.Forms.View.Details;
            // 
            // cSTT
            // 
            resources.ApplyResources(this.cSTT, "cSTT");
            // 
            // cID
            // 
            resources.ApplyResources(this.cID, "cID");
            // 
            // cName
            // 
            resources.ApplyResources(this.cName, "cName");
            // 
            // cStudents
            // 
            resources.ApplyResources(this.cStudents, "cStudents");
            // 
            // cInstructors
            // 
            resources.ApplyResources(this.cInstructors, "cInstructors");
            // 
            // cSubject
            // 
            resources.ApplyResources(this.cSubject, "cSubject");
            // 
            // cCourse
            // 
            resources.ApplyResources(this.cCourse, "cCourse");
            // 
            // cType
            // 
            resources.ApplyResources(this.cType, "cType");
            // 
            // cRank
            // 
            resources.ApplyResources(this.cRank, "cRank");
            // 
            // cHost
            // 
            resources.ApplyResources(this.cHost, "cHost");
            // 
            // panel12
            // 
            this.panel12.BackgroundImage = global::Project_Management.Properties.Resources.a;
            resources.ApplyResources(this.panel12, "panel12");
            this.panel12.Name = "panel12";
            // 
            // btnProjectDetail
            // 
            this.btnProjectDetail.BackColor = System.Drawing.Color.SlateGray;
            resources.ApplyResources(this.btnProjectDetail, "btnProjectDetail");
            this.btnProjectDetail.FlatAppearance.BorderSize = 0;
            this.btnProjectDetail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(120)))));
            this.btnProjectDetail.ForeColor = System.Drawing.Color.White;
            this.btnProjectDetail.Name = "btnProjectDetail";
            this.btnProjectDetail.UseVisualStyleBackColor = false;
            this.btnProjectDetail.Click += new System.EventHandler(this.btnProjectDetail_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Name = "label1";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Controls.Add(this.btnProjectDetail);
            this.panel4.Controls.Add(this.btnAll);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.SlateGray;
            resources.ApplyResources(this.btnAll, "btnAll");
            this.btnAll.FlatAppearance.BorderSize = 0;
            this.btnAll.ForeColor = System.Drawing.Color.White;
            this.btnAll.Name = "btnAll";
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.panel12);
            this.panel2.Controls.Add(this.label1);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // frmManageProjectSt
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageProjectSt";
            this.Load += new System.EventHandler(this.frmManageProjectSt_Load);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lstProject;
        private System.Windows.Forms.ColumnHeader cSTT;
        private System.Windows.Forms.ColumnHeader cID;
        private System.Windows.Forms.ColumnHeader cName;
        private System.Windows.Forms.ColumnHeader cStudents;
        private System.Windows.Forms.ColumnHeader cInstructors;
        private System.Windows.Forms.ColumnHeader cSubject;
        private System.Windows.Forms.ColumnHeader cCourse;
        private System.Windows.Forms.ColumnHeader cType;
        private System.Windows.Forms.ColumnHeader cRank;
        private System.Windows.Forms.ColumnHeader cHost;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button btnProjectDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}