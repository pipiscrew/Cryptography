using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace asymmetric
{
    public partial class frmCNG : Form
    {
        public frmCNG()
        {
            InitializeComponent();
        }

        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
            Process.Start("https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsacng?view=netframework-4.7");
            
        }

        private void linkLabel2_MouseClick(object sender, MouseEventArgs e)
        {
            Process.Start("https://msdn.microsoft.com/en-us/library/system.security.cryptography(v=vs.110).aspx");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://msdn.microsoft.com/en-us/library/windows/desktop/aa376210(v=vs.85).aspx");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://securitydriven.net/inferno/");
        }
    }
}
