namespace NobelMoon.UI
{
    partial class frmHotelBooking
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHotelBooking));
            this.cbohHotel = new System.Windows.Forms.ComboBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label170 = new System.Windows.Forms.Label();
            this.txthCurRate = new System.Windows.Forms.TextBox();
            this.txthAddress = new System.Windows.Forms.TextBox();
            this.label95 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.cbohPaymentTerm = new System.Windows.Forms.ComboBox();
            this.cbohCurrency = new System.Windows.Forms.ComboBox();
            this.label90 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.btnhAdd = new System.Windows.Forms.Button();
            this.txthAmount = new System.Windows.Forms.TextBox();
            this.txtRoomNo = new System.Windows.Forms.TextBox();
            this.txthRate = new System.Windows.Forms.TextBox();
            this.cboRoomType = new System.Windows.Forms.ComboBox();
            this.label84 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.dgvRoom = new System.Windows.Forms.DataGridView();
            this.colRType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNofN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colhAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnhDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colhrID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtphHotelBooking = new System.Windows.Forms.DateTimePicker();
            this.dtpDepatureDate = new System.Windows.Forms.DateTimePicker();
            this.dtpArrivalDate = new System.Windows.Forms.DateTimePicker();
            this.txthRemark = new System.Windows.Forms.TextBox();
            this.label75 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.txtNightNo = new System.Windows.Forms.TextBox();
            this.txtPaxNo = new System.Windows.Forms.TextBox();
            this.txthEmail = new System.Windows.Forms.TextBox();
            this.txthContactPhone = new System.Windows.Forms.TextBox();
            this.txthCompanyName = new System.Windows.Forms.TextBox();
            this.txthContactPerson = new System.Windows.Forms.TextBox();
            this.txthInvoiceNo = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.chkhOtherServices = new System.Windows.Forms.CheckedListBox();
            this.btnhOtherServices = new System.Windows.Forms.Button();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label97 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label94 = new System.Windows.Forms.Label();
            this.txtTotalhAmount = new System.Windows.Forms.TextBox();
            this.txtTotalRoom = new System.Windows.Forms.TextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.btnhPreview = new System.Windows.Forms.Button();
            this.btnhCancel = new System.Windows.Forms.Button();
            this.btnHotelBooking = new System.Windows.Forms.Button();
            this.txthSupplier = new System.Windows.Forms.TextBox();
            this.label214 = new System.Windows.Forms.Label();
            this.label215 = new System.Windows.Forms.Label();
            this.cbohIncomeType = new System.Windows.Forms.ComboBox();
            this.label223 = new System.Windows.Forms.Label();
            this.label228 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // cbohHotel
            // 
            this.cbohHotel.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbohHotel.ForeColor = System.Drawing.Color.Black;
            this.cbohHotel.FormattingEnabled = true;
            this.cbohHotel.Location = new System.Drawing.Point(458, 210);
            this.cbohHotel.Name = "cbohHotel";
            this.cbohHotel.Size = new System.Drawing.Size(153, 26);
            this.cbohHotel.TabIndex = 351;
            this.cbohHotel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbohHotel_KeyDown);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.BackColor = System.Drawing.Color.Transparent;
            this.label51.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(442, 214);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(13, 18);
            this.label51.TabIndex = 350;
            this.label51.Text = ":";
            // 
            // label170
            // 
            this.label170.AutoSize = true;
            this.label170.BackColor = System.Drawing.Color.Transparent;
            this.label170.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label170.Location = new System.Drawing.Point(341, 214);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(73, 18);
            this.label170.TabIndex = 349;
            this.label170.Text = "Hotel Name";
            // 
            // txthCurRate
            // 
            this.txthCurRate.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthCurRate.ForeColor = System.Drawing.Color.Black;
            this.txthCurRate.Location = new System.Drawing.Point(232, 152);
            this.txthCurRate.Name = "txthCurRate";
            this.txthCurRate.Size = new System.Drawing.Size(88, 25);
            this.txthCurRate.TabIndex = 348;
            this.txthCurRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txthCurrate_KeyDown);
            // 
            // txthAddress
            // 
            this.txthAddress.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthAddress.ForeColor = System.Drawing.Color.Black;
            this.txthAddress.Location = new System.Drawing.Point(145, 181);
            this.txthAddress.Multiline = true;
            this.txthAddress.Name = "txthAddress";
            this.txthAddress.Size = new System.Drawing.Size(175, 62);
            this.txthAddress.TabIndex = 347;
            this.txthAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txthAddress_KeyDown);
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.BackColor = System.Drawing.Color.Transparent;
            this.label95.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label95.Location = new System.Drawing.Point(130, 185);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(13, 18);
            this.label95.TabIndex = 346;
            this.label95.Text = ":";
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.BackColor = System.Drawing.Color.Transparent;
            this.label96.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label96.Location = new System.Drawing.Point(32, 185);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(54, 18);
            this.label96.TabIndex = 345;
            this.label96.Text = "Address";
            // 
            // cbohPaymentTerm
            // 
            this.cbohPaymentTerm.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbohPaymentTerm.ForeColor = System.Drawing.Color.Black;
            this.cbohPaymentTerm.FormattingEnabled = true;
            this.cbohPaymentTerm.Location = new System.Drawing.Point(458, 152);
            this.cbohPaymentTerm.Name = "cbohPaymentTerm";
            this.cbohPaymentTerm.Size = new System.Drawing.Size(153, 26);
            this.cbohPaymentTerm.TabIndex = 344;
            this.cbohPaymentTerm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbohPaymentTerm_KeyDown);
            // 
            // cbohCurrency
            // 
            this.cbohCurrency.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbohCurrency.FormattingEnabled = true;
            this.cbohCurrency.Location = new System.Drawing.Point(145, 152);
            this.cbohCurrency.Name = "cbohCurrency";
            this.cbohCurrency.Size = new System.Drawing.Size(82, 26);
            this.cbohCurrency.TabIndex = 343;
            this.cbohCurrency.SelectedIndexChanged += new System.EventHandler(this.cbohCurrency_SelectedIndexChanged);
            this.cbohCurrency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbohCurrency_KeyDown);
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.BackColor = System.Drawing.Color.Transparent;
            this.label90.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.Location = new System.Drawing.Point(442, 156);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(13, 18);
            this.label90.TabIndex = 342;
            this.label90.Text = ":";
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.BackColor = System.Drawing.Color.Transparent;
            this.label93.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label93.Location = new System.Drawing.Point(341, 156);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(89, 18);
            this.label93.TabIndex = 341;
            this.label93.Text = "Payment Term";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.BackColor = System.Drawing.Color.Transparent;
            this.label59.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.Location = new System.Drawing.Point(130, 156);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(13, 18);
            this.label59.TabIndex = 340;
            this.label59.Text = ":";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.BackColor = System.Drawing.Color.Transparent;
            this.label73.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.Location = new System.Drawing.Point(32, 157);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(60, 18);
            this.label73.TabIndex = 339;
            this.label73.Text = "Currency";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.BackColor = System.Drawing.Color.Transparent;
            this.label87.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.Location = new System.Drawing.Point(411, 304);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(14, 20);
            this.label87.TabIndex = 338;
            this.label87.Text = "-";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.BackColor = System.Drawing.Color.Transparent;
            this.label86.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label86.Location = new System.Drawing.Point(331, 306);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(14, 20);
            this.label86.TabIndex = 337;
            this.label86.Text = "-";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.BackColor = System.Drawing.Color.Transparent;
            this.label85.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label85.Location = new System.Drawing.Point(256, 306);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(14, 20);
            this.label85.TabIndex = 336;
            this.label85.Text = "-";
            // 
            // btnhAdd
            // 
            this.btnhAdd.BackColor = System.Drawing.Color.Navy;
            this.btnhAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhAdd.ForeColor = System.Drawing.Color.White;
            this.btnhAdd.Location = new System.Drawing.Point(504, 297);
            this.btnhAdd.Name = "btnhAdd";
            this.btnhAdd.Size = new System.Drawing.Size(55, 30);
            this.btnhAdd.TabIndex = 335;
            this.btnhAdd.Text = "Add";
            this.btnhAdd.UseVisualStyleBackColor = false;
            this.btnhAdd.Click += new System.EventHandler(this.btnhAdd_Click);
            // 
            // txthAmount
            // 
            this.txthAmount.Enabled = false;
            this.txthAmount.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthAmount.ForeColor = System.Drawing.Color.Black;
            this.txthAmount.Location = new System.Drawing.Point(429, 302);
            this.txthAmount.Name = "txthAmount";
            this.txthAmount.Size = new System.Drawing.Size(59, 25);
            this.txthAmount.TabIndex = 334;
            // 
            // txtRoomNo
            // 
            this.txtRoomNo.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomNo.ForeColor = System.Drawing.Color.Black;
            this.txtRoomNo.Location = new System.Drawing.Point(348, 302);
            this.txtRoomNo.Name = "txtRoomNo";
            this.txtRoomNo.Size = new System.Drawing.Size(59, 25);
            this.txtRoomNo.TabIndex = 333;
            this.txtRoomNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRoomNo_KeyDown);
            // 
            // txthRate
            // 
            this.txthRate.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthRate.ForeColor = System.Drawing.Color.Black;
            this.txthRate.Location = new System.Drawing.Point(270, 302);
            this.txthRate.Name = "txthRate";
            this.txthRate.Size = new System.Drawing.Size(59, 25);
            this.txthRate.TabIndex = 332;
            this.txthRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txthRate_KeyDown);
            // 
            // cboRoomType
            // 
            this.cboRoomType.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRoomType.ForeColor = System.Drawing.Color.Black;
            this.cboRoomType.FormattingEnabled = true;
            this.cboRoomType.Location = new System.Drawing.Point(34, 302);
            this.cboRoomType.Name = "cboRoomType";
            this.cboRoomType.Size = new System.Drawing.Size(221, 26);
            this.cboRoomType.TabIndex = 331;
            this.cboRoomType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboRoomType_KeyDown);
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.BackColor = System.Drawing.Color.Transparent;
            this.label84.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label84.Location = new System.Drawing.Point(432, 280);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(51, 18);
            this.label84.TabIndex = 330;
            this.label84.Text = "Amount";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.BackColor = System.Drawing.Color.Transparent;
            this.label83.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label83.Location = new System.Drawing.Point(343, 280);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(74, 18);
            this.label83.TabIndex = 329;
            this.label83.Text = "No of Room";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.BackColor = System.Drawing.Color.Transparent;
            this.label82.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label82.Location = new System.Drawing.Point(282, 280);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(35, 18);
            this.label82.TabIndex = 328;
            this.label82.Text = "Rate";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.BackColor = System.Drawing.Color.Transparent;
            this.label81.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label81.Location = new System.Drawing.Point(41, 280);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(210, 18);
            this.label81.TabIndex = 327;
            this.label81.Text = "- - - - - - - - Room Type - - - - - - - ";
            // 
            // dgvRoom
            // 
            this.dgvRoom.AllowUserToAddRows = false;
            this.dgvRoom.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRType,
            this.colRate,
            this.colNofN,
            this.colhAmount,
            this.btnhDelete,
            this.colhrID,
            this.colRCode});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRoom.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRoom.Location = new System.Drawing.Point(32, 337);
            this.dgvRoom.Name = "dgvRoom";
            this.dgvRoom.RowHeadersVisible = false;
            this.dgvRoom.Size = new System.Drawing.Size(585, 213);
            this.dgvRoom.TabIndex = 294;
            this.dgvRoom.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoom_CellClick);
            this.dgvRoom.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoom_CellEndEdit);
            // 
            // colRType
            // 
            this.colRType.HeaderText = "RoomType";
            this.colRType.Name = "colRType";
            this.colRType.Width = 200;
            // 
            // colRate
            // 
            this.colRate.HeaderText = "Rate";
            this.colRate.Name = "colRate";
            this.colRate.Width = 90;
            // 
            // colNofN
            // 
            this.colNofN.HeaderText = "Room";
            this.colNofN.Name = "colNofN";
            // 
            // colhAmount
            // 
            this.colhAmount.HeaderText = "Amount";
            this.colhAmount.Name = "colhAmount";
            this.colhAmount.Width = 120;
            // 
            // btnhDelete
            // 
            this.btnhDelete.HeaderText = "Delete";
            this.btnhDelete.Name = "btnhDelete";
            this.btnhDelete.ReadOnly = true;
            this.btnhDelete.Text = "Delete";
            this.btnhDelete.UseColumnTextForButtonValue = true;
            this.btnhDelete.Width = 70;
            // 
            // colhrID
            // 
            this.colhrID.HeaderText = "ID";
            this.colhrID.Name = "colhrID";
            this.colhrID.ReadOnly = true;
            this.colhrID.Visible = false;
            // 
            // colRCode
            // 
            this.colRCode.HeaderText = "Code";
            this.colRCode.Name = "colRCode";
            this.colRCode.ReadOnly = true;
            this.colRCode.Visible = false;
            // 
            // dtphHotelBooking
            // 
            this.dtphHotelBooking.CalendarForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtphHotelBooking.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtphHotelBooking.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtphHotelBooking.Location = new System.Drawing.Point(459, 9);
            this.dtphHotelBooking.Name = "dtphHotelBooking";
            this.dtphHotelBooking.Size = new System.Drawing.Size(108, 25);
            this.dtphHotelBooking.TabIndex = 326;
            this.dtphHotelBooking.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtphHotelBooking_KeyDown);
            // 
            // dtpDepatureDate
            // 
            this.dtpDepatureDate.CalendarForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtpDepatureDate.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDepatureDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDepatureDate.Location = new System.Drawing.Point(459, 67);
            this.dtpDepatureDate.Name = "dtpDepatureDate";
            this.dtpDepatureDate.Size = new System.Drawing.Size(108, 25);
            this.dtpDepatureDate.TabIndex = 325;
            this.dtpDepatureDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDepatureDate_KeyDown);
            // 
            // dtpArrivalDate
            // 
            this.dtpArrivalDate.CalendarForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtpArrivalDate.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpArrivalDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpArrivalDate.Location = new System.Drawing.Point(459, 38);
            this.dtpArrivalDate.Name = "dtpArrivalDate";
            this.dtpArrivalDate.Size = new System.Drawing.Size(108, 25);
            this.dtpArrivalDate.TabIndex = 324;
            this.dtpArrivalDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpArrivalDate_KeyDown);
            // 
            // txthRemark
            // 
            this.txthRemark.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthRemark.ForeColor = System.Drawing.Color.Black;
            this.txthRemark.Location = new System.Drawing.Point(459, 239);
            this.txthRemark.Multiline = true;
            this.txthRemark.Name = "txthRemark";
            this.txthRemark.Size = new System.Drawing.Size(152, 33);
            this.txthRemark.TabIndex = 323;
            this.txthRemark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txthRemark_KeyDown);
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.BackColor = System.Drawing.Color.Transparent;
            this.label75.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.Location = new System.Drawing.Point(442, 242);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(13, 18);
            this.label75.TabIndex = 322;
            this.label75.Text = ":";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.BackColor = System.Drawing.Color.Transparent;
            this.label76.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.Location = new System.Drawing.Point(341, 242);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(50, 18);
            this.label76.TabIndex = 321;
            this.label76.Text = "Remark";
            // 
            // txtNightNo
            // 
            this.txtNightNo.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNightNo.ForeColor = System.Drawing.Color.Black;
            this.txtNightNo.Location = new System.Drawing.Point(459, 124);
            this.txtNightNo.Name = "txtNightNo";
            this.txtNightNo.Size = new System.Drawing.Size(72, 25);
            this.txtNightNo.TabIndex = 320;
            this.txtNightNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNightNo_KeyDown);
            // 
            // txtPaxNo
            // 
            this.txtPaxNo.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaxNo.ForeColor = System.Drawing.Color.Black;
            this.txtPaxNo.Location = new System.Drawing.Point(459, 96);
            this.txtPaxNo.Name = "txtPaxNo";
            this.txtPaxNo.Size = new System.Drawing.Size(72, 25);
            this.txtPaxNo.TabIndex = 319;
            this.txtPaxNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPaxNo_KeyDown);
            // 
            // txthEmail
            // 
            this.txthEmail.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthEmail.ForeColor = System.Drawing.Color.Black;
            this.txthEmail.Location = new System.Drawing.Point(145, 123);
            this.txthEmail.Name = "txthEmail";
            this.txthEmail.Size = new System.Drawing.Size(175, 25);
            this.txthEmail.TabIndex = 318;
            this.txthEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txthEmail_KeyDown);
            // 
            // txthContactPhone
            // 
            this.txthContactPhone.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthContactPhone.ForeColor = System.Drawing.Color.Black;
            this.txthContactPhone.Location = new System.Drawing.Point(145, 95);
            this.txthContactPhone.Name = "txthContactPhone";
            this.txthContactPhone.Size = new System.Drawing.Size(174, 25);
            this.txthContactPhone.TabIndex = 317;
            this.txthContactPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txthContactPhone_KeyDown);
            // 
            // txthCompanyName
            // 
            this.txthCompanyName.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthCompanyName.ForeColor = System.Drawing.Color.Black;
            this.txthCompanyName.Location = new System.Drawing.Point(145, 67);
            this.txthCompanyName.Name = "txthCompanyName";
            this.txthCompanyName.Size = new System.Drawing.Size(174, 25);
            this.txthCompanyName.TabIndex = 316;
            this.txthCompanyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txthCompanyName_KeyDown);
            // 
            // txthContactPerson
            // 
            this.txthContactPerson.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthContactPerson.ForeColor = System.Drawing.Color.Black;
            this.txthContactPerson.Location = new System.Drawing.Point(145, 39);
            this.txthContactPerson.Name = "txthContactPerson";
            this.txthContactPerson.Size = new System.Drawing.Size(174, 25);
            this.txthContactPerson.TabIndex = 315;
            this.txthContactPerson.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txthContactPerson_KeyDown);
            // 
            // txthInvoiceNo
            // 
            this.txthInvoiceNo.Enabled = false;
            this.txthInvoiceNo.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthInvoiceNo.ForeColor = System.Drawing.Color.Black;
            this.txthInvoiceNo.Location = new System.Drawing.Point(145, 11);
            this.txthInvoiceNo.Name = "txthInvoiceNo";
            this.txthInvoiceNo.Size = new System.Drawing.Size(174, 25);
            this.txthInvoiceNo.TabIndex = 314;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.BackColor = System.Drawing.Color.Transparent;
            this.label77.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.Location = new System.Drawing.Point(441, 129);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(13, 18);
            this.label77.TabIndex = 313;
            this.label77.Text = ":";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.BackColor = System.Drawing.Color.Transparent;
            this.label78.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.Location = new System.Drawing.Point(340, 128);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(73, 18);
            this.label78.TabIndex = 312;
            this.label78.Text = "No of Night";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.BackColor = System.Drawing.Color.Transparent;
            this.label71.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.Location = new System.Drawing.Point(339, 99);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(102, 18);
            this.label71.TabIndex = 311;
            this.label71.Text = "No of Passenger";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.BackColor = System.Drawing.Color.Transparent;
            this.label72.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.Location = new System.Drawing.Point(441, 100);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(13, 18);
            this.label72.TabIndex = 310;
            this.label72.Text = ":";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.BackColor = System.Drawing.Color.Transparent;
            this.label74.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.Location = new System.Drawing.Point(338, 43);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(77, 18);
            this.label74.TabIndex = 309;
            this.label74.Text = "Arrival Date";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.BackColor = System.Drawing.Color.Transparent;
            this.label69.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.Location = new System.Drawing.Point(132, 17);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(13, 18);
            this.label69.TabIndex = 308;
            this.label69.Text = ":";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.BackColor = System.Drawing.Color.Transparent;
            this.label70.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.Location = new System.Drawing.Point(33, 18);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(69, 18);
            this.label70.TabIndex = 307;
            this.label70.Text = "Invoice No";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.BackColor = System.Drawing.Color.Transparent;
            this.label68.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.Location = new System.Drawing.Point(338, 71);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(97, 18);
            this.label68.TabIndex = 306;
            this.label68.Text = "Departure Date";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.BackColor = System.Drawing.Color.Transparent;
            this.label67.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.Location = new System.Drawing.Point(130, 128);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(13, 18);
            this.label67.TabIndex = 305;
            this.label67.Text = ":";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.BackColor = System.Drawing.Color.Transparent;
            this.label66.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.Location = new System.Drawing.Point(442, 13);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(13, 18);
            this.label66.TabIndex = 304;
            this.label66.Text = ":";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.BackColor = System.Drawing.Color.Transparent;
            this.label65.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.Location = new System.Drawing.Point(441, 72);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(13, 18);
            this.label65.TabIndex = 303;
            this.label65.Text = ":";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.BackColor = System.Drawing.Color.Transparent;
            this.label64.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label64.Location = new System.Drawing.Point(441, 43);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(13, 18);
            this.label64.TabIndex = 302;
            this.label64.Text = ":";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.BackColor = System.Drawing.Color.Transparent;
            this.label63.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.Location = new System.Drawing.Point(131, 100);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(13, 18);
            this.label63.TabIndex = 301;
            this.label63.Text = ":";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.BackColor = System.Drawing.Color.Transparent;
            this.label62.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.Location = new System.Drawing.Point(131, 73);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(13, 18);
            this.label62.TabIndex = 300;
            this.label62.Text = ":";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.BackColor = System.Drawing.Color.Transparent;
            this.label61.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.Location = new System.Drawing.Point(131, 44);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(13, 18);
            this.label61.TabIndex = 299;
            this.label61.Text = ":";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.BackColor = System.Drawing.Color.Transparent;
            this.label60.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.Location = new System.Drawing.Point(336, 13);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(81, 18);
            this.label60.TabIndex = 298;
            this.label60.Text = "Invoice Date";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.BackColor = System.Drawing.Color.Transparent;
            this.label58.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.Location = new System.Drawing.Point(32, 130);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(37, 18);
            this.label58.TabIndex = 297;
            this.label58.Text = "Email";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.BackColor = System.Drawing.Color.Transparent;
            this.label57.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.Location = new System.Drawing.Point(31, 101);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(92, 18);
            this.label57.TabIndex = 296;
            this.label57.Text = "Contact Phone";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.BackColor = System.Drawing.Color.Transparent;
            this.label56.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.Location = new System.Drawing.Point(31, 74);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(95, 18);
            this.label56.TabIndex = 295;
            this.label56.Text = "Company Name";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.BackColor = System.Drawing.Color.Transparent;
            this.label55.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.Location = new System.Drawing.Point(31, 44);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(96, 18);
            this.label55.TabIndex = 293;
            this.label55.Text = "Contact Person";
            // 
            // chkhOtherServices
            // 
            this.chkhOtherServices.BackColor = System.Drawing.Color.White;
            this.chkhOtherServices.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkhOtherServices.FormattingEnabled = true;
            this.chkhOtherServices.Location = new System.Drawing.Point(35, 400);
            this.chkhOtherServices.Name = "chkhOtherServices";
            this.chkhOtherServices.ScrollAlwaysVisible = true;
            this.chkhOtherServices.Size = new System.Drawing.Size(167, 224);
            this.chkhOtherServices.TabIndex = 363;
            this.chkhOtherServices.Visible = false;
            this.chkhOtherServices.SelectedIndexChanged += new System.EventHandler(this.chkhOtherServices_SelectedIndexChanged);
            this.chkhOtherServices.MouseLeave += new System.EventHandler(this.chkhOtherServices_MouseLeave);
            // 
            // btnhOtherServices
            // 
            this.btnhOtherServices.BackColor = System.Drawing.Color.Transparent;
            this.btnhOtherServices.FlatAppearance.BorderSize = 0;
            this.btnhOtherServices.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnhOtherServices.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnhOtherServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhOtherServices.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhOtherServices.Image = ((System.Drawing.Image)(resources.GetObject("btnhOtherServices.Image")));
            this.btnhOtherServices.Location = new System.Drawing.Point(51, 575);
            this.btnhOtherServices.Name = "btnhOtherServices";
            this.btnhOtherServices.Size = new System.Drawing.Size(59, 49);
            this.btnhOtherServices.TabIndex = 364;
            this.btnhOtherServices.UseVisualStyleBackColor = false;
            this.btnhOtherServices.Click += new System.EventHandler(this.btnhOtherServices_Click);
            // 
            // txtBalance
            // 
            this.txtBalance.Enabled = false;
            this.txtBalance.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.ForeColor = System.Drawing.Color.Black;
            this.txtBalance.Location = new System.Drawing.Point(418, 577);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(112, 25);
            this.txtBalance.TabIndex = 362;
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.BackColor = System.Drawing.Color.Transparent;
            this.label97.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label97.Location = new System.Drawing.Point(416, 559);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(203, 18);
            this.label97.TabIndex = 361;
            this.label97.Text = "Balance=((Total Amt * Night)-Dis)";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.ForeColor = System.Drawing.Color.Black;
            this.txtDiscount.Location = new System.Drawing.Point(360, 577);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(47, 25);
            this.txtDiscount.TabIndex = 360;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            this.txtDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiscount_KeyDown);
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.BackColor = System.Drawing.Color.Transparent;
            this.label94.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label94.Location = new System.Drawing.Point(363, 559);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(41, 18);
            this.label94.TabIndex = 359;
            this.label94.Text = "Dis %";
            // 
            // txtTotalhAmount
            // 
            this.txtTotalhAmount.Enabled = false;
            this.txtTotalhAmount.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalhAmount.ForeColor = System.Drawing.Color.Black;
            this.txtTotalhAmount.Location = new System.Drawing.Point(259, 578);
            this.txtTotalhAmount.Name = "txtTotalhAmount";
            this.txtTotalhAmount.Size = new System.Drawing.Size(90, 25);
            this.txtTotalhAmount.TabIndex = 358;
            // 
            // txtTotalRoom
            // 
            this.txtTotalRoom.Enabled = false;
            this.txtTotalRoom.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRoom.ForeColor = System.Drawing.Color.Black;
            this.txtTotalRoom.Location = new System.Drawing.Point(194, 578);
            this.txtTotalRoom.Name = "txtTotalRoom";
            this.txtTotalRoom.Size = new System.Drawing.Size(54, 25);
            this.txtTotalRoom.TabIndex = 357;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.BackColor = System.Drawing.Color.Transparent;
            this.label91.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label91.Location = new System.Drawing.Point(263, 559);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(84, 18);
            this.label91.TabIndex = 356;
            this.label91.Text = "Total Amount";
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.BackColor = System.Drawing.Color.Transparent;
            this.label92.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label92.Location = new System.Drawing.Point(193, 559);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(58, 18);
            this.label92.TabIndex = 355;
            this.label92.Text = "Room No";
            // 
            // btnhPreview
            // 
            this.btnhPreview.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnhPreview.FlatAppearance.BorderColor = System.Drawing.Color.NavajoWhite;
            this.btnhPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhPreview.Location = new System.Drawing.Point(408, 616);
            this.btnhPreview.Name = "btnhPreview";
            this.btnhPreview.Size = new System.Drawing.Size(75, 40);
            this.btnhPreview.TabIndex = 354;
            this.btnhPreview.Text = "Preview";
            this.btnhPreview.UseVisualStyleBackColor = false;
            this.btnhPreview.Click += new System.EventHandler(this.btnhPreview_Click);
            // 
            // btnhCancel
            // 
            this.btnhCancel.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnhCancel.FlatAppearance.BorderColor = System.Drawing.Color.NavajoWhite;
            this.btnhCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhCancel.Location = new System.Drawing.Point(307, 616);
            this.btnhCancel.Name = "btnhCancel";
            this.btnhCancel.Size = new System.Drawing.Size(75, 40);
            this.btnhCancel.TabIndex = 353;
            this.btnhCancel.Text = "Cancel";
            this.btnhCancel.UseVisualStyleBackColor = false;
            this.btnhCancel.Click += new System.EventHandler(this.btnhCancel_Click);
            // 
            // btnHotelBooking
            // 
            this.btnHotelBooking.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnHotelBooking.FlatAppearance.BorderColor = System.Drawing.Color.NavajoWhite;
            this.btnHotelBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHotelBooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHotelBooking.Location = new System.Drawing.Point(206, 616);
            this.btnHotelBooking.Name = "btnHotelBooking";
            this.btnHotelBooking.Size = new System.Drawing.Size(75, 40);
            this.btnHotelBooking.TabIndex = 352;
            this.btnHotelBooking.Text = "Booking";
            this.btnHotelBooking.UseVisualStyleBackColor = false;
            this.btnHotelBooking.Click += new System.EventHandler(this.btnHotelBooking_Click);
            // 
            // txthSupplier
            // 
            this.txthSupplier.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthSupplier.ForeColor = System.Drawing.Color.Black;
            this.txthSupplier.Location = new System.Drawing.Point(145, 247);
            this.txthSupplier.Multiline = true;
            this.txthSupplier.Name = "txthSupplier";
            this.txthSupplier.Size = new System.Drawing.Size(175, 27);
            this.txthSupplier.TabIndex = 367;
            // 
            // label214
            // 
            this.label214.AutoSize = true;
            this.label214.BackColor = System.Drawing.Color.Transparent;
            this.label214.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label214.Location = new System.Drawing.Point(129, 252);
            this.label214.Name = "label214";
            this.label214.Size = new System.Drawing.Size(13, 18);
            this.label214.TabIndex = 366;
            this.label214.Text = ":";
            // 
            // label215
            // 
            this.label215.AutoSize = true;
            this.label215.BackColor = System.Drawing.Color.Transparent;
            this.label215.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label215.Location = new System.Drawing.Point(32, 252);
            this.label215.Name = "label215";
            this.label215.Size = new System.Drawing.Size(54, 18);
            this.label215.TabIndex = 365;
            this.label215.Text = "Supplier";
            // 
            // cbohIncomeType
            // 
            this.cbohIncomeType.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbohIncomeType.ForeColor = System.Drawing.Color.Black;
            this.cbohIncomeType.FormattingEnabled = true;
            this.cbohIncomeType.Location = new System.Drawing.Point(458, 181);
            this.cbohIncomeType.Name = "cbohIncomeType";
            this.cbohIncomeType.Size = new System.Drawing.Size(153, 26);
            this.cbohIncomeType.TabIndex = 370;
            // 
            // label223
            // 
            this.label223.AutoSize = true;
            this.label223.BackColor = System.Drawing.Color.Transparent;
            this.label223.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label223.Location = new System.Drawing.Point(441, 185);
            this.label223.Name = "label223";
            this.label223.Size = new System.Drawing.Size(13, 18);
            this.label223.TabIndex = 369;
            this.label223.Text = ":";
            // 
            // label228
            // 
            this.label228.AutoSize = true;
            this.label228.BackColor = System.Drawing.Color.Transparent;
            this.label228.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label228.Location = new System.Drawing.Point(340, 185);
            this.label228.Name = "label228";
            this.label228.Size = new System.Drawing.Size(81, 18);
            this.label228.TabIndex = 368;
            this.label228.Text = "Income Type";
            // 
            // frmHotelBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(648, 670);
            this.Controls.Add(this.cbohIncomeType);
            this.Controls.Add(this.label223);
            this.Controls.Add(this.label228);
            this.Controls.Add(this.txthSupplier);
            this.Controls.Add(this.label214);
            this.Controls.Add(this.label215);
            this.Controls.Add(this.chkhOtherServices);
            this.Controls.Add(this.btnhOtherServices);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.label97);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.label94);
            this.Controls.Add(this.txtTotalhAmount);
            this.Controls.Add(this.txtTotalRoom);
            this.Controls.Add(this.label91);
            this.Controls.Add(this.label92);
            this.Controls.Add(this.btnhPreview);
            this.Controls.Add(this.btnhCancel);
            this.Controls.Add(this.btnHotelBooking);
            this.Controls.Add(this.cbohHotel);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.label170);
            this.Controls.Add(this.txthCurRate);
            this.Controls.Add(this.txthAddress);
            this.Controls.Add(this.label95);
            this.Controls.Add(this.label96);
            this.Controls.Add(this.cbohPaymentTerm);
            this.Controls.Add(this.cbohCurrency);
            this.Controls.Add(this.label90);
            this.Controls.Add(this.label93);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.label73);
            this.Controls.Add(this.label87);
            this.Controls.Add(this.label86);
            this.Controls.Add(this.label85);
            this.Controls.Add(this.btnhAdd);
            this.Controls.Add(this.txthAmount);
            this.Controls.Add(this.txtRoomNo);
            this.Controls.Add(this.txthRate);
            this.Controls.Add(this.cboRoomType);
            this.Controls.Add(this.label84);
            this.Controls.Add(this.label83);
            this.Controls.Add(this.label82);
            this.Controls.Add(this.label81);
            this.Controls.Add(this.dgvRoom);
            this.Controls.Add(this.dtphHotelBooking);
            this.Controls.Add(this.dtpDepatureDate);
            this.Controls.Add(this.dtpArrivalDate);
            this.Controls.Add(this.txthRemark);
            this.Controls.Add(this.label75);
            this.Controls.Add(this.label76);
            this.Controls.Add(this.txtNightNo);
            this.Controls.Add(this.txtPaxNo);
            this.Controls.Add(this.txthEmail);
            this.Controls.Add(this.txthContactPhone);
            this.Controls.Add(this.txthCompanyName);
            this.Controls.Add(this.txthContactPerson);
            this.Controls.Add(this.txthInvoiceNo);
            this.Controls.Add(this.label77);
            this.Controls.Add(this.label78);
            this.Controls.Add(this.label71);
            this.Controls.Add(this.label72);
            this.Controls.Add(this.label74);
            this.Controls.Add(this.label69);
            this.Controls.Add(this.label70);
            this.Controls.Add(this.label68);
            this.Controls.Add(this.label67);
            this.Controls.Add(this.label66);
            this.Controls.Add(this.label65);
            this.Controls.Add(this.label64);
            this.Controls.Add(this.label63);
            this.Controls.Add(this.label62);
            this.Controls.Add(this.label61);
            this.Controls.Add(this.label60);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.label55);
            this.Name = "frmHotelBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Booking Form";
            this.Load += new System.EventHandler(this.frmHotelBooking_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmHotelBooking_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbohHotel;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label170;
        private System.Windows.Forms.TextBox txthCurRate;
        private System.Windows.Forms.TextBox txthAddress;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.ComboBox cbohPaymentTerm;
        private System.Windows.Forms.ComboBox cbohCurrency;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Button btnhAdd;
        private System.Windows.Forms.TextBox txthAmount;
        private System.Windows.Forms.TextBox txtRoomNo;
        private System.Windows.Forms.TextBox txthRate;
        private System.Windows.Forms.ComboBox cboRoomType;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.DataGridView dgvRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNofN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colhAmount;
        private System.Windows.Forms.DataGridViewButtonColumn btnhDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colhrID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRCode;
        private System.Windows.Forms.DateTimePicker dtphHotelBooking;
        private System.Windows.Forms.DateTimePicker dtpDepatureDate;
        private System.Windows.Forms.DateTimePicker dtpArrivalDate;
        private System.Windows.Forms.TextBox txthRemark;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.TextBox txtNightNo;
        private System.Windows.Forms.TextBox txtPaxNo;
        private System.Windows.Forms.TextBox txthEmail;
        private System.Windows.Forms.TextBox txthContactPhone;
        private System.Windows.Forms.TextBox txthCompanyName;
        private System.Windows.Forms.TextBox txthContactPerson;
        private System.Windows.Forms.TextBox txthInvoiceNo;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.CheckedListBox chkhOtherServices;
        private System.Windows.Forms.Button btnhOtherServices;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.TextBox txtTotalhAmount;
        private System.Windows.Forms.TextBox txtTotalRoom;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.Button btnhPreview;
        private System.Windows.Forms.Button btnhCancel;
        public System.Windows.Forms.Button btnHotelBooking;
        private System.Windows.Forms.TextBox txthSupplier;
        private System.Windows.Forms.Label label214;
        private System.Windows.Forms.Label label215;
        private System.Windows.Forms.ComboBox cbohIncomeType;
        private System.Windows.Forms.Label label223;
        private System.Windows.Forms.Label label228;
    }
}