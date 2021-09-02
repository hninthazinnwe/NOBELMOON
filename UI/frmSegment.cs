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
    public partial class frmSegment : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        string code = "";
        public frmSegment()
        {
            InitializeComponent();
        }

        private void frmSegment_Load(object sender, EventArgs e)
        {
            show();
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
            dgvSegment.Rows.Clear();
            List<Connection.Segment> list = entity.Segments.Where(x => x.IsDelete == false).ToList();
            int i = 0;
            foreach (var row in list)
            {
                dgvSegment.Rows.Add(++i,row.Code, row.Name);
            }            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.btnSave.Text == "Save")
            {
                if (!this.IsExit())
                {
                    Connection.Segment segment = new Connection.Segment();
                    if (this.txtName.Text != "")
                    {
                        segment.Code = this.txtCode.Text;
                        segment.Name = this.txtName.Text;
                        segment.IsDelete = new bool?(false);
                        this.entity.AddToSegments(segment);
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
            else
            {
                Connection.Segment segment = new Connection.Segment();
                segment = (from x in this.entity.Segments
                           where x.Code == this.code && x.IsDelete == (bool?)false
                           select x).FirstOrDefault<Connection.Segment>();
                if (this.txtName.Text != "")
                {
                    segment.Code = this.txtCode.Text;
                    segment.Name = this.txtName.Text;
                    segment.IsDelete = new bool?(false);
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
            Connection.Segment c = new Connection.Segment();
            c = entity.Segments.Where(x => x.Code == code && x.IsDelete == false).FirstOrDefault();
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

        private void dgvSegment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    if (e.RowIndex >= 0)
                    {
                        code = dgvSegment.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtCode.Text = dgvSegment.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtName.Text = dgvSegment.Rows[e.RowIndex].Cells[2].Value.ToString();
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
                            Connection.Segment c = new Connection.Segment();
                            code = dgvSegment.Rows[e.RowIndex].Cells[1].Value.ToString();
                            c = entity.Segments.Where(x => x.Code == code).FirstOrDefault();
                            c.Name = txtName.Text;
                            c.IsDelete = true;
                            entity.SaveChanges();
                            frmSegment_Load(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Clear()
        {
            txtCode.Enabled = true;
            txtCode.Text = "";
            txtName.Text = "";
            btnSave.Text = "Save";
            txtCode.Focus();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtName.Focus();
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
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

        private void frmSegment_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);
        }
    }
}
