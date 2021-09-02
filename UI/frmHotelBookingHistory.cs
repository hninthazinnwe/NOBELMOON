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
    public partial class frmHotelBookingHistory : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        public frmHotelBookingHistory()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvHotelBookingHistory.Rows.Clear();
            List<NobelMoon.Connection.GetHotelBookingHeaderReport_Result> tbList = entity.GetHotelBookingHeaderReport().Where(x => Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) >= Convert.ToDateTime(dtpFrom.Value.ToShortDateString()) && Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) <= Convert.ToDateTime(dtpTo.Value.ToShortDateString())).ToList();
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
                dgvHotelBookingHistory.Rows.Add(i + 1, tbList[i].InvoiceDate.Value.ToShortDateString(), tbList[i].InvoiceNo, tbList[i].CompanyName, tbList[i].ContactPerson, "", tbList[i].Currency, tbList[i].Rate, tbList[i].NoofPax, tbList[i].NoofNight, tbList[i].TotalRoom, tbList[i].Balance);
            }          
        }

        private void frmHotelBookingHistory_Load(object sender, EventArgs e)
        {
            LoadHotelBookingList();
        }
        private void LoadHotelBookingList()
        {
            dgvHotelBookingHistory.Rows.Clear();
            List<NobelMoon.Connection.GetHotelBookingHeaderReport_Result> tbList = entity.GetHotelBookingHeaderReport().Where(x => Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) >= Convert.ToDateTime(dtpFrom.Value.ToShortDateString()) && Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) <= Convert.ToDateTime(dtpTo.Value.ToShortDateString())).ToList();

            for (int i = 0; i < tbList.Count; i++)
            {
                dgvHotelBookingHistory.Rows.Add(i + 1, tbList[i].InvoiceDate.Value.ToShortDateString(), tbList[i].InvoiceNo, tbList[i].CompanyName, tbList[i].ContactPerson, tbList[i].Description, tbList[i].Currency, tbList[i].Rate, tbList[i].NoofPax, tbList[i].NoofNight, tbList[i].TotalRoom, tbList[i].Balance);
            }
        }

        private void dgvHotelBookingHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string invoice = dgvHotelBookingHistory.CurrentRow.Cells["colInvoice"].Value.ToString();
                int count = (Int32)entity.SP_ChkTransactionForSaleEditDelete(invoice, "Hotel").FirstOrDefault();
                if (count > 0)
                {
                    MessageBox.Show("Cann't Edit or Delete Transaction!", "This Transaction has Pay For Credit!");
                }
                else
                {
                    if (e.ColumnIndex == 12)
                    {
                        frmHotelBooking newform = new frmHotelBooking();
                        newform.InvoiceNo = invoice;
                        newform.IsEdit = true;
                        newform.btnHotelBooking.Text = "Update";
                        this.Hide();
                        newform.ShowDialog();
                        this.Show();
                    }
                    if (e.ColumnIndex == 13)
                    {
                        if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Connection.HotelBooking tb = new Connection.HotelBooking();
                            tb = entity.HotelBookings.Where(x => x.InvoiceNo == invoice && x.IsDelete == false).FirstOrDefault();
                            if (tb != null)
                            {
                                tb.IsDelete = true;
                                entity.SaveChanges();
                            }

                            List<Connection.HotelRoom> tf = new List<Connection.HotelRoom>();
                            tf = entity.HotelRooms.Where(x => x.InvoiceNo == invoice && x.IsDelete == false).ToList();
                            if (tf.Count > 0)
                            {
                                for (int i = 0; i < tf.Count; i++)
                                {
                                    tf[i].IsDelete = true;
                                    entity.SaveChanges();
                                }
                            }

                            LoadHotelBookingList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmHotelBookingHistory_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);
        }
   }
}
