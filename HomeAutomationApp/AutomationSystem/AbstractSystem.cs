using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomationApp.AutomationSystem
{
    public abstract class AbstractSystem
    {

        internal bool isAutomationRunning = false;

        public void RunAutomation()
        {
            if (!isAutomationRunning)
            {
                isAutomationRunning = true;
                Task.Run(async () => await AutomationLoop());
            }
        }

        public void StopAutomation()
        {
            isAutomationRunning = false;
        }

        private async Task AutomationLoop()
        {
            while (isAutomationRunning)
            {
                AutomationLogic();

                await Task.Delay(1000); // Delay for 1 seconds before checking again
            }
        }

        internal abstract void AutomationLogic();
    }
}
