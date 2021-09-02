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
using NobelMoon.Connection;

namespace NobelMoon.UI
{
    public partial class frmCarRental : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        List<Int32> carrentalDeleteID = new List<Int32>();
        public bool IsEdit = false;
        public string InvoiceNo = "";
        public frmCarRental()
        {
            InitializeComponent();
        }

        private void frmCarRental_Load(object sender, EventArgs e)
        {
            if (IsEdit == true)
            {
                CleanCarRentalBooking();
                BindCarRentalBooking(InvoiceNo);
            }
        }

        #region"CarRental_Booking Function"
        private void CleanCarRentalBooking()
        {
            //txtcInvoiceNo.Text = entity.GetFormNo("CarRental").FirstOrDefault().ToString();
            txtcContactPerson.Text = "";
            txtcContactPhone.Text = "";
            txtcEmail.Text = "";
            txtcCompanyName.Text = "";
            dtpcInvoiceDate.Value = DateTime.Now;
            dtpcArrivalDate.Value = DateTime.Now;
            dtpcDepatureDate.Value = DateTime.Now;
            txtcRemark.Text = "";
            this.txtcSupplier.Text = "";
            txtcRate.Text = "1";
            txtcAddress.Text = "";
            txtcTotalAmount.Text = "0";
            txtcCarNo.Text = "";
            txtcExtraCharges.Text = "0";
            txtcBalance.Text = "0";
            //txtcSearch.Text = "";

            cbocCarType.DataSource = null;
            List<Connection.CarType> c = new List<Connection.CarType>();
            c = entity.CarType.Where(x => x.IsDelete == false).ToList();
            cbocCarType.DataSource = c;
            cbocCarType.DisplayMember = "Description";
            cbocCarType.ValueMember = "Code";
            cbocCarType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbocCarType.AutoCompleteSource = AutoCompleteSource.ListItems;

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

            cbocPayment.DataSource = null;
            List<Connection.PaymentTerm> p = new List<Connection.PaymentTerm>();
            p = entity.PaymentTerms.Where(x => x.IsDelete == false).ToList();
            cbocPayment.DataSource = p;
            cbocPayment.DisplayMember = "Description";
            cbocPayment.ValueMember = "Code";
            cbocPayment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbocPayment.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbocCurrency.DataSource = null;
            List<Connection.Currency> cu = new List<Connection.Currency>();
            cu = entity.Currencies.Where(x => x.IsDelete == false).ToList();
            cbocCurrency.DataSource = cu;
            cbocCurrency.DisplayMember = "Code";
            cbocCurrency.ValueMember = "Code";
            cbocCurrency.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbocCurrency.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbocPeroid.DataSource = null;
            List<Connection.Peroid> pak = new List<Connection.Peroid>();
            pak = entity.Peroid.Where(x => x.IsDelete == false).ToList();
            cbocPeroid.DataSource = pak;
            cbocPeroid.DisplayMember = "Description";
            cbocPeroid.ValueMember = "Code";
            cbocPeroid.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbocPeroid.AutoCompleteSource = AutoCompleteSource.ListItems;

            dgvCarRental.Rows.Clear();
            //btncPreview.Visible = false;
            if (InvoiceNo == "")
            {
                btnCBooking.Text = "Booking";
            }
            txtcContactPerson.Focus();
        }

