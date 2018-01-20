using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows.Forms;
using System.Xml;


namespace asymmetric
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            textBox1.Text = asymmetric.Properties.Resources.CipherModes_and_Padding;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Form2 frm = new Form2();
            //frm.TopLevel = false;
            //frm.Visible = true;
            //frm.FormBorderStyle = FormBorderStyle.None;
            //frm.Dock = DockStyle.Fill;
            //tabControl1.TabPages[0].Controls.Add(frm);

            addform2tabpage(new frmDSA_HASH(), tabControl1.TabPages[0]);
            addform2tabpage(new frmDSA_ENCRYPT(), tabControl1.TabPages[1]);
            addform2tabpage(new RSA_HASH(), tabControl1.TabPages[2]);
            addform2tabpage(new RSA_ENCRYPT(), tabControl1.TabPages[3]);
            addform2tabpage(new frmAES_ENCRYPT(), tabControl1.TabPages[4]);
            addform2tabpage(new frmCNG(), tabControl1.TabPages[5]);

        }

        private void addform2tabpage(Form frm, TabPage tab)
        {
            frm.TopLevel = false;
            frm.Visible = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            tab.Controls.Add(frm);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] buff = Convert.FromBase64String(txtRSA.Text);
            txtPlain.Text = BitConverter.ToString(buff).Replace("-", string.Empty);// System.Text.Encoding.UTF8.GetString(buff);


            BitArray bits = new BitArray(buff);
            label6.Text = bits.Length.ToString() + " bits";


            //
            byte[] toBytes = Encoding.ASCII.GetBytes(txtPlain.Text);
            BitArray bits2 = new BitArray(toBytes);
            label3.Text = (bits2.Length / 2).ToString() + " bits";
            Console.Write(toBytes);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtTextBase64.Text = Convert.ToBase64String(Encoding.UTF8.GetBytes(txtText.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtText.Text = Encoding.UTF8.GetString(Convert.FromBase64String(txtTextBase64.Text));
        }


    }
}