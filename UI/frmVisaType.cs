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
    public partial class frmVisaType : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        string code = "";
        public frmVisaType()
        {
            InitializeComponent();
        }

        private void frmVisaType_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);  //graphics comes from a PaintEventArgs argument(event)
        }

        private void txtDes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
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
            if (!this.IsExit())
            {
                if (this.btnSave.Text == "Save")
                {
                    try
                    {
                        Connection.VisaType visaType = new Connection.VisaType();
                        if (this.txtDes.Text != "")
                        {
                            visaType.Description = this.txtDes.Text;
                            visaType.CreatedDate = new DateTime?(DateTime.Now);
                            visaType.User = Utility.Utility.Staff;
                            visaType.IsDelete = new bool?(false);
                            this.entity.AddToVisaTypes(visaType);
                            this.entity.SaveChanges();
                            MessageBox.Show("Save Successfully", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Code", "Error");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Visa Type is Already Exist!", "Message");
                }
            }
            else
            {
                Connection.VisaType visaType = new Connection.VisaType();
                visaType = (from x in this.entity.VisaTypes
                            where x.Description == this.code && x.IsDelete == (bool?)false
                            select x).FirstOrDefault<Connection.VisaType>();
                if (this.txtDes.Text != "")
                {
                    visaType.Description = this.txtDes.Text;
                    visaType.CreatedDate = new DateTime?(DateTime.Now);
                    visaType.User = Utility.Utility.Staff;
                    visaType.IsDelete = new bool?(false);
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
            string code = txtDes.Text;
            Connection.VisaType c = new Connection.VisaType();
            c = entity.VisaTypes.Where(x => x.Description == code && x.IsDelete == false).FirstOrDefault();
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

        private void frmVisaType_Load(object sender, EventArgs e)
        {
            Clear();
            Show();
        }

        private void show()
        {
            dgvVisaType.Rows.Clear();
            List<Connection.VisaType> list = entity.VisaTypes.Where(x => x.IsDelete == false).ToList();
            int i = 0;
            foreach (var row in list)
            {
                dgvVisaType.Rows.Add(++i, row.Description);
            }
        }

        private void Clear()
        {
            List<Connection.VisaType> p = new List<Connection.VisaType>();
            p = entity.VisaTypes.Where(x => x.IsDelete == false).ToList();

            txtDes.Text = "";
            btnSave.Text = "Save";
            txtDes.Enabled = true;
            txtDes.Focus();
        }

        private void dgvVisaType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    if (e.RowIndex >= 0)
                    {
                        code = dgvVisaType.Rows[e.RowIndex].Cells[1].Value.ToString();
                        Connection.VisaType p = new Connection.VisaType();
                        p = entity.VisaTypes.Where(x => x.Description == code && x.IsDelete == false).FirstOrDefault();

                        txtDes.Text = dgvVisaType.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtDes.Enabled = false;
                        btnSave.Text = "Update";
                    }
                }
                if (e.ColumnIndex == 3)
                {
                    if (e.RowIndex >= 0)
                    {
                        if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Connection.VisaType c = new Connection.VisaType();
                            code = dgvVisaType.Rows[e.RowIndex].Cells[1].Value.ToString();
                            c = entity.VisaTypes.Where(x => x.Description == code && x.IsDelete == false).FirstOrDefault();
                            c.IsDelete = true;
                            entity.SaveChanges();
                            frmVisaType_Load(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
