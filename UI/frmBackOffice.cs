using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;


namespace NobelMoon.UI
{
    public partial class frmBackOffice : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        public frmBackOffice()
        {
            InitializeComponent();
        }

        private void airLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClass newform = new frmClass();
            newform.Show();
        }

        private void segmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSegment newform = new frmSegment();
            newform.Show();
        }

        private void RTtoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmRoomType newform = new frmRoomType();
            newform.Show();
        }

        private void paymentTermToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPaymentTerm newform = new frmPaymentTerm();
            newform.Show();
        }

        private void currencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCurrency newform = new frmCurrency();
            newform.Show(); 
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser newform = new frmUser();
            newform.Show();
        }

        private void salePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStaff newform = new frmStaff();
            newform.Show();
        }

        private void airTicketReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAirTicketReport newform = new frmAirTicketReport("AirTicket");
            newform.Show();
        }

        private void hotelBookingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAirTicketReport newform = new frmAirTicketReport("Hotel");
            newform.Show();
        }

        private void ticketingHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAirTicketHistory newform = new frmAirTicketHistory();
            newform.Show();
        }

        private void hotelReservationHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHotelBookingHistory newform = new frmHotelBookingHistory();
            newform.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmVehicalName newform = new frmVehicalName();
            newform.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmPackage newform = new frmPackage();
            newform.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmPackageType newform = new frmPackageType();
            newform.Show();
        }

        private void frmBackOffice_Load(object sender, EventArgs e)
        {
            CheckUserRule();
        }

        private void frmBackOffice_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.Khaki, Color.SkyBlue, 45f);
            graphics.FillRectangle(brush, gradient_rectangle); 
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmTourPackageList newform = new frmTourPackageList();
            newform.Show();
        }

        private void tourPackageBookingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAirTicketReport newform = new frmAirTicketReport("TourPackage");
            newform.Show();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(@"D:\OneClickSoftwareHouse\DataBackup"))
                {
                    if (File.Exists(@"D:\OneClickSoftwareHouse\DataBackup\NobleMoon.bak"))
                    {
                        File.Delete(@"D:\OneClickSoftwareHouse\DataBackup\NobleMoon.bak");
                    }
                }
                else
                {
                    System.IO.Directory.CreateDirectory(@"D:\OneClickSoftwareHouse\DataBackup\");
                }


                Backup();
                MessageBox.Show("Successfully backup your data.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #region "Backup"
        public void Backup()
        {
            try
            {
                string Directory = "D:\\OneClickSoftwareHouse\\DataBackup\\NobleMoon-"+DateTime.Now.ToFileTime()+".bak";
                entity.SP_Backup(Directory);
                MessageBox.Show("Backup Successfully!", "Successful", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            frmHotel newform = new frmHotel();
            newform.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frmServices newform = new frmServices();
            newform.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            frmVisaType newform = new frmVisaType();
            newform.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            frmRequireLetter newform = new frmRequireLetter();
            newform.Show();
        }

        private void authorizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAuthorize newform = new frmAuthorize();
            newform.Show();
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompany newform = new frmCompany();
            newform.Show();
        }

        private void CheckUserRule()
        {
            if (Utility.Utility.AirTicket_History == false)
            {
                airTicketReportToolStripMenuItem.Visible = false;
            }
            if (Utility.Utility.AirTicket_Report == false)
            {
                btnTicket.Enabled = false;
                airTicketReportToolStripMenuItem.Visible = false;
            }
            if (Utility.Utility.Hotel_History == false)
            {
                hotelReservationHistoryToolStripMenuItem.Visible = false;
            }
            if (Utility.Utility.Hotel_Report == false)
            {
                button1.Enabled = false;
                hotelBookingReportToolStripMenuItem.Visible = false;
            }
            if (Utility.Utility.Tour_History == false)
            {
                toolStripMenuItem5.Visible = false;
            }
            if (Utility.Utility.Tour_Report == false)
            {
                button2.Enabled = false;
                tourPackageBookingReportToolStripMenuItem.Visible = false;
            }
            if (Utility.Utility.Passport_History == false)
            {
                passportAgentHistoryToolStripMenuItem.Visible = false;
            }
            if (Utility.Utility.Passport_Report == false)
            {
                button3.Enabled = false;
                passportBookingReportToolStripMenuItem.Visible = false;
            }
            if (Utility.Utility.Carrental_History == false)
            {
                carRentalHistoryToolStripMenuItem.Visible = false;
            }
            if (Utility.Utility.Carrental_Report == false)
            {
                button4.Enabled = false;
                carRentalBookingReportToolStripMenuItem.Visible = false;
            }
            if (Utility.Utility.Setup == false)
            {
                btnUser.Visible = false;
                setupToolStripMenuItem.Visible = false;
            }
            if (Utility.Utility.Backup == false)
            {
                btnBackup.Enabled = false;
                backupToolStripMenuItem.Visible = false;
            }
            if (Utility.Utility.Authorization == false)
            {
                btnAuthorize.Enabled = false;
                authorizationToolStripMenuItem.Visible = false;
            }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            frmCarType newform = new frmCarType();
            newform.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            frmPeroid newform = new frmPeroid();
            newform.Show();
        }

        private void carRentalHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCarRentalList newform = new frmCarRentalList();
            newform.Show();
        }

        private void passportAgentHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPassportList newform = new frmPassportList();
            newform.Show();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void passportBookingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAirTicketReport newform = new frmAirTicketReport("Passport");
            newform.Show();
        }

        private void carRentalBookingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAirTicketReport newform = new frmAirTicketReport("CarRental");
            newform.Show();
        }

        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            frmAuthorize newform = new frmAuthorize();
            newform.Show();
        }

        private void BindChart()
        {

            //List<string[]> listDataSource = new List<string[]>();

            //// Populate the 1] with records. 
            //listDataSource.Add(1,"Hnin",30);
            //listDataSource.Add(1,"Hnin",30);
            //listDataSource.Add(1,"Hnin",30);

            //// Bind the chart to the list. 
            //chart2.DataSource = listDataSource;

            // Create a series, and add it to the chart. 
            //Series series1 = new Series("Series1");
            //series1.ChartType = SeriesChartType.Column;
            //chart2.Series.Add(series1);

            // Adjust the series data members. 
            //series1. = "name";
            //series1.ValueDataMembers.AddRange(new string[] { "age" });

            // Access the view-type-specific options of the series. 
            //    ((BarSeriesView)series1.View).ColorEach = true;
            //    series1.LegendPointOptions.Pattern = "{A}";
            //}}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void btnDashBook_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            Backup();
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                DataTable tablem = new DataTable("TotalAmountByMonthly");
                //table.Columns.Add(new DataColumn("Transaction", typeof(string)));
                //table.Columns.Add(new DataColumn("TotalAmount", typeof(Decimal)));
                //table.Columns.Add(new DataColumn("User", typeof(string)));
                tablem.Columns.Add(new DataColumn("Month_Name", typeof(string)));
                tablem.Columns.Add(new DataColumn("SalesVolumn", typeof(Decimal)));
                tablem.Columns.Add(new DataColumn("User", typeof(string)));
                List<NobelMoon.Connection.SP_GetTotalAmountByMonthly_Result> result = null;
                if (comboBox1.Text == "Ticket")
                {
                    result = entity.SP_GetTotalAmountByMonthly("Ticket").ToList();
                }
                if (comboBox1.Text == "Hotel")
                {
                    result = entity.SP_GetTotalAmountByMonthly("Hotel").ToList();
                }
                if (comboBox1.Text == "Tours")
                {
                    result = entity.SP_GetTotalAmountByMonthly("Tours").ToList();
                }
                if (comboBox1.Text == "Passport")
                {
                    result = entity.SP_GetTotalAmountByMonthly("Passport").ToList();
                }
                if (comboBox1.Text == "CarRental")
                {
                    result = entity.SP_GetTotalAmountByMonthly("CarRental").ToList();
                }
                if (result.Count > 0)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        DataRow dr1 = null;
                        dr1 = tablem.NewRow();
                        dr1["Month_Name"] = result[i].Month_Name;
                        dr1["SalesVolumn"] = result[i].SalesVolumn == null ? 0 : result[i].SalesVolumn;
                        tablem.Rows.Add(dr1);
                    }
                }

                if (comboBox3.Text == "Column Chart")
                {
                    this.chart2.Series.Clear();
                    Series series1 = new Series("SaleVolumn");
                    series1.ChartType = SeriesChartType.Column;
                    chart2.Series.Add(series1);
                    chart2.Series["SaleVolumn"].ChartArea = "ChartArea1";
                    //chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1; 
                    if (tablem.Rows.Count > 0)
                    {
                        for (int i = 0; i < tablem.Rows.Count; i++)
                        {
                            this.chart2.Series["SaleVolumn"].Points.AddXY(tablem.Rows[i]["Month_Name"].ToString(), tablem.Rows[i]["SalesVolumn"].ToString());
                        }
                    }
                    this.chart2.Visible = true;
                    this.chart1.Visible = false;
                    this.chart2.Width = 500;
                }
                else
                {
                    this.chart1.Series.Clear();
                    Series series1 = new Series("SaleVolumn");
                    series1.ChartType = SeriesChartType.Pie;
                    chart1.Series.Add(series1);
                    if (tablem.Rows.Count > 0)
                    {
                        for (int i = 0; i < tablem.Rows.Count; i++)
                        {
                            this.chart1.Series["SaleVolumn"].Points.AddXY(tablem.Rows[i]["Month_Name"].ToString(), tablem.Rows[i]["SalesVolumn"].ToString());
                        }
                    }

                    this.chart1.Visible = true;
                    this.chart2.Visible = false;
                    this.chart1.Width = 500;
                }
            }
            else 
            {
                DataTable table = new DataTable("TotalAmountByTransaction");
                table.Columns.Add(new DataColumn("Transaction", typeof(string)));
                table.Columns.Add(new DataColumn("TotalAmount", typeof(Decimal)));
                table.Columns.Add(new DataColumn("User", typeof(string)));
                List<NobelMoon.Connection.SP_GetTotalAmountByTransaction_Result1> result = null;
                if (comboBox2.Text == "ThisWeek")
                {
                    result = entity.SP_GetTotalAmountByTransaction("ThisWeek").ToList();
                }
                if (comboBox2.Text == "ThisMonth")
                {
                    result = entity.SP_GetTotalAmountByTransaction("ThisMonth").ToList();
                }
                if (comboBox2.Text == "ThisYear")
                {
                    result = entity.SP_GetTotalAmountByTransaction("ThisYear").ToList();
                }
                else result = entity.SP_GetTotalAmountByTransaction("").ToList();

                if (result.Count > 0)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        DataRow dr1 = null;
                        dr1 = table.NewRow();
                        dr1["Transaction"] = result[i].Transaction;
                        dr1["TotalAmount"] = result[i].TotalAmount;
                        table.Rows.Add(dr1);
                    }
                }

                if (comboBox3.Text == "Column Chart")
                {
                    this.chart2.Series.Clear();
                    Series series1 = new Series("SaleVolumn");
                    series1.ChartType = SeriesChartType.Column;
                    chart2.Series.Add(series1);
                    chart2.Series["SaleVolumn"].ChartArea = "ChartArea1";
                    //chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1; 
                    if (table.Rows.Count > 0)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            this.chart2.Series["SaleVolumn"].Points.AddXY(table.Rows[i]["Transaction"].ToString(), table.Rows[i]["TotalAmount"].ToString());
                        }
                    }
                    this.chart2.Visible = true;
                    this.chart1.Visible = false;
                    this.chart2.Width = 500;
                }
                else
                {
                    this.chart1.Series.Clear();
                    Series series1 = new Series("SaleVolumn");
                    series1.ChartType = SeriesChartType.Pie;
                    chart1.Series.Add(series1);
                    if (table.Rows.Count > 0)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            this.chart1.Series["SaleVolumn"].Points.AddXY(table.Rows[i]["Transaction"].ToString(), table.Rows[i]["TotalAmount"].ToString());
                        }
                    }

                    this.chart1.Visible = true;
                    this.chart2.Visible = false;
                    this.chart1.Width = 500;
                }
            }
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            //frmAirTicketHistory newform = new frmAirTicketHistory();
            //newform.Show();
            frmAirTicketReport newform = new frmAirTicketReport("AirTicket");
            newform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //frmHotelBookingHistory newform = new frmHotelBookingHistory();
            //newform.Show();
            frmAirTicketReport newform = new frmAirTicketReport("Hotel");
            newform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //frmTourPackageList newform = new frmTourPackageList();
            //newform.Show();
            frmAirTicketReport newform = new frmAirTicketReport("TourPackage");
            newform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //frmPassportList newform = new frmPassportList();
            //newform.Show();
            frmAirTicketReport newform = new frmAirTicketReport("Passport");
            newform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //frmCarRentalList newform = new frmCarRentalList();
            //newform.Show();
            frmAirTicketReport newform = new frmAirTicketReport("CarRental");
            newform.Show();
        }

        private void dashBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            frmUser newform = new frmUser();
            newform.Show();
        }

        private void payForCreditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPayforCreditHistory newform = new frmPayforCreditHistory();
            newform.Show();
        }

        private void cashReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCashReport resources = new frmCashReport();
            resources.Show();
        }

        private void incomeTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIncometype newform = new frmIncometype();
            newform.Show();
        }
    }
}
