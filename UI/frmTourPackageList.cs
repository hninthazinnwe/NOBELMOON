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
    public partial class frmTourPackageList : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        public frmTourPackageList()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dgvTourPackageBookingHistory.Rows.Clear();
                //List<Connection.TourBooking> tbList = new List<Connection.TourBooking>();
                //tbList = entity.TourBookings.Where(x => x.IsDelete == false && Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) >= Convert.ToDateTime(dtpFrom.Value.ToShortDateString()) && Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) <= Convert.ToDateTime(dtpTo.Value.ToShortDateString())).ToList();
                List<Connection.GetTourPackageBookingHeaderReport_Result> tbList = entity.GetTourPackageBookingHeaderReport().Where(x => Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) >= Convert.ToDateTime(dtpFrom.Value.ToShortDateString()) && Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) <= Convert.ToDateTime(dtpTo.Value.ToShortDateString())).ToList(); 
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
                    dgvTourPackageBookingHistory.Rows.Add(i + 1, tbList[i].InvoiceDate.Value.ToShortDateString(), tbList[i].DepatureDate.Value.ToShortDateString(), tbList[i].ArrivalDate.Value.ToShortDateString(), tbList[i].InvoiceNo, tbList[i].CompanyName, tbList[i].ContactPerson, tbList[i].Description, tbList[i].Currency, tbList[i].Rate, tbList[i].Balance, tbList[i].Status);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadTourPackageBookingList()
        {
            dgvTourPackageBookingHistory.Rows.Clear();
            List<Connection.GetTourPackageBookingHeaderReport_Result> tbList = entity.GetTourPackageBookingHeaderReport().Where(x => Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) >= Convert.ToDateTime(dtpFrom.Value.ToShortDateString()) && Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) <= Convert.ToDateTime(dtpTo.Value.ToShortDateString())).ToList(); 
                
            for (int i = 0; i < tbList.Count; i++)
            {
                dgvTourPackageBookingHistory.Rows.Add(i + 1, tbList[i].InvoiceDate.Value.ToShortDateString(), tbList[i].DepatureDate.Value.ToShortDateString(), tbList[i].ArrivalDate.Value.ToShortDateString(), tbList[i].InvoiceNo, tbList[i].CompanyName, tbList[i].ContactPerson, tbList[i].Description, tbList[i].Currency, tbList[i].Rate, tbList[i].Balance, tbList[i].Status);
            }
        }

        private void dgvTourPackageBookingHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string invoice = dgvTourPackageBookingHistory.CurrentRow.Cells["colInvoice"].Value.ToString();
                int count = (Int32)entity.SP_ChkTransactionForSaleEditDelete(invoice, "Tour").FirstOrDefault();
                if (count > 0)
                {
                    MessageBox.Show("Cann't Edit or Delete Transaction!", "This Transaction has Pay For Credit!");
                }
                else
                {
                    if (e.ColumnIndex == 12)
                    {
                        frmTourPackage newform = new frmTourPackage();
                        newform.InvoiceNo = invoice;
                        newform.IsEdit = true;
                        newform.btnTourPackageBooking.Text = "Update";
                        this.Hide();
                        newform.ShowDialog();
                        this.Show();
                    }
                    if (e.ColumnIndex == 13)
                    {
                        if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Connection.TourBooking tb = new Connection.TourBooking();
                            tb = entity.TourBookings.Where(x => x.InvoiceNo == invoice && x.IsDelete == false).FirstOrDefault();
                            if (tb != null)
                            {
                                tb.IsDelete = true;
                                entity.SaveChanges();
                            }

                            List<Connection.TourPackage> tf = new List<Connection.TourPackage>();
                            tf = entity.TourPackages.Where(x => x.InvoiceNo == invoice && x.IsDelete == false).ToList();
                            if (tf.Count > 0)
                            {
                                for (int i = 0; i < tf.Count; i++)
                                {
                                    tf[i].IsDelete = true;
                                    entity.SaveChanges();
                                }
                            }

                            LoadTourPackageBookingList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmTourPackageList_Load(object sender, EventArgs e)
        {
            LoadTourPackageBookingList();
        }

        private void frmTourPackageList_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);
        }
    }
}
