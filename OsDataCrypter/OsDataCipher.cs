using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace OsDataCipher
{
    /// <summary>
    /// OsDataCipher provide basic and optimized functionality
    /// for encrypt and decrypt string using a custom-length pass-phrase
    /// 
    /// </summary>
    public class OsDataCipher : IOsDataCipher
    {
        private readonly byte[] key;
        private readonly byte[] iv;

        /// <summary>
        /// Create a <see cref="OsDataCipher"/> class instance
        /// </summary>
        /// <param name="password">A password to use for encrypt and decrypt operations</param>
        public OsDataCipher(string password)
        {
            //Convert password string to byte array
            byte[] passPhraseAsByteArray = Encoding.UTF8.GetBytes(password);
            // create a 32 bit hash of the byte array and using it for AES algorithm
            key = SHA256.Create().ComputeHash(passPhraseAsByteArray);
            // create a 16 bit hash to use for initialization vector
            iv = MD5.Create().ComputeHash(passPhraseAsByteArray);
        }

        /// <summary>
        /// Encrypt a string
        /// </summary>
        /// <param name="data">String to encrypt</param>
        /// <returns>Base64 encrypted string</returns>
        public string Encrypt(string data)
        {
            return Convert.ToBase64String(
                Encrypt(Encoding.UTF8.GetBytes(data)));
        }

        /// <summary>
        /// Decrypt a encrypted string
        /// </summary>
        /// <param name="data">Base64 string to decrypt</param>
        /// <returns>Decrypted string</returns>
        public string Decrypt(string data)
        {
            return Encoding.UTF8.GetString(
                   Decrypt(
                       Convert.FromBase64String(data)));
        }

        /// <summary>
        /// Try to decrypt a string
        /// </summary>
        /// <param name="encrypted">Base64 encrypted string to try for decrypt</param>
        /// <param name="decrypted">Decrypted strings</param>
        /// <returns>True for decrypt successful</returns>
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
