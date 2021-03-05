using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using OsDataCipher;

namespace OsDataCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Method1();
            Console.WriteLine("----------------------------------------------------------------");
            Method2();
            Console.ReadKey();
        }

        private static void Method2()
        {
            Stopwatch stopwatch = new Stopwatch();
            var cipher = new OsDataCipher("stRhong%pword");

            {
                stopwatch.Start();
                var encrypted = cipher.Encrypt("ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234");
                stopwatch.Stop();
                Console.WriteLine($"Encrypt 1: {stopwatch.ElapsedMilliseconds}ms");
                stopwatch.Restart();
                var decrypted = cipher.Decrypt(encrypted);
                stopwatch.Stop();
                Console.WriteLine($"Decrypt 1: {stopwatch.ElapsedMilliseconds}ms");
            }

            {
                stopwatch.Start();
                var encrypted = cipher.Encrypt("ABCD1234");
                stopwatch.Stop();
                Console.WriteLine($"Encrypt 1: {stopwatch.ElapsedMilliseconds}ms");
                stopwatch.Restart();
                var decrypted = cipher.Decrypt(encrypted);
                stopwatch.Stop();
                Console.WriteLine($"Decrypt 1: {stopwatch.ElapsedMilliseconds}ms");
            }


            {
                stopwatch.Restart();
                var encrypted1 = cipher.Encrypt("ABCD1234");
                var decrypted1 = cipher.Decrypt(encrypted1);
                stopwatch.Stop();
                Console.WriteLine($"Encript & Decrypt 1: {stopwatch.ElapsedMilliseconds}ms");
            }

            {
                stopwatch.Restart();
                var encrypted1 = cipher.Encrypt("ABCD1234");
                var decrypted1 = cipher.Decrypt(encrypted1);
                stopwatch.Stop();
                Console.WriteLine($"Encript & Decrypt 1: {stopwatch.ElapsedMilliseconds}ms");
            }

            {
                stopwatch.Restart();
                string e, d;
                for (int i = 0; i < 10000; i++)
                {
                    e = cipher.Encrypt($"ABC{i.ToString("00000")}");
                    d = cipher.Decrypt(e);
                }
                stopwatch.Stop();
                Console.WriteLine($"Encript & Decrypt 10000: {stopwatch.ElapsedMilliseconds}ms");
            }

            {
                stopwatch.Restart();
                string e, d;
                for (int i = 0; i < 10000; i++)
                {
                    e = cipher.Encrypt($"ABC{i.ToString("00000")}");
                    d = cipher.Decrypt(e);
                }
                stopwatch.Stop();
                Console.WriteLine($"Encript & Decrypt 10000: {stopwatch.ElapsedMilliseconds}ms");
            }
        }

        private static void Method1()
        {
            byte[] data = Encoding.UTF8.GetBytes("stRhong%pword");
            byte[] hash = SHA256.Create().ComputeHash(data);

            Stopwatch stopwatch = new Stopwatch();
            {
                stopwatch.Start();
                var encrypted = EncryptString("ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234", hash);
                stopwatch.Stop();
                Console.WriteLine($"Encrypt 1: {stopwatch.ElapsedMilliseconds}ms");
                stopwatch.Restart();
                var decrypted = DecryptString(encrypted, hash);
                stopwatch.Stop();
                Console.WriteLine($"Decrypt 1: {stopwatch.ElapsedMilliseconds}ms");
            }

            {
                stopwatch.Start();
                var encrypted = EncryptString("ABCD1234", hash);
                stopwatch.Stop();
                Console.WriteLine($"Encrypt 1: {stopwatch.ElapsedMilliseconds}ms");
                stopwatch.Restart();
                var decrypted = DecryptString(encrypted, hash);
                stopwatch.Stop();
                Console.WriteLine($"Decrypt 1: {stopwatch.ElapsedMilliseconds}ms");
            }


            {
                stopwatch.Restart();
                var encrypted1 = EncryptString("ABCD1234", hash);
                var decrypted1 = DecryptString(encrypted1, hash);
                stopwatch.Stop();
                Console.WriteLine($"Encript & Decrypt 1: {stopwatch.ElapsedMilliseconds}ms");
            }

            {
                stopwatch.Restart();
                var encrypted1 = EncryptString("ABCD1234", hash);
                var decrypted1 = DecryptString(encrypted1, hash);
                stopwatch.Stop();
                Console.WriteLine($"Encript & Decrypt 1: {stopwatch.ElapsedMilliseconds}ms");
            }

            {
                stopwatch.Restart();
                string e, d;
                for (int i = 0; i < 10000; i++)
                {
                    e = EncryptString($"ABC{i.ToString("00000")}", hash);
                    d = DecryptString(e, hash);
                }
                stopwatch.Stop();
                Console.WriteLine($"Encript & Decrypt 10000: {stopwatch.ElapsedMilliseconds}ms");
            }

            {
                stopwatch.Restart();
                string e, d;
                for (int i = 0; i < 10000; i++)
                {
                    e = EncryptString($"ABC{i.ToString("00000")}", hash);
                    d = DecryptString(e, hash);
                }
                stopwatch.Stop();
                Console.WriteLine($"Encript & Decrypt 10000: {stopwatch.ElapsedMilliseconds}ms");
            }

        }

        public static string EncryptString(string text, byte[] key)
        {
            using (var aesAlg = Aes.Create("AesManaged"))
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        var iv = aesAlg.IV;

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }


        public static string DecryptString(string cipherText, byte[] key)
        {
            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[fullCipher.Length - iv.Length];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, fullCipher.Length - iv.Length);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }


    }


}
