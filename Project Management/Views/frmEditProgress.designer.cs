namespace Project_Management.Views
{
    partial class frmEditProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditProgress));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rbtnComplete = new System.Windows.Forms.RadioButton();
            this.rbtnNotComplete = new System.Windows.Forms.RadioButton();
            this.dpStart = new System.Windows.Forms.DateTimePicker();
            this.dpEnd = new System.Windows.Forms.DateTimePicker();
            this.dpSubmitted = new System.Windows.Forms.DateTimePicker();
            this.txbID = new System.Windows.Forms.TextBox();
            this.txbName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCanel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbReportTimes = new System.Windows.Forms.ComboBox();
            this.rbComment = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtExpense = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.panel12);
            this.panel2.Controls.Add(this.label10);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // panel12
            // 
            this.panel12.BackgroundImage = global::Project_Management.Properties.Resources.a;
            resources.ApplyResources(this.panel12, "panel12");
            this.panel12.Name = "panel12";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label10.Name = "label10";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.SlateGray;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.SlateGray;
            this.label2.Name = "label2";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.SlateGray;
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.SlateGray;
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.SlateGray;
            this.label6.Name = "label6";
            // 
            // rbtnComplete
            // 
            resources.ApplyResources(this.rbtnComplete, "rbtnComplete");
            this.rbtnComplete.ForeColor = System.Drawing.Color.SlateGray;
            this.rbtnComplete.Name = "rbtnComplete";
            this.rbtnComplete.TabStop = true;
            this.rbtnComplete.UseVisualStyleBackColor = true;
            this.rbtnComplete.CheckedChanged += new System.EventHandler(this.rbtnComplete_CheckedChanged);
            // 
            // rbtnNotComplete
            // 
            resources.ApplyResources(this.rbtnNotComplete, "rbtnNotComplete");
            this.rbtnNotComplete.ForeColor = System.Drawing.Color.SlateGray;
            this.rbtnNotComplete.Name = "rbtnNotComplete";
            this.rbtnNotComplete.TabStop = true;
            this.rbtnNotComplete.UseVisualStyleBackColor = true;
            this.rbtnNotComplete.CheckedChanged += new System.EventHandler(this.rbtnNotComplete_CheckedChanged);
            // 
            // dpStart
            // 
            resources.ApplyResources(this.dpStart, "dpStart");
            this.dpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpStart.Name = "dpStart";
            this.dpStart.ValueChanged += new System.EventHandler(this.dpStart_ValueChanged);
            // 
            // dpEnd
            // 
            resources.ApplyResources(this.dpEnd, "dpEnd");
            this.dpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpEnd.Name = "dpEnd";
            // 
            // dpSubmitted
            // 
            resources.ApplyResources(this.dpSubmitted, "dpSubmitted");
            this.dpSubmitted.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpSubmitted.Name = "dpSubmitted";
            // 
            // txbID
            // 
            resources.ApplyResources(this.txbID, "txbID");
            this.txbID.Name = "txbID";
            this.txbID.Click += new System.EventHandler(this.txbID_Click);
            this.txbID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbID_KeyPress);
            // 
            // txbName
            // 
            resources.ApplyResources(this.txbName, "txbName");
            this.txbName.Name = "txbName";
            this.txbName.Click += new System.EventHandler(this.txbName_Click);
            this.txbName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbName_KeyPress);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.BackColor = System.Drawing.Color.SlateGray;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(120)))));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCanel
            // 
            resources.ApplyResources(this.btnCanel, "btnCanel");
            this.btnCanel.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnCanel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCanel.FlatAppearance.BorderSize = 0;
            this.btnCanel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(120)))));
            this.btnCanel.ForeColor = System.Drawing.Color.White;
            this.btnCanel.Name = "btnCanel";
            this.btnCanel.UseVisualStyleBackColor = false;
            this.btnCanel.Click += new System.EventHandler(this.btnCanel_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.SlateGray;
            this.label3.Name = "label3";
            // 
            // cbReportTimes
            // 
            this.cbReportTimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbReportTimes, "cbReportTimes");
            this.cbReportTimes.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbReportTimes.FormattingEnabled = true;
            this.cbReportTimes.Items.AddRange(new object[] {
            resources.GetString("cbReportTimes.Items")});
            this.cbReportTimes.Name = "cbReportTimes";
            this.cbReportTimes.SelectedIndexChanged += new System.EventHandler(this.cbReportTimes_SelectedIndexChanged);
            // 
            // rbComment
            // 
            resources.ApplyResources(this.rbComment, "rbComment");
            this.rbComment.Name = "rbComment";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.SlateGray;
            this.label7.Name = "label7";
            // 
            // txtExpense
            // 
            resources.ApplyResources(this.txtExpense, "txtExpense");
            this.txtExpense.Name = "txtExpense";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.SlateGray;
            this.label8.Name = "label8";
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.DarkSalmon;
            resources.ApplyResources(this.btnDel, "btnDel");
            this.btnDel.ForeColor = System.Drawing.Color.White;
            this.btnDel.Name = "btnDel";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txbID);
            this.groupBox1.Controls.Add(this.txbName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dpStart);
            this.groupBox1.Controls.Add(this.dpEnd);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Controls.Add(this.cbReportTimes);
            this.groupBox2.Controls.Add(this.rbComment);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnDel);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtnComplete);
            this.groupBox3.Controls.Add(this.rbtnNotComplete);
            this.groupBox3.Controls.Add(this.txtExpense);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.dpSubmitted);
            this.groupBox3.Controls.Add(this.label6);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // frmEditProgress
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCanel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmEditProgress";
            this.Load += new System.EventHandler(this.frmEditProgress_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbtnComplete;
        private System.Windows.Forms.RadioButton rbtnNotComplete;
        private System.Windows.Forms.DateTimePicker dpStart;
        private System.Windows.Forms.DateTimePicker dpEnd;
        private System.Windows.Forms.DateTimePicker dpSubmitted;
        private System.Windows.Forms.TextBox txbID;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbReportTimes;
        private System.Windows.Forms.RichTextBox rbComment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtExpense;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}