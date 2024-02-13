using HomeAutomationApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomationApp.AutomationSystem
{
    public class HomeAutomationSystem : AbstractSystem
    {
        private IThermostat thermostat;
        private IDevice light;
        private IClock clock;
        private IAirConditionDevice airCondition;
        public HomeAutomationSystem(IThermostat thermostat, IDevice light, IClock clock, IAirConditionDevice airCondition)
        {
            this.thermostat = thermostat;
            this.light = light;
            this.clock = clock;
            this.airCondition = airCondition;
        }

        internal override void AutomationLogic()
        {
            DateTime currentTime = clock.GetCurrentTime();

            bool isNightTime = IsNightTime(currentTime);

            if (isNightTime)
            {
                light.TurnOn();
            }
            else
            {
                light.TurnOff();
            }

            // Update the air condition settings based on the time and outside temperature
            double outsideTemperature = thermostat.GetTemperature();
            if (currentTime.Hour >= 0 && currentTime.Hour < 6)
            {
                airCondition.SetTargetTemperature(18); // Nighttime temperature
            }
            else
            {
                airCondition.SetTargetTemperature(21); // Daytime temperature
            }

            // Decide on the mode (cooling/heating) based on the outside temperature
            if (outsideTemperature > 25)
            {
                airCondition.SetMode(AirConditionMode.Cooling);
            }
            else if (outsideTemperature < 15)
            {
                airCondition.SetMode(AirConditionMode.Heating);
            }
            else
            {
                airCondition.SetMode(AirConditionMode.Dehumidification);
            }
        }

        private bool IsNightTime(DateTime currentTime)
        {
            return currentTime.Hour >= 21 || currentTime.Hour < 6;
        }
    }
}
