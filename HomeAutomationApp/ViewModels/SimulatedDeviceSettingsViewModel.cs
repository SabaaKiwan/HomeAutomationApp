using CommunityToolkit.Mvvm.ComponentModel;
using HomeAutomationApp.AutomationSystem.HomeAutomationSystem;
using HomeAutomationApp.Contracts;
using HomeAutomationApp.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomationApp.ViewModels
{
    public partial class SimulatedDeviceSettingsViewModel : ObservableRecipient
    {
        private SimulatedThermostat thermostat;
        private SimulatedLight light;
        private SimulatedClock clock;
        private SimulatedAirCondition airCondition;
        public SimulatedDeviceSettingsViewModel(
            SimulatedThermostat thermostat,
            SimulatedLight light,
            SimulatedClock clock,
            SimulatedAirCondition airCondition)
        {
            this.thermostat = thermostat;
            this.light = light;
            this.clock = clock;
            this.airCondition = airCondition;
        }

        public double SimulatedOutsideTemperature
        {
            get { return thermostat.GetTemperature(); }
            set
            {
                thermostat.SetTemperature(value);
                OnPropertyChanged();
            }
        }

        [ObservableProperty]
        private bool useMachineClock = true;


        [ObservableProperty]
        private bool autoRunClock = false;

        [ObservableProperty]
        private double clockSpeed = 1;
    }
}
