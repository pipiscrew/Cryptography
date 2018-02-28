using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace asymmetric
{
    public partial class PEM2_XML : Form
    {
        public PEM2_XML()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPEM_Private.Text = txtPEM_Private.Text.Replace(pem2xml.KEY_HEADER, "").Replace(pem2xml.KEY_FOOTER, "").Replace("\r", "").Replace("\n", "").Trim();

            if (txtPEM_Private.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please paste PEM!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            byte[] private_key = Convert.FromBase64String(txtPEM_Private.Text);
            RSACryptoServiceProvider RSA = pem2xml.DecodeRSAPrivateKey(private_key);

            txtXML_Private.Text = RSA.ToXmlString(true);



            //public
            string tmp_file = Path.GetTempFileName();
            TextWriter  writer = File.CreateText(tmp_file);

            pem2xml.ExportPublicKey(RSA, writer);
            writer.Dispose();

            txtPEM_Public.Text = File.ReadAllText(tmp_file); // or XML RSA.ToXmlString(false)
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtXML_Private.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please paste XML!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(1024, new CspParameters { ProviderType = 1 }))
            {

                RSA.FromXmlString(txtXML_Private.Text.Trim());

                string tmp_file = Path.GetTempFileName();
                TextWriter writer = File.CreateText(tmp_file);

                pem2xml.ExportPrivateKey(RSA, writer);
                writer.Dispose();

                txtPEM_Private.Text = File.ReadAllText(tmp_file);

                
                
                //public
                tmp_file = Path.GetTempFileName();
                writer = File.CreateText(tmp_file);

                pem2xml.ExportPublicKey(RSA, writer);
                writer.Dispose();

                txtPEM_Public.Text = File.ReadAllText(tmp_file); //  or XML RSA.ToXmlString(false)
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPEM_Public.Text = "";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://8gwifi.org/rsafunctions.jsp");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://superdry.apphb.com/tools/online-rsa-key-converter");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://lapo.it/asn1js/");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://travistidwell.com/jsencrypt/demo/");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.cryptosys.net/pki/rsakeyformats.html");
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://developerscripts.blogspot.com/2014/01/convert-rsa-to-pem.html");
            Process.Start("https://www.bbsmax.com/A/A7zgN3od4n/");
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://stackoverflow.com/a/47699716");

            //in the normal decryption tested and failed, tested and working with the posted example^ aka :
            //The javascript library you are using is leaving off the leading zeros. So to fix this in .NET you would do
            //public byte[] Decrypt(byte[] bytes)
            //{
            //    using (var rsa = new RSACryptoServiceProvider())
            //    {
            //        rsa.ImportParameters(PrivateParameters);

            //        // Correct the error in the JS encryptor.
            //        if (bytes.Length < rsa.KeySize / 8)
            //        {
            //            byte[] tmp = new byte[rsa.KeySize / 8];
            //            Buffer.BlockCopy(bytes, 0, tmp, tmp.Length - bytes.Length, bytes.Length);
            //            bytes = tmp;
            //        }

            //        return rsa.Decrypt(bytes, RSAEncryptionPadding.Pkcs1);
            //    }
            //}
        }

        static string priv;
        private void button4_Click(object sender, EventArgs e)
        {
            txtPEM_Private.Text = txtPEM_Private.Text.Replace(pem2xml.KEY_HEADER, "").Replace(pem2xml.KEY_FOOTER, "").Replace("\r", "").Replace("\n", "").Trim();

            if (txtPEM_Private.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please paste PEM!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

           priv = txtPEM_Private.Text;
           txtPEM_Private_Decrypted_Text.Text =  RSA_Decrypt(txtPEM_Private_Encrypted_Text.Text);
        }


        internal static string RSA_Decrypt(string data)
        {
            byte[] encrBytes = Convert.FromBase64String(data);
            byte[] plainBytes = Decrypt(encrBytes);

            string plainText = Encoding.UTF8.GetString(plainBytes, 0, plainBytes.Length);

            return plainText;
        }

        public static byte[] Decrypt(byte[] bytes)
        {
            byte[] private_key = Convert.FromBase64String(priv);

            //in normal way
            //RSACryptoServiceProvider RSA = pem2xml.DecodeRSAPrivateKey(private_key);
            //return RSA.Decrypt(bytes, false);

            //https://stackoverflow.com/a/47699716 - The javascript library you are using is leaving off the leading zeros.
            using (var rsa = pem2xml.DecodeRSAPrivateKey(private_key))
            {
                // Correct the error in the JS encryptor.
                if (bytes.Length < rsa.KeySize / 8)
                {
                    byte[] tmp = new byte[rsa.KeySize / 8];
                    Buffer.BlockCopy(bytes, 0, tmp, tmp.Length - bytes.Length, bytes.Length);
                    bytes = tmp;
                }

                return rsa.Decrypt(bytes, false);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtPEM_Private.Text = txtPEM_Private.Text.Replace(pem2xml.KEY_HEADER, "").Replace(pem2xml.KEY_FOOTER, "").Replace("\r", "").Replace("\n", "").Trim();

            if (txtPEM_Private.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please paste PEM!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            priv = txtPEM_Private.Text;

            byte[] private_key = Convert.FromBase64String(priv);

            using (var rsa = pem2xml.DecodeRSAPrivateKey(private_key))
            {
                byte[] plainBytes = Encoding.UTF8.GetBytes(txtPEM_Private_Decrypted_Text.Text);


                byte[] encryptedBytes = rsa.Encrypt(plainBytes, false);

                txtPEM_Private_Encrypted_Text.Text = Convert.ToBase64String(encryptedBytes);
            }

        }
    }
}
