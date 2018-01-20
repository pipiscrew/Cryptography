using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace asymmetric
{
    internal static class rsa_method
    {
        /*
         * The typical way you would store the encoded message is in a base64 string - https://stackoverflow.com/a/43354722
         * https://stackoverflow.com/questions/8437288/signing-and-verifying-signatures-with-rsa-c-sharp
         * https://stackoverflow.com/questions/43354520/c-sharp-signing-and-verifying-signatures-with-rsa-encoding-issue
         * https://stackoverflow.com/questions/8437288/signing-and-verifying-signatures-with-rsa-c-sharp
         * 
         * 
         * The comp.security.pgp FAQ - http://www.pgp.net/pgpnet/pgp-faq/pgp-faq-security-questions.html#security-against-nsa
         * https://csharphardcoreprogramming.wordpress.com/tag/usemachinekeystore/
        */

        //private static RSAParameters private_key_rsa { get; set; }
        //private static RSAParameters public_key_rsa { get; set; }
        private static byte[] private_CspBlob { get; set; }
        private static byte[] public_CspBlob { get; set; }

        public static string private_key { get; set; }
        public static string public_key { get; set; }

        internal static void create_keypair()
        {
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(1024, new CspParameters { ProviderType = 1 }))
            {
                // keys representing in 3 flavors string - DSAParameters - byte[]

                //store it as RSAParameters
                //private_key_rsa = RSA.ExportParameters(true);
                //public_key_rsa = RSA.ExportParameters(false);
                //byte[] lP = private_key_rsa.P;
                //byte[] lQ = private_key_rsa.Q;
                //byte[] lModulus = private_key_rsa.Modulus;
                //byte[] lExponent = private_key_rsa.Exponent;


                //we will use CspBlob because is byte[]
                private_CspBlob = RSA.ExportCspBlob(true);
                public_CspBlob = RSA.ExportCspBlob(false);

                //store as string
                private_key = RSA.ToXmlString(true);
                public_key = RSA.ToXmlString(false);

                // keys representing in 3 flavors string - DSAParameters - byte[]
            }
        }


        #region    << ENCRYPTION >>

        /*  src - https://stackoverflow.com/questions/21702662/system-security-cryptography-cryptographicexception-bad-length-in-rsacryptoser
         *  src - https://en.wikipedia.org/wiki/Hybrid_cryptosystem

            To encrypt a message addressed to Alice in a hybrid cryptosystem, Bob does the following:

            Obtains Alice's public key.
            Generates a fresh symmetric key for the data encapsulation scheme.
            Encrypts the message under the data encapsulation scheme, using the symmetric key just generated.
            Encrypt the symmetric key under the key encapsulation scheme, using Alice's public key.
            Send both of these encryptions to Alice.
         
            To decrypt this hybrid ciphertext, Alice does the following:

            Uses her private key to decrypt the symmetric key contained in the key encapsulation segment.
            Uses this symmetric key to decrypt the message contained in the data encapsulation segment.
         * 
            RSA is a public-key encryption algorithm (asymmetric), while AES is a symmetric key algorithm. The two
            algorithms work very differently, and often a cryptosystem will use both algorithms. For example, a cryptosystem
            may use RSA to exchange keys securely, while use AES to encrypt the actual messages.
        */

        internal static string RSA_Encrypt(string data)
        {
            CspParameters cspParams = new CspParameters { ProviderType = 1 };
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(cspParams);

            rsaProvider.ImportCspBlob(public_CspBlob);

            byte[] plainBytes = Encoding.UTF8.GetBytes(data);

            //the limit is this
            if (plainBytes.Length > 117)
            {
                return null;
            }
            //the lmit is this

            byte[] encryptedBytes = rsaProvider.Encrypt(plainBytes, false);

            return Convert.ToBase64String(encryptedBytes);
        }

        //DECRYPT uses PRIVATE - you need the private key and that is why you get the "Key does not exist" exception. https://social.msdn.microsoft.com/Forums/vstudio/en-US/5805315d-299b-4699-ac70-32db33a5fda1/rsacryptoserviceprovider-key-does-not-exist-error
        //Remember: when Alice needs to send a message to Bob, she uses Bob's public key for the encryption and Bob will then use his own private key to decrypt.
        internal static string RSA_Decrypt(string encryptedText)
        {
            CspParameters cspParams = new CspParameters { ProviderType = 1 };
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(cspParams);

            rsaProvider.ImportCspBlob(private_CspBlob);

            var buffer = Convert.FromBase64String(encryptedText);

            byte[] plainBytes = rsaProvider.Decrypt(buffer, false);

            string plainText = Encoding.UTF8.GetString(plainBytes, 0, plainBytes.Length);

            return plainText;
        }


        #endregion


        #region    << HASH >>

        internal static string[] sign(string data)
        {
            // Convert to byte[]
            byte[] data_to_sign = Encoding.UTF8.GetBytes(data);

            // The value to hold the signed value.
            byte[] SignedHashValue = RSASignHash(data_to_sign, "SHA1");

            // Verify the hash
            bool verified = RSAVerifyHash(data_to_sign, SignedHashValue, "SHA1");

            if (verified)
            {
                return new string[] { Convert.ToBase64String(SignedHashValue), "The hash value was verified." };
            }
            else
            {
                return new string[] { Convert.ToBase64String(SignedHashValue), "Value was NOT verified." };
            }
        }

        //sign with private key
        internal static byte[] RSASignHash(byte[] HashToSign, string HashAlg)
        {
            byte[] sig = null;

            try
            {
                // Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    // Import the key information.
                    //RSA.ImportParameters(private_key_rsa);
                    //or
                    RSA.ImportCspBlob(private_CspBlob);

                    sig = RSA.SignData(HashToSign, CryptoConfig.MapNameToOID(HashAlg));
                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
            }

            return sig;
        }

        //read with public key
        internal static bool RSAVerifyHash(byte[] HashValue, byte[] SignedHashValue, string HashAlg)
        {
            bool verified = false;

            try
            {
                // Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    // Import the key information.
                    //RSA.ImportParameters(DSAKeyInfo);
                    RSA.ImportCspBlob(public_CspBlob);

                    verified = RSA.VerifyData(HashValue, CryptoConfig.MapNameToOID(HashAlg), SignedHashValue);
                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
            }

            return verified;
        }

        //:: the following working ::
        //private void the_tiny_sign_example(){
        //    //src - https://social.msdn.microsoft.com/Forums/vstudio/en-US/9c12c57b-3414-4a6e-a3a4-c798abb79bba/
        //    string str = File.ReadAllText(@"C:\devtools\del.cmd");
        //    //string str = "Hello World";
        //    byte[] messagebytes = Encoding.UTF8.GetBytes(str);

        //    RSACryptoServiceProvider oRSA4ToKey = new RSACryptoServiceProvider();
        //    string privtekey = oRSA4ToKey.ToXmlString(true);
        //    string publickey = oRSA4ToKey.ToXmlString(false);

        //    //sign
        //    RSACryptoServiceProvider oRSA4 = new RSACryptoServiceProvider();
        //    oRSA4.FromXmlString(privtekey);
        //    byte[] encryptedData = oRSA4.SignData(messagebytes, new SHA1CryptoServiceProvider());
        //    Console.WriteLine("SIGN--", Convert.ToBase64String(encryptedData));

        //    //verify
        //    RSACryptoServiceProvider oRSA4Verify = new RSACryptoServiceProvider();
        //    oRSA4Verify.FromXmlString(publickey);
        //    bool bVerify = oRSA4Verify.VerifyData(messagebytes, new SHA1CryptoServiceProvider(), encryptedData);
        //    Console.Write(bVerify);
        //}

    }

#endregion 

}
