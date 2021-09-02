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

namespace NobelMoon.UI
{
    public partial class frmAirTicket : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        List<Int32> tfDeleteID = new List<Int32>();
        List<Int32> tpDeleteID = new List<Int32>();
        Decimal hDiscount = 0;
        public bool IsEdit = false;
        public string InvoiceNo = "";
        public frmAirTicket()
        {
                InitializeComponent();
        }

        private void frmAirTicket_Load(object sender, EventArgs e)
        {
            if (IsEdit == true)
            {
                BindTicket();
                CleanTicketBooking();
                BindBooking(InvoiceNo);
            }
        }

        private void BindTicket()
        {
            //txtTBookingNo.Text = entity.GetFormNo("AirTicket").FirstOrDefault().ToString();
            cboFrom.DataSource = null;
            List<Connection.Segment> sf = new List<Connection.Segment>();
            sf = entity.Segments.Where(x => x.IsDelete == false).ToList();
            cboFrom.DataSource = sf;
            cboFrom.DisplayMember = "Code";
            cboFrom.ValueMember = "Code";
            cboFrom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboFrom.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboTo.DataSource = null;
            List<Connection.Segment> st = new List<Connection.Segment>();
            st = entity.Segments.Where(x => x.IsDelete == false).ToList();
            cboTo.DataSource = st;
            cboTo.DisplayMember = "Code";
            cboTo.ValueMember = "Code";
            cboTo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboTo.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboClass.DataSource = null;
            List<Connection.Class> c = new List<Connection.Class>();
            c = entity.Classes.Where(x => x.IsDelete == false).ToList();
            cboClass.DataSource = c;
            cboClass.DisplayMember = "Name";
            cboClass.ValueMember = "Name";
            cboClass.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboClass.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboPaymentTerm.DataSource = null;
            List<Connection.PaymentTerm> p = new List<Connection.PaymentTerm>();
            p = entity.PaymentTerms.Where(x => x.IsDelete == false).ToList();
            cboPaymentTerm.DataSource = p;
            cboPaymentTerm.DisplayMember = "Description";
            cboPaymentTerm.ValueMember = "Code";
            cboPaymentTerm.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboPaymentTerm.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboCurrency.DataSource = null;
            List<Connection.Currency> cu = new List<Connection.Currency>();
            cu = entity.Currencies.Where(x => x.IsDelete == false).ToList();
            cboCurrency.DataSource = cu;
            cboCurrency.DisplayMember = "Code";
            cboCurrency.ValueMember = "Code";
            cboCurrency.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCurrency.AutoCompleteSource = AutoCompleteSource.ListItems;

            this.cboIncomeType.DataSource = null;
            List<Connection.IncomeType> dataSource5 = new List<Connection.IncomeType>();
            dataSource5 = (from x in this.entity.IncomeType
                           where x.IsDelete == (bool?)false
                           select x).ToList<Connection.IncomeType>();
            this.cboIncomeType.DataSource = dataSource5;
            this.cboIncomeType.DisplayMember = "Description";
            this.cboIncomeType.ValueMember = "Description";
            this.cboIncomeType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cboIncomeType.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void CleanTicketBooking()
        {
            //txtTBookingNo.Text = entity.GetFormNo("AirTicket").FirstOrDefault().ToString();
            txtContactPerson.Text = "";
            txtCompanyName.Text = "";
            //txtpassport.Text = "";
            //txtpassName.Text = "";
            dtpbookingdate.Value = DateTime.Now;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            cboFrom.SelectedIndex = 0;
            cboTo.SelectedIndex = 0;
            cboClass.SelectedIndex = 0;
            dtpTime.Value = DateTime.Now;
            dtpTime.Format = DateTimePickerFormat.Custom;
            dtpTime.CustomFormat = "HH:mm";
            dtpTime.ShowUpDown = true;
            dtpaTime.Value = DateTime.Now;
            dtpaTime.Format = DateTimePickerFormat.Custom;
            dtpaTime.CustomFormat = "HH:mm";
            dtpaTime.ShowUpDown = true;
            txtFlight.Text = "";
            txtNo.Text = "0";
            txtPassenger.Text = "";
            txtTicker.Text = "";
            txtFare.Text = "0";
            txtbTax.Text = "0";
            txtpTotalFare.Text = "0";
            txtTax.Text = "0";
            txtTotalFare.Text = "0";
            txtTotalNo.Text = "0";
            cboPassengerType.SelectedIndex = 0;
            dgvFlight.Rows.Clear();
            dgvPassenger.Rows.Clear();
            //btnPreview.Visible = false;
            if (InvoiceNo == "")
            {
                btnBooking.Text = "Booking";
            }
            //txtSearch.Text = "";
            cboAType.SelectedIndex = 0;
            cboCurrency.Text = "MMK";
            txtAcurrate.Text = "1";
            cboAVehicalName.SelectedIndex = 0;
            this.cboIncomeType.SelectedIndex = 0;
            this.txtsupplier.Text = "";
        }

        private void BindBooking(string Invoice)
        {
            Connection.TicketBooking tb = new Connection.TicketBooking();
            tb = entity.TicketBookings.Where(x => x.InvoiceNo == Invoice && x.IsDelete == false).FirstOrDefault();
            if (tb != null)
            {
                txtTBookingNo.Text = tb.InvoiceNo;
                txtContactPerson.Text = tb.ContactPerson;
                txtCompanyName.Text = tb.CompanyName;
                cboCurrency.SelectedValue = tb.Currency;
                txtAcurrate.Text = tb.Rate.ToString();
                cboPaymentTerm.SelectedValue = tb.PaymentCode;
                dtpbookingdate.Value = (DateTime)tb.Date;
                txtPhone.Text = tb.Phone;
                txtEmail.Text = tb.Email;
                this.cboIncomeType.Text = tb.t2;
                this.txtsupplier.Text = tb.t3;
                this.cboIncomeType.SelectedValue = tb.t2;
                this.txtsupplier.Text = tb.t3;
                txtAddress.Text = tb.Address;
                txtTotalNo.Text = tb.NoSeat.ToString();
                txtTax.Text = tb.Tax.ToString();
                txtTotalFare.Text = tb.Total.ToString();
                if (tb.IsTransit == true)
                {
                    chkIsTransit.Checked = true;
                }
                else chkIsTransit.Checked = false;

                cboAType.SelectedItem = tb.Type.ToString();
            }

            List<Connection.TicketFlight> tf = new List<Connection.TicketFlight>();
            tf = entity.TicketFlights.Where(x => x.InvoiceNo == Invoice && x.IsDelete == false).ToList();
            if (tf.Count > 0)
            {
                dgvFlight.Rows.Clear();
                for (int i = 0; i < tf.Count; i++)
                {
                    dgvFlight.Rows.Add(tf[i].From, tf[i].To, tf[i].Date, tf[i].Time, tf[i].ArrivalDate, tf[i].ArrivalTime, tf[i].Class, tf[i].AirLine, tf[i].Flight, tf[i].NoSeats, 0, tf[i].ID);
                }

            }

            List<Connection.TicketPassenger> tp = new List<Connection.TicketPassenger>();
            tp = entity.TicketPassengers.Where(x => x.InvoiceNo == Invoice && x.IsDelete == false).ToList();
            if (tp.Count > 0)
            {
                dgvPassenger.Rows.Clear();
                for (int i = 0; i < tp.Count; i++)
                {
                    dgvPassenger.Rows.Add(tp[i].PassengerName, tp[i].t1, tp[i].Type, tp[i].TicketNo, tp[i].Fare, tp[i].tax, tp[i].TotalFare, 0, tp[i].ID);
                }
            }
        }

        private void btnPadd_Click(object sender, EventArgs e)
        {
            string name = txtPassenger.Text;
            string ticket = txtTicker.Text;
            string passport = txtPassport.Text;
            string type = cboPassengerType.SelectedItem.ToString();
            decimal fare = Decimal.Parse(txtFare.Text);
            decimal tax = Decimal.Parse(txtbTax.Text);
            decimal total = Decimal.Parse(txtpTotalFare.Text);

            dgvPassenger.Rows.Add(name, passport, type, ticket, fare, tax, total);
            //decimal taxtotal = Decimal.Parse(txtTax.Text);
            //decimal totalfare = Decimal.Parse(txtTotalFare.Text);

            //taxtotal += tax;
            //totalfare += (fare+tax);

            //txtbTax.Text = taxtotal.ToString();
            //txtTotalFare.Text = totalfare.ToString();
            CalculateAirTicketAmount();

            txtPassenger.Text = "";
            txtPassport.Text = "";
            txtTicker.Text = "";
            cboPassengerType.SelectedIndex = 0;
            txtFare.Text = "0";
            txtbTax.Text = "0";
            txtpTotalFare.Text = "0";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string from = cboFrom.SelectedValue.ToString();
            string to = cboTo.SelectedValue.ToString();
            string date = dtpDate.Value.ToShortDateString();
            string time = dtpTime.Value.ToString("HH:mm");
            string adate = dtpaDate.Value.ToShortDateString();
            string atime = dtpaTime.Value.ToString("HH:mm");
            string air = cboAVehicalName.SelectedValue.ToString();
            string c = cboClass.SelectedValue.ToString();
            string flight = txtFlight.Text;
            int qty = Int32.Parse(txtNo.Text == "" ? "0" : txtNo.Text);

            dgvFlight.Rows.Add(from, to, date, time, adate, atime, c, air, flight, qty);

            int totalqty = Int32.Parse(txtTotalNo.Text);
            totalqty += qty;
            txtTotalNo.Text = totalqty.ToString();


            cboFrom.SelectedIndex = 0;
            cboTo.SelectedIndex = 0;
            dtpDate.Value = DateTime.Now;
            dtpTime.Value = DateTime.Now;
            dtpaDate.Value = DateTime.Now;
            dtpaTime.Value = DateTime.Now;
            cboClass.SelectedIndex = 0;
            txtFlight.Text = "";
            txtNo.Text = "0";
            cboFrom.Focus();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            List<Connection.TicketBooking> list = new List<Connection.TicketBooking>();
            List<Connection.TicketFlight> list2 = new List<Connection.TicketFlight>();
            List<Connection.TicketPassenger> list3 = new List<Connection.TicketPassenger>();
            DataTable dataTable = new DataTable("TicketBooking");
            dataTable.Columns.Add(new DataColumn("Date", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
            dataTable.Columns.Add(new DataColumn("ContactPerson", typeof(string)));
            dataTable.Columns.Add(new DataColumn("CompanyName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("PaymentTerm", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Currency", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Phone", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Email", typeof(string)));
            dataTable.Columns.Add(new DataColumn("t2", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Address", typeof(string)));
            dataTable.Columns.Add(new DataColumn("NoSeat", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Tax", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Total", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("IsTransit", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("User", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
            DataRow dataRow = dataTable.NewRow();
            dataRow["Date"] = this.dtpbookingdate.Value;
            dataRow["InvoiceNo"] = this.txtTBookingNo.Text;
            dataRow["ContactPerson"] = this.txtContactPerson.Text;
            dataRow["CompanyName"] = this.txtCompanyName.Text;
            string payment = this.cboPaymentTerm.SelectedValue.ToString();
            Connection.PaymentTerm paymentTerm = new Connection.PaymentTerm();
            paymentTerm = (from x in this.entity.PaymentTerms
                           where x.Code == payment && x.IsDelete == (bool?)false
                           select x).FirstOrDefault<Connection.PaymentTerm>();
            dataRow["PaymentTerm"] = paymentTerm.Description;
            dataRow["Currency"] = this.cboCurrency.SelectedValue.ToString();
            dataRow["Phone"] = this.txtPhone.Text;
            dataRow["Email"] = this.txtEmail.Text;
            dataRow["t2"] = this.cboIncomeType.SelectedValue.ToString();
            dataRow["Address"] = this.txtAddress.Text;
            dataRow["NoSeat"] = this.txtTotalNo.Text;
            dataRow["Tax"] = this.txtTax.Text;
            dataRow["Total"] = this.txtTotalFare.Text;
            if (this.chkIsTransit.Checked)
            {
                dataRow["IsTransit"] = "true";
            }
            else
            {
                dataRow["IsTransit"] = "false";
            }
            string user = Utility.Utility.Staff;
            Connection.Staff staff = new Connection.Staff();
            staff = (from x in this.entity.Staffs
                     where x.Code == user && x.IsDelete == (bool?)false
                     select x).FirstOrDefault<Connection.Staff>();
            dataRow["User"] = Utility.Utility.Staff;
            dataRow["Type"] = this.cboAType.SelectedItem.ToString();
            dataTable.Rows.Add(dataRow);
            string text = "";
            string text2 = DateTime.Now.ToString();
            string text3 = DateTime.Now.ToString();
            string text4 = DateTime.Now.ToString();
            string text5 = DateTime.Now.ToString();
            string text6 = "";
            string text7 = "";
            DataTable dataTable2 = new DataTable("TicketFlight");
            dataTable2.Columns.Add(new DataColumn("Date", typeof(DateTime)));
            dataTable2.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("From", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("To", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("Time", typeof(DateTime)));
            dataTable2.Columns.Add(new DataColumn("ArrivalDate", typeof(DateTime)));
            dataTable2.Columns.Add(new DataColumn("ArrivalTime", typeof(DateTime)));
            dataTable2.Columns.Add(new DataColumn("Class", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("Flight", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("NoSeats", typeof(int)));
            dataTable2.Columns.Add(new DataColumn("User", typeof(string)));
            if (this.dgvFlight.Rows.Count > 0)
            {
                for (int i = 0; i < this.dgvFlight.Rows.Count; i++)
                {
                    DataRow dataRow2 = dataTable2.NewRow();
                    if (!this.chkIsTransit.Checked)
                    {
                        dataRow2["Date"] = this.dgvFlight.Rows[i].Cells["coldpDate"].Value.ToString();
                        dataRow2["InvoiceNo"] = this.txtTBookingNo.Text;
                        dataRow2["From"] = this.dgvFlight.Rows[i].Cells["colFrom"].Value.ToString();
                        dataRow2["To"] = this.dgvFlight.Rows[i].Cells["colTo"].Value.ToString();
                        dataRow2["Time"] = this.dgvFlight.Rows[i].Cells["colTime"].Value.ToString();
                        dataRow2["ArrivalDate"] = this.dgvFlight.Rows[i].Cells["colaDate"].Value.ToString();
                        dataRow2["ArrivalTime"] = this.dgvFlight.Rows[i].Cells["colaTime"].Value.ToString();
                        dataRow2["Class"] = this.dgvFlight.Rows[i].Cells["colbClass"].Value.ToString();
                        dataRow2["Flight"] = this.dgvFlight.Rows[i].Cells["colFNo"].Value.ToString();
                        dataRow2["NoSeats"] = this.dgvFlight.Rows[i].Cells["colSeat"].Value.ToString();
                        dataRow2["User"] = "";
                    }
                    if (this.chkIsTransit.Checked)
                    {
                        if (i == 0)
                        {
                            text = this.dgvFlight.Rows[i].Cells["colFrom"].Value.ToString() + "/" + this.dgvFlight.Rows[i].Cells["colTo"].Value.ToString();
                            text2 = this.dgvFlight.Rows[i].Cells["coldpDate"].Value.ToString();
                            text3 = this.dgvFlight.Rows[i].Cells["colTime"].Value.ToString();
                            text6 = this.dgvFlight.Rows[i].Cells["colbClass"].Value.ToString();
                            text7 = this.dgvFlight.Rows[i].Cells["colFNo"].Value.ToString();
                        }
                        else
                        {
                            text = text + "/" + this.dgvFlight.Rows[i].Cells["colTo"].Value.ToString();
                        }
                        if (i == this.dgvFlight.Rows.Count - 1)
                        {
                            text4 = this.dgvFlight.Rows[i].Cells["colaDate"].Value.ToString();
                            text5 = this.dgvFlight.Rows[i].Cells["colaTime"].Value.ToString();
                        }
                    }
                    dataTable2.Rows.Add(dataRow2);
                }
            }
            DataTable dataTable3 = new DataTable("TicketPassenger");
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            dataTable3.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
            dataTable3.Columns.Add(new DataColumn("PassengerName", typeof(string)));
            dataTable3.Columns.Add(new DataColumn("TicketNo", typeof(string)));
            dataTable3.Columns.Add(new DataColumn("Adult", typeof(string)));
            dataTable3.Columns.Add(new DataColumn("Child", typeof(string)));
            dataTable3.Columns.Add(new DataColumn("Infant", typeof(string)));
            dataTable3.Columns.Add(new DataColumn("Fare", typeof(decimal)));
            dataTable3.Columns.Add(new DataColumn("tax", typeof(int)));
            dataTable3.Columns.Add(new DataColumn("TotalFare", typeof(decimal)));
            dataTable3.Columns.Add(new DataColumn("User", typeof(string)));
            if (this.dgvPassenger.Rows.Count > 0)
            {
                for (int i = 0; i < this.dgvPassenger.Rows.Count; i++)
                {
                    DataRow dataRow3 = dataTable3.NewRow();
                    dataRow3["InvoiceNo"] = this.txtTBookingNo.Text;
                    dataRow3["PassengerName"] = this.dgvPassenger.Rows[i].Cells["colpName"].Value.ToString();
                    dataRow3["TicketNo"] = this.dgvPassenger.Rows[i].Cells["colTicketNo"].Value.ToString();
                    dataRow3["Fare"] = this.dgvPassenger.Rows[i].Cells["colFare"].Value.ToString();
                    dataRow3["tax"] = this.dgvPassenger.Rows[i].Cells["colTax"].Value.ToString();
                    dataRow3["TotalFare"] = this.dgvPassenger.Rows[i].Cells["colTotal"].Value.ToString();
                    if (this.dgvPassenger.Rows[i].Cells["colpType"].Value.ToString() == "Adult")
                    {
                        num2++;
                    }
                    else if (this.dgvPassenger.Rows[i].Cells["colpType"].Value.ToString() == "Child")
                    {
                        num++;
                    }
                    else if (this.dgvPassenger.Rows[i].Cells["colpType"].Value.ToString() == "Infant")
                    {
                        num3++;
                    }
                    dataRow3["User"] = Utility.Utility.Staff;
                    dataTable3.Rows.Add(dataRow3);
                }
            }
            dataSet.Tables.Add(dataTable);
            dataSet.Tables.Add(dataTable2);
            dataSet.Tables.Add(dataTable3);
            ReportDocument reportDocument = new ReportDocument();
            dataSet.WriteXmlSchema(Application.StartupPath + "\\DataSets\\NobelMoon.xsd");
            reportDocument.Load(Application.StartupPath + "\\Reports\\AirInvoice.rpt");
            FormulaFieldDefinitions formulaFields = reportDocument.Subreports["Passenger"].DataDefinition.FormulaFields;
            formulaFields["Adult"].Text = '"' + num2.ToString() + '"';
            FormulaFieldDefinitions formulaFields2 = reportDocument.Subreports["Passenger"].DataDefinition.FormulaFields;
            formulaFields2["Child"].Text = '"' + num.ToString() + '"';
            FormulaFieldDefinitions formulaFields3 = reportDocument.Subreports["Passenger"].DataDefinition.FormulaFields;
            formulaFields3["Infant"].Text = '"' + num3.ToString() + '"';
            FormulaFieldDefinitions formulaFields4 = reportDocument.Subreports["Flight"].DataDefinition.FormulaFields;
            formulaFields4["Origin/Dest"].Text = '"' + text.ToString() + '"';
            FormulaFieldDefinitions formulaFields5 = reportDocument.Subreports["Flight"].DataDefinition.FormulaFields;
            formulaFields5["Ddate"].Text = '"' + text2.ToString() + '"';
            FormulaFieldDefinitions formulaFields6 = reportDocument.Subreports["Flight"].DataDefinition.FormulaFields;
            formulaFields6["Dtime"].Text = '"' + text3.ToString() + '"';
            FormulaFieldDefinitions formulaFields7 = reportDocument.Subreports["Flight"].DataDefinition.FormulaFields;
            formulaFields7["Adate"].Text = '"' + text4.ToString() + '"';
            FormulaFieldDefinitions formulaFields8 = reportDocument.Subreports["Flight"].DataDefinition.FormulaFields;
            formulaFields8["Atime"].Text = '"' + text5.ToString() + '"';
            FormulaFieldDefinitions formulaFields9 = reportDocument.Subreports["Flight"].DataDefinition.FormulaFields;
            formulaFields9["class"].Text = '"' + text6.ToString() + '"';
            FormulaFieldDefinitions formulaFields10 = reportDocument.Subreports["Flight"].DataDefinition.FormulaFields;
            formulaFields10["flight"].Text = '"' + text7.ToString() + '"';
            reportDocument.SetDataSource(dataSet);
            UI.frmReport frmReport = new UI.frmReport();
            frmReport.reportViewer1.ReportSource = reportDocument;
            frmReport.reportViewer1.Refresh();
            frmReport.Show();
            base.UseWaitCursor = false;
        }

        private bool IsValid()
        {
            if (txtContactPerson.Text == "" && dgvFlight.Rows.Count == 0 && dgvPassenger.Rows.Count == 0)
            {
                return false;
            }
            else return true;
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            if (IsValid() == true)
            {
                try
                {
                    if (btnBooking.Text == "Booking")
                    {
                        #region"TicketBooking"
                        Connection.TicketBooking tb = new Connection.TicketBooking();
                        tb.InvoiceNo = txtTBookingNo.Text;
                        tb.ContactPerson = txtContactPerson.Text;
                        tb.CompanyName = txtCompanyName.Text;
                        tb.Currency = cboCurrency.SelectedValue.ToString();
                        tb.Rate = Int32.Parse(txtAcurrate.Text);
                        tb.PaymentCode = cboPaymentTerm.SelectedValue.ToString();
                        Connection.PaymentTerm p = new Connection.PaymentTerm();
                        p = entity.PaymentTerms.Where(x => x.Code == tb.PaymentCode && x.IsDelete == false).FirstOrDefault();
                        tb.PaymentDes = p.Description;
                        tb.Date = dtpDate.Value;
                        tb.Phone = txtPhone.Text;
                        tb.Email = txtEmail.Text;
                        tb.t2 = this.cboIncomeType.SelectedValue.ToString();
                        tb.t3 = txtsupplier.Text;
                        tb.Address = txtAddress.Text;
                        tb.SystemDate = DateTime.Now;
                        tb.NoSeat = Int32.Parse(txtTotalNo.Text == "" ? "0" : txtTotalNo.Text);
                        tb.Tax = Int32.Parse(txtTax.Text == "" ? "0" : txtTax.Text);
                        tb.Total = Decimal.Parse(txtTotalFare.Text == "" ? "0" : txtTotalFare.Text);
                        tb.Type = cboAType.SelectedItem.ToString();
                        if (chkIsTransit.Checked)
                        {
                            tb.IsTransit = true;
                        }
                        else tb.IsTransit = false;
                        tb.MMKBalance = CalculateMMKAmount(Convert.ToInt32(tb.Rate), Convert.ToDecimal(tb.Total));
                        tb.Status = "B";
                        tb.User = Utility.Utility.User;
                        tb.IsDelete = false;

                        entity.AddToTicketBookings(tb);
                        entity.SaveChanges();
                        #endregion

                        #region"TicketFlight"
                        if (dgvFlight.Rows.Count > 0)
                        {
                            for (int i = 0; i < dgvFlight.Rows.Count; i++)
                            {
                                Connection.TicketFlight tf = new Connection.TicketFlight();
                                tf.InvoiceNo = txtTBookingNo.Text;
                                tf.SystemDate = DateTime.Now;
                                tf.From = dgvFlight.Rows[i].Cells["colFrom"].Value.ToString();
                                tf.To = dgvFlight.Rows[i].Cells["colTo"].Value.ToString();
                                tf.Date = DateTime.Parse(dgvFlight.Rows[i].Cells["coldpDate"].Value.ToString());
                                tf.Time = DateTime.Parse(dgvFlight.Rows[i].Cells["colTime"].Value.ToString());
                                tf.ArrivalDate = DateTime.Parse(dgvFlight.Rows[i].Cells["colaDate"].Value.ToString());
                                tf.ArrivalTime = DateTime.Parse(dgvFlight.Rows[i].Cells["colaTime"].Value.ToString());
                                tf.Class = dgvFlight.Rows[i].Cells["colbClass"].Value.ToString();
                                tf.AirLine = dgvFlight.Rows[i].Cells["colAairline"].Value.ToString();
                                tf.Flight = dgvFlight.Rows[i].Cells["colFNo"].Value.ToString();
                                tf.NoSeats = Int32.Parse(dgvFlight.Rows[i].Cells["colSeat"].Value.ToString());
                                tf.User = Utility.Utility.User;
                                tf.IsDelete = false;

                                entity.AddToTicketFlights(tf);
                                entity.SaveChanges();
                            }
                        }
                        #endregion

                        #region"TicketPassenger"
                        if (dgvPassenger.Rows.Count > 0)
                        {
                            for (int i = 0; i < dgvPassenger.Rows.Count; i++)
                            {
                                Connection.TicketPassenger tp = new Connection.TicketPassenger();
                                tp.InvoiceNo = txtTBookingNo.Text;
                                tp.PassengerName = dgvPassenger.Rows[i].Cells["colpName"].Value.ToString();
                                tp.t1 = dgvPassenger.Rows[i].Cells["colPassport"].Value.ToString();
                                tp.Type = dgvPassenger.Rows[i].Cells["colPType"].Value.ToString();
                                tp.TicketNo = dgvPassenger.Rows[i].Cells["colTicketNo"].Value.ToString();
                                tp.Fare = Decimal.Parse(dgvPassenger.Rows[i].Cells["colFare"].Value.ToString());
                                tp.tax = Decimal.Parse(dgvPassenger.Rows[i].Cells["colTax"].Value.ToString());
                                tp.TotalFare = Decimal.Parse(dgvPassenger.Rows[i].Cells["colTotal"].Value.ToString());
                                tp.User = Utility.Utility.User;
                                tp.IsDelete = false;

                                entity.AddToTicketPassengers(tp);
                                entity.SaveChanges();
                            }
                        }
                        #endregion

                        MessageBox.Show("Booking Successful!", "Successful", MessageBoxButtons.OK);
                    }
                    else if (btnBooking.Text == "Update")
                    {
                        string invoice = txtTBookingNo.Text;
                        #region"TicketBooking"
                        Connection.TicketBooking tb = new Connection.TicketBooking();
                        tb = entity.TicketBookings.Where(x => x.InvoiceNo == invoice && x.IsDelete == false).FirstOrDefault();
                        tb.ContactPerson = txtContactPerson.Text;
                        tb.CompanyName = txtCompanyName.Text;
                        tb.Currency = cboCurrency.SelectedValue.ToString();
                        tb.Rate = Int32.Parse(txtAcurrate.Text);
                        tb.PaymentCode = cboPaymentTerm.SelectedValue.ToString();
                        tb.PaymentDes = cboPaymentTerm.SelectedValue.ToString();
                        tb.Date = dtpbookingdate.Value;
                        tb.Phone = txtPhone.Text;
                        tb.Email = txtEmail.Text;
                        tb.t2 = this.cboIncomeType.SelectedValue.ToString();
                        tb.t3 = txtsupplier.Text;
                        tb.Address = txtAddress.Text;
                        tb.SystemDate = DateTime.Now;
                        tb.NoSeat = Int32.Parse(txtTotalNo.Text == "" ? "0" : txtTotalNo.Text);
                        tb.Tax = Int32.Parse(txtTax.Text == "" ? "0" : txtTax.Text);
                        tb.Total = Decimal.Parse(txtTotalFare.Text == "" ? "0" : txtTotalFare.Text);
                        tb.Type = cboAType.SelectedItem.ToString();
                        if (chkIsTransit.Checked)
                        {
                            tb.IsTransit = true;
                        }
                        else tb.IsTransit = false;
                        tb.MMKBalance = CalculateMMKAmount(Convert.ToInt32(tb.Rate), Convert.ToDecimal(tb.Total));
                        tb.Status = "U";
                        tb.User = Utility.Utility.User;
                        tb.IsDelete = false;

                        entity.SaveChanges();
                        #endregion

                        #region"TicketFlight"
                        if (dgvFlight.Rows.Count > 0)
                        {
                            if (tfDeleteID.Count > 0)
                            {
                                for (int i = 0; i < tfDeleteID.Count; i++)
                                {
                                    Connection.TicketFlight tf = new Connection.TicketFlight();
                                    Int32 Id = Int32.Parse(tfDeleteID[i].ToString());
                                    tf = entity.TicketFlights.Where(x => x.ID == Id && x.IsDelete == false).FirstOrDefault();
                                    tf.IsDelete = true;
                                    entity.SaveChanges();
                                }
                            }
                            for (int i = 0; i < dgvFlight.Rows.Count; i++)
                            {
                                if (dgvFlight.Rows[i].Cells["colID"].Value == null)
                                {
                                    Connection.TicketFlight tf = new Connection.TicketFlight();
                                    tf.InvoiceNo = txtTBookingNo.Text;
                                    tf.SystemDate = DateTime.Now;
                                    tf.From = dgvFlight.Rows[i].Cells["colFrom"].Value.ToString();
                                    tf.To = dgvFlight.Rows[i].Cells["colTo"].Value.ToString();
                                    tf.Date = DateTime.Parse(dgvFlight.Rows[i].Cells["coldpDate"].Value.ToString());
                                    tf.Time = DateTime.Parse(dgvFlight.Rows[i].Cells["colTime"].Value.ToString());
                                    tf.ArrivalDate = DateTime.Parse(dgvFlight.Rows[i].Cells["colaDate"].Value.ToString());
                                    tf.ArrivalTime = DateTime.Parse(dgvFlight.Rows[i].Cells["colaTime"].Value.ToString());
                                    tf.Class = dgvFlight.Rows[i].Cells["colbClass"].Value.ToString();
                                    tf.AirLine = dgvFlight.Rows[i].Cells["colAairline"].Value.ToString();
                                    tf.Flight = dgvFlight.Rows[i].Cells["colFNo"].Value.ToString();
                                    tf.NoSeats = Int32.Parse(dgvFlight.Rows[i].Cells["colSeat"].Value.ToString());
                                    tf.User = Utility.Utility.User;
                                    tf.IsDelete = false;

                                    entity.AddToTicketFlights(tf);
                                    entity.SaveChanges();
                                }
                                else
                                {
                                    Connection.TicketFlight tf = new Connection.TicketFlight();
                                    Int32 Id = Int32.Parse(dgvFlight.Rows[i].Cells["colID"].Value.ToString());
                                    tf = entity.TicketFlights.Where(x => x.ID == Id && x.IsDelete == false).FirstOrDefault();
                                    tf.InvoiceNo = txtTBookingNo.Text;
                                    tf.SystemDate = DateTime.Now;
                                    tf.From = dgvFlight.Rows[i].Cells["colFrom"].Value.ToString();
                                    tf.To = dgvFlight.Rows[i].Cells["colTo"].Value.ToString();
                                    tf.Date = DateTime.Parse(dgvFlight.Rows[i].Cells["coldpDate"].Value.ToString());
                                    tf.Time = DateTime.Parse(dgvFlight.Rows[i].Cells["colTime"].Value.ToString());
                                    tf.Class = dgvFlight.Rows[i].Cells["colbClass"].Value.ToString();
                                    tf.AirLine = dgvFlight.Rows[i].Cells["colAairline"].Value.ToString();
                                    tf.Flight = dgvFlight.Rows[i].Cells["colFNo"].Value.ToString();
                                    tf.NoSeats = Int32.Parse(dgvFlight.Rows[i].Cells["colSeat"].Value.ToString());
                                    tf.User = Utility.Utility.User;
                                    tf.IsDelete = false;

                                    entity.SaveChanges();
                                }
                            }
                        }
                        #endregion

                        #region"TicketPassenger"
                        if (dgvPassenger.Rows.Count > 0)
                        {
                            if (tpDeleteID.Count > 0)
                            {
                                for (int i = 0; i < tpDeleteID.Count; i++)
                                {
                                    Connection.TicketPassenger tp = new Connection.TicketPassenger();
                                    Int32 Id = Int32.Parse(tpDeleteID[i].ToString());
                                    tp = entity.TicketPassengers.Where(x => x.ID == Id && x.IsDelete == false).FirstOrDefault();
                                    tp.IsDelete = true;
                                    entity.SaveChanges();
                                }
                            }
                            for (int i = 0; i < dgvPassenger.Rows.Count; i++)
                            {
                                if (dgvPassenger.Rows[i].Cells["colpID"].Value == null)
                                {
                                    Connection.TicketPassenger tp = new Connection.TicketPassenger();
                                    tp.InvoiceNo = txtTBookingNo.Text;
                                    tp.PassengerName = dgvPassenger.Rows[i].Cells["colpName"].Value.ToString();
                                    tp.t1 = dgvPassenger.Rows[i].Cells["colPassport"].Value.ToString();
                                    tp.Type = dgvPassenger.Rows[i].Cells["colPType"].Value.ToString();
                                    tp.TicketNo = dgvPassenger.Rows[i].Cells["colTicketNo"].Value.ToString();
                                    tp.Fare = Decimal.Parse(dgvPassenger.Rows[i].Cells["colFare"].Value.ToString());
                                    tp.tax = Int32.Parse(dgvPassenger.Rows[i].Cells["colTax"].Value.ToString());
                                    tp.TotalFare = Decimal.Parse(dgvPassenger.Rows[i].Cells["colTotal"].Value.ToString());
                                    tp.User = Utility.Utility.User;
                                    tp.IsDelete = false;

                                    entity.AddToTicketPassengers(tp);
                                    entity.SaveChanges();
                                }
                                else
                                {
                                    Connection.TicketPassenger tp = new Connection.TicketPassenger();
                                    Int32 Id = Int32.Parse(dgvPassenger.Rows[i].Cells["colpID"].Value.ToString());
                                    tp = entity.TicketPassengers.Where(x => x.ID == Id && x.IsDelete == false).FirstOrDefault();
                                    tp.InvoiceNo = txtTBookingNo.Text;
                                    tp.PassengerName = dgvPassenger.Rows[i].Cells["colpName"].Value.ToString();
                                    tp.t1 = dgvPassenger.Rows[i].Cells["colPassport"].Value.ToString();
                                    tp.Type = dgvPassenger.Rows[i].Cells["colPType"].Value.ToString();
                                    tp.TicketNo = dgvPassenger.Rows[i].Cells["colTicketNo"].Value.ToString();
                                    tp.Fare = Decimal.Parse(dgvPassenger.Rows[i].Cells["colFare"].Value.ToString());
                                    tp.tax = Int32.Parse(dgvPassenger.Rows[i].Cells["colTax"].Value.ToString());
                                    tp.TotalFare = Decimal.Parse(dgvPassenger.Rows[i].Cells["colTotal"].Value.ToString());
                                    tp.User = Utility.Utility.User;
                                    tp.IsDelete = false;

                                    entity.SaveChanges();
                                }
                            }
                        }
                        #endregion

                        MessageBox.Show("Booking Successful!", "Successful", MessageBoxButtons.OK);
                    }
                    else if (btnBooking.Text == "Issue")
                    {
                        string invoice = txtTBookingNo.Text;
                        #region"TicketBooking"
                        Connection.TicketBooking tb = new Connection.TicketBooking();
                        tb = entity.TicketBookings.Where(x => x.InvoiceNo == invoice && x.IsDelete == false).FirstOrDefault();
                        tb.ContactPerson = txtContactPerson.Text;
                        tb.CompanyName = txtCompanyName.Text;
                        tb.Currency = cboCurrency.SelectedValue.ToString();
                        tb.Rate = Int32.Parse(txtAcurrate.Text);
                        tb.PaymentCode = cboPaymentTerm.SelectedValue.ToString();
                        tb.PaymentDes = cboPaymentTerm.SelectedValue.ToString();
                        tb.Date = dtpbookingdate.Value;
                        tb.Phone = txtPhone.Text;
                        tb.Email = txtEmail.Text;
                        tb.Address = txtAddress.Text;
                        tb.SystemDate = DateTime.Now;
                        tb.NoSeat = Int32.Parse(txtTotalNo.Text == "" ? "0" : txtTotalNo.Text);
                        tb.Tax = Int32.Parse(txtTax.Text == "" ? "0" : txtTax.Text);
                        tb.Total = Decimal.Parse(txtTotalFare.Text == "" ? "0" : txtTotalFare.Text);
                        tb.Type = cboAType.SelectedItem.ToString();
                        if (chkIsTransit.Checked)
                        {
                            tb.IsTransit = true;
                        }
                        else tb.IsTransit = false;
                        tb.MMKBalance = CalculateMMKAmount(Convert.ToInt32(tb.Rate), Convert.ToDecimal(tb.Total));
                        tb.Status = "I";
                        tb.User = Utility.Utility.User;
                        tb.IsDelete = false;

                        entity.SaveChanges();
                        MessageBox.Show("Issue Successful!", "Successful", MessageBoxButtons.OK);
                        #endregion
                        btnPreview_Click(sender, e);
                    }
                    CleanTicketBooking();
                    tfDeleteID = new List<int>();
                    tpDeleteID = new List<int>();

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CleanTicketBooking();
        }

        private void dgvFlight_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                if (dgvFlight.CurrentRow.Cells["colID"].Value != null)
                {
                    tfDeleteID.Add(Int32.Parse(dgvFlight.CurrentRow.Cells["colID"].Value.ToString()));
                }
                Int32 no = Int32.Parse(dgvFlight.CurrentRow.Cells["colSeat"].Value.ToString());
                dgvFlight.Rows.Remove(dgvFlight.CurrentRow);

                Int32 totalno = Int32.Parse(txtTotalNo.Text);
                txtTotalNo.Text = (totalno - no).ToString();
            }
        }

        private void dgvPassenger_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7)
                {
                    if (dgvPassenger.CurrentRow.Cells["colpID"].Value != null)
                    {
                        tpDeleteID.Add(Int32.Parse(dgvPassenger.CurrentRow.Cells["colpID"].Value.ToString()));
                    }
                    decimal tax = Int32.Parse(dgvPassenger.CurrentRow.Cells["colTax"].Value.ToString());
                    decimal total = Decimal.Parse(dgvPassenger.CurrentRow.Cells["colTotal"].Value.ToString());
                    ReCalculateAirTicketAmount(tax, total);
                    dgvPassenger.Rows.Remove(dgvPassenger.CurrentRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void CalculateAirTicketAmount()
        {
            Decimal fare = Decimal.Parse(txtFare.Text);
            Int32 Tax = Int32.Parse(txtbTax.Text);
            Decimal totalfare = Decimal.Parse(txtpTotalFare.Text);
            Int32 TotalTax = Int32.Parse(txtTax.Text);
            Decimal totalamount = Decimal.Parse(txtTotalFare.Text);

            txtTax.Text = (Tax + TotalTax).ToString();
            txtTotalFare.Text = (totalfare + totalamount).ToString();
        }

        private void ReCalculateAirTicketAmount(Decimal tax, Decimal Amount)
        {
            decimal totaltax = Decimal.Parse(txtTax.Text);
            decimal totalfare = Decimal.Parse(txtTotalFare.Text);
            txtTax.Text = (totaltax - tax).ToString();
            txtTotalFare.Text = (totalfare - Amount).ToString();
        }

        private void frmAirTicket_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (IsEdit == true)
            //{
            //    frmAirTicketHistory newform = new frmAirTicketHistory();
            //    newform.Show();
            //}
        }

        private void frmAirTicket_Paint(object sender, PaintEventArgs e)
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

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void txtContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCompanyName.Focus();
            }
        }

        private void txtCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboPaymentTerm.Focus();
            }
        }

        private void cboPaymentTerm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //cboCurrency.Focus();
                cboIncomeType.Focus();
            }
        }

        private void cboCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Currency = cboCurrency.Text;
                Connection.Currency curr = new Connection.Currency();
                curr = entity.Currencies.Where(x => x.Code == Currency && x.IsDelete == false).FirstOrDefault();
                txtAcurrate.Text = curr.Rate.ToString();
                txtAcurrate.Focus();
            }
        }

        private void txtAcurrate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpbookingdate.Focus();
            }
        }

        private void dtpbookingdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboAType.Focus();
            }
        }

