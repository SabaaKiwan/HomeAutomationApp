using HomeAutomationApp.AutomationSystem.HomeAutomationSystem;
using HomeAutomationApp.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomationApp.AutomationSystem
{
    public abstract class AbstractSystem<TState> where TState : AbstractSystemState
    {
        public class SystemStateChangedEventArgs : EventArgs
        {
            public SystemStateChangedEventArgs(TState state)
            { State = state; }
            public TState State { get; set; }
        }
        public event EventHandler<SystemStateChangedEventArgs>? SystemStateChanged;
        private TState? previousState =null;

        public abstract TState GetCurrentState();


        internal IList<ISensor> Sensors = new List<ISensor>();
        internal IList<IDevice> Devices = new List<IDevice>();


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

                TState currentState = GetCurrentState();

                // Only raise the event if the state has changed
                if (!currentState.Equals(previousState))
                {
                    OnSystemStateChanged(new SystemStateChangedEventArgs(currentState));
                    previousState = currentState;
                }

                await Task.Delay(1000); // Delay for 1 seconds before checking again
            }
        }

        protected virtual void OnSystemStateChanged(SystemStateChangedEventArgs state)
        {
            SystemStateChanged?.Invoke(this, state);
        }
        internal abstract void AutomationLogic();
    }
}
