using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.ReportSource;
using Microsoft.Reporting.WinForms;
using NobelMoon.Connection;

namespace NobelMoon.UI
{
    public partial class frmTourPackage : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        public string InvoiceNo;
        public bool IsEdit;
        List<Int32> tourpDeleteID = new List<Int32>();
        Decimal tDiscount = 0;
        public frmTourPackage()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTourPackage_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle); 
        }

        #region"Tour_Package_Booking Function"
        private void CleanTourPackageBooking()
        {
            //txtTInvoiceNo.Text = entity.GetFormNo("Tour").FirstOrDefault().ToString();
            txtTContactPerson.Text = "";
            txtTCompany.Text = "";
            txtTContactPhone.Text = "";
            txtTemail.Text = "";
            dtpTInvoiceDate.Value = DateTime.Now;
            dtpTArrivalDate.Value = DateTime.Now;
            dtpTDepatureDate.Value = DateTime.Now;
            txtTNofN.Text = "0";
            txtTRemark.Text = "";
            txtTCurRate.Text = "1";
            txtMeetPoing.Text = "";
            cboTTransportation.SelectedIndex = 0;
            txtTAdress.Text = "";
            txtTPrice.Text = "0";
            txtTNoofPax.Text = "0";
            txtTAmount.Text = "0";
            txtTFlightNo.Text = "";
            txtTtotalAmount.Text = "0";
            txtTDiscount.Text = "0";
            txtTBalance.Text = "0";
            txttsupplier.Text = "";
            //txtTSearch.Text = "";

            cboTAirLine.DataSource = null;
            List<Connection.Vehical> c = new List<Connection.Vehical>();
            c = entity.Vehicals.Where(x => x.IsDelete == false).ToList();
            cboTAirLine.DataSource = c;
            cboTAirLine.DisplayMember = "Name";
            cboTAirLine.ValueMember = "Name";
            cboTAirLine.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboTAirLine.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboTPayment.DataSource = null;
            List<Connection.PaymentTerm> p = new List<Connection.PaymentTerm>();
            p = entity.PaymentTerms.Where(x => x.IsDelete == false).ToList();
            cboTPayment.DataSource = p;
            cboTPayment.DisplayMember = "Description";
            cboTPayment.ValueMember = "Code";
            cboTPayment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboTPayment.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboTCurrency.DataSource = null;
            List<Connection.Currency> cu = new List<Connection.Currency>();
            cu = entity.Currencies.Where(x => x.IsDelete == false).ToList();
            cboTCurrency.DataSource = cu;
            cboTCurrency.DisplayMember = "Code";
            cboTCurrency.ValueMember = "Code";
            cboTCurrency.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboTCurrency.AutoCompleteSource = AutoCompleteSource.ListItems;

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

            cboTPackage.DataSource = null;
            List<Connection.Package> pak = new List<Connection.Package>();
            pak = entity.Packages.Where(x => x.IsDelete == false).ToList();
            cboTPackage.DataSource = pak;
            cboTPackage.DisplayMember = "Description";
            cboTPackage.ValueMember = "Code";
            cboTPackage.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboTPackage.AutoCompleteSource = AutoCompleteSource.ListItems;

            dgvTourPackage.Rows.Clear();
            //btnTPreview.Visible = false;
            if (InvoiceNo == "")
            {
                btnTourPackageBooking.Text = "Booking";
            }
            tDiscount = 0;
            txtTContactPerson.Focus();

            chkOtherService.Items.Clear();
            List<Connection.Services> req = new List<Connection.Services>();
            req = entity.Services.Where(x => x.Transaction == "Travel & Tour" && x.IsDelete == false).ToList();
            foreach (Connection.Services var in req)
            {
                chkOtherService.Items.Add(var.Description);
            }
            chkOtherService.CheckOnClick = true;

        }

        private void BindTourPackageBooking(string Invoice)
        {
            Connection.TourBooking tb = new Connection.TourBooking();
            tb = entity.TourBookings.Where(x => x.InvoiceNo == Invoice && x.IsDelete == false).FirstOrDefault();
            if (tb != null)
            {
                txtTInvoiceNo.Text = tb.InvoiceNo;
                txtTContactPerson.Text = tb.ContactPerson;
                txtTCompany.Text = tb.CompanyName;
                txtTContactPhone.Text = tb.ContactPhone;
                cboTPayment.SelectedItem = tb.PaymentTerm;
                cboTCurrency.SelectedItem = tb.Currency;
                txtTemail.Text = tb.Email;
                this.cbotIncomeType.SelectedValue = tb.t1;
                this.txttsupplier.Text = tb.t2;
                dtpTInvoiceDate.Value = (DateTime)tb.InvoiceDate;
                dtpTArrivalDate.Value = (DateTime)tb.ArrivalDate;
                dtpTDepatureDate.Value = (DateTime)tb.DepatureDate;
                txtTAdress.Text = tb.Address;
                txtTRemark.Text = tb.Remark;
                txtTNofN.Text = tb.NoofNight.ToString();
                txtTCurRate.Text = tb.Rate.ToString();
                txtMeetPoing.Text = tb.MeetingPoint;
                txtTtotalAmount.Text = tb.TotalAmount.ToString();
                txtTDiscount.Text = tb.Discount_Percent.ToString();
                tDiscount = (Decimal)tb.Discount;
                txtTBalance.Text = tb.Balance.ToString();
                cboTTransportation.SelectedItem = tb.Type.ToString();
                cboTCurrency.Text = tb.Currency;
                txtTCurRate.Text = tb.Rate.ToString();
                //txtTSearch.Text = "";
            }

            List<Connection.TourPackage> tf = new List<Connection.TourPackage>();
            tf = entity.TourPackages.Where(x => x.InvoiceNo == Invoice && x.IsDelete == false).ToList();
            if (tf.Count > 0)
            {
                dgvTourPackage.Rows.Clear();
                for (int i = 0; i < tf.Count; i++)
                {
                    dgvTourPackage.Rows.Add(tf[i].PackageDescription, tf[i].Price, tf[i].NoofPax, tf[i].Amount, tf[i].AirLine, tf[i].FlightNo, 0, tf[i].ID, tf[i].PackageCode);
                }
            }

            string services = "";
            if (chkOtherService.CheckedItems.Count == 0)
            {
                chkOtherService.Items.Clear();
                List<Connection.Services> req = new List<Connection.Services>();
                req = entity.Services.Where(x => x.Transaction == "Travel & Tour" && x.IsDelete == false).ToList();
                List<Connection.ServicesOrRequirement> sr = new List<Connection.ServicesOrRequirement>();
                sr = entity.ServicesOrRequirement.Where(x => x.InvoiceNo == Invoice && x.Transaction == "Travel & Tour").ToList();
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
                        chkOtherService.Items.Add(var.Description, CheckState.Checked);
                    }
                    else chkOtherService.Items.Add(var.Description);
                }
            }
            chkOtherService.CheckOnClick = true;
        }

        private void CalculateTourPackageAmount()
        {
            Decimal tPrice = Decimal.Parse(txtTPrice.Text == "" ? "0" : txtTPrice.Text);
            Int32 Paxno = Int32.Parse(txtTNoofPax.Text == "" ? "0" : txtTNoofPax.Text);
            Decimal Amount = Decimal.Parse(txtTAmount.Text == "" ? "0" : txtTAmount.Text);
            Decimal Discount = tDiscount;
            Decimal TotalAmount = Decimal.Parse(txtTtotalAmount.Text == "" ? "0" : txtTtotalAmount.Text);
            Decimal Balance = Decimal.Parse(txtTBalance.Text == "" ? "0" : txtTBalance.Text);
            txtTAmount.Text = (tPrice * Paxno).ToString();
            txtTtotalAmount.Text = (TotalAmount + Amount).ToString();
            txtTBalance.Text = ((TotalAmount + Amount) - Discount).ToString();
        }

        private void ReCalculateTourPackageAmount(Int32 pno, Decimal Price, Decimal amt)
        {
            Decimal tPrice = Decimal.Parse(txtTPrice.Text == "" ? "0" : txtTPrice.Text);
            Int32 Paxno = Int32.Parse(txtTNoofPax.Text == "" ? "0" : txtTNoofPax.Text);
            Decimal Amount = Decimal.Parse(txtTAmount.Text == "" ? "0" : txtTAmount.Text);
            Decimal Discount = tDiscount;
            Decimal TotalAmount = Decimal.Parse(txtTtotalAmount.Text == "" ? "0" : txtTtotalAmount.Text);
            Decimal Balance = Decimal.Parse(txtTBalance.Text == "" ? "0" : txtTBalance.Text);
            txtTAmount.Text = (Amount - Price).ToString();
            txtTtotalAmount.Text = (TotalAmount - amt).ToString();
            txtTBalance.Text = (Balance - amt).ToString();
        }
        #endregion

        private void frmTourPackage_Load(object sender, EventArgs e)
        {
            if (IsEdit == true)
            {
                CleanTourPackageBooking();
                BindTourPackageBooking(InvoiceNo);
            }
        }

        private void txtTContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTCompany.Focus();
            }
        }

        private void txtTCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTContactPhone.Focus();
            }
        }

        private void txtTContactPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTemail.Focus();
            }
        }

        private void txtTemail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboTCurrency.Focus();
            }
        }

        private void cboTCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Currency = cboTCurrency.Text;
                Connection.Currency curr = new Connection.Currency();
                curr = entity.Currencies.Where(x => x.Code == Currency && x.IsDelete == false).FirstOrDefault();
                txtTCurRate.Text = curr.Rate.ToString();
                txtTCurRate.Focus();
            }
        }

        private void txtTCurRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTAdress.Focus();
            }
        }

        private void txtTAdress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txttsupplier.Focus();
            }
        }

        private void dtpTInvoiceDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpTDepatureDate.Focus();
            }
        }

        private void dtpTDepatureDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpTArrivalDate.Focus();
            }
        }

        private void dtpTArrivalDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Int32 date = Convert.ToInt32((dtpTArrivalDate.Value - dtpTDepatureDate.Value).TotalDays);
                txtTNofN.Text = date.ToString();
                txtTNofN.Focus();
            }
        }

        private void txtTNofN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMeetPoing.Focus();
            }
        }

        private void txtMeetPoing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboTPayment.Focus();
            }
        }

        private void cboTPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbotIncomeType.Focus();
            }
        }

        private void cboTTransportation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string type = cboTTransportation.Text;
                cboTAirLine.DataSource = null;
                List<Connection.Vehical> v = new List<Connection.Vehical>();
                v = entity.Vehicals.Where(x => x.IsDelete == false && x.Type == type).ToList();
                cboTAirLine.DataSource = v;
                cboTAirLine.DisplayMember = "Name";
                cboTAirLine.ValueMember = "Name";
                cboTAirLine.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboTAirLine.AutoCompleteSource = AutoCompleteSource.ListItems;
                txtTRemark.Focus();
            }
        }

        private void txtTRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboTPackage.Focus();
            }
        }

        private void cboTPackage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboTPackage.SelectedValue != null)
                {
                    string rtype = cboTPackage.Text;
                    string room = cboTPackage.SelectedValue.ToString();
                    Connection.Package r = new Connection.Package();
                    r = entity.Packages.Where(x => x.Code == room && x.IsDelete == false).FirstOrDefault();
                    txtTPrice.Text = r.Price.ToString();
                    txtTPrice.Focus();
                }
                else
                {
                    txtTPrice.Focus();
                }
            }
        }

        private void txtTPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTNoofPax.Focus();
            }
        }

        private void txtTNoofPax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal price = Decimal.Parse(txtTPrice.Text);
                Int32 pno = Int32.Parse(txtTNoofPax.Text);
                txtTAmount.Text = (price * pno).ToString();
                cboTAirLine.Focus();
            }
        }

        private void txtTAmount_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cboTAirLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTFlightNo.Focus();
            }
        }

        private void txtTFlightNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTAdd_Click(sender, e);
            }
        }

        private void btnTAdd_Click(object sender, EventArgs e)
        {
            string pcode = "";
            Connection.Package r = new Connection.Package();
            if (cboTPackage.SelectedValue != null)
            {
                pcode = cboTPackage.SelectedValue.ToString();
                r = entity.Packages.Where(x => x.Code == pcode && x.IsDelete == false).FirstOrDefault();
            }
            else
            {
                r.Description = cboTPackage.Text;
            }
            Decimal price = Decimal.Parse(txtTPrice.Text == "" ? "0" : txtTPrice.Text);
            Int32 pno = Int32.Parse(txtTNoofPax.Text == "" ? "0" : txtTNoofPax.Text);
            Decimal amount = Decimal.Parse(txtTAmount.Text == "" ? "0" : txtTAmount.Text);

            dgvTourPackage.Rows.Add(r.Description, price, pno, amount, cboTAirLine.SelectedValue, txtTFlightNo.Text, 0, null, pcode);

            CalculateTourPackageAmount();
            cboTPackage.SelectedIndex = 0;
            txtTPrice.Text = "0";
            txtTNoofPax.Text = "0";
            txtTAmount.Text = "0";
            cboTAirLine.SelectedIndex = 0;
            txtTFlightNo.Text = "";
            cboTPackage.Focus();
        }

        private void dgvTourPackage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (dgvTourPackage.CurrentRow.Cells["colTID"].Value != null)
                {
                    tourpDeleteID.Add(Int32.Parse(dgvTourPackage.CurrentRow.Cells["colTID"].Value.ToString()));
                }
                Int32 n = Int32.Parse(dgvTourPackage.CurrentRow.Cells["colTPax"].Value.ToString());
                decimal r = Int32.Parse(dgvTourPackage.CurrentRow.Cells["colTPrice"].Value.ToString());
                decimal a = Int32.Parse(dgvTourPackage.CurrentRow.Cells["colTAmount"].Value.ToString());
                ReCalculateTourPackageAmount(n, r, a);
                dgvTourPackage.Rows.Remove(dgvTourPackage.CurrentRow);
            }
        }

        private void dgvTourPackage_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                decimal total = 0, price = 0; Int32 pax = 0;
                dgvTourPackage.CurrentRow.Cells["colTAmount"].Value = Int32.Parse(dgvTourPackage.CurrentRow.Cells["colTPax"].Value.ToString()) * Decimal.Parse(dgvTourPackage.CurrentRow.Cells["colTPrice"].Value.ToString());
                for (int i = 0; i < dgvTourPackage.Rows.Count; i++)
                {
                    pax += Int32.Parse(dgvTourPackage.Rows[i].Cells["colTPax"].Value.ToString());
                    price += Int32.Parse(dgvTourPackage.Rows[i].Cells["colTPrice"].Value.ToString());
                    total += Int32.Parse(dgvTourPackage.Rows[i].Cells["colTAmount"].Value.ToString());
                }
                txtTtotalAmount.Text = total.ToString();
            }
        }

        private void txtTDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateTourDiscount();
            }
        }

        private void CalculateTourDiscount()
        {
            if (txtTBalance.Text != "" && txtTBalance.Text != null)
            {
                Decimal dis = Decimal.Parse(txtTDiscount.Text);
                Decimal totalamt = Decimal.Parse(txtTtotalAmount.Text);
                if (dis > 0)
                {
                    txtTBalance.Text = (totalamt - (totalamt * (dis / 100))).ToString();
                    tDiscount = (totalamt * (dis / 100));
                }
                else
                {
                    txtTBalance.Text = (totalamt).ToString();
                    tDiscount = 0;
                }
            }
        }

        private void txtTContactPerson_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboTCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string Currency = cboTCurrency.Text;
            //if (cboTCurrency.DataSource != null)
            //{
            //    Connection.Currency curr = new Connection.Currency();
            //    curr = entity.Currencies.Where(x => x.Code == Currency && x.IsDelete == false).FirstOrDefault();
            //    txtTCurRate.Text = curr.Rate.ToString();
            //}
        }

        private void cboTTransportation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTTransportation.SelectedItem == "Bus")
            {
                label119.Text = "CarLine";
                label107.Text = "CarNo";
                colAirLine.HeaderText = "AirLine";
                colFlightNo.HeaderText = "FlightNo";
                cboTAirLine.DataSource = null;
                List<Connection.Vehical> v = new List<Connection.Vehical>();
                v = entity.Vehicals.Where(x => x.IsDelete == false && x.Type == "Bus").ToList();
                cboTAirLine.DataSource = v;
                cboTAirLine.DisplayMember = "Name";
                cboTAirLine.ValueMember = "Name";
                cboTAirLine.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboTAirLine.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            else
            {
                label119.Text = "AirLine";
                label107.Text = "FlightNo";
                colAirLine.HeaderText = "AirLine";
                colFlightNo.HeaderText = "FlightNo";
                cboTAirLine.DataSource = null;
                List<Connection.Vehical> v = new List<Connection.Vehical>();
                v = entity.Vehicals.Where(x => x.IsDelete == false && x.Type == "AirLine").ToList();
                cboTAirLine.DataSource = v;
                cboTAirLine.DisplayMember = "Name";
                cboTAirLine.ValueMember = "Name";
                cboTAirLine.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboTAirLine.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        private bool TourPackageIsValid()
        {
            if (txtTContactPerson.Text == "" && dgvTourPackage.Rows.Count == 0)
            {
                return false;
            }
            else return true;
        }

        private void btnTourPackageBooking_Click(object sender, EventArgs e)
        {
            if (TourPackageIsValid() == true)
            {
                try
                {
                    if (btnTourPackageBooking.Text == "Booking")
                    {
                        Connection.TourBooking tb = new Connection.TourBooking();
                        tb.InvoiceNo = txtTInvoiceNo.Text;
                        tb.SystemDate = DateTime.Now;
                        tb.ContactPerson = txtTContactPerson.Text;
                        tb.CompanyName = txtTCompany.Text;
                        tb.ContactPhone = txtTContactPhone.Text;
                        tb.Currency = cboTCurrency.SelectedValue.ToString();
                        tb.MeetingPoint = txtMeetPoing.Text;
                        tb.Type = cboTTransportation.SelectedItem.ToString();
                        tb.Rate = Int32.Parse(txtTCurRate.Text);
                        tb.PaymentTerm = cboTPayment.SelectedValue.ToString();
                        tb.Address = txtTAdress.Text;
                        tb.Email = txtTemail.Text;
                        tb.t1 = this.cbotIncomeType.SelectedValue.ToString();
                        tb.t2 = this.txttsupplier.Text;
                        tb.InvoiceDate = DateTime.Parse(dtpTInvoiceDate.Value.ToShortDateString());
                        tb.DepatureDate = DateTime.Parse(dtpTDepatureDate.Value.ToShortDateString());
                        tb.ArrivalDate = DateTime.Parse(dtpTArrivalDate.Value.ToShortDateString());
                        tb.NoofNight = Int32.Parse(txtTNofN.Text == "" ? "0" : txtTNofN.Text);
                        tb.Discount = tDiscount;
                        tb.Discount_Percent = Int32.Parse(txtTDiscount.Text == "" ? "0" : txtTDiscount.Text);
                        tb.TotalAmount = Decimal.Parse(txtTtotalAmount.Text == "" ? "0" : txtTtotalAmount.Text);
                        tb.Balance = Decimal.Parse(txtTBalance.Text == "" ? "0" : txtTBalance.Text);
                        tb.Remark = txtTRemark.Text;
                        tb.MMKBalance = CalculateMMKAmount(Convert.ToInt32(tb.Rate), Convert.ToDecimal(tb.Balance));
                        tb.Status = "B";
                        tb.User = Utility.Utility.User;
                        tb.IsDelete = false;

                        entity.AddToTourBookings(tb);
                        entity.SaveChanges();

                        #region"TourPackage"
                        if (dgvTourPackage.Rows.Count > 0)
                        {
                            for (int i = 0; i < dgvTourPackage.Rows.Count; i++)
                            {
                                Connection.TourPackage hr = new Connection.TourPackage();
                                hr.InvoiceNo = txtTInvoiceNo.Text;
                                hr.SystemDate = DateTime.Now;
                                hr.PackageDescription = dgvTourPackage.Rows[i].Cells["colpackage"].Value.ToString();
                                hr.AirLine = dgvTourPackage.Rows[i].Cells["colAirline"].Value.ToString();
                                hr.FlightNo = dgvTourPackage.Rows[i].Cells["colFlightNo"].Value.ToString();
                                hr.Price = Decimal.Parse(dgvTourPackage.Rows[i].Cells["colTPrice"].Value.ToString());
                                hr.NoofPax = Int32.Parse(dgvTourPackage.Rows[i].Cells["colTPax"].Value.ToString());
                                hr.Amount = Decimal.Parse(dgvTourPackage.Rows[i].Cells["colTAmount"].Value.ToString());
                                hr.PackageCode = dgvTourPackage.Rows[i].Cells["colTpCode"].Value.ToString();
                                hr.Status = "B";
                                hr.User = Utility.Utility.User;
                                hr.IsDelete = false;

                                entity.AddToTourPackages(hr);
                                entity.SaveChanges();
                            }
                        }
                        #endregion

                        #region "Services&Requirement"
                        foreach (string var in chkOtherService.CheckedItems)
                        {
                            string services = var.ToString();
                            Connection.ServicesOrRequirement sr = new Connection.ServicesOrRequirement();
                            Connection.Services s = new Connection.Services();
                            s = entity.Services.Where(x => x.Description == services && x.Transaction == "Travel & Tour" && x.IsDelete == false).FirstOrDefault();

                            sr.CreatedDate = DateTime.Now;
                            sr.Code = s.Code;
                            sr.Description = s.Description;
                            sr.InvoiceNo = txtTInvoiceNo.Text;
                            sr.Transaction = "Travel & Tour";
                            sr.User = Utility.Utility.User;
                            entity.AddToServicesOrRequirement(sr);
                            entity.SaveChanges();
                        }
                        #endregion

                        MessageBox.Show("Booking Successful!", "Successful", MessageBoxButtons.OK);
                    }

                    else if (btnTourPackageBooking.Text == "Update")
                    {
                        string invoice = txtTInvoiceNo.Text;
                        #region"TicketBooking"
                        Connection.TourBooking tb = new Connection.TourBooking();
                        tb = entity.TourBookings.Where(x => x.InvoiceNo == invoice && x.IsDelete == false).FirstOrDefault();
                        tb.InvoiceNo = txtTInvoiceNo.Text;
                        tb.SystemDate = DateTime.Now;
                        tb.ContactPerson = txtTContactPerson.Text;
                        tb.CompanyName = txtTCompany.Text;
                        tb.ContactPhone = txtTContactPhone.Text;
                        tb.Currency = cboTCurrency.SelectedValue.ToString();
                        tb.MeetingPoint = txtMeetPoing.Text;
                        tb.Type = cboTTransportation.SelectedItem.ToString();
                        tb.Rate = Int32.Parse(txtTCurRate.Text);
                        tb.PaymentTerm = cboTPayment.SelectedValue.ToString();
                        tb.Address = txtTAdress.Text;
                        tb.Email = txtTemail.Text;
                        tb.InvoiceDate = DateTime.Parse(dtpTInvoiceDate.Value.ToShortDateString());
                        tb.DepatureDate = DateTime.Parse(dtpTDepatureDate.Value.ToShortDateString());
                        tb.ArrivalDate = DateTime.Parse(dtpTArrivalDate.Value.ToShortDateString());
                        tb.NoofNight = Int32.Parse(txtTNofN.Text == "" ? "0" : txtTNofN.Text);
                        tb.Discount = tDiscount;
                        tb.Discount_Percent = Int32.Parse(txtTDiscount.Text == "" ? "0" : txtTDiscount.Text);
                        tb.TotalAmount = Decimal.Parse(txtTtotalAmount.Text == "" ? "0" : txtTtotalAmount.Text);
                        tb.Balance = Decimal.Parse(txtTBalance.Text == "" ? "0" : txtTBalance.Text);
                        tb.Remark = txtTRemark.Text;
                        tb.MMKBalance = CalculateMMKAmount(Convert.ToInt32(tb.Rate), Convert.ToDecimal(tb.Balance));
                        tb.Status = "U";
                        tb.User = Utility.Utility.User;
                        tb.IsDelete = false;

                        entity.SaveChanges();
                        #endregion

                        #region"TourPackage"
                        if (dgvTourPackage.Rows.Count > 0)
                        {
                            if (tourpDeleteID.Count > 0)
                            {
                                for (int i = 0; i < tourpDeleteID.Count; i++)
                                {
                                    Connection.TourPackage tf = new Connection.TourPackage();
                                    Int32 Id = Int32.Parse(tourpDeleteID[i].ToString());
                                    tf = entity.TourPackages.Where(x => x.ID == Id && x.IsDelete == false).FirstOrDefault();
                                    tf.IsDelete = true;
                                    entity.SaveChanges();
                                }
                            }
                            for (int i = 0; i < dgvTourPackage.Rows.Count; i++)
                            {
                                if (dgvTourPackage.Rows[i].Cells["colTID"].Value == null)
                                {
                                    Connection.TourPackage hr = new Connection.TourPackage();
                                    hr.InvoiceNo = txtTInvoiceNo.Text;
                                    hr.SystemDate = DateTime.Now;
                                    hr.PackageDescription = dgvTourPackage.Rows[i].Cells["colpackage"].Value.ToString();
                                    hr.AirLine = dgvTourPackage.Rows[i].Cells["colAirline"].Value.ToString();
                                    hr.FlightNo = dgvTourPackage.Rows[i].Cells["colFlightNo"].Value.ToString();
                                    hr.Price = Decimal.Parse(dgvTourPackage.Rows[i].Cells["colTPrice"].Value.ToString());
                                    hr.NoofPax = Int32.Parse(dgvTourPackage.Rows[i].Cells["colTPax"].Value.ToString());
                                    hr.Amount = Decimal.Parse(dgvTourPackage.Rows[i].Cells["colTAmount"].Value.ToString());
                                    hr.PackageCode = dgvTourPackage.Rows[i].Cells["colTpCode"].Value.ToString();
                                    hr.User = Utility.Utility.User;
                                    hr.Status = "B";
                                    hr.IsDelete = false;

                                    entity.AddToTourPackages(hr);
                                    entity.SaveChanges();
                                }
                                else
                                {
                                    Connection.TourPackage hr = new Connection.TourPackage();
                                    Int32 Id = Int32.Parse(dgvTourPackage.Rows[i].Cells["colTID"].Value.ToString());
                                    hr = entity.TourPackages.Where(x => x.ID == Id && x.IsDelete == false).FirstOrDefault();
                                    hr.InvoiceNo = txtTInvoiceNo.Text;
                                    hr.SystemDate = DateTime.Now;
                                    hr.PackageDescription = dgvTourPackage.Rows[i].Cells["colpackage"].Value.ToString();
                                    hr.AirLine = dgvTourPackage.Rows[i].Cells["colAirline"].Value.ToString();
                                    hr.FlightNo = dgvTourPackage.Rows[i].Cells["colFlightNo"].Value.ToString();
                                    hr.Price = Decimal.Parse(dgvTourPackage.Rows[i].Cells["colTPrice"].Value.ToString());
                                    hr.NoofPax = Int32.Parse(dgvTourPackage.Rows[i].Cells["colTPax"].Value.ToString());
                                    hr.Amount = Decimal.Parse(dgvTourPackage.Rows[i].Cells["colTAmount"].Value.ToString());
                                    hr.PackageCode = dgvTourPackage.Rows[i].Cells["colTpCode"].Value.ToString();
                                    hr.User = Utility.Utility.User;
                                    hr.Status = "U";
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

                        sq = entity.ServicesOrRequirement.Where(x => x.InvoiceNo == txtTInvoiceNo.Text && x.Transaction == "Travel & Tour").ToList();
                        for (int i = 0; i < sq.Count; i++)
                        {
                            Int32 id = sq[i].ID;
                            sr = new Connection.ServicesOrRequirement();
                            sr = entity.ServicesOrRequirement.Where(x => x.ID == id).FirstOrDefault();
                            entity.ServicesOrRequirement.DeleteObject(sr);
                            entity.SaveChanges();
                        }

                        foreach (string var in chkOtherService.CheckedItems)
                        {
                            string services = var.ToString();
                            s = entity.Services.Where(x => x.Description == services && x.Transaction == "Travel & Tour" && x.IsDelete == false).FirstOrDefault();
                            sr = new Connection.ServicesOrRequirement();
                            sr.CreatedDate = DateTime.Now;
                            sr.Code = s.Code;
                            sr.Description = s.Description;
                            sr.InvoiceNo = txtTInvoiceNo.Text;
                            sr.Transaction = "Travel & Tour";
                            sr.User = Utility.Utility.User;
                            entity.AddToServicesOrRequirement(sr);
                            entity.SaveChanges();
                        }
                        #endregion

                        MessageBox.Show("Update Successful!", "Successful", MessageBoxButtons.OK);
                    }
                    else if (btnTourPackageBooking.Text == "Issue")
                    {
                        string invoice = txtTInvoiceNo.Text;
                        Connection.TourBooking tb = new Connection.TourBooking();
                        tb = entity.TourBookings.Where(x => x.InvoiceNo == invoice && x.IsDelete == false).FirstOrDefault();
                        tb.InvoiceNo = txtTInvoiceNo.Text;
                        tb.SystemDate = DateTime.Now;
                        tb.ContactPerson = txtTContactPerson.Text;
                        tb.CompanyName = txtTCompany.Text;
                        tb.ContactPhone = txtTContactPhone.Text;
                        tb.Currency = cboTCurrency.SelectedValue.ToString();
                        tb.MeetingPoint = txtMeetPoing.Text;
                        tb.Type = cboTTransportation.SelectedItem.ToString();
                        tb.Rate = Int32.Parse(txtTCurRate.Text);
                        tb.PaymentTerm = cboTPayment.SelectedValue.ToString();
                        tb.Address = txtTAdress.Text;
                        tb.Email = txtTemail.Text;
                        tb.InvoiceDate = DateTime.Parse(dtpTInvoiceDate.Value.ToShortDateString());
                        tb.DepatureDate = DateTime.Parse(dtpTDepatureDate.Value.ToShortDateString());
                        tb.ArrivalDate = DateTime.Parse(dtpTArrivalDate.Value.ToShortDateString());
                        tb.NoofNight = Int32.Parse(txtTNofN.Text == "" ? "0" : txtTNofN.Text);
                        tb.Discount = tDiscount;
                        tb.Discount_Percent = Int32.Parse(txtTDiscount.Text == "" ? "0" : txtTDiscount.Text);
                        tb.TotalAmount = Decimal.Parse(txtTtotalAmount.Text == "" ? "0" : txtTtotalAmount.Text);
                        tb.Balance = Decimal.Parse(txtTBalance.Text == "" ? "0" : txtTBalance.Text);
                        tb.Remark = txtTRemark.Text;
                        tb.MMKBalance = CalculateMMKAmount(Convert.ToInt32(tb.Rate), Convert.ToDecimal(tb.Balance));
                        tb.Status = "I";
                        tb.User = Utility.Utility.User;
                        tb.IsDelete = false;

                        entity.SaveChanges();

                        MessageBox.Show("Confirm Successful!", "Successful", MessageBoxButtons.OK);
                        btnTPreview_Click(sender, e);
                    }
                    tourpDeleteID = new List<int>();
                    CleanTourPackageBooking();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else MessageBox.Show("Please fill information!", "Incomplete Information");
        }

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

        private Decimal CalculateMMKAmount(int rate, decimal amount)
        {
            decimal MMKBalance = 0;
            MMKBalance = amount * rate;
            return MMKBalance;
        }

        private void btnTCancel_Click(object sender, EventArgs e)
        {
            CleanTourPackageBooking();
        }

        private void chkOtherService_MouseLeave(object sender, EventArgs e)
        {
             chkOtherService.Visible = false;
        }

        private void btnOtherService_Click(object sender, EventArgs e)
        {
            if (chkOtherService.Visible == false)
            {
                chkOtherService.Visible = true;
            }
            else chkOtherService.Visible = false;
        }

        private void txttsupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpTInvoiceDate.Focus();
            }
        }

        private void cbotIncomeType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboTTransportation.Focus();
            }
        }
    }
}
