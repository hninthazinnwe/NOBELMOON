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
    public partial class frmRequireLetter : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        string code = "";
        public frmRequireLetter()
        {
            InitializeComponent();
        }

        private void frmRequireLetter_Load(object sender, EventArgs e)
        {
            Clear();
            show();
        }

        private void frmRequireLetter_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);  //graphics comes from a PaintEventArgs argument(event)
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
                    Connection.RequireLetter requireLetter = new Connection.RequireLetter();
                    if (this.txtDes.Text != "")
                    {
                        requireLetter.Code = this.txtCode.Text;
                        requireLetter.Description = this.txtDes.Text;
                        requireLetter.Type = this.cboType.Text;
                        requireLetter.CreatedDate = new DateTime?(DateTime.Now);
                        requireLetter.User = Utility.Utility.Staff;
                        requireLetter.IsDelete = new bool?(false);
                        this.entity.AddToRequireLetter(requireLetter);
                        this.entity.SaveChanges();
                        MessageBox.Show("Save Successfully", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Required Letter Description", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Code is Already Exist!", "Message");
                }
            }
            else
            {
                Connection.RequireLetter requireLetter = new Connection.RequireLetter();
                requireLetter = (from x in this.entity.RequireLetter
                                 where x.Code == this.code && x.IsDelete == (bool?)false
                                 select x).FirstOrDefault<Connection.RequireLetter>();
                if (this.txtDes.Text != "")
                {
                    requireLetter.Code = this.txtCode.Text;
                    requireLetter.Description = this.txtDes.Text;
                    requireLetter.Type = this.cboType.Text;
                    requireLetter.CreatedDate = new DateTime?(DateTime.Now);
                    requireLetter.User = Utility.Utility.Staff;
                    requireLetter.IsDelete = new bool?(false);
                    this.entity.SaveChanges();
                    MessageBox.Show("Update Successfully", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Please Enter Required Letter Description", "Error");
                }
            }
            this.Clear();
            this.show();
        }

        private Boolean IsExit()
        {
            string code = txtCode.Text;
            Connection.RequireLetter c = new Connection.RequireLetter();
            c = entity.RequireLetter.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();
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

        private void dgvRequirement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    if (e.RowIndex >= 0)
                    {
                        code = dgvRequirement.Rows[e.RowIndex].Cells[1].Value.ToString();
                        Connection.RequireLetter p = new Connection.RequireLetter();
                        p = entity.RequireLetter.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();

                        txtCode.Text = dgvRequirement.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtDes.Text = dgvRequirement.Rows[e.RowIndex].Cells[2].Value.ToString();
                        cboType.Text = dgvRequirement.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtDes.Enabled = false;
                        btnSave.Text = "Update";
                    }
                }
                if (e.ColumnIndex == 5)
                {
                    if (e.RowIndex >= 0)
                    {
                        if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Connection.RequireLetter c = new Connection.RequireLetter();
                            code = dgvRequirement.Rows[e.RowIndex].Cells[1].Value.ToString();
                            c = entity.RequireLetter.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();
                            c.IsDelete = true;
                            entity.SaveChanges();
                            frmRequireLetter_Load(sender, e);
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
            dgvRequirement.Rows.Clear();
            List<Connection.RequireLetter> list = entity.RequireLetter.Where(x => x.IsDelete == false).ToList();
            int i = 0;
            foreach (var row in list)
            {
                dgvRequirement.Rows.Add(++i,row.Code, row.Description,row.Type);
            }
        }

        private void Clear()
        {
            List<Connection.RequireLetter> p = new List<Connection.RequireLetter>();
            p = entity.RequireLetter.Where(x => x.IsDelete == false).ToList();

            txtCode.Text = "";
            txtDes.Text = "";
            btnSave.Text = "Save";
            txtDes.Enabled = true;
            cboType.SelectedIndex = 0;
            txtCode.Focus();
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
    }
}
