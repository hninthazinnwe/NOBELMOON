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
    public partial class frmHotel : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        string code = "";
        public frmHotel()
        {
            InitializeComponent();
        }

        private void frmHotel_Load(object sender, EventArgs e)
        {
            Clear();
            show();
        }

        private void frmHotel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);  //graphics comes from a PaintEventArgs argument(event)
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.IsExit())
            {
                if (this.btnSave.Text == "Save")
                {
                    Connection.Hotel hotel = new Connection.Hotel();
                    if (this.txtDes.Text != "")
                    {
                        hotel.Name = this.txtDes.Text;
                        hotel.CreatedDate = new DateTime?(DateTime.Now);
                        hotel.StarRate = this.txtRate.Text;
                        hotel.User = Utility.Utility.Staff;
                        hotel.IsDelete = new bool?(false);
                        this.entity.AddToHotels(hotel);
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
                    Connection.Hotel hotel = new Connection.Hotel();
                    hotel = (from x in this.entity.Hotels
                             where x.Name == this.code && x.IsDelete == (bool?)false
                             select x).FirstOrDefault<Connection.Hotel>();
                    if (this.txtDes.Text != "")
                    {
                        hotel.Name = this.txtDes.Text;
                        hotel.CreatedDate = new DateTime?(DateTime.Now);
                        hotel.StarRate = this.txtRate.Text;
                        hotel.User = Utility.Utility.Staff;
                        hotel.IsDelete = new bool?(false);
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
            string code = txtDes.Text;
            Connection.Hotel c = new Connection.Hotel();
            c = entity.Hotels.Where(x => x.Name == code && x.IsDelete == false).FirstOrDefault();
            if (c != null)
            {
                return true;
            }
            else return false;
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
            dgvHotel.Rows.Clear();
            List<Connection.Hotel> list = entity.Hotels.Where(x => x.IsDelete == false).ToList();
            int i = 0;
            foreach (var row in list)
            {
                dgvHotel.Rows.Add(++i, row.Name, row.StarRate);
            }
        }

        private void Clear()
        {
            List<Connection.Hotel> p = new List<Connection.Hotel>();
            p = entity.Hotels.Where(x => x.IsDelete == false).ToList();

            txtRate.Text = "";
            txtDes.Text = "";
            btnSave.Text = "Save";
            txtDes.Enabled = true;
            txtDes.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgvHotel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    if (e.RowIndex >= 0)
                    {
                        code = dgvHotel.Rows[e.RowIndex].Cells[1].Value.ToString();
                        Connection.Hotel p = new Connection.Hotel();
                        p = entity.Hotels.Where(x => x.Name == code && x.IsDelete == false).FirstOrDefault();

                        txtDes.Text = dgvHotel.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtRate.Text = dgvHotel.Rows[e.RowIndex].Cells[2].Value.ToString();
                        txtDes.Enabled = false;
                        btnSave.Text = "Update";
                    }
                }
                if (e.ColumnIndex == 4)
                {
                    if (e.RowIndex >= 0)
                    {
                        if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Connection.Hotel c = new Connection.Hotel();
                            code = dgvHotel.Rows[e.RowIndex].Cells[1].Value.ToString();
                            c = entity.Hotels.Where(x => x.Name == code && x.IsDelete == false).FirstOrDefault();
                            c.IsDelete = true;
                            entity.SaveChanges();
                            frmHotel_Load(sender, e);
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
                txtRate.Focus();
            }
        }

        private void txtRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }
    }
}
