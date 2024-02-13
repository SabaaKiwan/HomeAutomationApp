using HomeAutomationApp.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomationApp.Devices
{
    public class SimulatedClock : IClock
    {
        private DateTime? time = null;

        public void SetTime(DateTime time)
        {
            this.time = time;
        }
        public DateTime GetCurrentTime()
        {
            return time ?? DateTime.Now;
        }
    }
}
