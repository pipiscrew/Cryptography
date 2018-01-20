using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace asymmetric
{
    public partial class frmDSA_ENCRYPT : Form
    {
        public frmDSA_ENCRYPT()
        {
            InitializeComponent();
        }

        private void txtEncryptionKey_TextChanged(object sender, EventArgs e)
        {
            label4.Text = txtEncryptionKey.Text.Length.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtContent.Visible = false;
            txtContent.Text = Program.generate_dummy_text(1000);
            txtContent.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtEncryptionKey.Text.Length !=8)
            {
                MessageBox.Show("Key size must be 8 chars!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            txtEncrypted.Text = dsa_encrypt.EncryptDataDES(txtContent.Text, txtEncryptionKey.Text); 
            button4.Visible = (txtEncrypted.Text.Length > 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtEncryptionKey.Text =  Program.GenerateRandomString(8);
        }

        private void txtEncrypted_TextChanged(object sender, EventArgs e)
        {
            label8.Text = txtEncrypted.Text.Length.ToString();
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            label2.Text = txtContent.Text.Length.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtEncryptionKey.Text.Length != 8)
            {
                MessageBox.Show("Key size must be 8 chars!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            txtDecrypted.Text = dsa_encrypt.DecryptDataDES(txtEncrypted.Text, txtEncryptionKey.Text);
            tabPanel2.SelectedIndex = 1;
        }

        private void txtDecrypted_TextChanged(object sender, EventArgs e)
        {
            label5.Text = txtDecrypted.Text.Length.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtContent2.Visible = false;
            txtContent2.Text = Program.generate_dummy_text(1000);
            txtContent2.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txtEncryptionKey2.Text.Length != 24)
            {
                MessageBox.Show("Key size must be 24 chars!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            txtEncrypted2.Text = dsa_encrypt.EncryptData3DES(txtContent2.Text, txtEncryptionKey2.Text);
            button5.Visible = (txtEncrypted2.Text.Length > 0);
        }

        private void txtContent2_TextChanged(object sender, EventArgs e)
        {
            label3.Text = txtContent2.Text.Length.ToString();
        }

        private void txtEncrypted2_TextChanged(object sender, EventArgs e)
        {
            label7.Text = txtEncrypted2.Text.Length.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtEncryptionKey2.Text.Length != 24)
            {
                MessageBox.Show("Key size must be 24 chars!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            txtDecrypted2.Text = dsa_encrypt.DecryptData3DES(txtEncrypted2.Text, txtEncryptionKey2.Text);
            tabControl1.SelectedIndex = 1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtEncryptionKey2.Text = Program.GenerateRandomString(24);
        }

        private void txtEncryptionKey2_TextChanged(object sender, EventArgs e)
        {
            label11.Text = txtEncryptionKey2.Text.Length.ToString();
        }

        private void txtDecrypted2_TextChanged(object sender, EventArgs e)
        {
            label9.Text = txtDecrypted2.Text.Length.ToString();
        }

        private void txtDESstory_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtDESstory.Dock == DockStyle.Fill)
            {
                txtDESstory.Dock = DockStyle.None;
                txtDESstory.SendToBack();
            }
                else {
                txtDESstory.Dock = DockStyle.Fill;
                txtDESstory.BringToFront();
            }
        }
    }
}
