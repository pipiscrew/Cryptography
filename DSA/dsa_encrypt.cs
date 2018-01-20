using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace asymmetric
{
    internal static class dsa_encrypt
    {
        internal static byte[] key = { }; //Encryption Key   
        internal static byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };

        #region << DES >>

        internal static string EncryptDataDES(string strData, string strKey)
        {
            byte[] inputByteArray;

            try
            {
                key = Encoding.UTF8.GetBytes(strKey);

                DESCryptoServiceProvider ObjDES = new DESCryptoServiceProvider();
                //you can use :
                //ObjDES.GenerateKey();
                //ObjDES.GenerateIV();

                inputByteArray = Encoding.UTF8.GetBytes(strData);
                MemoryStream Objmst = new MemoryStream();
                CryptoStream Objcs = new CryptoStream(Objmst, ObjDES.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                Objcs.Write(inputByteArray, 0, inputByteArray.Length);
                Objcs.FlushFinalBlock();

                return Convert.ToBase64String(Objmst.ToArray());//encrypted string  
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        internal static string DecryptDataDES(string strData, string strKey)
        {
            byte[] inputByteArray = new byte[strData.Length];

            try
            {
                key = Encoding.UTF8.GetBytes(strKey);
                DESCryptoServiceProvider ObjDES = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(strData);

                MemoryStream Objmst = new MemoryStream();
                CryptoStream Objcs = new CryptoStream(Objmst, ObjDES.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                Objcs.Write(inputByteArray, 0, inputByteArray.Length);
                Objcs.FlushFinalBlock();

                Encoding encoding = Encoding.UTF8;
                return encoding.GetString(Objmst.ToArray());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #endregion



        #region << 3DES >>

        // http://www.codeproject.com/Articles/14150/Encrypt-and-Decrypt-Data-with-C
        // https://stackoverflow.com/a/11413660
        
        internal static string EncryptData3DES(string strData, string strKey)
        {
            try
            {
                key = Encoding.UTF8.GetBytes(strKey);
                byte[] toEncryptArray = Encoding.UTF8.GetBytes(strData);

                TripleDESCryptoServiceProvider ObjDES = new TripleDESCryptoServiceProvider();
                //you can use :
                //ObjDES.GenerateKey();
                //ObjDES.GenerateIV();

                //mode of operation. there are other 4 modes. We choose ECB(Electronic code Book)
                ObjDES.Mode = CipherMode.ECB;
                //padding mode(if any extra byte added)
                ObjDES.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = ObjDES.CreateEncryptor(key, IV);

                //transform the specified region of bytes array to resultArray
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);


                //Release resources held by TripleDes Encryptor
                ObjDES.Clear();

                //Return the encrypted data into unreadable string format
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        internal static string DecryptData3DES(string strData, string strKey)
        {
            try
            {
                byte[] toEncryptArray = Convert.FromBase64String(strData);
                key = Encoding.UTF8.GetBytes(strKey);

                TripleDESCryptoServiceProvider ObjDES = new TripleDESCryptoServiceProvider();

                //mode of operation. there are other 4 modes. We choose ECB(Electronic code Book)
                ObjDES.Mode = CipherMode.ECB;
                //padding mode(if any extra byte added)
                ObjDES.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = ObjDES.CreateDecryptor(key, IV);
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                //Release resources held by TripleDes Encryptor                
                ObjDES.Clear();

                //return the Clear decrypted TEXT
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
