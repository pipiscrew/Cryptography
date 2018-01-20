using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace asymmetric
{
    /*
     * src -
     * http://msdn.microsoft.com/en-us/library/yyysx3fh%28v=vs.100%29.aspx?cs-save-lang=1&cs-lang=csharp
     * 
     * DSA Generates different signatures with the same data (Generate a random per-message k)
     * https://security.stackexchange.com/questions/46939/dsa-generates-different-signatures-with-the-same-data
     * 
     * ref *
     * https://msdn.microsoft.com/en-us/library/system.security.cryptography.dsacryptoserviceprovider(v=vs.110).aspx
     * https://msdn.microsoft.com/en-us/library/system.security.cryptography.dsasignaturedeformatter(v=vs.110).aspx
     * https://msdn.microsoft.com/en-us/library/system.security.cryptography.cspparameters(v=vs.110).aspx
     * https://www.codeproject.com/Articles/38804/Encryption-and-Decryption-on-the-NET-Framework
     * 
     * https://stackoverflow.com/a/1200194 ::
        -Sender calculates a hash from the data before sending
        -Sender encrypts that hash with senders private key
        -Receiver calculates hash from the received data
        -Receiver decrypts senders signature with senders public key
        -Receiver compares the locally calculated hash and the decrypted signature
     * 
     * https://www.quora.com/What-is-the-difference-between-RSA-and-DSA
     * https://books.google.com/books?id=qi4Tonh8_b0C&lpg=PA186&ots=Z6IEa0Je0y&dq=DSACryptoServiceProvider%20encrypt%20byte%20with%20sign&pg=PA254#v=onepage&q=DSACryptoServiceProvider%20encrypt%20byte%20with%20sign&f=false
     * 
     * I have to check *
     * https://github.com/CodesInChaos/ChaosUtil
     * https://csharphardcoreprogramming.wordpress.com/tag/usemachinekeystore/ (UseMachineKey)
    */
    internal static class dsa_hash
    {
        //private static DSAParameters private_key_dsa {get;set;}
        //private static DSAParameters public_key_dsa { get; set; }
        private static byte[] private_CspBlob { get; set; }
        private static byte[] public_CspBlob { get; set; }

        public static string private_key { get; set; }
        public static string public_key { get; set; }

        //DSASignatureFormatter over DSACryptoServiceProvider needed? - https://stackoverflow.com/questions/262756/what-is-the-benefit-of-using-dsasignatureformatter-over-dsacryptoserviceprovider

        internal static void create_keypair()
        {
            using (DSACryptoServiceProvider DSA = new DSACryptoServiceProvider(1024, new CspParameters { ProviderType = 13 }))
            {
                // keys representing in 3 flavors string - DSAParameters - byte[]

                //store it as DSAParameters
                //private_key_dsa = DSA.ExportParameters(true);
                //public_key_dsa = DSA.ExportParameters(false);

                //we will use CspBlob because is byte[]
                private_CspBlob = DSA.ExportCspBlob(true);
                public_CspBlob = DSA.ExportCspBlob(false);

                //store as string
                private_key = DSA.ToXmlString(true);
                public_key = DSA.ToXmlString(false);

                // keys representing in 3 flavors string - DSAParameters - byte[]
            }
        }



        internal static string[] sign(string data_to_sign)
        {
            // Convert to byte[]
            byte[] HashValue = Encoding.UTF8.GetBytes(data_to_sign);


            // Computes the hash value for the specified byte array. 
            // *REQ* otherwise you got - *CryptographicException: SHA1 algorithm hash size is 20 bytes* exception
            byte[] rgbHash;
            using (SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider())
            {
                rgbHash = sHA1CryptoServiceProvider.ComputeHash(HashValue);
            }


            // The value to hold the signed value.
            byte[] SignedHashValue = DSASignHash(rgbHash, "SHA1");

            // Verify the hash
            bool verified = DSAVerifyHash(rgbHash, SignedHashValue, "SHA1");

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
        internal static byte[] DSASignHash(byte[] HashToSign, string HashAlg)
        {
            byte[] sig = null;

            try
            {
                // Create a new instance of DSACryptoServiceProvider.
                using (DSACryptoServiceProvider DSA = new DSACryptoServiceProvider())
                {
                    // Import the key information.
                    //DSA.ImportParameters(private_key_dsa);
                    //or
                    DSA.ImportCspBlob(private_CspBlob);

                    // Create an DSASignatureFormatter object and pass it the
                    // DSACryptoServiceProvider to transfer the private key.
                    DSASignatureFormatter DSAFormatter = new DSASignatureFormatter(DSA);

                    // Set the hash algorithm to the passed value.
                    DSAFormatter.SetHashAlgorithm(HashAlg);

                    // Create a signature for HashValue and return it.
                    sig = DSAFormatter.CreateSignature(HashToSign);
                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
            }

            return sig;
        }

        //read with public key
        internal static bool DSAVerifyHash(byte[] HashValue, byte[] SignedHashValue, string HashAlg)
        {
            bool verified = false;

            try
            {
                // Create a new instance of DSACryptoServiceProvider.
                using (DSACryptoServiceProvider DSA = new DSACryptoServiceProvider())
                {
                    // Import the key information.
                    //DSA.ImportParameters(DSAKeyInfo);
                     DSA.ImportCspBlob(public_CspBlob);

                    // Create an DSASignatureDeformatter object and pass it the
                    // DSACryptoServiceProvider to transfer the private key.
                    DSASignatureDeformatter DSADeformatter = new DSASignatureDeformatter(DSA);

                    // Set the hash algorithm to the passed value.
                    DSADeformatter.SetHashAlgorithm(HashAlg);

                    // Verify signature and return the result.
                    verified = DSADeformatter.VerifySignature(HashValue, SignedHashValue);
                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
            }

            return verified;
        }


    }
}