        private void cboAType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string type = cboAType.Text;
                    cboAVehicalName.DataSource = null;
                    List<Connection.Vehical> v = new List<Connection.Vehical>();
                    v = entity.Vehicals.Where(x => x.IsDelete == false && x.Type == type).ToList();
                    cboAVehicalName.DataSource = v;
                    cboAVehicalName.DisplayMember = "Name";
                    cboAVehicalName.ValueMember = "Name";
                    cboAVehicalName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cboAVehicalName.AutoCompleteSource = AutoCompleteSource.ListItems;
                    txtPhone.Focus();
                }
            }
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress.Focus();
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // cboFrom.Focus();
                txtsupplier.Focus();
            }
        }

        private void cboFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboTo.Focus();
            }
        }

        private void cboTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpDate.Focus();
            }
        }

        private void dtpDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpTime.Focus();
            }
        }

        private void cboClass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboAVehicalName.Focus();
            }
        }

        private void cboAVehicalName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFlight.Focus();
            }
        }

        private void txtFlight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNo.Focus();
            }
        }

        private void txtNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(sender, e);
            }
        }

        private void txtPassenger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassport.Focus();
            }
        }

        private void txtPassport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboPassengerType.Focus();
            }
        }

        private void cboPassengerType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTicker.Focus();
            }
        }

        private void txtTicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFare.Focus();
            }
        }

        private void txtFare_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal fare = Decimal.Parse(txtFare.Text == "" ? "0" : txtFare.Text);
                decimal totalfare = Decimal.Parse(txtTotalFare.Text == "" ? "0" : txtTotalFare.Text);
                txtFare.Text = fare.ToString();
                txtpTotalFare.Text = fare.ToString();
                //txtTotalFare.Text = (fare + totalfare).ToString();
                txtbTax.Focus();
            }
        }

        private void txtbTax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal fare = Decimal.Parse(txtFare.Text == "" ? "0" : txtFare.Text);
                decimal totalfare = Decimal.Parse(txtTotalFare.Text == "" ? "0" : txtTotalFare.Text);
                decimal tax = Decimal.Parse(txtbTax.Text == "" ? "0" : txtbTax.Text);
                decimal totaltax = Decimal.Parse(txtTax.Text == "" ? "0" : txtTax.Text);
                txtbTax.Text = (tax).ToString();
                txtpTotalFare.Text = (fare + tax).ToString();
                //txtTax.Text = (totaltax + tax).ToString();
                //txtTotalFare.Text = (totalfare + tax).ToString();
                btnPadd_Click(sender, e);
            }
        }

        private void txtpTotalFare_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPadd_Click(sender, e);
            }
        }

        private void cboAType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAType.SelectedItem == "Bus")
            {
                label29.Text = "Car No";
                colFNo.HeaderText = "Car No";
                label147.Text = "CarLine";
                colAairline.HeaderText = "CarLine";
            }
            else
            {
                label29.Text = "Flight No";
                colFNo.HeaderText = "Flight No";
                label147.Text = "AirLine";
                colAairline.HeaderText = "AirLine";
            }
        }

        private void dtpTime_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dtpaDate_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dtpaTime_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle); 
        }

        private void tabPage2_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle); 
        }

        private void cboAType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboAType.SelectedItem == "Bus")
            {
                label29.Text = "Car No";
                colFNo.HeaderText = "Car No";
                label147.Text = "CarLine";
                colAairline.HeaderText = "CarLine";
                cboAVehicalName.DataSource = null;
                List<Connection.Vehical> v = new List<Connection.Vehical>();
                v = entity.Vehicals.Where(x => x.IsDelete == false && x.Type == "Bus").ToList();
                cboAVehicalName.DataSource = v;
                cboAVehicalName.DisplayMember = "Name";
                cboAVehicalName.ValueMember = "Name";
                cboAVehicalName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboAVehicalName.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            else
            {
                label29.Text = "Flight No";
                colFNo.HeaderText = "Flight No";
                label147.Text = "AirLine";
                colAairline.HeaderText = "AirLine";
                cboAVehicalName.DataSource = null;
                List<Connection.Vehical> v = new List<Connection.Vehical>();
                v = entity.Vehicals.Where(x => x.IsDelete == false && x.Type == "Airline").ToList();
                cboAVehicalName.DataSource = v;
                cboAVehicalName.DisplayMember = "Name";
                cboAVehicalName.ValueMember = "Name";
                cboAVehicalName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboAVehicalName.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string Currency = cboCurrency.Text;
            //if (cboCurrency.DataSource != null)
            //{
            //    Connection.Currency curr = new Connection.Currency();
            //    curr = entity.Currencies.Where(x => x.Code == Currency && x.IsDelete == false).FirstOrDefault();
            //    txtAcurrate.Text = curr.Rate.ToString();
            //}
        }

        private void dgvFlight_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int seat = 0;
            for (int i = 0; i < dgvFlight.Rows.Count; i++)
            {
                seat += Int32.Parse(dgvFlight.Rows[i].Cells["colSeat"].Value.ToString());
            }
            txtTotalNo.Text = seat.ToString();
        }

        private void dgvPassenger_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6)
            {
                int tax = 0; decimal fare = 0, totalfare = 0;
                dgvPassenger.CurrentRow.Cells["colTotal"].Value = Int32.Parse(dgvPassenger.CurrentRow.Cells["colTax"].Value.ToString()) + Decimal.Parse(dgvPassenger.CurrentRow.Cells["colFare"].Value.ToString());
                for (int i = 0; i < dgvPassenger.Rows.Count; i++)
                {
                    tax += Int32.Parse(dgvPassenger.Rows[i].Cells["colTax"].Value.ToString());
                    fare += Decimal.Parse(dgvPassenger.Rows[i].Cells["colFare"].Value.ToString());
                    totalfare += Decimal.Parse(dgvPassenger.Rows[i].Cells["colTotal"].Value.ToString());
                }

                txtFare.Text = fare.ToString();
                txtTax.Text = tax.ToString();
                txtTotalFare.Text = totalfare.ToString();
            }
        }

        private void cboIncomeType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboCurrency.Focus();
            }
        }

        private void txtsupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboFrom.Focus();
            }
        }
    }
}
