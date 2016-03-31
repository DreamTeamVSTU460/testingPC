using System;
using System.Management;
using System.Windows.Forms;

namespace TestCPU
{
    class Measure
    {
        // Функция измерения текущей температуры ЦП
        public double GetTemperature()
        {
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\WMI",
                    "SELECT * FROM MSAcpi_ThermalZoneTemperature");

                double curTemp = 0;
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    double temp = Convert.ToDouble(queryObj["CurrentTemperature"].ToString());
                    curTemp = (temp / 10 - 273.15);
                }
                return curTemp;
            }
            catch (ManagementException ex)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + ex.Message);
                return 0;
            }
        }

        // Функция измерения текущей загрузки ЦП
        public double getLoad()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

            int curLoad = 0;
            foreach (ManagementObject queryObj in searcher.Get())
            {
                //curLoad = System.Convert.ToInt32(queryObj["LoadPercentage"]); // У меня эта строчка не работает
            }
            return curLoad;
        }

        // Также тут будет отрисовка графика
    }
}
