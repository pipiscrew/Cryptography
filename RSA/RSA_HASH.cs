using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace asymmetric
{
    public partial class RSA_HASH : Form
    {
        public RSA_HASH()
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (rsa_method.private_key == null)
            {
                MessageBox.Show("Please generate keypair!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string g = txtContent.Text;

            string[] report = rsa_method.sign(g);
            txtSign.Text = report[0];
            label6.Text = report[1];

            label5.Text = txtSign.Text.Length.ToString();
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

        private void button4_Click(object sender, EventArgs e)
        {
            // TODO SEE - https://msdn.microsoft.com/en-us/library/75wfb4f2(v=vs.110).aspx
            //https://msdn.microsoft.com/en-us/library/system.security.cryptography.xml.dsakeyvalue(v=vs.100).aspx

            //working 
            //src - https://blogs.msdn.microsoft.com/shawnfa/2004/03/31/signing-specific-xml-with-references/
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(@"<xml>
                          <signed id='tag1'>Signed Data</signed>
                          <unsigned id='tag2'>Unsigned Data</unsigned>
                          <signed id='tag3'>More Signed Data</signed>
                        </xml>");

            SignedXml signer = new SignedXml(doc);
            signer.AddReference(new Reference("#tag1"));
            signer.AddReference(new Reference("#tag3"));
            signer.SigningKey = new RSACryptoServiceProvider();
            signer.ComputeSignature();

            //modify the unsigned #tag2
            XmlElement unsignedElem = doc.SelectSingleNode("//xml/unsigned") as XmlElement;
            unsignedElem.InnerText = "Modified Data";

            SignedXml verifier = new SignedXml(doc);
            verifier.LoadXml(signer.GetXml());

            if (verifier.CheckSignature(signer.SigningKey))
                Console.WriteLine("Pass");
            else
                Console.WriteLine("Fail");
        }


        // XML itself signing
        //https://docs.microsoft.com/en-us/dotnet/standard/security/how-to-sign-xml-documents-with-digital-signatures
        //https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.xml.signedxml?view=netframework-4.5
        //https://www.stum.de/2016/05/19/net-framework-4-6-2-adds-support-to-sign-xml-documents-using-rsa-sha256/
    }
}
