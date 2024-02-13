using HomeAutomationApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomationApp.Devices
{
    public class SimulatedLight : IDevice
    {
        private bool isOn = false;

        public bool IsOn => isOn;

        public void TurnOff()
        {
            isOn = false;
        }

        public void TurnOn()
        {
            isOn = true;
        }

        string IDevice.GetState()
        {
            return "Smart Light Is: " + (isOn ? " On" : " Off");
        }
    }
}
