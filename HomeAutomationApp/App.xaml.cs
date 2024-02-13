using HomeAutomationApp.AutomationSystem.HomeAutomationSystem;
using HomeAutomationApp.Contracts;
using HomeAutomationApp.Devices;
using HomeAutomationApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HomeAutomationApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost host;

        public static T GetService<T>() where T : class
        {
            if ((App.Current as App)!.host.Services.GetService(typeof(T)) is not T service)
            {
                throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
            }

            return service;
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Register your SimulatedDevices
                    services.AddSingleton<SimulatedThermostat>();
                    services.AddSingleton<SimulatedLight>();
                    services.AddSingleton<SimulatedClock>();
                    services.AddSingleton<SimulatedAirCondition>();


                    // Register your System
                    services.AddSingleton<HomeAutomationSystem>();

                    // Register your Devices
                    services.AddSingleton<IThermostat>(provider => provider.GetRequiredService<SimulatedThermostat>());
                    services.AddSingleton<IDevice>(provider => provider.GetRequiredService<SimulatedLight>());
                    services.AddSingleton<IClock>(provider => provider.GetRequiredService<SimulatedClock>());
                    services.AddSingleton<IAirConditionDevice>(provider => provider.GetRequiredService<SimulatedAirCondition>());


                    // Views and ViewModels
                    services.AddTransient<SimulatedDeviceSettingsViewModel>();
                    services.AddTransient<HomeAutomationViewModel>();

                    // Other services and configurations...
                })
                .Build();

            // Start the automation on application startup
            host.Services.GetRequiredService<HomeAutomationSystem>().RunAutomation();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            // Clean up resources on application exit
            host?.Dispose();

            base.OnExit(e);
        }
    }
}
