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
    public partial class frmCarType : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        string code = "";
        public frmCarType()
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
                    Connection.CarType carType = new Connection.CarType();
                    if (this.txtCode.Text != "")
                    {
                        carType.Code = this.txtCode.Text;
                        carType.Description = this.txtDes.Text;
                        carType.CreatedDate = new DateTime?(DateTime.Now);
                        carType.User = Utility.Utility.Staff;
                        carType.IsDelete = new bool?(false);
                        this.entity.AddToCarType(carType);
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
            else if (this.txtCode.Text != "")
            {
                Connection.CarType carType = new Connection.CarType();
                carType = (from x in this.entity.CarType
                           where x.Code == this.code && x.IsDelete == (bool?)false
                           select x).FirstOrDefault<Connection.CarType>();
                carType.Code = this.txtCode.Text;
                carType.Description = this.txtDes.Text;
                carType.CreatedDate = new DateTime?(DateTime.Now);
                carType.User = Utility.Utility.Staff;
                carType.IsDelete = new bool?(false);
                this.entity.SaveChanges();
                MessageBox.Show("Update Successfully", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Please Enter Name", "Error");
            }
            this.Clear();
            this.show();
        }

        private Boolean IsExit()
        {
            string code = txtCode.Text;
            Connection.CarType c = new Connection.CarType();
            c = entity.CarType.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();
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

        private void txtDes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }

        private void frmCarType_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);  //graphics comes from a PaintEventArgs argument(event)
        }

        private void frmCarType_Load(object sender, EventArgs e)
        {
            Clear();
            show();
        }

        private void show()
        {
            dgvCarType.Rows.Clear();
            List<Connection.CarType> list = entity.CarType.Where(x => x.IsDelete == false).ToList();
            int i = 0;
            foreach (var row in list)
            {
                dgvCarType.Rows.Add(++i, row.Code,row.Description);
            }
        }

        private void Clear()
        {
            List<Connection.CarType> p = new List<Connection.CarType>();
            p = entity.CarType.Where(x => x.IsDelete == false).ToList();

            txtDes.Text = "";
            txtCode.Text = "";
            btnSave.Text = "Save";
            txtCode.Enabled = true;
            txtCode.Focus();
        }

        private void dgvCarType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    if (e.RowIndex >= 0)
                    {
                        code = dgvCarType.Rows[e.RowIndex].Cells[1].Value.ToString();
                        Connection.CarType p = new Connection.CarType();
                        p = entity.CarType.Where(x => x.Description == code && x.IsDelete == false).FirstOrDefault();
                        txtCode.Text = dgvCarType.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtDes.Text = dgvCarType.Rows[e.RowIndex].Cells[2].Value.ToString();
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
                            Connection.CarType c = new Connection.CarType();
                            code = dgvCarType.Rows[e.RowIndex].Cells[1].Value.ToString();
                            c = entity.CarType.Where(x => x.Description == code && x.IsDelete == false).FirstOrDefault();
                            c.IsDelete = true;
                            entity.SaveChanges();
                            frmCarType_Load(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDes.Focus();
            }
        }
    }
}
