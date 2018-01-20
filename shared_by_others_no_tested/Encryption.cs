using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


public class Encryption
{

    public static void CreateKeys(out string publicKey, out string privateKey)
    {
        using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider(2048))
        {
            publicKey = provider.ToXmlString(false);
            privateKey = provider.ToXmlString(true);
        }
    }

    public static string CreateSignatureSHA1(string privateKeyText, string strSource)
    {
        using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider())
        {
            provider.FromXmlString(privateKeyText);
            byte[] bytes = Encoding.UTF8.GetBytes(strSource);
            return Convert.ToBase64String(provider.SignData(bytes, new SHA1CryptoServiceProvider()));
        }
    }

    public static string CreateSignatureSHA256(string privateKeyText, string strSource)
    {
        using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider())
        {
            provider.FromXmlString(privateKeyText);
            byte[] bytes = Encoding.UTF8.GetBytes(strSource);
            return Convert.ToBase64String(provider.SignData(bytes, new SHA256CryptoServiceProvider()));
        }
    }

    public static void DecryptFile(string privateKeyText, string encryptedFileName, string plainFileName)
    {
        FileStream stream = null;
        StreamWriter writer = null;
        string str = string.Empty;
        byte[] buffer = null;
        byte[] bytes = null;
        try
        {
            RSACryptoServiceProvider provider1 = new RSACryptoServiceProvider(512);
            provider1.FromXmlString(privateKeyText);
            stream = File.OpenRead(encryptedFileName);
            buffer = new byte[stream.Length];
            stream.Read(buffer, 0, (int)stream.Length);
            bytes = provider1.Decrypt(buffer, false);
            writer = File.CreateText(plainFileName);
            str = Encoding.UTF8.GetString(bytes);
            writer.Write(str);
        }
        finally
        {
            if (stream != null)
            {
                stream.Close();
            }
            if (writer != null)
            {
                writer.Close();
            }
        }
    }

    public static void EncryptFile(string publicKeyText, string plainFileName, string encryptedFileName)
    {
        StreamReader reader = null;
        FileStream stream = null;
        string s = string.Empty;
        byte[] buffer = null;
        try
        {
            RSACryptoServiceProvider provider1 = new RSACryptoServiceProvider(512);
            provider1.FromXmlString(publicKeyText);
            reader = File.OpenText(plainFileName);
            s = reader.ReadToEnd();
            buffer = provider1.Encrypt(Encoding.UTF8.GetBytes(s), false);
            stream = File.Create(encryptedFileName);
            stream.Write(buffer, 0, buffer.Length);
        }
        finally
        {
            if (reader != null)
            {
                reader.Close();
            }
            if (stream != null)
            {
                stream.Close();
            }
        }
    }

    public static bool VerifySignatureSHA1(string publicKeyText, string strSignature, string strSource)
    {
        using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider())
        {
            provider.FromXmlString(publicKeyText);
            byte[] bytes = Encoding.UTF8.GetBytes(strSource);
            byte[] signature = Convert.FromBase64String(strSignature);
            return provider.VerifyData(bytes, new SHA1CryptoServiceProvider(), signature);
        }
    }

    public static bool VerifySignatureSHA256(string publicKeyText, string strSignature, string strSource)
    {
        using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider())
        {
            provider.FromXmlString(publicKeyText);
            byte[] bytes = Encoding.UTF8.GetBytes(strSource);
            byte[] signature = Convert.FromBase64String(strSignature);
            return provider.VerifyData(bytes, new SHA256CryptoServiceProvider(), signature);
        }
    }
}


