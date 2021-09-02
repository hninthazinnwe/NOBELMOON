using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using NobelMoon.Connection;
using CrystalDecisions.CrystalReports.Engine;

namespace NobelMoon.UI
{
    public partial class frmCashReport : Form
    {
        private NobelMoonEntities1 entity = new NobelMoonEntities1();
        public frmCashReport()
        {
            InitializeComponent();
        }
        private void frmCashReport_Load(object sender, EventArgs e)
        {
        }

        // Token: 0x06000F1F RID: 3871 RVA: 0x000AB1B4 File Offset: 0x000A93B4
        private void frmCashReport_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
            Brush brush = new LinearGradientBrush(rect, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, rect);
        }

        // Token: 0x06000F20 RID: 3872 RVA: 0x000AB204 File Offset: 0x000A9404
        private void GetCashReport()
        {
            List<Connection.GetCashReport_Result> list = this.entity.GetCashReport(new DateTime?(this.dtpFrom.Value), new DateTime?(this.dtpTo.Value)).ToList<GetCashReport_Result>();
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable("CashReportTbl");
            dataTable.Columns.Add(new DataColumn("No", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Amount", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("Currency", typeof(string)));
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["No"] = list[i].No;
                    dataRow["Name"] = list[i].Name;
                    dataRow["Amount"] = list[i].Amount;
                    dataRow["Currency"] = list[i].Currency;
                    dataTable.Rows.Add(dataRow);
                }
            }
            dataSet.Tables.Add(dataTable);
            ReportDocument reportDocument = new ReportDocument();
            dataSet.WriteXmlSchema(Application.StartupPath + "\\DataSets\\NobelMoon.xsd");
            reportDocument.Load(Application.StartupPath + "\\Reports\\CashReport.rpt");
            reportDocument.SetDataSource(dataSet);
            this.ReportViewer1.ReportSource = reportDocument;
            this.ReportViewer1.Refresh();
            base.UseWaitCursor = false;
        }

        // Token: 0x06000F21 RID: 3873 RVA: 0x000AB3FD File Offset: 0x000A95FD
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.GetCashReport();
        }

        private void frmCashReport_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle); 
        }
    }
}
