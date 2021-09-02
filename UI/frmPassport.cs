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
using NobelMoon.Connection;

namespace NobelMoon.UI
{
    public partial class frmPassport : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        List<Int32> passportDeleteID = new List<Int32>();
        public bool IsEdit = false;
        public string InvoiceNo = "";
        public frmPassport()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #region "Passport Booking"
        private void CleanPassportBooking()
        {
            //txtPInvoice.Text = entity.GetFormNo("Passport").FirstOrDefault().ToString();
            txtPContactPerson.Text = "";
            txtPContactPhone.Text = "";
            dtpPInvoiceDate.Value = DateTime.Now;
            txtPRemark.Text = "";
            //cboPCurrency.SelectedIndex = 0;
            txtPCurrRate.Text = "1";
            cboPType.SelectedIndex = 0;
            txtpSupplier.Text = "";

            txtPName.Text = "";
            //dtpPBirthDate.Value = DateTime.Now;
            //txtPNRC.Text = "";
            //txtPPhone.Text = "";
            //txtPAddress.Text = "";
            txtCharges.Text = "0";
            txtPNo.Text = "0";
            txtPtotalamount.Text = "0";
            //txthSearch.Text = "";

            cboPPayment.DataSource = null;
            List<Connection.PaymentTerm> p = new List<Connection.PaymentTerm>();
            p = entity.PaymentTerms.Where(x => x.IsDelete == false).ToList();
            cboPPayment.DataSource = p;
            cboPPayment.DisplayMember = "Description";
            cboPPayment.ValueMember = "Code";
            cboPPayment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboPPayment.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboPCurrency.DataSource = null;
            List<Connection.Currency> cu = new List<Connection.Currency>();
            cu = entity.Currencies.Where(x => x.IsDelete == false).ToList();
            cboPCurrency.DataSource = cu;
            cboPCurrency.DisplayMember = "Code";
            cboPCurrency.ValueMember = "Code";
            cboPCurrency.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboPCurrency.AutoCompleteSource = AutoCompleteSource.ListItems;

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

            chkRequirement.Items.Clear();
            List<Connection.RequireLetter> req = new List<Connection.RequireLetter>();
            req = entity.RequireLetter.Where(x => x.IsDelete == false).ToList();
            foreach (Connection.RequireLetter var in req)
            {
                chkRequirement.Items.Add(var.Description);
            }
            chkRequirement.CheckOnClick = true;

            dgvPassport.Rows.Clear();
            //btnPPreview.Visible = false;
            if (InvoiceNo == "")
            {
                btnPSave.Text = "Booking";
            }
            cboPCurrency.Text = "MMK";
            txtPCurrRate.Text = "1";
            txtPContactPerson.Focus();
        }

        private void BindPassportBooking(string Invoice)
        {
            Connection.PassportBooking tb = new Connection.PassportBooking();
            tb = entity.PassportBookings.Where(x => x.InvoiceNo == Invoice && x.IsDelete == false).FirstOrDefault();
            if (tb != null)
            {
                txtPInvoice.Text = tb.InvoiceNo;
                txtPContactPerson.Text = tb.ContactPerson;
                txtPContactPhone.Text = tb.ContactPhone;
                cboPPayment.SelectedItem = tb.PaymentTerm;
                cboPCurrency.SelectedItem = tb.Currency;
                dtpPInvoiceDate.Value = (DateTime)tb.InvoiceDate;
                txtPRemark.Text = tb.Remark;
                this.cbopIncomeType.Text = tb.t1;
                this.txtpSupplier.Text = tb.t2;
                txtPCurrRate.Text = tb.Rate.ToString();
                cboPType.SelectedItem = tb.Type;
                txtPNo.Text = tb.TotalNo.ToString();
                txtPtotalamount.Text = tb.TotalAmount.ToString();
                //txtTSearch.Text = "";
            }

            List<Connection.PassportPerson> tf = new List<Connection.PassportPerson>();
            tf = entity.PassportPersons.Where(x => x.InvoiceNo == Invoice && x.IsDelete == false).ToList();
            if (tf.Count > 0)
            {
                dgvPassport.Rows.Clear();
                for (int i = 0; i < tf.Count; i++)
                {                    
                    dgvPassport.Rows.Add(i+1,tf[i].Name, tf[i].Charges, 0,tf[i].ID);
                }

            }

            if (chkRequirement.CheckedItems.Count == 0)
            {
                chkRequirement.Items.Clear();
                List<Connection.RequireLetter> req = new List<Connection.RequireLetter>();
                req = entity.RequireLetter.Where(x => (x.Type == tb.Type || x.Type == "Both") && x.IsDelete == false).ToList();
                List<Connection.ServicesOrRequirement> sr = new List<Connection.ServicesOrRequirement>();
                sr = entity.ServicesOrRequirement.Where(x => x.InvoiceNo == Invoice && x.Transaction == "Passport").ToList();
                string requirement = "";
                foreach (Connection.RequireLetter var in req)
                {
                    requirement = "";
                    for (int i = 0; i < sr.Count; i++)
                    {
                        if (var.Description == sr[i].Description)
                        {
                            requirement = sr[i].Description;
                        }
                    }
                    if (requirement != "")
                    {
                        chkRequirement.Items.Add(var.Description, CheckState.Checked);
                    }
                    else chkRequirement.Items.Add(var.Description);
                }
            }
            chkRequirement.CheckOnClick = true;
        }

