using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace asymmetric
{
    public partial class frmDSA_HASH : Form
    {
        public frmDSA_HASH()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dsa_hash.private_key == null)
            {
                MessageBox.Show("Please generate keypair!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string g = txtContent.Text;

            string[] report = dsa_hash.sign(g);
            txtSign.Text = report[0];
            label6.Text = report[1];

            label5.Text = txtSign.Text.Length.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dsa_hash.create_keypair();
            
            txtPrivate.Text = dsa_hash.private_key;
            label3.Text = txtPrivate.Text.Length.ToString();
            txtPublic.Text = dsa_hash.public_key;
            label4.Text = txtPublic.Text.Length.ToString();
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            label9.Text = txtContent.Text.Length.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //https://en.wikipedia.org/wiki/Digital_Signature_Algorithm
            Process.Start("https://security.stackexchange.com/questions/46939/dsa-generates-different-signatures-with-the-same-data");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtContent.Visible = false;
            txtContent.Text += Program.generate_dummy_text(1000);
            txtContent.Visible = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://hashtoolkit.com/");
        }



    }
}
