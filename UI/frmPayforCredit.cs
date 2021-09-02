using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NobelMoon.Connection;
using System.Drawing.Drawing2D;
using CrystalDecisions.CrystalReports.Engine;


namespace NobelMoon.UI
{
    public partial class frmPayforCredit : Form
    {
        private NobelMoonEntities1 entity = new NobelMoonEntities1();

        private string Invoice = "";
        private string CName = "";
        private string currency = "";
        private string transaction = "";
        private decimal Amount = 0;
        private decimal PaidAmt = 0;
        public bool IsEdit = false;
        public string VoucherNo = "";

        public frmPayforCredit()
        {
            InitializeComponent();
        }
        public frmPayforCredit(string invoiceno, string name, decimal amount, decimal paidamt, string Currency, string tran)
		{
			this.Invoice = invoiceno;
			this.CName = name;
			this.Amount = amount;
			this.currency = Currency;
			this.transaction = tran;
			this.PaidAmt = paidamt;
			this.InitializeComponent();
		}

		private void BindPayforCredit(string Voucher)
		{
			PayforCredit payforCredit = new PayforCredit();
			payforCredit = (from x in this.entity.PayforCredit
			where x.VoucherNo == Voucher && x.IsDelete == (bool?)false
			select x).FirstOrDefault<PayforCredit>();
			if (payforCredit != null)
			{
				this.txtDocNo.Text = payforCredit.VoucherNo;
				this.dtpDate.Value = payforCredit.Date.Value;
				this.txtVoucherNo.Text = payforCredit.InvoiceNo;
				this.txtContactPerson.Text = payforCredit.ContactPerson;
				this.txtCreditAmount.Text = payforCredit.CreditAmount.ToString();
				this.lblCurrency.Text = payforCredit.Currency;
				this.txtRate.Text = payforCredit.Rate.ToString();
				this.txtPaidAmount.Text = payforCredit.Amount.ToString();
				this.transaction = payforCredit.Transaction;
			}
		}

		private void frmPayforCredit_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
			Brush brush = new LinearGradientBrush(rect, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
			graphics.FillRectangle(brush, rect);
		}

		// Token: 0x06000BC8 RID: 3016 RVA: 0x0004F5AF File Offset: 0x0004D7AF
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000BC9 RID: 3017 RVA: 0x0004F5BC File Offset: 0x0004D7BC
		private void frmPayforCredit_Load(object sender, EventArgs e)
		{
			if (this.VoucherNo != "")
			{
				this.BindPayforCredit(this.VoucherNo);
			}
			else
			{
				this.LoadPayforCredit();
			}
		}

		// Token: 0x06000BCA RID: 3018 RVA: 0x0004F5FC File Offset: 0x0004D7FC
		private void LoadPayforCredit()
		{
			this.txtDocNo.Text = this.entity.GetFormNo("payforcredit").FirstOrDefault<string>().ToString();
			this.dtpDate.Value = DateTime.Now;
			this.txtVoucherNo.Text = this.Invoice;
			this.txtContactPerson.Text = this.CName;
			this.txtCreditAmount.Text = (this.Amount - this.PaidAmt).ToString();
			this.lblCurrency.Text = this.currency;
			this.txtPaidAmount.Focus();
		}