        private void BindCarRentalBooking(string Invoice)
        {
            Connection.CarRentalBooking tb = new Connection.CarRentalBooking();
            tb = entity.CarRentalBooking.Where(x => x.InvoiceNo == Invoice && x.IsDelete == false).FirstOrDefault();
            if (tb != null)
            {
                txtcInvoiceNo.Text = tb.InvoiceNo;
                txtcContactPerson.Text = tb.ContactPerson;
                txtcContactPhone.Text = tb.ContactPhone;
                txtcEmail.Text = tb.Email;
                this.txtcEmail.Text = tb.Email;
                this.txtcSupplier.Text = tb.t2;
                this.cbocIncomeType.SelectedValue = tb.t1;
                txtcCompanyName.Text = tb.CompanyName;
                dtpcInvoiceDate.Value = (DateTime)tb.InvoiceDate;
                dtpcArrivalDate.Value = (DateTime)tb.ArrivalDate;
                dtpcDepatureDate.Value = (DateTime)tb.DepatureDate;
                txtcRemark.Text = tb.Remark;
                txtcRate.Text = tb.Rate.ToString();
                txtcAddress.Text = tb.Address;
                txtcTotalAmount.Text = tb.TotalAmount.ToString();
                txtcExtraCharges.Text = tb.ExtraCharges.ToString();
                txtcBalance.Text = tb.Balance.ToString();
                //txtcSearch.Text = "";
                cbocCurrency.SelectedItem = tb.Currency;
                cbocPayment.SelectedItem = tb.PaymentTerm;
            }

            List<Connection.CarRentalDetail> tf = new List<Connection.CarRentalDetail>();
            tf = entity.CarRentalDetail.Where(x => x.InvoiceNo == Invoice && x.IsDelete == false).ToList();
            if (tf.Count > 0)
            {
                dgvCarRental.Rows.Clear();
                for (int i = 0; i < tf.Count; i++)
                {
                    dgvCarRental.Rows.Add(tf[i].CarType, tf[i].Peroid, tf[i].Amount, tf[i].CarType, 0, tf[i].ID);
                }

            }
        }

        private void CalculateCarRentalAmount()
        {
            Decimal amount = Decimal.Parse(txtcAmount.Text == "" ? "0" : txtcAmount.Text);
            Decimal totalamount = Decimal.Parse(txtcTotalAmount.Text == "" ? "0" : txtcTotalAmount.Text);
            Decimal extracharges = Decimal.Parse(txtcExtraCharges.Text == "" ? "0" : txtcExtraCharges.Text);
            Decimal balance = Decimal.Parse(txtcBalance.Text == "" ? "0" : txtcBalance.Text);
            txtcTotalAmount.Text = (amount + totalamount).ToString();
            txtcBalance.Text = ((totalamount + amount) + extracharges).ToString();
        }

        #endregion

        private void btncAdd_Click(object sender, EventArgs e)
        {
            string cartype = "", peroid = "";
            cartype = cbocCarType.Text.ToString();
            peroid = cbocPeroid.Text.ToString();
            Decimal amount = Decimal.Parse(txtcAmount.Text == "" ? "0" : txtcAmount.Text);
            string carno = txtcCarNo.Text;

            dgvCarRental.Rows.Add(cartype, peroid, amount, carno);

            CalculateCarRentalAmount();
            cbocCarType.SelectedIndex = 0;
            cbocPeroid.SelectedIndex = 0;
            txtcAmount.Text = "0";
            txtcCarNo.Text = "";
            cbocCarType.Focus();
        }

