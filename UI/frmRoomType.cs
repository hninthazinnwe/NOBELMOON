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
    public partial class frmRoomType : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        string code = "";
        public frmRoomType()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.btnSave.Text == "Save")
            {
                if (!this.IsExit())
                {
                    Connection.RoomType roomType = new Connection.RoomType();
                    if (this.txtCode.Text != "")
                    {
                        roomType.Code = this.txtCode.Text;
                        roomType.Description = this.txtDes.Text;
                        roomType.Rate = new decimal?(int.Parse(this.txtRate.Text));
                        roomType.User = Utility.Utility.Staff;
                        roomType.IsDelete = new bool?(false);
                        this.entity.AddToRoomTypes(roomType);
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
                Connection.RoomType roomType = new Connection.RoomType();
                roomType = (from x in this.entity.RoomTypes
                            where x.Code == this.code && x.IsDelete == (bool?)false
                            select x).FirstOrDefault<Connection.RoomType>();
                if (this.txtCode.Text != "")
                {
                    roomType.Code = this.txtCode.Text;
                    roomType.Description = this.txtDes.Text;
                    roomType.Rate = new decimal?(int.Parse(this.txtRate.Text));
                    roomType.User = Utility.Utility.Staff;
                    roomType.IsDelete = new bool?(false);
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
            Connection.RoomType c = new Connection.RoomType();
            c = entity.RoomTypes.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();
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
            dgvRoomType.Rows.Clear();
            List<Connection.RoomType> list = entity.RoomTypes.Where(x => x.IsDelete == false).ToList();
            int i = 0;
            foreach (var row in list)
            {
                dgvRoomType.Rows.Add(++i, row.Code, row.Description,row.Rate);
            }
        }
        private void Clear()
        {
            txtCode.Enabled = true;
            txtCode.Text = "";
            txtDes.Text = "";
            txtRate.Text = "0";
            btnSave.Text = "Save";
            txtCode.Focus();
        }

        private void frmRoomType_Load(object sender, EventArgs e)
        {
            Clear();
            show();
        }

        private void dgvRoomType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    if (e.RowIndex >= 0)
                    {
                        code = dgvRoomType.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtCode.Text = dgvRoomType.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtDes.Text = dgvRoomType.Rows[e.RowIndex].Cells[2].Value.ToString();
                        txtRate.Text = dgvRoomType.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtCode.Enabled = false;
                        btnSave.Text = "Update";
                    }
                }
                if (e.ColumnIndex == 5)
                {
                    if (e.RowIndex >= 0)
                    {
                        if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Connection.RoomType c = new Connection.RoomType();
                            code = dgvRoomType.Rows[e.RowIndex].Cells[1].Value.ToString();
                            c = entity.RoomTypes.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();
                            c.IsDelete = true;
                            entity.SaveChanges();
                            frmRoomType_Load(sender, e);
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

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics graphics = e.Graphics;
            //Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            //Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.MidnightBlue, 45f);
            //graphics.FillRectangle(brush, gradient_rectangle);  //graphics comes from a PaintEventArgs argument(event)
        }

        private void frmRoomType_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);  //graphics comes from a PaintEventArgs argument(event)
        }
    }
}
