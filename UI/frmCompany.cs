using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace NobelMoon.UI
{
    public partial class frmCompany : Form
    {
        Connection.NobelMoonEntities1 entity = new Connection.NobelMoonEntities1();
        string code = "", path = ""; byte[] logoupdate;
        public frmCompany()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = @":D\";
                fldlg.Filter = "Image File(*.jpg;*.jpeg;*.bmp;*.gif)|*.jpg;*.jpeg;*.bmp;*.gif";

                if (fldlg.ShowDialog() == DialogResult.OK)
                {
                    path = fldlg.FileName.ToString();
                    txtLogo.Text = path;
                    pictureBox1.ImageLocation = path;

                    if (txtLogo.Text != "")
                    {
                        logoupdate = System.IO.File.ReadAllBytes(txtLogo.Text);
                    }
                }
            }
            catch (System.ArgumentException ae)
            {
                MessageBox.Show(ae.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void frmCompany_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.SkyBlue, Color.FromArgb(0, 52, 113), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);
        }

        private void show()
        {
            Connection.Company list = entity.Company.FirstOrDefault();
            if (list != null)
            {
                txtName.Text = list.Name;
                txtPhone.Text = list.Phone;
                txtFax.Text = list.Fax;
                txtEmail.Text = list.Email;
                txtWebsite.Text = list.Website;
                txtAddress.Text = list.Address;
                txtMessage.Text = list.Message;
                if (list.Logo != null)
                {
                    byte[] photoarray = (byte[])list.Logo;
                    MemoryStream ms = new MemoryStream(photoarray);
                    pictureBox1.Image = Image.FromStream(ms);
                    logoupdate = (byte[])list.Logo;
                }
                else pictureBox1.Image = null;
                code = list.Name;
                btnSave.Text = "Update";
            }
        }

        private void Clear()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";
            txtWebsite.Text = "";
            txtAddress.Text = "";
            txtMessage.Text = "";
            txtLogo.Text = "";
            pictureBox1.Image = null;
            txtName.Focus();
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            Clear();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                Connection.Company c = new Connection.Company();
                if (txtName.Text != "" && txtPhone.Text != "" && txtAddress.Text != "")
                {
                    c.Name = txtName.Text;
                    c.Phone = txtPhone.Text;
                    c.Fax = txtFax.Text;
                    c.Address = txtAddress.Text;
                    c.Email = txtEmail.Text;
                    c.Website = txtWebsite.Text;
                    c.Message = txtMessage.Text;
                    c.Logo = System.IO.File.ReadAllBytes(path);
                    entity.AddToCompany(c);
                    entity.SaveChanges();
                    MessageBox.Show("Save Successfully", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please Enter Code", "Error");
                }
            }
            else
            {
                Connection.Company c = new Connection.Company();
                c = entity.Company.Where(x => x.Name == code).FirstOrDefault();
                if (txtName.Text != "" && txtPhone.Text != "" && txtAddress.Text != "")
                {
                    c.Name = txtName.Text;
                    c.Phone = txtPhone.Text;
                    c.Fax = txtFax.Text;
                    c.Address = txtAddress.Text;
                    c.Email = txtEmail.Text;
                    c.Website = txtWebsite.Text;
                    c.Message = txtMessage.Text;
                    c.Logo = logoupdate;
                    entity.SaveChanges();
                    MessageBox.Show("Update Successfully", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please Enter Name", "Error");
                }
            }
            Clear();
            show();
        }
    }
}
