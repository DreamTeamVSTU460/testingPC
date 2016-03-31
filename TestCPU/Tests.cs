using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;
using System.Diagnostics;
using System.IO;

namespace TestCPU
{
    class Tests
    {
        // Тест хеширования по алгоритму SHA1
        public string HashTest()
        {
            byte[] data = new byte[2000000];
            byte[] result;

            string file = @"C:\file.txt";

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            SHA1 sha = new SHA1CryptoServiceProvider();
            // This is one implementation of the abstract class SHA1.

            FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read, 1000);
            for (int i = 0; i < 2000000; i++)
                result = sha.ComputeHash(stream);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);

            return elapsedTime;
        }

        // Тест шифрования по алгоритму AES
        public string CriptTest()
        {
            // Здесь будет код
            return "0";
        }

        // Тест архивирования 
        public string CompressTest()
        {
            // Здесь будет код
            return "0";
        }

        // Тест обработки изображения 
        public string ImageTest()
        {
            // Здесь будет код
            return "0";
        }
    }
}
