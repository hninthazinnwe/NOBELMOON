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
    public partial class frmAuthorize : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        public frmAuthorize()
        {
            this.InitializeComponent();
        }

        // Token: 0x06000B2E RID: 2862 RVA: 0x00044055 File Offset: 0x00042255
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }

        // Token: 0x06000B2F RID: 2863 RVA: 0x00044060 File Offset: 0x00042260
        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        // Token: 0x06000B30 RID: 2864 RVA: 0x0004406C File Offset: 0x0004226C
        private void frmAuthorize_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
            Brush brush = new LinearGradientBrush(rect, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, rect);
        }

        // Token: 0x06000B31 RID: 2865 RVA: 0x000440BC File Offset: 0x000422BC
        private void frmAuthorize_Load(object sender, EventArgs e)
        {
            List<Connection.Staff> graphics = new List<Connection.Staff>();
            graphics = (from x in this.entity.Staffs
                        where x.IsDelete == (bool?)false
                        select x).ToList<Connection.Staff>();
            this.cboUser.DataSource = null;
            this.cboUser.DataSource = graphics;
            this.cboUser.DisplayMember = "Name";
            this.cboUser.ValueMember = "Code";
        }

        // Token: 0x06000B32 RID: 2866 RVA: 0x00044188 File Offset: 0x00042388
        private void tabPage7_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, base.Width, base.Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);
        }

        // Token: 0x06000B33 RID: 2867 RVA: 0x000441D8 File Offset: 0x000423D8
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.chkaNew.Checked)
            {
                this.SaveRule("01", "AirTicket_New", this.cboUser.SelectedValue.ToString(), true);
            }
            else
            {
                this.SaveRule("01", "AirTicket_New", this.cboUser.SelectedValue.ToString(), false);
            }
            if (this.chkaHistory.Checked)
            {
                this.SaveRule("02", "AirTicket_History", this.cboUser.SelectedValue.ToString(), true);
            }
            else
            {
                this.SaveRule("02", "AirTicket_History", this.cboUser.SelectedValue.ToString(), false);
            }
            if (this.chkaReport.Checked)
            {
                this.SaveRule("03", "AirTicket_Report", this.cboUser.SelectedValue.ToString(), true);
            }
            else
            {
                this.SaveRule("03", "AirTicket_Report", this.cboUser.SelectedValue.ToString(), false);
            }
            if (this.chkhNew.Checked)
            {
                this.SaveRule("04", "Hotel_New", this.cboUser.SelectedValue.ToString(), true);
            }
            else
            {
                this.SaveRule("04", "Hotel_New", this.cboUser.SelectedValue.ToString(), false);
            }
            if (this.chkhHistory.Checked)
            {
                this.SaveRule("05", "Hotelt_History", this.cboUser.SelectedValue.ToString(), true);
            }
            else
            {
                this.SaveRule("05", "Hotel_History", this.cboUser.SelectedValue.ToString(), false);
            }
            if (this.chkhReport.Checked)
            {
                this.SaveRule("06", "Hotel_Report", this.cboUser.SelectedValue.ToString(), true);
            }
            else
            {
                this.SaveRule("06", "Hotel_Report", this.cboUser.SelectedValue.ToString(), false);
            }
            if (this.chktNew.Checked)
            {
                this.SaveRule("07", "TourPackage_New", this.cboUser.SelectedValue.ToString(), true);
            }
            else
            {
                this.SaveRule("07", "TourPackage_New", this.cboUser.SelectedValue.ToString(), false);
            }
            if (this.chktHistory.Checked)
            {
                this.SaveRule("08", "TourPackage_History", this.cboUser.SelectedValue.ToString(), true);
            }
            else
            {
                this.SaveRule("08", "TourPackage_History", this.cboUser.SelectedValue.ToString(), false);
            }
            if (this.chktReport.Checked)
            {
                this.SaveRule("09", "TourPackage_Report", this.cboUser.SelectedValue.ToString(), true);
            }
            else
            {
                this.SaveRule("09", "TourPackage_Report", this.cboUser.SelectedValue.ToString(), false);
            }
            if (this.chkpNew.Checked)
            {
                this.SaveRule("10", "Passport_New", this.cboUser.SelectedValue.ToString(), true);
            }
            else
            {
                this.SaveRule("10", "Passport_New", this.cboUser.SelectedValue.ToString(), false);
            }
            if (this.chkpHistory.Checked)
            {
                this.SaveRule("11", "Passport_History", this.cboUser.SelectedValue.ToString(), true);
            }
            else
            {
                this.SaveRule("11", "Passport_History", this.cboUser.SelectedValue.ToString(), false);
            }
            if (this.chkpReport.Checked)
            {
                this.SaveRule("12", "Passport_Report", this.cboUser.SelectedValue.ToString(), true);
            }
            else
            {
                this.SaveRule("12", "Passport_Report", this.cboUser.SelectedValue.ToString(), false);
            }
            if (this.chkcNew.Checked)
            {
                this.SaveRule("13", "CarRental_New", this.cboUser.SelectedValue.ToString(), true);
            }
            else
            {
                this.SaveRule("13", "CarRental_New", this.cboUser.SelectedValue.ToString(), false);
            }
            if (this.chkcHistory.Checked)
            {
                this.SaveRule("14", "CarRental_History", this.cboUser.SelectedValue.ToString(), true);
            }
            else
            {
                this.SaveRule("14", "CarRental_History", this.cboUser.SelectedValue.ToString(), false);
            }
            if (this.chkcReport.Checked)
            {
                this.SaveRule("15", "CarRental_Report", this.cboUser.SelectedValue.ToString(), true);
            }
            else
            {
                this.SaveRule("15", "CarRental_Report", this.cboUser.SelectedValue.ToString(), false);
            }
            if (this.chksNew.Checked)
            {
                this.SaveRule("16", "Setup_New", this.cboUser.SelectedValue.ToString(), true);
            }
            else
            {
                this.SaveRule("16", "Setup_New", this.cboUser.SelectedValue.ToString(), false);
            }
            if (this.chkfBackup.Checked)
            {
                this.SaveRule("17", "Backup", this.cboUser.SelectedValue.ToString(), true);
            }
            else
            {
                this.SaveRule("17", "Backup", this.cboUser.SelectedValue.ToString(), false);
            }
            if (this.chkfAuthorize.Checked)
            {
                this.SaveRule("18", "Authorization", this.cboUser.SelectedValue.ToString(), true);
            }
            else
            {
                this.SaveRule("18", "Authorization", this.cboUser.SelectedValue.ToString(), false);
            }
            if (this.chkfFingerPrint.Checked)
            {
                this.SaveRule("19", "FingerPrint", this.cboUser.SelectedValue.ToString(), true);
            }
            else
            {
                this.SaveRule("19", "FingerPrint", this.cboUser.SelectedValue.ToString(), false);
            }
            if (this.chkCash.Checked)
            {
                this.SaveRule("20", "CashReceive", this.cboUser.SelectedValue.ToString(), true);
            }
            else
            {
                this.SaveRule("20", "CashReceive", this.cboUser.SelectedValue.ToString(), false);
            }
            MessageBox.Show("Successfull", "Save Successfully!");
            this.Reset();
        }

        // Token: 0x06000B34 RID: 2868 RVA: 0x00044910 File Offset: 0x00042B10
        private void SaveRule(string code, string Description, string staff, bool IsCheck)
        {
            Connection.Authorization graphics = new Connection.Authorization();
            graphics = (from x in this.entity.Authorizations
                        where x.Code == code && x.Staff == staff
                        select x).FirstOrDefault<Connection.Authorization>();
            if (graphics == null)
            {
                Connection.Authorization gradient_rectangle = new Connection.Authorization();
                gradient_rectangle.SystemDate = new DateTime?(DateTime.Now);
                gradient_rectangle.Code = code;
                gradient_rectangle.Description = Description;
                gradient_rectangle.Staff = staff;
                gradient_rectangle.User = Utility.Utility._User;
                gradient_rectangle.IsChecked = new bool?(IsCheck);
                this.entity.AddToAuthorizations(gradient_rectangle);
                this.entity.SaveChanges();
            }
            else
            {
                graphics.SystemDate = new DateTime?(DateTime.Now);
                graphics.Code = code;
                graphics.Description = Description;
                graphics.Staff = staff;
                graphics.User = Utility.Utility._User;
                graphics.IsChecked = new bool?(IsCheck);
                this.entity.SaveChanges();
            }
        }

        // Token: 0x06000B35 RID: 2869 RVA: 0x00044AD4 File Offset: 0x00042CD4
        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            this.chkaNew.Checked = true;
            this.chkaHistory.Checked = true;
            this.chkaReport.Checked = true;
            this.chkhNew.Checked = true;
            this.chkhHistory.Checked = true;
            this.chkhReport.Checked = true;
            this.chktNew.Checked = true;
            this.chktHistory.Checked = true;
            this.chktReport.Checked = true;
            this.chkpNew.Checked = true;
            this.chkpHistory.Checked = true;
            this.chkpReport.Checked = true;
            this.chkcNew.Checked = true;
            this.chkcHistory.Checked = true;
            this.chkcReport.Checked = true;
            this.chksNew.Checked = true;
            this.chkfBackup.Checked = true;
            this.chkfAuthorize.Checked = true;
            this.chkCash.Checked = true;
        }

        // Token: 0x06000B36 RID: 2870 RVA: 0x00044BD9 File Offset: 0x00042DD9
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Reset();
        }

        // Token: 0x06000B37 RID: 2871 RVA: 0x00044BE4 File Offset: 0x00042DE4
        private void Reset()
        {
            this.chkaNew.Checked = false;
            this.chkaHistory.Checked = false;
            this.chkaReport.Checked = false;
            this.chkhNew.Checked = false;
            this.chkhHistory.Checked = false;
            this.chkhReport.Checked = false;
            this.chktNew.Checked = false;
            this.chktHistory.Checked = false;
            this.chktReport.Checked = false;
            this.chkpNew.Checked = false;
            this.chkpHistory.Checked = false;
            this.chkpReport.Checked = false;
            this.chkcNew.Checked = false;
            this.chkcHistory.Checked = false;
            this.chkcReport.Checked = false;
            this.chksNew.Checked = false;
            this.chkfBackup.Checked = false;
            this.chkfAuthorize.Checked = false;
            this.chkCash.Checked = false;
        }

        // Token: 0x06000B38 RID: 2872 RVA: 0x00044CEC File Offset: 0x00042EEC
        private void tbSetup_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics resources = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
            Brush brush = new LinearGradientBrush(rect, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            resources.FillRectangle(brush, rect);
        }

        // Token: 0x06000B39 RID: 2873 RVA: 0x00044D3C File Offset: 0x00042F3C
        private void tpCarrental_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
            Brush brush = new LinearGradientBrush(rect, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, rect);
        }

        // Token: 0x06000B3A RID: 2874 RVA: 0x00044D8C File Offset: 0x00042F8C
        private void tbPassport_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
            Brush brush = new LinearGradientBrush(rect, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, rect);
        }

        // Token: 0x06000B3B RID: 2875 RVA: 0x00044DDC File Offset: 0x00042FDC
        private void tpTour_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
            Brush brush = new LinearGradientBrush(rect, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, rect);
        }

        // Token: 0x06000B3C RID: 2876 RVA: 0x00044E2C File Offset: 0x0004302C
        private void tpHotel_Paint(object sender, PaintEventArgs e)
        {
            Graphics DS = e.Graphics;
            Rectangle table = new Rectangle(0, 0, base.Width, base.Height);
            Brush result = new LinearGradientBrush(table, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            DS.FillRectangle(result, table);
        }

        // Token: 0x06000B3D RID: 2877 RVA: 0x00044E7C File Offset: 0x0004307C
        private void tpAir_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
            Brush brush = new LinearGradientBrush(rect, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, rect);
        }             
    }
}