        private void btnCBooking_Click(object sender, EventArgs e)
        {
            if (CarRentalIsValid() == true)
            {
                try
                {
                    if (btnCBooking.Text == "Booking")
                    {
                        Connection.CarRentalBooking tb = new Connection.CarRentalBooking();
                        tb.InvoiceNo = txtcInvoiceNo.Text;
                        tb.SystemDate = DateTime.Now;
                        tb.ContactPerson = txtcContactPerson.Text;
                        tb.CompanyName = txtcCompanyName.Text;
                        tb.ContactPhone = txtcContactPhone.Text;
                        tb.Currency = cbocCurrency.SelectedValue.ToString();
                        tb.Rate = Int32.Parse(txtcRate.Text);
                        tb.PaymentTerm = cbocPayment.SelectedValue.ToString();
                        tb.Address = txtcAddress.Text;
                        tb.Email = txtcEmail.Text;
                        tb.t1 = this.cbocIncomeType.SelectedValue.ToString();
                        tb.t2 = this.txtcSupplier.Text;
                        tb.InvoiceDate = DateTime.Parse(dtpcInvoiceDate.Value.ToShortDateString());
                        tb.DepatureDate = DateTime.Parse(dtpcDepatureDate.Value.ToShortDateString());
                        tb.ArrivalDate = DateTime.Parse(dtpcArrivalDate.Value.ToShortDateString());
                        tb.TotalAmount = Decimal.Parse(txtcTotalAmount.Text == "" ? "0" : txtcTotalAmount.Text);
                        tb.ExtraCharges = Decimal.Parse(txtcExtraCharges.Text == "" ? "0" : txtcExtraCharges.Text);
                        tb.Balance = Decimal.Parse(txtcBalance.Text == "" ? "0" : txtcBalance.Text);
                        tb.Remark = txtcRemark.Text;
                        tb.Status = "B";
                        tb.User = Utility.Utility.User;
                        tb.IsDelete = false;

                        entity.AddToCarRentalBooking(tb);
                        entity.SaveChanges();

                        #region"CarRentalDetail"
                        if (dgvCarRental.Rows.Count > 0)
                        {
                            for (int i = 0; i < dgvCarRental.Rows.Count; i++)
                            {
                                Connection.CarRentalDetail hr = new Connection.CarRentalDetail();
                                hr.InvoiceNo = txtcInvoiceNo.Text;
                                hr.SystemDate = DateTime.Now;
                                hr.CarType = dgvCarRental.Rows[i].Cells["colCarType"].Value.ToString();
                                hr.Peroid = dgvCarRental.Rows[i].Cells["colPeroid"].Value.ToString();
                                hr.CarNo = dgvCarRental.Rows[i].Cells["colCarNo"].Value.ToString();
                                hr.Amount = Decimal.Parse(dgvCarRental.Rows[i].Cells["colcAmount"].Value.ToString());
                                hr.Status = "B";
                                hr.User = Utility.Utility.User;
                                hr.IsDelete = false;

                                entity.AddToCarRentalDetail(hr);
                                entity.SaveChanges();
                            }
                        }
                        #endregion

                        MessageBox.Show("Booking Successful!", "Successful", MessageBoxButtons.OK);
                    }

                    else if (btnCBooking.Text == "Update")
                    {
                        string invoice = txtcInvoiceNo.Text;
                        #region"TicketBooking"
                        Connection.CarRentalBooking tb = new Connection.CarRentalBooking();
                        tb = entity.CarRentalBooking.Where(x => x.InvoiceNo == invoice && x.IsDelete == false).FirstOrDefault();
                        tb.InvoiceNo = txtcInvoiceNo.Text;
                        tb.SystemDate = DateTime.Now;
                        tb.ContactPerson = txtcContactPerson.Text;
                        tb.CompanyName = txtcCompanyName.Text;
                        tb.ContactPhone = txtcContactPhone.Text;
                        tb.Currency = cbocCurrency.SelectedValue.ToString();
                        tb.Rate = Int32.Parse(txtcRate.Text);
                        tb.PaymentTerm = cbocPayment.SelectedValue.ToString();
                        tb.Address = txtcAddress.Text;
                        tb.Email = txtcEmail.Text;
                        tb.t1 = this.cbocIncomeType.SelectedValue.ToString();
                        tb.t2 = this.txtcSupplier.Text;
                        tb.InvoiceDate = DateTime.Parse(dtpcInvoiceDate.Value.ToShortDateString());
                        tb.DepatureDate = DateTime.Parse(dtpcDepatureDate.Value.ToShortDateString());
                        tb.ArrivalDate = DateTime.Parse(dtpcArrivalDate.Value.ToShortDateString());
                        tb.TotalAmount = Decimal.Parse(txtcTotalAmount.Text == "" ? "0" : txtcTotalAmount.Text);
                        tb.ExtraCharges = Decimal.Parse(txtcExtraCharges.Text == "" ? "0" : txtcExtraCharges.Text);
                        tb.Balance = Decimal.Parse(txtcBalance.Text == "" ? "0" : txtcBalance.Text);
                        tb.Remark = txtcRemark.Text;
                        tb.Status = "U";
                        tb.User = Utility.Utility.User;
                        tb.IsDelete = false;

                        entity.SaveChanges();
                        #endregion

                        #region"CarRentalDetail"
                        if (dgvCarRental.Rows.Count > 0)
                        {
                            if (carrentalDeleteID.Count > 0)
                            {
                                for (int i = 0; i < carrentalDeleteID.Count; i++)
                                {
                                    Connection.CarRentalDetail tf = new Connection.CarRentalDetail();
                                    Int32 Id = Int32.Parse(carrentalDeleteID[i].ToString());
                                    tf = entity.CarRentalDetail.Where(x => x.ID == Id && x.IsDelete == false).FirstOrDefault();
                                    tf.IsDelete = true;
                                    entity.SaveChanges();
                                }
                            }
                            for (int i = 0; i < dgvCarRental.Rows.Count; i++)
                            {
                                if (dgvCarRental.Rows[i].Cells["colcID"].Value == null)
                                {
                                    Connection.CarRentalDetail hr = new Connection.CarRentalDetail();
                                    hr.InvoiceNo = txtcInvoiceNo.Text;
                                    hr.SystemDate = DateTime.Now;
                                    hr.CarType = dgvCarRental.Rows[i].Cells["colCarType"].Value.ToString();
                                    hr.Peroid = dgvCarRental.Rows[i].Cells["colPeroid"].Value.ToString();
                                    hr.CarNo = dgvCarRental.Rows[i].Cells["colCarNo"].Value.ToString();
                                    hr.Amount = Decimal.Parse(dgvCarRental.Rows[i].Cells["colcAmount"].Value.ToString());
                                    hr.Status = "B";
                                    hr.User = Utility.Utility.User;
                                    hr.IsDelete = false;

                                    entity.AddToCarRentalDetail(hr);
                                    entity.SaveChanges();
                                }
                                else
                                {
                                    Connection.CarRentalDetail hr = new Connection.CarRentalDetail();
                                    Int32 Id = Int32.Parse(dgvCarRental.Rows[i].Cells["colcID"].Value.ToString());
                                    hr = entity.CarRentalDetail.Where(x => x.ID == Id && x.IsDelete == false).FirstOrDefault();
                                    hr.InvoiceNo = txtcInvoiceNo.Text;
                                    hr.SystemDate = DateTime.Now;
                                    hr.CarType = dgvCarRental.Rows[i].Cells["colCarType"].Value.ToString();
                                    hr.Peroid = dgvCarRental.Rows[i].Cells["colPeroid"].Value.ToString();
                                    hr.CarNo = dgvCarRental.Rows[i].Cells["colCarNo"].Value.ToString();
                                    hr.Amount = Decimal.Parse(dgvCarRental.Rows[i].Cells["colcAmount"].Value.ToString());
                                    hr.User = Utility.Utility.User;
                                    hr.Status = "U";
                                    hr.IsDelete = false;

                                    entity.SaveChanges();
                                }
                            }
                        }
                        #endregion

                        MessageBox.Show("Update Successful!", "Successful", MessageBoxButtons.OK);
                    }
                    else if (btnCBooking.Text == "Issue")
                    {
                        string invoice = txtcInvoiceNo.Text;
                        Connection.CarRentalBooking tb = new Connection.CarRentalBooking();
                        tb = entity.CarRentalBooking.Where(x => x.InvoiceNo == invoice && x.IsDelete == false).FirstOrDefault();
                        tb.InvoiceNo = txtcInvoiceNo.Text;
                        tb.SystemDate = DateTime.Now;
                        tb.ContactPerson = txtcContactPerson.Text;
                        tb.CompanyName = txtcCompanyName.Text;
                        tb.ContactPhone = txtcContactPhone.Text;
                        tb.Currency = cbocCurrency.SelectedValue.ToString();
                        tb.Rate = Int32.Parse(txtcRate.Text);
                        tb.PaymentTerm = cbocPayment.SelectedValue.ToString();
                        tb.Address = txtcAddress.Text;
                        tb.Email = txtcEmail.Text;
                        tb.InvoiceDate = DateTime.Parse(dtpcInvoiceDate.Value.ToShortDateString());
                        tb.DepatureDate = DateTime.Parse(dtpcDepatureDate.Value.ToShortDateString());
                        tb.ArrivalDate = DateTime.Parse(dtpcArrivalDate.Value.ToShortDateString());
                        tb.TotalAmount = Decimal.Parse(txtcTotalAmount.Text == "" ? "0" : txtcTotalAmount.Text);
                        tb.ExtraCharges = Decimal.Parse(txtcExtraCharges.Text == "" ? "0" : txtcExtraCharges.Text);
                        tb.Balance = Decimal.Parse(txtcBalance.Text == "" ? "0" : txtcBalance.Text);
                        tb.Remark = txtcRemark.Text;
                        tb.Status = "I";
                        tb.User = Utility.Utility.User;
                        tb.IsDelete = false;

                        entity.SaveChanges();

                        MessageBox.Show("Confirm Successful!", "Successful", MessageBoxButtons.OK);
                        btncPreview_Click(sender, e);
                    }
                    carrentalDeleteID = new List<int>();
                    CleanCarRentalBooking();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else MessageBox.Show("Please fill information!", "Incomplete Information");
        }

        private void frmCarRental_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle); 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtcContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtcContactPhone.Focus();
            }
        }

        private void txtcContactPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtcCompanyName.Focus();
            }
        }

        private void txtcCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtcEmail.Focus();
            }
        }

        private void txtcEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtcAddress.Focus();
            }
        }

        private void txtcAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtcSupplier.Focus();
            }
        }

        private void dtpcInvoiceDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpcDepatureDate.Focus();
            }
        }

        private void dtpcDepatureDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpcArrivalDate.Focus();
            }
        }

        private void txtcRate_TextChanged(object sender, EventArgs e)
        {


        }

        private void cbocCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Currency = cbocCurrency.Text;
                Connection.Currency curr = new Connection.Currency();
                curr = entity.Currencies.Where(x => x.Code == Currency && x.IsDelete == false).FirstOrDefault();
                txtcRate.Text = curr.Rate.ToString();
                txtcRate.Focus();
            }
        }

        private void dtpcArrivalDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbocCurrency.Focus();
            }
        }

        private void txtcRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbocPayment.Focus();
            }
        }

        private void cbocPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbocIncomeType.Focus();
            }
        }

        private void txtcRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbocCarType.Focus();
            }
        }

        private void cbocCarType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbocPeroid.Focus();
            }
        }

        private void cbocPeroid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtcAmount.Focus();
            }
        }

        private void txtcAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtcCarNo.Focus();
            }
        }

        private void txtcCarNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btncAdd_Click(sender, e);
            }
        }

        private void txtcExtraCharges_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateCarRentalAmount();
            }
        }

        private bool CarRentalIsValid()
        {
            if (txtcContactPerson.Text == "" && dgvCarRental.Rows.Count == 0)
            {
                return false;
            }
            else return true;
        }

        private void dgvCarRental_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (dgvCarRental.CurrentRow.Cells["colcID"].Value != null)
                {
                    carrentalDeleteID.Add(Int32.Parse(dgvCarRental.CurrentRow.Cells["colcID"].Value.ToString()));
                }
                decimal amount = Decimal.Parse(dgvCarRental.CurrentRow.Cells["colcAmount"].Value.ToString());
                dgvCarRental.Rows.Remove(dgvCarRental.CurrentRow);
                decimal charges = Decimal.Parse(txtcExtraCharges.Text == "" ? "0" : txtcExtraCharges.Text);
                decimal totalamount = Decimal.Parse(txtcTotalAmount.Text == "" ? "0" : txtcTotalAmount.Text);
                txtcTotalAmount.Text = (totalamount - amount).ToString();
                txtcBalance.Text = ((totalamount - amount) - charges).ToString();
            }
        }

        private void dgvCarRental_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                decimal total = 0;
                for (int i = 0; i < dgvCarRental.Rows.Count; i++)
                {
                    total += Int32.Parse(dgvCarRental.Rows[i].Cells["colcAmount"].Value.ToString());
                }
                txtcTotalAmount.Text = total.ToString();
            }
        }

        private void btncCancel_Click(object sender, EventArgs e)
        {

        }

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

        private void cbocCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string Currency = cbocCurrency.Text;
            //if (cbocCurrency.DataSource != null)
            //{
            //    Connection.Currency curr = new Connection.Currency();
            //    curr = entity.Currencies.Where(x => x.Code == Currency && x.IsDelete == false).FirstOrDefault();
            //    txtcRate.Text = curr.Rate.ToString();
            //}
        }

        private void txtcSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpcInvoiceDate.Focus();
            }
        }

        private void cbocIncomeType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtcRemark.Focus();
            }
        }

    }
}
