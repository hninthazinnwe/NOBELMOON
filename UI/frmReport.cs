using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data; sing System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace NobelMoon.UI
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        public frmReport(System.Data.DataSet Ds,string type)
        {

        }

        private void frmReport_Load(object sender, EventArgs e)
        {

        }
    }
}
