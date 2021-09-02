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
    public partial class frmLogIn : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        string f = "";
        public frmLogIn()
        {
            InitializeComponent();
        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            this.Clear();
            //this.txtUser.Focus();
        }

        // Token: 0x06000BFD RID: 3069 RVA: 0x00057174 File Offset: 0x00055374
        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string user = this.txtUser.Text;
                Connection.TblUser u = new Connection.TblUser();
                u = (from x in this.entity.TblUsers
                     where x.Code == user && x.IsDelete == (bool?)false
                     select x).FirstOrDefault<Connection.TblUser>();
                if (u != null)
                {
                    Connection.Staff staff = new Connection.Staff();
                    staff = (from x in this.entity.Staffs
                             where x.Code == u.StaffCode && x.IsDelete == (bool?)false
                             select x).FirstOrDefault<Connection.Staff>();
                    if (u != null)
                    {
                        this.txtStaff.Text = staff.Name;
                        this.txtPassword.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid User!");
                }
            }
        }

        // Token: 0x06000BFE RID: 3070 RVA: 0x00057824 File Offset: 0x00055A24
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string user = this.txtUser.Text;
                string text = this.txtPassword.Text;
                Connection.TblUser u = new Connection.TblUser();
                Connection.Staff staff = new Connection.Staff();
                List<Connection.Authorization> list = new List<Connection.Authorization>();
                u = (from x in this.entity.TblUsers
                     where x.Code == user && x.IsDelete == (bool?)false
                     select x).FirstOrDefault<Connection.TblUser>();
                staff = (from x in this.entity.Staffs
                         where x.Code == u.StaffCode && x.IsDelete == (bool?)false
                         select x).FirstOrDefault<Connection.Staff>();
                list = (from x in this.entity.Authorizations
                        where x.Staff == u.StaffCode
                        select x).ToList<Connection.Authorization>();
                if (u.Password == text)
                {
                    Utility.Utility.User = u.Code;
                    Utility.Utility.Staff = staff.Name;
                    if (list.Count != 0)
                    {
                        Utility.Utility._AirTicket_New = Convert.ToBoolean((from x in list
                                                                    where x.Code == "01"
                                                                    select x.IsChecked).FirstOrDefault<bool?>());
                        Utility.Utility._AirTicket_History = Convert.ToBoolean((from x in list
                                                                        where x.Code == "02"
                                                                        select x.IsChecked).FirstOrDefault<bool?>());
                        Utility.Utility._AirTicket_Report = Convert.ToBoolean((from x in list
                                                                       where x.Code == "03"
                                                                       select x.IsChecked).FirstOrDefault<bool?>());
                        Utility.Utility._Hotel_New = Convert.ToBoolean((from x in list
                                                                where x.Code == "04"
                                                                select x.IsChecked).FirstOrDefault<bool?>());
                        Utility.Utility._Hotel_History = Convert.ToBoolean((from x in list
                                                                    where x.Code == "05"
                                                                    select x.IsChecked).FirstOrDefault<bool?>());
                        Utility.Utility._Hotel_Report = Convert.ToBoolean((from x in list
                                                                   where x.Code == "06"
                                                                   select x.IsChecked).FirstOrDefault<bool?>());
                        Utility.Utility._Tour_New = Convert.ToBoolean((from x in list
                                                               where x.Code == "07"
                                                               select x.IsChecked).FirstOrDefault<bool?>());
                        Utility.Utility._Tour_History = Convert.ToBoolean((from x in list
                                                                   where x.Code == "08"
                                                                   select x.IsChecked).FirstOrDefault<bool?>());
                        Utility.Utility._Tour_Report = Convert.ToBoolean((from x in list
                                                                  where x.Code == "09"
                                                                  select x.IsChecked).FirstOrDefault<bool?>());
                        Utility.Utility._Passport_New = Convert.ToBoolean((from x in list
                                                                   where x.Code == "10"
                                                                   select x.IsChecked).FirstOrDefault<bool?>());
                        Utility.Utility._Passport_History = Convert.ToBoolean((from x in list
                                                                       where x.Code == "11"
                                                                       select x.IsChecked).FirstOrDefault<bool?>());
                        Utility.Utility._Passport_Report = Convert.ToBoolean((from x in list
                                                                      where x.Code == "12"
                                                                      select x.IsChecked).FirstOrDefault<bool?>());
                        Utility.Utility._Carrental_New = Convert.ToBoolean((from x in list
                                                                    where x.Code == "13"
                                                                    select x.IsChecked).FirstOrDefault<bool?>());
                        Utility.Utility._Carrental_History = Convert.ToBoolean((from x in list
                                                                        where x.Code == "14"
                                                                        select x.IsChecked).FirstOrDefault<bool?>());
                        Utility.Utility._Carrental_Report = Convert.ToBoolean((from x in list
                                                                       where x.Code == "15"
                                                                       select x.IsChecked).FirstOrDefault<bool?>());
                        Utility.Utility._Setup_New = Convert.ToBoolean((from x in list
                                                                where x.Code == "16"
                                                                select x.IsChecked).FirstOrDefault<bool?>());
                        Utility.Utility._Backup = Convert.ToBoolean((from x in list
                                                             where x.Code == "17"
                                                             select x.IsChecked).FirstOrDefault<bool?>());
                        Utility.Utility._Authorization = Convert.ToBoolean((from x in list
                                                                    where x.Code == "18"
                                                                    select x.IsChecked).FirstOrDefault<bool?>());
                        Utility.Utility._CashReceive = Convert.ToBoolean((from x in list
                                                                  where x.Code == "20"
                                                                  select x.IsChecked).FirstOrDefault<bool?>());
                    }
                    FrmMain frmMain = new FrmMain();
                    frmMain.Show();
                    base.Hide();
                }
                else
                {
                    this.txtPassword.Text = "";
                    MessageBox.Show("Incorrect Password!");
                }
            }
        }

        // Token: 0x06000BFF RID: 3071 RVA: 0x00058230 File Offset: 0x00056430
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }

        // Token: 0x06000C00 RID: 3072 RVA: 0x0005823B File Offset: 0x0005643B
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Token: 0x06000C01 RID: 3073 RVA: 0x00058244 File Offset: 0x00056444
        private void frmLogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        // Token: 0x06000C02 RID: 3074 RVA: 0x00058247 File Offset: 0x00056447
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        // Token: 0x06000C03 RID: 3075 RVA: 0x0005824A File Offset: 0x0005644A
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtPassword.Clear();
            this.txtStaff.Clear();
            this.txtUser.Clear();
        }

        // Token: 0x06000C04 RID: 3076 RVA: 0x000586F0 File Offset: 0x000568F0
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = this.txtUser.Text;
            string graphics = this.txtPassword.Text;
            Connection.TblUser u = new Connection.TblUser();
            Connection.Staff gradient_rectangle = new Connection.Staff();
            List<Connection.Authorization> brush = new List<Connection.Authorization>();
            u = (from x in this.entity.TblUsers
                 where x.Code == user && x.IsDelete == (bool?)false
                 select x).FirstOrDefault<Connection.TblUser>();
            gradient_rectangle = (from x in this.entity.Staffs
                                  where x.Code == u.StaffCode && x.IsDelete == (bool?)false
                                  select x).FirstOrDefault<Connection.Staff>();
            brush = (from x in this.entity.Authorizations
                     where x.Staff == u.StaffCode
                     select x).ToList<Connection.Authorization>();
            if (u.Password == graphics)
            {
                Utility.Utility.User = u.Code;
                Utility.Utility.Staff = gradient_rectangle.Name;
                if (brush.Count != 0)
                {
                    Utility.Utility._AirTicket_New = Convert.ToBoolean((from x in brush
                                                                where x.Code == "01"
                                                                select x.IsChecked).FirstOrDefault<bool?>());
                    Utility.Utility._AirTicket_History = Convert.ToBoolean((from x in brush
                                                                    where x.Code == "02"
                                                                    select x.IsChecked).FirstOrDefault<bool?>());
                    Utility.Utility._AirTicket_Report = Convert.ToBoolean((from x in brush
                                                                   where x.Code == "03"
                                                                   select x.IsChecked).FirstOrDefault<bool?>());
                    Utility.Utility._Hotel_New = Convert.ToBoolean((from x in brush
                                                            where x.Code == "04"
                                                            select x.IsChecked).FirstOrDefault<bool?>());
                    Utility.Utility._Hotel_History = Convert.ToBoolean((from x in brush
                                                                where x.Code == "05"
                                                                select x.IsChecked).FirstOrDefault<bool?>());
                    Utility.Utility._Hotel_Report = Convert.ToBoolean((from x in brush
                                                               where x.Code == "06"
                                                               select x.IsChecked).FirstOrDefault<bool?>());
                    Utility.Utility._Tour_New = Convert.ToBoolean((from x in brush
                                                           where x.Code == "07"
                                                           select x.IsChecked).FirstOrDefault<bool?>());
                    Utility.Utility._Tour_History = Convert.ToBoolean((from x in brush
                                                               where x.Code == "08"
                                                               select x.IsChecked).FirstOrDefault<bool?>());
                    Utility.Utility._Tour_Report = Convert.ToBoolean((from x in brush
                                                              where x.Code == "09"
                                                              select x.IsChecked).FirstOrDefault<bool?>());
                    Utility.Utility._Passport_New = Convert.ToBoolean((from x in brush
                                                               where x.Code == "10"
                                                               select x.IsChecked).FirstOrDefault<bool?>());
                    Utility.Utility._Passport_History = Convert.ToBoolean((from x in brush
                                                                   where x.Code == "11"
                                                                   select x.IsChecked).FirstOrDefault<bool?>());
                    Utility.Utility._Passport_Report = Convert.ToBoolean((from x in brush
                                                                  where x.Code == "12"
                                                                  select x.IsChecked).FirstOrDefault<bool?>());
                    Utility.Utility._Carrental_New = Convert.ToBoolean((from x in brush
                                                                where x.Code == "13"
                                                                select x.IsChecked).FirstOrDefault<bool?>());
                    Utility.Utility._Carrental_History = Convert.ToBoolean((from x in brush
                                                                    where x.Code == "14"
                                                                    select x.IsChecked).FirstOrDefault<bool?>());
                    Utility.Utility._Carrental_Report = Convert.ToBoolean((from x in brush
                                                                   where x.Code == "15"
                                                                   select x.IsChecked).FirstOrDefault<bool?>());
                    Utility.Utility._Setup_New = Convert.ToBoolean((from x in brush
                                                            where x.Code == "16"
                                                            select x.IsChecked).FirstOrDefault<bool?>());
                    Utility.Utility._Backup = Convert.ToBoolean((from x in brush
                                                         where x.Code == "17"
                                                         select x.IsChecked).FirstOrDefault<bool?>());
                    Utility.Utility._Authorization = Convert.ToBoolean((from x in brush
                                                                where x.Code == "18"
                                                                select x.IsChecked).FirstOrDefault<bool?>());
                    Utility.Utility._CashReceive = Convert.ToBoolean((from x in brush
                                                              where x.Code == "20"
                                                              select x.IsChecked).FirstOrDefault<bool?>());
                }
                FrmMain frmMain = new FrmMain();
                frmMain.Show();
                base.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect Password!");
            }
        }

        // Token: 0x06000C05 RID: 3077 RVA: 0x000590D2 File Offset: 0x000572D2
        private void Clear()
        {
            this.txtUser.Text = "";
            this.txtStaff.Text = "";
            this.txtPassword.Text = "";
        }

        // Token: 0x06000C06 RID: 3078 RVA: 0x00059108 File Offset: 0x00057308
        private void frmLogIn_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
            Brush brush = new LinearGradientBrush(rect, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, rect);
            //if (txtUser.Text == "")
            //{
            //    txtUser.Focus();
            //}
        }

        // Token: 0x06000C07 RID: 3079 RVA: 0x00059157 File Offset: 0x00057357
        private void label1_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x06000C08 RID: 3080 RVA: 0x0005915A File Offset: 0x0005735A
        private void frmLogIn_Shown(object sender, EventArgs e)
        {
            this.txtUser.Focus();
        }
    }
}