		// Token: 0x06000BCB RID: 3019 RVA: 0x0004F6A8 File Offset: 0x0004D8A8
		private void txtPaidAmount_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.txtRate.Select();
				this.txtRate.Focus();
			}
		}

		// Token: 0x06000BCC RID: 3020 RVA: 0x0004F6E4 File Offset: 0x0004D8E4
		private void txtRate_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.txtRemark.Focus();
			}
		}

		// Token: 0x06000BCD RID: 3021 RVA: 0x0004F714 File Offset: 0x0004D914
		private void txtRemark_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.btnSave_Click(sender, e);
			}
		}

		// Token: 0x06000BCE RID: 3022 RVA: 0x0004F73E File Offset: 0x0004D93E
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Clear();
		}

		// Token: 0x06000BCF RID: 3023 RVA: 0x0004F748 File Offset: 0x0004D948
		private void Clear()
		{
			this.txtDocNo.Text = this.entity.GetFormNo("payforcredit").FirstOrDefault<string>().ToString();
			this.dtpDate.Value = DateTime.Now;
			this.txtVoucherNo.Text = "";
			this.txtContactPerson.Text = "";
			this.txtCreditAmount.Text = "0";
			this.lblCurrency.Text = "-";
			this.txtPaidAmount.Text = "0";
		}

		// Token: 0x06000BD0 RID: 3024 RVA: 0x0004F7E4 File Offset: 0x0004D9E4
		private void btnSave_Click(object sender, EventArgs e)
		{
			if (this.btnSave.Text == "Save")
			{
				PayforCredit newform = new PayforCredit();
				newform.CreatedDate = new DateTime?(DateTime.Now);
				newform.Date = new DateTime?(this.dtpDate.Value);
				newform.VoucherNo = this.txtDocNo.Text;
				newform.InvoiceNo = this.txtVoucherNo.Text;
				newform.ContactPerson = this.txtContactPerson.Text;
				newform.Currency = this.lblCurrency.Text;
				newform.Rate = new decimal?(decimal.Parse(this.txtRate.Text));
				newform.Amount = new decimal?(decimal.Parse(this.txtPaidAmount.Text));
				newform.CreditAmount = new decimal?(decimal.Parse(this.txtCreditAmount.Text));
				newform.MMKBalance = newform.Rate * newform.Amount;
				newform.Remark = this.txtRemark.Text;
				newform.Transaction = this.transaction;
				newform.UserID = Utility.Utility.User;
				newform.IsDelete = new bool?(false);
				this.entity.AddToPayforCredit(newform);
				this.entity.SaveChanges();
				MessageBox.Show("PayforCredit is Successfully Saved.", "Successful!");
				base.Close();
			}
			else
			{
				PayforCredit newform = new PayforCredit();
				newform = (from x in this.entity.PayforCredit
				where x.VoucherNo == this.VoucherNo && x.IsDelete == (bool?)false && x.Transaction == this.transaction
				select x).FirstOrDefault<PayforCredit>();
				newform.Date = new DateTime?(this.dtpDate.Value);
				newform.VoucherNo = this.txtDocNo.Text;
				newform.InvoiceNo = this.txtVoucherNo.Text;
				newform.ContactPerson = this.txtContactPerson.Text;
				newform.Currency = this.lblCurrency.Text;
				newform.Rate = new decimal?(decimal.Parse(this.txtRate.Text));
				newform.Amount = new decimal?(decimal.Parse(this.txtPaidAmount.Text));
				newform.MMKBalance = newform.Rate * newform.Amount;
				newform.Remark = this.txtRemark.Text;
				newform.Transaction = this.transaction;
				newform.UserID = Utility.Utility.User;
				this.entity.SaveChanges();
				MessageBox.Show("PayforCredit is Successfully Updated.", "Successful!");
				base.Close();
			}
			this.PrintVoucher();
		}

		// Token: 0x06000BD1 RID: 3025 RVA: 0x0004FBFC File Offset: 0x0004DDFC
		private void PrintVoucher()
		{
			DataSet tbList = new DataSet();
			DataTable dataTable = new DataTable("PayforCredit");
			dataTable.Columns.Add(new DataColumn("Date", typeof(DateTime)));
			dataTable.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ContactPerson", typeof(string)));
			dataTable.Columns.Add(new DataColumn("VoucherNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CreditAmount", typeof(decimal)));
			dataTable.Columns.Add(new DataColumn("Currency", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PaidAmount", typeof(decimal)));
			dataTable.Columns.Add(new DataColumn("Rate", typeof(decimal)));
			DataRow dataRow = dataTable.NewRow();
			dataRow["Date"] = this.dtpDate.Value;
			dataRow["InvoiceNo"] = this.txtVoucherNo.Text;
			dataRow["ContactPerson"] = this.txtContactPerson.Text;
			dataRow["VoucherNo"] = this.txtVoucherNo.Text;
			dataRow["CreditAmount"] = this.txtCreditAmount.Text;
			dataRow["Currency"] = this.lblCurrency.Text;
			dataRow["PaidAmount"] = this.txtPaidAmount.Text;
			dataRow["Rate"] = this.txtRate.Text;
			dataTable.Rows.Add(dataRow);
			tbList.Tables.Add(dataTable);
			ReportDocument reportDocument = new ReportDocument();
			tbList.WriteXmlSchema(Application.StartupPath + "\\DataSets\\NobelMoon.xsd");
			reportDocument.Load(Application.StartupPath + "\\Reports\\PayforCredit.rpt");
			reportDocument.SetDataSource(tbList);
			frmReport i = new frmReport();
			i.reportViewer1.ReportSource = reportDocument;
			i.reportViewer1.Refresh();
			i.Show();
			base.UseWaitCursor = false;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
