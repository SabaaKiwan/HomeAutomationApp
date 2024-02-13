using HomeAutomationApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomationApp.Devices
{
    public class SimulatedThermostat : IThermostat
    {
        private double temperature = 0;

        public SimulatedThermostat()
        {

            Console.WriteLine("SimulatedThermostat");
        }

        public void SetTemperature(double temperature)
        {
            this.temperature = temperature;
        }

        public double GetTemperature()
        {
            return temperature;
        }

        public string GetState()
        {
            return "Smart Thermostat Reads " + temperature.ToString() + " Degree";
        }

    }
}
