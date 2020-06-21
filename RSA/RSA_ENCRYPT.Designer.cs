namespace asymmetric
{
    partial class RSA_ENCRYPT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabPanel2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEncrypted = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDecrypted = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPublic = new System.Windows.Forms.TextBox();
            this.txtPrivate = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBednerEncrypted = new System.Windows.Forms.TextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBednerDecrypted = new System.Windows.Forms.TextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.tabPanel2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtContent);
            this.groupBox1.Location = new System.Drawing.Point(12, 344);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(826, 236);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "digital sign";
            // 
            // tabPanel2
            // 
            this.tabPanel2.Controls.Add(this.tabPage1);
            this.tabPanel2.Controls.Add(this.tabPage2);
            this.tabPanel2.Location = new System.Drawing.Point(3, 3);
            this.tabPanel2.Name = "tabPanel2";
            this.tabPanel2.SelectedIndex = 0;
            this.tabPanel2.Size = new System.Drawing.Size(498, 210);
            this.tabPanel2.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtEncrypted);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(490, 182);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "encrypt";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(11, 85);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 39);
            this.button4.TabIndex = 13;
            this.button4.Text = "decrypt to 2tab";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 39);
            this.button1.TabIndex = 12;
            this.button1.Text = "encrypt >>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 15);
            this.label8.TabIndex = 11;
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtEncrypted
            // 
            this.txtEncrypted.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEncrypted.Location = new System.Drawing.Point(110, 3);
            this.txtEncrypted.MaxLength = 0;
            this.txtEncrypted.Multiline = true;
            this.txtEncrypted.Name = "txtEncrypted";
            this.txtEncrypted.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEncrypted.Size = new System.Drawing.Size(374, 174);
            this.txtEncrypted.TabIndex = 10;
            this.txtEncrypted.TextChanged += new System.EventHandler(this.txtEncrypted_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtDecrypted);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(490, 182);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "decrypt";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 15);
            this.label6.TabIndex = 12;
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDecrypted
            // 
            this.txtDecrypted.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDecrypted.Location = new System.Drawing.Point(110, 3);
            this.txtDecrypted.MaxLength = 0;
            this.txtDecrypted.Multiline = true;
            this.txtDecrypted.Name = "txtDecrypted";
            this.txtDecrypted.ReadOnly = true;
            this.txtDecrypted.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDecrypted.Size = new System.Drawing.Size(374, 174);
            this.txtDecrypted.TabIndex = 11;
            this.txtDecrypted.TextChanged += new System.EventHandler(this.txtDecrypted_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(149, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "add dummy text";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 15);
            this.label7.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(722, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 15);
            this.label5.TabIndex = 6;
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtContent
            // 
            this.txtContent.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContent.Location = new System.Drawing.Point(17, 42);
            this.txtContent.MaxLength = 0;
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(244, 188);
            this.txtContent.TabIndex = 0;
            this.txtContent.TextChanged += new System.EventHandler(this.txtContent_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtPublic);
            this.groupBox2.Controls.Add(this.txtPrivate);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(826, 315);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "create keypair";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(684, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 15);
            this.label4.TabIndex = 6;
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(346, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 5;
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(459, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Public Key :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(124, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Private Key :";
            // 
            // txtPublic
            // 
            this.txtPublic.Location = new System.Drawing.Point(462, 40);
            this.txtPublic.Multiline = true;
            this.txtPublic.Name = "txtPublic";
            this.txtPublic.ReadOnly = true;
            this.txtPublic.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPublic.Size = new System.Drawing.Size(320, 258);
            this.txtPublic.TabIndex = 2;
            // 
            // txtPrivate
            // 
            this.txtPrivate.Location = new System.Drawing.Point(124, 41);
            this.txtPrivate.Multiline = true;
            this.txtPrivate.Name = "txtPrivate";
            this.txtPrivate.ReadOnly = true;
            this.txtPrivate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrivate.Size = new System.Drawing.Size(320, 258);
            this.txtPrivate.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "generate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(297, 331);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(425, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "The results show a 2048 bit RSA key is equivalent to around 116 bits of a symmetr" +
    "ic algo";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.tabControl1.Location = new System.Drawing.Point(288, 13);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(540, 223);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tabPanel2);
            this.tabPage3.Location = new System.Drawing.Point(26, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(510, 215);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "casual";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tabControl2);
            this.tabPage4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage4.Location = new System.Drawing.Point(26, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(510, 215);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "use private";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Location = new System.Drawing.Point(6, 2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(498, 210);
            this.tabControl2.TabIndex = 14;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.linkLabel2);
            this.tabPage5.Controls.Add(this.button5);
            this.tabPage5.Controls.Add(this.button6);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.txtBednerEncrypted);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(490, 182);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "encrypt";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(11, 85);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 39);
            this.button5.TabIndex = 13;
            this.button5.Text = "decrypt to 2tab";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(11, 40);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 39);
            this.button6.TabIndex = 12;
            this.button6.Text = "encrypt >>";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 15);
            this.label9.TabIndex = 11;
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBednerEncrypted
            // 
            this.txtBednerEncrypted.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBednerEncrypted.Location = new System.Drawing.Point(110, 3);
            this.txtBednerEncrypted.MaxLength = 0;
            this.txtBednerEncrypted.Multiline = true;
            this.txtBednerEncrypted.Name = "txtBednerEncrypted";
            this.txtBednerEncrypted.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBednerEncrypted.Size = new System.Drawing.Size(374, 144);
            this.txtBednerEncrypted.TabIndex = 10;
            this.txtBednerEncrypted.TextChanged += new System.EventHandler(this.txtBednerEncrypted_TextChanged);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label10);
            this.tabPage6.Controls.Add(this.txtBednerDecrypted);
            this.tabPage6.Location = new System.Drawing.Point(4, 24);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(490, 182);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "decrypt";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 15);
            this.label10.TabIndex = 12;
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBednerDecrypted
            // 
            this.txtBednerDecrypted.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBednerDecrypted.Location = new System.Drawing.Point(110, 3);
            this.txtBednerDecrypted.MaxLength = 0;
            this.txtBednerDecrypted.Multiline = true;
            this.txtBednerDecrypted.Name = "txtBednerDecrypted";
            this.txtBednerDecrypted.ReadOnly = true;
            this.txtBednerDecrypted.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBednerDecrypted.Size = new System.Drawing.Size(374, 174);
            this.txtBednerDecrypted.TabIndex = 11;
            this.txtBednerDecrypted.TextChanged += new System.EventHandler(this.txtBednerDecrypted_TextChanged);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(123, 162);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(357, 15);
            this.linkLabel2.TabIndex = 14;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "This is Bedner method - use private for encryption";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // RSA_ENCRYPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 592);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "RSA_ENCRYPT";
            this.Text = "RSA_ENCRYPT";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPanel2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPublic;
        private System.Windows.Forms.TextBox txtPrivate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtEncrypted;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabPanel2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtDecrypted;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBednerEncrypted;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBednerDecrypted;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}