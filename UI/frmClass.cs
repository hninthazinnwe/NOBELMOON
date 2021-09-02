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
    public partial class frmClass : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        string classid = "";
        public frmClass()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.IsExit())
            {
                if (this.btnSave.Text == "Save")
                {
                    Connection.Class list = new Connection.Class();
                    if (this.txtName.Text != "")
                    {
                        list.Name = this.txtName.Text;
                        list.IsDelete = new bool?(false);
                        this.entity.AddToClasses(list);
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
                    Connection.Class list = new Connection.Class();
                    list = (from x in this.entity.Classes
                            where x.Name == this.classid && x.IsDelete == (bool?)false
                            select x).FirstOrDefault<Connection.Class>();
                    if (this.txtName.Text != "")
                    {
                        list.Name = this.txtName.Text;
                        list.IsDelete = new bool?(false);
                        this.entity.SaveChanges();
                        MessageBox.Show("Update Successfully", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Name", "Error");
                    }
                }
                this.Clear();
                this.Show();
            }
            else
            {
                MessageBox.Show("Name is Already Exist!", "Message");
            }
        }

        private Boolean IsExit()
        {
            string code = txtName.Text;
            Connection.Class c = new Connection.Class();
            c = entity.Classes.Where(x => x.Name == code && x.IsDelete == false).FirstOrDefault();
            if (c != null)
            {
                return true;
            }
            else return false;
        }

        private void Show()
        {
            dgvClass.Rows.Clear();
            List<Connection.Class> list = entity.Classes.Where(x=>x.IsDelete == false).ToList();
            int i = 0;
            foreach (var row in list)
            {
                dgvClass.Rows.Add(++i,row.Name);
            }            
        }

        private void dgvClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    if (e.RowIndex >= 0)
                    { 
                        classid = dgvClass.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtName.Text = dgvClass.Rows[e.RowIndex].Cells[1].Value.ToString();
                        btnSave.Text="Update";
                    }
                }
                if (e.ColumnIndex == 3)
                {
                    if (e.RowIndex >= 0)
                    {
                        if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Connection.Class c = new Connection.Class();
                            classid = dgvClass.Rows[e.RowIndex].Cells[1].Value.ToString();
                            c = entity.Classes.Where(x => x.Name == classid).FirstOrDefault();
                            c.Name = txtName.Text;
                            c.IsDelete = true;
                            entity.SaveChanges();
                            frmClass_Load(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void frmClass_Load(object sender, EventArgs e)
        {
            Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Clear()
        {
            txtName.Text = "";
            txtName.Focus();
            btnSave.Text = "Save";
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
                btnSave_Click(sender,e);
            }
        }

        private void frmClass_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);
        }

        private void btnMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
