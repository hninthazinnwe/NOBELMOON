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
    public partial class frmVehicalName : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        string Name = "";
        public frmVehicalName()
        {
            InitializeComponent();
        }

        private void frmVehicalName_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);  
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void show()
        {
            dgvVehicalName.Rows.Clear();
            List<Connection.Vehical> list = entity.Vehicals.Where(x => x.IsDelete == false).ToList();
            int i = 0;
            foreach (var row in list)
            {
                dgvVehicalName.Rows.Add(++i, row.Name, row.Type);
            }
        }

        private void frmVehicalName_Load(object sender, EventArgs e)
        {
            Clear();
            show();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedItem.ToString() == "Airline")
            {
                groupBox1.Text = "New Airline";
            }
            else { groupBox1.Text = "New Bus"; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.IsExit())
            {
                if (this.btnSave.Text == "Save")
                {
                    Connection.Vehical c = new Connection.Vehical();
                    if (this.txtName.Text != "")
                    {
                        c.Name = this.txtName.Text;
                        c.CreatedDate = new DateTime?(DateTime.Now);
                        c.Type = this.cboType.SelectedItem.ToString();
                        c.User = Utility.Utility.Staff;
                        c.IsDelete = new bool?(false);
                        this.entity.AddToVehicals(c);
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
                    Connection.Vehical c = new Connection.Vehical();
                    c = (from x in this.entity.Vehicals
                         where x.Name == this.Name && x.IsDelete == (bool?)false
                         select x).FirstOrDefault<Connection.Vehical>();
                    if (this.txtName.Text != "")
                    {
                        c.Name = this.txtName.Text;
                        c.CreatedDate = new DateTime?(DateTime.Now);
                        c.Type = this.cboType.SelectedItem.ToString();
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
            else
            {
                MessageBox.Show("Name is Already Exist!", "Message");
            }
        }

        private Boolean IsExit()
        {
            string code = txtName.Text;
            Connection.Vehical c = new Connection.Vehical();
            c = entity.Vehicals.Where(x => x.Name == code && x.IsDelete == false).FirstOrDefault();
            if (c != null)
            {
                return true;
            }
            else return false;
        }

        private void Clear()
        {
            txtName.Text = "";
            cboType.SelectedIndex = 0;
            btnSave.Text = "Save";
            txtName.Focus();
            cboType.SelectedIndex = 0;
        }

        private void dgvVehicalName_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    if (e.RowIndex >= 0)
                    {
                        Name = dgvVehicalName.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtName.Text = dgvVehicalName.Rows[e.RowIndex].Cells[1].Value.ToString();
                        cboType.Text = dgvVehicalName.Rows[e.RowIndex].Cells[2].Value.ToString();
                        btnSave.Text = "Update";
                    }
                }
                if (e.ColumnIndex == 4)
                {
                    if (e.RowIndex >= 0)
                    {
                        if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Connection.Vehical c = new Connection.Vehical();
                            Name = dgvVehicalName.Rows[e.RowIndex].Cells[1].Value.ToString();
                            c = entity.Vehicals.Where(x => x.Name == Name && x.IsDelete == false).FirstOrDefault();
                            c.IsDelete = true;
                            entity.SaveChanges();
                            frmVehicalName_Load(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txtName_ImeModeChanged(object sender, EventArgs e)
        {

        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
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
                btnSave_Click(sender, e);
            }
        }
    }
}
