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
    public partial class frmPackageType : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        string code = "";
        public frmPackageType()
        {
            InitializeComponent();
        }

        private void frmPackageType_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle); 
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void show()
        {
            dgvPackageType.Rows.Clear();
            List<Connection.PackageType> list = entity.PackageTypes.Where(x => x.IsDelete == false).ToList();
            int i = 0;
            foreach (var row in list)
            {
                dgvPackageType.Rows.Add(++i, row.Code, row.Description);
            }
        }

        private void Clear()
        {
            txtCode.Text = "";
            txtDes.Text = "";
            btnSave.Text = "Save";
            txtCode.Focus();
        }

        private void frmPackageType_Load(object sender, EventArgs e)
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
                    Connection.PackageType c = new Connection.PackageType();
                    if (this.txtCode.Text != "")
                    {
                        c.Code = this.txtCode.Text;
                        c.CreatedDate = new DateTime?(DateTime.Now);
                        c.Description = this.txtDes.Text;
                        c.User = Utility.Utility.Staff;
                        c.IsDelete = new bool?(false);
                        this.entity.AddToPackageTypes(c);
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
                Connection.PackageType c = new Connection.PackageType();
                c = (from x in this.entity.PackageTypes
                     where x.Code == this.code && x.IsDelete == (bool?)false
                     select x).FirstOrDefault<Connection.PackageType>();
                if (this.txtCode.Text != "")
                {
                    c.Code = this.txtCode.Text;
                    c.CreatedDate = new DateTime?(DateTime.Now);
                    c.Description = this.txtDes.Text;
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
            Connection.PackageType c = new Connection.PackageType();
            c = entity.PackageTypes.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();
            if (c != null)
            {
                return true;
            }
            else return false;
        }

        private void dgvPackageType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    if (e.RowIndex >= 0)
                    {
                        Name = dgvPackageType.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtCode.Text = dgvPackageType.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtDes.Text = dgvPackageType.Rows[e.RowIndex].Cells[2].Value.ToString();
                        btnSave.Text = "Update";
                    }
                }
                if (e.ColumnIndex == 4)
                {
                    if (e.RowIndex >= 0)
                    {
                        if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Connection.PackageType c = new Connection.PackageType();
                            Name = dgvPackageType.Rows[e.RowIndex].Cells[1].Value.ToString();
                            c = entity.PackageTypes.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();
                            c.IsDelete = true;
                            entity.SaveChanges();
                            frmPackageType_Load(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDes.Focus();
            }
        }

        private void txtDes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }
    }
}
