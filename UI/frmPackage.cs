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
    public partial class frmPackage : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        string code = "";
        public frmPackage()
        {
            InitializeComponent();
        }

        private void frmPackage_Paint(object sender, PaintEventArgs e)
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
            dgvPackage.Rows.Clear();
            List<Connection.Package> list = entity.Packages.Where(x => x.IsDelete == false).ToList();
            Connection.PackageType pt = new Connection.PackageType();
            int i = 0;
            foreach (var row in list)
            {
                pt = entity.PackageTypes.Where(x => x.Code == row.Type && x.IsDelete == false).FirstOrDefault();
                dgvPackage.Rows.Add(++i, row.Code, row.Description,pt.Description,row.Price);
            }
        }

        private void Clear()
        {
            List<Connection.PackageType> p = new List<Connection.PackageType>();
            p = entity.PackageTypes.Where(x => x.IsDelete == false).ToList();
            cboType.DataSource = p;
            cboType.DisplayMember = "Description";
            cboType.ValueMember = "Code";

            txtCode.Text = "";
            txtDes.Text = "";
            txtPrice.Text = "0";
            txtDetail.Text = "";
            cboType.SelectedIndex = 0;
            btnSave.Text = "Save";
            txtCode.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.btnSave.Text == "Save")
            {
                if (!this.IsExit())
                {
                    Connection.Package package = new Connection.Package();
                    if (this.txtCode.Text != "")
                    {
                        package.Code = this.txtCode.Text;
                        package.CreatedDate = new DateTime?(DateTime.Now);
                        package.Description = this.txtDes.Text;
                        package.Type = this.cboType.SelectedValue.ToString();
                        package.Price = new decimal?(int.Parse(this.txtPrice.Text));
                        package.Detail = this.txtDetail.Text;
                        package.User = Utility.Utility.Staff;
                        package.IsDelete = new bool?(false);
                        this.entity.AddToPackages(package);
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
                Connection.Package package = new Connection.Package();
                package = (from x in this.entity.Packages
                           where x.Code == this.code && x.IsDelete == (bool?)false
                           select x).FirstOrDefault<Connection.Package>();
                if (this.txtCode.Text != "")
                {
                    package.Code = this.txtCode.Text;
                    package.CreatedDate = new DateTime?(DateTime.Now);
                    package.Description = this.txtDes.Text;
                    package.Type = this.cboType.SelectedValue.ToString();
                    package.Price = new decimal?(int.Parse(this.txtPrice.Text));
                    package.Detail = this.txtDetail.Text;
                    package.User = Utility.Utility.Staff;
                    package.IsDelete = new bool?(false);
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
            Connection.Package c = new Connection.Package();
            c = entity.Packages.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();
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

        private void dgvPackage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    if (e.RowIndex >= 0)
                    {
                        code = dgvPackage.Rows[e.RowIndex].Cells[1].Value.ToString();
                        Connection.Package p = new Connection.Package();
                        p = entity.Packages.Where(x => x.Code ==code && x.IsDelete == false).FirstOrDefault();

                        txtCode.Text = dgvPackage.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtDes.Text = dgvPackage.Rows[e.RowIndex].Cells[2].Value.ToString();
                        cboType.Text = dgvPackage.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtPrice.Text = dgvPackage.Rows[e.RowIndex].Cells[4].Value.ToString(); 
                        txtDetail.Text = p.Detail;
                        btnSave.Text = "Update";
                    }
                }
                if (e.ColumnIndex == 6)
                {
                    if (e.RowIndex >= 0)
                    {
                        if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Connection.Package c = new Connection.Package();
                            code = dgvPackage.Rows[e.RowIndex].Cells[1].Value.ToString();
                            c = entity.Packages.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();
                            c.IsDelete = true;
                            entity.SaveChanges();
                            frmPackage_Load(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void frmPackage_Load(object sender, EventArgs e)
        {
            Clear();
            show();
        }

        private void txtDetail_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
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
                cboType.Focus();
            }
        }

        private void cboType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPrice.Focus();
            }
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDetail.Focus();
            }
        }
    }
}
