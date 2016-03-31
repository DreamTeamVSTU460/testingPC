using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace TestCPU
{
    public partial class Form1 : Form
    {
        Tests test = new Tests();

        public Form1()
        {
            InitializeComponent();

            // Запрос на получение информации о ЦП
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

            // Вывод информации о ЦП в форму
            foreach (ManagementObject queryObj in searcher.Get())
            {
                name.Text = queryObj["Name"].ToString();
                numCore.Text = queryObj["NumberOfCores"].ToString();
                ident.Text = queryObj["ProcessorId"].ToString();
                speed.Text = queryObj["MaxClockSpeed"].ToString() + " MHz";
                sysName.Text = queryObj["SystemName"].ToString();
                numLogCore.Text = queryObj["NumberOfLogicalProcessors"].ToString();
                curSpeed.Text = queryObj["CurrentClockSpeed"].ToString() + " MHz";
                data.Text = queryObj["DataWidth"].ToString() + " Bit";
                Cache1.Text = queryObj["L2CacheSize"].ToString() + " Kilobytes";
                Cache2.Text = queryObj["L3CacheSize"].ToString() + " Kilobytes";
                //Load.Text = queryObj["LoadPercentage"].ToString() + " %"; // У меня эта строчка не работает
                Manufacturer.Text = queryObj["Manufacturer"].ToString();
            }
        }

        private void hashTestStart_Click(object sender, EventArgs e)
        {
            // Здесь должен быть запуск замеров

            string time = test.HashTest();
            HashTestTime.Text = time;
        }

        private void CriptTestStart_Click(object sender, EventArgs e)
        {
            // Здесь должен быть запуск замеров

            string time = test.CriptTest();
            CriptTestTime.Text = time;
        }

        private void CompressTestStart_Click(object sender, EventArgs e)
        {
            // Здесь должен быть запуск замеров

            string time = test.CompressTest();
            CompressTestTime.Text = time;
        }

        private void ImageTestStart_Click(object sender, EventArgs e)
        {
            // Здесь должен быть запуск замеров

            string time = test.ImageTest();
            ImageTestTime.Text = time;
        }
    }
}
