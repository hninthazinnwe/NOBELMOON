using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Drawing2D;
using NobelMoon.Connection;

namespace NobelMoon.UI
{
    public partial class frmHotelBooking : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        List<Int32> hrDeleteID = new List<Int32>();
        Decimal hDiscount = 0;
        public bool IsEdit = false;
        public string InvoiceNo = "";
        public frmHotelBooking()
        {
            InitializeComponent();
        }

        private void frmHotelBooking_Load(object sender, EventArgs e)
        {
            if (IsEdit == true)
            {
                CleanHotelBooking();
                BindHotelBooking(InvoiceNo);
            }
        }

        private void CleanHotelBooking()
        {
            //txthInvoiceNo.Text = entity.GetFormNo("Hotel").FirstOrDefault().ToString();
            txthContactPerson.Text = "";
            txthCompanyName.Text = "";
            txthContactPhone.Text = "";
            //txthSubject.Text = "";
            txthEmail.Text = "";
            dtphHotelBooking.Value = DateTime.Now;
            dtpArrivalDate.Value = DateTime.Now;
            dtpDepatureDate.Value = DateTime.Now;
            txtPaxNo.Text = "0";
            txtNightNo.Text = "0";
            txthRemark.Text = "";
            txthRate.Text = "0";
            txtRoomNo.Text = "0";
            txthAmount.Text = "0";
            txtTotalRoom.Text = "0";
            txtTotalhAmount.Text = "0";
            txtDiscount.Text = "0";
            txtBalance.Text = "0";
            //txthSearch.Text = "";
            cbohCurrency.Text = "MMK";
            txthCurRate.Text = "1";
            txthSupplier.Text = "";

            cboRoomType.DataSource = null;
            List<Connection.RoomType> c = new List<Connection.RoomType>();
            c = entity.RoomTypes.Where(x => x.IsDelete == false).ToList();
            cboRoomType.DataSource = c;
            cboRoomType.DisplayMember = "Description";
            cboRoomType.ValueMember = "Code";
            cboRoomType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboRoomType.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbohPaymentTerm.DataSource = null;
            List<Connection.PaymentTerm> p = new List<Connection.PaymentTerm>();
            p = entity.PaymentTerms.Where(x => x.IsDelete == false).ToList();
            cbohPaymentTerm.DataSource = p;
            cbohPaymentTerm.DisplayMember = "Description";
            cbohPaymentTerm.ValueMember = "Code";
            cbohPaymentTerm.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbohPaymentTerm.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbohCurrency.DataSource = null;
            List<Connection.Currency> cu = new List<Connection.Currency>();
            cu = entity.Currencies.Where(x => x.IsDelete == false).ToList();
            cbohCurrency.DataSource = cu;
            cbohCurrency.DisplayMember = "Code";
            cbohCurrency.ValueMember = "Code";
            cbohCurrency.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbohCurrency.AutoCompleteSource = AutoCompleteSource.ListItems;

            this.cbohIncomeType.DataSource = null;
            List<IncomeType> hit = new List<IncomeType>();
            hit = (from x in this.entity.IncomeType
                   where x.IsDelete == (bool?)false
                   select x).ToList<IncomeType>();
            this.cbohIncomeType.DataSource = hit;
            this.cbohIncomeType.DisplayMember = "Description";
            this.cbohIncomeType.ValueMember = "Description";
            this.cbohIncomeType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbohIncomeType.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbohHotel.DataSource = null;
            List<Connection.Hotel> h = new List<Connection.Hotel>();
            h = entity.Hotels.Where(x => x.IsDelete == false).ToList();
            cbohHotel.DataSource = h;
            cbohHotel.DisplayMember = "Name";
            cbohHotel.ValueMember = "Name";
            cbohHotel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbohHotel.AutoCompleteSource = AutoCompleteSource.ListItems;

            dgvRoom.Rows.Clear();
            //btnhPreview.Visible = false;
            if (InvoiceNo == "")
            {
                btnHotelBooking.Text = "Booking";
            }
            hDiscount = 0;


            chkhOtherServices.Items.Clear();
            List<Connection.Services> req = new List<Connection.Services>();
            req = entity.Services.Where(x => x.Transaction == "Hotel" && x.IsDelete == false).ToList();
            foreach (Connection.Services var in req)
            {
                chkhOtherServices.Items.Add(var.Description);
            }

            chkhOtherServices.CheckOnClick = true;
        }

        private bool HotelIsValid()
        {
            if (txthContactPerson.Text == "" && dgvRoom.Rows.Count == 0)
            {
                return false;
            }
            else return true;
        }

