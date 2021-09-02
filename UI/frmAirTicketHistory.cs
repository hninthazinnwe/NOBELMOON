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
    public partial class frmAirTicketHistory : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        public frmAirTicketHistory()
        {
            InitializeComponent();
        }

        private void frmAirTicketHistory_Load(object sender, EventArgs e)
        {
            LoadBookingList();
        }

        private void LoadBookingList()
        {
            dgvAirTicketHistory.Rows.Clear();
            List<NobelMoon.Connection.GetAirTicketHeaderReport_Result> tbList = entity.GetAirTicketHeaderReport().Where(x => Convert.ToDateTime(x.Date.Value.ToShortDateString()) >= Convert.ToDateTime(dtpFrom.Value.ToShortDateString()) && Convert.ToDateTime(x.Date.Value.ToShortDateString()) <= Convert.ToDateTime(dtpTo.Value.ToShortDateString())).ToList();
                
            for (int i = 0; i < tbList.Count; i++)
            {
                dgvAirTicketHistory.Rows.Add(i + 1, tbList[i].Date.Value.ToShortDateString(), tbList[i].InvoiceNo, tbList[i].CompanyName, tbList[i].ContactPerson, tbList[i].PaymentDes, tbList[i].Currency, tbList[i].Rate, tbList[i].Tax, tbList[i].Total);
            }
        }

        private void dgvAirTicketHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string invoice = dgvAirTicketHistory.CurrentRow.Cells["colInvoice"].Value.ToString();
                int count = (Int32)entity.SP_ChkTransactionForSaleEditDelete(invoice, "Ticketing").FirstOrDefault();
                if (count > 0)
                {
                    MessageBox.Show("Cann't Edit or Delete Transaction!", "This Transaction has Pay For Credit!");
                }
                else
                {
                    if (e.ColumnIndex == 11)
                    {
                        frmAirTicket newform = new frmAirTicket();
                        newform.InvoiceNo = invoice;
                        newform.IsEdit = true;
                        newform.btnBooking.Text = "Update";
                        this.Hide();
                        newform.ShowDialog();
                        this.Show();
                    }
                    if (e.ColumnIndex == 12)
                    {
                        if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Connection.TicketBooking tb = new Connection.TicketBooking();
                            tb = entity.TicketBookings.Where(x => x.InvoiceNo == invoice && x.IsDelete == false).FirstOrDefault();
                            if (tb != null)
                            {
                                tb.IsDelete = true;
                                entity.SaveChanges();
                            }

                            List<Connection.TicketFlight> tf = new List<Connection.TicketFlight>();
                            tf = entity.TicketFlights.Where(x => x.InvoiceNo == invoice && x.IsDelete == false).ToList();
                            if (tf.Count > 0)
                            {
                                for (int i = 0; i < tf.Count; i++)
                                {
                                    tf[i].IsDelete = true;
                                    entity.SaveChanges();
                                }
                            }

                            List<Connection.TicketPassenger> tp = new List<Connection.TicketPassenger>();
                            tp = entity.TicketPassengers.Where(x => x.InvoiceNo == invoice && x.IsDelete == false).ToList();
                            if (tp.Count > 0)
                            {
                                for (int i = 0; i < tf.Count; i++)
                                {
                                    tp[i].IsDelete = true;
                                    entity.SaveChanges();
                                }
                            }

                            LoadBookingList();
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
                dgvAirTicketHistory.Rows.Clear();
                List<NobelMoon.Connection.GetAirTicketHeaderReport_Result> tbList = entity.GetAirTicketHeaderReport().Where(x => Convert.ToDateTime(x.Date.Value.ToShortDateString()) >= Convert.ToDateTime(dtpFrom.Value.ToShortDateString()) && Convert.ToDateTime(x.Date.Value.ToShortDateString()) <= Convert.ToDateTime(dtpTo.Value.ToShortDateString())).ToList();
                
                if (txtCompanyName.Text != "")
                {
                    string company = txtCompanyName.Text;
                    tbList = tbList.Where(x => x.CompanyName == company).ToList();
                }
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
                    dgvAirTicketHistory.Rows.Add(i + 1, tbList[i].Date.Value.ToShortDateString(), tbList[i].InvoiceNo, tbList[i].CompanyName, tbList[i].ContactPerson, tbList[i].PaymentDes, tbList[i].Currency, tbList[i].Rate, tbList[i].Tax, tbList[i].Total);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAirTicketHistory_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle); 
        }
    }
}
