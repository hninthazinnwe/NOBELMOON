using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NobelMoon.Connection;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Drawing2D;

namespace NobelMoon.UI
{
    public partial class frmPayforCreditHistory : Form
    {
        private NobelMoonEntities1 entity = new NobelMoonEntities1();
        public frmPayforCreditHistory()
        {
            InitializeComponent();
        }
        private void frmPayforCreditHistory_Paint(object sender, PaintEventArgs e)
        {
            Graphics tbList = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
            Brush type = new LinearGradientBrush(rect, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            tbList.FillRectangle(type, rect);
        }

        // Token: 0x06000CB8 RID: 3256 RVA: 0x00064D7F File Offset: 0x00062F7F
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadPayforCreditHistory();
        }

        // Token: 0x06000CB9 RID: 3257 RVA: 0x00064E24 File Offset: 0x00063024
        private void LoadPayforCreditHistory()
        {
            try
            {
                this.dgvPayforCredit.Rows.Clear();
                DateTime todate = this.dtpTo.Value.Date.AddDays(1.0);
                List<PayforCredit> newform = (from x in this.entity.PayforCredit
                                              where x.Date >= (DateTime?)this.dtpFrom.Value.Date && x.Date <= (DateTime?)todate.Date && x.IsDelete == (bool?)false
                                              select x).ToList<PayforCredit>();
                if (this.txtContactPerson.Text != "")
                {
                    string contact = this.txtContactPerson.Text;
                    newform = (from x in newform
                               where x.ContactPerson.Contains(contact)
                               select x).ToList<PayforCredit>();
                }
                else if (this.cboType.Text == "Passport/Visa")
                {
                    string tb = this.cboType.Text;
                    newform = (from x in newform
                               where x.Transaction == "Passport" || x.Transaction == "Visa"
                               select x).ToList<PayforCredit>();
                }
                else if (this.cboType.Text != "ALL" && this.cboType.Text != "")
                {
                    string type = this.cboType.Text;
                    newform = (from x in newform
                               where x.Transaction == type
                               select x).ToList<PayforCredit>();
                }
                for (int ex = 0; ex < newform.Count; ex++)
                {
                    this.dgvPayforCredit.Rows.Add(new object[]
					{
						ex + 1,
						newform[ex].Date.Value.ToShortDateString(),
						newform[ex].VoucherNo,
						newform[ex].ContactPerson,
						newform[ex].Amount,
						newform[ex].Currency,
						newform[ex].Rate,
						newform[ex].Transaction
					});
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.ToString());
            }
        }

        // Token: 0x06000CBA RID: 3258 RVA: 0x0006522C File Offset: 0x0006342C
        private void frmPayforCreditHistory_Load(object sender, EventArgs e)
        {
            this.LoadPayforCreditHistory();
        }

        // Token: 0x06000CBB RID: 3259 RVA: 0x00065240 File Offset: 0x00063440
        private void dgvPayforCredit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 8)
                {
                    frmPayforCredit frmPayforCredit = new frmPayforCredit();
                    string voucherNo = this.dgvPayforCredit.CurrentRow.Cells["colVoucher"].Value.ToString();
                    frmPayforCredit.VoucherNo = voucherNo;
                    frmPayforCredit.IsEdit = true;
                    frmPayforCredit.btnSave.Text = "Update";
                    base.Hide();
                    frmPayforCredit.ShowDialog();
                    base.Show();
                }
                if (e.ColumnIndex == 9)
                {
                    string invoice = this.dgvPayforCredit.CurrentRow.Cells["colVoucher"].Value.ToString();
                    if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PayforCredit payforCredit = new PayforCredit();
                        payforCredit = (from x in this.entity.PayforCredit
                                        where x.VoucherNo == invoice && x.IsDelete == (bool?)false
                                        select x).FirstOrDefault<PayforCredit>();
                        if (payforCredit != null)
                        {
                            payforCredit.IsDelete = new bool?(true);
                            this.entity.SaveChanges();
                        }
                        this.LoadPayforCreditHistory();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Token: 0x06000CBC RID: 3260 RVA: 0x000654F0 File Offset: 0x000636F0
        private void btnPreview_Click(object sender, EventArgs e)
        {
            DateTime todate = this.dtpTo.Value.Date.AddDays(1.0);
            List<PayforCredit> dataGridViewCellStyle3 = (from x in this.entity.PayforCredit
                                                         where x.Date >= (DateTime?)this.dtpFrom.Value.Date && x.Date <= (DateTime?)todate.Date && x.IsDelete == (bool?)false
                                                         select x).ToList<PayforCredit>();
            if (this.txtContactPerson.Text != "")
            {
                string contact = this.txtContactPerson.Text;
                dataGridViewCellStyle3 = (from x in dataGridViewCellStyle3
                                          where x.ContactPerson == contact
                                          select x).ToList<PayforCredit>();
            }
            if (this.cboType.Text != "ALL" && this.cboType.Text != "")
            {
                string type = this.cboType.Text;
                dataGridViewCellStyle3 = (from x in dataGridViewCellStyle3
                                          where x.Transaction == type
                                          select x).ToList<PayforCredit>();
            }
            else if (this.cboType.Text == "Passport/Visa")
            {
                string text = this.cboType.Text;
                dataGridViewCellStyle3 = (from x in dataGridViewCellStyle3
                                          where x.Transaction == "Passport" || x.Transaction == "Visa"
                                          select x).ToList<PayforCredit>();
            }
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable("PayforCredit");
            dataTable.Columns.Add(new DataColumn("Date", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
            dataTable.Columns.Add(new DataColumn("ContactPerson", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Transaction", typeof(string)));
            dataTable.Columns.Add(new DataColumn("VoucherNo", typeof(string)));
            dataTable.Columns.Add(new DataColumn("CreditAmount", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("Currency", typeof(string)));
            dataTable.Columns.Add(new DataColumn("PaidAmount", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("Rate", typeof(decimal)));
            for (int i = 0; i < dataGridViewCellStyle3.Count; i++)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["Date"] = dataGridViewCellStyle3[i].Date;
                dataRow["InvoiceNo"] = dataGridViewCellStyle3[i].InvoiceNo;
                dataRow["ContactPerson"] = dataGridViewCellStyle3[i].ContactPerson;
                dataRow["Transaction"] = dataGridViewCellStyle3[i].ContactPerson;
                dataRow["VoucherNo"] = dataGridViewCellStyle3[i].VoucherNo;
                dataRow["CreditAmount"] = dataGridViewCellStyle3[i].CreditAmount;
                dataRow["Currency"] = dataGridViewCellStyle3[i].Currency;
                dataRow["PaidAmount"] = dataGridViewCellStyle3[i].Amount;
                dataRow["Rate"] = dataGridViewCellStyle3[i].Rate;
                dataTable.Rows.Add(dataRow);
            }
            dataSet.Tables.Add(dataTable);
            ReportDocument reportDocument = new ReportDocument();
            dataSet.WriteXmlSchema(Application.StartupPath + "\\DataSets\\NobelMoon.xsd");
            reportDocument.Load(Application.StartupPath + "\\Reports\\PayforCreditHistoty.rpt");
            reportDocument.SetDataSource(dataSet);
            frmReport frmReport = new frmReport();
            frmReport.reportViewer1.ReportSource = reportDocument;
            frmReport.reportViewer1.Refresh();
            frmReport.Show();
            base.UseWaitCursor = false;
        }
    }
}
