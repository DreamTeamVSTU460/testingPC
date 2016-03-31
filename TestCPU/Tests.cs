using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;

namespace TestCPU
{
    class Tests
    {
        // Тест хеширования по алгоритму SHA1
        public string HashTest(int bytes, ProgressBar pb)
        {
            byte[] data = new byte[bytes];
            byte[] result;

            pb.Maximum = bytes;

            string file = @"file.txt";

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            SHA1 sha = new SHA1CryptoServiceProvider();
            // This is one implementation of the abstract class SHA1.

            try
            {
                FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read, 1000);

                for (int i = 0; i < bytes; i++)
                {
                    result = sha.ComputeHash(stream);
                    pb.Value++;
                }

            }
            catch (Exception e) { MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            string startPath = @"c:\example\start";
            try
            {
                FastZip zip = new FastZip();
                zip.CreateZip("my.zip", "toZip", true, null);
            }
            catch (Exception e) { MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);

            return elapsedTime;
        }

        // Тест обработки изображения 
        public string ImageTest()
        {
            // Здесь будет код
            return "0";
        }
    }
}
