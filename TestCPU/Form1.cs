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
using ZedGraph;

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
            try
            {
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
                    Load.Text = queryObj["LoadPercentage"].ToString() + " %"; // У меня эта строчка не работает
                    Manufacturer.Text = queryObj["Manufacturer"].ToString();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hashTestStart_Click(object sender, EventArgs e)
        {
            // Здесь должен быть запуск замеров

            string time = test.HashTest(2000000, testingProgressBar);
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

        private void TempretureButton_Click(object sender, EventArgs e)
        {
            temperatureGraph();
        }       

        private async void temperatureGraph()
        {
            z1.IsShowPointValues = true;
            z1.GraphPane.Title = "CPU Temperature";
            GraphPane pane = z1.GraphPane;
            double[] x = new double[100];
            double[] y = new double[100];
            Measure t = new Measure();
            testingProgressBar.Maximum = 100;
            for (int i = 0; i < 100; i++)
            {
                y[i] = t.GetTemperature();
                x[i] = i * 100;
                await pause(1500);
                testingProgressBar.Value++;
            }
            pane.XAxis.Title = "Время";
            pane.YAxis.Title = "Температура";

            z1.GraphPane.AddCurve("Temerature", x, y, Color.Red, SymbolType.None);
            z1.AxisChange();
            z1.Invalidate();
        }
        private async Task pause(int time)
        {
            await Task.Delay(time);
        }
    }
}
