namespace WF_3Layer03
{
    partial class frmMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteAllProc = new System.Windows.Forms.Button();
            this.cbProc = new System.Windows.Forms.CheckBox();
            this.cbDto = new System.Windows.Forms.CheckBox();
            this.cbBus = new System.Windows.Forms.CheckBox();
            this.cbDal = new System.Windows.Forms.CheckBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.fpnCode = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeleteFile);
            this.groupBox1.Controls.Add(this.btnDeleteAllProc);
            this.groupBox1.Controls.Add(this.cbProc);
            this.groupBox1.Controls.Add(this.cbDto);
            this.groupBox1.Controls.Add(this.cbBus);
            this.groupBox1.Controls.Add(this.cbDal);
            this.groupBox1.Controls.Add(this.txtDatabase);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.btnRun);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(880, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Option";
            // 
            // btnDeleteAllProc
            // 
            this.btnDeleteAllProc.BackColor = System.Drawing.Color.OrangeRed;
            this.btnDeleteAllProc.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDeleteAllProc.Location = new System.Drawing.Point(344, 16);
            this.btnDeleteAllProc.Name = "btnDeleteAllProc";
            this.btnDeleteAllProc.Size = new System.Drawing.Size(75, 32);
            this.btnDeleteAllProc.TabIndex = 10;
            this.btnDeleteAllProc.Text = "Del Proc";
            this.btnDeleteAllProc.UseVisualStyleBackColor = false;
            this.btnDeleteAllProc.Click += new System.EventHandler(this.btnDeleteAllProc_Click);
            // 
            // cbProc
            // 
            this.cbProc.AutoSize = true;
            this.cbProc.Checked = true;
            this.cbProc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbProc.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbProc.Location = new System.Drawing.Point(296, 16);
            this.cbProc.Name = "cbProc";
            this.cbProc.Size = new System.Drawing.Size(48, 32);
            this.cbProc.TabIndex = 6;
            this.cbProc.Text = "Proc";
            this.cbProc.UseVisualStyleBackColor = true;
            // 
            // cbDto
            // 
            this.cbDto.AutoSize = true;
            this.cbDto.Checked = true;
            this.cbDto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDto.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbDto.Location = new System.Drawing.Point(253, 16);
            this.cbDto.Name = "cbDto";
            this.cbDto.Size = new System.Drawing.Size(43, 32);
            this.cbDto.TabIndex = 7;
            this.cbDto.Text = "Dto";
            this.cbDto.UseVisualStyleBackColor = true;
            // 
            // cbBus
            // 
            this.cbBus.AutoSize = true;
            this.cbBus.Checked = true;
            this.cbBus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBus.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbBus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbBus.Location = new System.Drawing.Point(209, 16);
            this.cbBus.Name = "cbBus";
            this.cbBus.Size = new System.Drawing.Size(44, 32);
            this.cbBus.TabIndex = 8;
            this.cbBus.Text = "Bus";
            this.cbBus.UseVisualStyleBackColor = true;
            // 
            // cbDal
            // 
            this.cbDal.AutoSize = true;
            this.cbDal.Checked = true;
            this.cbDal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDal.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbDal.Location = new System.Drawing.Point(167, 16);
            this.cbDal.Name = "cbDal";
            this.cbDal.Size = new System.Drawing.Size(42, 32);
            this.cbDal.TabIndex = 9;
            this.cbDal.Text = "Dal";
            this.cbDal.UseVisualStyleBackColor = true;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtDatabase.Location = new System.Drawing.Point(3, 16);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.ReadOnly = true;
            this.txtDatabase.Size = new System.Drawing.Size(164, 20);
            this.txtDatabase.TabIndex = 5;
            this.txtDatabase.Text = "Database";
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLoad.Location = new System.Drawing.Point(727, 16);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 32);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnRun.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRun.Location = new System.Drawing.Point(802, 16);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 32);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Visible = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtbLog);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 378);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(880, 127);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.SystemColors.WindowText;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.ForeColor = System.Drawing.Color.Green;
            this.rtbLog.Location = new System.Drawing.Point(3, 16);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(874, 108);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "This is Log";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.fpnCode);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 51);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(880, 327);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Code";
            // 
            // fpnCode
            // 
            this.fpnCode.AutoScroll = true;
            this.fpnCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpnCode.Location = new System.Drawing.Point(3, 16);
            this.fpnCode.Name = "fpnCode";
            this.fpnCode.Size = new System.Drawing.Size(874, 308);
            this.fpnCode.TabIndex = 0;
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.BackColor = System.Drawing.Color.OrangeRed;
            this.btnDeleteFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDeleteFile.Location = new System.Drawing.Point(419, 16);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(75, 32);
            this.btnDeleteFile.TabIndex = 11;
            this.btnDeleteFile.Text = "Del File";
            this.btnDeleteFile.UseVisualStyleBackColor = false;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(880, 505);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.Text = "ThreeLayer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.FlowLayoutPanel fpnCode;
        private System.Windows.Forms.CheckBox cbProc;
        private System.Windows.Forms.CheckBox cbDto;
        private System.Windows.Forms.CheckBox cbBus;
        private System.Windows.Forms.CheckBox cbDal;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Button btnDeleteAllProc;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnDeleteFile;
    }
}