        private void BindHotelBooking(string Invoice)
        {
            Connection.HotelBooking tb = new Connection.HotelBooking();
            tb = entity.HotelBookings.Where(x => x.InvoiceNo == Invoice && x.IsDelete == false).FirstOrDefault();
            if (tb != null)
            {
                txthInvoiceNo.Text = tb.InvoiceNo;
                txthContactPerson.Text = tb.ContactPerson;
                txthCompanyName.Text = tb.CompanyName;
                txthContactPhone.Text = tb.ContactPhone;
                cbohPaymentTerm.SelectedItem = tb.PaymentTerm;
                cbohCurrency.SelectedItem = tb.Currency;
                txthEmail.Text = tb.Email;
                this.cbohIncomeType.SelectedValue = tb.t1;
                this.txthSupplier.Text = tb.t2;
                dtphHotelBooking.Value = (DateTime)tb.InvoiceDate;
                dtpArrivalDate.Value = (DateTime)tb.ArrivalDate;
                dtpDepatureDate.Value = (DateTime)tb.DepatureDate;
                txthAddress.Text = tb.Address;
                txthRemark.Text = tb.Remark;
                txtPaxNo.Text = tb.NoofPax.ToString();
                txtNightNo.Text = tb.NoofNight.ToString();
                txtTotalRoom.Text = tb.TotalRoom.ToString();
                txtDiscount.Text = tb.DiscountPercent.ToString();
                txtTotalhAmount.Text = tb.TotalAmount.ToString();
                txtBalance.Text = tb.Balance.ToString();
                cbohHotel.Text = tb.Hotel.ToString();
                cbohCurrency.Text = tb.Currency;
                txthCurRate.Text = tb.Rate.ToString();
            }

            List<Connection.HotelRoom> tf = new List<Connection.HotelRoom>();
            tf = entity.HotelRooms.Where(x => x.InvoiceNo == Invoice && x.IsDelete == false).ToList();
            if (tf.Count > 0)
            {
                dgvRoom.Rows.Clear();
                for (int i = 0; i < tf.Count; i++)
                {
                    dgvRoom.Rows.Add(tf[i].RoomType, tf[i].Rate, tf[i].NoofRoom, tf[i].Amount, 0, tf[i].ID, tf[i].RoomCode);
                }

            }

            string services = "";
            if (chkhOtherServices.CheckedItems.Count == 0)
            {
                chkhOtherServices.Items.Clear();
                List<Connection.Services> req = new List<Connection.Services>();
                req = entity.Services.Where(x => x.Transaction == "Hotel" && x.IsDelete == false).ToList();
                List<Connection.ServicesOrRequirement> sr = new List<Connection.ServicesOrRequirement>();
                sr = entity.ServicesOrRequirement.Where(x => x.InvoiceNo == Invoice && x.Transaction == "Hotel").ToList();
                foreach (Connection.Services var in req)
                {
                    services = "";
                    for (int i = 0; i < sr.Count; i++)
                    {
                        if (var.Description == sr[i].Description)
                        {
                            services = sr[i].Description;
                        }
                    }
                    if (services != "")
                    {
                        chkhOtherServices.Items.Add(var.Description, CheckState.Checked);
                    }
                    else chkhOtherServices.Items.Add(var.Description);
                }
            }
            chkhOtherServices.CheckOnClick = true;
        }

        private void btnhAdd_Click(object sender, EventArgs e)
        {
            string room = "";
            Connection.RoomType r = new Connection.RoomType();
            if (cboRoomType.SelectedValue != null)
            {
                room = cboRoomType.SelectedValue.ToString();
                r = entity.RoomTypes.Where(x => x.Code == room && x.IsDelete == false).FirstOrDefault();
            }
            else
            {
                r.Description = cboRoomType.Text;
            }
            Decimal rate = Decimal.Parse(txthRate.Text == "" ? "0" : txthRate.Text);
            Int32 no = Int32.Parse(txtRoomNo.Text == "" ? "0" : txtRoomNo.Text);
            Decimal amount = Decimal.Parse(txthAmount.Text == "" ? "0" : txthAmount.Text);

            dgvRoom.Rows.Add(r.Description, rate, no, amount, 0, null, room);

            CalculateHotelAmount();
            cboRoomType.SelectedIndex = 0;
            txthRate.Text = "0";
            txtRoomNo.Text = "0";
            txthAmount.Text = "0";
            cboRoomType.Focus();
            //a > b ? x : y
            //decimal tamount = txthAmount.Text == "0" ? 0 : Decimal.Parse(txthAmount.Text);
            //int tno = txtTotalRoom.Text == "0" ? 0 : Int32.Parse(txtTotalRoom.Text);

            //txtTotalRoom.Text = (tno + no).ToString();
            //txtTotalhAmount.Text = (tamount + amount).ToString();
        }

