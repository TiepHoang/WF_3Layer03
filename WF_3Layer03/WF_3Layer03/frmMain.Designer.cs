﻿namespace WF_3Layer03
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.fpnCode = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBack = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbProc = new System.Windows.Forms.CheckBox();
            this.cbDto = new System.Windows.Forms.CheckBox();
            this.cbBus = new System.Windows.Forms.CheckBox();
            this.cbDal = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbProc);
            this.groupBox1.Controls.Add(this.cbDto);
            this.groupBox1.Controls.Add(this.cbBus);
            this.groupBox1.Controls.Add(this.cbDal);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.btnRun);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(880, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Option";
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
            // btnRun
            // 
            this.btnRun.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRun.Location = new System.Drawing.Point(802, 16);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 28);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLoad.Location = new System.Drawing.Point(727, 16);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 28);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.fpnCode);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 47);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(880, 331);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Code";
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
            // fpnCode
            // 
            this.fpnCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpnCode.Location = new System.Drawing.Point(3, 16);
            this.fpnCode.Name = "fpnCode";
            this.fpnCode.Size = new System.Drawing.Size(874, 312);
            this.fpnCode.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBack.Location = new System.Drawing.Point(652, 16);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 28);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox1.Location = new System.Drawing.Point(3, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(164, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Database";
            // 
            // cbProc
            // 
            this.cbProc.AutoSize = true;
            this.cbProc.Checked = true;
            this.cbProc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbProc.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbProc.Location = new System.Drawing.Point(296, 16);
            this.cbProc.Name = "cbProc";
            this.cbProc.Size = new System.Drawing.Size(48, 28);
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
            this.cbDto.Size = new System.Drawing.Size(43, 28);
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
            this.cbBus.Location = new System.Drawing.Point(209, 16);
            this.cbBus.Name = "cbBus";
            this.cbBus.Size = new System.Drawing.Size(44, 28);
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
            this.cbDal.Size = new System.Drawing.Size(42, 28);
            this.cbDal.TabIndex = 9;
            this.cbDal.Text = "Dal";
            this.cbDal.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.CheckBox cbProc;
        private System.Windows.Forms.CheckBox cbDto;
        private System.Windows.Forms.CheckBox cbBus;
        private System.Windows.Forms.CheckBox cbDal;
        private System.Windows.Forms.TextBox textBox1;
    }
}