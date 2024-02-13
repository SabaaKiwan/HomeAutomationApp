using HomeAutomationApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomationApp.Devices
{
    public class SimulatedAirCondition : IAirConditionDevice
    {
        private bool isOn;
        private double targetTemprature;
        private AirConditionMode airConditionMode;


        public void SetMode(AirConditionMode mode)
        {
            airConditionMode = mode;
        }

        public void SetTargetTemperature(double temperature)
        {
            targetTemprature = temperature;
        }

        public void TurnOff()
        {
            isOn = false;
        }

        public void TurnOn()
        {
            isOn = true;
        }


        public bool GetState()
        {
            return isOn;
        }

        public double GetTargetTemperature()
        {
            return targetTemprature;
        }

        public AirConditionMode GetAirConditionMode() { return airConditionMode; }

        string IDevice.GetState()
        {
            return "Smart Air Condition Is " +
                (isOn ?
                "Running In Mode " + airConditionMode.ToString() +
                " With Target Temperature " + targetTemprature.ToString()

                : " Off");
        }
    }
}
