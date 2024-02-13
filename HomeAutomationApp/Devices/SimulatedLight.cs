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

        public bool GetState()
        {
            return isOn;
        }

        public void TurnOff()
        {
            isOn = false;
        }

        public void TurnOn()
        {
            isOn = false;
        }
    }
}
