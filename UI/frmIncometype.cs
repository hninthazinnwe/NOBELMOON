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
    public partial class frmIncometype : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        string code = "";
        public frmIncometype()
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
                    Connection.IncomeType carType = new Connection.IncomeType();
                    if (this.txtCode.Text != "")
                    {
                        carType.Code = this.txtCode.Text;
                        carType.Description = this.txtDes.Text;
                        carType.CreatedDate = (DateTime)(DateTime.Now);
                        carType.User = Utility.Utility.Staff;
                        carType.IsDelete = false;
                        this.entity.AddToIncomeType(carType);
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
                Connection.IncomeType carType = new Connection.IncomeType();
                carType = (from x in this.entity.IncomeType
                           where x.Code == this.code && x.IsDelete == (bool?)false
                           select x).FirstOrDefault<Connection.IncomeType>();
                carType.Code = this.txtCode.Text;
                carType.Description = this.txtDes.Text;
                carType.CreatedDate = DateTime.Now;
                carType.User = Utility.Utility.Staff;
                carType.IsDelete = false;
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
            Connection.IncomeType c = new Connection.IncomeType();
            c = entity.IncomeType.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();
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

        private void frmIncometype_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);  //graphics comes from a PaintEventArgs argument(event)
        }

        private void frmIncometype_Load(object sender, EventArgs e)
        {
            Clear();
            show();
        }

        private void show()
        {
            dgvIncomeType.Rows.Clear();
            List<Connection.IncomeType> list = entity.IncomeType.Where(x => x.IsDelete == false).ToList();
            int i = 0;
            foreach (var row in list)
            {
                dgvIncomeType.Rows.Add(++i, row.Code,row.Description);
            }
        }

        private void Clear()
        {
            List<Connection.IncomeType> p = new List<Connection.IncomeType>();
            p = entity.IncomeType.Where(x => x.IsDelete == false).ToList();

            txtDes.Text = "";
            txtCode.Text = "";
            btnSave.Text = "Save";
            txtCode.Enabled = true;
            txtCode.Focus();
        }

        private void dgvIncomeType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    if (e.RowIndex >= 0)
                    {
                        code = dgvIncomeType.Rows[e.RowIndex].Cells[1].Value.ToString();
                        Connection.IncomeType p = new Connection.IncomeType();
                        p = entity.IncomeType.Where(x => x.Description == code && x.IsDelete == false).FirstOrDefault();
                        txtCode.Text = dgvIncomeType.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtDes.Text = dgvIncomeType.Rows[e.RowIndex].Cells[2].Value.ToString();
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
                            Connection.IncomeType c = new Connection.IncomeType();
                            code = dgvIncomeType.Rows[e.RowIndex].Cells[1].Value.ToString();
                            c = entity.IncomeType.Where(x => x.Description == code && x.IsDelete == false).FirstOrDefault();
                            c.IsDelete = true;
                            entity.SaveChanges();
                            frmIncometype_Load(sender, e);
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
