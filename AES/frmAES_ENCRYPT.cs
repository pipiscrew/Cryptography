using asymmetric.AES;
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
    public partial class frmAES_ENCRYPT : Form
    {
        public frmAES_ENCRYPT()
        {
            InitializeComponent();
        }

        private void txtHelp_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtHelp.Dock == DockStyle.Fill)
            {
                txtHelp.Dock = DockStyle.None;
                txtHelp.SendToBack();
            }
            else
            {
                txtHelp.Dock = DockStyle.Fill;
                txtHelp.BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtEncryptionKey.Text.Length != 32)
            {
                MessageBox.Show("Key size must be 32 chars!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            txtEncrypted.Text = aes_encrypt.EncryptDataAES(txtContent.Text, txtEncryptionKey.Text);
            button4.Visible = (txtEncrypted.Text.Length > 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtEncryptionKey.Text = Program.GenerateRandomString(32);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtEncryptionKey.Text.Length != 32)
            {
                MessageBox.Show("Key size must be 32 chars!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            txtDecrypted.Text = aes_encrypt.DecryptDataAES(txtEncrypted.Text, txtEncryptionKey.Text);
            tabPanel2.SelectedIndex = 1;
        }

        private void txtEncrypted_TextChanged(object sender, EventArgs e)
        {
            label8.Text = txtEncrypted.Text.Length.ToString();
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            label2.Text = txtContent.Text.Length.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtContent.Visible = false;
            txtContent.Text = Program.generate_dummy_text(1000);
            txtContent.Visible = true;
        }

        private void txtDecrypted_TextChanged(object sender, EventArgs e)
        {
            label5.Text = txtDecrypted.Text.Length.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtEncryptionKey2.Text = Program.GenerateRandomString(32);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txtEncryptionKey2.Text.Length != 16 && txtEncryptionKey2.Text.Length != 32)
            {
                MessageBox.Show("Key size must be 16 or 32 bytes!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            txtEncrypted2.Text = aes_encrypt.EncryptDataRijndael(txtContent2.Text, txtEncryptionKey2.Text);
            button5.Visible = (txtEncrypted2.Text.Length > 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtEncryptionKey2.Text.Length != 16 && txtEncryptionKey2.Text.Length != 32)
            {
                MessageBox.Show("Key size must be 16 or 32 bytes!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            txtDecrypted2.Text = aes_encrypt.DecryptDataRijndael(txtEncrypted2.Text, txtEncryptionKey2.Text);
            tabControl1.SelectedIndex = 1;
        }

        private void txtContent2_TextChanged(object sender, EventArgs e)
        {
            label3.Text = txtContent2.Text.Length.ToString();                
        }

        private void txtEncrypted2_TextChanged(object sender, EventArgs e)
        {
            label7.Text = txtEncrypted2.Text.Length.ToString();
        }

        private void txtDecrypted2_TextChanged(object sender, EventArgs e)
        {
            label9.Text = txtDecrypted2.Text.Length.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtContent2.Visible = false;
            txtContent2.Text = Program.generate_dummy_text(1000);
            txtContent2.Visible = true;
        }

        private void txtEncryptionKey_TextChanged(object sender, EventArgs e)
        {
            label4.Text = txtEncryptionKey.Text.Length.ToString();
        }

        private void txtEncryptionKey2_TextChanged(object sender, EventArgs e)
        {
            label11.Text = txtEncryptionKey2.Text.Length.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.codeproject.com/Tips/834977/Using-RSA-and-AES-for-File-Encryption");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://msdn.microsoft.com/en-us/library/system.security.cryptography.aescng.aspx");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/dotnet/corefx/issues/10544");
        }
    }
}
