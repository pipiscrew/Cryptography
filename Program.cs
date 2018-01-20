using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace asymmetric
{
    static class Program
    {
        //AES - https://gist.github.com/yetanotherchris/810c5900616b6c76f78dedda9bf3be85
        //AES - http://www.c-sharpcorner.com/article/introduction-to-aes-and-des-encryption-algorithms-in-net/


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        //https://stackoverflow.com/a/4286491
        public const string LoremIpsum = @"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        public static string generate_dummy_text(int count)
        {
           return  String.Join(Environment.NewLine, Enumerable.Repeat(LoremIpsum, count));
        }

        //https://codereview.stackexchange.com/a/152567
        public static string GenerateRandomString(int size)
        {
            var b = new byte[size];
            new RNGCryptoServiceProvider().GetBytes(b);
            return Encoding.ASCII.GetString(b);
        }
    }
}
