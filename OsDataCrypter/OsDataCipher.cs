using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OsDataCipher
{
    public class OsDataCipher : IOsDataCipher
    {
        private byte[] key;
        private byte[] iv = new byte[] {
            32, 182, 48, 165, 169, 9, 156, 188,
            74, 177, 236, 211, 100, 41, 81, 7
        };

        public OsDataCipher(string password)
        {
            byte[] passPhraseAsByteArray = Encoding.UTF8.GetBytes(password);
            key = SHA256.Create().ComputeHash(passPhraseAsByteArray);
        }
        public string Decrypt(string data)
        {
            return Encoding.UTF8.GetString(
                   Decrypt(
                       Convert.FromBase64String(data)));
        }

        public string Encrypt(string data)
        {
            return Convert.ToBase64String(
                Encrypt(Encoding.UTF8.GetBytes(data)));
        }

        public bool TryDecrypt(string encrypted, out string decrypted)
        {
            try
            {
                decrypted = Decrypt(encrypted);
                return true;
            }
            catch (Exception)
            {
                decrypted = "";
                return false;
            }
        }

        private byte[] Encrypt(byte[] data)
        {
            using Aes algorithm = Aes.Create();
            using ICryptoTransform encryptor = algorithm.CreateEncryptor(key, iv);
            return Crypt(data, encryptor);
        }
        private byte[] Decrypt(byte[] data)
        {
            using Aes algorithm = Aes.Create();
            using ICryptoTransform decryptor = algorithm.CreateDecryptor(key, iv);
            return Crypt(data, decryptor);
        }
        private byte[] Crypt(byte[] data, ICryptoTransform cryptor)
        {
            MemoryStream m = new MemoryStream();
            using var c = new CryptoStream(m, cryptor, CryptoStreamMode.Write);
            c.Write(data, 0, data.Length);
            c.FlushFinalBlock();
            return m.ToArray();
        }

    }
}
