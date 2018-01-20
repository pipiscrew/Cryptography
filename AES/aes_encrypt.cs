using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace asymmetric.AES
{
    internal static class aes_encrypt
    {
        /*
         * src AES                  - https://gist.github.com/yetanotherchris/810c5900616b6c76f78dedda9bf3be85
         * src Rijndael             - http://www.c-sharpcorner.com/article/introduction-to-aes-and-des-encryption-algorithms-in-net/
         * src Rfc2898DeriveBytes   - https://stackoverflow.com/a/6531179
        
         * done use PasswordDeriveBytes is unsecure.
         * Microsoft's implementation of original PKCS#5 (aka PBKDF1) include insecure extensions to provide more bytes than the hash function can provide 
         *              https://bugzilla.novell.com/show_bug.cgi?id=316364 + https://bugzilla.novell.com/show_bug.cgi?id=372893
         *              
         * 
         * https://stackoverflow.com/a/9233562
         * Strongly suggest to use the newer Rfc2898DeriveBytes which implements PBKDF2 (PKCS#5 v2) which is available since .NET 2.0.
         
         *      ref - https://msdn.microsoft.com/en-us/library/system.security.cryptography.rfc2898derivebytes.aspx
         *      ref - https://msdn.microsoft.com/en-us/library/system.security.cryptography.passwordderivebytes.aspx
         *
         * 
         * https://stackoverflow.com/a/21151751 - // **To make it harder to brute force passwords it uses the iteration count**
         * Rfc2898DeriveBytes iterations - Uses a salt and key stretching to create a relatively safe key from a password.. To make it harder to brute force passwords it uses the iteration count
         */

        internal static byte[] key = { }; //Encryption Key   
        //internal static byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 10, 20, 30, 40, 50, 60 };

        /* https://stackoverflow.com/a/20530777
         * Salts, in the context of password hashing (and key derivation), are used to prevent precomputation attacks like rainbow tables.
         * Note that the salt must be different and unpredictable (preferably random) for every password. Also note that salts need not be secret – that's what the password is for. You gain no security by keeping the salt secret.
        */
        static byte[] salt = new byte[10] { 1, 2, 23, 234, 37, 48, 134, 63, 248, 4 };

        #region << AES >>

        internal static string EncryptDataAES(string strData, string strKey)
        {
            byte[] inputByteArray;

            try
            {
                key = Encoding.UTF8.GetBytes(strKey);
                inputByteArray = Encoding.UTF8.GetBytes(strData);

                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                //you can use :
                //aes.GenerateKey();
                //aes.GenerateIV();

                /* THE DEFAULT - when no setted is: */
                ////set the mode for operation of the algorithm   
                //aes.Mode = CipherMode.CBC;
                ////set the padding mode used in the algorithm.   
                //aes.Padding = PaddingMode.PKCS7;
                ////set the size, in bits, for the secret key.   
                //aes.KeySize = 128;
                ////set the block size in bits for the cryptographic operation.    
                //aes.BlockSize = 128;

                Rfc2898DeriveBytes k1 = new Rfc2898DeriveBytes(key, salt, 1000);
                aes.Key = k1.GetBytes(32);   // 16 for 128bit \/\/\/ 32 for 256bit
                aes.IV = k1.GetBytes(16);    //[aes.BlockSize / 8] - either 128 or 256, is 16. Because rj.BlockSize is always 128 -- https://stackoverflow.com/a/36826559

                /* PLAIN AWAY */
                //aes.Key = key;
                //aes.IV = IV;

                var cryptor = aes.CreateEncryptor();
                byte[] encryptedBytes = cryptor.TransformFinalBlock(inputByteArray, 0, inputByteArray.Length);

                return Convert.ToBase64String(encryptedBytes);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        internal static string DecryptDataAES(string strData, string strKey)
        {
            byte[] inputByteArray = new byte[strData.Length];

            try
            {
                key = Encoding.UTF8.GetBytes(strKey);
                inputByteArray = Convert.FromBase64String(strData);

                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();

                /* THE DEFAULT - when no setted is: */
                ////set the mode for operation of the algorithm   
                //aes.Mode = CipherMode.CBC;
                ////set the padding mode used in the algorithm.   
                //aes.Padding = PaddingMode.PKCS7;
                ////set the size, in bits, for the secret key.   
                //aes.KeySize = 128;
                ////set the block size in bits for the cryptographic operation.    
                //aes.BlockSize = 128;

                Rfc2898DeriveBytes k1 = new Rfc2898DeriveBytes(key, salt, 1000);
                aes.Key = k1.GetBytes(32);   // 16 for 128bit \/\/\/ 32 for 256bit
                aes.IV = k1.GetBytes(16);    //[aes.BlockSize / 8] - either 128 or 256, is 16. Because rj.BlockSize is always 128 -- https://stackoverflow.com/a/36826559

                /* PLAIN AWAY */
                //aes.Key = key;
                //aes.IV = IV;

                var decryptor = aes.CreateDecryptor();
                byte[] decryptedBytes = decryptor.TransformFinalBlock(inputByteArray, 0, inputByteArray.Length);

                return Encoding.UTF8.GetString(decryptedBytes);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #region  " MS CryptoStream Examples "
        
        // using the following Microsoft example - tested & produce the same results
        // Microsoft style - https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.aesmanaged?view=netframework-4.7
        // Under the hood CryptoStream uses TransformBlock/TransformFinalBlock, so the this way is derivative from the EncryptDataAES function method.  -- http://vadmyst.blogspot.com/2008/06/hashing-in-net-cryptography-related.html


        internal static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an AesManaged object
            // with the specified key and IV.
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        internal static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AesManaged object
            // with the specified key and IV.
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }

        #endregion

        #endregion





        #region << Rijndael >>


        internal static string EncryptDataRijndael(string strData, string strKey)
        {
            byte[] inputByteArray;

            try
            {
                key = Encoding.UTF8.GetBytes(strKey);
                inputByteArray = Encoding.UTF8.GetBytes(strData);

                RijndaelManaged rj = new RijndaelManaged();
                //you can use :
                //rj.GenerateKey();
                //rj.GenerateIV();

                /* THE DEFAULT - when no setted is: */
                ////set the mode for operation of the algorithm   
                //rj.Mode = CipherMode.CBC;
                ////set the padding mode used in the algorithm.   
                //rj.Padding = PaddingMode.PKCS7;
                ////set the size, in bits, for the secret key.   
                //rj.KeySize = 128;
                ////set the block size in bits for the cryptographic operation.    
                //rj.BlockSize = 128;

                //To make it harder to brute force passwords it uses the iteration count
                Rfc2898DeriveBytes k1 = new Rfc2898DeriveBytes(key, salt, 1000);
                rj.Key = k1.GetBytes(32);   // 16 for 128bit \/\/\/ 32 for 256bit
                rj.IV = k1.GetBytes(16);    //[rj.BlockSize / 8] - either 128 or 256, is 16. Because rj.BlockSize is always 128 -- https://stackoverflow.com/a/36826559

                /* PLAIN AWAY */
                //rj.Key = key;
                //rj.IV = IV;

                ICryptoTransform objtransform = rj.CreateEncryptor();
                byte[] decryptedBytes = objtransform.TransformFinalBlock(inputByteArray, 0, inputByteArray.Length);

                return Convert.ToBase64String(decryptedBytes);



                //var cryptor = aes.CreateEncryptor();
                //byte[] encryptedBytes = cryptor.TransformFinalBlock(inputByteArray, 0, inputByteArray.Length);

                //return Convert.ToBase64String(encryptedBytes);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        internal static string DecryptDataRijndael(string strData, string strKey)
        {
            byte[] inputByteArray;

            try
            {
                key = Encoding.UTF8.GetBytes(strKey);
                inputByteArray = Convert.FromBase64String(strData);

                RijndaelManaged rj = new RijndaelManaged();
                //you can use :
                //rj.GenerateKey();
                //rj.GenerateIV();


                /* THE DEFAULT - when no setted is: */
                ////set the mode for operation of the algorithm   
                //rj.Mode = CipherMode.CBC;
                ////set the padding mode used in the algorithm.   
                //rj.Padding = PaddingMode.PKCS7;
                ////set the size, in bits, for the secret key.   
                //rj.KeySize = 128;
                ////set the block size in bits for the cryptographic operation.    
                //rj.BlockSize = 128;

                //To make it harder to brute force passwords it uses the iteration count
                Rfc2898DeriveBytes k1 = new Rfc2898DeriveBytes(key, salt, 1000);
                rj.Key = k1.GetBytes(32);   // 16 for 128bit \/\/\/ 32 for 256bit
                rj.IV = k1.GetBytes(16);    //[rj.BlockSize / 8] - either 128 or 256, is 16. Because rj.BlockSize is always 128 -- https://stackoverflow.com/a/36826559

                /* PLAIN AWAY */
                //rj.Key = key;
                //rj.IV = IV;

                byte[] TextByte = rj.CreateDecryptor().TransformFinalBlock(inputByteArray, 0, inputByteArray.Length);
                return Encoding.UTF8.GetString(TextByte);



                //var cryptor = aes.CreateEncryptor();
                //byte[] encryptedBytes = cryptor.TransformFinalBlock(inputByteArray, 0, inputByteArray.Length);

                //return Convert.ToBase64String(encryptedBytes);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        #region " MS CryptoStream Examples "

        // using the following Microsoft example - tested & produce the same results
        // Microsoft style - https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.aesmanaged?view=netframework-4.7
        // Under the hood CryptoStream uses TransformBlock/TransformFinalBlock, so the this way is derivative from the EncryptDataAES function method.  -- http://vadmyst.blogspot.com/2008/06/hashing-in-net-cryptography-related.html


        internal static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        internal static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }
    

     #endregion

        #endregion

    }
}
