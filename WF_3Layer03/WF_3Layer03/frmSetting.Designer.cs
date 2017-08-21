namespace WF_3Layer03
{
    partial class frmSetting
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblDababase = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtFolderDto = new System.Windows.Forms.TextBox();
            this.txtFolderDal = new System.Windows.Forms.TextBox();
            this.txtFolderBus = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEntity = new System.Windows.Forms.TextBox();
            this.txtNamespace_Dto = new System.Windows.Forms.TextBox();
            this.txtNamespace_Dal = new System.Windows.Forms.TextBox();
            this.txtNamespace_Bus = new System.Windows.Forms.TextBox();
            this.lblNamespaceDto = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNamespaceDal = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblNamespaceBus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listView = new System.Windows.Forms.ListView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtNew = new System.Windows.Forms.TextBox();
            this.txtOld = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFomat_Proc = new System.Windows.Forms.TextBox();
            this.txtFomat_Dto = new System.Windows.Forms.TextBox();
            this.txtFomat_Dal = new System.Windows.Forms.TextBox();
            this.txtFomat_Bus = new System.Windows.Forms.TextBox();
            this.lblFormatProc = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblFormatDto = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFormatDal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFormatBus = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtResultTable = new System.Windows.Forms.TextBox();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 481);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(863, 43);
            this.panel1.TabIndex = 3;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNext.Location = new System.Drawing.Point(0, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(113, 43);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Save";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.lblDababase);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.txtDatabase);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(863, 47);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATABASE";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Server";
            // 
            // lblDababase
            // 
            this.lblDababase.AutoSize = true;
            this.lblDababase.Location = new System.Drawing.Point(377, 21);
            this.lblDababase.Name = "lblDababase";
            this.lblDababase.Size = new System.Drawing.Size(56, 13);
            this.lblDababase.TabIndex = 1;
            this.lblDababase.Text = "Dababase";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(96, 16);
            this.txtServer.Name = "txtServer";
            this.txtServer.ReadOnly = true;
            this.txtServer.Size = new System.Drawing.Size(208, 20);
            this.txtServer.TabIndex = 14;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(445, 17);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.ReadOnly = true;
            this.txtDatabase.Size = new System.Drawing.Size(208, 20);
            this.txtDatabase.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.txtEntity);
            this.groupBox2.Controls.Add(this.txtNamespace_Dto);
            this.groupBox2.Controls.Add(this.txtNamespace_Dal);
            this.groupBox2.Controls.Add(this.txtNamespace_Bus);
            this.groupBox2.Controls.Add(this.lblNamespaceDto);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblNamespaceDal);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.lblNamespaceBus);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(863, 173);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "";
            this.groupBox2.Text = "NAMESPACE";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtFolderDto);
            this.groupBox4.Controls.Add(this.txtFolderDal);
            this.groupBox4.Controls.Add(this.txtFolderBus);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(3, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(326, 154);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fordel save code";
            // 
            // txtFolderDto
            // 
            this.txtFolderDto.Location = new System.Drawing.Point(48, 83);
            this.txtFolderDto.Name = "txtFolderDto";
            this.txtFolderDto.Size = new System.Drawing.Size(269, 20);
            this.txtFolderDto.TabIndex = 1;
            this.txtFolderDto.DoubleClick += new System.EventHandler(this.txtFolderDto_DoubleClick);
            this.txtFolderDto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFolderDto_KeyUp);
            // 
            // txtFolderDal
            // 
            this.txtFolderDal.Location = new System.Drawing.Point(48, 51);
            this.txtFolderDal.Name = "txtFolderDal";
            this.txtFolderDal.Size = new System.Drawing.Size(269, 20);
            this.txtFolderDal.TabIndex = 1;
            this.txtFolderDal.DoubleClick += new System.EventHandler(this.txtFolderDal_DoubleClick);
            this.txtFolderDal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFolderDal_KeyUp);
            // 
            // txtFolderBus
            // 
            this.txtFolderBus.Location = new System.Drawing.Point(48, 19);
            this.txtFolderBus.Name = "txtFolderBus";
            this.txtFolderBus.Size = new System.Drawing.Size(269, 20);
            this.txtFolderBus.TabIndex = 1;
            this.txtFolderBus.DoubleClick += new System.EventHandler(this.txtFolderBus_DoubleClick);
            this.txtFolderBus.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFolderBus_KeyUp);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(18, 86);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Dto";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Dal";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Bus";
            // 
            // txtEntity
            // 
            this.txtEntity.Location = new System.Drawing.Point(453, 144);
            this.txtEntity.Name = "txtEntity";
            this.txtEntity.Size = new System.Drawing.Size(208, 20);
            this.txtEntity.TabIndex = 12;
            this.txtEntity.Text = "Entity";
            this.txtEntity.DoubleClick += new System.EventHandler(this.txtEntity_DoubleClick);
            this.txtEntity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtEntity_KeyUp);
            // 
            // txtNamespace_Dto
            // 
            this.txtNamespace_Dto.Location = new System.Drawing.Point(453, 107);
            this.txtNamespace_Dto.Name = "txtNamespace_Dto";
            this.txtNamespace_Dto.Size = new System.Drawing.Size(208, 20);
            this.txtNamespace_Dto.TabIndex = 12;
            this.txtNamespace_Dto.Text = "Object";
            this.txtNamespace_Dto.TextChanged += new System.EventHandler(this.txtNamespace_Dto_TextChanged);
            this.txtNamespace_Dto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNamespace_Dto_KeyUp);
            // 
            // txtNamespace_Dal
            // 
            this.txtNamespace_Dal.Location = new System.Drawing.Point(453, 67);
            this.txtNamespace_Dal.Name = "txtNamespace_Dal";
            this.txtNamespace_Dal.Size = new System.Drawing.Size(208, 20);
            this.txtNamespace_Dal.TabIndex = 13;
            this.txtNamespace_Dal.Text = "Dao";
            this.txtNamespace_Dal.TextChanged += new System.EventHandler(this.txtNamespace_Dal_TextChanged);
            this.txtNamespace_Dal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNamespace_Dal_KeyUp);
            // 
            // txtNamespace_Bus
            // 
            this.txtNamespace_Bus.Location = new System.Drawing.Point(453, 27);
            this.txtNamespace_Bus.Name = "txtNamespace_Bus";
            this.txtNamespace_Bus.Size = new System.Drawing.Size(208, 20);
            this.txtNamespace_Bus.TabIndex = 14;
            this.txtNamespace_Bus.Text = "BCL";
            this.txtNamespace_Bus.TextChanged += new System.EventHandler(this.txtNamespace_Bus_TextChanged);
            this.txtNamespace_Bus.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNamespace_Bus_KeyUp);
            // 
            // lblNamespaceDto
            // 
            this.lblNamespaceDto.AutoSize = true;
            this.lblNamespaceDto.Location = new System.Drawing.Point(692, 110);
            this.lblNamespaceDto.Name = "lblNamespaceDto";
            this.lblNamespaceDto.Size = new System.Drawing.Size(90, 13);
            this.lblNamespaceDto.TabIndex = 9;
            this.lblNamespaceDto.Text = "Namespace DTO";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(352, 147);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(93, 13);
            this.label17.TabIndex = 9;
            this.label17.Text = "Namespace Entity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Namespace DTO";
            // 
            // lblNamespaceDal
            // 
            this.lblNamespaceDal.AutoSize = true;
            this.lblNamespaceDal.Location = new System.Drawing.Point(692, 70);
            this.lblNamespaceDal.Name = "lblNamespaceDal";
            this.lblNamespaceDal.Size = new System.Drawing.Size(88, 13);
            this.lblNamespaceDal.TabIndex = 10;
            this.lblNamespaceDal.Text = "Namespace DAL";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(667, 110);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 13);
            this.label20.TabIndex = 19;
            this.label20.Text = "ex:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(667, 70);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(21, 13);
            this.label19.TabIndex = 19;
            this.label19.Text = "ex:";
            // 
            // lblNamespaceBus
            // 
            this.lblNamespaceBus.AutoSize = true;
            this.lblNamespaceBus.Location = new System.Drawing.Point(692, 30);
            this.lblNamespaceBus.Name = "lblNamespaceBus";
            this.lblNamespaceBus.Size = new System.Drawing.Size(89, 13);
            this.lblNamespaceBus.TabIndex = 11;
            this.lblNamespaceBus.Text = "Namespace BUS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Namespace DAL";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(665, 30);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 13);
            this.label18.TabIndex = 20;
            this.label18.Text = "ex:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(352, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Namespace BUS";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTable);
            this.groupBox3.Controls.Add(this.txtResultTable);
            this.groupBox3.Controls.Add(this.listView);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Controls.Add(this.txtNew);
            this.groupBox3.Controls.Add(this.txtOld);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtFomat_Proc);
            this.groupBox3.Controls.Add(this.txtFomat_Dto);
            this.groupBox3.Controls.Add(this.txtFomat_Dal);
            this.groupBox3.Controls.Add(this.txtFomat_Bus);
            this.groupBox3.Controls.Add(this.lblFormatProc);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.lblFormatDto);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lblFormatDal);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lblFormatBus);
            this.groupBox3.Controls.Add(this.lbl);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 220);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(863, 261);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FORMAT-NAME";
            // 
            // listView
            // 
            this.listView.CheckBoxes = true;
            this.listView.Location = new System.Drawing.Point(387, 91);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(351, 158);
            this.listView.TabIndex = 24;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView_KeyUp);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(703, 40);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(35, 23);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtNew
            // 
            this.txtNew.Location = new System.Drawing.Point(561, 42);
            this.txtNew.Name = "txtNew";
            this.txtNew.Size = new System.Drawing.Size(131, 20);
            this.txtNew.TabIndex = 21;
            this.txtNew.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNew_KeyUp);
            // 
            // txtOld
            // 
            this.txtOld.Location = new System.Drawing.Point(424, 42);
            this.txtOld.Name = "txtOld";
            this.txtOld.Size = new System.Drawing.Size(131, 20);
            this.txtOld.TabIndex = 21;
            this.txtOld.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtOld_KeyUp);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(94, 237);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "ex:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(94, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "ex:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(94, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "ex:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(433, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "ex:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "ex:";
            // 
            // txtFomat_Proc
            // 
            this.txtFomat_Proc.Location = new System.Drawing.Point(96, 212);
            this.txtFomat_Proc.Name = "txtFomat_Proc";
            this.txtFomat_Proc.Size = new System.Drawing.Size(234, 20);
            this.txtFomat_Proc.TabIndex = 13;
            this.txtFomat_Proc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFomat_Proc_KeyUp);
            // 
            // txtFomat_Dto
            // 
            this.txtFomat_Dto.Location = new System.Drawing.Point(96, 160);
            this.txtFomat_Dto.Name = "txtFomat_Dto";
            this.txtFomat_Dto.Size = new System.Drawing.Size(234, 20);
            this.txtFomat_Dto.TabIndex = 14;
            this.txtFomat_Dto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFomat_Dto_KeyUp);
            // 
            // txtFomat_Dal
            // 
            this.txtFomat_Dal.Location = new System.Drawing.Point(96, 96);
            this.txtFomat_Dal.Name = "txtFomat_Dal";
            this.txtFomat_Dal.Size = new System.Drawing.Size(234, 20);
            this.txtFomat_Dal.TabIndex = 15;
            this.txtFomat_Dal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFomat_Dal_KeyUp);
            // 
            // txtFomat_Bus
            // 
            this.txtFomat_Bus.Location = new System.Drawing.Point(96, 38);
            this.txtFomat_Bus.Name = "txtFomat_Bus";
            this.txtFomat_Bus.Size = new System.Drawing.Size(234, 20);
            this.txtFomat_Bus.TabIndex = 16;
            this.txtFomat_Bus.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFomat_Bus_KeyUp);
            // 
            // lblFormatProc
            // 
            this.lblFormatProc.AutoSize = true;
            this.lblFormatProc.Location = new System.Drawing.Point(121, 237);
            this.lblFormatProc.Name = "lblFormatProc";
            this.lblFormatProc.Size = new System.Drawing.Size(61, 13);
            this.lblFormatProc.TabIndex = 5;
            this.lblFormatProc.Text = "Fomat Proc";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 215);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Fomat Proc";
            // 
            // lblFormatDto
            // 
            this.lblFormatDto.AutoSize = true;
            this.lblFormatDto.Location = new System.Drawing.Point(121, 185);
            this.lblFormatDto.Name = "lblFormatDto";
            this.lblFormatDto.Size = new System.Drawing.Size(62, 13);
            this.lblFormatDto.TabIndex = 7;
            this.lblFormatDto.Text = "Fomat DTO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Fomat DTO";
            // 
            // lblFormatDal
            // 
            this.lblFormatDal.AutoSize = true;
            this.lblFormatDal.Location = new System.Drawing.Point(121, 121);
            this.lblFormatDal.Name = "lblFormatDal";
            this.lblFormatDal.Size = new System.Drawing.Size(60, 13);
            this.lblFormatDal.TabIndex = 9;
            this.lblFormatDal.Text = "Fomat DAL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Fomat DAL";
            // 
            // lblFormatBus
            // 
            this.lblFormatBus.AutoSize = true;
            this.lblFormatBus.Location = new System.Drawing.Point(121, 63);
            this.lblFormatBus.Name = "lblFormatBus";
            this.lblFormatBus.Size = new System.Drawing.Size(61, 13);
            this.lblFormatBus.TabIndex = 11;
            this.lblFormatBus.Text = "Fomat BUS";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(349, 45);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(69, 13);
            this.lbl.TabIndex = 12;
            this.lbl.Text = "CustomTable";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Fomat BUS";
            // 
            // txtResultTable
            // 
            this.txtResultTable.Location = new System.Drawing.Point(460, 66);
            this.txtResultTable.Name = "txtResultTable";
            this.txtResultTable.ReadOnly = true;
            this.txtResultTable.Size = new System.Drawing.Size(211, 20);
            this.txtResultTable.TabIndex = 25;
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(460, 13);
            this.txtTable.Name = "txtTable";
            this.txtTable.ReadOnly = true;
            this.txtTable.Size = new System.Drawing.Size(211, 20);
            this.txtTable.TabIndex = 25;
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 524);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3. Setting";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDababase;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFomat_Proc;
        private System.Windows.Forms.TextBox txtFomat_Dto;
        private System.Windows.Forms.TextBox txtFomat_Dal;
        private System.Windows.Forms.TextBox txtFomat_Bus;
        private System.Windows.Forms.Label lblFormatProc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblFormatDto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblFormatDal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFormatBus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.TextBox txtOld;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtNamespace_Dto;
        private System.Windows.Forms.TextBox txtNamespace_Dal;
        private System.Windows.Forms.TextBox txtNamespace_Bus;
        private System.Windows.Forms.Label lblNamespaceDto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNamespaceDal;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblNamespaceBus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtFolderDto;
        private System.Windows.Forms.TextBox txtFolderDal;
        private System.Windows.Forms.TextBox txtFolderBus;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtEntity;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtResultTable;
        private System.Windows.Forms.TextBox txtTable;
    }
}