using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OsDataCipher
{
    /// <summary>
    /// IOsDataCippher inteface
    /// </summary>
    public interface IOsDataCipher
    {
        /// <summary>
        /// Encrypt a string
        /// </summary>
        /// <param name="data">String to encrypt</param>
        /// <returns>Encrypted string</returns>
        string Encrypt(string data);

        /// <summary>
        /// Decrypt a crypted string
        /// </summary>
        /// <param name="data">String to decrypt</param>
        /// <returns>Decrypted string</returns>
        string Decrypt(string data);

        /// <summary>
        /// Try to decrypt a string
        /// </summary>
        /// <param name="encrypted">Encrypted string to try for decrypt</param>
        /// <param name="decrypted">Decrypted strings</param>
        /// <returns>True for decrypt successfull</returns>
        bool TryDecrypt(string encrypted, out string decrypted);
    }
}
