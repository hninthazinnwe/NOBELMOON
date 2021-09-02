using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace NobelMoon.UI
{
    public partial class frmPassportList : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        public frmPassportList()
        {
            InitializeComponent();
        }

        private void frmPassportList_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);
        }

        private void frmPassportList_Load(object sender, EventArgs e)
        {
            LoadPassportBookingList();
        }

        private void LoadPassportBookingList()
        {
            dgvPassportBookingHistory.Rows.Clear();
            List<Connection.GetPassportHeaderReport_Result> tbList = entity.GetPassportHeaderReport().Where(x => Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) >= Convert.ToDateTime(dtpFrom.Value.ToShortDateString()) && Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) <= Convert.ToDateTime(dtpTo.Value.ToShortDateString())).ToList();
            for (int i = 0; i < tbList.Count; i++)
            {
                dgvPassportBookingHistory.Rows.Add(i + 1,tbList[i].InvoiceDate.Value.ToShortDateString(), tbList[i].InvoiceNo, tbList[i].ContactPerson, tbList[i].PaymentTerm, tbList[i].Currency, tbList[i].Rate, tbList[i].TotalAmount, tbList[i].Status);
            }
        }

        private void dgvPassportBookingHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string invoice = dgvPassportBookingHistory.CurrentRow.Cells["colInvoice"].Value.ToString();
                int count = (Int32)entity.SP_ChkTransactionForSaleEditDelete(invoice, "Passport").FirstOrDefault();
                if (count > 0)
                {
                    MessageBox.Show("Cann't Edit or Delete Transaction!", "This Transaction has Pay For Credit!");
                }
                else
                {
                    if (e.ColumnIndex == 9)
                    {
                        frmPassport newform = new frmPassport();
                        newform.InvoiceNo = invoice;
                        newform.IsEdit = true;
                        newform.btnPSave.Text = "Update";
                        this.Hide();
                        newform.ShowDialog();
                        this.Show();
                    }
                    if (e.ColumnIndex == 10)
                    {
                        if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Connection.PassportBooking tb = new Connection.PassportBooking();
                            tb = entity.PassportBookings.Where(x => x.InvoiceNo == invoice && x.IsDelete == false).FirstOrDefault();
                            if (tb != null)
                            {
                                tb.IsDelete = true;
                                entity.SaveChanges();
                            }

                            List<Connection.PassportPerson> tf = new List<Connection.PassportPerson>();
                            tf = entity.PassportPersons.Where(x => x.InvoiceNo == invoice && x.IsDelete == false).ToList();
                            if (tf.Count > 0)
                            {
                                for (int i = 0; i < tf.Count; i++)
                                {
                                    tf[i].IsDelete = true;
                                    entity.SaveChanges();
                                }
                            }

                            LoadPassportBookingList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dgvPassportBookingHistory.Rows.Clear();
                //List<Connection.PassportBooking> tbList = new List<Connection.PassportBooking>();
                //tbList = entity.PassportBookings.Where(x => x.IsDelete == false && Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) >= Convert.ToDateTime(dtpFrom.Value.ToShortDateString()) && Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) <= Convert.ToDateTime(dtpTo.Value.ToShortDateString())).ToList();
                List<Connection.GetPassportHeaderReport_Result> tbList = entity.GetPassportHeaderReport().Where(x => Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) >= Convert.ToDateTime(dtpFrom.Value.ToShortDateString()) && Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) <= Convert.ToDateTime(dtpTo.Value.ToShortDateString())).ToList();
                if (txtContactPerson.Text != "")
                {
                    string contact = txtContactPerson.Text;
                    tbList = tbList.Where(x => x.ContactPerson == contact).ToList();
                }
                if (cboStatus.Text == "Booking")
                {
                    string status = "B";
                    tbList = tbList.Where(x => x.Status == status).ToList();
                }
                else if (cboStatus.Text == "Issue")
                {
                    string status = "I";
                    tbList = tbList.Where(x => x.Status == status).ToList();
                }

                for (int i = 0; i < tbList.Count; i++)
                {
                    dgvPassportBookingHistory.Rows.Add(i + 1, tbList[i].InvoiceDate.Value.ToShortDateString(), tbList[i].InvoiceNo, tbList[i].ContactPerson, tbList[i].PaymentTerm, tbList[i].Currency, tbList[i].Rate, tbList[i].TotalAmount, tbList[i].Status);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
