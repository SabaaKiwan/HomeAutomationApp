using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomationApp.AutomationSystem.HomeAutomationSystem
{
    public class HomeAutomationState : AbstractSystemState
    {
        public HomeAutomationState(string outsideTemperature, string time, string light,
            string airCondition)
        {
            this.OutsideTemperature = outsideTemperature;
            this.CurrentTime = time;
            this.LightState = light;
            this.AirConditionState = airCondition;
        }

        public string OutsideTemperature { get; set; }
        public string CurrentTime { get; set; }
        public string LightState { get; set; }
        public string AirConditionState { get; set; }
        

        // Override Equals method to compare states for changes
        public override bool Equals(object obj)
        {
            if (!(obj is HomeAutomationState otherState))
                return false;

            return LightState == otherState.LightState &&
                   AirConditionState == otherState.AirConditionState &&
                   OutsideTemperature == otherState.OutsideTemperature &&
                   CurrentTime == otherState.CurrentTime;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(LightState, AirConditionState, OutsideTemperature, CurrentTime);
        }
    }
}
