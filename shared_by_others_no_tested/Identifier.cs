using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


public class Identifier
{

    public static string CreateInterleaveHash(string strUserName, string strPassword, bool bBase64)
    {
        string str = strUserName.ToLower();
        int num = Math.Max(str.Length, strPassword.Length);
        char[] chArray = new char[num * 2];
        for (int i = 0; i < num; i++)
        {
            chArray[i * 2] = (i < str.Length) ? str[i] : '#';
            chArray[(i * 2) + 1] = (i < strPassword.Length) ? strPassword[i] : '#';
        }
        return CreateMD5Hash(new string(chArray), bBase64);
    }

    public static string CreateMD5Hash(string strToHash, bool bBase64)
    {
        byte[] inArray = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(strToHash));
        if (bBase64)
        {
            return Convert.ToBase64String(inArray);
        }
        return ToHexString(inArray);
    }

    public static string CreateUniquieID(bool bBase64)
    {
        Guid guid = Guid.NewGuid();
        if (bBase64)
        {
            return Convert.ToBase64String(guid.ToByteArray());
        }
        return ToHexString(guid.ToByteArray());
    }

    public static string DecryptString(string Message, string Passphrase)
    {
        byte[] buffer;
        UTF8Encoding encoding = new UTF8Encoding();
        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        byte[] buffer2 = provider.ComputeHash(encoding.GetBytes(Passphrase));
        TripleDESCryptoServiceProvider provider2 = new TripleDESCryptoServiceProvider
        {
            Key = buffer2,
            Mode = CipherMode.ECB,
            Padding = PaddingMode.PKCS7
        };
        byte[] inputBuffer = Convert.FromBase64String(Message);
        try
        {
            buffer = provider2.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
        }
        finally
        {
            provider2.Clear();
            provider.Clear();
        }
        return encoding.GetString(buffer);
    }

    public static string DecryptText(string strKey, string strDecrypt)
    {
        if (!string.IsNullOrEmpty(strKey) && !string.IsNullOrEmpty(strDecrypt))
        {
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider provider1 = new MD5CryptoServiceProvider();
            byte[] rgbKey = provider1.ComputeHash(Encoding.ASCII.GetBytes("-1x@" + strKey + "'p9#"));
            byte[] rgbIV = provider1.ComputeHash(Encoding.ASCII.GetBytes(strKey));
            byte[] inputBuffer = Convert.FromBase64String(strDecrypt);
            try
            {
                byte[] bytes = provider.CreateDecryptor(rgbKey, rgbIV).TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                return Encoding.ASCII.GetString(bytes);
            }
            catch (Exception)
            {
            }
        }
        return string.Empty;
    }

    public static string EncryptString(string Message, string Passphrase)
    {
        byte[] buffer;
        UTF8Encoding encoding = new UTF8Encoding();
        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        byte[] buffer2 = provider.ComputeHash(encoding.GetBytes(Passphrase));
        TripleDESCryptoServiceProvider provider2 = new TripleDESCryptoServiceProvider
        {
            Key = buffer2,
            Mode = CipherMode.ECB,
            Padding = PaddingMode.PKCS7
        };
        byte[] bytes = encoding.GetBytes(Message);
        try
        {
            buffer = provider2.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
        }
        finally
        {
            provider2.Clear();
            provider.Clear();
        }
        return Convert.ToBase64String(buffer);
    }

    public static string EncryptText(string strKey, string strEncrypt)
    {
        TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider provider1 = new MD5CryptoServiceProvider();
        byte[] rgbKey = provider1.ComputeHash(Encoding.ASCII.GetBytes("-1x@" + strKey + "'p9#"));
        byte[] rgbIV = provider1.ComputeHash(Encoding.ASCII.GetBytes(strKey));
        byte[] bytes = Encoding.ASCII.GetBytes(strEncrypt);
        try
        {
            return Convert.ToBase64String(provider.CreateEncryptor(rgbKey, rgbIV).TransformFinalBlock(bytes, 0, bytes.Length));
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    public static string ToHexString(byte[] abConvert)
    {
        StringBuilder builder = new StringBuilder(abConvert.Length * 2);
        for (int i = 0; i < abConvert.Length; i++)
        {
            builder.Append(abConvert[i].ToString("x2"));
        }
        return builder.ToString();
    }



}



