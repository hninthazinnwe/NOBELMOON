using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using NobelMoon.Connection;
using NobelMoon.UI;
using NobelMoon.Utility;

//using System.Drawing.Printing;
//using Microsoft.Reporting.WinForms;

namespace NobelMoon
{
    public partial class FrmMain : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        List<Int32> tfDeleteID = new List<Int32>();
        List<Int32> tpDeleteID = new List<Int32>();
        List<Int32> hrDeleteID = new List<Int32>();
        List<Int32> tourpDeleteID = new List<Int32>();
        List<Int32> passportDeleteID = new List<Int32>();
        List<Int32> carrentalDeleteID = new List<Int32>();
        Decimal hDiscount = 0, tDiscount = 0;

        public FrmMain()
        {
            this.InitializeComponent();
        }

        // Token: 0x06000DE9 RID: 3561 RVA: 0x00090FCC File Offset: 0x0008F1CC
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.pnlTravel.Visible = false;
            this.pnlTourPackage.Visible = false;
            this.pnlHotelBooking.Visible = false;
            this.CheckUserRule();
            this.LoadGridSetting();
        }

        // Token: 0x06000DEA RID: 3562 RVA: 0x00091004 File Offset: 0x0008F204
        private void LoadGridSetting()
        {
            this.dgvFlight.ColumnHeadersDefaultCellStyle.Font = new Font("Zawgyi-One", 8f, FontStyle.Bold);
            this.dgvFlight.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.dgvFlight.DefaultCellStyle.Font = new Font("Zawgyi-One", 8f);
            this.dgvFlight.DefaultCellStyle.SelectionBackColor = Color.Blue;
            this.dgvPassenger.ColumnHeadersDefaultCellStyle.Font = new Font("Zawgyi-One", 8f, FontStyle.Bold);
            this.dgvPassenger.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.dgvPassenger.DefaultCellStyle.Font = new Font("Zawgyi-One", 8f);
            this.dgvPassenger.DefaultCellStyle.SelectionBackColor = Color.Blue;
            this.dgvBookingList.ColumnHeadersDefaultCellStyle.Font = new Font("Zawgyi-One", 8f, FontStyle.Bold);
            this.dgvBookingList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.dgvBookingList.DefaultCellStyle.Font = new Font("Zawgyi-One", 8f);
            this.dgvBookingList.DefaultCellStyle.ForeColor = Color.DimGray;
            this.dgvBookingList.DefaultCellStyle.SelectionBackColor = Color.Blue;
            this.dgvRoom.ColumnHeadersDefaultCellStyle.Font = new Font("Zawgyi-One", 8f, FontStyle.Bold);
            this.dgvRoom.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.dgvRoom.DefaultCellStyle.Font = new Font("Zawgyi-One", 8f);
            this.dgvRoom.DefaultCellStyle.ForeColor = Color.DimGray;
            this.dgvRoom.DefaultCellStyle.SelectionBackColor = Color.Blue;
            this.dgvHotelBooking.ColumnHeadersDefaultCellStyle.Font = new Font("Zawgyi-One", 8f, FontStyle.Bold);
            this.dgvHotelBooking.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.dgvHotelBooking.DefaultCellStyle.Font = new Font("Zawgyi-One", 8f);
            this.dgvHotelBooking.DefaultCellStyle.ForeColor = Color.DimGray;
            this.dgvHotelBooking.DefaultCellStyle.SelectionBackColor = Color.Blue;
            this.dgvTourPackage.ColumnHeadersDefaultCellStyle.Font = new Font("Zawgyi-One", 8f, FontStyle.Bold);
            this.dgvTourPackage.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.dgvTourPackage.DefaultCellStyle.Font = new Font("Zawgyi-One", 8f);
            this.dgvTourPackage.DefaultCellStyle.ForeColor = Color.DimGray;
            this.dgvTourPackage.DefaultCellStyle.SelectionBackColor = Color.Blue;
            this.dgvTourPackageList.ColumnHeadersDefaultCellStyle.Font = new Font("Zawgyi-One", 8f, FontStyle.Bold);
            this.dgvTourPackageList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.dgvTourPackageList.DefaultCellStyle.Font = new Font("Zawgyi-One", 8f);
            this.dgvTourPackageList.DefaultCellStyle.ForeColor = Color.DimGray;
            this.dgvTourPackageList.DefaultCellStyle.SelectionBackColor = Color.Blue;
            this.dgvPassport.ColumnHeadersDefaultCellStyle.Font = new Font("Zawgyi-One", 8f, FontStyle.Bold);
            this.dgvPassport.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.dgvPassport.DefaultCellStyle.Font = new Font("Zawgyi-One", 8f);
            this.dgvPassport.DefaultCellStyle.ForeColor = Color.DimGray;
            this.dgvPassport.DefaultCellStyle.SelectionBackColor = Color.Blue;
            this.dgvPassportList.ColumnHeadersDefaultCellStyle.Font = new Font("Zawgyi-One", 8f, FontStyle.Bold);
            this.dgvPassportList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.dgvPassportList.DefaultCellStyle.Font = new Font("Zawgyi-One", 8f);
            this.dgvPassportList.DefaultCellStyle.ForeColor = Color.DimGray;
            this.dgvPassportList.DefaultCellStyle.SelectionBackColor = Color.Blue;
            this.dgvCarRental.ColumnHeadersDefaultCellStyle.Font = new Font("Zawgyi-One", 8f, FontStyle.Bold);
            this.dgvCarRental.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.dgvCarRental.DefaultCellStyle.Font = new Font("Zawgyi-One", 8f);
            this.dgvCarRental.DefaultCellStyle.ForeColor = Color.DimGray;
            this.dgvCarRental.DefaultCellStyle.SelectionBackColor = Color.Blue;
            this.dgvCarRentalList.ColumnHeadersDefaultCellStyle.Font = new Font("Zawgyi-One", 8f, FontStyle.Bold);
            this.dgvCarRentalList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.dgvCarRentalList.DefaultCellStyle.Font = new Font("Zawgyi-One", 8f);
            this.dgvCarRentalList.DefaultCellStyle.ForeColor = Color.DimGray;
            this.dgvCarRentalList.DefaultCellStyle.SelectionBackColor = Color.Blue;
        }

        // Token: 0x06000DEB RID: 3563 RVA: 0x00091588 File Offset: 0x0008F788
        private void txtCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cboPaymentTerm.Focus();
            }
        }

        // Token: 0x06000DEC RID: 3564 RVA: 0x000915B8 File Offset: 0x0008F7B8
        private void txtContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtCompanyName.Focus();
            }
        }

        // Token: 0x06000DED RID: 3565 RVA: 0x000915E8 File Offset: 0x0008F7E8
        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtEmail.Focus();
            }
        }

        // Token: 0x06000DEE RID: 3566 RVA: 0x00091618 File Offset: 0x0008F818
        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtAddress.Focus();
            }
        }

        // Token: 0x06000DEF RID: 3567 RVA: 0x00091648 File Offset: 0x0008F848
        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtsupplier.Focus();
            }
        }

        // Token: 0x06000DF0 RID: 3568 RVA: 0x00091678 File Offset: 0x0008F878
        private void btnBooking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnBooking_Click(sender, e);
            }
            else
            {
                this.btnCancel.Focus();
            }
        }

        // Token: 0x06000DF1 RID: 3569 RVA: 0x000916B4 File Offset: 0x0008F8B4
        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnCancel_Click(sender, e);
            }
        }

        // Token: 0x06000DF2 RID: 3570 RVA: 0x000916E4 File Offset: 0x0008F8E4
        private void cboFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cboTo.Focus();
            }
        }

        // Token: 0x06000DF3 RID: 3571 RVA: 0x00091714 File Offset: 0x0008F914
        private void cboTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpDate.Focus();
            }
        }

        // Token: 0x06000DF4 RID: 3572 RVA: 0x00091741 File Offset: 0x0008F941
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
        }

        // Token: 0x06000DF5 RID: 3573 RVA: 0x00091744 File Offset: 0x0008F944
        private void dtpDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpTime.Focus();
            }
        }

        // Token: 0x06000DF6 RID: 3574 RVA: 0x00091774 File Offset: 0x0008F974
        private void dtpTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpaDate.Focus();
            }
        }

        // Token: 0x06000DF7 RID: 3575 RVA: 0x000917A4 File Offset: 0x0008F9A4
        private void cboClass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cboAVehicalName.Focus();
            }
        }

        // Token: 0x06000DF8 RID: 3576 RVA: 0x000917D4 File Offset: 0x0008F9D4
        private void txtFlight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtNo.Focus();
            }
        }

        // Token: 0x06000DF9 RID: 3577 RVA: 0x00091804 File Offset: 0x0008FA04
        private void txtNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnAdd_Click(sender, e);
            }
        }

        // Token: 0x06000DFA RID: 3578 RVA: 0x00091830 File Offset: 0x0008FA30
        private void txtFare_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal num = decimal.Parse((this.txtFare.Text == "") ? "0" : this.txtFare.Text);
                decimal num2 = decimal.Parse((this.txtTotalFare.Text == "") ? "0" : this.txtTotalFare.Text);
                this.txtFare.Text = num.ToString();
                this.txtpTotalFare.Text = num.ToString();
                this.txtbTax.Focus();
            }
        }

        // Token: 0x06000DFB RID: 3579 RVA: 0x000918E4 File Offset: 0x0008FAE4
        private void txtbTax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal d = decimal.Parse((this.txtFare.Text == "") ? "0" : this.txtFare.Text);
                decimal num = decimal.Parse((this.txtTotalFare.Text == "") ? "0" : this.txtTotalFare.Text);
                decimal d2 = decimal.Parse((this.txtbTax.Text == "") ? "0" : this.txtbTax.Text);
                decimal num2 = decimal.Parse((this.txtTax.Text == "") ? "0" : this.txtTax.Text);
                this.txtbTax.Text = d2.ToString();
                this.txtpTotalFare.Text = (d + d2).ToString();
                this.btnPadd_Click(sender, e);
            }
        }

        // Token: 0x06000DFC RID: 3580 RVA: 0x00091A00 File Offset: 0x0008FC00
        private void btnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnAdd_Click(sender, e);
                this.cboFrom.Focus();
            }
        }

        // Token: 0x06000DFD RID: 3581 RVA: 0x00091A38 File Offset: 0x0008FC38
        private void btnPadd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnPadd_Click(sender, e);
                this.txtPassenger.Focus();
            }
        }

        // Token: 0x06000DFE RID: 3582 RVA: 0x00091A70 File Offset: 0x0008FC70
        private void txtpassport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboPassengerType.Focus();
            }
        }

        // Token: 0x06000DFF RID: 3583 RVA: 0x00091A94 File Offset: 0x0008FC94
        private void txtpassName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpbookingdate.Focus();
            }
        }

        // Token: 0x06000E00 RID: 3584 RVA: 0x00091AC4 File Offset: 0x0008FCC4
        private void dtpbookingdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cboAType.Focus();
            }
        }

        // Token: 0x06000E01 RID: 3585 RVA: 0x00091AF4 File Offset: 0x0008FCF4
        private void BindTicket()
        {
            this.cboAVehicalName.DataSource = null;
            List<Vehical> tbList = new List<Vehical>();
            tbList = (from x in this.entity.Vehicals
                      where x.IsDelete == (bool?)false
                      select x).ToList<Vehical>();
            this.cboAVehicalName.DataSource = tbList;
            this.cboAVehicalName.DisplayMember = "Name";
            this.cboAVehicalName.ValueMember = "Name";
            this.cboAVehicalName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cboAVehicalName.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.txtTBookingNo.Text = this.entity.GetFormNo("AirTicket").FirstOrDefault<string>().ToString();
            this.cboFrom.DataSource = null;
            List<Segment> i = new List<Segment>();
            i = (from x in this.entity.Segments
                 where x.IsDelete == (bool?)false
                 select x).ToList<Segment>();
            this.cboFrom.DataSource = i;
            this.cboFrom.DisplayMember = "Code";
            this.cboFrom.ValueMember = "Code";
            this.cboFrom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cboFrom.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cboTo.DataSource = null;
            List<Segment> dataSource = new List<Segment>();
            dataSource = (from x in this.entity.Segments
                          where x.IsDelete == (bool?)false
                          select x).ToList<Segment>();
            this.cboTo.DataSource = dataSource;
            this.cboTo.DisplayMember = "Code";
            this.cboTo.ValueMember = "Code";
            this.cboTo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cboTo.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cboClass.DataSource = null;
            List<Class> dataSource2 = new List<Class>();
            dataSource2 = (from x in this.entity.Classes
                           where x.IsDelete == (bool?)false
                           select x).ToList<Class>();
            this.cboClass.DataSource = dataSource2;
            this.cboClass.DisplayMember = "Name";
            this.cboClass.ValueMember = "Name";
            this.cboClass.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cboClass.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cboPaymentTerm.DataSource = null;
            List<PaymentTerm> dataSource3 = new List<PaymentTerm>();
            dataSource3 = (from x in this.entity.PaymentTerms
                           where x.IsDelete == (bool?)false
                           select x).ToList<PaymentTerm>();
            this.cboPaymentTerm.DataSource = dataSource3;
            this.cboPaymentTerm.DisplayMember = "Description";
            this.cboPaymentTerm.ValueMember = "Code";
            this.cboPaymentTerm.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cboPaymentTerm.AutoCompleteSource = AutoCompleteSource.ListItems;

            this.cboIncomeType.DataSource = null;
            List<IncomeType> dataSource5 = new List<IncomeType>();
            dataSource5 = (from x in this.entity.IncomeType
                           where x.IsDelete == (bool?)false
                           select x).ToList<IncomeType>();
            this.cboIncomeType.DataSource = dataSource5;
            this.cboIncomeType.DisplayMember = "Description";
            this.cboIncomeType.ValueMember = "Description";
            this.cboIncomeType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cboIncomeType.AutoCompleteSource = AutoCompleteSource.ListItems;

            this.cboCurrency.DataSource = null;
            List<Currency> dataSource4 = new List<Currency>();
            dataSource4 = (from x in this.entity.Currencies
                           where x.IsDelete == (bool?)false
                           select x).ToList<Currency>();
            this.cboCurrency.DataSource = dataSource4;
            this.cboCurrency.DisplayMember = "Code";
            this.cboCurrency.ValueMember = "Code";
            this.cboCurrency.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cboCurrency.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        // Token: 0x06000E02 RID: 3586 RVA: 0x00092070 File Offset: 0x00090270
        private void CleanTicketBooking()
        {
            this.txtTBookingNo.Text = this.entity.GetFormNo("AirTicket").FirstOrDefault<string>().ToString();
            this.txtContactPerson.Text = "";
            this.txtCompanyName.Text = "";
            this.dtpbookingdate.Value = DateTime.Now;
            this.txtPhone.Text = "";
            this.txtEmail.Text = "";
            this.txtAddress.Text = "";
            this.cboFrom.SelectedIndex = 0;
            this.cboTo.SelectedIndex = 0;
            this.cboClass.SelectedIndex = 0;
            this.dtpTime.Value = DateTime.Now;
            this.dtpTime.Format = DateTimePickerFormat.Custom;
            this.dtpTime.CustomFormat = "HH:mm";
            this.dtpTime.ShowUpDown = true;
            this.dtpaTime.Value = DateTime.Now;
            this.dtpaTime.Format = DateTimePickerFormat.Custom;
            this.dtpaTime.CustomFormat = "HH:mm";
            this.dtpaTime.ShowUpDown = true;
            this.txtFlight.Text = "";
            this.txtNo.Text = "0";
            this.txtPassenger.Text = "";
            this.txtTicker.Text = "";
            this.txtFare.Text = "0";
            this.txtbTax.Text = "0";
            this.txtpTotalFare.Text = "0";
            this.txtTax.Text = "0";
            this.txtTotalFare.Text = "0";
            this.txtTotalNo.Text = "0";
            this.cboPassengerType.SelectedIndex = 0;
            this.dgvFlight.Rows.Clear();
            this.dgvPassenger.Rows.Clear();
            this.btnPreview.Visible = false;
            this.btnBooking.Text = "Booking";
            this.txtSearch.Text = "";
            this.cboAType.SelectedIndex = 0;
            this.cboCurrency.Text = "MMK";
            this.txtAcurrate.Text = "1";
            this.cboAVehicalName.SelectedIndex = 0;
            this.cboIncomeType.SelectedIndex = 0;
            this.txtsupplier.Text = "";
        }

        // Token: 0x06000E03 RID: 3587 RVA: 0x000922F0 File Offset: 0x000904F0
        private void LoadBookingList()
        {
            this.dgvBookingList.Rows.Clear();
            List<TicketBooking> tb = new List<TicketBooking>();
            tb = (from x in this.entity.TicketBookings
                  where x.IsDelete == (bool?)false && x.Status != "I"
                  select x).ToList<TicketBooking>();
            for (int tf = 0; tf < tb.Count; tf++)
            {
                this.dgvBookingList.Rows.Add(new object[]
				{
					tf + 1,
					tb[tf].Date.Value.ToShortDateString(),
					tb[tf].CompanyName,
					tb[tf].ContactPerson,
					tb[tf].Type,
					0,
					0,
					0,
					tb[tf].InvoiceNo
				});
            }
        }

        // Token: 0x06000E04 RID: 3588 RVA: 0x0009249C File Offset: 0x0009069C
        private void LoadCreditList()
        {
            List<CheckCreditList_Result> fare = new List<CheckCreditList_Result>();
            fare = this.entity.SP_CheckCreditList(new DateTime?(dtppfrom.Value), new DateTime?(dtppto.Value), "", "", new int?(0)).ToList<CheckCreditList_Result>();
            this.dgvCreditList.Rows.Clear();
            this.lblRows.Text = fare.Count<CheckCreditList_Result>().ToString();
            if (fare.Count > 0)
            {
                for (int Tax = 0; Tax < fare.Count<CheckCreditList_Result>(); Tax++)
                {
                    this.dgvCreditList.Rows.Add(new object[]
					{
						Tax + 1,
						fare[Tax].Date,
						fare[Tax].VoucherNo,
						fare[Tax].ContactPerson,
						fare[Tax].CompanyName,
						fare[Tax].Transaction,
						fare[Tax].Amount,
						fare[Tax].PaidAmount,
						fare[Tax].Currency,
						fare[Tax].Peroid
					});
                    if (fare[Tax].Peroid < 1)
                    {
                        this.dgvCreditList.Rows[Tax].DefaultCellStyle.BackColor = Color.Gray;
                    }
                    else if (fare[Tax].Peroid < 8)
                    {
                        this.dgvCreditList.Rows[Tax].DefaultCellStyle.BackColor = Color.Pink;
                    }
                }
            }
        }

        // Token: 0x06000E05 RID: 3589 RVA: 0x0009268C File Offset: 0x0009088C
        private void BindBooking(string Invoice)
        {
            TicketBooking totaltax = new TicketBooking();
            totaltax = (from x in this.entity.TicketBookings
                        where x.InvoiceNo == Invoice && x.IsDelete == (bool?)false
                        select x).FirstOrDefault<TicketBooking>();
            if (totaltax != null)
            {
                this.txtTBookingNo.Text = totaltax.InvoiceNo;
                this.txtContactPerson.Text = totaltax.ContactPerson;
                this.txtCompanyName.Text = totaltax.CompanyName;
                this.cboCurrency.Text = totaltax.Currency;
                this.txtAcurrate.Text = totaltax.Rate.ToString();
                this.cboPaymentTerm.SelectedValue = totaltax.PaymentCode;
                this.cboIncomeType.Text = totaltax.t2;
                this.txtsupplier.Text = totaltax.t3;
                this.dtpbookingdate.Value = totaltax.Date.Value;
                this.txtPhone.Text = totaltax.Phone;
                this.txtEmail.Text = totaltax.Email;
                this.txtAddress.Text = totaltax.Address;
                this.txtTotalNo.Text = totaltax.NoSeat.ToString();
                this.txtTax.Text = totaltax.Tax.ToString();
                this.txtTotalFare.Text = totaltax.Total.ToString();
                if (totaltax.IsTransit == true)
                {
                    this.chkIsTransit.Checked = true;
                }
                else
                {
                    this.chkIsTransit.Checked = false;
                }
                this.cboAType.SelectedItem = totaltax.Type.ToString();
            }
            List<TicketFlight> totalfare = new List<TicketFlight>();
            totalfare = (from x in this.entity.TicketFlights
                         where x.InvoiceNo == Invoice && x.IsDelete == (bool?)false
                         select x).ToList<TicketFlight>();
            if (totalfare.Count > 0)
            {
                this.dgvFlight.Rows.Clear();
                for (int i = 0; i < totalfare.Count; i++)
                {
                    this.dgvFlight.Rows.Add(new object[]
					{
						totalfare[i].From,
						totalfare[i].To,
						totalfare[i].Date,
						totalfare[i].Time,
						totalfare[i].ArrivalDate,
						totalfare[i].ArrivalTime,
						totalfare[i].Class,
						totalfare[i].AirLine,
						totalfare[i].Flight,
						totalfare[i].NoSeats,
						0,
						totalfare[i].ID
					});
                }
            }
            List<TicketPassenger> list = new List<TicketPassenger>();
            list = (from x in this.entity.TicketPassengers
                    where x.InvoiceNo == Invoice && x.IsDelete == (bool?)false
                    select x).ToList<TicketPassenger>();
            if (list.Count > 0)
            {
                this.dgvPassenger.Rows.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    this.dgvPassenger.Rows.Add(new object[]
					{
						list[i].PassengerName,
						list[i].t1,
						list[i].Type,
						list[i].TicketNo,
						list[i].Fare,
						list[i].tax,
						list[i].TotalFare,
						0,
						list[i].ID
					});
                }
            }
        }

        // Token: 0x06000E06 RID: 3590 RVA: 0x00092CE4 File Offset: 0x00090EE4
        private void CalculateAirTicketAmount()
        {
            decimal c = decimal.Parse((this.txtFare.Text == "") ? "0" : this.txtFare.Text);
            int p = int.Parse((this.txtbTax.Text == "") ? "0" : this.txtbTax.Text);
            decimal cu = decimal.Parse((this.txtpTotalFare.Text == "") ? "0" : this.txtpTotalFare.Text);
            int h = int.Parse((this.txtTax.Text == "") ? "0" : this.txtTax.Text);
            decimal req = decimal.Parse((this.txtTotalFare.Text == "") ? "0" : this.txtTotalFare.Text);
            this.txtTax.Text = (p + h).ToString();
            this.txtTotalFare.Text = (cu + req).ToString();
        }

        // Token: 0x06000E07 RID: 3591 RVA: 0x00092E14 File Offset: 0x00091014
        private void ReCalculateAirTicketAmount(decimal tax, decimal Amount)
        {
            decimal tbList = decimal.Parse((this.txtTax.Text == "") ? "0" : this.txtTax.Text);
            decimal i = decimal.Parse((this.txtTotalFare.Text == "") ? "0" : this.txtTotalFare.Text);
            this.txtTax.Text = (tbList - tax).ToString();
            this.txtTotalFare.Text = (i - Amount).ToString();
        }

        // Token: 0x06000E08 RID: 3592 RVA: 0x00092EB8 File Offset: 0x000910B8
        private void CleanHotelBooking()
        {
            this.txthInvoiceNo.Text = this.entity.GetFormNo("Hotel").FirstOrDefault<string>().ToString();
            this.txthContactPerson.Text = "";
            this.txthCompanyName.Text = "";
            this.txthContactPhone.Text = "";
            this.txthEmail.Text = "";
            this.dtphHotelBooking.Value = DateTime.Now;
            this.dtpArrivalDate.Value = DateTime.Now;
            this.dtpDepatureDate.Value = DateTime.Now;
            this.txtPaxNo.Text = "0";
            this.txtNightNo.Text = "0";
            this.txthRemark.Text = "";
            this.txthRate.Text = "0";
            this.txtRoomNo.Text = "0";
            this.txthAmount.Text = "0";
            this.txtTotalRoom.Text = "0";
            this.txtTotalhAmount.Text = "0";
            this.txtDiscount.Text = "0";
            this.txtBalance.Text = "0";
            this.txthSearch.Text = "";
            this.cbohCurrency.Text = "MMK";
            this.txthCurRate.Text = "1";
            this.txthSupplier.Text = "";
            this.cboRoomType.DataSource = null;
            List<RoomType> tb = new List<RoomType>();
            tb = (from x in this.entity.RoomTypes
                  where x.IsDelete == (bool?)false
                  select x).ToList<RoomType>();
            this.cboRoomType.DataSource = tb;
            this.cboRoomType.DisplayMember = "Description";
            this.cboRoomType.ValueMember = "Code";
            this.cboRoomType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cboRoomType.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cbohPaymentTerm.DataSource = null;
            List<PaymentTerm> tf = new List<PaymentTerm>();
            tf = (from x in this.entity.PaymentTerms
                  where x.IsDelete == (bool?)false
                  select x).ToList<PaymentTerm>();
            this.cbohPaymentTerm.DataSource = tf;
            this.cbohPaymentTerm.DisplayMember = "Description";
            this.cbohPaymentTerm.ValueMember = "Code";
            this.cbohPaymentTerm.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbohPaymentTerm.AutoCompleteSource = AutoCompleteSource.ListItems;

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

            this.cbohCurrency.DataSource = null;
            List<Currency> i = new List<Currency>();
            i = (from x in this.entity.Currencies
                 where x.IsDelete == (bool?)false
                 select x).ToList<Currency>();
            this.cbohCurrency.DataSource = i;
            this.cbohCurrency.DisplayMember = "Code";
            this.cbohCurrency.ValueMember = "Code";
            this.cbohCurrency.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbohCurrency.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cbohHotel.DataSource = null;
            List<Hotel> services = new List<Hotel>();
            services = (from x in this.entity.Hotels
                        where x.IsDelete == (bool?)false
                        select x).ToList<Hotel>();
            this.cbohHotel.DataSource = services;
            this.cbohHotel.DisplayMember = "Name";
            this.cbohHotel.ValueMember = "Name";
            this.cbohHotel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbohHotel.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.dgvRoom.Rows.Clear();
            this.btnhPreview.Visible = false;
            this.btnHotelBooking.Text = "Booking";
            this.hDiscount = 0m;
            this.chkhOtherServices.Items.Clear();
            List<Services> req = new List<Services>();
            req = (from x in this.entity.Services
                   where x.Transaction == "Hotel" && x.IsDelete == (bool?)false
                   select x).ToList<Services>();
            foreach (Services sr in req)
            {
                this.chkhOtherServices.Items.Add(sr.Description);
            }
            this.chkhOtherServices.CheckOnClick = true;
        }

        // Token: 0x06000E09 RID: 3593 RVA: 0x00093544 File Offset: 0x00091744
        private void LoadHotelBookingList()
        {
            this.dgvHotelBooking.Rows.Clear();
            List<HotelBooking> hrate = new List<HotelBooking>();
            hrate = (from x in this.entity.HotelBookings
                     where x.IsDelete == (bool?)false && x.Status != "I"
                     select x).ToList<HotelBooking>();
            for (int Rno = 0; Rno < hrate.Count; Rno++)
            {
                this.dgvHotelBooking.Rows.Add(new object[]
				{
					Rno + 1,
					hrate[Rno].InvoiceDate.Value.ToShortDateString(),
					hrate[Rno].InvoiceNo,
					hrate[Rno].CompanyName,
					hrate[Rno].ContactPerson
				});
            }
        }

        // Token: 0x06000E0A RID: 3594 RVA: 0x000936C4 File Offset: 0x000918C4
        private void BindHotelBooking(string Invoice)
        {
            HotelBooking tno = new HotelBooking();
            tno = (from x in this.entity.HotelBookings
                   where x.InvoiceNo == Invoice && x.IsDelete == (bool?)false
                   select x).FirstOrDefault<HotelBooking>();
            if (tno != null)
            {
                this.txthInvoiceNo.Text = tno.InvoiceNo;
                this.txthContactPerson.Text = tno.ContactPerson;
                this.txthCompanyName.Text = tno.CompanyName;
                this.txthContactPhone.Text = tno.ContactPhone;
                this.cbohPaymentTerm.SelectedValue = tno.PaymentTerm;
                this.txthEmail.Text = tno.Email;
                this.cbohIncomeType.SelectedValue = tno.t1;
                this.txthSupplier.Text = tno.t2;
                this.dtphHotelBooking.Value = tno.InvoiceDate.Value;
                this.dtpArrivalDate.Value = tno.ArrivalDate.Value;
                this.dtpDepatureDate.Value = tno.DepatureDate.Value;
                this.txthAddress.Text = tno.Address;
                this.txthRemark.Text = tno.Remark;
                this.txtPaxNo.Text = tno.NoofPax.ToString();
                this.txtNightNo.Text = tno.NoofNight.ToString();
                this.txtTotalRoom.Text = tno.TotalRoom.ToString();
                this.txtDiscount.Text = tno.DiscountPercent.ToString();
                this.txtTotalhAmount.Text = tno.TotalAmount.ToString();
                this.txtBalance.Text = tno.Balance.ToString();
                this.cbohHotel.Text = tno.Hotel.ToString();
                this.cbohCurrency.Text = tno.Currency;
                this.txthCurRate.Text = tno.Rate.ToString();
            }
            List<HotelRoom> Night = new List<HotelRoom>();
            Night = (from x in this.entity.HotelRooms
                     where x.InvoiceNo == Invoice && x.IsDelete == (bool?)false
                     select x).ToList<HotelRoom>();
            if (Night.Count > 0)
            {
                this.dgvRoom.Rows.Clear();
                for (int tamount = 0; tamount < Night.Count; tamount++)
                {
                    this.dgvRoom.Rows.Add(new object[]
					{
						Night[tamount].RoomType,
						Night[tamount].Rate,
						Night[tamount].NoofRoom,
						Night[tamount].Amount,
						0,
						Night[tamount].ID,
						Night[tamount].RoomCode
					});
                }
            }
            if (this.chkhOtherServices.CheckedItems.Count == 0)
            {
                this.chkhOtherServices.Items.Clear();
                List<Services> list = new List<Services>();
                list = (from x in this.entity.Services
                        where x.Transaction == "Hotel" && x.IsDelete == (bool?)false
                        select x).ToList<Services>();
                List<ServicesOrRequirement> list2 = new List<ServicesOrRequirement>();
                list2 = (from x in this.entity.ServicesOrRequirement
                         where x.InvoiceNo == Invoice && x.Transaction == "Hotel"
                         select x).ToList<ServicesOrRequirement>();
                foreach (Services services in list)
                {
                    string balance = "";
                    for (int tamount = 0; tamount < list2.Count; tamount++)
                    {
                        if (services.Description == list2[tamount].Description)
                        {
                            balance = list2[tamount].Description;
                        }
                    }
                    if (balance != "")
                    {
                        this.chkhOtherServices.Items.Add(services.Description, CheckState.Checked);
                    }
                    else
                    {
                        this.chkhOtherServices.Items.Add(services.Description);
                    }
                }
            }
            this.chkhOtherServices.CheckOnClick = true;
        }

        // Token: 0x06000E0B RID: 3595 RVA: 0x00093E20 File Offset: 0x00092020
        private void CalculateHotelAmount()
        {
            decimal c = decimal.Parse((this.txthRate.Text == "") ? "0" : this.txthRate.Text);
            int p = int.Parse((this.txtRoomNo.Text == "") ? "0" : this.txtRoomNo.Text);
            decimal cu = decimal.Parse((this.txthAmount.Text == "") ? "0" : this.txthAmount.Text);
            int pak = int.Parse((this.txtNightNo.Text == "") ? "0" : this.txtNightNo.Text);
            int req = int.Parse((this.txtTotalRoom.Text == "") ? "0" : this.txtTotalRoom.Text);
            decimal var = this.hDiscount;
            decimal d = decimal.Parse((this.txtTotalhAmount.Text == "") ? "0" : this.txtTotalhAmount.Text);
            decimal num = decimal.Parse((this.txtBalance.Text == "") ? "0" : this.txtBalance.Text);
            this.txtTotalRoom.Text = (p + req).ToString();
            this.txtTotalhAmount.Text = (d + cu).ToString();
            this.txtBalance.Text = ((d + cu) * pak - var).ToString();
        }

        // Token: 0x06000E0C RID: 3596 RVA: 0x00093FE8 File Offset: 0x000921E8
        private void ReCalculateHotelAmount(int no, decimal rate, decimal Amount)
        {
            int tbList = int.Parse((this.txtTotalRoom.Text == "") ? "0" : this.txtTotalRoom.Text);
            int i = int.Parse((this.txtNightNo.Text == "") ? "0" : this.txtNightNo.Text);
            decimal d = decimal.Parse((this.txtTotalhAmount.Text == "") ? "0" : this.txtTotalhAmount.Text);
            decimal d2 = decimal.Parse((this.txtBalance.Text == "") ? "0" : this.txtBalance.Text);
            this.txtTotalRoom.Text = (tbList - no).ToString();
            this.txtTotalhAmount.Text = (d - Amount).ToString();
            this.txtBalance.Text = (d2 - Amount * i).ToString();
        }

        // Token: 0x06000E0D RID: 3597 RVA: 0x00094110 File Offset: 0x00092310
        private void CleanTourPackageBooking()
        {
            this.txtTInvoiceNo.Text = this.entity.GetFormNo("Tour").FirstOrDefault<string>().ToString();
            this.txtTContactPerson.Text = "";
            this.txtTCompany.Text = "";
            this.txtTContactPhone.Text = "";
            this.txtTemail.Text = "";
            this.txttsupplier.Text = "";
            this.dtpTInvoiceDate.Value = DateTime.Now;
            this.dtpTArrivalDate.Value = DateTime.Now;
            this.dtpTDepatureDate.Value = DateTime.Now;
            this.txtTNofN.Text = "0";
            this.txtTRemark.Text = "";
            this.txtTCurRate.Text = "1";
            this.txtMeetPoing.Text = "";
            this.cboTTransportation.SelectedIndex = 0;
            this.txtTAdress.Text = "";
            this.txtTPrice.Text = "0";
            this.txtTNoofPax.Text = "0";
            this.txtTAmount.Text = "0";
            this.txtTFlightNo.Text = "";
            this.txtTtotalAmount.Text = "0";
            this.txtTDiscount.Text = "0";
            this.txtTBalance.Text = "0";
            this.txtTSearch.Text = "";
            this.cboTAirLine.DataSource = null;
            List<Vehical> tb = new List<Vehical>();
            tb = (from x in this.entity.Vehicals
                  where x.IsDelete == (bool?)false
                  select x).ToList<Vehical>();
            this.cboTAirLine.DataSource = tb;
            this.cboTAirLine.DisplayMember = "Name";
            this.cboTAirLine.ValueMember = "Name";
            this.cboTAirLine.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cboTAirLine.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cboTPayment.DataSource = null;
            List<PaymentTerm> tf = new List<PaymentTerm>();
            tf = (from x in this.entity.PaymentTerms
                  where x.IsDelete == (bool?)false
                  select x).ToList<PaymentTerm>();
            this.cboTPayment.DataSource = tf;
            this.cboTPayment.DisplayMember = "Description";
            this.cboTPayment.ValueMember = "Code";
            this.cboTPayment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cboTPayment.AutoCompleteSource = AutoCompleteSource.ListItems;

            this.cbotIncomeType.DataSource = null;
            List<IncomeType> l = new List<IncomeType>();
            l = (from x in this.entity.IncomeType
                 where x.IsDelete == (bool?)false
                 select x).ToList<IncomeType>();
            this.cbotIncomeType.DataSource = l;
            this.cbotIncomeType.DisplayMember = "Description";
            this.cbotIncomeType.ValueMember = "Description";
            this.cbotIncomeType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbotIncomeType.AutoCompleteSource = AutoCompleteSource.ListItems;


            this.cboTCurrency.DataSource = null;
            List<Currency> i = new List<Currency>();
            i = (from x in this.entity.Currencies
                 where x.IsDelete == (bool?)false
                 select x).ToList<Currency>();
            this.cboTCurrency.DataSource = i;
            this.cboTCurrency.DisplayMember = "Code";
            this.cboTCurrency.ValueMember = "Code";
            this.cboTCurrency.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cboTCurrency.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cboTPackage.DataSource = null;
            List<Package> services = new List<Package>();
            services = (from x in this.entity.Packages
                        where x.IsDelete == (bool?)false
                        select x).ToList<Package>();
            this.cboTPackage.DataSource = services;
            this.cboTPackage.DisplayMember = "Description";
            this.cboTPackage.ValueMember = "Code";
            this.cboTPackage.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cboTPackage.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.dgvTourPackage.Rows.Clear();
            this.btnTPreview.Visible = false;
            this.btnTourPackageBooking.Text = "Booking";
            this.tDiscount = 0m;
            this.txtTContactPerson.Focus();
            this.chkOtherService.Items.Clear();
            List<Services> req = new List<Services>();
            req = (from x in this.entity.Services
                   where x.Transaction == "Travel & Tour" && x.IsDelete == (bool?)false
                   select x).ToList<Services>();
            foreach (Services sr in req)
            {
                this.chkOtherService.Items.Add(sr.Description);
            }
            this.chkOtherService.CheckOnClick = true;
        }

        // Token: 0x06000E0E RID: 3598 RVA: 0x000947B4 File Offset: 0x000929B4
        private void LoadTourPackageBookingList()
        {
            this.dgvTourPackageList.Rows.Clear();
            List<TourBooking> tPrice = new List<TourBooking>();
            tPrice = (from x in this.entity.TourBookings
                      where x.IsDelete == (bool?)false && x.Status != "I"
                      select x).ToList<TourBooking>();
            for (int Paxno = 0; Paxno < tPrice.Count; Paxno++)
            {
                this.dgvTourPackageList.Rows.Add(new object[]
				{
					Paxno + 1,
					tPrice[Paxno].InvoiceDate.Value.ToShortDateString(),
					tPrice[Paxno].InvoiceNo,
					tPrice[Paxno].CompanyName,
					tPrice[Paxno].ContactPerson
				});
            }
        }

        // Token: 0x06000E0F RID: 3599 RVA: 0x00094934 File Offset: 0x00092B34
        private void BindTourPackageBooking(string Invoice)
        {
            TourBooking tPrice = new TourBooking();
            tPrice = (from x in this.entity.TourBookings
                      where x.InvoiceNo == Invoice && x.IsDelete == (bool?)false
                      select x).FirstOrDefault<TourBooking>();
            if (tPrice != null)
            {
                this.txtTInvoiceNo.Text = tPrice.InvoiceNo;
                this.txtTContactPerson.Text = tPrice.ContactPerson;
                this.txtTCompany.Text = tPrice.CompanyName;
                this.txtTContactPhone.Text = tPrice.ContactPhone;
                this.cboTPayment.SelectedValue = tPrice.PaymentTerm;
                this.cbotIncomeType.SelectedValue = tPrice.t1;
                this.txttsupplier.Text = tPrice.t2;
                this.txtTemail.Text = tPrice.Email;
                this.dtpTInvoiceDate.Value = tPrice.InvoiceDate.Value;
                this.dtpTArrivalDate.Value = tPrice.ArrivalDate.Value;
                this.dtpTDepatureDate.Value = tPrice.DepatureDate.Value;
                this.txtTAdress.Text = tPrice.Address;
                this.txtTRemark.Text = tPrice.Remark;
                this.txtTNofN.Text = tPrice.NoofNight.ToString();
                this.txtTCurRate.Text = tPrice.Rate.ToString();
                this.txtMeetPoing.Text = tPrice.MeetingPoint;
                this.txtTtotalAmount.Text = tPrice.TotalAmount.ToString();
                this.txtTDiscount.Text = tPrice.Discount_Percent.ToString();
                this.tDiscount = tPrice.Discount.Value;
                this.txtTBalance.Text = tPrice.Balance.ToString();
                this.cboTTransportation.Text = tPrice.Type.ToString();
                this.cboTCurrency.Text = tPrice.Currency;
                this.txtTCurRate.Text = tPrice.Rate.ToString();
                this.txtTSearch.Text = "";
            }
            List<TourPackage> Paxno = new List<TourPackage>();
            Paxno = (from x in this.entity.TourPackages
                     where x.InvoiceNo == Invoice && x.IsDelete == (bool?)false
                     select x).ToList<TourPackage>();
            if (Paxno.Count > 0)
            {
                this.dgvTourPackage.Rows.Clear();
                for (int Amount = 0; Amount < Paxno.Count; Amount++)
                {
                    this.dgvTourPackage.Rows.Add(new object[]
					{
						Paxno[Amount].PackageDescription,
						Paxno[Amount].Price,
						Paxno[Amount].NoofPax,
						Paxno[Amount].Amount,
						Paxno[Amount].AirLine,
						Paxno[Amount].FlightNo,
						0,
						Paxno[Amount].ID,
						Paxno[Amount].PackageCode
					});
                }
            }
            if (this.chkOtherService.CheckedItems.Count == 0)
            {
                this.chkOtherService.Items.Clear();
                List<Services> TotalAmount = new List<Services>();
                TotalAmount = (from x in this.entity.Services
                               where x.Transaction == "Travel & Tour" && x.IsDelete == (bool?)false
                               select x).ToList<Services>();
                List<ServicesOrRequirement> Balance = new List<ServicesOrRequirement>();
                Balance = (from x in this.entity.ServicesOrRequirement
                           where x.InvoiceNo == Invoice && x.Transaction == "Travel & Tour"
                           select x).ToList<ServicesOrRequirement>();
                foreach (Services services in TotalAmount)
                {
                    string Discount = "";
                    for (int Amount = 0; Amount < Balance.Count; Amount++)
                    {
                        if (services.Description == Balance[Amount].Description)
                        {
                            Discount = Balance[Amount].Description;
                        }
                    }
                    if (Discount != "")
                    {
                        this.chkOtherService.Items.Add(services.Description, CheckState.Checked);
                    }
                    else
                    {
                        this.chkOtherService.Items.Add(services.Description);
                    }
                }
            }
            this.chkOtherService.CheckOnClick = true;
        }

        // Token: 0x06000E10 RID: 3600 RVA: 0x000950C8 File Offset: 0x000932C8
        private void CalculateTourPackageAmount()
        {
            decimal p = decimal.Parse((this.txtTPrice.Text == "") ? "0" : this.txtTPrice.Text);
            int cu = int.Parse((this.txtTNoofPax.Text == "") ? "0" : this.txtTNoofPax.Text);
            decimal req = decimal.Parse((this.txtTAmount.Text == "") ? "0" : this.txtTAmount.Text);
            decimal var = this.tDiscount;
            decimal d = decimal.Parse((this.txtTtotalAmount.Text == "") ? "0" : this.txtTtotalAmount.Text);
            decimal num = decimal.Parse((this.txtTBalance.Text == "") ? "0" : this.txtTBalance.Text);
            this.txtTAmount.Text = (p * cu).ToString();
            this.txtTtotalAmount.Text = (d + req).ToString();
            this.txtTBalance.Text = (d + req - var).ToString();
        }

        // Token: 0x06000E11 RID: 3601 RVA: 0x0009522C File Offset: 0x0009342C
        private void ReCalculateTourPackageAmount(int pno, decimal Price, decimal amt)
        {
            decimal tbList = decimal.Parse((this.txtTPrice.Text == "") ? "0" : this.txtTPrice.Text);
            int i = int.Parse((this.txtTNoofPax.Text == "") ? "0" : this.txtTNoofPax.Text);
            decimal d = decimal.Parse((this.txtTAmount.Text == "") ? "0" : this.txtTAmount.Text);
            decimal num = this.tDiscount;
            decimal d2 = decimal.Parse((this.txtTtotalAmount.Text == "") ? "0" : this.txtTtotalAmount.Text);
            decimal d3 = decimal.Parse((this.txtTBalance.Text == "") ? "0" : this.txtTBalance.Text);
            this.txtTAmount.Text = (d - Price).ToString();
            this.txtTtotalAmount.Text = (d2 - amt).ToString();
            this.txtTBalance.Text = (d3 - amt).ToString();
        }

        // Token: 0x06000E12 RID: 3602 RVA: 0x00095384 File Offset: 0x00093584
        private void CleanPassportBooking()
        {
            this.txtPInvoice.Text = this.entity.GetFormNo("Passport").FirstOrDefault<string>().ToString();
            this.txtPContactPerson.Text = "";
            this.txtPContactPhone.Text = "";
            this.dtpPInvoiceDate.Value = DateTime.Now;
            this.txtPRemark.Text = "";
            this.txtPCurrRate.Text = "1";
            this.cboPType.SelectedIndex = 0;
            this.txtPName.Text = "";
            this.txtCharges.Text = "0";
            this.txtPNo.Text = "0";
            this.txtPtotalamount.Text = "0";
            this.txtpSupplier.Text = "";
            this.cboPPayment.DataSource = null;
            List<PaymentTerm> tf = new List<PaymentTerm>();
            tf = (from x in this.entity.PaymentTerms
                  where x.IsDelete == (bool?)false
                  select x).ToList<PaymentTerm>();
            this.cboPPayment.DataSource = tf;
            this.cboPPayment.DisplayMember = "Description";
            this.cboPPayment.ValueMember = "Code";
            this.cboPPayment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cboPPayment.AutoCompleteSource = AutoCompleteSource.ListItems;

            this.cbopIncomeType.DataSource = null;
            List<IncomeType> hit = new List<IncomeType>();
            hit = (from x in this.entity.IncomeType
                  where x.IsDelete == (bool?)false
                   select x).ToList<IncomeType>();
            this.cbopIncomeType.DataSource = hit;
            this.cbopIncomeType.DisplayMember = "Description";
            this.cbopIncomeType.ValueMember = "Description";
            this.cbopIncomeType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbopIncomeType.AutoCompleteSource = AutoCompleteSource.ListItems;

            this.cboPCurrency.DataSource = null;
            List<Currency> i = new List<Currency>();
            i = (from x in this.entity.Currencies
                 where x.IsDelete == (bool?)false
                 select x).ToList<Currency>();
            this.cboPCurrency.DataSource = i;
            this.cboPCurrency.DisplayMember = "Code";
            this.cboPCurrency.ValueMember = "Code";
            this.cboPCurrency.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cboPCurrency.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.chkRequirement.Items.Clear();
            List<RequireLetter> req = new List<RequireLetter>();
            req = (from x in this.entity.RequireLetter
                   where x.IsDelete == (bool?)false
                   select x).ToList<RequireLetter>();
            foreach (RequireLetter sr in req)
            {
                this.chkRequirement.Items.Add(sr.Description);
            }
            this.chkRequirement.CheckOnClick = true;
            this.dgvPassport.Rows.Clear();
            this.btnPPreview.Visible = false;
            this.btnPSave.Text = "Booking";
            this.cboPCurrency.Text = "MMK";
            this.txtPCurrRate.Text = "1";
            this.txtPContactPerson.Focus();
        }

        // Token: 0x06000E13 RID: 3603 RVA: 0x0009577C File Offset: 0x0009397C
        private void LoadPassportBookingList()
        {
            this.dgvPassportList.Rows.Clear();
            List<PassportBooking> no = new List<PassportBooking>();
            no = (from x in this.entity.PassportBookings
                  where x.IsDelete == (bool?)false && x.Status != "I"
                  select x).ToList<PassportBooking>();
            for (int charge = 0; charge < no.Count; charge++)
            {
                this.dgvPassportList.Rows.Add(new object[]
				{
					charge + 1,
					no[charge].InvoiceDate.Value.ToShortDateString(),
					no[charge].InvoiceNo,
					no[charge].ContactPerson,
					no[charge].Type,
					no[charge].TotalAmount
				});
            }
        }

        // Token: 0x06000E14 RID: 3604 RVA: 0x00095914 File Offset: 0x00093B14
        private void BindPassportBooking(string Invoice)
        {
            PassportBooking tb = new PassportBooking();
            tb = (from x in this.entity.PassportBookings
                  where x.InvoiceNo == Invoice && x.IsDelete == (bool?)false
                  select x).FirstOrDefault<PassportBooking>();
            if (tb != null)
            {
                this.txtPInvoice.Text = tb.InvoiceNo;
                this.txtPContactPerson.Text = tb.ContactPerson;
                this.txtPContactPhone.Text = tb.ContactPhone;
                this.cboPPayment.SelectedValue = tb.PaymentTerm;
                this.cboPCurrency.Text = tb.Currency;
                this.cbopIncomeType.Text = tb.t1;
                this.txtpSupplier.Text = tb.t2;
                this.dtpPInvoiceDate.Value = tb.InvoiceDate.Value;
                this.txtPRemark.Text = tb.Remark;
                this.txtPCurrRate.Text = tb.Rate.ToString();
                this.cboPType.Text = tb.Type;
                this.txtPNo.Text = tb.TotalNo.ToString();
                this.txtPtotalamount.Text = tb.TotalAmount.ToString();
                this.txtPSearch.Text = "";
            }
            List<PassportPerson> c = new List<PassportPerson>();
            c = (from x in this.entity.PassportPersons
                 where x.InvoiceNo == Invoice && x.IsDelete == (bool?)false
                 select x).ToList<PassportPerson>();
            if (c.Count > 0)
            {
                this.dgvPassport.Rows.Clear();
                for (int p = 0; p < c.Count; p++)
                {
                    this.dgvPassport.Rows.Add(new object[]
					{
						p + 1,
						c[p].Name,
						c[p].Charges,
						"",
						c[p].ID
					});
                }
            }
            if (this.chkRequirement.CheckedItems.Count == 0)
            {
                this.chkRequirement.Items.Clear();
                List<RequireLetter> cu = new List<RequireLetter>();
                cu = (from x in this.entity.RequireLetter
                      where (x.Type == tb.Type || x.Type == "Both") && x.IsDelete == (bool?)false
                      select x).ToList<RequireLetter>();
                List<ServicesOrRequirement> pak = new List<ServicesOrRequirement>();
                pak = (from x in this.entity.ServicesOrRequirement
                       where x.InvoiceNo == Invoice && x.Transaction == "Passport"
                       select x).ToList<ServicesOrRequirement>();
                foreach (RequireLetter requireLetter in cu)
                {
                    string a = "";
                    for (int p = 0; p < pak.Count; p++)
                    {
                        if (requireLetter.Description == pak[p].Description)
                        {
                            a = pak[p].Description;
                        }
                    }
                    if (a != "")
                    {
                        this.chkRequirement.Items.Add(requireLetter.Description, CheckState.Checked);
                    }
                    else
                    {
                        this.chkRequirement.Items.Add(requireLetter.Description);
                    }
                }
            }
            this.chkRequirement.CheckOnClick = true;
        }

        // Token: 0x06000E15 RID: 3605 RVA: 0x00096004 File Offset: 0x00094204
        private void CalculatePassportAmount()
        {
            int tbList = this.dgvPassport.Rows.Count;
            decimal i = 0m;
            for (int j = 0; j < this.dgvPassport.Rows.Count; j++)
            {
                i += Convert.ToDecimal(this.dgvPassport.Rows[j].Cells["colCharges"].Value);
            }
            this.txtPtotalamount.Text = i.ToString();
            this.txtPNo.Text = tbList.ToString();
        }

        // Token: 0x06000E16 RID: 3606 RVA: 0x000960A4 File Offset: 0x000942A4
        private void CleanCarRentalBooking()
        {
            this.txtcInvoiceNo.Text = this.entity.GetFormNo("CarRental").FirstOrDefault<string>().ToString();
            this.txtcContactPerson.Text = "";
            this.txtcContactPhone.Text = "";
            this.txtcEmail.Text = "";
            this.txtcCompanyName.Text = "";
            this.dtpcInvoiceDate.Value = DateTime.Now;
            this.dtpcArrivalDate.Value = DateTime.Now;
            this.dtpcDepatureDate.Value = DateTime.Now;
            this.txtcRemark.Text = "";
            this.txtcSupplier.Text = "";
            this.txtcRate.Text = "1";
            this.txtcAddress.Text = "";
            this.txtcTotalAmount.Text = "0";
            this.txtcCarNo.Text = "";
            this.txtcExtraCharges.Text = "0";
            this.txtcBalance.Text = "0";
            this.txtcSearch.Text = "";
            this.cbocCarType.DataSource = null;
            List<CarType> tb = new List<CarType>();
            tb = (from x in this.entity.CarType
                  where x.IsDelete == (bool?)false
                  select x).ToList<CarType>();
            this.cbocCarType.DataSource = tb;
            this.cbocCarType.DisplayMember = "Description";
            this.cbocCarType.ValueMember = "Code";
            this.cbocCarType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbocCarType.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cbocPayment.DataSource = null;
            List<PaymentTerm> tf = new List<PaymentTerm>();
            tf = (from x in this.entity.PaymentTerms
                  where x.IsDelete == (bool?)false
                  select x).ToList<PaymentTerm>();
            this.cbocPayment.DataSource = tf;
            this.cbocPayment.DisplayMember = "Description";
            this.cbocPayment.ValueMember = "Code";
            this.cbocPayment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbocPayment.AutoCompleteSource = AutoCompleteSource.ListItems;

            this.cbocIncomeType.DataSource = null;
            List<IncomeType> cit = new List<IncomeType>();
            cit = (from x in this.entity.IncomeType
                  where x.IsDelete == (bool?)false
                   select x).ToList<IncomeType>();
            this.cbocIncomeType.DataSource = cit;
            this.cbocIncomeType.DisplayMember = "Description";
            this.cbocIncomeType.ValueMember = "Description";
            this.cbocIncomeType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbocIncomeType.AutoCompleteSource = AutoCompleteSource.ListItems;

            this.cbocCurrency.DataSource = null;
            List<Currency> i = new List<Currency>();
            i = (from x in this.entity.Currencies
                 where x.IsDelete == (bool?)false
                 select x).ToList<Currency>();
            this.cbocCurrency.DataSource = i;
            this.cbocCurrency.DisplayMember = "Code";
            this.cbocCurrency.ValueMember = "Code";
            this.cbocCurrency.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbocCurrency.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cbocPeroid.DataSource = null;
            List<Peroid> dataSource = new List<Peroid>();
            dataSource = (from x in this.entity.Peroid
                          where x.IsDelete == (bool?)false
                          select x).ToList<Peroid>();
            this.cbocPeroid.DataSource = dataSource;
            this.cbocPeroid.DisplayMember = "Description";
            this.cbocPeroid.ValueMember = "Code";
            this.cbocPeroid.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbocPeroid.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.dgvCarRental.Rows.Clear();
            this.btncPreview.Visible = false;
            this.btnCBooking.Text = "Booking";
            this.txtcContactPerson.Focus();
        }

        // Token: 0x06000E17 RID: 3607 RVA: 0x00096594 File Offset: 0x00094794
        private void LoadCarRentalBookingList()
        {
            this.dgvCarRentalList.Rows.Clear();
            List<CarRentalBooking> amount = new List<CarRentalBooking>();
            amount = (from x in this.entity.CarRentalBooking
                      where x.IsDelete == (bool?)false && x.Status != "I"
                      select x).ToList<CarRentalBooking>();
            for (int totalamount = 0; totalamount < amount.Count; totalamount++)
            {
                this.dgvCarRentalList.Rows.Add(new object[]
				{
					totalamount + 1,
					amount[totalamount].InvoiceDate.Value.ToShortDateString(),
					amount[totalamount].InvoiceNo,
					amount[totalamount].CompanyName,
					amount[totalamount].ContactPerson
				});
            }
        }

        // Token: 0x06000E18 RID: 3608 RVA: 0x00096714 File Offset: 0x00094914
        private void BindCarRentalBooking(string Invoice)
        {
            CarRentalBooking from = new CarRentalBooking();
            from = (from x in this.entity.CarRentalBooking
                    where x.InvoiceNo == Invoice && x.IsDelete == (bool?)false
                    select x).FirstOrDefault<CarRentalBooking>();
            if (from != null)
            {
                this.txtcInvoiceNo.Text = from.InvoiceNo;
                this.txtcContactPerson.Text = from.ContactPerson;
                this.txtcContactPhone.Text = from.ContactPhone;
                this.txtcEmail.Text = from.Email;
                this.txtcSupplier.Text = from.t2;
                this.cbocIncomeType.SelectedValue = from.t1;
                this.txtcCompanyName.Text = from.CompanyName;
                this.dtpcInvoiceDate.Value = from.InvoiceDate.Value;
                this.dtpcArrivalDate.Value = from.ArrivalDate.Value;
                this.dtpcDepatureDate.Value = from.DepatureDate.Value;
                this.txtcRemark.Text = from.Remark;
                this.txtcRate.Text = from.Rate.ToString();
                this.txtcAddress.Text = from.Address;
                this.txtcTotalAmount.Text = from.TotalAmount.ToString();
                this.txtcExtraCharges.Text = from.ExtraCharges.ToString();
                this.txtcBalance.Text = from.Balance.ToString();
                this.txtcSearch.Text = "";
                this.cbocCurrency.Text = from.Currency;
                this.cbocPayment.SelectedValue = from.PaymentTerm;
            }
            List<CarRentalDetail> to = new List<CarRentalDetail>();
            to = (from x in this.entity.CarRentalDetail
                  where x.InvoiceNo == Invoice && x.IsDelete == (bool?)false
                  select x).ToList<CarRentalDetail>();
            if (to.Count > 0)
            {
                this.dgvCarRental.Rows.Clear();
                for (int date = 0; date < to.Count; date++)
                {
                    this.dgvCarRental.Rows.Add(new object[]
					{
						to[date].CarType,
						to[date].Peroid,
						to[date].Amount,
						to[date].CarType,
						0,
						to[date].ID
					});
                }
            }
        }

        // Token: 0x06000E19 RID: 3609 RVA: 0x00096B24 File Offset: 0x00094D24
        private void CalculateCarRentalAmount()
        {
            decimal newform = decimal.Parse((this.txtcAmount.Text == "") ? "0" : this.txtcAmount.Text);
            decimal num = decimal.Parse((this.txtcTotalAmount.Text == "") ? "0" : this.txtcTotalAmount.Text);
            decimal d = decimal.Parse((this.txtcExtraCharges.Text == "") ? "0" : this.txtcExtraCharges.Text);
            decimal num2 = decimal.Parse((this.txtcBalance.Text == "") ? "0" : this.txtcBalance.Text);
            this.txtcTotalAmount.Text = (newform + num).ToString();
            this.txtcBalance.Text = (num + newform + d).ToString();
        }

        // Token: 0x06000E1A RID: 3610 RVA: 0x00096C2C File Offset: 0x00094E2C
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string text = this.cboFrom.SelectedValue.ToString();
            string text2 = this.cboTo.SelectedValue.ToString();
            string text3 = this.dtpDate.Value.ToShortDateString();
            string text4 = this.dtpTime.Value.ToString("HH:mm");
            string text5 = this.dtpaDate.Value.ToShortDateString();
            string text6 = this.dtpaTime.Value.ToString("HH:mm");
            string text7 = this.cboAVehicalName.SelectedValue.ToString();
            string text8 = this.cboClass.SelectedValue.ToString();
            string text9 = this.txtFlight.Text;
            int num = int.Parse((this.txtNo.Text == "") ? "0" : this.txtNo.Text);
            this.dgvFlight.Rows.Add(new object[]
			{
				text,
				text2,
				text3,
				text4,
				text5,
				text6,
				text8,
				text7,
				text9,
				num
			});
            int num2 = int.Parse(this.txtTotalNo.Text);
            num2 += num;
            this.txtTotalNo.Text = num2.ToString();
            this.cboFrom.SelectedIndex = 0;
            this.cboTo.SelectedIndex = 0;
            this.dtpDate.Value = DateTime.Now;
            this.dtpTime.Value = DateTime.Now;
            this.dtpaDate.Value = DateTime.Now;
            this.dtpaTime.Value = DateTime.Now;
            this.cboClass.SelectedIndex = 0;
            this.txtFlight.Text = "";
            this.txtNo.Text = "0";
            this.cboFrom.Focus();
        }

        // Token: 0x06000E1B RID: 3611 RVA: 0x00096E3C File Offset: 0x0009503C
        private void btnSetup_Click(object sender, EventArgs e)
        {
            UI.frmBackOffice name = new UI.frmBackOffice();
            name.Show();
        }

        // Token: 0x06000E1C RID: 3612 RVA: 0x00096E58 File Offset: 0x00095058
        private void btnMain_Click(object sender, EventArgs e)
        {
            this.pnlCredit.Visible = false;
            this.pnlTravel.Visible = false;
            this.pnlHotelBooking.Visible = false;
            this.pnlTourPackage.Visible = false;
            this.pnlPassport.Visible = false;
            this.pnlCarRental.Visible = false;
        }

        // Token: 0x06000E1D RID: 3613 RVA: 0x00096EB4 File Offset: 0x000950B4
        private void btnPadd_Click(object sender, EventArgs e)
        {
            string text = this.txtPassenger.Text;
            string text2 = this.txtTicker.Text;
            string text3 = this.txtPassport.Text;
            string text4 = this.cboPassengerType.SelectedItem.ToString();
            decimal num = decimal.Parse((this.txtFare.Text == "") ? "0" : this.txtFare.Text);
            decimal num2 = decimal.Parse((this.txtbTax.Text == "") ? "0" : this.txtbTax.Text);
            decimal num3 = decimal.Parse((this.txtpTotalFare.Text == "") ? "0" : this.txtpTotalFare.Text);
            this.dgvPassenger.Rows.Add(new object[]
			{
				text,
				text3,
				text4,
				text2,
				num,
				num2,
				num3
			});
            this.CalculateAirTicketAmount();
            this.txtPassenger.Text = "";
            this.txtPassport.Text = "";
            this.txtTicker.Text = "";
            this.cboPassengerType.SelectedIndex = 0;
            this.txtFare.Text = "0";
            this.txtbTax.Text = "0";
            this.txtpTotalFare.Text = "0";
            this.txtPassenger.Focus();
        }

        // Token: 0x06000E1E RID: 3614 RVA: 0x00097068 File Offset: 0x00095268
        private void btnPreview_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            List<TicketBooking> list = new List<TicketBooking>();
            List<TicketFlight> list2 = new List<TicketFlight>();
            List<TicketPassenger> list3 = new List<TicketPassenger>();
            DataTable dataTable = new DataTable("TicketBooking");
            dataTable.Columns.Add(new DataColumn("Date", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
            dataTable.Columns.Add(new DataColumn("ContactPerson", typeof(string)));
            dataTable.Columns.Add(new DataColumn("CompanyName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("t2", typeof(string)));
            dataTable.Columns.Add(new DataColumn("PaymentTerm", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Currency", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Phone", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Email", typeof(string)));
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
            PaymentTerm paymentTerm = new PaymentTerm();
            paymentTerm = (from x in this.entity.PaymentTerms
                           where x.Code == payment && x.IsDelete == (bool?)false
                           select x).FirstOrDefault<PaymentTerm>();
            dataRow["PaymentTerm"] = paymentTerm.Description;
            dataRow["Currency"] = this.cboCurrency.SelectedValue.ToString();
            dataRow["Phone"] = this.txtPhone.Text;
            dataRow["t2"] = this.cboIncomeType.SelectedValue.ToString();
            dataRow["Email"] = this.txtEmail.Text;
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
            Staff staff = new Staff();
            staff = (from x in this.entity.Staffs
                     where x.Code == user && x.IsDelete == (bool?)false
                     select x).FirstOrDefault<Staff>();
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

        // Token: 0x06000E1F RID: 3615 RVA: 0x0009839C File Offset: 0x0009659C
        private void btnTravelnTour_Click(object sender, EventArgs e)
        {
            this.pnlTravel.Left = 160;
            this.pnlTravel.Width = 1210;
            this.pnlTravel.Height = 722;
            this.pnlTravel.Visible = true;
            this.pnlCredit.Visible = false;
            this.pnlHotelBooking.Visible = false;
            this.pnlTourPackage.Visible = false;
            this.pnlPassport.Visible = false;
            this.pnlCarRental.Visible = false;
            this.txtContactPerson.Focus();
            this.BindTicket();
            this.CleanTicketBooking();
            this.LoadBookingList();
        }

        // Token: 0x06000E20 RID: 3616 RVA: 0x0009844C File Offset: 0x0009664C
        private void btnPassport_Click(object sender, EventArgs e)
        {
            this.pnlPassport.Visible = true;
            this.pnlPassport.Left = 160;
            this.pnlPassport.Width = 1210;
            this.pnlPassport.Height = 722;
            this.pnlTravel.Visible = false;
            this.pnlCredit.Visible = false;
            this.pnlHotelBooking.Visible = false;
            this.pnlTourPackage.Visible = false;
            this.pnlCarRental.Visible = false;
            this.CleanPassportBooking();
            this.LoadPassportBookingList();
            this.txtPContactPerson.Focus();
        }

        // Token: 0x06000E21 RID: 3617 RVA: 0x00098530 File Offset: 0x00096730
        private void btnBooking_Click(object sender, EventArgs e)
        {
            if (this.IsValid())
            {
                try
                {
                    if (this.btnBooking.Text == "Booking")
                    {
                        TicketBooking tb = new TicketBooking();
                        tb.InvoiceNo = this.txtTBookingNo.Text;
                        tb.ContactPerson = this.txtContactPerson.Text;
                        tb.CompanyName = this.txtCompanyName.Text;
                        tb.Currency = this.cboCurrency.SelectedValue.ToString();
                        tb.Rate = new int?(int.Parse(this.txtAcurrate.Text));
                        tb.PaymentCode = this.cboPaymentTerm.SelectedValue.ToString();
                        PaymentTerm paymentTerm = new PaymentTerm();
                        paymentTerm = (from x in this.entity.PaymentTerms
                                       where x.Code == tb.PaymentCode && x.IsDelete == (bool?)false
                                       select x).FirstOrDefault<PaymentTerm>();
                        tb.PaymentDes = paymentTerm.Description;
                        tb.Date = new DateTime?(this.dtpDate.Value);
                        tb.Phone = this.txtPhone.Text;
                        tb.Email = this.txtEmail.Text;
                        tb.Address = this.txtAddress.Text;
                        tb.t2 = this.cboIncomeType.SelectedValue.ToString();
                        tb.t3 = txtsupplier.Text;
                        tb.SystemDate = new DateTime?(DateTime.Now);
                        tb.NoSeat = new int?(int.Parse((this.txtTotalNo.Text == "") ? "0" : this.txtTotalNo.Text));
                        tb.Tax = new decimal?(int.Parse((this.txtTax.Text == "") ? "0" : this.txtTax.Text));
                        tb.Total = new decimal?(decimal.Parse((this.txtTotalFare.Text == "") ? "0" : this.txtTotalFare.Text));
                        tb.Type = this.cboAType.SelectedItem.ToString();
                        if (this.chkIsTransit.Checked)
                        {
                            tb.IsTransit = new bool?(true);
                        }
                        else
                        {
                            tb.IsTransit = new bool?(false);
                        }
                        tb.MMKBalance = new decimal?(this.CalculateMMKAmount(Convert.ToInt32(tb.Rate), Convert.ToDecimal(tb.Total)));
                        tb.Status = "B";
                        tb.User = Utility.Utility.User;
                        tb.IsDelete = new bool?(false);
                        this.entity.AddToTicketBookings(tb);
                        this.entity.SaveChanges();
                        if (this.dgvFlight.Rows.Count > 0)
                        {
                            for (int i = 0; i < this.dgvFlight.Rows.Count; i++)
                            {
                                TicketFlight ticketFlight = new TicketFlight();
                                ticketFlight.InvoiceNo = this.txtTBookingNo.Text;
                                ticketFlight.SystemDate = new DateTime?(DateTime.Now);
                                ticketFlight.From = this.dgvFlight.Rows[i].Cells["colFrom"].Value.ToString();
                                ticketFlight.To = this.dgvFlight.Rows[i].Cells["colTo"].Value.ToString();
                                ticketFlight.Date = new DateTime?(DateTime.Parse(this.dgvFlight.Rows[i].Cells["coldpDate"].Value.ToString()));
                                ticketFlight.Time = new DateTime?(DateTime.Parse(this.dgvFlight.Rows[i].Cells["colTime"].Value.ToString()));
                                ticketFlight.ArrivalDate = new DateTime?(DateTime.Parse(this.dgvFlight.Rows[i].Cells["colaDate"].Value.ToString()));
                                ticketFlight.ArrivalTime = new DateTime?(DateTime.Parse(this.dgvFlight.Rows[i].Cells["colaTime"].Value.ToString()));
                                ticketFlight.Class = this.dgvFlight.Rows[i].Cells["colbClass"].Value.ToString();
                                ticketFlight.AirLine = this.dgvFlight.Rows[i].Cells["colAairline"].Value.ToString();
                                ticketFlight.Flight = this.dgvFlight.Rows[i].Cells["colFNo"].Value.ToString();
                                ticketFlight.NoSeats = new int?(int.Parse(this.dgvFlight.Rows[i].Cells["colSeat"].Value.ToString()));
                                ticketFlight.User = Utility.Utility.User;
                                ticketFlight.IsDelete = new bool?(false);
                                this.entity.AddToTicketFlights(ticketFlight);
                                this.entity.SaveChanges();
                            }
                        }
                        if (this.dgvPassenger.Rows.Count > 0)
                        {
                            for (int i = 0; i < this.dgvPassenger.Rows.Count; i++)
                            {
                                TicketPassenger ticketPassenger = new TicketPassenger();
                                ticketPassenger.InvoiceNo = this.txtTBookingNo.Text;
                                ticketPassenger.PassengerName = this.dgvPassenger.Rows[i].Cells["colpName"].Value.ToString();
                                ticketPassenger.t1 = this.dgvPassenger.Rows[i].Cells["colPassport"].Value.ToString();
                                ticketPassenger.Type = this.dgvPassenger.Rows[i].Cells["colPType"].Value.ToString();
                                ticketPassenger.TicketNo = this.dgvPassenger.Rows[i].Cells["colTicketNo"].Value.ToString();
                                ticketPassenger.Fare = new decimal?(decimal.Parse(this.dgvPassenger.Rows[i].Cells["colFare"].Value.ToString()));
                                ticketPassenger.tax = new decimal?(decimal.Parse(this.dgvPassenger.Rows[i].Cells["colTax"].Value.ToString()));
                                ticketPassenger.TotalFare = new decimal?(decimal.Parse(this.dgvPassenger.Rows[i].Cells["colTotal"].Value.ToString()));
                                ticketPassenger.User = Utility.Utility.User;
                                ticketPassenger.IsDelete = new bool?(false);
                                this.entity.AddToTicketPassengers(ticketPassenger);
                                this.entity.SaveChanges();
                            }
                        }
                        MessageBox.Show("Booking Successful!", "Successful", MessageBoxButtons.OK);
                    }
                    else if (this.btnBooking.Text == "Update")
                    {
                        string invoice = this.txtTBookingNo.Text;
                        TicketBooking ticketBooking = new TicketBooking();
                        ticketBooking = (from x in this.entity.TicketBookings
                                         where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                                         select x).FirstOrDefault<TicketBooking>();
                        ticketBooking.ContactPerson = this.txtContactPerson.Text;
                        ticketBooking.CompanyName = this.txtCompanyName.Text;
                        ticketBooking.Currency = this.cboCurrency.SelectedValue.ToString();
                        ticketBooking.Rate = new int?(int.Parse(this.txtAcurrate.Text));
                        ticketBooking.PaymentCode = this.cboPaymentTerm.SelectedValue.ToString();
                        ticketBooking.PaymentDes = this.cboPaymentTerm.SelectedValue.ToString();
                        ticketBooking.Date = new DateTime?(this.dtpbookingdate.Value);
                        ticketBooking.Phone = this.txtPhone.Text;
                        ticketBooking.Email = this.txtEmail.Text;
                        ticketBooking.Address = this.txtAddress.Text;
                        ticketBooking.t2 = this.cboIncomeType.SelectedValue.ToString();
                        ticketBooking.t3 = txtsupplier.Text;
                        ticketBooking.SystemDate = new DateTime?(DateTime.Now);
                        ticketBooking.NoSeat = new int?(int.Parse((this.txtTotalNo.Text == "") ? "0" : this.txtTotalNo.Text));
                        ticketBooking.Tax = new decimal?(int.Parse((this.txtTax.Text == "") ? "0" : this.txtTax.Text));
                        ticketBooking.Total = new decimal?(decimal.Parse((this.txtTotalFare.Text == "") ? "0" : this.txtTotalFare.Text));
                        ticketBooking.Type = this.cboAType.SelectedItem.ToString();
                        if (this.chkIsTransit.Checked)
                        {
                            ticketBooking.IsTransit = new bool?(true);
                        }
                        else
                        {
                            ticketBooking.IsTransit = new bool?(false);
                        }
                        ticketBooking.MMKBalance = new decimal?(this.CalculateMMKAmount(Convert.ToInt32(ticketBooking.Rate), Convert.ToDecimal(ticketBooking.Total)));
                        ticketBooking.Status = "U";
                        ticketBooking.User = Utility.Utility.User;
                        ticketBooking.IsDelete = new bool?(false);
                        this.entity.SaveChanges();
                        if (this.dgvFlight.Rows.Count > 0)
                        {
                            if (this.tfDeleteID.Count > 0)
                            {
                                for (int i = 0; i < this.tfDeleteID.Count; i++)
                                {
                                    TicketFlight ticketFlight = new TicketFlight();
                                    int Id = int.Parse(this.tfDeleteID[i].ToString());
                                    ticketFlight = (from x in this.entity.TicketFlights
                                                    where x.ID == Id && x.IsDelete == (bool?)false
                                                    select x).FirstOrDefault<TicketFlight>();
                                    ticketFlight.IsDelete = new bool?(true);
                                    this.entity.SaveChanges();
                                }
                            }
                            for (int i = 0; i < this.dgvFlight.Rows.Count; i++)
                            {
                                if (this.dgvFlight.Rows[i].Cells["colID"].Value == null)
                                {
                                    TicketFlight ticketFlight = new TicketFlight();
                                    ticketFlight.InvoiceNo = this.txtTBookingNo.Text;
                                    ticketFlight.SystemDate = new DateTime?(DateTime.Now);
                                    ticketFlight.From = this.dgvFlight.Rows[i].Cells["colFrom"].Value.ToString();
                                    ticketFlight.To = this.dgvFlight.Rows[i].Cells["colTo"].Value.ToString();
                                    ticketFlight.Date = new DateTime?(DateTime.Parse(this.dgvFlight.Rows[i].Cells["coldpDate"].Value.ToString()));
                                    ticketFlight.Time = new DateTime?(DateTime.Parse(this.dgvFlight.Rows[i].Cells["colTime"].Value.ToString()));
                                    ticketFlight.ArrivalDate = new DateTime?(DateTime.Parse(this.dgvFlight.Rows[i].Cells["colaDate"].Value.ToString()));
                                    ticketFlight.ArrivalTime = new DateTime?(DateTime.Parse(this.dgvFlight.Rows[i].Cells["colaTime"].Value.ToString()));
                                    ticketFlight.Class = this.dgvFlight.Rows[i].Cells["colbClass"].Value.ToString();
                                    ticketFlight.AirLine = this.dgvFlight.Rows[i].Cells["colAairline"].Value.ToString();
                                    ticketFlight.Flight = this.dgvFlight.Rows[i].Cells["colFNo"].Value.ToString();
                                    ticketFlight.NoSeats = new int?(int.Parse(this.dgvFlight.Rows[i].Cells["colSeat"].Value.ToString()));
                                    ticketFlight.User = Utility.Utility.User;
                                    ticketFlight.IsDelete = new bool?(false);
                                    this.entity.AddToTicketFlights(ticketFlight);
                                    this.entity.SaveChanges();
                                }
                                else
                                {
                                    TicketFlight ticketFlight = new TicketFlight();
                                    int Id = int.Parse(this.dgvFlight.Rows[i].Cells["colID"].Value.ToString());
                                    ticketFlight = (from x in this.entity.TicketFlights
                                                    where x.ID == Id && x.IsDelete == (bool?)false
                                                    select x).FirstOrDefault<TicketFlight>();
                                    ticketFlight.InvoiceNo = this.txtTBookingNo.Text;
                                    ticketFlight.SystemDate = new DateTime?(DateTime.Now);
                                    ticketFlight.From = this.dgvFlight.Rows[i].Cells["colFrom"].Value.ToString();
                                    ticketFlight.To = this.dgvFlight.Rows[i].Cells["colTo"].Value.ToString();
                                    ticketFlight.Date = new DateTime?(DateTime.Parse(this.dgvFlight.Rows[i].Cells["coldpDate"].Value.ToString()));
                                    ticketFlight.Time = new DateTime?(DateTime.Parse(this.dgvFlight.Rows[i].Cells["colTime"].Value.ToString()));
                                    ticketFlight.Class = this.dgvFlight.Rows[i].Cells["colbClass"].Value.ToString();
                                    ticketFlight.AirLine = this.dgvFlight.Rows[i].Cells["colAairline"].Value.ToString();
                                    ticketFlight.Flight = this.dgvFlight.Rows[i].Cells["colFNo"].Value.ToString();
                                    ticketFlight.NoSeats = new int?(int.Parse(this.dgvFlight.Rows[i].Cells["colSeat"].Value.ToString()));
                                    ticketFlight.User = Utility.Utility.User;
                                    ticketFlight.IsDelete = new bool?(false);
                                    this.entity.SaveChanges();
                                }
                            }
                        }
                        if (this.dgvPassenger.Rows.Count > 0)
                        {
                            if (this.tpDeleteID.Count > 0)
                            {
                                for (int i = 0; i < this.tpDeleteID.Count; i++)
                                {
                                    TicketPassenger ticketPassenger = new TicketPassenger();
                                    int Id = int.Parse(this.tpDeleteID[i].ToString());
                                    ticketPassenger = (from x in this.entity.TicketPassengers
                                                       where x.ID == Id && x.IsDelete == (bool?)false
                                                       select x).FirstOrDefault<TicketPassenger>();
                                    ticketPassenger.IsDelete = new bool?(true);
                                    this.entity.SaveChanges();
                                }
                            }
                            for (int i = 0; i < this.dgvPassenger.Rows.Count; i++)
                            {
                                if (this.dgvPassenger.Rows[i].Cells["colpID"].Value == null)
                                {
                                    TicketPassenger ticketPassenger = new TicketPassenger();
                                    ticketPassenger.InvoiceNo = this.txtTBookingNo.Text;
                                    ticketPassenger.PassengerName = this.dgvPassenger.Rows[i].Cells["colpName"].Value.ToString();
                                    ticketPassenger.t1 = this.dgvPassenger.Rows[i].Cells["colPassport"].Value.ToString();
                                    ticketPassenger.Type = this.dgvPassenger.Rows[i].Cells["colPType"].Value.ToString();
                                    ticketPassenger.TicketNo = this.dgvPassenger.Rows[i].Cells["colTicketNo"].Value.ToString();
                                    ticketPassenger.Fare = new decimal?(decimal.Parse(this.dgvPassenger.Rows[i].Cells["colFare"].Value.ToString()));
                                    ticketPassenger.tax = new decimal?(int.Parse(this.dgvPassenger.Rows[i].Cells["colTax"].Value.ToString()));
                                    ticketPassenger.TotalFare = new decimal?(decimal.Parse(this.dgvPassenger.Rows[i].Cells["colTotal"].Value.ToString()));
                                    ticketPassenger.User = Utility.Utility.User;
                                    ticketPassenger.IsDelete = new bool?(false);
                                    this.entity.AddToTicketPassengers(ticketPassenger);
                                    this.entity.SaveChanges();
                                }
                                else
                                {
                                    TicketPassenger ticketPassenger = new TicketPassenger();
                                    int Id = int.Parse(this.dgvPassenger.Rows[i].Cells["colpID"].Value.ToString());
                                    ticketPassenger = (from x in this.entity.TicketPassengers
                                                       where x.ID == Id && x.IsDelete == (bool?)false
                                                       select x).FirstOrDefault<TicketPassenger>();
                                    ticketPassenger.InvoiceNo = this.txtTBookingNo.Text;
                                    ticketPassenger.PassengerName = this.dgvPassenger.Rows[i].Cells["colpName"].Value.ToString();
                                    ticketPassenger.t1 = this.dgvPassenger.Rows[i].Cells["colPassport"].Value.ToString();
                                    ticketPassenger.Type = this.dgvPassenger.Rows[i].Cells["colPType"].Value.ToString();
                                    ticketPassenger.TicketNo = this.dgvPassenger.Rows[i].Cells["colTicketNo"].Value.ToString();
                                    ticketPassenger.Fare = new decimal?(decimal.Parse(this.dgvPassenger.Rows[i].Cells["colFare"].Value.ToString()));
                                    ticketPassenger.tax = new decimal?(int.Parse(this.dgvPassenger.Rows[i].Cells["colTax"].Value.ToString()));
                                    ticketPassenger.TotalFare = new decimal?(decimal.Parse(this.dgvPassenger.Rows[i].Cells["colTotal"].Value.ToString()));
                                    ticketPassenger.User = Utility.Utility.User;
                                    ticketPassenger.IsDelete = new bool?(false);
                                    this.entity.SaveChanges();
                                }
                            }
                        }
                        MessageBox.Show("Booking Successful!", "Successful", MessageBoxButtons.OK);
                    }
                    else if (this.btnBooking.Text == "Issue")
                    {
                        string invoice = this.txtTBookingNo.Text;
                        TicketBooking ticketBooking = new TicketBooking();
                        ticketBooking = (from x in this.entity.TicketBookings
                                         where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                                         select x).FirstOrDefault<TicketBooking>();
                        ticketBooking.ContactPerson = this.txtContactPerson.Text;
                        ticketBooking.CompanyName = this.txtCompanyName.Text;
                        ticketBooking.Currency = this.cboCurrency.SelectedValue.ToString();
                        ticketBooking.Rate = new int?(int.Parse(this.txtAcurrate.Text));
                        ticketBooking.PaymentCode = this.cboPaymentTerm.SelectedValue.ToString();
                        ticketBooking.PaymentDes = this.cboPaymentTerm.SelectedValue.ToString();
                        ticketBooking.Date = new DateTime?(this.dtpbookingdate.Value);
                        ticketBooking.Phone = this.txtPhone.Text;
                        ticketBooking.Email = this.txtEmail.Text;
                        ticketBooking.Address = this.txtAddress.Text;
                        ticketBooking.SystemDate = new DateTime?(DateTime.Now);
                        ticketBooking.NoSeat = new int?(int.Parse((this.txtTotalNo.Text == "") ? "0" : this.txtTotalNo.Text));
                        ticketBooking.Tax = new decimal?(int.Parse((this.txtTax.Text == "") ? "0" : this.txtTax.Text));
                        ticketBooking.Total = new decimal?(decimal.Parse((this.txtTotalFare.Text == "") ? "0" : this.txtTotalFare.Text));
                        ticketBooking.Type = this.cboAType.SelectedItem.ToString();
                        if (this.chkIsTransit.Checked)
                        {
                            ticketBooking.IsTransit = new bool?(true);
                        }
                        else
                        {
                            ticketBooking.IsTransit = new bool?(false);
                        }
                        ticketBooking.MMKBalance = new decimal?(this.CalculateMMKAmount(Convert.ToInt32(ticketBooking.Rate), Convert.ToDecimal(ticketBooking.Total)));
                        ticketBooking.Status = "I";
                        ticketBooking.User = Utility.Utility.User;
                        ticketBooking.IsDelete = new bool?(false);
                        this.entity.SaveChanges();
                        MessageBox.Show("Issue Successful!", "Successful", MessageBoxButtons.OK);
                        this.btnPreview_Click(sender, e);
                    }
                    this.CleanTicketBooking();
                    this.LoadBookingList();
                    this.tfDeleteID = new List<int>();
                    this.tpDeleteID = new List<int>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please fill information!", "Incomplete Information");
            }
        }

        // Token: 0x06000E22 RID: 3618 RVA: 0x0009A310 File Offset: 0x00098510
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.CleanTicketBooking();
        }

        // Token: 0x06000E23 RID: 3619 RVA: 0x0009A31C File Offset: 0x0009851C
        private void btnHotelReserve_Click(object sender, EventArgs e)
        {
            this.pnlHotelBooking.Left = 160;
            this.pnlHotelBooking.Width = 1210;
            this.pnlHotelBooking.Height = 722;
            this.pnlHotelBooking.Visible = true;
            this.pnlTourPackage.Visible = false;
            this.pnlCredit.Visible = false;
            this.pnlTravel.Visible = false;
            this.pnlPassport.Visible = false;
            this.pnlCarRental.Visible = false;
            this.CleanHotelBooking();
            this.LoadHotelBookingList();
            this.txthContactPerson.Focus();
        }

        // Token: 0x06000E24 RID: 3620 RVA: 0x0009A3D0 File Offset: 0x000985D0
        private void btnhAdd_Click(object sender, EventArgs e)
        {
            string room = "";
            RoomType DS = new RoomType();
            if (this.cboRoomType.SelectedValue != null)
            {
                room = this.cboRoomType.SelectedValue.ToString();
                DS = (from x in this.entity.RoomTypes
                      where x.Code == room && x.IsDelete == (bool?)false
                      select x).FirstOrDefault<RoomType>();
            }
            else
            {
                DS.Description = this.cboRoomType.Text;
            }
            decimal tb = decimal.Parse((this.txthRate.Text == "") ? "0" : this.txthRate.Text);
            int tf = int.Parse((this.txtRoomNo.Text == "") ? "0" : this.txtRoomNo.Text);
            decimal table = decimal.Parse((this.txthAmount.Text == "") ? "0" : this.txthAmount.Text);
            this.dgvRoom.Rows.Add(new object[]
			{
				DS.Description,
				tb,
				tf,
				table,
				0,
				null,
				room
			});
            this.CalculateHotelAmount();
            this.cboRoomType.SelectedIndex = 0;
            this.txthRate.Text = "0";
            this.txtRoomNo.Text = "0";
            this.txthAmount.Text = "0";
            this.cboRoomType.Focus();
        }

        // Token: 0x06000E25 RID: 3621 RVA: 0x0009A674 File Offset: 0x00098874
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.HotelIsValid())
            {
                try
                {
                    if (this.btnHotelBooking.Text == "Booking")
                    {
                        HotelBooking hotelBooking = new HotelBooking();
                        hotelBooking.InvoiceNo = this.txthInvoiceNo.Text;
                        hotelBooking.SystemDate = new DateTime?(DateTime.Now);
                        hotelBooking.ContactPerson = this.txthContactPerson.Text;
                        hotelBooking.CompanyName = this.txthCompanyName.Text;
                        hotelBooking.ContactPhone = this.txthContactPhone.Text;
                        hotelBooking.Currency = this.cbohCurrency.SelectedValue.ToString();
                        hotelBooking.Rate = new decimal?(int.Parse(this.txthCurRate.Text));
                        hotelBooking.PaymentTerm = this.cbohPaymentTerm.SelectedValue.ToString();
                        hotelBooking.t1 = this.cbohIncomeType.SelectedValue.ToString();
                        hotelBooking.t2 = this.txthSupplier.Text;
                        hotelBooking.Address = this.txthAddress.Text;
                        hotelBooking.Email = this.txthEmail.Text;
                        hotelBooking.InvoiceDate = new DateTime?(DateTime.Parse(this.dtphHotelBooking.Value.ToShortDateString()));
                        hotelBooking.DepatureDate = new DateTime?(DateTime.Parse(this.dtpDepatureDate.Value.ToShortDateString()));
                        hotelBooking.ArrivalDate = new DateTime?(DateTime.Parse(this.dtpArrivalDate.Value.ToShortDateString()));
                        hotelBooking.NoofPax = new int?(int.Parse((this.txtPaxNo.Text == "") ? "0" : this.txtPaxNo.Text));
                        hotelBooking.NoofNight = new int?(int.Parse((this.txtNightNo.Text == "") ? "0" : this.txtNightNo.Text));
                        hotelBooking.Discount = new decimal?(this.hDiscount);
                        hotelBooking.DiscountPercent = new decimal?(int.Parse((this.txtDiscount.Text == "") ? "0" : this.txtDiscount.Text));
                        hotelBooking.TotalRoom = new decimal?(int.Parse((this.txtTotalRoom.Text == "") ? "0" : this.txtTotalRoom.Text));
                        hotelBooking.TotalAmount = new decimal?(decimal.Parse((this.txtTotalhAmount.Text == "") ? "0" : this.txtTotalhAmount.Text));
                        hotelBooking.Balance = new decimal?(decimal.Parse((this.txtBalance.Text == "") ? "0" : this.txtBalance.Text));
                        hotelBooking.Remark = this.txthRemark.Text;
                        hotelBooking.Hotel = this.cbohHotel.Text;
                        hotelBooking.MMKBalance = new decimal?(this.CalculateMMKAmount(Convert.ToInt32(hotelBooking.Rate), Convert.ToDecimal(hotelBooking.Balance)));
                        hotelBooking.Status = "B";
                        hotelBooking.User = Utility.Utility.User;
                        hotelBooking.IsDelete = new bool?(false);
                        this.entity.AddToHotelBookings(hotelBooking);
                        this.entity.SaveChanges();
                        if (this.dgvRoom.Rows.Count > 0)
                        {
                            for (int i = 0; i < this.dgvRoom.Rows.Count; i++)
                            {
                                HotelRoom hotelRoom = new HotelRoom();
                                hotelRoom.InvoiceNo = this.txthInvoiceNo.Text;
                                hotelRoom.SystemDate = new DateTime?(DateTime.Now);
                                hotelRoom.RoomType = this.dgvRoom.Rows[i].Cells["colRType"].Value.ToString();
                                hotelRoom.Rate = new decimal?(decimal.Parse(this.dgvRoom.Rows[i].Cells["colRate"].Value.ToString()));
                                hotelRoom.NoofRoom = new int?(int.Parse(this.dgvRoom.Rows[i].Cells["colNofN"].Value.ToString()));
                                hotelRoom.Amount = new decimal?(decimal.Parse(this.dgvRoom.Rows[i].Cells["colhAmount"].Value.ToString()));
                                hotelRoom.RoomCode = this.dgvRoom.Rows[i].Cells["colRCode"].Value.ToString();
                                hotelRoom.User = Utility.Utility.User;
                                hotelRoom.IsDelete = new bool?(false);
                                this.entity.AddToHotelRooms(hotelRoom);
                                this.entity.SaveChanges();
                            }
                        }
                        ServicesOrRequirement servicesOrRequirement = new ServicesOrRequirement();
                        Services services2 = new Services();
                        foreach (object obj in this.chkhOtherServices.CheckedItems)
                        {
                            string text = (string)obj;
                            string services = text.ToString();
                            services2 = (from x in this.entity.Services
                                         where x.Description == services && x.Transaction == "Hotel" && x.IsDelete == (bool?)false
                                         select x).FirstOrDefault<Services>();
                            servicesOrRequirement = new ServicesOrRequirement();
                            servicesOrRequirement.CreatedDate = new DateTime?(DateTime.Now);
                            servicesOrRequirement.Code = services2.Code;
                            servicesOrRequirement.Description = services2.Description;
                            servicesOrRequirement.InvoiceNo = this.txthInvoiceNo.Text;
                            servicesOrRequirement.Transaction = "Hotel";
                            servicesOrRequirement.User = Utility.Utility.User;
                            this.entity.AddToServicesOrRequirement(servicesOrRequirement);
                            this.entity.SaveChanges();
                        }
                        MessageBox.Show("Booking Successful!", "Successful", MessageBoxButtons.OK);
                    }
                    else if (this.btnHotelBooking.Text == "Update")
                    {
                        string invoice = this.txthInvoiceNo.Text;
                        HotelBooking hotelBooking = new HotelBooking();
                        hotelBooking = (from x in this.entity.HotelBookings
                                        where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                                        select x).FirstOrDefault<HotelBooking>();
                        hotelBooking.InvoiceNo = this.txthInvoiceNo.Text;
                        hotelBooking.SystemDate = new DateTime?(DateTime.Now);
                        hotelBooking.ContactPerson = this.txthContactPerson.Text;
                        hotelBooking.CompanyName = this.txthCompanyName.Text;
                        hotelBooking.ContactPhone = this.txthContactPhone.Text;
                        hotelBooking.Currency = this.cbohCurrency.SelectedValue.ToString();
                        hotelBooking.Rate = new decimal?(int.Parse(this.txthCurRate.Text));
                        hotelBooking.PaymentTerm = this.cbohPaymentTerm.SelectedValue.ToString();
                        hotelBooking.t1 = this.cbohIncomeType.SelectedValue.ToString();
                        hotelBooking.t2 = this.txthSupplier.Text;
                        hotelBooking.Address = this.txthAddress.Text;
                        hotelBooking.Email = this.txthEmail.Text;
                        hotelBooking.InvoiceDate = new DateTime?(DateTime.Parse(this.dtphHotelBooking.Value.ToShortDateString()));
                        hotelBooking.DepatureDate = new DateTime?(DateTime.Parse(this.dtpDepatureDate.Value.ToShortDateString()));
                        hotelBooking.ArrivalDate = new DateTime?(DateTime.Parse(this.dtpArrivalDate.Value.ToShortDateString()));
                        hotelBooking.NoofPax = new int?(int.Parse((this.txtPaxNo.Text == "") ? "0" : this.txtPaxNo.Text));
                        hotelBooking.NoofNight = new int?(int.Parse((this.txtNightNo.Text == "") ? "0" : this.txtNightNo.Text));
                        hotelBooking.Discount = new decimal?(this.hDiscount);
                        hotelBooking.DiscountPercent = new decimal?(int.Parse((this.txtDiscount.Text == "") ? "0" : this.txtDiscount.Text));
                        hotelBooking.TotalRoom = new decimal?(int.Parse((this.txtTotalRoom.Text == "") ? "0" : this.txtTotalRoom.Text));
                        hotelBooking.TotalAmount = new decimal?(decimal.Parse((this.txtTotalhAmount.Text == "") ? "0" : this.txtTotalhAmount.Text));
                        hotelBooking.Balance = new decimal?(decimal.Parse((this.txtBalance.Text == "") ? "0" : this.txtBalance.Text));
                        hotelBooking.Remark = this.txthRemark.Text;
                        hotelBooking.Hotel = this.cbohHotel.Text;
                        hotelBooking.MMKBalance = new decimal?(this.CalculateMMKAmount(Convert.ToInt32(hotelBooking.Rate), Convert.ToDecimal(hotelBooking.Balance)));
                        hotelBooking.Status = "U";
                        hotelBooking.User = Utility.Utility.User;
                        hotelBooking.IsDelete = new bool?(false);
                        this.entity.SaveChanges();
                        if (this.dgvRoom.Rows.Count > 0)
                        {
                            if (this.hrDeleteID.Count > 0)
                            {
                                for (int i = 0; i < this.hrDeleteID.Count; i++)
                                {
                                    HotelRoom hotelRoom2 = new HotelRoom();
                                    int Id = int.Parse(this.hrDeleteID[i].ToString());
                                    hotelRoom2 = (from x in this.entity.HotelRooms
                                                  where x.ID == Id && x.IsDelete == (bool?)false
                                                  select x).FirstOrDefault<HotelRoom>();
                                    hotelRoom2.IsDelete = new bool?(true);
                                    this.entity.SaveChanges();
                                }
                            }
                            for (int i = 0; i < this.dgvRoom.Rows.Count; i++)
                            {
                                if (this.dgvRoom.Rows[i].Cells["colhrID"].Value == null)
                                {
                                    HotelRoom hotelRoom = new HotelRoom();
                                    hotelRoom.InvoiceNo = this.txthInvoiceNo.Text;
                                    hotelRoom.SystemDate = new DateTime?(DateTime.Now);
                                    hotelRoom.RoomType = this.dgvRoom.Rows[i].Cells["colRType"].Value.ToString();
                                    hotelRoom.Rate = new decimal?(decimal.Parse(this.dgvRoom.Rows[i].Cells["colRate"].Value.ToString()));
                                    hotelRoom.NoofRoom = new int?(int.Parse(this.dgvRoom.Rows[i].Cells["colNofN"].Value.ToString()));
                                    hotelRoom.Amount = new decimal?(decimal.Parse(this.dgvRoom.Rows[i].Cells["colhAmount"].Value.ToString()));
                                    hotelRoom.RoomCode = this.dgvRoom.Rows[i].Cells["colRCode"].Value.ToString();
                                    hotelRoom.User = Utility.Utility.User;
                                    hotelRoom.IsDelete = new bool?(false);
                                    this.entity.AddToHotelRooms(hotelRoom);
                                    this.entity.SaveChanges();
                                }
                                else
                                {
                                    HotelRoom hotelRoom = new HotelRoom();
                                    int Id = int.Parse(this.dgvRoom.Rows[i].Cells["colhrID"].Value.ToString());
                                    hotelRoom = (from x in this.entity.HotelRooms
                                                 where x.ID == Id && x.IsDelete == (bool?)false
                                                 select x).FirstOrDefault<HotelRoom>();
                                    hotelRoom.InvoiceNo = this.txthInvoiceNo.Text;
                                    hotelRoom.SystemDate = new DateTime?(DateTime.Now);
                                    hotelRoom.RoomType = this.dgvRoom.Rows[i].Cells["colRType"].Value.ToString();
                                    hotelRoom.Rate = new decimal?(decimal.Parse(this.dgvRoom.Rows[i].Cells["colRate"].Value.ToString()));
                                    hotelRoom.NoofRoom = new int?(int.Parse(this.dgvRoom.Rows[i].Cells["colNofN"].Value.ToString()));
                                    hotelRoom.Amount = new decimal?(decimal.Parse(this.dgvRoom.Rows[i].Cells["colhAmount"].Value.ToString()));
                                    hotelRoom.RoomCode = this.dgvRoom.Rows[i].Cells["colRCode"].Value.ToString();
                                    hotelRoom.User = Utility.Utility.User;
                                    hotelRoom.IsDelete = new bool?(false);
                                    this.entity.SaveChanges();
                                }
                            }
                        }
                        List<ServicesOrRequirement> list = new List<ServicesOrRequirement>();
                        ServicesOrRequirement servicesOrRequirement = new ServicesOrRequirement();
                        Services services2 = new Services();
                        list = (from x in this.entity.ServicesOrRequirement
                                where x.InvoiceNo == this.txthInvoiceNo.Text && x.Transaction == "Hotel"
                                select x).ToList<ServicesOrRequirement>();
                        for (int i = 0; i < list.Count; i++)
                        {
                            int id = list[i].ID;
                            servicesOrRequirement = new ServicesOrRequirement();
                            servicesOrRequirement = (from x in this.entity.ServicesOrRequirement
                                                     where x.ID == id
                                                     select x).FirstOrDefault<ServicesOrRequirement>();
                            this.entity.ServicesOrRequirement.DeleteObject(servicesOrRequirement);
                            this.entity.SaveChanges();
                        }
                        foreach (object obj2 in this.chkhOtherServices.CheckedItems)
                        {
                            string text = (string)obj2;
                            string services = text.ToString();
                            services2 = (from x in this.entity.Services
                                         where x.Description == services && x.Transaction == "Hotel" && x.IsDelete == (bool?)false
                                         select x).FirstOrDefault<Services>();
                            servicesOrRequirement = new ServicesOrRequirement();
                            servicesOrRequirement.CreatedDate = new DateTime?(DateTime.Now);
                            servicesOrRequirement.Code = services2.Code;
                            servicesOrRequirement.Description = services2.Description;
                            servicesOrRequirement.InvoiceNo = this.txthInvoiceNo.Text;
                            servicesOrRequirement.Transaction = "Hotel";
                            servicesOrRequirement.User = Utility.Utility.User;
                            this.entity.AddToServicesOrRequirement(servicesOrRequirement);
                            this.entity.SaveChanges();
                        }
                        MessageBox.Show("Update Successful!", "Successful", MessageBoxButtons.OK);
                    }
                    else if (this.btnHotelBooking.Text == "Confirm")
                    {
                        string invoice = this.txthInvoiceNo.Text;
                        HotelBooking hotelBooking = new HotelBooking();
                        hotelBooking = (from x in this.entity.HotelBookings
                                        where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                                        select x).FirstOrDefault<HotelBooking>();
                        hotelBooking.InvoiceNo = this.txthInvoiceNo.Text;
                        hotelBooking.SystemDate = new DateTime?(DateTime.Now);
                        hotelBooking.ContactPerson = this.txthContactPerson.Text;
                        hotelBooking.CompanyName = this.txthCompanyName.Text;
                        hotelBooking.ContactPhone = this.txthContactPhone.Text;
                        hotelBooking.Currency = this.cbohCurrency.SelectedValue.ToString();
                        hotelBooking.Rate = new decimal?(int.Parse(this.txthCurRate.Text));
                        hotelBooking.PaymentTerm = this.cbohPaymentTerm.SelectedValue.ToString();
                        hotelBooking.Address = this.txthAddress.Text;
                        hotelBooking.Email = this.txthEmail.Text;
                        hotelBooking.InvoiceDate = new DateTime?(DateTime.Parse(this.dtphHotelBooking.Value.ToShortDateString()));
                        hotelBooking.DepatureDate = new DateTime?(DateTime.Parse(this.dtpDepatureDate.Value.ToShortDateString()));
                        hotelBooking.ArrivalDate = new DateTime?(DateTime.Parse(this.dtpArrivalDate.Value.ToShortDateString()));
                        hotelBooking.NoofPax = new int?(int.Parse((this.txtPaxNo.Text == "") ? "0" : this.txtPaxNo.Text));
                        hotelBooking.NoofNight = new int?(int.Parse((this.txtNightNo.Text == "") ? "0" : this.txtNightNo.Text));
                        hotelBooking.Discount = new decimal?(this.hDiscount);
                        hotelBooking.DiscountPercent = new decimal?(int.Parse((this.txtDiscount.Text == "") ? "0" : this.txtDiscount.Text));
                        hotelBooking.TotalRoom = new decimal?(int.Parse((this.txtTotalRoom.Text == "") ? "0" : this.txtTotalRoom.Text));
                        hotelBooking.TotalAmount = new decimal?(decimal.Parse((this.txtTotalhAmount.Text == "") ? "0" : this.txtTotalhAmount.Text));
                        hotelBooking.Balance = new decimal?(decimal.Parse((this.txtBalance.Text == "") ? "0" : this.txtBalance.Text));
                        hotelBooking.Remark = this.txthRemark.Text;
                        hotelBooking.Hotel = this.cbohHotel.Text;
                        hotelBooking.MMKBalance = new decimal?(this.CalculateMMKAmount(Convert.ToInt32(hotelBooking.Rate), Convert.ToDecimal(hotelBooking.Balance)));
                        hotelBooking.Status = "I";
                        hotelBooking.User = Utility.Utility.User;
                        hotelBooking.IsDelete = new bool?(false);
                        this.entity.SaveChanges();
                        MessageBox.Show("Confirm Successful!", "Successful", MessageBoxButtons.OK);
                        this.btnhPreview_Click(sender, e);
                    }
                    this.hrDeleteID = new List<int>();
                    this.CleanHotelBooking();
                    this.LoadHotelBookingList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please fill information!", "Incomplete Information");
            }
        }

        // Token: 0x06000E26 RID: 3622 RVA: 0x0009C07C File Offset: 0x0009A27C
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
            dataTable.Columns.Add(new DataColumn("t1", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
            dataTable.Columns.Add(new DataColumn("ContactPhone", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Hotel", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Email", typeof(string)));
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

        // Token: 0x06000E27 RID: 3623 RVA: 0x0009CA66 File Offset: 0x0009AC66
        private void btnhCancel_Click(object sender, EventArgs e)
        {
            this.CleanHotelBooking();
        }

        // Token: 0x06000E28 RID: 3624 RVA: 0x0009CA70 File Offset: 0x0009AC70
        private void pBoxHome_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x06000E29 RID: 3625 RVA: 0x0009CA74 File Offset: 0x0009AC74
        private void btnTourPackage_Click(object sender, EventArgs e)
        {
            this.pnlTourPackage.Visible = true;
            this.pnlTourPackage.Left = 160;
            this.pnlTourPackage.Width = 1210;
            this.pnlTourPackage.Height = 722;
            this.pnlTravel.Visible = false;
            this.pnlCredit.Visible = false;
            this.pnlHotelBooking.Visible = false;
            this.pnlPassport.Visible = false;
            this.pnlCarRental.Visible = false;
            this.CleanTourPackageBooking();
            this.LoadTourPackageBookingList();
            this.txthContactPerson.Focus();
        }

        // Token: 0x06000E2A RID: 3626 RVA: 0x0009CB28 File Offset: 0x0009AD28
        private void dgvBookingList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    this.CleanTicketBooking();
                    string inv = this.dgvBookingList.CurrentRow.Cells["colInvoice"].Value.ToString();
                    this.BindBooking(inv);
                    this.btnBooking.Text = "Update";
                }
                if (e.ColumnIndex == 6)
                {
                    this.CleanTicketBooking();
                    string inv = this.dgvBookingList.CurrentRow.Cells["colInvoice"].Value.ToString();
                    this.BindBooking(inv);
                    this.btnBooking.Text = "Issue";
                    this.btnBooking.Focus();
                }
                if (e.ColumnIndex == 7)
                {
                    string invoice = this.dgvBookingList.CurrentRow.Cells["colInvoice"].Value.ToString();
                    if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        TicketBooking total = new TicketBooking();
                        total = (from x in this.entity.TicketBookings
                                 where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                                 select x).FirstOrDefault<TicketBooking>();
                        if (total != null)
                        {
                            total.IsDelete = new bool?(true);
                            this.entity.SaveChanges();
                        }
                        List<TicketFlight> ex = new List<TicketFlight>();
                        ex = (from x in this.entity.TicketFlights
                              where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                              select x).ToList<TicketFlight>();
                        if (ex.Count > 0)
                        {
                            for (int i = 0; i < ex.Count; i++)
                            {
                                ex[i].IsDelete = new bool?(true);
                                this.entity.SaveChanges();
                            }
                        }
                        List<TicketPassenger> list = new List<TicketPassenger>();
                        list = (from x in this.entity.TicketPassengers
                                where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                                select x).ToList<TicketPassenger>();
                        if (list.Count > 0)
                        {
                            for (int i = 0; i < list.Count; i++)
                            {
                                list[i].IsDelete = new bool?(true);
                                this.entity.SaveChanges();
                            }
                        }
                        this.LoadBookingList();
                    }
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.ToString());
            }
        }

        // Token: 0x06000E2B RID: 3627 RVA: 0x0009CFC4 File Offset: 0x0009B1C4
        private void dgvFlight_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                if (this.dgvFlight.CurrentRow.Cells["colID"].Value != null)
                {
                    this.tfDeleteID.Add(int.Parse(this.dgvFlight.CurrentRow.Cells["colID"].Value.ToString()));
                }
                int i = int.Parse(this.dgvFlight.CurrentRow.Cells["colSeat"].Value.ToString());
                this.dgvFlight.Rows.Remove(this.dgvFlight.CurrentRow);
                int r = int.Parse(this.txtTotalNo.Text);
                this.txtTotalNo.Text = (r - i).ToString();
            }
        }

        // Token: 0x06000E2C RID: 3628 RVA: 0x0009D0B4 File Offset: 0x0009B2B4
        private void dgvPassenger_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7)
                {
                    if (this.dgvPassenger.CurrentRow.Cells["colpID"].Value != null)
                    {
                        this.tpDeleteID.Add(int.Parse(this.dgvPassenger.CurrentRow.Cells["colpID"].Value.ToString()));
                    }
                    decimal invoice = int.Parse(this.dgvPassenger.CurrentRow.Cells["colTax"].Value.ToString());
                    decimal tb = decimal.Parse(this.dgvPassenger.CurrentRow.Cells["colTotal"].Value.ToString());
                    this.ReCalculateAirTicketAmount(invoice, tb);
                    this.dgvPassenger.Rows.Remove(this.dgvPassenger.CurrentRow);
                }
            }
            catch (Exception tf)
            {
                MessageBox.Show(tf.ToString());
            }
        }

        // Token: 0x06000E2D RID: 3629 RVA: 0x0009D1D8 File Offset: 0x0009B3D8
        private void dgvRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (this.dgvRoom.CurrentRow.Cells["colhrID"].Value != null)
                {
                    this.hrDeleteID.Add(int.Parse(this.dgvRoom.CurrentRow.Cells["colhrID"].Value.ToString()));
                }
                int no = int.Parse(this.dgvRoom.CurrentRow.Cells["colNofN"].Value.ToString());
                decimal rate = int.Parse(this.dgvRoom.CurrentRow.Cells["colRate"].Value.ToString());
                decimal amount = int.Parse(this.dgvRoom.CurrentRow.Cells["colhAmount"].Value.ToString());
                this.ReCalculateHotelAmount(no, rate, amount);
                this.dgvRoom.Rows.Remove(this.dgvRoom.CurrentRow);
            }
        }

        // Token: 0x06000E2E RID: 3630 RVA: 0x0009D310 File Offset: 0x0009B510
        private void dgvHotelBooking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    this.CleanHotelBooking();
                    string invoice2 = this.dgvHotelBooking.CurrentRow.Cells["colhInvoice"].Value.ToString();
                    this.BindHotelBooking(invoice2);
                    this.btnHotelBooking.Text = "Update";
                }
                if (e.ColumnIndex == 6)
                {
                    this.CleanHotelBooking();
                    string invoice2 = this.dgvHotelBooking.CurrentRow.Cells["colhInvoice"].Value.ToString();
                    this.BindHotelBooking(invoice2);
                    this.btnHotelBooking.Text = "Confirm";
                    this.btnHotelBooking.Focus();
                }
                if (e.ColumnIndex == 7)
                {
                    string invoice = this.dgvHotelBooking.CurrentRow.Cells["colhInvoice"].Value.ToString();
                    if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        HotelBooking hotelBooking = new HotelBooking();
                        hotelBooking = (from x in this.entity.HotelBookings
                                        where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                                        select x).FirstOrDefault<HotelBooking>();
                        if (hotelBooking != null)
                        {
                            hotelBooking.IsDelete = new bool?(true);
                            this.entity.SaveChanges();
                        }
                        List<HotelRoom> list = new List<HotelRoom>();
                        list = (from x in this.entity.HotelRooms
                                where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                                select x).ToList<HotelRoom>();
                        if (list.Count > 0)
                        {
                            for (int i = 0; i < list.Count; i++)
                            {
                                list[i].IsDelete = new bool?(true);
                                this.entity.SaveChanges();
                            }
                        }
                        this.LoadHotelBookingList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Token: 0x06000E2F RID: 3631 RVA: 0x0009D68C File Offset: 0x0009B88C
        private void txthContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txthCompanyName.Focus();
            }
        }

        // Token: 0x06000E30 RID: 3632 RVA: 0x0009D6BC File Offset: 0x0009B8BC
        private void txthCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txthContactPhone.Focus();
            }
        }

        // Token: 0x06000E31 RID: 3633 RVA: 0x0009D6EC File Offset: 0x0009B8EC
        private void txthContactPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txthEmail.Focus();
            }
        }

        // Token: 0x06000E32 RID: 3634 RVA: 0x0009D71C File Offset: 0x0009B91C
        private void txthSubject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txthEmail.Focus();
            }
        }

        // Token: 0x06000E33 RID: 3635 RVA: 0x0009D74C File Offset: 0x0009B94C
        private void txthEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbohCurrency.Focus();
            }
        }

        // Token: 0x06000E34 RID: 3636 RVA: 0x0009D77C File Offset: 0x0009B97C
        private void dtphHotelBooking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpArrivalDate.Focus();
            }
        }

        // Token: 0x06000E35 RID: 3637 RVA: 0x0009D7AC File Offset: 0x0009B9AC
        private void dtpArrivalDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpDepatureDate.Focus();
            }
        }

        // Token: 0x06000E36 RID: 3638 RVA: 0x0009D7DC File Offset: 0x0009B9DC
        private void dtpDepatureDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int num = Convert.ToInt32((this.dtpDepatureDate.Value - this.dtpArrivalDate.Value).TotalDays);
                this.txtNightNo.Text = num.ToString();
                this.txtPaxNo.Focus();
            }
        }

        // Token: 0x06000E37 RID: 3639 RVA: 0x0009D848 File Offset: 0x0009BA48
        private void txtPaxNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPaxNo.Text = ((this.txtNightNo.Text == "") ? "0" : this.txtPaxNo.Text);
                this.txtNightNo.Focus();
            }
        }

        // Token: 0x06000E38 RID: 3640 RVA: 0x0009D8AC File Offset: 0x0009BAAC
        private void txtNightNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtNightNo.Text = ((this.txtNightNo.Text == "") ? "0" : this.txtNightNo.Text);
                this.cbohPaymentTerm.Focus();
            }
        }

        // Token: 0x06000E39 RID: 3641 RVA: 0x0009D910 File Offset: 0x0009BB10
        private void txthRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cboRoomType.Focus();
            }
        }

        // Token: 0x06000E3A RID: 3642 RVA: 0x0009D948 File Offset: 0x0009BB48
        private void cboRoomType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.cboRoomType.SelectedValue != null)
                {
                    string rate = this.cboRoomType.Text;
                    string room = this.cboRoomType.SelectedValue.ToString();
                    RoomType no = new RoomType();
                    no = (from x in this.entity.RoomTypes
                          where x.Code == room && x.IsDelete == (bool?)false
                          select x).FirstOrDefault<RoomType>();
                    this.txthRate.Text = no.Rate.ToString();
                    this.txthRate.Focus();
                }
                else
                {
                    this.txthRate.Focus();
                }
            }
        }

        // Token: 0x06000E3B RID: 3643 RVA: 0x0009DAB4 File Offset: 0x0009BCB4
        private void txthRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtRoomNo.Focus();
            }
        }

        // Token: 0x06000E3C RID: 3644 RVA: 0x0009DAE4 File Offset: 0x0009BCE4
        private void txtRoomNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal d = decimal.Parse(this.txthRate.Text);
                int value = int.Parse(this.txtRoomNo.Text);
                this.txthAmount.Text = (d * value).ToString();
                this.btnhAdd_Click(sender, e);
            }
        }

        // Token: 0x06000E3D RID: 3645 RVA: 0x0009DB50 File Offset: 0x0009BD50
        private void txtPassenger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPassport.Focus();
            }
        }

        // Token: 0x06000E3E RID: 3646 RVA: 0x0009DB80 File Offset: 0x0009BD80
        private void txtPassport_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cboPassengerType.Focus();
            }
        }

        // Token: 0x06000E3F RID: 3647 RVA: 0x0009DBB0 File Offset: 0x0009BDB0
        private void txtTicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtFare.Focus();
            }
        }

        // Token: 0x06000E40 RID: 3648 RVA: 0x0009DBE0 File Offset: 0x0009BDE0
        private void cboPaymentTerm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cboIncomeType.Focus();
            }
        }

        // Token: 0x06000E41 RID: 3649 RVA: 0x0009DC18 File Offset: 0x0009BE18
        private void cboCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Currency = this.cboCurrency.Text;
                Currency curr = new Currency();
                curr = (from x in this.entity.Currencies
                        where x.Code == Currency && x.IsDelete == (bool?)false
                        select x).FirstOrDefault<Currency>();
                this.txtAcurrate.Text = curr.Rate.ToString();
                this.txtAcurrate.Focus();
            }
        }

        // Token: 0x06000E42 RID: 3650 RVA: 0x0009DD48 File Offset: 0x0009BF48
        private void cboPassengerType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtTicker.Focus();
            }
        }

        // Token: 0x06000E43 RID: 3651 RVA: 0x0009DD80 File Offset: 0x0009BF80
        private void cbohCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Currency = this.cbohCurrency.Text;
                Currency currency = new Currency();
                currency = (from x in this.entity.Currencies
                            where x.Code == Currency && x.IsDelete == (bool?)false
                            select x).FirstOrDefault<Currency>();
                this.txthCurRate.Text = currency.Rate.ToString();
                this.txthCurRate.Focus();
            }
        }

        // Token: 0x06000E44 RID: 3652 RVA: 0x0009DEB0 File Offset: 0x0009C0B0
        private void txthAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txthSupplier.Focus();
            }
        }

        // Token: 0x06000E45 RID: 3653 RVA: 0x0009DEE0 File Offset: 0x0009C0E0
        private void cbohPaymentTerm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbohIncomeType.Focus();
            }
        }

        // Token: 0x06000E46 RID: 3654 RVA: 0x0009DF10 File Offset: 0x0009C110
        private void txthSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dgvHotelBooking.Rows.Clear();
                List<HotelBooking> dis = new List<HotelBooking>();
                dis = (from x in this.entity.HotelBookings
                       where x.IsDelete == (bool?)false && x.Status != "I" && (x.ContactPerson.Contains(this.txthSearch.Text) || x.CompanyName.Contains(this.txthSearch.Text) || x.InvoiceNo.Contains(this.txthSearch.Text))
                       select x).ToList<HotelBooking>();
                for (int Nno = 0; Nno < dis.Count; Nno++)
                {
                    this.dgvHotelBooking.Rows.Add(new object[]
					{
						Nno + 1,
						dis[Nno].InvoiceDate.Value.ToShortDateString(),
						dis[Nno].InvoiceNo,
						dis[Nno].CompanyName,
						dis[Nno].ContactPerson
					});
                }
            }
        }

        // Token: 0x06000E47 RID: 3655 RVA: 0x0009E1FC File Offset: 0x0009C3FC
        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.CalculateHotelDiscount();
            }
        }

        // Token: 0x06000E48 RID: 3656 RVA: 0x0009E224 File Offset: 0x0009C424
        private void CalculateHotelDiscount()
        {
            if (this.txtBalance.Text != "" && this.txtBalance.Text != null)
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

        // Token: 0x06000E49 RID: 3657 RVA: 0x0009E33C File Offset: 0x0009C53C
        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.IsMatch(this.txtNo.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                this.txtNo.Text = "";
                this.txtNo.Focus();
            }
        }

        // Token: 0x06000E4A RID: 3658 RVA: 0x0009E390 File Offset: 0x0009C590
        private void txtFare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.IsMatch(this.txtFare.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                this.txtFare.Text = "";
                this.txtFare.Focus();
            }
        }

        // Token: 0x06000E4B RID: 3659 RVA: 0x0009E3E4 File Offset: 0x0009C5E4
        private void txtbTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.IsMatch(this.txtbTax.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                this.txtTax.Text = "";
                this.txtTax.Focus();
            }
        }

        // Token: 0x06000E4C RID: 3660 RVA: 0x0009E438 File Offset: 0x0009C638
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dgvBookingList.Rows.Clear();
                List<TicketBooking> list = new List<TicketBooking>();
                list = (from x in this.entity.TicketBookings
                        where x.IsDelete == (bool?)false && x.Status != "I" && (x.ContactPerson.Contains(this.txtSearch.Text) || x.CompanyName.Contains(this.txtSearch.Text) || x.InvoiceNo.Contains(this.txtSearch.Text))
                        select x).ToList<TicketBooking>();
                for (int i = 0; i < list.Count; i++)
                {
                    this.dgvBookingList.Rows.Add(new object[]
					{
						i + 1,
						list[i].Date.Value.ToShortDateString(),
						list[i].CompanyName,
						list[i].ContactPerson,
						list[i].InvoiceNo
					});
                }
            }
        }

        // Token: 0x06000E4D RID: 3661 RVA: 0x0009E724 File Offset: 0x0009C924
        private void txtPaxNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.IsMatch(this.txtPaxNo.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                this.txtPaxNo.Text = "";
                this.txtPaxNo.Focus();
            }
        }

        // Token: 0x06000E4E RID: 3662 RVA: 0x0009E778 File Offset: 0x0009C978
        private void txtNightNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.IsMatch(this.txtNightNo.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                this.txtNightNo.Text = "";
                this.txtNightNo.Focus();
            }
        }

        // Token: 0x06000E4F RID: 3663 RVA: 0x0009E7CC File Offset: 0x0009C9CC
        private void txthRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.IsMatch(this.txthRate.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                this.txthRate.Text = "";
                this.txthRate.Focus();
            }
        }

        // Token: 0x06000E50 RID: 3664 RVA: 0x0009E820 File Offset: 0x0009CA20
        private void txtRoomNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.IsMatch(this.txtRoomNo.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                this.txtRoomNo.Text = "";
                this.txtRoomNo.Focus();
            }
        }

        // Token: 0x06000E51 RID: 3665 RVA: 0x0009E874 File Offset: 0x0009CA74
        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.IsMatch(this.txtDiscount.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                this.txtDiscount.Text = "";
                this.txtDiscount.Focus();
            }
        }

        // Token: 0x06000E52 RID: 3666 RVA: 0x0009E8C8 File Offset: 0x0009CAC8
        private void dgvBookingList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // Token: 0x06000E53 RID: 3667 RVA: 0x0009E8CC File Offset: 0x0009CACC
        private void pnlTourPackage_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, base.Width, base.Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.LightGreen, Color.SeaGreen, 90f);
            graphics.FillRectangle(brush, gradient_rectangle);
        }

        // Token: 0x06000E54 RID: 3668 RVA: 0x0009E918 File Offset: 0x0009CB18
        private void pnlHotelBooking_Paint(object sender, PaintEventArgs e)
        {
            Graphics r = e.Graphics;
            Rectangle price = new Rectangle(0, 0, base.Width, base.Height);
            Brush pno = new LinearGradientBrush(price, Color.LightSkyBlue, Color.DarkCyan, 90f);
            r.FillRectangle(pno, price);
        }

        // Token: 0x06000E55 RID: 3669 RVA: 0x0009E964 File Offset: 0x0009CB64
        private void pnlTravel_Paint(object sender, PaintEventArgs e)
        {
            Graphics rtype = e.Graphics;
            Rectangle r = new Rectangle(0, 0, base.Width, base.Height);
            Brush brush = new LinearGradientBrush(r, Color.LightPink, Color.HotPink, 90f);
            rtype.FillRectangle(brush, r);
        }

        // Token: 0x06000E56 RID: 3670 RVA: 0x0009E9B8 File Offset: 0x0009CBB8
        private void btnTAdd_Click(object sender, EventArgs e)
        {
            string pcode = "";
            Package package = new Package();
            if (this.cboTPackage.SelectedValue != null)
            {
                pcode = this.cboTPackage.SelectedValue.ToString();
                package = (from x in this.entity.Packages
                           where x.Code == pcode && x.IsDelete == (bool?)false
                           select x).FirstOrDefault<Package>();
            }
            else
            {
                package.Description = this.cboTPackage.Text;
            }
            decimal num = decimal.Parse((this.txtTPrice.Text == "") ? "0" : this.txtTPrice.Text);
            int num2 = int.Parse((this.txtTNoofPax.Text == "") ? "0" : this.txtTNoofPax.Text);
            decimal num3 = decimal.Parse((this.txtTAmount.Text == "") ? "0" : this.txtTAmount.Text);
            this.dgvTourPackage.Rows.Add(new object[]
			{
				package.Description,
				num,
				num2,
				num3,
				this.cboTAirLine.SelectedValue,
				this.txtTFlightNo.Text,
				0,
				null,
				pcode
			});
            this.CalculateTourPackageAmount();
            this.cboTPackage.SelectedIndex = 0;
            this.txtTPrice.Text = "0";
            this.txtTNoofPax.Text = "0";
            this.txtTAmount.Text = "0";
            this.cboTAirLine.SelectedIndex = 0;
            this.txtTFlightNo.Text = "";
            this.cboTPackage.Focus();
        }

        // Token: 0x06000E57 RID: 3671 RVA: 0x0009EC6C File Offset: 0x0009CE6C
        private void cboTPackage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.cboTPackage.SelectedValue != null)
                {
                    string price = this.cboTPackage.Text;
                    string room = this.cboTPackage.SelectedValue.ToString();
                    Package pno = new Package();
                    pno = (from x in this.entity.Packages
                           where x.Code == room && x.IsDelete == (bool?)false
                           select x).FirstOrDefault<Package>();
                    this.txtTPrice.Text = pno.Price.ToString();
                    this.txtTPrice.Focus();
                }
                else
                {
                    this.txtTPrice.Focus();
                }
            }
        }

        // Token: 0x06000E58 RID: 3672 RVA: 0x0009EDD8 File Offset: 0x0009CFD8
        private void txtTPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtTNoofPax.Focus();
            }
        }

        // Token: 0x06000E59 RID: 3673 RVA: 0x0009EE08 File Offset: 0x0009D008
        private void txtTNoofPax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal dis = decimal.Parse(this.txtTPrice.Text);
                int totalamt = int.Parse(this.txtTNoofPax.Text);
                this.txtTAmount.Text = (dis * totalamt).ToString();
                this.cboTAirLine.Focus();
            }
        }

        // Token: 0x06000E5A RID: 3674 RVA: 0x0009EE78 File Offset: 0x0009D078
        private void txtTDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.CalculateTourDiscount();
            }
        }

        // Token: 0x06000E5B RID: 3675 RVA: 0x0009EEA0 File Offset: 0x0009D0A0
        private void CalculateTourDiscount()
        {
            if (this.txtTBalance.Text != "" && this.txtTBalance.Text != null)
            {
                decimal d = decimal.Parse(this.txtTDiscount.Text);
                decimal d2 = decimal.Parse(this.txtTtotalAmount.Text);
                if (d > 0)
                {
                    this.txtTBalance.Text = (d2 - d2 * (d / 100)).ToString();
                    this.tDiscount = d2 * (d / 100);
                }
                else
                {
                    this.txtTBalance.Text = d2.ToString();
                    this.tDiscount = 0m;
                }
            }
        }

        // Token: 0x06000E5C RID: 3676 RVA: 0x0009EFB8 File Offset: 0x0009D1B8
        private void btnTourPackageBooking_Click(object sender, EventArgs e)
        {
            if (this.TourPackageIsValid())
            {
                try
                {
                    if (this.btnTourPackageBooking.Text == "Booking")
                    {
                        TourBooking v = new TourBooking();
                        v.InvoiceNo = this.txtTInvoiceNo.Text;
                        v.SystemDate = new DateTime?(DateTime.Now);
                        v.ContactPerson = this.txtTContactPerson.Text;
                        v.CompanyName = this.txtTCompany.Text;
                        v.ContactPhone = this.txtTContactPhone.Text;
                        v.Currency = this.cboTCurrency.SelectedValue.ToString();
                        v.MeetingPoint = this.txtMeetPoing.Text;
                        v.Type = this.cboTTransportation.SelectedItem.ToString();
                        v.Rate = new decimal?(int.Parse(this.txtTCurRate.Text));
                        v.PaymentTerm = this.cboTPayment.SelectedValue.ToString();
                        v.Address = this.txtTAdress.Text;
                        v.Email = this.txtTemail.Text;
                        v.t1 = this.cbotIncomeType.SelectedValue.ToString();
                        v.t2 = this.txttsupplier.Text;
                        v.InvoiceDate = new DateTime?(DateTime.Parse(this.dtpTInvoiceDate.Value.ToShortDateString()));
                        v.DepatureDate = new DateTime?(DateTime.Parse(this.dtpTDepatureDate.Value.ToShortDateString()));
                        v.ArrivalDate = new DateTime?(DateTime.Parse(this.dtpTArrivalDate.Value.ToShortDateString()));
                        v.NoofNight = new int?(int.Parse((this.txtTNofN.Text == "") ? "0" : this.txtTNofN.Text));
                        v.Discount = new decimal?(this.tDiscount);
                        v.Discount_Percent = new int?(int.Parse((this.txtTDiscount.Text == "") ? "0" : this.txtTDiscount.Text));
                        v.TotalAmount = new decimal?(decimal.Parse((this.txtTtotalAmount.Text == "") ? "0" : this.txtTtotalAmount.Text));
                        v.Balance = new decimal?(decimal.Parse((this.txtTBalance.Text == "") ? "0" : this.txtTBalance.Text));
                        v.Remark = this.txtTRemark.Text;
                        v.MMKBalance = new decimal?(this.CalculateMMKAmount(Convert.ToInt32(v.Rate), Convert.ToDecimal(v.Balance)));
                        v.Status = "B";
                        v.User = Utility.Utility.User;
                        v.IsDelete = new bool?(false);
                        this.entity.AddToTourBookings(v);
                        this.entity.SaveChanges();
                        if (this.dgvTourPackage.Rows.Count > 0)
                        {
                            for (int i = 0; i < this.dgvTourPackage.Rows.Count; i++)
                            {
                                TourPackage tourPackage = new TourPackage();
                                tourPackage.InvoiceNo = this.txtTInvoiceNo.Text;
                                tourPackage.SystemDate = new DateTime?(DateTime.Now);
                                tourPackage.PackageDescription = this.dgvTourPackage.Rows[i].Cells["colpackage"].Value.ToString();
                                tourPackage.AirLine = this.dgvTourPackage.Rows[i].Cells["colAirline"].Value.ToString();
                                tourPackage.FlightNo = this.dgvTourPackage.Rows[i].Cells["colFlightNo"].Value.ToString();
                                tourPackage.Price = new decimal?(decimal.Parse(this.dgvTourPackage.Rows[i].Cells["colTPrice"].Value.ToString()));
                                tourPackage.NoofPax = new int?(int.Parse(this.dgvTourPackage.Rows[i].Cells["colTPax"].Value.ToString()));
                                tourPackage.Amount = new decimal?(decimal.Parse(this.dgvTourPackage.Rows[i].Cells["colTAmount"].Value.ToString()));
                                tourPackage.PackageCode = this.dgvTourPackage.Rows[i].Cells["colTpCode"].Value.ToString();
                                tourPackage.Status = "B";
                                tourPackage.User = Utility.Utility.User;
                                tourPackage.IsDelete = new bool?(false);
                                this.entity.AddToTourPackages(tourPackage);
                                this.entity.SaveChanges();
                            }
                        }
                        foreach (object obj in this.chkOtherService.CheckedItems)
                        {
                            string text = (string)obj;
                            string services = text.ToString();
                            ServicesOrRequirement servicesOrRequirement = new ServicesOrRequirement();
                            Services services2 = new Services();
                            services2 = (from x in this.entity.Services
                                         where x.Description == services && x.Transaction == "Travel & Tour" && x.IsDelete == (bool?)false
                                         select x).FirstOrDefault<Services>();
                            servicesOrRequirement.CreatedDate = new DateTime?(DateTime.Now);
                            servicesOrRequirement.Code = services2.Code;
                            servicesOrRequirement.Description = services2.Description;
                            servicesOrRequirement.InvoiceNo = this.txtTInvoiceNo.Text;
                            servicesOrRequirement.Transaction = "Travel & Tour";
                            servicesOrRequirement.User = Utility.Utility.User;
                            this.entity.AddToServicesOrRequirement(servicesOrRequirement);
                            this.entity.SaveChanges();
                        }
                        MessageBox.Show("Booking Successful!", "Successful", MessageBoxButtons.OK);
                    }
                    else if (this.btnTourPackageBooking.Text == "Update")
                    {
                        string invoice = this.txtTInvoiceNo.Text;
                        TourBooking v = new TourBooking();
                        v = (from x in this.entity.TourBookings
                             where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                             select x).FirstOrDefault<TourBooking>();
                        v.InvoiceNo = this.txtTInvoiceNo.Text;
                        v.SystemDate = new DateTime?(DateTime.Now);
                        v.ContactPerson = this.txtTContactPerson.Text;
                        v.CompanyName = this.txtTCompany.Text;
                        v.ContactPhone = this.txtTContactPhone.Text;
                        v.t1 = this.cbotIncomeType.SelectedValue.ToString();
                        v.t2 = this.txttsupplier.Text;
                        v.Currency = this.cboTCurrency.SelectedValue.ToString();
                        v.MeetingPoint = this.txtMeetPoing.Text;
                        v.Type = this.cboTTransportation.SelectedItem.ToString();
                        v.Rate = new decimal?(int.Parse(this.txtTCurRate.Text));
                        v.PaymentTerm = this.cboTPayment.SelectedValue.ToString();
                        v.Address = this.txtTAdress.Text;
                        v.Email = this.txtTemail.Text;
                        v.InvoiceDate = new DateTime?(DateTime.Parse(this.dtpTInvoiceDate.Value.ToShortDateString()));
                        v.DepatureDate = new DateTime?(DateTime.Parse(this.dtpTDepatureDate.Value.ToShortDateString()));
                        v.ArrivalDate = new DateTime?(DateTime.Parse(this.dtpTArrivalDate.Value.ToShortDateString()));
                        v.NoofNight = new int?(int.Parse((this.txtTNofN.Text == "") ? "0" : this.txtTNofN.Text));
                        v.Discount = new decimal?(this.tDiscount);
                        v.Discount_Percent = new int?(int.Parse((this.txtTDiscount.Text == "") ? "0" : this.txtTDiscount.Text));
                        v.TotalAmount = new decimal?(decimal.Parse((this.txtTtotalAmount.Text == "") ? "0" : this.txtTtotalAmount.Text));
                        v.Balance = new decimal?(decimal.Parse((this.txtTBalance.Text == "") ? "0" : this.txtTBalance.Text));
                        v.Remark = this.txtTRemark.Text;
                        v.MMKBalance = new decimal?(this.CalculateMMKAmount(Convert.ToInt32(v.Rate), Convert.ToDecimal(v.Balance)));
                        v.Status = "U";
                        v.User = Utility.Utility.User;
                        v.IsDelete = new bool?(false);
                        this.entity.SaveChanges();
                        if (this.dgvTourPackage.Rows.Count > 0)
                        {
                            if (this.tourpDeleteID.Count > 0)
                            {
                                for (int i = 0; i < this.tourpDeleteID.Count; i++)
                                {
                                    TourPackage tourPackage2 = new TourPackage();
                                    int Id = int.Parse(this.tourpDeleteID[i].ToString());
                                    tourPackage2 = (from x in this.entity.TourPackages
                                                    where x.ID == Id && x.IsDelete == (bool?)false
                                                    select x).FirstOrDefault<TourPackage>();
                                    tourPackage2.IsDelete = new bool?(true);
                                    this.entity.SaveChanges();
                                }
                            }
                            for (int i = 0; i < this.dgvTourPackage.Rows.Count; i++)
                            {
                                if (this.dgvTourPackage.Rows[i].Cells["colTID"].Value == null)
                                {
                                    TourPackage tourPackage = new TourPackage();
                                    tourPackage.InvoiceNo = this.txtTInvoiceNo.Text;
                                    tourPackage.SystemDate = new DateTime?(DateTime.Now);
                                    tourPackage.PackageDescription = this.dgvTourPackage.Rows[i].Cells["colpackage"].Value.ToString();
                                    tourPackage.AirLine = this.dgvTourPackage.Rows[i].Cells["colAirline"].Value.ToString();
                                    tourPackage.FlightNo = this.dgvTourPackage.Rows[i].Cells["colFlightNo"].Value.ToString();
                                    tourPackage.Price = new decimal?(decimal.Parse(this.dgvTourPackage.Rows[i].Cells["colTPrice"].Value.ToString()));
                                    tourPackage.NoofPax = new int?(int.Parse(this.dgvTourPackage.Rows[i].Cells["colTPax"].Value.ToString()));
                                    tourPackage.Amount = new decimal?(decimal.Parse(this.dgvTourPackage.Rows[i].Cells["colTAmount"].Value.ToString()));
                                    tourPackage.PackageCode = this.dgvTourPackage.Rows[i].Cells["colTpCode"].Value.ToString();
                                    tourPackage.User = Utility.Utility.User;
                                    tourPackage.Status = "B";
                                    tourPackage.IsDelete = new bool?(false);
                                    this.entity.AddToTourPackages(tourPackage);
                                    this.entity.SaveChanges();
                                }
                                else
                                {
                                    TourPackage tourPackage = new TourPackage();
                                    int Id = int.Parse(this.dgvTourPackage.Rows[i].Cells["colTID"].Value.ToString());
                                    tourPackage = (from x in this.entity.TourPackages
                                                   where x.ID == Id && x.IsDelete == (bool?)false
                                                   select x).FirstOrDefault<TourPackage>();
                                    tourPackage.InvoiceNo = this.txtTInvoiceNo.Text;
                                    tourPackage.SystemDate = new DateTime?(DateTime.Now);
                                    tourPackage.PackageDescription = this.dgvTourPackage.Rows[i].Cells["colpackage"].Value.ToString();
                                    tourPackage.AirLine = this.dgvTourPackage.Rows[i].Cells["colAirline"].Value.ToString();
                                    tourPackage.FlightNo = this.dgvTourPackage.Rows[i].Cells["colFlightNo"].Value.ToString();
                                    tourPackage.Price = new decimal?(decimal.Parse(this.dgvTourPackage.Rows[i].Cells["colTPrice"].Value.ToString()));
                                    tourPackage.NoofPax = new int?(int.Parse(this.dgvTourPackage.Rows[i].Cells["colTPax"].Value.ToString()));
                                    tourPackage.Amount = new decimal?(decimal.Parse(this.dgvTourPackage.Rows[i].Cells["colTAmount"].Value.ToString()));
                                    tourPackage.PackageCode = this.dgvTourPackage.Rows[i].Cells["colTpCode"].Value.ToString();
                                    tourPackage.User = Utility.Utility.User;
                                    tourPackage.Status = "U";
                                    tourPackage.IsDelete = new bool?(false);
                                    this.entity.SaveChanges();
                                }
                            }
                        }
                        List<ServicesOrRequirement> list = new List<ServicesOrRequirement>();
                        ServicesOrRequirement servicesOrRequirement = new ServicesOrRequirement();
                        Services services2 = new Services();
                        list = (from x in this.entity.ServicesOrRequirement
                                where x.InvoiceNo == this.txtTInvoiceNo.Text && x.Transaction == "Travel & Tour"
                                select x).ToList<ServicesOrRequirement>();
                        for (int i = 0; i < list.Count; i++)
                        {
                            int id = list[i].ID;
                            servicesOrRequirement = new ServicesOrRequirement();
                            servicesOrRequirement = (from x in this.entity.ServicesOrRequirement
                                                     where x.ID == id
                                                     select x).FirstOrDefault<ServicesOrRequirement>();
                            this.entity.ServicesOrRequirement.DeleteObject(servicesOrRequirement);
                            this.entity.SaveChanges();
                        }
                        foreach (object obj2 in this.chkOtherService.CheckedItems)
                        {
                            string text = (string)obj2;
                            string services = text.ToString();
                            services2 = (from x in this.entity.Services
                                         where x.Description == services && x.Transaction == "Travel & Tour" && x.IsDelete == (bool?)false
                                         select x).FirstOrDefault<Services>();
                            servicesOrRequirement = new ServicesOrRequirement();
                            servicesOrRequirement.CreatedDate = new DateTime?(DateTime.Now);
                            servicesOrRequirement.Code = services2.Code;
                            servicesOrRequirement.Description = services2.Description;
                            servicesOrRequirement.InvoiceNo = this.txtTInvoiceNo.Text;
                            servicesOrRequirement.Transaction = "Travel & Tour";
                            servicesOrRequirement.User = Utility.Utility.User;
                            this.entity.AddToServicesOrRequirement(servicesOrRequirement);
                            this.entity.SaveChanges();
                        }
                        MessageBox.Show("Update Successful!", "Successful", MessageBoxButtons.OK);
                    }
                    else if (this.btnTourPackageBooking.Text == "Issue")
                    {
                        string invoice = this.txtTInvoiceNo.Text;
                        TourBooking v = new TourBooking();
                        v = (from x in this.entity.TourBookings
                             where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                             select x).FirstOrDefault<TourBooking>();
                        v.InvoiceNo = this.txtTInvoiceNo.Text;
                        v.SystemDate = new DateTime?(DateTime.Now);
                        v.ContactPerson = this.txtTContactPerson.Text;
                        v.CompanyName = this.txtTCompany.Text;
                        v.ContactPhone = this.txtTContactPhone.Text;
                        v.Currency = this.cboTCurrency.SelectedValue.ToString();
                        v.MeetingPoint = this.txtMeetPoing.Text;
                        v.Type = this.cboTTransportation.SelectedItem.ToString();
                        v.Rate = new decimal?(int.Parse(this.txtTCurRate.Text));
                        v.PaymentTerm = this.cboTPayment.SelectedValue.ToString();
                        v.Address = this.txtTAdress.Text;
                        v.Email = this.txtTemail.Text;
                        v.InvoiceDate = new DateTime?(DateTime.Parse(this.dtpTInvoiceDate.Value.ToShortDateString()));
                        v.DepatureDate = new DateTime?(DateTime.Parse(this.dtpTDepatureDate.Value.ToShortDateString()));
                        v.ArrivalDate = new DateTime?(DateTime.Parse(this.dtpTArrivalDate.Value.ToShortDateString()));
                        v.NoofNight = new int?(int.Parse((this.txtTNofN.Text == "") ? "0" : this.txtTNofN.Text));
                        v.Discount = new decimal?(this.tDiscount);
                        v.Discount_Percent = new int?(int.Parse((this.txtTDiscount.Text == "") ? "0" : this.txtTDiscount.Text));
                        v.TotalAmount = new decimal?(decimal.Parse((this.txtTtotalAmount.Text == "") ? "0" : this.txtTtotalAmount.Text));
                        v.Balance = new decimal?(decimal.Parse((this.txtTBalance.Text == "") ? "0" : this.txtTBalance.Text));
                        v.Remark = this.txtTRemark.Text;
                        v.MMKBalance = new decimal?(this.CalculateMMKAmount(Convert.ToInt32(v.Rate), Convert.ToDecimal(v.Balance)));
                        v.Status = "I";
                        v.User = Utility.Utility.User;
                        v.IsDelete = new bool?(false);
                        this.entity.SaveChanges();
                        MessageBox.Show("Confirm Successful!", "Successful", MessageBoxButtons.OK);
                        this.btnTPreview_Click(sender, e);
                    }
                    this.tourpDeleteID = new List<int>();
                    this.CleanTourPackageBooking();
                    this.LoadTourPackageBookingList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please fill information!", "Incomplete Information");
            }
        }

        // Token: 0x06000E5D RID: 3677 RVA: 0x000A09E0 File Offset: 0x0009EBE0
        private void btnTCancel_Click(object sender, EventArgs e)
        {
            this.CleanTourPackageBooking();
        }

        // Token: 0x06000E5E RID: 3678 RVA: 0x000A09EC File Offset: 0x0009EBEC
        private void cboAType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboAType.SelectedItem == "Bus")
            {
                this.label29.Text = "Car No";
                this.colFNo.HeaderText = "Car No";
                this.label147.Text = "CarLine";
                this.colAairline.HeaderText = "CarLine";
                this.cboAVehicalName.DataSource = null;
                List<Vehical> dataSource = new List<Vehical>();
                dataSource = (from x in this.entity.Vehicals
                              where x.IsDelete == (bool?)false && x.Type == "Bus"
                              select x).ToList<Vehical>();
                this.cboAVehicalName.DataSource = dataSource;
                this.cboAVehicalName.DisplayMember = "Name";
                this.cboAVehicalName.ValueMember = "Name";
                this.cboAVehicalName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cboAVehicalName.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            else
            {
                this.label29.Text = "Flight No";
                this.colFNo.HeaderText = "Flight No";
                this.label147.Text = "AirLine";
                this.colAairline.HeaderText = "AirLine";
                this.cboAVehicalName.DataSource = null;
                List<Vehical> dataSource = new List<Vehical>();
                dataSource = (from x in this.entity.Vehicals
                              where x.IsDelete == (bool?)false && x.Type == "Airline"
                              select x).ToList<Vehical>();
                this.cboAVehicalName.DataSource = dataSource;
                this.cboAVehicalName.DisplayMember = "Name";
                this.cboAVehicalName.ValueMember = "Name";
                this.cboAVehicalName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cboAVehicalName.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        // Token: 0x06000E5F RID: 3679 RVA: 0x000A0CE1 File Offset: 0x0009EEE1
        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        // Token: 0x06000E60 RID: 3680 RVA: 0x000A0CE4 File Offset: 0x0009EEE4
        private void cboAVehicalName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtFlight.Focus();
            }
        }

        // Token: 0x06000E61 RID: 3681 RVA: 0x000A0D14 File Offset: 0x0009EF14
        private void dgvTourPackage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (this.dgvTourPackage.CurrentRow.Cells["colTID"].Value != null)
                {
                    this.tourpDeleteID.Add(int.Parse(this.dgvTourPackage.CurrentRow.Cells["colTID"].Value.ToString()));
                }
                int pno = int.Parse(this.dgvTourPackage.CurrentRow.Cells["colTPax"].Value.ToString());
                decimal price = int.Parse(this.dgvTourPackage.CurrentRow.Cells["colTPrice"].Value.ToString());
                decimal amt = int.Parse(this.dgvTourPackage.CurrentRow.Cells["colTAmount"].Value.ToString());
                this.ReCalculateTourPackageAmount(pno, price, amt);
                this.dgvTourPackage.Rows.Remove(this.dgvTourPackage.CurrentRow);
            }
        }

        // Token: 0x06000E62 RID: 3682 RVA: 0x000A0E4C File Offset: 0x0009F04C
        private void dgvTourPackageList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    this.CleanTourPackageBooking();
                    string invoice2 = this.dgvTourPackageList.CurrentRow.Cells["colTInvoice"].Value.ToString();
                    this.BindTourPackageBooking(invoice2);
                    this.btnTourPackageBooking.Text = "Update";
                }
                if (e.ColumnIndex == 6)
                {
                    this.CleanTourPackageBooking();
                    string invoice2 = this.dgvTourPackageList.CurrentRow.Cells["colTInvoice"].Value.ToString();
                    this.BindTourPackageBooking(invoice2);
                    this.btnTourPackageBooking.Text = "Issue";
                    this.btnTourPackageBooking.Focus();
                }
                if (e.ColumnIndex == 7)
                {
                    string invoice = this.dgvTourPackageList.CurrentRow.Cells["colTInvoice"].Value.ToString();
                    if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        TourBooking tourBooking = new TourBooking();
                        tourBooking = (from x in this.entity.TourBookings
                                       where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                                       select x).FirstOrDefault<TourBooking>();
                        if (tourBooking != null)
                        {
                            tourBooking.IsDelete = new bool?(true);
                            this.entity.SaveChanges();
                        }
                        List<TourPackage> list = new List<TourPackage>();
                        list = (from x in this.entity.TourPackages
                                where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                                select x).ToList<TourPackage>();
                        if (list.Count > 0)
                        {
                            for (int i = 0; i < list.Count; i++)
                            {
                                list[i].IsDelete = new bool?(true);
                                this.entity.SaveChanges();
                            }
                        }
                        this.LoadTourPackageBookingList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Token: 0x06000E63 RID: 3683 RVA: 0x000A11C8 File Offset: 0x0009F3C8
        private void txtTContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtTCompany.Focus();
            }
        }

        // Token: 0x06000E64 RID: 3684 RVA: 0x000A11F8 File Offset: 0x0009F3F8
        private void txtTCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtTContactPhone.Focus();
            }
        }

        // Token: 0x06000E65 RID: 3685 RVA: 0x000A1228 File Offset: 0x0009F428
        private void txtTContactPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtTemail.Focus();
            }
        }

        // Token: 0x06000E66 RID: 3686 RVA: 0x000A1258 File Offset: 0x0009F458
        private void txtTemail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cboTCurrency.Focus();
            }
        }

        // Token: 0x06000E67 RID: 3687 RVA: 0x000A1288 File Offset: 0x0009F488
        private void cboTCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtTCurRate.Focus();
            }
        }

        // Token: 0x06000E68 RID: 3688 RVA: 0x000A12B8 File Offset: 0x0009F4B8
        private void txtTCurRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtTAdress.Focus();
            }
        }

        // Token: 0x06000E69 RID: 3689 RVA: 0x000A12E8 File Offset: 0x0009F4E8
        private void txtTAdress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txttsupplier.Focus();
            }
        }

        // Token: 0x06000E6A RID: 3690 RVA: 0x000A1318 File Offset: 0x0009F518
        private void dtpTInvoiceDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpTDepatureDate.Focus();
            }
        }

        // Token: 0x06000E6B RID: 3691 RVA: 0x000A1348 File Offset: 0x0009F548
        private void dtpTDepatureDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpTArrivalDate.Focus();
            }
        }

        // Token: 0x06000E6C RID: 3692 RVA: 0x000A1378 File Offset: 0x0009F578
        private void dtpTArrivalDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int num = Convert.ToInt32((this.dtpTArrivalDate.Value - this.dtpTDepatureDate.Value).TotalDays);
                this.txtTNofN.Text = num.ToString();
                this.txtTNofN.Focus();
            }
        }

        // Token: 0x06000E6D RID: 3693 RVA: 0x000A13E4 File Offset: 0x0009F5E4
        private void txtTNofN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtMeetPoing.Focus();
            }
        }

        // Token: 0x06000E6E RID: 3694 RVA: 0x000A1414 File Offset: 0x0009F614
        private void txtMeetPoing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cboTPayment.Focus();
            }
        }

        // Token: 0x06000E6F RID: 3695 RVA: 0x000A1444 File Offset: 0x0009F644
        private void cboTPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbotIncomeType.Focus();
            }
        }

        // Token: 0x06000E70 RID: 3696 RVA: 0x000A147C File Offset: 0x0009F67C
        private void cboTTransportation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string type = this.cboTTransportation.Text;
                this.cboTAirLine.DataSource = null;
                List<Vehical> dataSource = new List<Vehical>();
                dataSource = (from x in this.entity.Vehicals
                              where x.IsDelete == (bool?)false && x.Type == type
                              select x).ToList<Vehical>();
                this.cboTAirLine.DataSource = dataSource;
                this.cboTAirLine.DisplayMember = "Name";
                this.cboTAirLine.ValueMember = "Name";
                this.cboTAirLine.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cboTAirLine.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.txtTRemark.Focus();
            }
        }

        // Token: 0x06000E71 RID: 3697 RVA: 0x000A15E4 File Offset: 0x0009F7E4
        private void txtTRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cboTPackage.Focus();
            }
        }

        // Token: 0x06000E72 RID: 3698 RVA: 0x000A1614 File Offset: 0x0009F814
        private void cboTAirLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtTFlightNo.Focus();
            }
        }

        // Token: 0x06000E73 RID: 3699 RVA: 0x000A1644 File Offset: 0x0009F844
        private void txtTFlightNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnTAdd_Click(sender, e);
            }
        }

        // Token: 0x06000E74 RID: 3700 RVA: 0x000A1670 File Offset: 0x0009F870
        private void txtTSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dgvTourPackageList.Rows.Clear();
                List<TourBooking> v = new List<TourBooking>();
                v = (from x in this.entity.TourBookings
                     where x.IsDelete == (bool?)false && x.Status != "I" && (x.ContactPerson.Contains(this.txtTSearch.Text) || x.CompanyName.Contains(this.txtTSearch.Text) || x.InvoiceNo.Contains(this.txtTSearch.Text))
                     select x).ToList<TourBooking>();
                for (int i = 0; i < v.Count; i++)
                {
                    this.dgvTourPackageList.Rows.Add(new object[]
					{
						i + 1,
						v[i].InvoiceDate.Value.ToShortDateString(),
						v[i].InvoiceNo,
						v[i].CompanyName,
						v[i].ContactPerson
					});
                }
            }
        }

        // Token: 0x06000E75 RID: 3701 RVA: 0x000A195C File Offset: 0x0009FB5C
        private void txtAcurrate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpbookingdate.Focus();
            }
        }

        // Token: 0x06000E76 RID: 3702 RVA: 0x000A1994 File Offset: 0x0009FB94
        private void cboAType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string type = this.cboAType.Text;
                this.cboAVehicalName.DataSource = null;
                List<Vehical> dataSource = new List<Vehical>();
                dataSource = (from x in this.entity.Vehicals
                              where x.IsDelete == (bool?)false && x.Type == type
                              select x).ToList<Vehical>();
                this.cboAVehicalName.DataSource = dataSource;
                this.cboAVehicalName.DisplayMember = "Name";
                this.cboAVehicalName.ValueMember = "Name";
                this.cboAVehicalName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cboAVehicalName.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.txtPhone.Focus();
            }
        }

        // Token: 0x06000E77 RID: 3703 RVA: 0x000A1AFC File Offset: 0x0009FCFC
        private void txthCurRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txthAddress.Focus();
            }
        }

        // Token: 0x06000E78 RID: 3704 RVA: 0x000A1B2C File Offset: 0x0009FD2C
        private void txthAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnhAdd_Click(sender, e);
            }
        }

        // Token: 0x06000E79 RID: 3705 RVA: 0x000A1B58 File Offset: 0x0009FD58
        private void cboTTransportation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTTransportation.SelectedItem == "Bus")
            {
                this.label119.Text = "CarLine";
                this.label107.Text = "CarNo";
                this.colAirLine.HeaderText = "AirLine";
                this.colFlightNo.HeaderText = "FlightNo";
                this.cboTAirLine.DataSource = null;
                List<Vehical> amount = new List<Vehical>();
                amount = (from x in this.entity.Vehicals
                          where x.IsDelete == (bool?)false && x.Type == "Bus"
                          select x).ToList<Vehical>();
                this.cboTAirLine.DataSource = amount;
                this.cboTAirLine.DisplayMember = "Name";
                this.cboTAirLine.ValueMember = "Name";
                this.cboTAirLine.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cboTAirLine.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            else
            {
                this.label119.Text = "AirLine";
                this.label107.Text = "FlightNo";
                this.colAirLine.HeaderText = "AirLine";
                this.colFlightNo.HeaderText = "FlightNo";
                this.cboTAirLine.DataSource = null;
                List<Vehical> amount = new List<Vehical>();
                amount = (from x in this.entity.Vehicals
                          where x.IsDelete == (bool?)false && x.Type == "AirLine"
                          select x).ToList<Vehical>();
                this.cboTAirLine.DataSource = amount;
                this.cboTAirLine.DisplayMember = "Name";
                this.cboTAirLine.ValueMember = "Name";
                this.cboTAirLine.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cboTAirLine.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        // Token: 0x06000E7A RID: 3706 RVA: 0x000A1E58 File Offset: 0x000A0058
        private void btnTPreview_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            List<TourBooking> list = new List<TourBooking>();
            List<TourPackage> list2 = new List<TourPackage>();
            DataTable dataTable = new DataTable("TourBooking");
            dataTable.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
            dataTable.Columns.Add(new DataColumn("InvoiceDate", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("ArrivalDate", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("DepatureDate", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("ContactPerson", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Currency", typeof(string)));
            dataTable.Columns.Add(new DataColumn("PaymentTerm", typeof(string)));
            dataTable.Columns.Add(new DataColumn("CompanyName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("MeetingPoint", typeof(string)));
            dataTable.Columns.Add(new DataColumn("ContactPhone", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Email", typeof(string)));
            dataTable.Columns.Add(new DataColumn("t1", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Address", typeof(string)));
            dataTable.Columns.Add(new DataColumn("NoofNight", typeof(int)));
            dataTable.Columns.Add(new DataColumn("TotalAmount", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("Balance", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("Discount", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("DiscountPercent", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Usesr", typeof(string)));
            DataRow dataRow = dataTable.NewRow();
            dataRow["InvoiceNo"] = this.txtTInvoiceNo.Text;
            dataRow["InvoiceDate"] = this.dtpTInvoiceDate.Value;
            dataRow["ArrivalDate"] = this.dtpTArrivalDate.Value;
            dataRow["DepatureDate"] = this.dtpTDepatureDate.Value;
            dataRow["ContactPerson"] = this.txtTContactPerson.Text;
            dataRow["CompanyName"] = this.txtTCompany.Text;
            dataRow["MeetingPoint"] = this.txtMeetPoing.Text;
            dataRow["ContactPhone"] = this.txtTContactPhone.Text;
            dataRow["Currency"] = this.cboTCurrency.Text;
            string p = this.cboTPayment.SelectedValue.ToString();
            PaymentTerm paymentTerm = new PaymentTerm();
            paymentTerm = (from x in this.entity.PaymentTerms
                           where x.Code == p && x.IsDelete == (bool?)false
                           select x).FirstOrDefault<PaymentTerm>();
            dataRow["PaymentTerm"] = paymentTerm.Description;
            dataRow["Email"] = this.txtTemail.Text;
            dataRow["t1"] = this.cbotIncomeType.SelectedValue.ToString();
            dataRow["Address"] = "";
            dataRow["NoofNight"] = int.Parse(this.txtTNofN.Text);
            dataRow["TotalAmount"] = decimal.Parse(this.txtTtotalAmount.Text);
            dataRow["Balance"] = decimal.Parse(this.txtTBalance.Text);
            dataRow["DiscountPercent"] = decimal.Parse(this.txtTDiscount.Text);
            decimal d = decimal.Parse((this.txtTDiscount.Text == "") ? "0" : this.txtTDiscount.Text);
            decimal d2 = decimal.Parse(this.txtTtotalAmount.Text);
            if (d != 0m)
            {
                dataRow["Discount"] = d2 * (d / 100m);
            }
            else
            {
                dataRow["Discount"] = 0;
            }
            dataRow["Remark"] = this.txtTRemark.Text;
            string user = Utility.Utility.Staff;
            Staff staff = new Staff();
            staff = (from x in this.entity.Staffs
                     where x.Code == user && x.IsDelete == (bool?)false
                     select x).FirstOrDefault<Staff>();
            dataRow["Type"] = this.cboTTransportation.SelectedItem.ToString();
            dataRow["Usesr"] = Utility.Utility.Staff;
            dataTable.Rows.Add(dataRow);
            DataTable dataTable2 = new DataTable("TourPackage");
            dataTable2.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("PackageDescription", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("Price", typeof(decimal)));
            dataTable2.Columns.Add(new DataColumn("NoofPax", typeof(int)));
            dataTable2.Columns.Add(new DataColumn("Amount", typeof(decimal)));
            dataTable2.Columns.Add(new DataColumn("AirLine", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("FlightNo", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("User", typeof(string)));
            if (this.dgvTourPackage.Rows.Count > 0)
            {
                for (int i = 0; i < this.dgvTourPackage.Rows.Count; i++)
                {
                    DataRow dataRow2 = dataTable2.NewRow();
                    dataRow2["InvoiceNo"] = this.txtTInvoiceNo.Text;
                    dataRow2["PackageDescription"] = this.dgvTourPackage.Rows[i].Cells["colpackage"].Value.ToString();
                    dataRow2["Price"] = this.dgvTourPackage.Rows[i].Cells["colTPrice"].Value.ToString();
                    dataRow2["NoofPax"] = this.dgvTourPackage.Rows[i].Cells["colTPax"].Value.ToString();
                    dataRow2["Amount"] = this.dgvTourPackage.Rows[i].Cells["colTAmount"].Value.ToString();
                    dataRow2["AirLine"] = this.dgvTourPackage.Rows[i].Cells["colAirLine"].Value.ToString();
                    dataRow2["FlightNo"] = this.dgvTourPackage.Rows[i].Cells["colFlightNo"].Value.ToString();
                    dataRow2["User"] = Utility.Utility.Staff;
                    dataTable2.Rows.Add(dataRow2);
                }
            }
            DataTable dataTable3 = new DataTable("ServicesOrRequirements");
            dataTable3.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
            dataTable3.Columns.Add(new DataColumn("Transaction", typeof(string)));
            dataTable3.Columns.Add(new DataColumn("Description", typeof(string)));
            dataTable3.Columns.Add(new DataColumn("User", typeof(string)));
            if (this.chkOtherService.CheckedItems.Count > 0)
            {
                for (int i = 0; i < this.chkOtherService.CheckedItems.Count; i++)
                {
                    DataRow dataRow3 = dataTable3.NewRow();
                    dataRow3["InvoiceNo"] = this.txtTInvoiceNo.Text;
                    dataRow3["Transaction"] = "Travel & Tour";
                    dataRow3["Description"] = this.chkOtherService.CheckedItems[i].ToString();
                    dataRow3["User"] = Utility.Utility.Staff;
                    dataTable3.Rows.Add(dataRow3);
                }
            }
            dataSet.Tables.Add(dataTable);
            dataSet.Tables.Add(dataTable2);
            dataSet.Tables.Add(dataTable3);
            ReportDocument reportDocument = new ReportDocument();
            dataSet.WriteXmlSchema(Application.StartupPath + "\\DataSets\\NobelMoon.xsd");
            reportDocument.Load(Application.StartupPath + "\\Reports\\TourPackageInvoice.rpt");
            reportDocument.SetDataSource(dataSet);
            frmReport frmReport = new frmReport();
            frmReport.reportViewer1.ReportSource = reportDocument;
            frmReport.reportViewer1.Refresh();
            frmReport.Show();
            base.UseWaitCursor = false;
        }

        // Token: 0x06000E7B RID: 3707 RVA: 0x000A2A58 File Offset: 0x000A0C58
        private void dgvRoom_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvRoom.SelectedCells[0].ColumnIndex == 3 || this.dgvRoom.SelectedCells[0].ColumnIndex == 1 || this.dgvRoom.SelectedCells[0].ColumnIndex == 2)
            {
                decimal d = 0m;
                decimal d2 = 0m;
                int num = 0;
                for (int i = 0; i < this.dgvRoom.Rows.Count; i++)
                {
                    d2 += decimal.Parse(this.dgvRoom.Rows[i].Cells["colRate"].Value.ToString());
                    num += int.Parse(this.dgvRoom.Rows[i].Cells["colNofN"].Value.ToString());
                    d += d2 * num;
                }
                this.txtTotalhAmount.Text = d.ToString();
            }
        }

        // Token: 0x06000E7C RID: 3708 RVA: 0x000A2B8C File Offset: 0x000A0D8C
        private bool IsValid()
        {
            return !(this.txtContactPerson.Text == "") && this.dgvFlight.Rows.Count != 0 && this.dgvPassenger.Rows.Count != 0;
        }

        // Token: 0x06000E7D RID: 3709 RVA: 0x000A2BEC File Offset: 0x000A0DEC
        private bool HotelIsValid()
        {
            return !(this.txthContactPerson.Text == "") && this.dgvRoom.Rows.Count != 0;
        }

        // Token: 0x06000E7E RID: 3710 RVA: 0x000A2C38 File Offset: 0x000A0E38
        private bool TourPackageIsValid()
        {
            return !(this.txtTContactPerson.Text == "") && this.dgvTourPackage.Rows.Count != 0;
        }

        // Token: 0x06000E7F RID: 3711 RVA: 0x000A2C84 File Offset: 0x000A0E84
        private bool CarRentalIsValid()
        {
            return !(this.txtcContactPerson.Text == "") && this.dgvCarRental.Rows.Count != 0;
        }

        // Token: 0x06000E80 RID: 3712 RVA: 0x000A2CD0 File Offset: 0x000A0ED0
        private bool PassportIsValid()
        {
            return !(this.txtPContactPerson.Text == "") && !(this.txtPtotalamount.Text == "0") && !(this.txtPtotalamount.Text == "");
        }

        // Token: 0x06000E81 RID: 3713 RVA: 0x000A2D38 File Offset: 0x000A0F38
        private void btnPRequirement_Click(object sender, EventArgs e)
        {
            if (!this.chkRequirement.Visible)
            {
                this.chkRequirement.Visible = true;
            }
            else
            {
                this.chkRequirement.Visible = false;
            }
        }

        // Token: 0x06000E82 RID: 3714 RVA: 0x000A2D74 File Offset: 0x000A0F74
        private void btnPassportAdd_Click(object sender, EventArgs e)
        {
            string text = this.txtPName.Text;
            decimal num = decimal.Parse((this.txtCharges.Text == "") ? "0" : this.txtCharges.Text);
            int count = this.dgvPassport.Rows.Count;
            this.dgvPassport.Rows.Add(new object[]
			{
				count + 1,
				text,
				num
			});
            this.CalculatePassportAmount();
            this.txtPName.Text = "";
            this.txtCharges.Text = "0";
            this.txtPName.Focus();
        }

        // Token: 0x06000E83 RID: 3715 RVA: 0x000A2E70 File Offset: 0x000A1070
        private void btnPSave_Click(object sender, EventArgs e)
        {
            if (this.PassportIsValid())
            {
                try
                {
                    if (this.btnPSave.Text == "Booking")
                    {
                        PassportBooking passportBooking = new PassportBooking();
                        passportBooking.InvoiceNo = this.txtPInvoice.Text;
                        passportBooking.SystemDate = new DateTime?(DateTime.Now);
                        passportBooking.ContactPerson = this.txtPContactPerson.Text;
                        passportBooking.ContactPhone = this.txtPContactPhone.Text;
                        passportBooking.Currency = this.cboPCurrency.SelectedValue.ToString();
                        passportBooking.Type = this.cboPType.SelectedItem.ToString();
                        passportBooking.Rate = new decimal?(int.Parse(this.txtPCurrRate.Text));
                        passportBooking.PaymentTerm = this.cboPPayment.SelectedValue.ToString();
                        passportBooking.t1 = this.cbopIncomeType.SelectedValue.ToString();
                        passportBooking.t2 = this.txtpSupplier.Text;
                        passportBooking.InvoiceDate = new DateTime?(DateTime.Parse(this.dtpPInvoiceDate.Value.ToShortDateString()));
                        passportBooking.TotalNo = new int?(int.Parse((this.txtPNo.Text == "") ? "0" : this.txtPNo.Text));
                        passportBooking.TotalAmount = new decimal?(decimal.Parse((this.txtPtotalamount.Text == "") ? "0" : this.txtPtotalamount.Text));
                        passportBooking.Remark = this.txtPRemark.Text;
                        passportBooking.MMKBalance = new decimal?(this.CalculateMMKAmount(Convert.ToInt32(passportBooking.Rate), Convert.ToDecimal(passportBooking.TotalAmount)));
                        passportBooking.Status = "B";
                        passportBooking.User = Utility.Utility.User;
                        passportBooking.IsDelete = new bool?(false);
                        this.entity.AddToPassportBookings(passportBooking);
                        this.entity.SaveChanges();
                        if (this.dgvPassport.Rows.Count > 0)
                        {
                            for (int i = 0; i < this.dgvPassport.Rows.Count; i++)
                            {
                                PassportPerson passportPerson = new PassportPerson();
                                passportPerson.InvoiceNo = this.txtPInvoice.Text;
                                passportPerson.SystemDate = new DateTime?(DateTime.Now);
                                passportPerson.Name = this.dgvPassport.Rows[i].Cells["colName"].Value.ToString();
                                passportPerson.Charges = new decimal?(decimal.Parse(this.dgvPassport.Rows[i].Cells["colCharges"].Value.ToString()));
                                passportPerson.Status = "B";
                                passportPerson.User = Utility.Utility.User;
                                passportPerson.IsDelete = new bool?(false);
                                this.entity.AddToPassportPersons(passportPerson);
                                this.entity.SaveChanges();
                            }
                        }
                        ServicesOrRequirement servicesOrRequirement = new ServicesOrRequirement();
                        RequireLetter requireLetter = new RequireLetter();
                        foreach (object obj in this.chkRequirement.CheckedItems)
                        {
                            string text = (string)obj;
                            string services = text.ToString();
                            requireLetter = (from x in this.entity.RequireLetter
                                             where x.Description == services && x.IsDelete == (bool?)false
                                             select x).FirstOrDefault<RequireLetter>();
                            servicesOrRequirement = new ServicesOrRequirement();
                            servicesOrRequirement.CreatedDate = new DateTime?(DateTime.Now);
                            servicesOrRequirement.Code = requireLetter.Code;
                            servicesOrRequirement.Description = requireLetter.Description;
                            servicesOrRequirement.InvoiceNo = this.txtPInvoice.Text;
                            servicesOrRequirement.Transaction = "Passport";
                            servicesOrRequirement.User = Utility.Utility.User;
                            this.entity.AddToServicesOrRequirement(servicesOrRequirement);
                            this.entity.SaveChanges();
                        }
                        MessageBox.Show("Booking Successful!", "Successful", MessageBoxButtons.OK);
                    }
                    else if (this.btnPSave.Text == "Update")
                    {
                        string invoice = this.txtPInvoice.Text;
                        PassportBooking passportBooking = new PassportBooking();
                        passportBooking = (from x in this.entity.PassportBookings
                                           where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                                           select x).FirstOrDefault<PassportBooking>();
                        passportBooking.InvoiceNo = this.txtPInvoice.Text;
                        passportBooking.SystemDate = new DateTime?(DateTime.Now);
                        passportBooking.ContactPerson = this.txtPContactPerson.Text;
                        passportBooking.ContactPhone = this.txtPContactPhone.Text;
                        passportBooking.Currency = this.cboPCurrency.SelectedValue.ToString();
                        passportBooking.Type = this.cboPType.SelectedItem.ToString();
                        passportBooking.t1 = this.cbopIncomeType.SelectedValue.ToString();
                        passportBooking.t2 = this.txtpSupplier.Text;
                        passportBooking.Rate = new decimal?(int.Parse(this.txtPCurrRate.Text));
                        passportBooking.PaymentTerm = this.cboPPayment.SelectedValue.ToString();
                        passportBooking.InvoiceDate = new DateTime?(DateTime.Parse(this.dtpPInvoiceDate.Value.ToShortDateString()));
                        passportBooking.TotalNo = new int?(int.Parse((this.txtPNo.Text == "") ? "0" : this.txtPNo.Text));
                        passportBooking.TotalAmount = new decimal?(decimal.Parse((this.txtPtotalamount.Text == "") ? "0" : this.txtPtotalamount.Text));
                        passportBooking.Remark = this.txtPRemark.Text;
                        passportBooking.MMKBalance = new decimal?(this.CalculateMMKAmount(Convert.ToInt32(passportBooking.Rate), Convert.ToDecimal(passportBooking.TotalAmount)));
                        passportBooking.Status = "U";
                        passportBooking.User = Utility.Utility.User;
                        passportBooking.IsDelete = new bool?(false);
                        this.entity.SaveChanges();
                        if (this.dgvPassport.Rows.Count > 0)
                        {
                            if (this.passportDeleteID.Count > 0)
                            {
                                for (int i = 0; i < this.passportDeleteID.Count; i++)
                                {
                                    PassportPerson passportPerson2 = new PassportPerson();
                                    int Id = int.Parse(this.passportDeleteID[i].ToString());
                                    passportPerson2 = (from x in this.entity.PassportPersons
                                                       where x.ID == Id && x.IsDelete == (bool?)false
                                                       select x).FirstOrDefault<PassportPerson>();
                                    passportPerson2.IsDelete = new bool?(true);
                                    this.entity.SaveChanges();
                                }
                            }
                            for (int i = 0; i < this.dgvPassport.Rows.Count; i++)
                            {
                                if (this.dgvPassport.Rows[i].Cells["colPassID"].Value == null)
                                {
                                    PassportPerson passportPerson = new PassportPerson();
                                    passportPerson.InvoiceNo = this.txtPInvoice.Text;
                                    passportPerson.SystemDate = new DateTime?(DateTime.Now);
                                    passportPerson.Name = this.dgvPassport.Rows[i].Cells["colName"].Value.ToString();
                                    passportPerson.Charges = new decimal?(decimal.Parse(this.dgvPassport.Rows[i].Cells["colCharges"].Value.ToString()));
                                    passportPerson.Status = "B";
                                    passportPerson.User = Utility.Utility.User;
                                    passportPerson.IsDelete = new bool?(false);
                                    this.entity.AddToPassportPersons(passportPerson);
                                    this.entity.SaveChanges();
                                }
                                else
                                {
                                    PassportPerson passportPerson = new PassportPerson();
                                    int num = int.Parse(this.dgvPassport.Rows[i].Cells["colPassID"].Value.ToString());
                                    passportPerson.InvoiceNo = this.txtPInvoice.Text;
                                    passportPerson.SystemDate = new DateTime?(DateTime.Now);
                                    passportPerson.Name = this.dgvPassport.Rows[i].Cells["colName"].Value.ToString();
                                    passportPerson.Charges = new decimal?(decimal.Parse(this.dgvPassport.Rows[i].Cells["colCharges"].Value.ToString()));
                                    passportPerson.User = Utility.Utility.User;
                                    passportPerson.Status = "U";
                                    passportPerson.IsDelete = new bool?(false);
                                    this.entity.SaveChanges();
                                }
                            }
                        }
                        List<ServicesOrRequirement> list = new List<ServicesOrRequirement>();
                        ServicesOrRequirement servicesOrRequirement = new ServicesOrRequirement();
                        RequireLetter requireLetter = new RequireLetter();
                        list = (from x in this.entity.ServicesOrRequirement
                                where x.InvoiceNo == this.txtPInvoice.Text && x.Transaction == "Passport"
                                select x).ToList<ServicesOrRequirement>();
                        for (int i = 0; i < list.Count; i++)
                        {
                            int id = list[i].ID;
                            servicesOrRequirement = new ServicesOrRequirement();
                            servicesOrRequirement = (from x in this.entity.ServicesOrRequirement
                                                     where x.ID == id
                                                     select x).FirstOrDefault<ServicesOrRequirement>();
                            this.entity.ServicesOrRequirement.DeleteObject(servicesOrRequirement);
                            this.entity.SaveChanges();
                        }
                        foreach (object obj2 in this.chkRequirement.CheckedItems)
                        {
                            string text = (string)obj2;
                            string services = text.ToString();
                            requireLetter = (from x in this.entity.RequireLetter
                                             where x.Description == services && x.IsDelete == (bool?)false
                                             select x).FirstOrDefault<RequireLetter>();
                            servicesOrRequirement = new ServicesOrRequirement();
                            servicesOrRequirement.CreatedDate = new DateTime?(DateTime.Now);
                            servicesOrRequirement.Code = requireLetter.Code;
                            servicesOrRequirement.Description = requireLetter.Description;
                            servicesOrRequirement.InvoiceNo = this.txtPInvoice.Text;
                            servicesOrRequirement.Transaction = "Passport";
                            servicesOrRequirement.User = Utility.Utility.User;
                            this.entity.AddToServicesOrRequirement(servicesOrRequirement);
                            this.entity.SaveChanges();
                        }
                        MessageBox.Show("Update Successful!", "Successful", MessageBoxButtons.OK);
                    }
                    else if (this.btnPSave.Text == "Issue")
                    {
                        string invoice = this.txtPInvoice.Text;
                        PassportBooking passportBooking = new PassportBooking();
                        passportBooking = (from x in this.entity.PassportBookings
                                           where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                                           select x).FirstOrDefault<PassportBooking>();
                        passportBooking.InvoiceNo = this.txtPInvoice.Text;
                        passportBooking.SystemDate = new DateTime?(DateTime.Now);
                        passportBooking.ContactPerson = this.txtPContactPerson.Text;
                        passportBooking.ContactPhone = this.txtPContactPhone.Text;
                        passportBooking.Currency = this.cboPCurrency.SelectedValue.ToString();
                        passportBooking.Type = this.cboPType.SelectedItem.ToString();
                        passportBooking.Rate = new decimal?(int.Parse(this.txtPCurrRate.Text));
                        passportBooking.PaymentTerm = this.cboPPayment.SelectedValue.ToString();
                        passportBooking.InvoiceDate = new DateTime?(DateTime.Parse(this.dtpPInvoiceDate.Value.ToShortDateString()));
                        passportBooking.TotalNo = new int?(int.Parse((this.txtPNo.Text == "") ? "0" : this.txtPNo.Text));
                        passportBooking.TotalAmount = new decimal?(decimal.Parse((this.txtPtotalamount.Text == "") ? "0" : this.txtPtotalamount.Text));
                        passportBooking.Remark = this.txtPRemark.Text;
                        passportBooking.MMKBalance = new decimal?(this.CalculateMMKAmount(Convert.ToInt32(passportBooking.Rate), Convert.ToDecimal(passportBooking.TotalAmount)));
                        passportBooking.Status = "I";
                        passportBooking.User = Utility.Utility.User;
                        passportBooking.IsDelete = new bool?(false);
                        this.entity.SaveChanges();
                        MessageBox.Show("Confirm Successful!", "Successful", MessageBoxButtons.OK);
                        this.btnPPreview_Click(sender, e);
                    }
                    this.passportDeleteID = new List<int>();
                    this.CleanPassportBooking();
                    this.LoadPassportBookingList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please fill information!", "Incomplete Information");
            }
        }

        // Token: 0x06000E84 RID: 3716 RVA: 0x000A40D8 File Offset: 0x000A22D8
        private void btnPCancel_Click(object sender, EventArgs e)
        {
            this.CleanPassportBooking();
        }

        // Token: 0x06000E85 RID: 3717 RVA: 0x000A40E2 File Offset: 0x000A22E2
        private void chkRequirement_MouseLeave(object sender, EventArgs e)
        {
            this.chkRequirement.Visible = false;
        }

        // Token: 0x06000E86 RID: 3718 RVA: 0x000A40F4 File Offset: 0x000A22F4
        private void txtPContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPContactPhone.Focus();
            }
        }

        // Token: 0x06000E87 RID: 3719 RVA: 0x000A4124 File Offset: 0x000A2324
        private void txtPContactPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cboPPayment.Focus();
            }
        }

        // Token: 0x06000E88 RID: 3720 RVA: 0x000A4154 File Offset: 0x000A2354
        private void cboPPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbopIncomeType.Focus();
            }
        }

        // Token: 0x06000E89 RID: 3721 RVA: 0x000A4184 File Offset: 0x000A2384
        private void dtpPInvoiceDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cboPType.Focus();
            }
        }

        // Token: 0x06000E8A RID: 3722 RVA: 0x000A41BC File Offset: 0x000A23BC
        private void cboPType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.chkRequirement.Items.Clear();
                List<RequireLetter> list = new List<RequireLetter>();
                string type = this.cboPType.SelectedItem.ToString();
                list = (from x in this.entity.RequireLetter
                        where x.IsDelete == (bool?)false && (x.Type == type || x.Type == "Both")
                        select x).ToList<RequireLetter>();
                foreach (RequireLetter requireLetter in list)
                {
                    this.chkRequirement.Items.Add(requireLetter.Description);
                }
                this.cboPCurrency.Focus();
            }
        }

        // Token: 0x06000E8B RID: 3723 RVA: 0x000A438C File Offset: 0x000A258C
        private void cboPCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Currency = this.cboPCurrency.Text;
                Currency currency = new Currency();
                currency = (from x in this.entity.Currencies
                            where x.Code == Currency && x.IsDelete == (bool?)false
                            select x).FirstOrDefault<Currency>();
                this.txtPCurrRate.Text = currency.Rate.ToString();
                this.txtPCurrRate.Focus();
            }
        }

        // Token: 0x06000E8C RID: 3724 RVA: 0x000A44BC File Offset: 0x000A26BC
        private void txtPCurrRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtpSupplier.Focus();
            }
        }

        // Token: 0x06000E8D RID: 3725 RVA: 0x000A44EC File Offset: 0x000A26EC
        private void txtPRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPName.Focus();
            }
        }

        // Token: 0x06000E8E RID: 3726 RVA: 0x000A451C File Offset: 0x000A271C
        private void txtPName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtCharges.Focus();
            }
        }

        // Token: 0x06000E8F RID: 3727 RVA: 0x000A454C File Offset: 0x000A274C
        private void dtpPBirthDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
        }

        // Token: 0x06000E90 RID: 3728 RVA: 0x000A4570 File Offset: 0x000A2770
        private void txtPNRC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
        }

        // Token: 0x06000E91 RID: 3729 RVA: 0x000A4594 File Offset: 0x000A2794
        private void txtPPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
        }

        // Token: 0x06000E92 RID: 3730 RVA: 0x000A45B8 File Offset: 0x000A27B8
        private void btnPRequirement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnPRequirement_Click(sender, e);
            }
        }

        // Token: 0x06000E93 RID: 3731 RVA: 0x000A45E4 File Offset: 0x000A27E4
        private void txtPAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtCharges.Focus();
            }
        }

        // Token: 0x06000E94 RID: 3732 RVA: 0x000A4614 File Offset: 0x000A2814
        private void txtCharges_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnPassportAdd_Click(sender, e);
            }
        }

        // Token: 0x06000E95 RID: 3733 RVA: 0x000A4640 File Offset: 0x000A2840
        private void CheckUserRule()
        {
            if (!Utility.Utility.AirTicket_New)
            {
                this.btnTravelnTour.Enabled = false;
                this.btnTravelnTour.BackColor = Color.LightGray;
            }
            if (!Utility.Utility.Hotel_New)
            {
                this.btnHotelReserve.Enabled = false;
                this.btnHotelReserve.BackColor = Color.LightGray;
            }
            if (!Utility.Utility.Tour_New)
            {
                this.btnTourPackage.Enabled = false;
                this.btnTourPackage.BackColor = Color.LightGray;
            }
            if (!Utility.Utility.Passport_New)
            {
                this.btnPassport.Enabled = false;
                this.btnPassport.BackColor = Color.LightGray;
            }
            if (!Utility.Utility.Carrental_New)
            {
                this.btnCarRental.Enabled = false;
                this.btnCarRental.BackColor = Color.LightGray;
            }
            if (!Utility.Utility.CashReceive)
            {
                this.btnCreditList.Enabled = false;
                this.btnCreditList.BackColor = Color.LightGray;
            }
        }

        // Token: 0x06000E96 RID: 3734 RVA: 0x000A4744 File Offset: 0x000A2944
        private void btnCarRental_Click(object sender, EventArgs e)
        {
            this.pnlCarRental.Visible = true;
            this.pnlCarRental.Left = 160;
            this.pnlCarRental.Width = 1210;
            this.pnlCarRental.Height = 722;
            this.pnlTravel.Visible = false;
            this.pnlHotelBooking.Visible = false;
            this.pnlCredit.Visible = false;
            this.pnlTourPackage.Visible = false;
            this.pnlPassport.Visible = false;
            this.CleanCarRentalBooking();
            this.LoadCarRentalBookingList();
            this.txtcContactPerson.Focus();
        }

        // Token: 0x06000E97 RID: 3735 RVA: 0x000A47F0 File Offset: 0x000A29F0
        private void pnlCarRental_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
            Brush brush = new LinearGradientBrush(rect, Color.LightSteelBlue, Color.RoyalBlue, 90f);
            graphics.FillRectangle(brush, rect);
        }

        // Token: 0x06000E98 RID: 3736 RVA: 0x000A483C File Offset: 0x000A2A3C
        private void pnlPassport_Paint(object sender, PaintEventArgs e)
        {
            Graphics cartype = e.Graphics;
            Rectangle peroid = new Rectangle(0, 0, base.Width, base.Height);
            Brush amount = new LinearGradientBrush(peroid, Color.BurlyWood, Color.Peru, 90f);
            cartype.FillRectangle(amount, peroid);
        }

        // Token: 0x06000E99 RID: 3737 RVA: 0x000A4886 File Offset: 0x000A2A86
        private void groupBox11_Enter(object sender, EventArgs e)
        {
        }

        // Token: 0x06000E9A RID: 3738 RVA: 0x000A488C File Offset: 0x000A2A8C
        private void btncAdd_Click(object sender, EventArgs e)
        {
            string text = this.cbocCarType.Text.ToString();
            string text2 = this.cbocPeroid.Text.ToString();
            decimal num = decimal.Parse((this.txtcAmount.Text == "") ? "0" : this.txtcAmount.Text);
            string text3 = this.txtcCarNo.Text;
            this.dgvCarRental.Rows.Add(new object[]
			{
				text,
				text2,
				num,
				text3
			});
            this.CalculateCarRentalAmount();
            this.cbocCarType.SelectedIndex = 0;
            this.cbocPeroid.SelectedIndex = 0;
            this.txtcAmount.Text = "0";
            this.txtcCarNo.Text = "";
            this.cbocCarType.Focus();
        }

        // Token: 0x06000E9B RID: 3739 RVA: 0x000A49A8 File Offset: 0x000A2BA8
        private void btnCBooking_Click(object sender, EventArgs e)
        {
            if (this.CarRentalIsValid())
            {
                try
                {
                    if (this.btnCBooking.Text == "Booking")
                    {
                        CarRentalBooking DS = new CarRentalBooking();
                        DS.InvoiceNo = this.txtcInvoiceNo.Text;
                        DS.SystemDate = new DateTime?(DateTime.Now);
                        DS.ContactPerson = this.txtcContactPerson.Text;
                        DS.CompanyName = this.txtcCompanyName.Text;
                        DS.ContactPhone = this.txtcContactPhone.Text;
                        DS.Currency = this.cbocCurrency.SelectedValue.ToString();
                        DS.Rate = new decimal?(int.Parse(this.txtcRate.Text));
                        DS.PaymentTerm = this.cbocPayment.SelectedValue.ToString();
                        DS.Address = this.txtcAddress.Text;
                        DS.Email = this.txtcEmail.Text;
                        DS.t1 = this.cbocIncomeType.SelectedValue.ToString();
                        DS.t2 = this.txtcSupplier.Text;
                        DS.InvoiceDate = new DateTime?(DateTime.Parse(this.dtpcInvoiceDate.Value.ToShortDateString()));
                        DS.DepatureDate = new DateTime?(DateTime.Parse(this.dtpcDepatureDate.Value.ToShortDateString()));
                        DS.ArrivalDate = new DateTime?(DateTime.Parse(this.dtpcArrivalDate.Value.ToShortDateString()));
                        DS.TotalAmount = new decimal?(decimal.Parse((this.txtcTotalAmount.Text == "") ? "0" : this.txtcTotalAmount.Text));
                        DS.ExtraCharges = new decimal?(decimal.Parse((this.txtcExtraCharges.Text == "") ? "0" : this.txtcExtraCharges.Text));
                        DS.Balance = new decimal?(decimal.Parse((this.txtcBalance.Text == "") ? "0" : this.txtcBalance.Text));
                        DS.Remark = this.txtcRemark.Text;
                        DS.Status = "B";
                        DS.User = Utility.Utility.User;
                        DS.IsDelete = new bool?(false);
                        this.entity.AddToCarRentalBooking(DS);
                        this.entity.SaveChanges();
                        if (this.dgvCarRental.Rows.Count > 0)
                        {
                            for (int tb = 0; tb < this.dgvCarRental.Rows.Count; tb++)
                            {
                                CarRentalDetail tf = new CarRentalDetail();
                                tf.InvoiceNo = this.txtcInvoiceNo.Text;
                                tf.SystemDate = new DateTime?(DateTime.Now);
                                tf.CarType = this.dgvCarRental.Rows[tb].Cells["colCarType"].Value.ToString();
                                tf.Peroid = this.dgvCarRental.Rows[tb].Cells["colPeroid"].Value.ToString();
                                tf.CarNo = this.dgvCarRental.Rows[tb].Cells["colCarNo"].Value.ToString();
                                tf.Amount = new decimal?(decimal.Parse(this.dgvCarRental.Rows[tb].Cells["colcAmount"].Value.ToString()));
                                tf.Status = "B";
                                tf.User = Utility.Utility.User;
                                tf.IsDelete = new bool?(false);
                                this.entity.AddToCarRentalDetail(tf);
                                this.entity.SaveChanges();
                            }
                        }
                        MessageBox.Show("Booking Successful!", "Successful", MessageBoxButtons.OK);
                    }
                    else if (this.btnCBooking.Text == "Update")
                    {
                        string invoice = this.txtcInvoiceNo.Text;
                        CarRentalBooking DS = new CarRentalBooking();
                        DS = (from x in this.entity.CarRentalBooking
                              where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                              select x).FirstOrDefault<CarRentalBooking>();
                        DS.InvoiceNo = this.txtcInvoiceNo.Text;
                        DS.SystemDate = new DateTime?(DateTime.Now);
                        DS.ContactPerson = this.txtcContactPerson.Text;
                        DS.CompanyName = this.txtcCompanyName.Text;
                        DS.ContactPhone = this.txtcContactPhone.Text;
                        DS.Currency = this.cbocCurrency.SelectedValue.ToString();
                        DS.Rate = new decimal?(int.Parse(this.txtcRate.Text));
                        DS.PaymentTerm = this.cbocPayment.SelectedValue.ToString();
                        DS.Address = this.txtcAddress.Text;
                        DS.Email = this.txtcEmail.Text;
                        DS.t1 = this.cbocIncomeType.SelectedValue.ToString();
                        DS.t2 = this.txtcSupplier.Text;
                        DS.InvoiceDate = new DateTime?(DateTime.Parse(this.dtpcInvoiceDate.Value.ToShortDateString()));
                        DS.DepatureDate = new DateTime?(DateTime.Parse(this.dtpcDepatureDate.Value.ToShortDateString()));
                        DS.ArrivalDate = new DateTime?(DateTime.Parse(this.dtpcArrivalDate.Value.ToShortDateString()));
                        DS.TotalAmount = new decimal?(decimal.Parse((this.txtcTotalAmount.Text == "") ? "0" : this.txtcTotalAmount.Text));
                        DS.ExtraCharges = new decimal?(decimal.Parse((this.txtcExtraCharges.Text == "") ? "0" : this.txtcExtraCharges.Text));
                        DS.Balance = new decimal?(decimal.Parse((this.txtcBalance.Text == "") ? "0" : this.txtcBalance.Text));
                        DS.Remark = this.txtcRemark.Text;
                        DS.Status = "U";
                        DS.User = Utility.Utility.User;
                        DS.IsDelete = new bool?(false);
                        this.entity.SaveChanges();
                        if (this.dgvCarRental.Rows.Count > 0)
                        {
                            if (this.carrentalDeleteID.Count > 0)
                            {
                                for (int tb = 0; tb < this.carrentalDeleteID.Count; tb++)
                                {
                                    CarRentalDetail table = new CarRentalDetail();
                                    int Id = int.Parse(this.carrentalDeleteID[tb].ToString());
                                    table = (from x in this.entity.CarRentalDetail
                                             where x.ID == Id && x.IsDelete == (bool?)false
                                             select x).FirstOrDefault<CarRentalDetail>();
                                    table.IsDelete = new bool?(true);
                                    this.entity.SaveChanges();
                                }
                            }
                            for (int tb = 0; tb < this.dgvCarRental.Rows.Count; tb++)
                            {
                                if (this.dgvCarRental.Rows[tb].Cells["colcID"].Value == null)
                                {
                                    CarRentalDetail tf = new CarRentalDetail();
                                    tf.InvoiceNo = this.txtcInvoiceNo.Text;
                                    tf.SystemDate = new DateTime?(DateTime.Now);
                                    tf.CarType = this.dgvCarRental.Rows[tb].Cells["colCarType"].Value.ToString();
                                    tf.Peroid = this.dgvCarRental.Rows[tb].Cells["colPeroid"].Value.ToString();
                                    tf.CarNo = this.dgvCarRental.Rows[tb].Cells["colCarNo"].Value.ToString();
                                    tf.Amount = new decimal?(decimal.Parse(this.dgvCarRental.Rows[tb].Cells["colcAmount"].Value.ToString()));
                                    tf.Status = "B";
                                    tf.User = Utility.Utility.User;
                                    tf.IsDelete = new bool?(false);
                                    this.entity.AddToCarRentalDetail(tf);
                                    this.entity.SaveChanges();
                                }
                                else
                                {
                                    CarRentalDetail tf = new CarRentalDetail();
                                    int Id = int.Parse(this.dgvCarRental.Rows[tb].Cells["colcID"].Value.ToString());
                                    tf = (from x in this.entity.CarRentalDetail
                                          where x.ID == Id && x.IsDelete == (bool?)false
                                          select x).FirstOrDefault<CarRentalDetail>();
                                    tf.InvoiceNo = this.txtcInvoiceNo.Text;
                                    tf.SystemDate = new DateTime?(DateTime.Now);
                                    tf.CarType = this.dgvCarRental.Rows[tb].Cells["colCarType"].Value.ToString();
                                    tf.Peroid = this.dgvCarRental.Rows[tb].Cells["colPeroid"].Value.ToString();
                                    tf.CarNo = this.dgvCarRental.Rows[tb].Cells["colCarNo"].Value.ToString();
                                    tf.Amount = new decimal?(decimal.Parse(this.dgvCarRental.Rows[tb].Cells["colcAmount"].Value.ToString()));
                                    tf.User = Utility.Utility.User;
                                    tf.Status = "U";
                                    tf.IsDelete = new bool?(false);
                                    this.entity.SaveChanges();
                                }
                            }
                        }
                        MessageBox.Show("Update Successful!", "Successful", MessageBoxButtons.OK);
                    }
                    else if (this.btnCBooking.Text == "Issue")
                    {
                        string invoice = this.txtcInvoiceNo.Text;
                        CarRentalBooking DS = new CarRentalBooking();
                        DS = (from x in this.entity.CarRentalBooking
                              where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                              select x).FirstOrDefault<CarRentalBooking>();
                        DS.InvoiceNo = this.txtcInvoiceNo.Text;
                        DS.SystemDate = new DateTime?(DateTime.Now);
                        DS.ContactPerson = this.txtcContactPerson.Text;
                        DS.CompanyName = this.txtcCompanyName.Text;
                        DS.ContactPhone = this.txtcContactPhone.Text;
                        DS.Currency = this.cbocCurrency.SelectedValue.ToString();
                        DS.Rate = new decimal?(int.Parse(this.txtcRate.Text));
                        DS.PaymentTerm = this.cbocPayment.SelectedValue.ToString();
                        DS.Address = this.txtcAddress.Text;
                        DS.Email = this.txtcEmail.Text;
                        DS.t1 = this.cbocIncomeType.SelectedValue.ToString();
                        DS.t2 = this.txtcSupplier.Text;
                        DS.InvoiceDate = new DateTime?(DateTime.Parse(this.dtpcInvoiceDate.Value.ToShortDateString()));
                        DS.DepatureDate = new DateTime?(DateTime.Parse(this.dtpcDepatureDate.Value.ToShortDateString()));
                        DS.ArrivalDate = new DateTime?(DateTime.Parse(this.dtpcArrivalDate.Value.ToShortDateString()));
                        DS.TotalAmount = new decimal?(decimal.Parse((this.txtcTotalAmount.Text == "") ? "0" : this.txtcTotalAmount.Text));
                        DS.ExtraCharges = new decimal?(decimal.Parse((this.txtcExtraCharges.Text == "") ? "0" : this.txtcExtraCharges.Text));
                        DS.Balance = new decimal?(decimal.Parse((this.txtcBalance.Text == "") ? "0" : this.txtcBalance.Text));
                        DS.Remark = this.txtcRemark.Text;
                        DS.Status = "I";
                        DS.User = Utility.Utility.User;
                        DS.IsDelete = new bool?(false);
                        this.entity.SaveChanges();
                        MessageBox.Show("Confirm Successful!", "Successful", MessageBoxButtons.OK);
                        this.btncPreview_Click(sender, e);
                    }
                    this.carrentalDeleteID = new List<int>();
                    this.CleanCarRentalBooking();
                    this.LoadCarRentalBookingList();
                }
                catch (Exception i)
                {
                    MessageBox.Show(i.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please fill information!", "Incomplete Information");
            }
        }

        // Token: 0x06000E9C RID: 3740 RVA: 0x000A59E0 File Offset: 0x000A3BE0
        private void btncCancel_Click(object sender, EventArgs e)
        {
            this.CleanCarRentalBooking();
        }

        // Token: 0x06000E9D RID: 3741 RVA: 0x000A59F4 File Offset: 0x000A3BF4
        private void btncPreview_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            List<PassportBooking> list = new List<PassportBooking>();
            List<PassportPerson> list2 = new List<PassportPerson>();
            DataTable dataTable = new DataTable("CarRentalHeader");
            dataTable.Columns.Add(new DataColumn("InvoiceDate", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("ArrivalDate", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("DepatureDate", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
            dataTable.Columns.Add(new DataColumn("ContactPerson", typeof(string)));
            dataTable.Columns.Add(new DataColumn("ContactPhone", typeof(string)));
            dataTable.Columns.Add(new DataColumn("CompanyName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Email", typeof(string)));
            dataTable.Columns.Add(new DataColumn("t1", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Address", typeof(string)));
            dataTable.Columns.Add(new DataColumn("PaymentTerm", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Currency", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Rate", typeof(int)));
            dataTable.Columns.Add(new DataColumn("ExtraCharges", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("TotalAmount", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Balance", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("User", typeof(string)));
            DataRow dataRow = dataTable.NewRow();
            dataRow["InvoiceNo"] = this.txtcInvoiceNo.Text;
            dataRow["InvoiceDate"] = this.dtpcInvoiceDate.Value;
            dataRow["ArrivalDate"] = this.dtpcArrivalDate.Value;
            dataRow["DepatureDate"] = this.dtpcDepatureDate.Value;
            dataRow["ContactPerson"] = this.txtcContactPerson.Text;
            dataRow["ContactPhone"] = this.txtcContactPhone.Text;
            dataRow["CompanyName"] = this.txtcCompanyName.Text;
            dataRow["Email"] = this.txtcEmail.Text;
            dataRow["t1"] = this.cbocIncomeType.SelectedValue.ToString();
            dataRow["Address"] = this.txtcAddress.Text;
            string p = this.cbocPayment.SelectedValue.ToString();
            PaymentTerm paymentTerm = new PaymentTerm();
            paymentTerm = (from x in this.entity.PaymentTerms
                           where x.Code == p && x.IsDelete == (bool?)false
                           select x).FirstOrDefault<PaymentTerm>();
            dataRow["PaymentTerm"] = paymentTerm.Description;
            dataRow["Currency"] = this.cbocCurrency.Text;
            dataRow["Rate"] = this.txtcRate.Text;
            dataRow["ExtraCharges"] = decimal.Parse(this.txtcExtraCharges.Text);
            dataRow["TotalAmount"] = decimal.Parse(this.txtcTotalAmount.Text);
            dataRow["Balance"] = decimal.Parse(this.txtcBalance.Text);
            dataRow["Remark"] = this.txtcRemark.Text;
            string user = Utility.Utility.Staff;
            Staff staff = new Staff();
            staff = (from x in this.entity.Staffs
                     where x.Code == user && x.IsDelete == (bool?)false
                     select x).FirstOrDefault<Staff>();
            dataRow["User"] = Utility.Utility.Staff;
            dataTable.Rows.Add(dataRow);
            DataTable dataTable2 = new DataTable("CarRentalDetail");
            dataTable2.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("CarType", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("Reroid", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("Amount", typeof(decimal)));
            dataTable2.Columns.Add(new DataColumn("CarNo", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("Status", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("User", typeof(string)));
            if (this.dgvCarRental.Rows.Count > 0)
            {
                for (int i = 0; i < this.dgvCarRental.Rows.Count; i++)
                {
                    DataRow dataRow2 = dataTable2.NewRow();
                    dataRow2["InvoiceNo"] = this.txtcInvoiceNo.Text;
                    dataRow2["CarType"] = this.dgvCarRental.Rows[i].Cells["colCarType"].Value.ToString();
                    dataRow2["Reroid"] = this.dgvCarRental.Rows[i].Cells["colPeroid"].Value.ToString();
                    dataRow2["Amount"] = this.dgvCarRental.Rows[i].Cells["colcAmount"].Value.ToString();
                    dataRow2["CarNo"] = this.dgvCarRental.Rows[i].Cells["colCarNo"].Value.ToString();
                    dataTable2.Rows.Add(dataRow2);
                }
            }
            dataSet.Tables.Add(dataTable);
            dataSet.Tables.Add(dataTable2);
            ReportDocument reportDocument = new ReportDocument();
            dataSet.WriteXmlSchema(Application.StartupPath + "\\DataSets\\NobelMoon.xsd");
            reportDocument.Load(Application.StartupPath + "\\Reports\\CarRentalInvoice.rpt");
            reportDocument.SetDataSource(dataSet);
            frmReport frmReport = new frmReport();
            frmReport.reportViewer1.ReportSource = reportDocument;
            frmReport.reportViewer1.Refresh();
            frmReport.Show();
            base.UseWaitCursor = false;
        }

        // Token: 0x06000E9E RID: 3742 RVA: 0x000A62BC File Offset: 0x000A44BC
        private void dgvCarRental_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (this.dgvCarRental.CurrentRow.Cells["colcID"].Value != null)
                {
                    this.carrentalDeleteID.Add(int.Parse(this.dgvCarRental.CurrentRow.Cells["colcID"].Value.ToString()));
                }
                decimal d = decimal.Parse(this.dgvCarRental.CurrentRow.Cells["colcAmount"].Value.ToString());
                this.dgvCarRental.Rows.Remove(this.dgvCarRental.CurrentRow);
                decimal d2 = decimal.Parse((this.txtcExtraCharges.Text == "") ? "0" : this.txtcExtraCharges.Text);
                decimal d3 = decimal.Parse((this.txtcTotalAmount.Text == "") ? "0" : this.txtcTotalAmount.Text);
                this.txtcTotalAmount.Text = (d3 - d).ToString();
                this.txtcBalance.Text = (d3 - d - d2).ToString();
            }
        }

        // Token: 0x06000E9F RID: 3743 RVA: 0x000A6420 File Offset: 0x000A4620
        private void txtcInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtcContactPerson.Focus();
            }
        }

        // Token: 0x06000EA0 RID: 3744 RVA: 0x000A6450 File Offset: 0x000A4650
        private void txtcContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtcContactPhone.Focus();
            }
        }

        // Token: 0x06000EA1 RID: 3745 RVA: 0x000A6480 File Offset: 0x000A4680
        private void txtcContactPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtcCompanyName.Focus();
            }
        }

        // Token: 0x06000EA2 RID: 3746 RVA: 0x000A64B0 File Offset: 0x000A46B0
        private void txtcCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtcEmail.Focus();
            }
        }

        // Token: 0x06000EA3 RID: 3747 RVA: 0x000A64E0 File Offset: 0x000A46E0
        private void txtcEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtcAddress.Focus();
            }
        }

        // Token: 0x06000EA4 RID: 3748 RVA: 0x000A6510 File Offset: 0x000A4710
        private void txtcAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtcSupplier.Focus();
            }
        }

        // Token: 0x06000EA5 RID: 3749 RVA: 0x000A6540 File Offset: 0x000A4740
        private void dtpcInvoiceDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpcDepatureDate.Focus();
            }
        }

        // Token: 0x06000EA6 RID: 3750 RVA: 0x000A6570 File Offset: 0x000A4770
        private void dtpcDepatureDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpcArrivalDate.Focus();
            }
        }

        // Token: 0x06000EA7 RID: 3751 RVA: 0x000A65A0 File Offset: 0x000A47A0
        private void dtpcArrivalDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbocCurrency.Focus();
            }
        }

        // Token: 0x06000EA8 RID: 3752 RVA: 0x000A65D8 File Offset: 0x000A47D8
        private void cbocCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Currency = this.cbocCurrency.Text;
                Currency currency = new Currency();
                currency = (from x in this.entity.Currencies
                            where x.Code == Currency && x.IsDelete == (bool?)false
                            select x).FirstOrDefault<Currency>();
                this.txtcRate.Text = currency.Rate.ToString();
                this.txtcRate.Focus();
            }
        }

        // Token: 0x06000EA9 RID: 3753 RVA: 0x000A6708 File Offset: 0x000A4908
        private void txtcRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbocPayment.Focus();
            }
        }

        // Token: 0x06000EAA RID: 3754 RVA: 0x000A6738 File Offset: 0x000A4938
        private void cbocPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbocIncomeType.Focus();
            }
        }

        // Token: 0x06000EAB RID: 3755 RVA: 0x000A6768 File Offset: 0x000A4968
        private void txtcRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbocCarType.Focus();
            }
        }

        // Token: 0x06000EAC RID: 3756 RVA: 0x000A6798 File Offset: 0x000A4998
        private void cbocPeroid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtcAmount.Focus();
            }
        }

        // Token: 0x06000EAD RID: 3757 RVA: 0x000A67C8 File Offset: 0x000A49C8
        private void cbocCarType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbocPeroid.Focus();
            }
        }

        // Token: 0x06000EAE RID: 3758 RVA: 0x000A67F8 File Offset: 0x000A49F8
        private void txtcAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtcCarNo.Focus();
            }
        }

        // Token: 0x06000EAF RID: 3759 RVA: 0x000A6828 File Offset: 0x000A4A28
        private void txtcCarNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btncAdd_Click(sender, e);
            }
        }

        // Token: 0x06000EB0 RID: 3760 RVA: 0x000A685C File Offset: 0x000A4A5C
        private void dgvCarRentalList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    this.CleanCarRentalBooking();
                    string charges = this.dgvCarRentalList.CurrentRow.Cells[2].Value.ToString();
                    this.BindCarRentalBooking(charges);
                    this.btnCBooking.Text = "Update";
                }
                if (e.ColumnIndex == 6)
                {
                    this.CleanCarRentalBooking();
                    string charges = this.dgvCarRentalList.CurrentRow.Cells[2].Value.ToString();
                    this.BindCarRentalBooking(charges);
                    this.btnCBooking.Text = "Issue";
                    this.btnCBooking.Focus();
                }
                if (e.ColumnIndex == 7)
                {
                    string invoice = this.dgvCarRentalList.CurrentRow.Cells[2].Value.ToString();
                    if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CarRentalBooking no = new CarRentalBooking();
                        no = (from x in this.entity.CarRentalBooking
                              where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                              select x).FirstOrDefault<CarRentalBooking>();
                        if (no != null)
                        {
                            no.IsDelete = new bool?(true);
                            this.entity.SaveChanges();
                        }
                        List<CarRentalDetail> totalamount = new List<CarRentalDetail>();
                        totalamount = (from x in this.entity.CarRentalDetail
                                       where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                                       select x).ToList<CarRentalDetail>();
                        if (totalamount.Count > 0)
                        {
                            for (int i = 0; i < totalamount.Count; i++)
                            {
                                totalamount[i].IsDelete = new bool?(true);
                                this.entity.SaveChanges();
                            }
                        }
                        this.LoadCarRentalBookingList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Token: 0x06000EB1 RID: 3761 RVA: 0x000A6BD4 File Offset: 0x000A4DD4
        private void dgvPassportList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    this.CleanPassportBooking();
                    string DS = this.dgvPassportList.CurrentRow.Cells[2].Value.ToString();
                    this.BindPassportBooking(DS);
                    this.btnPSave.Text = "Update";
                }
                if (e.ColumnIndex == 7)
                {
                    this.CleanPassportBooking();
                    string DS = this.dgvPassportList.CurrentRow.Cells[2].Value.ToString();
                    this.BindPassportBooking(DS);
                    this.btnPSave.Text = "Issue";
                    this.btnPSave.Focus();
                }
                if (e.ColumnIndex == 8)
                {
                    string invoice = this.dgvPassportList.CurrentRow.Cells[2].Value.ToString();
                    if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PassportBooking tb = new PassportBooking();
                        tb = (from x in this.entity.PassportBookings
                              where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                              select x).FirstOrDefault<PassportBooking>();
                        if (tb != null)
                        {
                            tb.IsDelete = new bool?(true);
                            this.entity.SaveChanges();
                        }
                        List<PassportPerson> tf = new List<PassportPerson>();
                        tf = (from x in this.entity.PassportPersons
                              where x.InvoiceNo == invoice && x.IsDelete == (bool?)false
                              select x).ToList<PassportPerson>();
                        if (tf.Count > 0)
                        {
                            for (int table = 0; table < tf.Count; table++)
                            {
                                tf[table].IsDelete = new bool?(true);
                                this.entity.SaveChanges();
                            }
                        }
                        this.LoadPassportBookingList();
                    }
                }
            }
            catch (Exception pt)
            {
                MessageBox.Show(pt.ToString());
            }
        }

        // Token: 0x06000EB2 RID: 3762 RVA: 0x000A6F44 File Offset: 0x000A5144
        private void dgvPassport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (this.dgvPassport.CurrentRow.Cells["colPassID"].Value != null)
                {
                    this.passportDeleteID.Add(int.Parse(this.dgvPassport.CurrentRow.Cells["colPassID"].Value.ToString()));
                }
                decimal d = decimal.Parse(this.dgvPassport.CurrentRow.Cells["colCharges"].Value.ToString());
                this.dgvPassport.Rows.Remove(this.dgvPassport.CurrentRow);
                int num = int.Parse((this.txtPNo.Text == "") ? "0" : this.txtPNo.Text);
                decimal d2 = decimal.Parse((this.txtPtotalamount.Text == "") ? "0" : this.txtPtotalamount.Text);
                this.txtPNo.Text = (num - 1).ToString();
                this.txtPtotalamount.Text = (d2 - d).ToString();
            }
        }

        // Token: 0x06000EB3 RID: 3763 RVA: 0x000A70A4 File Offset: 0x000A52A4
        private void btnPPreview_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            List<PassportBooking> list = new List<PassportBooking>();
            List<PassportPerson> list2 = new List<PassportPerson>();
            DataTable dataTable = new DataTable("PassporBooking");
            dataTable.Columns.Add(new DataColumn("InvoiceDate", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
            dataTable.Columns.Add(new DataColumn("ContactPerson", typeof(string)));
            dataTable.Columns.Add(new DataColumn("ContactPhone", typeof(string)));
            dataTable.Columns.Add(new DataColumn("PaymentTerm", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Currency", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Rate", typeof(int)));
            dataTable.Columns.Add(new DataColumn("TotalNo", typeof(int)));
            dataTable.Columns.Add(new DataColumn("TotalAmount", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
            dataTable.Columns.Add(new DataColumn("t1", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
            dataTable.Columns.Add(new DataColumn("User", typeof(string)));
            DataRow dataRow = dataTable.NewRow();
            dataRow["InvoiceNo"] = this.txtPInvoice.Text;
            dataRow["InvoiceDate"] = this.dtpPInvoiceDate.Value;
            dataRow["ContactPerson"] = this.txtPContactPerson.Text;
            dataRow["ContactPhone"] = this.txtPContactPhone.Text;
            string p = this.cboPPayment.SelectedValue.ToString();
            PaymentTerm paymentTerm = new PaymentTerm();
            paymentTerm = (from x in this.entity.PaymentTerms
                           where x.Code == p && x.IsDelete == (bool?)false
                           select x).FirstOrDefault<PaymentTerm>();
            dataRow["PaymentTerm"] = paymentTerm.Description;
            dataRow["Currency"] = this.cboPCurrency.Text;
            dataRow["Rate"] = this.txtPCurrRate.Text;
            dataRow["TotalNo"] = int.Parse(this.txtPNo.Text);
            dataRow["TotalAmount"] = decimal.Parse(this.txtPtotalamount.Text);
            dataRow["Remark"] = this.txtPRemark.Text;
            dataRow["t1"] = this.cbopIncomeType.SelectedValue.ToString();
            string user = Utility.Utility.Staff;
            Staff staff = new Staff();
            staff = (from x in this.entity.Staffs
                     where x.Code == user && x.IsDelete == (bool?)false
                     select x).FirstOrDefault<Staff>();
            dataRow["Type"] = this.cboPType.SelectedItem.ToString();
            dataRow["User"] = Utility.Utility.Staff;
            dataTable.Rows.Add(dataRow);
            DataTable dataTable2 = new DataTable("PassportPerson");
            dataTable2.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("Name", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("DOB", typeof(DateTime)));
            dataTable2.Columns.Add(new DataColumn("NRC", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("Phone", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("Requirements", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("Address", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("Charges", typeof(decimal)));
            dataTable2.Columns.Add(new DataColumn("User", typeof(string)));
            if (this.dgvPassport.Rows.Count > 0)
            {
                for (int i = 0; i < this.dgvPassport.Rows.Count; i++)
                {
                    DataRow dataRow2 = dataTable2.NewRow();
                    dataRow2["InvoiceNo"] = this.txtPInvoice.Text;
                    dataRow2["Name"] = this.dgvPassport.Rows[i].Cells["colName"].Value.ToString();
                    dataRow2["Charges"] = this.dgvPassport.Rows[i].Cells["colCharges"].Value.ToString();
                    dataTable2.Rows.Add(dataRow2);
                }
            }
            DataTable dataTable3 = new DataTable("ServicesOrRequirements");
            dataTable3.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
            dataTable3.Columns.Add(new DataColumn("Transaction", typeof(string)));
            dataTable3.Columns.Add(new DataColumn("Description", typeof(string)));
            dataTable3.Columns.Add(new DataColumn("User", typeof(string)));
            if (this.chkRequirement.CheckedItems.Count > 0)
            {
                for (int i = 0; i < this.chkRequirement.CheckedItems.Count; i++)
                {
                    DataRow dataRow3 = dataTable3.NewRow();
                    dataRow3["InvoiceNo"] = this.txtPInvoice.Text;
                    dataRow3["Transaction"] = "Hotel";
                    dataRow3["Description"] = this.chkRequirement.CheckedItems[i].ToString();
                    dataRow3["User"] = Utility.Utility.Staff;
                    dataTable3.Rows.Add(dataRow3);
                }
            }
            dataSet.Tables.Add(dataTable);
            dataSet.Tables.Add(dataTable2);
            dataSet.Tables.Add(dataTable3);
            ReportDocument reportDocument = new ReportDocument();
            dataSet.WriteXmlSchema(Application.StartupPath + "\\DataSets\\NobelMoon.xsd");
            reportDocument.Load(Application.StartupPath + "\\Reports\\PassportInvoice.rpt");
            reportDocument.SetDataSource(dataSet);
            frmReport frmReport = new frmReport();
            frmReport.reportViewer1.ReportSource = reportDocument;
            frmReport.reportViewer1.Refresh();
            frmReport.Show();
            base.UseWaitCursor = false;
        }

        // Token: 0x06000EB4 RID: 3764 RVA: 0x000A797C File Offset: 0x000A5B7C
        private void btnOtherService_Click(object sender, EventArgs e)
        {
            if (!this.chkOtherService.Visible)
            {
                this.chkOtherService.Visible = true;
            }
            else
            {
                this.chkOtherService.Visible = false;
            }
        }

        // Token: 0x06000EB5 RID: 3765 RVA: 0x000A79B7 File Offset: 0x000A5BB7
        private void chkOtherService_MouseLeave(object sender, EventArgs e)
        {
            this.chkOtherService.Visible = false;
        }

        // Token: 0x06000EB6 RID: 3766 RVA: 0x000A79C7 File Offset: 0x000A5BC7
        private void dgvHotelBooking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // Token: 0x06000EB7 RID: 3767 RVA: 0x000A79CA File Offset: 0x000A5BCA
        private void groupBox8_Enter(object sender, EventArgs e)
        {
        }

        // Token: 0x06000EB8 RID: 3768 RVA: 0x000A79CD File Offset: 0x000A5BCD
        private void chkRequirement_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // Token: 0x06000EB9 RID: 3769 RVA: 0x000A79D0 File Offset: 0x000A5BD0
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dgvPassportList.Rows.Clear();
                List<PassportBooking> list = new List<PassportBooking>();
                list = (from x in this.entity.PassportBookings
                        where x.IsDelete == (bool?)false && x.Status != "I" && (x.ContactPerson.Contains(this.txtPSearch.Text) || x.InvoiceNo.Contains(this.txtPSearch.Text))
                        select x).ToList<PassportBooking>();
                for (int i = 0; i < list.Count; i++)
                {
                    this.dgvPassportList.Rows.Add(new object[]
					{
						i + 1,
						list[i].InvoiceDate.Value.ToShortDateString(),
						list[i].InvoiceNo,
						list[i].ContactPerson
					});
                }
            }
        }

        // Token: 0x06000EBA RID: 3770 RVA: 0x000A7C34 File Offset: 0x000A5E34
        private void txtcSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dgvCarRentalList.Rows.Clear();
                List<CarRentalBooking> list = new List<CarRentalBooking>();
                list = (from x in this.entity.CarRentalBooking
                        where x.IsDelete == (bool?)false && x.Status != "I" && (x.ContactPerson.Contains(this.txtcSearch.Text) || x.InvoiceNo.Contains(this.txtcSearch.Text))
                        select x).ToList<CarRentalBooking>();
                for (int i = 0; i < list.Count; i++)
                {
                    this.dgvCarRentalList.Rows.Add(new object[]
					{
						i + 1,
						list[i].InvoiceDate.Value.ToShortDateString(),
						list[i].InvoiceNo,
						list[i].CompanyName,
						list[i].ContactPerson
					});
                }
            }
        }

        // Token: 0x06000EBB RID: 3771 RVA: 0x000A7EAC File Offset: 0x000A60AC
        private void txtcExtraCharges_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.CalculateCarRentalAmount();
            }
        }

        // Token: 0x06000EBC RID: 3772 RVA: 0x000A7ED4 File Offset: 0x000A60D4
        private void btnhOtherServices_Click(object sender, EventArgs e)
        {
            if (!this.chkhOtherServices.Visible)
            {
                this.chkhOtherServices.Visible = true;
            }
            else
            {
                this.chkhOtherServices.Visible = false;
            }
        }

        // Token: 0x06000EBD RID: 3773 RVA: 0x000A7F0F File Offset: 0x000A610F
        private void chkhOtherServices_MouseLeave(object sender, EventArgs e)
        {
            this.chkhOtherServices.Visible = false;
        }

        // Token: 0x06000EBE RID: 3774 RVA: 0x000A7F28 File Offset: 0x000A6128
        private void cboPType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.chkRequirement.CheckedItems.Count == 0)
            {
                this.chkRequirement.Items.Clear();
                List<RequireLetter> list = new List<RequireLetter>();
                string type = this.cboPType.SelectedItem.ToString();
                list = (from x in this.entity.RequireLetter
                        where x.IsDelete == (bool?)false && (x.Type == type || x.Type == "Both")
                        select x).ToList<RequireLetter>();
                foreach (RequireLetter requireLetter in list)
                {
                    this.chkRequirement.Items.Add(requireLetter.Description);
                }
            }
        }

        // Token: 0x06000EBF RID: 3775 RVA: 0x000A80EC File Offset: 0x000A62EC
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // Token: 0x06000EC0 RID: 3776 RVA: 0x000A80F5 File Offset: 0x000A62F5
        private void groupBox2_Enter_1(object sender, EventArgs e)
        {
        }

        // Token: 0x06000EC1 RID: 3777 RVA: 0x000A80F8 File Offset: 0x000A62F8
        private void dgvFlight_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int curr = 0;
            for (int i = 0; i < this.dgvFlight.Rows.Count; i++)
            {
                curr += int.Parse(this.dgvFlight.Rows[i].Cells["colSeat"].Value.ToString());
            }
            this.txtTotalNo.Text = curr.ToString();
        }

        // Token: 0x06000EC2 RID: 3778 RVA: 0x000A8170 File Offset: 0x000A6370
        private void dgvPassenger_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6)
            {
                int MMKBalance = 0;
                decimal d = 0m;
                decimal d2 = 0m;
                this.dgvPassenger.CurrentRow.Cells["colTotal"].Value = int.Parse(this.dgvPassenger.CurrentRow.Cells["colTax"].Value.ToString()) + decimal.Parse(this.dgvPassenger.CurrentRow.Cells["colFare"].Value.ToString());
                for (int i = 0; i < this.dgvPassenger.Rows.Count; i++)
                {
                    MMKBalance += int.Parse(this.dgvPassenger.Rows[i].Cells["colTax"].Value.ToString());
                    d += decimal.Parse(this.dgvPassenger.Rows[i].Cells["colFare"].Value.ToString());
                    d2 += decimal.Parse(this.dgvPassenger.Rows[i].Cells["colTotal"].Value.ToString());
                }
                this.txtFare.Text = d.ToString();
                this.txtTax.Text = MMKBalance.ToString();
                this.txtTotalFare.Text = d2.ToString();
            }
        }

        // Token: 0x06000EC3 RID: 3779 RVA: 0x000A8344 File Offset: 0x000A6544
        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Currency = this.cboCurrency.Text;
            if (this.cboCurrency.DataSource != null)
            {
                Currency currency = new Currency();
                currency = (from x in this.entity.Currencies
                            where x.Code == Currency && x.IsDelete == (bool?)false
                            select x).FirstOrDefault<Currency>();
                this.txtAcurrate.Text = currency.Rate.ToString();
            }
        }

        // Token: 0x06000EC4 RID: 3780 RVA: 0x000A846C File Offset: 0x000A666C
        private decimal CalculateMMKAmount(int rate, decimal amount)
        {
            return amount * rate;
        }

        // Token: 0x06000EC5 RID: 3781 RVA: 0x000A8494 File Offset: 0x000A6694
        private void dtpaDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpaTime.Focus();
            }
        }

        // Token: 0x06000EC6 RID: 3782 RVA: 0x000A84C4 File Offset: 0x000A66C4
        private void dtpaTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cboClass.Focus();
            }
        }

        // Token: 0x06000EC7 RID: 3783 RVA: 0x000A84F4 File Offset: 0x000A66F4
        private void cbohHotel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txthRemark.Focus();
            }
        }

        // Token: 0x06000EC8 RID: 3784 RVA: 0x000A852C File Offset: 0x000A672C
        private void cbohCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Currency = this.cbohCurrency.Text;
            if (this.cbohCurrency.DataSource != null)
            {
                Currency curr = new Currency();
                curr = (from x in this.entity.Currencies
                        where x.Code == Currency && x.IsDelete == (bool?)false
                        select x).FirstOrDefault<Currency>();
                this.txthCurRate.Text = curr.Rate.ToString();
            }
        }

        // Token: 0x06000EC9 RID: 3785 RVA: 0x000A8651 File Offset: 0x000A6851
        private void txtTotalhAmount_TextChanged(object sender, EventArgs e)
        {
            this.CalculateHotelDiscount();
        }

        // Token: 0x06000ECA RID: 3786 RVA: 0x000A8664 File Offset: 0x000A6864
        private void cboTCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Currency = this.cboTCurrency.Text;
            if (this.cboTCurrency.DataSource != null)
            {
                Currency currency = new Currency();
                currency = (from x in this.entity.Currencies
                            where x.Code == Currency && x.IsDelete == (bool?)false
                            select x).FirstOrDefault<Currency>();
                this.txtTCurRate.Text = currency.Rate.ToString();
            }
        }

        // Token: 0x06000ECB RID: 3787 RVA: 0x000A878C File Offset: 0x000A698C
        private void dgvTourPackage_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                decimal total = 0m;
                decimal i = 0m;
                int num = 0;
                this.dgvTourPackage.CurrentRow.Cells["colTAmount"].Value = int.Parse(this.dgvTourPackage.CurrentRow.Cells["colTPax"].Value.ToString()) * decimal.Parse(this.dgvTourPackage.CurrentRow.Cells["colTPrice"].Value.ToString());
                for (int j = 0; j < this.dgvTourPackage.Rows.Count; j++)
                {
                    num += int.Parse(this.dgvTourPackage.Rows[j].Cells["colTPax"].Value.ToString());
                    i += int.Parse(this.dgvTourPackage.Rows[j].Cells["colTPrice"].Value.ToString());
                    total += int.Parse(this.dgvTourPackage.Rows[j].Cells["colTAmount"].Value.ToString());
                }
                this.txtTtotalAmount.Text = total.ToString();
            }
        }

        // Token: 0x06000ECC RID: 3788 RVA: 0x000A893B File Offset: 0x000A6B3B
        private void txtTtotalAmount_TextChanged(object sender, EventArgs e)
        {
            this.CalculateTourDiscount();
        }

        // Token: 0x06000ECD RID: 3789 RVA: 0x000A8948 File Offset: 0x000A6B48
        private void dgvPassport_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                decimal curr = 0m;
                for (int i = 0; i < this.dgvPassport.Rows.Count; i++)
                {
                    curr += int.Parse(this.dgvPassport.Rows[i].Cells["colCharges"].Value.ToString());
                }
                this.txtPtotalamount.Text = curr.ToString();
            }
        }

        // Token: 0x06000ECE RID: 3790 RVA: 0x000A89E8 File Offset: 0x000A6BE8
        private void cboPCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Currency = this.cboPCurrency.Text;
            if (this.cboPCurrency.DataSource != null)
            {
                Currency currency = new Currency();
                currency = (from x in this.entity.Currencies
                            where x.Code == Currency && x.IsDelete == (bool?)false
                            select x).FirstOrDefault<Currency>();
                this.txtPCurrRate.Text = currency.Rate.ToString();
            }
        }

        // Token: 0x06000ECF RID: 3791 RVA: 0x000A8B18 File Offset: 0x000A6D18
        private void cbocCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Currency = this.cbocCurrency.Text;
            if (this.cbocCurrency.DataSource != null)
            {
                Currency total = new Currency();
                total = (from x in this.entity.Currencies
                         where x.Code == Currency && x.IsDelete == (bool?)false
                         select x).FirstOrDefault<Currency>();
                this.txtcRate.Text = total.Rate.ToString();
            }
        }

        // Token: 0x06000ED0 RID: 3792 RVA: 0x000A8C3D File Offset: 0x000A6E3D
        private void cbocPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // Token: 0x06000ED1 RID: 3793 RVA: 0x000A8C40 File Offset: 0x000A6E40
        private void dgvCarRental_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                decimal graphics = 0m;
                for (int gradient_rectangle = 0; gradient_rectangle < this.dgvCarRental.Rows.Count; gradient_rectangle++)
                {
                    graphics += int.Parse(this.dgvCarRental.Rows[gradient_rectangle].Cells["colcAmount"].Value.ToString());
                }
                this.txtcTotalAmount.Text = graphics.ToString();
            }
        }

        // Token: 0x06000ED2 RID: 3794 RVA: 0x000A8CD6 File Offset: 0x000A6ED6
        private void txtcTotalAmount_TextChanged(object sender, EventArgs e)
        {
        }

        // Token: 0x06000ED3 RID: 3795 RVA: 0x000A8CDC File Offset: 0x000A6EDC
        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
            Brush brush = new LinearGradientBrush(rect, Color.LightPink, Color.HotPink, 90f);
            graphics.FillRectangle(brush, rect);
        }

        // Token: 0x06000ED4 RID: 3796 RVA: 0x000A8D28 File Offset: 0x000A6F28
        private void tabPage2_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
            Brush brush = new LinearGradientBrush(rect, Color.LightPink, Color.HotPink, 90f);
            graphics.FillRectangle(brush, rect);
        }

        // Token: 0x06000ED5 RID: 3797 RVA: 0x000A8D72 File Offset: 0x000A6F72
        private void s(object sender, EventArgs e)
        {
        }

        // Token: 0x06000ED6 RID: 3798 RVA: 0x000A8D78 File Offset: 0x000A6F78
        private void button1_Click(object sender, EventArgs e)
        {
            this.pnlCredit.Visible = true;
            this.pnlCredit.Left = 160;
            this.pnlCredit.Width = 1210;
            this.pnlCredit.Height = 722;
            this.pnlTravel.Visible = false;
            this.pnlCarRental.Visible = false;
            this.pnlHotelBooking.Visible = false;
            this.pnlTourPackage.Visible = false;
            this.pnlPassport.Visible = false;
            this.LoadCreditList();
        }

        // Token: 0x06000ED7 RID: 3799 RVA: 0x000A8E0E File Offset: 0x000A700E
        private void groupBox17_Enter(object sender, EventArgs e)
        {
        }

        // Token: 0x06000ED8 RID: 3800 RVA: 0x000A8E11 File Offset: 0x000A7011
        private void groupBox16_Enter(object sender, EventArgs e)
        {
        }

        // Token: 0x06000ED9 RID: 3801 RVA: 0x000A8E14 File Offset: 0x000A7014
        private void pnlCredit_Paint(object sender, PaintEventArgs e)
        {
            Graphics newform = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
            Brush brush = new LinearGradientBrush(rect, Color.LightCoral, Color.FromArgb(200, 200, 100), 90f);
            newform.FillRectangle(brush, rect);
        }

        // Token: 0x06000EDA RID: 3802 RVA: 0x000A8E6A File Offset: 0x000A706A
        private void btncreditsearch_Click(object sender, EventArgs e)
        {
            LoadCreditList();
        }

        // Token: 0x06000EDB RID: 3803 RVA: 0x000A8E70 File Offset: 0x000A7070
        private void dgvCreditList_DoubleClick(object sender, EventArgs e)
        {
            frmPayforCredit frmPayforCredit = new frmPayforCredit(this.dgvCreditList.SelectedRows[0].Cells[2].Value.ToString(), this.dgvCreditList.SelectedRows[0].Cells[3].Value.ToString(), Convert.ToDecimal(this.dgvCreditList.SelectedRows[0].Cells[6].Value), Convert.ToDecimal(this.dgvCreditList.SelectedRows[0].Cells[7].Value.ToString()), this.dgvCreditList.SelectedRows[0].Cells[8].Value.ToString(), this.dgvCreditList.SelectedRows[0].Cells[5].Value.ToString());
            frmPayforCredit.ShowDialog();
            this.LoadCreditList();
        }

        // Token: 0x06000EDC RID: 3804 RVA: 0x000A8F7C File Offset: 0x000A717C
        private void txtPNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtCharges.Focus();
            }
        }

        private void dgvRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboIncomeType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cboCurrency.Focus();
            }
        }

        private void groupBox11_Enter_1(object sender, EventArgs e)
        {

        }

        private void txtsupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cboFrom.Focus();
            }
        }

        private void txthSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtphHotelBooking.Focus();
            }
        }

        private void cbohIncomeType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbohHotel.Focus();
            }
        }

        private void txttsupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpTInvoiceDate.Focus();
            }
        }

        private void cbotIncomeType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cboTTransportation.Focus();
            }
        }

        private void cbopIncomeType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpPInvoiceDate.Focus();
            }
        }

        private void txtpSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPRemark.Focus();
            }
        }

        private void txtcSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpcInvoiceDate.Focus();
            }
        }

        private void cbocIncomeType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtcRemark.Focus();
            }
        }
    }
}
