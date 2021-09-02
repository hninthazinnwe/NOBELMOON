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
    public partial class frmPaymentTerm : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        string code = "";
        public frmPaymentTerm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.btnSave.Text == "Save")
            {
                if (!this.IsExit())
                {
                    Connection.PaymentTerm paymentTerm = new Connection.PaymentTerm();
                    if (this.txtCode.Text != "")
                    {
                        paymentTerm.CreatedDate = new DateTime?(DateTime.Now);
                        paymentTerm.Code = this.txtCode.Text;
                        paymentTerm.Description = this.txtDes.Text;
                        paymentTerm.n1 = (Convert.ToInt32(this.txtNo.Text));
                        paymentTerm.User = Utility.Utility.Staff;
                        paymentTerm.IsDelete = new bool?(false);
                        this.entity.AddToPaymentTerms(paymentTerm);
                        this.entity.SaveChanges();
                        MessageBox.Show("Save Successfully", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.Clear();
                        this.show();
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Name", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Already Exist!", "Code is Already Exist!");
                }
            }
            else
            {
                Connection.PaymentTerm paymentTerm = new Connection.PaymentTerm();
                paymentTerm = (from x in this.entity.PaymentTerms
                               where x.Code == this.code && x.IsDelete == (bool?)false
                               select x).FirstOrDefault<Connection.PaymentTerm>();
                if (this.txtCode.Text != "")
                {
                    paymentTerm.Code = this.txtCode.Text;
                    paymentTerm.Description = this.txtDes.Text;
                    paymentTerm.n1 = (Convert.ToInt32(this.txtNo.Text));
                    paymentTerm.User = Utility.Utility.Staff;
                    paymentTerm.IsDelete = new bool?(false);
                    this.entity.SaveChanges();
                    MessageBox.Show("Update Successfully", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Clear();
                    this.show();
                }
                else
                {
                    MessageBox.Show("Please Enter Name", "Error");
                }
            }
        }

        private Boolean IsExit()
        {
            string code = txtCode.Text;
            Connection.PaymentTerm c = new Connection.PaymentTerm();
            c = entity.PaymentTerms.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();
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

        private void frmPaymentTerm_Load(object sender, EventArgs e)
        {
            Clear();
            show();
        }

        private void show()
        {
            dgvPaymentTerm.Rows.Clear();
            List<Connection.PaymentTerm> list = entity.PaymentTerms.Where(x => x.IsDelete == false).ToList();
            int i = 0;
            foreach (var row in list)
            {
                dgvPaymentTerm.Rows.Add(++i, row.Code,row.n1, row.Description);
            }
        }
        private void Clear()
        {
            txtCode.Enabled = true;
            txtCode.Text = "";
            txtDes.Text = "";
            txtNo.Text = "0";
            btnSave.Text = "Save";
            txtCode.Focus();
        }

        private void dgvPaymentTerm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    if (e.RowIndex >= 0)
                    {
                        code = dgvPaymentTerm.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtCode.Text = dgvPaymentTerm.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtDes.Text = dgvPaymentTerm.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtNo.Text = dgvPaymentTerm.Rows[e.RowIndex].Cells[2].Value.ToString();
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
                            Connection.PaymentTerm c = new Connection.PaymentTerm();
                            code = dgvPaymentTerm.Rows[e.RowIndex].Cells[1].Value.ToString();
                            c = entity.PaymentTerms.Where(x => x.Code == code).FirstOrDefault();
                            c.Description = txtDes.Text;
                            c.IsDelete = true;
                            entity.SaveChanges();
                            frmPaymentTerm_Load(sender, e);
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
                txtNo.Focus();
            }
        }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }

        private void frmPaymentTerm_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvPaymentTerm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
            else
            { 
            
            }
        }
    }
}