        private void CalculatePassportAmount()
        {
            Decimal charge = Decimal.Parse(txtCharges.Text == "" ? "0" : txtCharges.Text);
            Int32 No = Int32.Parse(txtPNo.Text == "" ? "0" : txtPNo.Text);
            Decimal Amount = Decimal.Parse(txtPtotalamount.Text == "" ? "0" : txtPtotalamount.Text);
            txtPtotalamount.Text = (Amount + charge).ToString();
            txtPNo.Text = (No + 1).ToString();
        }

        #endregion

        private void btnPRequirement_Click(object sender, EventArgs e)
        {
            if (chkRequirement.Visible == false)
            {
                chkRequirement.Visible = true;
            }
            else chkRequirement.Visible = false;
        }

        private void chkRequirement_MouseLeave(object sender, EventArgs e)
        {
            chkRequirement.Visible = false;
        }

        private bool PassportIsValid()
        {
            if (txtPContactPerson.Text == "" && dgvPassport.Rows.Count == 0)
            {
                return false;
            }
            else return true;
        }

        private void btnPSave_Click(object sender, EventArgs e)
        {
            if (PassportIsValid() == true)
            {
                try
                {
                    if (btnPSave.Text == "Booking")
                    {
                        Connection.PassportBooking tb = new Connection.PassportBooking();
                        tb.InvoiceNo = txtPInvoice.Text;
                        tb.SystemDate = DateTime.Now;
                        tb.ContactPerson = txtPContactPerson.Text;
                        tb.ContactPhone = txtPContactPhone.Text;
                        tb.Currency = cboPCurrency.SelectedValue.ToString();
                        tb.Type = cboPType.SelectedItem.ToString();
                        tb.Rate = Int32.Parse(txtPCurrRate.Text);
                        tb.PaymentTerm = cboPPayment.SelectedValue.ToString();
                        tb.InvoiceDate = DateTime.Parse(dtpPInvoiceDate.Value.ToShortDateString());
                        tb.TotalNo = Int32.Parse(txtPNo.Text == "" ? "0" : txtPNo.Text);
                        tb.TotalAmount = Decimal.Parse(txtPtotalamount.Text == "" ? "0" : txtPtotalamount.Text);
                        tb.Remark = txtPRemark.Text;
                        tb.t1 = this.cbopIncomeType.SelectedValue.ToString();
                        tb.t2 = this.txtpSupplier.Text;
                        tb.MMKBalance = CalculateMMKAmount(Convert.ToInt32(tb.Rate), Convert.ToDecimal(tb.TotalAmount));
                        tb.Status = "B";
                        tb.User = Utility.Utility.User;
                        tb.IsDelete = false;

                        entity.AddToPassportBookings(tb);
                        entity.SaveChanges();

                        #region"PassportPeron"
                        if (dgvPassport.Rows.Count > 0)
                        {
                            for (int i = 0; i < dgvPassport.Rows.Count; i++)
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
                        #endregion

                        #region "Services&Requirement"

                        Connection.ServicesOrRequirement sr = new Connection.ServicesOrRequirement();
                        Connection.RequireLetter s = new Connection.RequireLetter();
                        foreach (string var in chkRequirement.CheckedItems)
                        {
                            string services = var.ToString();
                            s = entity.RequireLetter.Where(x => x.Description == services && x.IsDelete == false).FirstOrDefault();
                            sr = new Connection.ServicesOrRequirement();
                            sr.CreatedDate = DateTime.Now;
                            sr.Code = s.Code;
                            sr.Description = s.Description;
                            sr.InvoiceNo = txtPInvoice.Text;
                            sr.Transaction = "Passport";
                            sr.User = Utility.Utility.User;
                            entity.AddToServicesOrRequirement(sr);
                            entity.SaveChanges();
                        }
                        #endregion

                        MessageBox.Show("Booking Successful!", "Successful", MessageBoxButtons.OK);
                    }

                    else if (btnPSave.Text == "Update")
                    {
                        string invoice = txtPInvoice.Text;
                        #region"PassportBooking"
                        Connection.PassportBooking tb = new Connection.PassportBooking();
                        tb = entity.PassportBookings.Where(x => x.InvoiceNo == invoice && x.IsDelete == false).FirstOrDefault();
                        tb.InvoiceNo = txtPInvoice.Text;
                        tb.SystemDate = DateTime.Now;
                        tb.ContactPerson = txtPContactPerson.Text;
                        tb.ContactPhone = txtPContactPhone.Text;
                        tb.t1 = this.cbopIncomeType.SelectedValue.ToString();
                        tb.t2 = this.txtpSupplier.Text;
                        tb.Currency = cboPCurrency.SelectedValue.ToString();
                        tb.Type = cboPType.SelectedItem.ToString();
                        tb.Rate = Int32.Parse(txtPCurrRate.Text);
                        tb.PaymentTerm = cboPPayment.SelectedValue.ToString();
                        tb.InvoiceDate = DateTime.Parse(dtpPInvoiceDate.Value.ToShortDateString());
                        tb.TotalNo = Int32.Parse(txtPNo.Text == "" ? "0" : txtPNo.Text);
                        tb.TotalAmount = Decimal.Parse(txtPtotalamount.Text == "" ? "0" : txtPtotalamount.Text);
                        tb.Remark = txtPRemark.Text;
                        tb.MMKBalance = CalculateMMKAmount(Convert.ToInt32(tb.Rate), Convert.ToDecimal(tb.TotalAmount));
                        tb.Status = "U";
                        tb.User = Utility.Utility.User;
                        tb.IsDelete = false;

                        entity.SaveChanges();
                        #endregion

                        #region"PassportPeron"
                        if (dgvPassport.Rows.Count > 0)
                        {
                            if (passportDeleteID.Count > 0)
                            {
                                for (int i = 0; i < passportDeleteID.Count; i++)
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
                            for (int i = 0; i < dgvPassport.Rows.Count; i++)
                            {
                                if (dgvPassport.Rows[i].Cells["colPassID"].Value == null)
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
                                    Connection.PassportPerson hr = new Connection.PassportPerson();
                                    Int32 Id = Int32.Parse(dgvPassport.Rows[i].Cells["colPassID"].Value.ToString());
                                    hr.InvoiceNo = this.txtPInvoice.Text;
                                    hr.SystemDate = new DateTime?(DateTime.Now);
                                    hr.Name = this.dgvPassport.Rows[i].Cells["colName"].Value.ToString();
                                    hr.Charges = new decimal?(decimal.Parse(this.dgvPassport.Rows[i].Cells["colCharges"].Value.ToString()));
                                    hr.Status = "B";
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
                        Connection.RequireLetter s = new Connection.RequireLetter();
                        string invoiceno = txtPInvoice.Text;
                        sq = entity.ServicesOrRequirement.Where(x => x.InvoiceNo == invoiceno && x.Transaction == "Passport").ToList();
                        for (int i = 0; i < sq.Count; i++)
                        {
                            Int32 id = sq[i].ID;
                            sr = new Connection.ServicesOrRequirement();
                            sr = entity.ServicesOrRequirement.Where(x => x.ID == id).FirstOrDefault();
                            entity.ServicesOrRequirement.DeleteObject(sr);
                            entity.SaveChanges();
                        }

                        foreach (string var in chkRequirement.CheckedItems)
                        {
                            string services = var.ToString();
                            s = entity.RequireLetter.Where(x => x.Description == services && x.IsDelete == false).FirstOrDefault();
                            sr = new Connection.ServicesOrRequirement();
                            sr.CreatedDate = DateTime.Now;
                            sr.Code = s.Code;
                            sr.Description = s.Description;
                            sr.InvoiceNo = txtPInvoice.Text;
                            sr.Transaction = "Passport";
                            sr.User = Utility.Utility.User;
                            entity.AddToServicesOrRequirement(sr);
                            entity.SaveChanges();
                        }
                        #endregion

                        MessageBox.Show("Update Successful!", "Successful", MessageBoxButtons.OK);
                    }
                    else if (btnPSave.Text == "Issue")
                    {
                        #region"PassportBooking"
                        string invoice = txtPInvoice.Text;
                        Connection.PassportBooking tb = new Connection.PassportBooking();
                        tb = entity.PassportBookings.Where(x => x.InvoiceNo == invoice && x.IsDelete == false).FirstOrDefault();
                        tb.InvoiceNo = txtPInvoice.Text;
                        tb.SystemDate = DateTime.Now;
                        tb.ContactPerson = txtPContactPerson.Text;
                        tb.ContactPhone = txtPContactPhone.Text;
                        tb.Currency = cboPCurrency.SelectedValue.ToString();
                        tb.Type = cboPType.SelectedItem.ToString();
                        tb.Rate = Int32.Parse(txtPCurrRate.Text);
                        tb.PaymentTerm = cboPPayment.SelectedValue.ToString();
                        tb.InvoiceDate = DateTime.Parse(dtpPInvoiceDate.Value.ToShortDateString());
                        tb.TotalNo = Int32.Parse(txtPNo.Text == "" ? "0" : txtPNo.Text);
                        tb.TotalAmount = Decimal.Parse(txtPtotalamount.Text == "" ? "0" : txtPtotalamount.Text);
                        tb.Remark = txtPRemark.Text;
                        tb.MMKBalance = CalculateMMKAmount(Convert.ToInt32(tb.Rate), Convert.ToDecimal(tb.TotalAmount));
                        tb.Status = "I";
                        tb.User = Utility.Utility.User;
                        tb.IsDelete = false;

                        entity.SaveChanges();
                        #endregion

                        MessageBox.Show("Confirm Successful!", "Successful", MessageBoxButtons.OK);
                        btnPPreview_Click(sender, e);
                    }
                    passportDeleteID = new List<int>();
                    CleanPassportBooking();
                    //LoadPassportBookingList();

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

        private void btnPCancel_Click(object sender, EventArgs e)
        {
            CleanPassportBooking();
        }

        private void frmPassport_Load(object sender, EventArgs e)
        {
            if (IsEdit == true)
            {
                CleanPassportBooking();
                BindPassportBooking(InvoiceNo);
            }
        }

        private void frmPassport_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle); 
        }

        private void txtPContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPContactPhone.Focus();
            }
        }

        private void txtPContactPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboPPayment.Focus();
            }
        }

        private void cboPPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbopIncomeType.Focus();
            }
        }

        private void dtpPInvoiceDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboPType.Focus();
            }
        }

        private void cboPType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chkRequirement.Items.Clear();
                List<Connection.RequireLetter> req = new List<Connection.RequireLetter>();
                string type = cboPType.SelectedItem.ToString();
                req = entity.RequireLetter.Where(x => x.IsDelete == false && (x.Type == type || x.Type == "Both")).ToList();
                foreach (Connection.RequireLetter var in req)
                {
                    chkRequirement.Items.Add(var.Description);
                }
                cboPCurrency.Focus();
            }
        }

        private void cboPCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Currency = cboPCurrency.Text;
                Connection.Currency curr = new Connection.Currency();
                curr = entity.Currencies.Where(x => x.Code == Currency && x.IsDelete == false).FirstOrDefault();
                txtPCurrRate.Text = curr.Rate.ToString();
                txtPCurrRate.Focus();
            }
        }

        private void txtPCurrRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtpSupplier.Focus();
            }
        }

        private void txtPRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPName.Focus();
            }
        }

        private void txtPName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCharges.Focus();
            }
        }

        //private void dtpPBirthDate_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        txtPNRC.Focus();
        //    }
        //}

        //private void txtPNRC_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        txtPPhone.Focus();
        //    }
        //}

        //private void txtPPhone_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        txtPAddress.Focus();
        //    }
        //}

        private void txtPAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCharges.Focus();
            }
        }

        private void txtCharges_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPassportAdd_Click(sender, e);
            }
        }

        private void btnPassportAdd_Click(object sender, EventArgs e)
        {
            string name = txtPName.Text;
            //string dob = dtpPBirthDate.Value.ToShortDateString();
            //string nrc = txtPNRC.Text;
            //string phone = txtPPhone.Text;
            //string address = txtPAddress.Text;
            string requirement = "";
            decimal charge = Decimal.Parse(txtCharges.Text == "" ? "0" : txtCharges.Text);

            //foreach (string var in chkRequirement.CheckedItems)
            //{
            //    requirement += var.ToString() + "၊ ";
            //}

            dgvPassport.Rows.Add(name, charge);

            CalculatePassportAmount();
            txtPName.Text = "";
            //dtpPBirthDate.Value = DateTime.Now;
            //txtPNRC.Text = "";
            //txtPPhone.Text = "";
            //chkRequirement.Items.Clear();
            //List<Connection.RequireLetter> req = new List<Connection.RequireLetter>();
            //req = entity.RequireLetter.Where(x => x.IsDelete == false).ToList();
            //foreach (Connection.RequireLetter var in req)
            //{
            //    chkRequirement.Items.Add(var.Description);
            //}
            //txtPAddress.Text = "";
            txtCharges.Text = "0";
        }

        private void dgvPassport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (dgvPassport.CurrentRow.Cells["colPassID"].Value != null)
                {
                    passportDeleteID.Add(Int32.Parse(dgvPassport.CurrentRow.Cells["colPassID"].Value.ToString()));
                }
                decimal charges = Decimal.Parse(dgvPassport.CurrentRow.Cells["colCharges"].Value.ToString());
                dgvPassport.Rows.Remove(dgvPassport.CurrentRow);
                Int32 no = Int32.Parse(txtPNo.Text == "" ? "0" : txtPNo.Text);
                decimal totalamount = Decimal.Parse(txtPtotalamount.Text == "" ? "0" : txtPtotalamount.Text);
                txtPNo.Text = (no - 1).ToString();
                txtPtotalamount.Text = (totalamount - charges).ToString();
            }
        }

        private void dgvPassport_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                decimal total = 0;
                for (int i = 0; i < dgvPassport.Rows.Count; i++)
                {
                    total += Int32.Parse(dgvPassport.Rows[i].Cells["colCharges"].Value.ToString());
                }
                txtPtotalamount.Text = total.ToString();
            }
        }

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
            dataTable.Columns.Add(new DataColumn("t1", typeof(string)));
            dataTable.Columns.Add(new DataColumn("TotalNo", typeof(int)));
            dataTable.Columns.Add(new DataColumn("TotalAmount", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
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

        private void cboPType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkRequirement.CheckedItems.Count == 0)
            {
                chkRequirement.Items.Clear();
                List<Connection.RequireLetter> req = new List<Connection.RequireLetter>();
                string type = cboPType.SelectedItem.ToString();
                req = entity.RequireLetter.Where(x => x.IsDelete == false && (x.Type == type || x.Type == "Both")).ToList();
                foreach (Connection.RequireLetter var in req)
                {
                    chkRequirement.Items.Add(var.Description);
                }
            }
        }

        private void cbopIncomeType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpPInvoiceDate.Focus();
            }
        }

        private void txtpSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtpSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPRemark.Focus();
            }
        }
    }
}
