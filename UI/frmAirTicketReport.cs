using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Drawing2D;

namespace NobelMoon.UI
{
    public partial class frmAirTicketReport : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        string type = "";
        public frmAirTicketReport()
        {
            InitializeComponent();
        }

        public frmAirTicketReport(string reportType)
        {
            InitializeComponent();
            type = reportType;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            cboStatus.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            System.Data.DataSet DS = new System.Data.DataSet();

            if (type == "AirTicket")
            {
                DataTable table = new DataTable("AirTicketHeader");
                table.Columns.Add(new DataColumn("Date", typeof(DateTime)));
                table.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
                table.Columns.Add(new DataColumn("ContactPerson", typeof(string)));
                table.Columns.Add(new DataColumn("CompanyName", typeof(string)));
                table.Columns.Add(new DataColumn("PaymentCode", typeof(string)));
                table.Columns.Add(new DataColumn("PaymentDes", typeof(string)));
                table.Columns.Add(new DataColumn("Phone", typeof(string)));
                table.Columns.Add(new DataColumn("Email", typeof(string)));
                table.Columns.Add(new DataColumn("Address", typeof(string)));
                table.Columns.Add(new DataColumn("Name", typeof(string)));
                table.Columns.Add(new DataColumn("t3", typeof(string)));
                table.Columns.Add(new DataColumn("NoSeat", typeof(Int32)));
                table.Columns.Add(new DataColumn("Tax", typeof(Int32)));
                table.Columns.Add(new DataColumn("Total", typeof(Decimal)));
                table.Columns.Add(new DataColumn("Currency", typeof(string)));
                table.Columns.Add(new DataColumn("User", typeof(string)));

                List<NobelMoon.Connection.GetAirTicketHeaderReport_Result> result = entity.GetAirTicketHeaderReport().Where(x => Convert.ToDateTime(x.Date.Value.ToShortDateString()) >= Convert.ToDateTime(dtpFrom.Value.ToShortDateString()) && Convert.ToDateTime(x.Date.Value.ToShortDateString())<= Convert.ToDateTime(dtpTo.Value.ToShortDateString())).ToList();

                if (txtCompanyName.Text != "")
                { 
                    string company = txtCompanyName.Text;
                    result = result.Where(x => x.Name == company).ToList();
                }
                if (txtContactPerson.Text != "")
                {
                    string contact = txtContactPerson.Text;
                    result = result.Where(x => x.ContactPerson == contact).ToList();
                }
                if (cboStatus.Text != "All")
                {
                    string status="";
                    if(cboStatus.Text=="Booking")
                    {
                        status = "B";
                    }
                        else  status = "I";
                    result = result.Where(x => x.Status == status).ToList();
                }
                if (result.Count > 0)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        DataRow dr1 = null;
                        dr1 = table.NewRow();
                        dr1["Date"] = result[i].Date;
                        dr1["InvoiceNo"] = result[i].InvoiceNo;
                        dr1["ContactPerson"] = result[i].ContactPerson;
                        dr1["CompanyName"] = result[i].CompanyName;
                        dr1["PaymentCode"] = result[i].PaymentCode;
                        dr1["PaymentDes"] = result[i].PaymentDes;
                        dr1["Phone"] = result[i].Phone;
                        dr1["Email"] = result[i].Email;
                        dr1["Address"] = result[i].Address;
                        dr1["Name"] = result[i].Name;
                        dr1["t3"] = result[i].t3;
                        dr1["NoSeat"] = result[i].NoSeat;
                        dr1["Tax"] = result[i].Tax;
                        dr1["Total"] = result[i].Total;
                        dr1["Currency"] = result[i].Currency;
                        dr1["User"] = result[i].Name;
                        table.Rows.Add(dr1);
                    }
                }
                DS.Tables.Add(table);

