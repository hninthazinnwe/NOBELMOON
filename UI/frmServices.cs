using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NobelMoon.UI
{
    public partial class frmServices : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        string code = "";
        public frmServices()
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
                    Connection.Services services = new Connection.Services();
                    if (this.txtDes.Text != "")
                    {
                        services.Code = this.txtCode.Text;
                        services.CreateDate = new DateTime?(DateTime.Now);
                        services.Description = this.txtDes.Text;
                        services.Transaction = this.cboTransaction.Text;
                        services.User = Utility.Utility.Staff;
                        services.IsDelete = new bool?(false);
                        this.entity.AddToServices(services);
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
                Connection.Services services = new Connection.Services();
                services = (from x in this.entity.Services
                            where x.Code == this.code && x.IsDelete == (bool?)false
                            select x).FirstOrDefault<Connection.Services>();
                if (this.txtDes.Text != "")
                {
                    services.CreateDate = new DateTime?(DateTime.Now);
                    services.Description = this.txtDes.Text;
                    services.Transaction = this.cboTransaction.Text;
                    services.User = Utility.Utility.Staff;
                    services.IsDelete = new bool?(false);
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
            Connection.Services c = new Connection.Services();
            c = entity.Services.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();
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

        private void txtCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmServices_Load(object sender, EventArgs e)
        {
            Clear();
            show();
        }

        private void dgvSegment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    if (e.RowIndex >= 0)
                    {
                        code = dgvServices.Rows[e.RowIndex].Cells[1].Value.ToString();
                        Connection.Services p = new Connection.Services();
                        p = entity.Services.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();

                        txtCode.Text = dgvServices.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtDes.Text = dgvServices.Rows[e.RowIndex].Cells[2].Value.ToString();
                        cboTransaction.Text = dgvServices.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtCode.Enabled = false;
                        txtDes.Focus();
                        btnSave.Text = "Update";
                    }
                }
                if (e.ColumnIndex == 5)
                {
                    if (e.RowIndex >= 0)
                    {
                        if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Connection.Services c = new Connection.Services();
                            code = dgvServices.Rows[e.RowIndex].Cells[1].Value.ToString();
                            c = entity.Services.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();
                            c.IsDelete = true;
                            entity.SaveChanges();
                            frmServices_Load(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void frmServices_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);  //graphics comes from a PaintEventArgs argument(event)
        }

        private void show()
        {
            dgvServices.Rows.Clear();
            List<Connection.Services> list = entity.Services.Where(x => x.IsDelete == false).ToList();
            int i = 0;
            foreach (var row in list)
            {
                dgvServices.Rows.Add(++i, row.Code, row.Description,row.Transaction);
            }
        }

        private void Clear()
        {
            List<Connection.Services> p = new List<Connection.Services>();
            p = entity.Services.Where(x => x.IsDelete == false).ToList();

            txtCode.Text = "";
            txtDes.Text = "";
            cboTransaction.SelectedIndex = 0;
            btnSave.Text = "Save";
            txtCode.Enabled = true;
            txtCode.Focus();
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
                cboTransaction.Focus();
            }
        }

        private void cboTransaction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }
    }
}
