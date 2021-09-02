namespace NobelMoon.UI
{
    partial class frmAuthorize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuthorize));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.tpAir = new System.Windows.Forms.TabPage();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.chkaReport = new System.Windows.Forms.CheckBox();
            this.chkaHistory = new System.Windows.Forms.CheckBox();
            this.chkaNew = new System.Windows.Forms.CheckBox();
            this.tpHotel = new System.Windows.Forms.TabPage();
            this.chkhReport = new System.Windows.Forms.CheckBox();
            this.chkhHistory = new System.Windows.Forms.CheckBox();
            this.chkhNew = new System.Windows.Forms.CheckBox();
            this.tpTour = new System.Windows.Forms.TabPage();
            this.chktReport = new System.Windows.Forms.CheckBox();
            this.chktHistory = new System.Windows.Forms.CheckBox();
            this.chktNew = new System.Windows.Forms.CheckBox();
            this.tbPassport = new System.Windows.Forms.TabPage();
            this.chkpReport = new System.Windows.Forms.CheckBox();
            this.chkpHistory = new System.Windows.Forms.CheckBox();
            this.chkpNew = new System.Windows.Forms.CheckBox();
            this.tpCarrental = new System.Windows.Forms.TabPage();
            this.chkcReport = new System.Windows.Forms.CheckBox();
            this.chkcHistory = new System.Windows.Forms.CheckBox();
            this.chkcNew = new System.Windows.Forms.CheckBox();
            this.tbSetup = new System.Windows.Forms.TabPage();
            this.chksNew = new System.Windows.Forms.CheckBox();
            this.tpFile = new System.Windows.Forms.TabPage();
            this.chkfFingerPrint = new System.Windows.Forms.CheckBox();
            this.chkfAuthorize = new System.Windows.Forms.CheckBox();
            this.chkfBackup = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboUser = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkCash = new System.Windows.Forms.CheckBox();
            this.TabControl1.SuspendLayout();
            this.tpAir.SuspendLayout();
            this.tpHotel.SuspendLayout();
            this.tpTour.SuspendLayout();
            this.tbPassport.SuspendLayout();
            this.tpCarrental.SuspendLayout();
            this.tbSetup.SuspendLayout();
            this.tpFile.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.TabControl1.Controls.Add(this.tpAir);
            this.TabControl1.Controls.Add(this.tpHotel);
            this.TabControl1.Controls.Add(this.tpTour);
            this.TabControl1.Controls.Add(this.tbPassport);
            this.TabControl1.Controls.Add(this.tpCarrental);
            this.TabControl1.Controls.Add(this.tbSetup);
            this.TabControl1.Controls.Add(this.tpFile);
            this.TabControl1.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl1.Location = new System.Drawing.Point(10, 85);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(511, 221);
            this.TabControl1.TabIndex = 0;
            // 
            // tpAir
            // 
            this.tpAir.Controls.Add(this.btnReset);
            this.tpAir.Controls.Add(this.btnCheckAll);
            this.tpAir.Controls.Add(this.chkaReport);
            this.tpAir.Controls.Add(this.chkaHistory);
            this.tpAir.Controls.Add(this.chkaNew);
            this.tpAir.Location = new System.Drawing.Point(4, 32);
            this.tpAir.Name = "tpAir";
            this.tpAir.Padding = new System.Windows.Forms.Padding(3);
            this.tpAir.Size = new System.Drawing.Size(503, 185);
            this.tpAir.TabIndex = 0;
            this.tpAir.Text = " AirTicket ";
            this.tpAir.UseVisualStyleBackColor = true;
            this.tpAir.Paint += new System.Windows.Forms.PaintEventHandler(this.tpAir_Paint);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(407, 124);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 36);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Location = new System.Drawing.Point(309, 124);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(75, 36);
            this.btnCheckAll.TabIndex = 3;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // chkaReport
            // 
            this.chkaReport.AutoSize = true;
            this.chkaReport.Location = new System.Drawing.Point(15, 88);
            this.chkaReport.Name = "chkaReport";
            this.chkaReport.Size = new System.Drawing.Size(65, 24);
            this.chkaReport.TabIndex = 2;
            this.chkaReport.Text = "Report";
            this.chkaReport.UseVisualStyleBackColor = true;
            // 
            // chkaHistory
            // 
            this.chkaHistory.AutoSize = true;
            this.chkaHistory.Location = new System.Drawing.Point(15, 56);
            this.chkaHistory.Name = "chkaHistory";
            this.chkaHistory.Size = new System.Drawing.Size(65, 24);
            this.chkaHistory.TabIndex = 1;
            this.chkaHistory.Text = "History";
            this.chkaHistory.UseVisualStyleBackColor = true;
            // 
            // chkaNew
            // 
            this.chkaNew.AutoSize = true;
            this.chkaNew.Location = new System.Drawing.Point(15, 24);
            this.chkaNew.Name = "chkaNew";
            this.chkaNew.Size = new System.Drawing.Size(53, 24);
            this.chkaNew.TabIndex = 0;
            this.chkaNew.Text = "New";
            this.chkaNew.UseVisualStyleBackColor = true;
            // 
            // tpHotel
            // 
            this.tpHotel.Controls.Add(this.chkhReport);
            this.tpHotel.Controls.Add(this.chkhHistory);
            this.tpHotel.Controls.Add(this.chkhNew);
            this.tpHotel.Location = new System.Drawing.Point(4, 32);
            this.tpHotel.Name = "tpHotel";
            this.tpHotel.Padding = new System.Windows.Forms.Padding(3);
            this.tpHotel.Size = new System.Drawing.Size(503, 185);
            this.tpHotel.TabIndex = 1;
            this.tpHotel.Text = " Hotel ";
            this.tpHotel.UseVisualStyleBackColor = true;
            this.tpHotel.Paint += new System.Windows.Forms.PaintEventHandler(this.tpHotel_Paint);
            // 
            // chkhReport
            // 
            this.chkhReport.AutoSize = true;
            this.chkhReport.Location = new System.Drawing.Point(22, 88);
            this.chkhReport.Name = "chkhReport";
            this.chkhReport.Size = new System.Drawing.Size(65, 24);
            this.chkhReport.TabIndex = 7;
            this.chkhReport.Text = "Report";
            this.chkhReport.UseVisualStyleBackColor = true;
            // 
            // chkhHistory
            // 
            this.chkhHistory.AutoSize = true;
            this.chkhHistory.Location = new System.Drawing.Point(22, 56);
            this.chkhHistory.Name = "chkhHistory";
            this.chkhHistory.Size = new System.Drawing.Size(65, 24);
            this.chkhHistory.TabIndex = 6;
            this.chkhHistory.Text = "History";
            this.chkhHistory.UseVisualStyleBackColor = true;
            // 
            // chkhNew
            // 
            this.chkhNew.AutoSize = true;
            this.chkhNew.Location = new System.Drawing.Point(22, 24);
            this.chkhNew.Name = "chkhNew";
            this.chkhNew.Size = new System.Drawing.Size(53, 24);
            this.chkhNew.TabIndex = 5;
            this.chkhNew.Text = "New";
            this.chkhNew.UseVisualStyleBackColor = true;
            // 
            // tpTour
            // 
            this.tpTour.Controls.Add(this.chktReport);
            this.tpTour.Controls.Add(this.chktHistory);
            this.tpTour.Controls.Add(this.chktNew);
            this.tpTour.Location = new System.Drawing.Point(4, 32);
            this.tpTour.Name = "tpTour";
            this.tpTour.Size = new System.Drawing.Size(503, 185);
            this.tpTour.TabIndex = 2;
            this.tpTour.Text = " TourPackage ";
            this.tpTour.UseVisualStyleBackColor = true;
            this.tpTour.Paint += new System.Windows.Forms.PaintEventHandler(this.tpTour_Paint);
            // 
            // chktReport
            // 
            this.chktReport.AutoSize = true;
            this.chktReport.Location = new System.Drawing.Point(22, 88);
            this.chktReport.Name = "chktReport";
            this.chktReport.Size = new System.Drawing.Size(65, 24);
            this.chktReport.TabIndex = 7;
            this.chktReport.Text = "Report";
            this.chktReport.UseVisualStyleBackColor = true;
            // 
            // chktHistory
            // 
            this.chktHistory.AutoSize = true;
            this.chktHistory.Location = new System.Drawing.Point(22, 56);
            this.chktHistory.Name = "chktHistory";
            this.chktHistory.Size = new System.Drawing.Size(65, 24);
            this.chktHistory.TabIndex = 6;
            this.chktHistory.Text = "History";
            this.chktHistory.UseVisualStyleBackColor = true;
            // 
            // chktNew
            // 
            this.chktNew.AutoSize = true;
            this.chktNew.Location = new System.Drawing.Point(22, 24);
            this.chktNew.Name = "chktNew";
            this.chktNew.Size = new System.Drawing.Size(53, 24);
            this.chktNew.TabIndex = 5;
            this.chktNew.Text = "New";
            this.chktNew.UseVisualStyleBackColor = true;
            // 
            // tbPassport
            // 
            this.tbPassport.Controls.Add(this.chkpReport);
            this.tbPassport.Controls.Add(this.chkpHistory);
            this.tbPassport.Controls.Add(this.chkpNew);
            this.tbPassport.Location = new System.Drawing.Point(4, 32);
            this.tbPassport.Name = "tbPassport";
            this.tbPassport.Size = new System.Drawing.Size(503, 185);
            this.tbPassport.TabIndex = 3;
            this.tbPassport.Text = " Passport ";
            this.tbPassport.UseVisualStyleBackColor = true;
            this.tbPassport.Paint += new System.Windows.Forms.PaintEventHandler(this.tbPassport_Paint);
            // 
            // chkpReport
            // 
            this.chkpReport.AutoSize = true;
            this.chkpReport.Location = new System.Drawing.Point(22, 88);
            this.chkpReport.Name = "chkpReport";
            this.chkpReport.Size = new System.Drawing.Size(65, 24);
            this.chkpReport.TabIndex = 7;
            this.chkpReport.Text = "Report";
            this.chkpReport.UseVisualStyleBackColor = true;
            // 
            // chkpHistory
            // 
            this.chkpHistory.AutoSize = true;
            this.chkpHistory.Location = new System.Drawing.Point(22, 56);
            this.chkpHistory.Name = "chkpHistory";
            this.chkpHistory.Size = new System.Drawing.Size(65, 24);
            this.chkpHistory.TabIndex = 6;
            this.chkpHistory.Text = "History";
            this.chkpHistory.UseVisualStyleBackColor = true;
            // 
            // chkpNew
            // 
            this.chkpNew.AutoSize = true;
            this.chkpNew.Location = new System.Drawing.Point(22, 24);
            this.chkpNew.Name = "chkpNew";
            this.chkpNew.Size = new System.Drawing.Size(53, 24);
            this.chkpNew.TabIndex = 5;
            this.chkpNew.Text = "New";
            this.chkpNew.UseVisualStyleBackColor = true;
            // 
            // tpCarrental
            // 
            this.tpCarrental.Controls.Add(this.chkcReport);
            this.tpCarrental.Controls.Add(this.chkcHistory);
            this.tpCarrental.Controls.Add(this.chkcNew);
            this.tpCarrental.Location = new System.Drawing.Point(4, 32);
            this.tpCarrental.Name = "tpCarrental";
            this.tpCarrental.Size = new System.Drawing.Size(503, 185);
            this.tpCarrental.TabIndex = 4;
            this.tpCarrental.Text = " CarRental ";
            this.tpCarrental.UseVisualStyleBackColor = true;
            this.tpCarrental.Paint += new System.Windows.Forms.PaintEventHandler(this.tpCarrental_Paint);
            // 
            // chkcReport
            // 
            this.chkcReport.AutoSize = true;
            this.chkcReport.Location = new System.Drawing.Point(22, 88);
            this.chkcReport.Name = "chkcReport";
            this.chkcReport.Size = new System.Drawing.Size(65, 24);
            this.chkcReport.TabIndex = 7;
            this.chkcReport.Text = "Report";
            this.chkcReport.UseVisualStyleBackColor = true;
            // 
            // chkcHistory
            // 
            this.chkcHistory.AutoSize = true;
            this.chkcHistory.Location = new System.Drawing.Point(22, 56);
            this.chkcHistory.Name = "chkcHistory";
            this.chkcHistory.Size = new System.Drawing.Size(65, 24);
            this.chkcHistory.TabIndex = 6;
            this.chkcHistory.Text = "History";
            this.chkcHistory.UseVisualStyleBackColor = true;
            // 
            // chkcNew
            // 
            this.chkcNew.AutoSize = true;
            this.chkcNew.Location = new System.Drawing.Point(22, 24);
            this.chkcNew.Name = "chkcNew";
            this.chkcNew.Size = new System.Drawing.Size(53, 24);
            this.chkcNew.TabIndex = 5;
            this.chkcNew.Text = "New";
            this.chkcNew.UseVisualStyleBackColor = true;
            // 
            // tbSetup
            // 
            this.tbSetup.Controls.Add(this.chksNew);
            this.tbSetup.Location = new System.Drawing.Point(4, 32);
            this.tbSetup.Name = "tbSetup";
            this.tbSetup.Size = new System.Drawing.Size(503, 185);
            this.tbSetup.TabIndex = 5;
            this.tbSetup.Text = " Setup ";
            this.tbSetup.UseVisualStyleBackColor = true;
            this.tbSetup.Paint += new System.Windows.Forms.PaintEventHandler(this.tbSetup_Paint_1);
            // 
            // chksNew
            // 
            this.chksNew.AutoSize = true;
            this.chksNew.Location = new System.Drawing.Point(22, 24);
            this.chksNew.Name = "chksNew";
            this.chksNew.Size = new System.Drawing.Size(53, 24);
            this.chksNew.TabIndex = 5;
            this.chksNew.Text = "New";
            this.chksNew.UseVisualStyleBackColor = true;
            // 
            // tpFile
            // 
            this.tpFile.BackColor = System.Drawing.Color.Transparent;
            this.tpFile.Controls.Add(this.chkCash);
            this.tpFile.Controls.Add(this.chkfFingerPrint);
            this.tpFile.Controls.Add(this.chkfAuthorize);
            this.tpFile.Controls.Add(this.chkfBackup);
            this.tpFile.Location = new System.Drawing.Point(4, 32);
            this.tpFile.Name = "tpFile";
            this.tpFile.Padding = new System.Windows.Forms.Padding(3);
            this.tpFile.Size = new System.Drawing.Size(503, 185);
            this.tpFile.TabIndex = 6;
            this.tpFile.Text = " File ";
            this.tpFile.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPage7_Paint);
            // 
            // chkfFingerPrint
            // 
            this.chkfFingerPrint.AutoSize = true;
            this.chkfFingerPrint.Location = new System.Drawing.Point(21, 117);
            this.chkfFingerPrint.Name = "chkfFingerPrint";
            this.chkfFingerPrint.Size = new System.Drawing.Size(90, 24);
            this.chkfFingerPrint.TabIndex = 7;
            this.chkfFingerPrint.Text = "Finger Print";
            this.chkfFingerPrint.UseVisualStyleBackColor = true;
            // 
            // chkfAuthorize
            // 
            this.chkfAuthorize.AutoSize = true;
            this.chkfAuthorize.Location = new System.Drawing.Point(21, 58);
            this.chkfAuthorize.Name = "chkfAuthorize";
            this.chkfAuthorize.Size = new System.Drawing.Size(80, 24);
            this.chkfAuthorize.TabIndex = 6;
            this.chkfAuthorize.Text = "Authorize";
            this.chkfAuthorize.UseVisualStyleBackColor = true;
            // 
            // chkfBackup
            // 
            this.chkfBackup.AutoSize = true;
            this.chkfBackup.Location = new System.Drawing.Point(21, 26);
            this.chkfBackup.Name = "chkfBackup";
            this.chkfBackup.Size = new System.Drawing.Size(67, 24);
            this.chkfBackup.TabIndex = 5;
            this.chkfBackup.Text = "Backup";
            this.chkfBackup.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(551, 35);
            this.panel1.TabIndex = 26;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnMinimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinimize.BackgroundImage")));
            this.btnMinimize.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Zawgyi-One", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.Location = new System.Drawing.Point(478, 2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(33, 32);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Zawgyi-One", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(514, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 32);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 27;
            this.label1.Text = "Staff  Name  :";
            // 
            // cboUser
            // 
            this.cboUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUser.FormattingEnabled = true;
            this.cboUser.Location = new System.Drawing.Point(110, 36);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(158, 23);
            this.cboUser.TabIndex = 28;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.TabControl1);
            this.groupBox1.Controls.Add(this.cboUser);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 325);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Authorized User";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.NavajoWhite;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(276, 378);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 37);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.NavajoWhite;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(185, 378);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 37);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkCash
            // 
            this.chkCash.AutoSize = true;
            this.chkCash.Location = new System.Drawing.Point(21, 87);
            this.chkCash.Name = "chkCash";
            this.chkCash.Size = new System.Drawing.Size(53, 24);
            this.chkCash.TabIndex = 8;
            this.chkCash.Text = "Cash";
            this.chkCash.UseVisualStyleBackColor = true;
            // 
            // frmAuthorize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(551, 427);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAuthorize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAuthorize";
            this.Load += new System.EventHandler(this.frmAuthorize_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmAuthorize_Paint);
            this.TabControl1.ResumeLayout(false);
            this.tpAir.ResumeLayout(false);
            this.tpAir.PerformLayout();
            this.tpHotel.ResumeLayout(false);
            this.tpHotel.PerformLayout();
            this.tpTour.ResumeLayout(false);
            this.tpTour.PerformLayout();
            this.tbPassport.ResumeLayout(false);
            this.tbPassport.PerformLayout();
            this.tpCarrental.ResumeLayout(false);
            this.tpCarrental.PerformLayout();
            this.tbSetup.ResumeLayout(false);
            this.tbSetup.PerformLayout();
            this.tpFile.ResumeLayout(false);
            this.tpFile.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl1;
        private System.Windows.Forms.TabPage tpAir;
        private System.Windows.Forms.TabPage tpHotel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.CheckBox chkaReport;
        private System.Windows.Forms.CheckBox chkaHistory;
        private System.Windows.Forms.CheckBox chkaNew;
        private System.Windows.Forms.CheckBox chkhReport;
        private System.Windows.Forms.CheckBox chkhHistory;
        private System.Windows.Forms.CheckBox chkhNew;
        private System.Windows.Forms.TabPage tpTour;
        private System.Windows.Forms.CheckBox chktReport;
        private System.Windows.Forms.CheckBox chktHistory;
        private System.Windows.Forms.CheckBox chktNew;
        private System.Windows.Forms.TabPage tbPassport;
        private System.Windows.Forms.CheckBox chkpReport;
        private System.Windows.Forms.CheckBox chkpHistory;
        private System.Windows.Forms.CheckBox chkpNew;
        private System.Windows.Forms.TabPage tpCarrental;
        private System.Windows.Forms.CheckBox chkcReport;
        private System.Windows.Forms.CheckBox chkcHistory;
        private System.Windows.Forms.CheckBox chkcNew;
        private System.Windows.Forms.TabPage tbSetup;
        private System.Windows.Forms.CheckBox chksNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tpFile;
        private System.Windows.Forms.CheckBox chkfFingerPrint;
        private System.Windows.Forms.CheckBox chkfAuthorize;
        private System.Windows.Forms.CheckBox chkfBackup;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkCash;
    }
}