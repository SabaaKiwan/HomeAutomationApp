using HomeAutomationApp.AutomationSystem;
using HomeAutomationApp.Contracts;
using HomeAutomationApp.Devices;
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

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Register your services
                    services.AddSingleton<IThermostat, SimulatedThermostat>();
                    services.AddSingleton<IDevice, SimulatedLight>();
                    services.AddSingleton<IClock, SimulatedClock>();
                    services.AddSingleton<IAirConditionDevice, SimulatedAirCondition>();
                    
                    services.AddSingleton< HomeAutomationSystem>();

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
