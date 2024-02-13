using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomationApp.Contracts
{
    public interface IDevice
    {
        void TurnOn();
        void TurnOff();

        string GetState();
    }
}
