using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using HomeAutomationApp.AutomationSystem.HomeAutomationSystem;

namespace HomeAutomationApp.ViewModels
{
    public partial class HomeAutomationViewModel : ObservableRecipient
    {
        private readonly HomeAutomationSystem homeAutomationSystem;
        private readonly SimulatedDeviceSettingsViewModel deviceSettingsViewModel;

        public HomeAutomationViewModel(HomeAutomationSystem homeAutomationSystem, SimulatedDeviceSettingsViewModel simulationSettings)
        {
            this.homeAutomationSystem = homeAutomationSystem;
            homeAutomationSystem.SystemStateChanged += (sender, args) => UpdateSystemState(args.State);

            deviceSettingsViewModel = simulationSettings;
        }

        private void UpdateSystemState(HomeAutomationState state)
        {
            // Get and update properties that represent the state of the system
            LightState = state.LightState;
            AirConditionState = state.AirConditionState;
            OutsideTemperature = state.OutsideTemperature;
            CurrentTime = state.CurrentTime;
        }


        [ObservableProperty]
        private string lightState = "";

        [ObservableProperty]
        private string airConditionState = "";

        [ObservableProperty]
        private string outsideTemperature = "";

        [ObservableProperty]
        private string currentTime = "";

        public SimulatedDeviceSettingsViewModel DeviceSettingsViewModel => deviceSettingsViewModel;

    }
}
