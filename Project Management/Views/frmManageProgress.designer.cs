namespace Project_Management.Views
{
    partial class frmManageProgress
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageProgress));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.listViewProgress = new System.Windows.Forms.ListView();
            this.clSTT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clIDProject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clProjectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cllistStudent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clFinishTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clSubmitTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clExpense = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbtimedown = new System.Windows.Forms.Label();
            this.radNotFinished = new System.Windows.Forms.RadioButton();
            this.radFinished = new System.Windows.Forms.RadioButton();
            this.lbProjectName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timedown = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel12
            // 
            this.panel12.BackgroundImage = global::Project_Management.Properties.Resources.a;
            resources.ApplyResources(this.panel12, "panel12");
            this.panel12.Name = "panel12";
            this.panel12.Paint += new System.Windows.Forms.PaintEventHandler(this.panel12_Paint);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.btnAdd);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.button1, "button1");
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(120)))));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.SlateGray;
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(120)))));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // listViewProgress
            // 
            this.listViewProgress.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clSTT,
            this.clIDProject,
            this.clProjectName,
            this.cllistStudent,
            this.clStartTime,
            this.clFinishTime,
            this.clSubmitTime,
            this.clExpense});
            resources.ApplyResources(this.listViewProgress, "listViewProgress");
            this.listViewProgress.FullRowSelect = true;
            this.listViewProgress.GridLines = true;
            this.listViewProgress.HideSelection = false;
            this.listViewProgress.Name = "listViewProgress";
            this.listViewProgress.UseCompatibleStateImageBehavior = false;
            this.listViewProgress.View = System.Windows.Forms.View.Details;
            this.listViewProgress.SelectedIndexChanged += new System.EventHandler(this.listViewProgress_SelectedIndexChanged);
            // 
            // clSTT
            // 
            resources.ApplyResources(this.clSTT, "clSTT");
            // 
            // clIDProject
            // 
            resources.ApplyResources(this.clIDProject, "clIDProject");
            // 
            // clProjectName
            // 
            resources.ApplyResources(this.clProjectName, "clProjectName");
            // 
            // cllistStudent
            // 
            resources.ApplyResources(this.cllistStudent, "cllistStudent");
            // 
            // clStartTime
            // 
            resources.ApplyResources(this.clStartTime, "clStartTime");
            // 
            // clFinishTime
            // 
            resources.ApplyResources(this.clFinishTime, "clFinishTime");
            // 
            // clSubmitTime
            // 
            resources.ApplyResources(this.clSubmitTime, "clSubmitTime");
            // 
            // clExpense
            // 
            resources.ApplyResources(this.clExpense, "clExpense");
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.listViewProgress);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lbtimedown);
            this.panel4.Controls.Add(this.radNotFinished);
            this.panel4.Controls.Add(this.radFinished);
            this.panel4.Controls.Add(this.lbProjectName);
            this.panel4.Controls.Add(this.label3);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // lbtimedown
            // 
            resources.ApplyResources(this.lbtimedown, "lbtimedown");
            this.lbtimedown.ForeColor = System.Drawing.Color.LightGreen;
            this.lbtimedown.Name = "lbtimedown";
            this.lbtimedown.Click += new System.EventHandler(this.lbtimedown_Click);
            // 
            // radNotFinished
            // 
            resources.ApplyResources(this.radNotFinished, "radNotFinished");
            this.radNotFinished.ForeColor = System.Drawing.Color.SlateGray;
            this.radNotFinished.Name = "radNotFinished";
            this.radNotFinished.TabStop = true;
            this.radNotFinished.UseVisualStyleBackColor = true;
            this.radNotFinished.CheckedChanged += new System.EventHandler(this.radNotFinished_CheckedChanged);
            // 
            // radFinished
            // 
            resources.ApplyResources(this.radFinished, "radFinished");
            this.radFinished.ForeColor = System.Drawing.Color.SlateGray;
            this.radFinished.Name = "radFinished";
            this.radFinished.TabStop = true;
            this.radFinished.UseVisualStyleBackColor = true;
            this.radFinished.CheckedChanged += new System.EventHandler(this.radFinished_CheckedChanged);
            // 
            // lbProjectName
            // 
            resources.ApplyResources(this.lbProjectName, "lbProjectName");
            this.lbProjectName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbProjectName.Name = "lbProjectName";
            this.lbProjectName.Click += new System.EventHandler(this.lbProjectName_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.SlateGray;
            this.label3.Name = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // timedown
            // 
            this.timedown.Interval = 10;
            this.timedown.Tick += new System.EventHandler(this.timedown_Tick);
            // 
            // frmManageProgress
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageProgress";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewProgress;
        private System.Windows.Forms.ColumnHeader clSTT;
        private System.Windows.Forms.ColumnHeader clIDProject;
        private System.Windows.Forms.ColumnHeader clProjectName;
        private System.Windows.Forms.ColumnHeader cllistStudent;
        private System.Windows.Forms.ColumnHeader clStartTime;
        private System.Windows.Forms.ColumnHeader clFinishTime;
        private System.Windows.Forms.ColumnHeader clSubmitTime;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbProjectName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radNotFinished;
        private System.Windows.Forms.RadioButton radFinished;
        private System.Windows.Forms.Label lbtimedown;
        private System.Windows.Forms.Timer timedown;
        private System.Windows.Forms.ColumnHeader clExpense;
        private System.Windows.Forms.Button button1;
    }
}