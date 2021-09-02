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
    public partial class frmStaff : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        string code = "";
        public frmStaff()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.btnSave.Text == "Save")
            {
                if (!this.IsExit())
                {
                    Connection.Staff staff = new Connection.Staff();
                    if (this.txtCode.Text != "")
                    {
                        staff.CreatedDate = new DateTime?(DateTime.Now);
                        staff.Code = this.txtCode.Text;
                        staff.Name = this.txtName.Text;
                        staff.NRC = this.txtNRC.Text;
                        staff.Phone = this.txtPhone.Text;
                        staff.Email = this.txtEmail.Text;
                        staff.Address = this.txtAddress.Text;
                        staff.User = Utility.Utility.Staff;
                        staff.IsDelete = new bool?(false);
                        this.entity.AddToStaffs(staff);
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
                Connection.Staff staff = new Connection.Staff();
                staff = (from x in this.entity.Staffs
                         where x.Code == this.code && x.IsDelete == (bool?)false
                         select x).FirstOrDefault<Connection.Staff>();
                if (this.txtCode.Text != "")
                {
                    staff.Code = this.txtCode.Text;
                    staff.Name = this.txtName.Text;
                    staff.Phone = this.txtPhone.Text;
                    staff.Email = this.txtEmail.Text;
                    staff.NRC = this.txtNRC.Text;
                    staff.Address = this.txtAddress.Text;
                    staff.User = Utility.Utility.Staff;
                    staff.IsDelete = new bool?(false);
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
            string code = txtCode.Text;
            Connection.Staff c = new Connection.Staff();
            c = entity.Staffs.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();
            if (c != null)
            {
                return true;
            }
            else return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Clear()
        {
            txtCode.Enabled = true;
            txtCode.Text = "";
            txtName.Text = "";
            txtNRC.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            btnSave.Text = "Save";
            txtCode.Focus();
        }
        private void show()
        {
            List<Connection.Staff> s = new List<Connection.Staff>();
            s = entity.Staffs.Where(x => x.IsDelete == false).ToList();

            dgvStaff.Rows.Clear();
            int i = 0;
            foreach (var row in s)
            {
                dgvStaff.Rows.Add(++i, row.Code, row.Name,row.NRC,row.Phone);
            }
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    if (e.RowIndex >= 0)
                    {
                        code = dgvStaff.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtCode.Text = dgvStaff.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtName.Text = dgvStaff.Rows[e.RowIndex].Cells[2].Value.ToString();
                        txtNRC.Text = dgvStaff.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtPhone.Text = dgvStaff.Rows[e.RowIndex].Cells[4].Value.ToString();
                        Connection.Staff s = new Connection.Staff();
                        s = entity.Staffs.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();
                        txtEmail.Text = s.Email;
                        txtAddress.Text = s.Address;
                        txtCode.Enabled = false;
                        
                        btnSave.Text = "Update";
                    }
                }
                if (e.ColumnIndex == 6)
                {
                    if (e.RowIndex >= 0)
                    {
                        if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Connection.Staff c = new Connection.Staff();
                            code = dgvStaff.Rows[e.RowIndex].Cells[1].Value.ToString();
                            c = entity.Staffs.Where(x => x.Code == code).FirstOrDefault();
                            c.IsDelete = true;
                            entity.SaveChanges();
                            frmStaff_Load(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void frmStaff_Load(object sender, EventArgs e)
        {
            Clear(); show();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtName.Focus();
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNRC.Focus();
            }
        }

        private void txtNRC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPhone.Focus();
            }
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress.Focus();
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
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

        private void frmStaff_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);
        }
    }
}