        private void btnHotelBooking_Click(object sender, EventArgs e)
        {
            if (HotelIsValid() == true)
            {
                try
                {
                    if (btnHotelBooking.Text == "Booking")
                    {
                        Connection.HotelBooking hb = new Connection.HotelBooking();
                        hb.InvoiceNo = txthInvoiceNo.Text;
                        hb.SystemDate = DateTime.Now;
                        hb.ContactPerson = txthContactPerson.Text;
                        hb.CompanyName = txthCompanyName.Text;
                        hb.ContactPhone = txthContactPhone.Text;
                        hb.Currency = cbohCurrency.SelectedValue.ToString();
                        hb.Rate = Int32.Parse(txthCurRate.Text);
                        hb.PaymentTerm = cbohPaymentTerm.SelectedValue.ToString();
                        hb.Address = txthAddress.Text;
                        hb.Email = txthEmail.Text;
                        hb.t1 = this.cbohIncomeType.SelectedValue.ToString();
                        hb.t2 = this.txthSupplier.Text;
                        hb.InvoiceDate = DateTime.Parse(dtphHotelBooking.Value.ToShortDateString());
                        hb.DepatureDate = DateTime.Parse(dtpDepatureDate.Value.ToShortDateString());
                        hb.ArrivalDate = DateTime.Parse(dtpArrivalDate.Value.ToShortDateString());
                        hb.NoofPax = Int32.Parse(txtPaxNo.Text == "" ? "0" : txtPaxNo.Text);
                        hb.NoofNight = Int32.Parse(txtNightNo.Text == "" ? "0" : txtNightNo.Text);
                        hb.Discount = hDiscount;
                        hb.DiscountPercent = Int32.Parse(txtDiscount.Text == "" ? "0" : txtDiscount.Text);
                        hb.TotalRoom = Int32.Parse(txtTotalRoom.Text == "" ? "0" : txtTotalRoom.Text);
                        hb.TotalAmount = Decimal.Parse(txtTotalhAmount.Text == "" ? "0" : txtTotalhAmount.Text);
                        hb.Balance = Decimal.Parse(txtBalance.Text == "" ? "0" : txtBalance.Text);
                        hb.Remark = txthRemark.Text;
                        hb.Hotel = cbohHotel.Text;
                        hb.MMKBalance = CalculateMMKAmount(Convert.ToInt32(hb.Rate), Convert.ToDecimal(hb.Balance));
                        hb.Status = "B";
                        hb.User = Utility.Utility.User;
                        hb.IsDelete = false;

                        entity.AddToHotelBookings(hb);
                        entity.SaveChanges();

                        #region"HotelRoom"
                        if (dgvRoom.Rows.Count > 0)
                        {
                            for (int i = 0; i < dgvRoom.Rows.Count; i++)
                            {
                                Connection.HotelRoom hr = new Connection.HotelRoom();
                                hr.InvoiceNo = txthInvoiceNo.Text;
                                hr.SystemDate = DateTime.Now;
                                hr.RoomType = dgvRoom.Rows[i].Cells["colRType"].Value.ToString();
                                hr.Rate = Decimal.Parse(dgvRoom.Rows[i].Cells["colRate"].Value.ToString());
                                hr.NoofRoom = Int32.Parse(dgvRoom.Rows[i].Cells["colNofN"].Value.ToString());
                                hr.Amount = Decimal.Parse(dgvRoom.Rows[i].Cells["colhAmount"].Value.ToString());
                                hr.RoomCode = dgvRoom.Rows[i].Cells["colRCode"].Value.ToString();
                                hr.User = Utility.Utility.User;
                                hr.IsDelete = false;

                                entity.AddToHotelRooms(hr);
                                entity.SaveChanges();
                            }
                        }
                        #endregion

                        #region "Services&Requirement"

                        Connection.ServicesOrRequirement sr = new Connection.ServicesOrRequirement();
                        Connection.Services s = new Connection.Services();

                        foreach (string var in chkhOtherServices.CheckedItems)
                        {
                            string services = var.ToString();
                            s = entity.Services.Where(x => x.Description == services && x.Transaction == "Hotel" && x.IsDelete == false).FirstOrDefault();
                            sr = new Connection.ServicesOrRequirement();
                            sr.CreatedDate = DateTime.Now;
                            sr.Code = s.Code;
                            sr.Description = s.Description;
                            sr.InvoiceNo = txthInvoiceNo.Text;
                            sr.Transaction = "Hotel";
                            sr.User = Utility.Utility.User;
                            entity.AddToServicesOrRequirement(sr);
                            entity.SaveChanges();
                        }
                        #endregion

                        MessageBox.Show("Booking Successful!", "Successful", MessageBoxButtons.OK);
                    }

                    else if (btnHotelBooking.Text == "Update")
                    {
                        string invoice = txthInvoiceNo.Text;
                        #region"TicketBooking"
                        Connection.HotelBooking hb = new Connection.HotelBooking();
                        hb = entity.HotelBookings.Where(x => x.InvoiceNo == invoice && x.IsDelete == false).FirstOrDefault();
                        hb.InvoiceNo = txthInvoiceNo.Text;
                        hb.SystemDate = DateTime.Now;
                        hb.ContactPerson = txthContactPerson.Text;
                        hb.CompanyName = txthCompanyName.Text;
                        hb.ContactPhone = txthContactPhone.Text;
                        hb.Currency = cbohCurrency.SelectedValue.ToString();
                        hb.Rate = Int32.Parse(txthCurRate.Text);
                        hb.PaymentTerm = cbohPaymentTerm.SelectedValue.ToString();
                        hb.Address = txthAddress.Text;
                        hb.Email = txthEmail.Text;
                        hb.t1 = this.cbohIncomeType.SelectedValue.ToString();
                        hb.t2 = this.txthSupplier.Text;
                        hb.InvoiceDate = DateTime.Parse(dtphHotelBooking.Value.ToShortDateString());
                        hb.DepatureDate = DateTime.Parse(dtpDepatureDate.Value.ToShortDateString());
                        hb.ArrivalDate = DateTime.Parse(dtpArrivalDate.Value.ToShortDateString());
                        hb.NoofPax = Int32.Parse(txtPaxNo.Text == "" ? "0" : txtPaxNo.Text);
                        hb.NoofNight = Int32.Parse(txtNightNo.Text == "" ? "0" : txtNightNo.Text);
                        hb.Discount = hDiscount;
                        hb.DiscountPercent = Int32.Parse(txtDiscount.Text == "" ? "0" : txtDiscount.Text);
                        hb.TotalRoom = Int32.Parse(txtTotalRoom.Text == "" ? "0" : txtTotalRoom.Text);
                        hb.TotalAmount = Decimal.Parse(txtTotalhAmount.Text == "" ? "0" : txtTotalhAmount.Text);
                        hb.Balance = Decimal.Parse(txtBalance.Text == "" ? "0" : txtBalance.Text);
                        hb.Remark = txthRemark.Text;
                        hb.Hotel = cbohHotel.Text;
                        hb.MMKBalance = CalculateMMKAmount(Convert.ToInt32(hb.Rate), Convert.ToDecimal(hb.Balance));
                        hb.Status = "U";
                        hb.User = Utility.Utility.User;
                        hb.IsDelete = false;

                        entity.SaveChanges();
                        #endregion

                        #region"HotelRoom"
                        if (dgvRoom.Rows.Count > 0)
                        {
                            if (hrDeleteID.Count > 0)
                            {
                                for (int i = 0; i < hrDeleteID.Count; i++)
                                {
                                    Connection.HotelRoom tf = new Connection.HotelRoom();
                                    Int32 Id = Int32.Parse(hrDeleteID[i].ToString());
                                    tf = entity.HotelRooms.Where(x => x.ID == Id && x.IsDelete == false).FirstOrDefault();
                                    tf.IsDelete = true;
                                    entity.SaveChanges();
                                }
                            }
                            for (int i = 0; i < dgvRoom.Rows.Count; i++)
                            {
                                if (dgvRoom.Rows[i].Cells["colhrID"].Value == null)
                                {
                                    Connection.HotelRoom hr = new Connection.HotelRoom();
                                    hr.InvoiceNo = txthInvoiceNo.Text;
                                    hr.SystemDate = DateTime.Now;
                                    hr.RoomType = dgvRoom.Rows[i].Cells["colRType"].Value.ToString();
                                    hr.Rate = Decimal.Parse(dgvRoom.Rows[i].Cells["colRate"].Value.ToString());
                                    hr.NoofRoom = Int32.Parse(dgvRoom.Rows[i].Cells["colNofN"].Value.ToString());
                                    hr.Amount = Decimal.Parse(dgvRoom.Rows[i].Cells["colhAmount"].Value.ToString());
                                    hr.RoomCode = dgvRoom.Rows[i].Cells["colRCode"].Value.ToString();
                                    hr.User = Utility.Utility.User;
                                    hr.IsDelete = false;

                                    entity.AddToHotelRooms(hr);
                                    entity.SaveChanges();
                                }
                                else
                                {
                                    Connection.HotelRoom hr = new Connection.HotelRoom();
                                    Int32 Id = Int32.Parse(dgvRoom.Rows[i].Cells["colhrID"].Value.ToString());
                                    hr = entity.HotelRooms.Where(x => x.ID == Id && x.IsDelete == false).FirstOrDefault();
                                    hr.InvoiceNo = txthInvoiceNo.Text;
                                    hr.SystemDate = DateTime.Now;
                                    hr.RoomType = dgvRoom.Rows[i].Cells["colRType"].Value.ToString();
                                    hr.Rate = Decimal.Parse(dgvRoom.Rows[i].Cells["colRate"].Value.ToString());
                                    hr.NoofRoom = Int32.Parse(dgvRoom.Rows[i].Cells["colNofN"].Value.ToString());
                                    hr.Amount = Decimal.Parse(dgvRoom.Rows[i].Cells["colhAmount"].Value.ToString());
                                    hr.RoomCode = dgvRoom.Rows[i].Cells["colRCode"].Value.ToString();
                                    hr.User = Utility.Utility.User;
                                    hr.IsDelete = false;

                                    entity.SaveChanges();
                                }
                            }
                        }
                        #endregion

                        #region "Services&Requirement"

                        List<Connection.ServicesOrRequirement> sq = new List<Connection.ServicesOrRequirement>();
                        Connection.ServicesOrRequirement sr = new Connection.ServicesOrRequirement();
                        Connection.Services s = new Connection.Services();

                        sq = entity.ServicesOrRequirement.Where(x => x.InvoiceNo == txthInvoiceNo.Text && x.Transaction == "Hotel").ToList();
                        for (int i = 0; i < sq.Count; i++)
                        {
                            Int32 id = sq[i].ID;
                            sr = new Connection.ServicesOrRequirement();
                            sr = entity.ServicesOrRequirement.Where(x => x.ID == id).FirstOrDefault();
                            entity.ServicesOrRequirement.DeleteObject(sr);
                            entity.SaveChanges();
                        }

                        foreach (string var in chkhOtherServices.CheckedItems)
                        {
                            string services = var.ToString();
                            s = entity.Services.Where(x => x.Description == services && x.Transaction == "Hotel" && x.IsDelete == false).FirstOrDefault();
                            sr = new Connection.ServicesOrRequirement();
                            sr.CreatedDate = DateTime.Now;
                            sr.Code = s.Code;
                            sr.Description = s.Description;
                            sr.InvoiceNo = txthInvoiceNo.Text;
                            sr.Transaction = "Hotel";
                            sr.User = Utility.Utility.User;
                            entity.AddToServicesOrRequirement(sr);
                            entity.SaveChanges();
                        }
                        #endregion

                        MessageBox.Show("Update Successful!", "Successful", MessageBoxButtons.OK);
                    }
                    else if (btnHotelBooking.Text == "Confirm")
                    {
                        string invoice = txthInvoiceNo.Text;
                        Connection.HotelBooking hb = new Connection.HotelBooking();
                        hb = entity.HotelBookings.Where(x => x.InvoiceNo == invoice && x.IsDelete == false).FirstOrDefault();
                        hb.InvoiceNo = txthInvoiceNo.Text;
                        hb.SystemDate = DateTime.Now;
                        hb.ContactPerson = txthContactPerson.Text;
                        hb.CompanyName = txthCompanyName.Text;
                        hb.ContactPhone = txthContactPhone.Text;
                        hb.Currency = cbohCurrency.SelectedValue.ToString();
                        hb.Rate = Int32.Parse(txthCurRate.Text);
                        hb.PaymentTerm = cbohPaymentTerm.SelectedValue.ToString();
                        hb.Address = txthAddress.Text;
                        hb.Email = txthEmail.Text;
                        hb.InvoiceDate = DateTime.Parse(dtphHotelBooking.Value.ToShortDateString());
                        hb.DepatureDate = DateTime.Parse(dtpDepatureDate.Value.ToShortDateString());
                        hb.ArrivalDate = DateTime.Parse(dtpArrivalDate.Value.ToShortDateString());
                        hb.NoofPax = Int32.Parse(txtPaxNo.Text == "" ? "0" : txtPaxNo.Text);
                        hb.NoofNight = Int32.Parse(txtNightNo.Text == "" ? "0" : txtNightNo.Text);
                        hb.Discount = hDiscount;
                        hb.DiscountPercent = Int32.Parse(txtDiscount.Text == "" ? "0" : txtDiscount.Text);
                        hb.TotalRoom = Int32.Parse(txtTotalRoom.Text == "" ? "0" : txtTotalRoom.Text);
                        hb.TotalAmount = Decimal.Parse(txtTotalhAmount.Text == "" ? "0" : txtTotalhAmount.Text);
                        hb.Balance = Decimal.Parse(txtBalance.Text == "" ? "0" : txtBalance.Text);
                        hb.Remark = txthRemark.Text;
                        hb.Hotel = cbohHotel.Text;
                        hb.MMKBalance = CalculateMMKAmount(Convert.ToInt32(hb.Rate), Convert.ToDecimal(hb.Balance));
                        hb.Status = "I";
                        hb.User = Utility.Utility.User;
                        hb.IsDelete = false;

                        entity.SaveChanges();

                        MessageBox.Show("Confirm Successful!", "Successful", MessageBoxButtons.OK);
                        btnhPreview_Click(sender, e);
                    }
                    hrDeleteID = new List<int>();
                    CleanHotelBooking();                  

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else MessageBox.Show("Please fill information!", "Incomplete Information");
        }

        private Decimal CalculateMMKAmount(int rate, decimal amount)
        {
            decimal MMKBalance = 0;
            MMKBalance = amount * rate;
            return MMKBalance;
        }

        private void dgvRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (dgvRoom.CurrentRow.Cells["colhrID"].Value != null)
                {
                    hrDeleteID.Add(Int32.Parse(dgvRoom.CurrentRow.Cells["colhrID"].Value.ToString()));
                }
                Int32 n = Int32.Parse(dgvRoom.CurrentRow.Cells["colNofN"].Value.ToString());
                decimal r = Int32.Parse(dgvRoom.CurrentRow.Cells["colRate"].Value.ToString());
                decimal a = Int32.Parse(dgvRoom.CurrentRow.Cells["colhAmount"].Value.ToString());
                ReCalculateHotelAmount(n, r, a);
                dgvRoom.Rows.Remove(dgvRoom.CurrentRow);
            }
        }

