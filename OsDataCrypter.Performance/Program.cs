using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using OsDataCipher;

namespace OsDataCipher.Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            Using_StaticDataCipher();
            Console.WriteLine("----------------------------------------------------------------");
            Using_OsDataCipher();
            Console.ReadKey();
        }

        private static void Using_OsDataCipher()
        {
            Stopwatch stopwatch = new Stopwatch();
            var cipher = new OsDataCipher("stRhong%pword");

            {
                stopwatch.Start();
                var encrypted = cipher.Encrypt("ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234");
                stopwatch.Stop();
                Console.WriteLine($"Encrypt 1: {stopwatch.ElapsedMilliseconds}ms");
                stopwatch.Restart();
                var _ = cipher.Decrypt(encrypted);
                stopwatch.Stop();
                Console.WriteLine($"Decrypt 1: {stopwatch.ElapsedMilliseconds}ms");
            }

            {
                stopwatch.Start();
                var encrypted = cipher.Encrypt("ABCD1234");
                stopwatch.Stop();
                Console.WriteLine($"Encrypt 1: {stopwatch.ElapsedMilliseconds}ms");
                stopwatch.Restart();
                var _ = cipher.Decrypt(encrypted);
                stopwatch.Stop();
                Console.WriteLine($"Decrypt 1: {stopwatch.ElapsedMilliseconds}ms");
            }


            {
                stopwatch.Restart();
                var encrypted1 = cipher.Encrypt("ABCD1234");
                var _ = cipher.Decrypt(encrypted1);
                stopwatch.Stop();
                Console.WriteLine($"Encrypt & Decrypt 1: {stopwatch.ElapsedMilliseconds}ms");
            }

            {
                stopwatch.Restart();
                var encrypted1 = cipher.Encrypt("ABCD1234");
                var _ = cipher.Decrypt(encrypted1);
                stopwatch.Stop();
                Console.WriteLine($"Encrypt & Decrypt 1: {stopwatch.ElapsedMilliseconds}ms");
            }

            {
                stopwatch.Restart();
                string e;
                for (int i = 0; i < 10000; i++)
                {
                    e = cipher.Encrypt($"ABC{i:00000}");
                    _ = cipher.Decrypt(e);
                }
                stopwatch.Stop();
                Console.WriteLine($"Encrypt & Decrypt 10000: {stopwatch.ElapsedMilliseconds}ms");
            }

            {
                stopwatch.Restart();
                string e;
                for (int i = 0; i < 10000; i++)
                {
                    e = cipher.Encrypt($"ABC{i:00000}");
                    _ = cipher.Decrypt(e);
                }
                stopwatch.Stop();
                Console.WriteLine($"Encrypt & Decrypt 10000: {stopwatch.ElapsedMilliseconds}ms");
            }
        }

        private static void Using_StaticDataCipher()
        {
            byte[] data = Encoding.UTF8.GetBytes("stRhong%pword");
            byte[] hash = SHA256.Create().ComputeHash(data);

            Stopwatch stopwatch = new Stopwatch();
            {
                stopwatch.Start();
                var encrypted = StaticCipher.EncryptString("ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234ABCD1234", hash);
                stopwatch.Stop();
                Console.WriteLine($"Encrypt 1: {stopwatch.ElapsedMilliseconds}ms");
                stopwatch.Restart();
                var _ = StaticCipher.DecryptString(encrypted, hash);
                stopwatch.Stop();
                Console.WriteLine($"Decrypt 1: {stopwatch.ElapsedMilliseconds}ms");
            }

            {
                stopwatch.Start();
                var encrypted = StaticCipher.EncryptString("ABCD1234", hash);
                stopwatch.Stop();
                Console.WriteLine($"Encrypt 1: {stopwatch.ElapsedMilliseconds}ms");
                stopwatch.Restart();
                var _ = StaticCipher.DecryptString(encrypted, hash);
                stopwatch.Stop();
                Console.WriteLine($"Decrypt 1: {stopwatch.ElapsedMilliseconds}ms");
            }


            {
                stopwatch.Restart();
                var encrypted1 = StaticCipher.EncryptString("ABCD1234", hash);
                var _ = StaticCipher.DecryptString(encrypted1, hash);
                stopwatch.Stop();
                Console.WriteLine($"Encrypt & Decrypt 1: {stopwatch.ElapsedMilliseconds}ms");
            }

            {
                stopwatch.Restart();
                var encrypted1 = StaticCipher.EncryptString("ABCD1234", hash);
                var _ = StaticCipher.DecryptString(encrypted1, hash);
                stopwatch.Stop();
                Console.WriteLine($"Encrypt & Decrypt 1: {stopwatch.ElapsedMilliseconds}ms");
            }

            {
                stopwatch.Restart();
                string e;
                for (int i = 0; i < 10000; i++)
                {
                    e = StaticCipher.EncryptString($"ABC{i:00000}", hash);
                    _ = StaticCipher.DecryptString(e, hash);
                }
                stopwatch.Stop();
                Console.WriteLine($"Encrypt & Decrypt 10000: {stopwatch.ElapsedMilliseconds}ms");
            }

            {
                stopwatch.Restart();
                string e;
                for (int i = 0; i < 10000; i++)
                {
                    e = StaticCipher.EncryptString($"ABC{i:00000}", hash);
                    _ = StaticCipher.DecryptString(e, hash);
                }
                stopwatch.Stop();
                Console.WriteLine($"Encrypt & Decrypt 10000: {stopwatch.ElapsedMilliseconds}ms");
            }

        }

      


    }


}
