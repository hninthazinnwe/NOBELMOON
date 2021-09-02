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
    public partial class frmUser : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        string code = "";
        public frmUser()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            Clear();
            show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.btnSave.Text == "Save")
            {
                if (!this.IsExit())
                {
                    Connection.TblUser tblUser = new Connection.TblUser();
                    if (this.txtCode.Text != "")
                    {
                        tblUser.CreatedDate = new DateTime?(DateTime.Now);
                        tblUser.Code = this.txtCode.Text;
                        tblUser.StaffCode = this.cboStaff.SelectedValue.ToString();
                        tblUser.Role = "";
                        tblUser.Password = this.txtPassword.Text;
                        tblUser.User = Utility.Utility.Staff;
                        tblUser.IsDelete = new bool?(false);
                        this.entity.AddToTblUsers(tblUser);
                        this.entity.SaveChanges();
                        MessageBox.Show("Save Successfully", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Name", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Code is Already Exist!", "Message");
                }
            }
            else
            {
                Connection.TblUser tblUser = new Connection.TblUser();
                tblUser = (from x in this.entity.TblUsers
                           where x.Code == this.code && x.IsDelete == (bool?)false
                           select x).FirstOrDefault<Connection.TblUser>();
                if (this.txtCode.Text != "")
                {
                    tblUser.Code = this.txtCode.Text;
                    tblUser.StaffCode = this.cboStaff.SelectedValue.ToString();
                    tblUser.Role = "";
                    tblUser.User = Utility.Utility.Staff;
                    if (this.txtPassword.Text != "")
                    {
                        tblUser.Password = this.txtPassword.Text;
                    }
                    tblUser.IsDelete = new bool?(false);
                    this.entity.SaveChanges();
                    MessageBox.Show("Update Successfully", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Please Enter Name", "Error");
                }
            }
            this.Clear();
            this.show();
        }

        private Boolean IsExit()
        {
            if (btnSave.Text == "Save ")
            {
                string code = txtCode.Text;
                Connection.TblUser c = new Connection.TblUser();
                c = entity.TblUsers.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();
                if (c != null)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    if (e.RowIndex >= 0)
                    {
                        code = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtCode.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                        string s = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                        cboStaff.SelectedValue = s;
                        string r = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtCode.Enabled = false;
                        cboRole.SelectedValue = r;

                        btnSave.Text = "Update";
                    }
                }
                if (e.ColumnIndex == 6)
                {
                    if (e.RowIndex >= 0)
                    {
                        if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Connection.TblUser c = new Connection.TblUser();
                            code = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                            c = entity.TblUsers.Where(x => x.Code == code).FirstOrDefault();
                            c.IsDelete = true;
                            entity.SaveChanges();
                            frmUser_Load(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void show()
        {
            List<Connection.Staff> s = new List<Connection.Staff>();
            s = entity.Staffs.Where(x => x.IsDelete == false).ToList();
            cboStaff.DataSource = s;
            cboStaff.DisplayMember = "Name";
            cboStaff.ValueMember = "Code";

            List<Connection.Role> r = new List<Connection.Role>();
            r = entity.Roles.Where(x => x.IsDelete == false).ToList();
            cboRole.DataSource = r;
            cboRole.DisplayMember = "Description";
            cboRole.ValueMember = "Code";

            dgvUser.Rows.Clear();
            List<Connection.TblUser> list = entity.TblUsers.Where(x => x.IsDelete == false).ToList();
            int i = 0;
            foreach (var row in list)
            {
                dgvUser.Rows.Add(++i, row.Code, row.StaffCode,row.Role);
            }
        }
        private void Clear()
        {
            txtCode.Enabled = true;
            txtCode.Text = "";
            if (cboStaff.DataSource != null)
            {
                cboStaff.SelectedIndex = 0;
            }
            if (cboRole.DataSource != null)
            {
                cboRole.SelectedIndex = 0;
            }
            txtPassword.Text = "";
            btnSave.Text = "Save";
            txtCode.Focus();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboStaff.Focus();
            }
        }

        private void cboStaff_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboRole.Focus();
            }
        }

        private void cboRole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }

        private void frmUser_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);
        }
    }
}
