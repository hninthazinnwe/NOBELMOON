﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NobelMoon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for t  application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmMain());
            Application.Run(new UI.frmLogIn());
        }
    }
}
