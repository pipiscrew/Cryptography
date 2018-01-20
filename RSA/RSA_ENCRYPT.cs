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
    public partial class RSA_ENCRYPT : Form
    {
        public RSA_ENCRYPT()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rsa_method.create_keypair();

            txtPrivate.Text = rsa_method.private_key;
            label3.Text = txtPrivate.Text.Length.ToString();
            txtPublic.Text = rsa_method.public_key;
            label4.Text = txtPublic.Text.Length.ToString();
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            label7.Text = txtContent.Text.Length.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtContent.Visible = false;
            txtContent.Text += Program.generate_dummy_text(1000);
            txtContent.Visible = true;
        }

        private void txtEncrypted_TextChanged(object sender, EventArgs e)
        {
            label8.Text = txtEncrypted.Text.Length.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rsa_method.private_key == null)
            {
                MessageBox.Show("Please generate keypair!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

           txtEncrypted.Text =  rsa_method.RSA_Encrypt(txtContent.Text);
           button4.Visible = (txtEncrypted.Text.Length >0);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            txtContent.Visible = false;
            txtContent.Text = Program.generate_dummy_text(3).Substring(0,117);
            txtContent.Visible = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (rsa_method.private_key == null)
            {
                MessageBox.Show("Please generate keypair!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            txtDecrypted.Text = rsa_method.RSA_Decrypt(txtEncrypted.Text);
            tabPanel2.SelectedIndex = 1;
        }

        private void txtDecrypted_TextChanged(object sender, EventArgs e)
        {
            label6.Text = txtDecrypted.Text.Length.ToString();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://certsimple.com/blog/measuring-ssl-rsa-keys");
        }
    }
}