        private void btnhPreview_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            List<HotelBooking> list = new List<HotelBooking>();
            List<HotelRoom> list2 = new List<HotelRoom>();
            DataTable dataTable = new DataTable("HotelBooking");
            dataTable.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
            dataTable.Columns.Add(new DataColumn("InvoiceDate", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("ArrivalDate", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("DepatureDate", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("ContactPerson", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Currency", typeof(string)));
            dataTable.Columns.Add(new DataColumn("CompanyName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
            dataTable.Columns.Add(new DataColumn("ContactPhone", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Hotel", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Email", typeof(string)));
            dataTable.Columns.Add(new DataColumn("t1", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Address", typeof(string)));
            dataTable.Columns.Add(new DataColumn("NoofPax", typeof(int)));
            dataTable.Columns.Add(new DataColumn("NoofNight", typeof(int)));
            dataTable.Columns.Add(new DataColumn("TotalRoom", typeof(int)));
            dataTable.Columns.Add(new DataColumn("TotalAmount", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("Balance", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("Discount", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("DiscountPercent", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
            DataRow dataRow = dataTable.NewRow();
            dataRow["InvoiceNo"] = this.txthInvoiceNo.Text;
            dataRow["InvoiceDate"] = this.dtphHotelBooking.Value;
            dataRow["ArrivalDate"] = this.dtpArrivalDate.Value;
            dataRow["DepatureDate"] = this.dtpDepatureDate.Value;
            dataRow["ContactPerson"] = this.txthContactPerson.Text;
            dataRow["Currency"] = this.cbohCurrency.Text;
            dataRow["CompanyName"] = this.txthCompanyName.Text;
            dataRow["Description"] = this.cbohPaymentTerm.Text;
            dataRow["ContactPhone"] = this.txthContactPhone.Text;
            dataRow["Hotel"] = this.cbohHotel.Text;
            dataRow["Email"] = this.txthEmail.Text;
            dataRow["t1"] = this.cbohIncomeType.Text;
            dataRow["Address"] = "";
            dataRow["NoofPax"] = int.Parse(this.txtPaxNo.Text);
            dataRow["NoofNight"] = int.Parse(this.txtNightNo.Text);
            dataRow["TotalRoom"] = int.Parse(this.txtTotalRoom.Text);
            dataRow["TotalAmount"] = decimal.Parse(this.txtTotalhAmount.Text);
            dataRow["Balance"] = decimal.Parse(this.txtBalance.Text);
            dataRow["DiscountPercent"] = decimal.Parse(this.txtDiscount.Text);
            decimal d = decimal.Parse((this.txtDiscount.Text == "") ? "0" : this.txtDiscount.Text);
            decimal d2 = decimal.Parse(this.txtTotalhAmount.Text) * int.Parse(this.txtNightNo.Text);
            if (d != 0m)
            {
                dataRow["Discount"] = d2 * (d / 100m);
            }
            else
            {
                dataRow["Discount"] = 0;
            }
            dataRow["Remark"] = this.txthRemark.Text;
            dataRow["Name"] = Utility.Utility.Staff;
            dataTable.Rows.Add(dataRow);
            DataTable dataTable2 = new DataTable("HotelRoom");
            dataTable2.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("Roomtype", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("Rate", typeof(decimal)));
            dataTable2.Columns.Add(new DataColumn("NoofRoom", typeof(int)));
            dataTable2.Columns.Add(new DataColumn("Amount", typeof(decimal)));
            dataTable2.Columns.Add(new DataColumn("User", typeof(string)));
            if (this.dgvRoom.Rows.Count > 0)
            {
                for (int i = 0; i < this.dgvRoom.Rows.Count; i++)
                {
                    DataRow dataRow2 = dataTable2.NewRow();
                    dataRow2["InvoiceNo"] = this.txthInvoiceNo.Text;
                    dataRow2["Roomtype"] = this.dgvRoom.Rows[i].Cells["colRType"].Value.ToString();
                    dataRow2["Rate"] = this.dgvRoom.Rows[i].Cells["colRate"].Value.ToString();
                    dataRow2["NoofRoom"] = this.dgvRoom.Rows[i].Cells["colNofN"].Value.ToString();
                    dataRow2["Amount"] = this.dgvRoom.Rows[i].Cells["colhAmount"].Value.ToString();
                    dataRow2["User"] = "";
                    dataTable2.Rows.Add(dataRow2);
                }
            }
            DataTable dataTable3 = new DataTable("ServicesOrRequirements");
            dataTable3.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
            dataTable3.Columns.Add(new DataColumn("Transaction", typeof(string)));
            dataTable3.Columns.Add(new DataColumn("Description", typeof(string)));
            dataTable3.Columns.Add(new DataColumn("User", typeof(string)));
            if (this.chkhOtherServices.CheckedItems.Count > 0)
            {
                for (int i = 0; i < this.chkhOtherServices.CheckedItems.Count; i++)
                {
                    DataRow dataRow3 = dataTable3.NewRow();
                    dataRow3["InvoiceNo"] = this.txthInvoiceNo.Text;
                    dataRow3["Transaction"] = "Hotel";
                    dataRow3["Description"] = this.chkhOtherServices.CheckedItems[i].ToString();
                    dataRow3["User"] = Utility.Utility.Staff;
                    dataTable3.Rows.Add(dataRow3);
                }
            }
            dataSet.Tables.Add(dataTable);
            dataSet.Tables.Add(dataTable2);
            dataSet.Tables.Add(dataTable3);
            ReportDocument reportDocument = new ReportDocument();
            dataSet.WriteXmlSchema(Application.StartupPath + "\\DataSets\\NobelMoon.xsd");
            reportDocument.Load(Application.StartupPath + "\\Reports\\HotelInvoice.rpt");
            reportDocument.SetDataSource(dataSet);
            UI.frmReport frmReport = new UI.frmReport();
            frmReport.reportViewer1.ReportSource = reportDocument;
            frmReport.reportViewer1.Refresh();
            frmReport.Show();
            base.UseWaitCursor = false;
        }

        private void CalculateHotelAmount()
        {
            Decimal hrate = Decimal.Parse(txthRate.Text);
            Int32 Rno = Int32.Parse(txtRoomNo.Text);
            Decimal hAmount = Decimal.Parse(txthAmount.Text);
            Int32 Nno = Int32.Parse(txtNightNo.Text);
            Int32 TotalR = Int32.Parse(txtTotalRoom.Text);
            Decimal Discount = hDiscount;
            Decimal TotalAmount = Decimal.Parse(txtTotalhAmount.Text);
            Decimal Balance = Decimal.Parse(txtBalance.Text);
            txtTotalRoom.Text = (Rno + TotalR).ToString();
            txtTotalhAmount.Text = (TotalAmount + hAmount).ToString();
            txtBalance.Text = (((TotalAmount + hAmount) * Nno) - Discount).ToString();
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Decimal dis = Decimal.Parse(txtDiscount.Text);
                Int32 Nno = Int32.Parse(txtNightNo.Text);
                Decimal totalamt = Decimal.Parse(txtTotalhAmount.Text);
                if (dis > 0)
                {
                    txtBalance.Text = ((totalamt - (totalamt * (dis / 100))) * Nno).ToString();
                    hDiscount = ((totalamt * (dis / 100)) * Nno);
                }
                else
                {
                    txtBalance.Text = (totalamt * Nno).ToString();
                    hDiscount = 0;
                }
            }
        }

        private void ReCalculateHotelAmount(Int32 no, Decimal rate, Decimal Amount)
        {
            Int32 tno = Int32.Parse(txtTotalRoom.Text);
            Int32 Night = Int32.Parse(txtNightNo.Text);
            decimal tamount = Decimal.Parse(txtTotalhAmount.Text);
            decimal balance = Decimal.Parse(txtBalance.Text);
            txtTotalRoom.Text = (tno - no).ToString();
            txtTotalhAmount.Text = (tamount - Amount).ToString();
            txtBalance.Text = (balance - (Amount * Night)).ToString();
        }

        private void btnhCancel_Click(object sender, EventArgs e)
        {
            CleanHotelBooking();
        }

        private void frmHotelBooking_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle); 
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txthContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txthCompanyName.Focus();
            }
        }

        private void txthCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txthContactPhone.Focus();
            }
        }

        private void txthContactPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txthEmail.Focus();
            }
        }

        private void txthEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbohCurrency.Focus();
            }
        }

        private void cbohCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txthCurRate.Focus();
            }
        }

        private void txthCurrate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txthAddress.Focus();
            }
        }

        private void txthAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtphHotelBooking.Focus();
            }
        }

        private void dtphHotelBooking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpArrivalDate.Focus();
            }
        }

        private void dtpArrivalDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpDepatureDate.Focus();
            }
        }

        private void dtpDepatureDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Int32 night = Convert.ToInt32((dtpDepatureDate.Value - dtpArrivalDate.Value).TotalDays);
                txtNightNo.Text = night.ToString();
                txtPaxNo.Focus();
            }
        }

        private void txtPaxNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPaxNo.Text = txtNightNo.Text == "" ? "0" : txtPaxNo.Text;
                txtNightNo.Focus();
            }
        }

        private void txtNightNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNightNo.Text = txtNightNo.Text == "" ? "0" : txtNightNo.Text;
                cbohPaymentTerm.Focus();
            }
        }

        private void cbohPaymentTerm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbohHotel.Focus();
            }
        }

        private void txthRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboRoomType.Focus();
            }
        }

        private void cboRoomType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboRoomType.SelectedValue != null)
                {
                    string rtype = cboRoomType.Text;
                    string room = cboRoomType.SelectedValue.ToString();
                    Connection.RoomType r = new Connection.RoomType();
                    r = entity.RoomTypes.Where(x => x.Code == room && x.IsDelete == false).FirstOrDefault();
                    txthRate.Text = r.Rate.ToString();
                    txthRate.Focus();
                }
                else
                {
                    txthRate.Focus();
                }
            }
        }

        private void txthRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //CalculateHotelAmount();
                txtRoomNo.Focus();
            }
        }

        private void txtRoomNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Decimal rate = Decimal.Parse(txthRate.Text);
                Int32 no = Int32.Parse(txtRoomNo.Text);
                txthAmount.Text = (rate * no).ToString();
                //CalculateHotelAmount();
                btnhAdd_Click(sender, e);
            }
        }

        private void cbohHotel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txthRemark.Focus();
            }
        }

        private void chkhOtherServices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnhOtherServices_Click(object sender, EventArgs e)
        {
            if (chkhOtherServices.Visible == false)
            {
                chkhOtherServices.Visible = true;
            }
            else chkhOtherServices.Visible = false;
        }

        private void dgvRoom_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRoom.SelectedCells[0].ColumnIndex == 3)
            {
                decimal amount = 0;
                for (int i = 0; i < dgvRoom.Rows.Count; i++)
                {
                    amount += Decimal.Parse(dgvRoom.Rows[i].Cells["colhAmount"].Value.ToString());
                }
                txtTotalhAmount.Text = amount.ToString();
            }
        }

        private void chkhOtherServices_MouseLeave(object sender, EventArgs e)
        {
            chkhOtherServices.Visible = false;
        }

        private void cbohCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Currency = cbohCurrency.Text;
            if (cbohCurrency.DataSource != null)
            {
                Connection.Currency curr = new Connection.Currency();
                curr = entity.Currencies.Where(x => x.Code == Currency && x.IsDelete == false).FirstOrDefault();
                if (curr != null)
                {
                    txthCurRate.Text = curr.Rate.ToString();
                }
                else txthCurRate.Text ="1";
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