                ReportDocument l_Report = new ReportDocument();
                DS.WriteXmlSchema(Application.StartupPath + @"\DataSets\NobelMoon.xsd");
                l_Report.Load(Application.StartupPath + @"\Reports\AirTicketHeader.rpt");
                l_Report.SetDataSource(DS);
                this.crystalReportViewer1.ReportSource = l_Report;
                this.crystalReportViewer1.Refresh();
                this.UseWaitCursor = false;
            }
            else if (type == "Hotel")
            {
                DataTable table = new DataTable("HotelBooking");
                table.Columns.Add(new DataColumn("InvoiceDate", typeof(DateTime)));
                table.Columns.Add(new DataColumn("ArrivalDate", typeof(DateTime)));
                table.Columns.Add(new DataColumn("DepatureDate", typeof(DateTime)));
                table.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
                table.Columns.Add(new DataColumn("ContactPerson", typeof(string)));
                table.Columns.Add(new DataColumn("CompanyName", typeof(string)));
                table.Columns.Add(new DataColumn("ContactPhone", typeof(string)));
                table.Columns.Add(new DataColumn("Description", typeof(string)));
                table.Columns.Add(new DataColumn("Name", typeof(string)));
                table.Columns.Add(new DataColumn("Email", typeof(string)));
                table.Columns.Add(new DataColumn("t2", typeof(string)));
                table.Columns.Add(new DataColumn("NoofPax", typeof(Int32)));
                table.Columns.Add(new DataColumn("NoofNight", typeof(Int32)));
                table.Columns.Add(new DataColumn("Remark", typeof(string)));
                table.Columns.Add(new DataColumn("Currency", typeof(string)));
                table.Columns.Add(new DataColumn("Rate", typeof(Decimal)));
                table.Columns.Add(new DataColumn("Code", typeof(string)));
                table.Columns.Add(new DataColumn("TotalRoom", typeof(Int32)));
                table.Columns.Add(new DataColumn("TotalAmount", typeof(Decimal)));
                table.Columns.Add(new DataColumn("Balance", typeof(Decimal)));
                table.Columns.Add(new DataColumn("DiscountPercnet", typeof(Int32)));
                table.Columns.Add(new DataColumn("Discount", typeof(Decimal)));

                List<NobelMoon.Connection.GetHotelBookingHeaderReport_Result> result = entity.GetHotelBookingHeaderReport().Where(x => Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) >= Convert.ToDateTime(dtpFrom.Value.ToShortDateString()) && Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) <= Convert.ToDateTime(dtpTo.Value.ToShortDateString())).ToList();
                if (txtCompanyName.Text != "")
                {
                    string company = txtCompanyName.Text;
                    result = result.Where(x => x.Name == company).ToList();
                }
                if (txtContactPerson.Text != "")
                {
                    string contact = txtContactPerson.Text;
                    result = result.Where(x => x.ContactPerson == contact).ToList();
                }
                if (cboStatus.Text != "All")
                {
                    string status = "";
                    if (cboStatus.Text == "Booking")
                    {
                        status = "B";
                    }
                    else status = "I";
                    result = result.Where(x => x.Status == status).ToList();
                }
                if (result.Count > 0)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        DataRow dr1 = null;
                        dr1 = table.NewRow();
                        dr1["InvoiceDate"] = result[i].InvoiceDate;
                        dr1["ArrivalDate"] = result[i].ArrivalDate;
                        dr1["DepatureDate"] = result[i].DepatureDate;
                        dr1["InvoiceNo"] = result[i].InvoiceNo;
                        dr1["ContactPerson"] = result[i].ContactPerson;
                        dr1["CompanyName"] = result[i].CompanyName;
                        dr1["Description"] = result[i].Description;
                        dr1["Remark"] = result[i].Remark;
                        dr1["ContactPhone"] = result[i].ContactPhone;
                        dr1["Email"] = result[i].Email;
                        dr1["t2"] = result[i].t2;
                        dr1["NoofPax"] = result[i].NoofPax;
                        dr1["NoofNight"] = result[i].NoofNight;
                        dr1["Currency"] = result[i].Currency;
                        dr1["Rate"] = result[i].Rate;
                        dr1["TotalRoom"] = result[i].TotalRoom;
                        dr1["TotalAmount"] = result[i].TotalAmount;
                        dr1["Balance"] = result[i].Balance;
                        dr1["Code"] = result[i].Code;
                        dr1["DiscountPercnet"] = result[i].DiscountPercent;
                        dr1["Discount"] = result[i].Discount;
                        dr1["Name"] = result[i].Name;
                        table.Rows.Add(dr1);
                    }
                }
                DS.Tables.Add(table);

                ReportDocument l_Report = new ReportDocument();
                DS.WriteXmlSchema(Application.StartupPath + @"\DataSets\NobelMoon.xsd");
                l_Report.Load(Application.StartupPath + @"\Reports\HotelBookingHeader.rpt");
                l_Report.SetDataSource(DS);
                this.crystalReportViewer1.ReportSource = l_Report;
                this.crystalReportViewer1.Refresh();
                this.UseWaitCursor = false;
            }
            else if (type == "TourPackage")
            {
                DataTable table = new DataTable("TourBooking");
                table.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
                table.Columns.Add(new DataColumn("InvoiceDate", typeof(DateTime)));
                table.Columns.Add(new DataColumn("ArrivalDate", typeof(DateTime)));
                table.Columns.Add(new DataColumn("DepatureDate", typeof(DateTime)));
                table.Columns.Add(new DataColumn("ContactPerson", typeof(string)));
                table.Columns.Add(new DataColumn("PaymentTerm", typeof(string)));
                table.Columns.Add(new DataColumn("CompanyName", typeof(string)));
                table.Columns.Add(new DataColumn("MeetingPoint", typeof(string)));
                table.Columns.Add(new DataColumn("ContactPhone", typeof(string)));
                table.Columns.Add(new DataColumn("Email", typeof(string)));
                table.Columns.Add(new DataColumn("t2", typeof(string)));
                table.Columns.Add(new DataColumn("Address", typeof(string)));
                table.Columns.Add(new DataColumn("NoofNight", typeof(Int32)));
                table.Columns.Add(new DataColumn("TotalAmount", typeof(Decimal)));
                table.Columns.Add(new DataColumn("Balance", typeof(Decimal)));
                table.Columns.Add(new DataColumn("Discount", typeof(Decimal)));
                table.Columns.Add(new DataColumn("Rate", typeof(Decimal)));
                table.Columns.Add(new DataColumn("DiscountPercent", typeof(Int32)));
                table.Columns.Add(new DataColumn("Remark", typeof(string)));
                table.Columns.Add(new DataColumn("Type", typeof(string)));
                table.Columns.Add(new DataColumn("Currency", typeof(string)));
                table.Columns.Add(new DataColumn("Usesr", typeof(string)));

                List<NobelMoon.Connection.GetTourPackageBookingHeaderReport_Result> result = entity.GetTourPackageBookingHeaderReport().Where(x => Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) >= Convert.ToDateTime(dtpFrom.Value.ToShortDateString()) && Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) <= Convert.ToDateTime(dtpTo.Value.ToShortDateString())).ToList();
                if (txtCompanyName.Text != "")
                {
                    string company = txtCompanyName.Text;
                    result = result.Where(x => x.Name == company).ToList();
                }
                if (txtContactPerson.Text != "")
                {
                    string contact = txtContactPerson.Text;
                    result = result.Where(x => x.ContactPerson == contact).ToList();
                }
                if (cboStatus.Text != "All")
                {
                    string status = "";
                    if (cboStatus.Text == "Booking")
                    {
                        status = "B";
                    }
                    else status = "I";
                    result = result.Where(x => x.Status == status).ToList();
                }
                if (result.Count > 0)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        DataRow dr1 = null;
                        dr1 = table.NewRow();
                        dr1["InvoiceDate"] = result[i].InvoiceDate;
                        dr1["ArrivalDate"] = result[i].ArrivalDate;
                        dr1["DepatureDate"] = result[i].DepatureDate;
                        dr1["InvoiceNo"] = result[i].InvoiceNo;
                        dr1["ContactPerson"] = result[i].ContactPerson;
                        dr1["CompanyName"] = result[i].CompanyName;
                        dr1["PaymentTerm"] = result[i].Description;
                        dr1["Remark"] = result[i].Remark;
                        dr1["ContactPhone"] = result[i].ContactPhone;
                        dr1["Email"] = result[i].Email;
                        dr1["t2"] = result[i].t2;
                        dr1["MeetingPoint"] = result[i].MeetingPoint;
                        dr1["NoofNight"] = result[i].NoofNight;
                        dr1["Currency"] = result[i].Currency;
                        //dr1["Type"] = result[i].Type;
                        dr1["Rate"] = result[i].Rate;
                        dr1["TotalAmount"] = result[i].TotalAmount;
                        dr1["Balance"] = result[i].Balance;
                        //dr1["Code"] = result[i].Code;
                        dr1["DiscountPercent"] = result[i].Discount_Percent;
                        dr1["Discount"] = result[i].Discount;
                        dr1["Usesr"] = result[i].Name;
                        table.Rows.Add(dr1);
                    }
                }
                DS.Tables.Add(table);


                ReportDocument l_Report = new ReportDocument();
                DS.WriteXmlSchema(Application.StartupPath + @"\DataSets\NobelMoon.xsd");
                l_Report.Load(Application.StartupPath + @"\Reports\TourPackageHeader.rpt");
                l_Report.SetDataSource(DS);
                this.crystalReportViewer1.ReportSource = l_Report;
                this.crystalReportViewer1.Refresh();
                this.UseWaitCursor = false;
            }

            else if (type == "Passport")
            {
                DataTable table = new DataTable("PassporBooking");
                table.Columns.Add(new DataColumn("InvoiceDate", typeof(DateTime)));
                table.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
                table.Columns.Add(new DataColumn("ContactPerson", typeof(string)));
                table.Columns.Add(new DataColumn("ContactPhone", typeof(string)));
                table.Columns.Add(new DataColumn("PaymentTerm", typeof(string)));
                table.Columns.Add(new DataColumn("Currency", typeof(string)));
                table.Columns.Add(new DataColumn("Rate", typeof(Int32)));
                table.Columns.Add(new DataColumn("TotalNo", typeof(Int32)));
                table.Columns.Add(new DataColumn("TotalAmount", typeof(Decimal)));
                table.Columns.Add(new DataColumn("Remark", typeof(string)));
                table.Columns.Add(new DataColumn("t2", typeof(string)));
                table.Columns.Add(new DataColumn("Type", typeof(string)));
                table.Columns.Add(new DataColumn("User", typeof(string)));

                List<NobelMoon.Connection.GetPassportHeaderReport_Result> result = entity.GetPassportHeaderReport().Where(x => Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) >= Convert.ToDateTime(dtpFrom.Value.ToShortDateString()) && Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) <= Convert.ToDateTime(dtpTo.Value.ToShortDateString())).ToList();
                if (txtCompanyName.Text != "")
                {
                    string company = txtCompanyName.Text;
                    result = result.Where(x => x.Name == company).ToList();
                }
                if (txtContactPerson.Text != "")
                {
                    string contact = txtContactPerson.Text;
                    result = result.Where(x => x.ContactPerson == contact).ToList();
                }
                if (cboStatus.Text != "All")
                {
                    string status = "";
                    if (cboStatus.Text == "Booking")
                    {
                        status = "B";
                    }
                    else status = "I";
                    result = result.Where(x => x.Status == status).ToList();
                }
                if (result.Count > 0)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        DataRow dr1 = null;
                        dr1 = table.NewRow();
                        dr1["InvoiceDate"] = result[i].InvoiceDate;
                        dr1["InvoiceNo"] = result[i].InvoiceNo;
                        dr1["ContactPerson"] = result[i].ContactPerson;
                        dr1["ContactPhone"] = result[i].ContactPhone;
                        dr1["Currency"] = result[i].Currency;
                        dr1["Rate"] = result[i].Rate;
                        dr1["TotalNo"] = result[i].TotalNo;
                        dr1["TotalAmount"] = result[i].TotalAmount;
                        dr1["Type"] = result[i].Type;
                        dr1["Remark"] = result[i].TotalAmount;
                        dr1["t2"] = result[i].t2;
                        dr1["PaymentTerm"] = result[i].PaymentTerm;
                        dr1["Type"] = result[i].Type;
                        dr1["User"] = result[i].Name;
                        table.Rows.Add(dr1);
                    }
                }
                DS.Tables.Add(table);

                ReportDocument l_Report = new ReportDocument();
                DS.WriteXmlSchema(Application.StartupPath + @"\DataSets\NobelMoon.xsd");
                l_Report.Load(Application.StartupPath + @"\Reports\PassportHeader.rpt");
                l_Report.SetDataSource(DS);
                this.crystalReportViewer1.ReportSource = l_Report;
                this.crystalReportViewer1.Refresh();
                this.UseWaitCursor = false;
            }

            else if (type == "CarRental")
            {
                DataTable table = new DataTable("CarRentalHeader");
                table.Columns.Add(new DataColumn("InvoiceDate", typeof(DateTime)));
                table.Columns.Add(new DataColumn("ArrivalDate", typeof(DateTime)));
                table.Columns.Add(new DataColumn("DepatureDate", typeof(DateTime)));
                table.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
                table.Columns.Add(new DataColumn("ContactPerson", typeof(string)));
                table.Columns.Add(new DataColumn("ContactPhone", typeof(string)));
                table.Columns.Add(new DataColumn("CompanyName", typeof(string)));
                table.Columns.Add(new DataColumn("Email", typeof(string)));
                table.Columns.Add(new DataColumn("t2", typeof(string)));
                table.Columns.Add(new DataColumn("Address", typeof(string)));
                table.Columns.Add(new DataColumn("PaymentTerm", typeof(string)));
                table.Columns.Add(new DataColumn("Currency", typeof(string)));
                table.Columns.Add(new DataColumn("Rate", typeof(Int32)));
                table.Columns.Add(new DataColumn("ExtraCharges", typeof(Decimal)));
                table.Columns.Add(new DataColumn("TotalAmount", typeof(Decimal)));
                table.Columns.Add(new DataColumn("Remark", typeof(string)));
                table.Columns.Add(new DataColumn("Balance", typeof(Decimal)));
                table.Columns.Add(new DataColumn("User", typeof(string)));

                List<NobelMoon.Connection.GetCarRentalHeaderReport_Result> result = entity.GetCarRentalHeaderReport().Where(x => Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) >= Convert.ToDateTime(dtpFrom.Value.ToShortDateString()) && Convert.ToDateTime(x.InvoiceDate.Value.ToShortDateString()) <= Convert.ToDateTime(dtpTo.Value.ToShortDateString())).ToList();
                if (txtCompanyName.Text != "")
                {
                    string company = txtCompanyName.Text;
                    result = result.Where(x => x.Name == company).ToList();
                }
                if (txtContactPerson.Text != "")
                {
                    string contact = txtContactPerson.Text;
                    result = result.Where(x => x.ContactPerson == contact).ToList();
                }
                if (cboStatus.Text != "All")
                {
                    string status = "";
                    if (cboStatus.Text == "Booking")
                    {
                        status = "B";
                    }
                    else status = "I";
                    result = result.Where(x => x.Status == status).ToList();
                }
                if (result.Count > 0)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        DataRow dr1 = null;
                        dr1 = table.NewRow();
                        dr1["InvoiceDate"] = result[i].InvoiceDate;
                        dr1["ArrivalDate"] = result[i].ArrivalDate;
                        dr1["DepatureDate"] = result[i].DepatureDate;
                        dr1["InvoiceNo"] = result[i].InvoiceNo;
                        dr1["ContactPerson"] = result[i].ContactPerson;
                        dr1["CompanyName"] = result[i].CompanyName;
                        dr1["PaymentTerm"] = result[i].PaymentTerm;
                        //dr1["Remark"] = result[i].rem;
                        dr1["ContactPhone"] = result[i].ContactPhone;
                        dr1["Email"] = result[i].Email;
                        dr1["t2"] = result[i].t2;
                        dr1["Address"] = result[i].Address;
                        dr1["Currency"] = result[i].Currency;
                        dr1["Rate"] = result[i].Rate;
                        dr1["TotalAmount"] = result[i].TotalAmount;
                        dr1["Balance"] = result[i].Balance;
                        dr1["ExtraCharges"] = result[i].ExtraCharges;
                        dr1["User"] = result[i].Name;
                        table.Rows.Add(dr1);
                    }
                }
                DS.Tables.Add(table);

                ReportDocument l_Report = new ReportDocument();
                DS.WriteXmlSchema(Application.StartupPath + @"\DataSets\NobelMoon.xsd");
                l_Report.Load(Application.StartupPath + @"\Reports\CarRentalHeader.rpt");
                l_Report.SetDataSource(DS);
                this.crystalReportViewer1.ReportSource = l_Report;
                this.crystalReportViewer1.Refresh();
                this.UseWaitCursor = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmAirTicketReport_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle); 
        }
    }
}
