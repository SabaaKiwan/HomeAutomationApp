using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomationApp.Contracts
{
    public enum AirConditionMode
    {
        Cooling,
        Heating,
        Dehumidification
    }
    public interface IAirConditionDevice : IDevice
    {
        public void SetTargetTemperature (double temperature);
        public void SetMode(AirConditionMode mode);
    }
}
