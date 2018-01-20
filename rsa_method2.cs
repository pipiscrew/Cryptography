using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace asymmetric
{
    class rsa_method2
    {
        //src - https://stackoverflow.com/a/18872346
        /*
         * -Only works for small data. i have around 2000 character length string. getting bad length exception
         * 	
         * -The length of data that can be encrypted by RSA is limited by the size of the key and the padding used.
         * For PKCS#1 padding the maximum message length is the key size (in bytes) - 11 (e.g. a 2048 bit key = 256 bytes,
         * so the maximum message length is 256 - 11 = 245 bytes). For OAEP padding the limit is more complex as it depends
         * also in the size of the hash function used. For large data you can use a hybrid encryption scheme whereby RSA is
         * used only to encrypt a randomly-generated key which is used with a symmetric algorithm (e.g. AES) to encrypt the message itself
         * 
         * ref *
         * https://msdn.microsoft.com/en-us/library/system.security.cryptography.rsacryptoserviceprovider.persistkeyincsp(v=vs.110).aspx
         * https://msdn.microsoft.com/en-us/library/system.security.cryptography.rsacryptoserviceprovider.usemachinekeystore(v=vs.110).aspx
         * http://www.sis.pitt.edu/lersais/education/labs/cryptocs.php
         * http://www.mtelligent.com/home/2006/3/17/exam-70-553-encrypt-decrypt-and-hash-data-by-using-the-syste.html
         */

        public static void create_helper(){
            CreateKeyPair();
        }

        public static string RSA_Decrypt(string encryptedText, string privateKey)
        {
            CspParameters cspParams = new CspParameters { ProviderType = 1 };
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(cspParams);

            rsaProvider.ImportCspBlob(Convert.FromBase64String(privateKey));

            var buffer = Convert.FromBase64String(encryptedText);

            byte[] plainBytes = rsaProvider.Decrypt(buffer, false);

            string plainText = Encoding.UTF8.GetString(plainBytes, 0, plainBytes.Length);

            return plainText;
        }

        public static string RSA_Encrypt(string data, string publicKey)
        {
            CspParameters cspParams = new CspParameters { ProviderType = 1 };
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(cspParams);

            rsaProvider.ImportCspBlob(Convert.FromBase64String(publicKey));

            byte[] plainBytes = Encoding.UTF8.GetBytes(data);
            byte[] encryptedBytes = rsaProvider.Encrypt(plainBytes, false);

            return Convert.ToBase64String(encryptedBytes);
        }

        public static Tuple<string, string> CreateKeyPair()
        {
            CspParameters cspParams = new CspParameters { ProviderType = 1 /* PROV_RSA_FULL */ };

            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(2048, cspParams);

            string publicKey = Convert.ToBase64String(rsaProvider.ExportCspBlob(false));
            string privateKey = Convert.ToBase64String(rsaProvider.ExportCspBlob(true));

            return new Tuple<string, string>(privateKey, publicKey);
        }

    }
}
