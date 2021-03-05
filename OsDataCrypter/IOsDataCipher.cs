using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OsDataCipher
{
    public interface IOsDataCipher
    {
        string Encrypt(string data);
        string Decrypt(string data);
        bool TryDecrypt(string encrypted, out string decrypted);
    }
}
