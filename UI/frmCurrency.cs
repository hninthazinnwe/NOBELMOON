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
    public partial class frmCurrency : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        string code = "";
        public frmCurrency()
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

        private void frmCurrency_Load(object sender, EventArgs e)
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
                    Connection.Currency currency = new Connection.Currency();
                    if (this.txtCode.Text != "")
                    {
                        currency.CreatedDate = new DateTime?(DateTime.Now);
                        currency.Code = this.txtCode.Text;
                        currency.Description = this.txtDes.Text;
                        currency.Rate = new decimal?(int.Parse(this.txtRate.Text));
                        currency.t1 = this.txtOperator.Text;
                        currency.User = Utility.Utility.Staff;
                        currency.IsDelete = new bool?(false);
                        this.entity.AddToCurrencies(currency);
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
            else if (this.txtCode.Text != "")
            {
                Connection.Currency currency = new Connection.Currency();
                currency = (from x in this.entity.Currencies
                            where x.Code == this.code && x.IsDelete == (bool?)false
                            select x).FirstOrDefault<Connection.Currency>();
                currency.Code = this.txtCode.Text;
                currency.Description = this.txtDes.Text;
                currency.Rate = new decimal?(int.Parse(this.txtRate.Text));
                currency.t1 = this.txtOperator.Text;
                currency.User = Utility.Utility.Staff;
                currency.IsDelete = new bool?(false);
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
            Connection.Currency c = new Connection.Currency();
            c = entity.Currencies.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();
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

        private void dgvCurrency_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    if (e.RowIndex >= 0)
                    {
                        code = dgvCurrency.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtCode.Text = dgvCurrency.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtDes.Text = dgvCurrency.Rows[e.RowIndex].Cells[2].Value.ToString();
                        txtRate.Text = dgvCurrency.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtOperator.Text = dgvCurrency.Rows[e.RowIndex].Cells[4].Value.ToString();
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
                            Connection.Currency c = new Connection.Currency();
                            code = dgvCurrency.Rows[e.RowIndex].Cells[1].Value.ToString();
                            c = entity.Currencies.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();
                            c.Description = txtDes.Text;
                            c.IsDelete = true;
                            entity.SaveChanges();
                            frmCurrency_Load(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void show()
        {
            dgvCurrency.Rows.Clear();
            List<Connection.Currency> list = entity.Currencies.Where(x => x.IsDelete == false).ToList();
            int i = 0;
            foreach (var row in list)
            {
                dgvCurrency.Rows.Add(++i, row.Code, row.Description,row.Rate,row.t1);
            }
        }
        private void Clear()
        {
            txtCode.Enabled = true;
            txtCode.Focus();
            txtCode.Text = "";
            txtDes.Text = "";
            txtRate.Text = "0";
            txtOperator.Text = "";
            btnSave.Text = "Save";
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
                txtOperator.Focus();
            }
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtRate.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtRate.Text = txtRate.Text.Remove(txtRate.Text.Length - 1);
            }
        }

        private void txtOperator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }

        private void frmCurrency_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);
        }
    }
}
