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
    public partial class frmPeroid : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        string code = "";
        public frmPeroid()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.btnSave.Text == "Save")
            {
                if (!this.IsExit())
                {
                    Connection.Peroid c = new Connection.Peroid();
                    if (this.txtCode.Text != "")
                    {
                        c.Code = this.txtCode.Text;
                        c.Description = this.txtDes.Text;
                        c.CreatedDate = new DateTime?(DateTime.Now);
                        c.User = Utility.Utility.Staff;
                        c.IsDelete = new bool?(false);
                        this.entity.AddToPeroid(c);
                        this.entity.SaveChanges();
                        MessageBox.Show("Save Successfully", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Code", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Code is Already Exist!", "Message");
                }
            }
            else
            {
                Connection.Peroid c = new Connection.Peroid();
                c = (from x in this.entity.Peroid
                     where x.Description == this.code && x.IsDelete == (bool?)false
                     select x).FirstOrDefault<Connection.Peroid>();
                if (this.txtCode.Text != "")
                {
                    c.Code = this.txtCode.Text;
                    c.Description = this.txtDes.Text;
                    c.CreatedDate = new DateTime?(DateTime.Now);
                    c.User = Utility.Utility.Staff;
                    c.IsDelete = new bool?(false);
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
            Connection.Peroid c = new Connection.Peroid();
            c = entity.Peroid.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();
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

        private void dgvPeroid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    if (e.RowIndex >= 0)
                    {
                        code = dgvPeroid.Rows[e.RowIndex].Cells[1].Value.ToString();
                        Connection.Peroid p = new Connection.Peroid();
                        p = entity.Peroid.Where(x => x.Description == code && x.IsDelete == false).FirstOrDefault();
                        txtCode.Text = dgvPeroid.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtDes.Text = dgvPeroid.Rows[e.RowIndex].Cells[2].Value.ToString();
                        txtCode.Enabled = false;
                        btnSave.Text = "Update";
                    }
                }
                if (e.ColumnIndex == 4)
                {
                    if (e.RowIndex >= 0)
                    {
                        if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Connection.Peroid c = new Connection.Peroid();
                            code = dgvPeroid.Rows[e.RowIndex].Cells[1].Value.ToString();
                            c = entity.Peroid.Where(x => x.Description == code && x.IsDelete == false).FirstOrDefault();
                            c.IsDelete = true;
                            entity.SaveChanges();
                            frmPeroid_Load(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txtDes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }

        private void frmPeroid_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);  //graphics comes from a PaintEventArgs argument(event)
        }

        private void show()
        {
            dgvPeroid.Rows.Clear();
            List<Connection.Peroid> list = entity.Peroid.Where(x => x.IsDelete == false).ToList();
            int i = 0;
            foreach (var row in list)
            {
                dgvPeroid.Rows.Add(++i, row.Code,row.Description);
            }
        }

        private void Clear()
        {
            List<Connection.Peroid> p = new List<Connection.Peroid>();
            p = entity.Peroid.Where(x => x.IsDelete == false).ToList();

            txtCode.Text = "";
            txtDes.Text = "";
            btnSave.Text = "Save";
            txtCode.Enabled = true;
            txtCode.Focus();
        }

        private void frmPeroid_Load(object sender, EventArgs e)
        {
            Clear();
            show();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDes.Focus();
            }
        }
    }
}
