using HomeAutomationApp.AutomationSystem.HomeAutomationSystem;
using HomeAutomationApp.Devices;

namespace HomeAutomationApp.Tests
{
    [TestClass]
    public class HomeAutomationSystemTests
    {
        [TestMethod]
        public async Task AutomationLogic_TurnsOnLightAtNight()
        {
            // Arrange
            var simulatedThermostat = new SimulatedThermostat();  // You can replace this with a mock if needed
            var simulatedLight = new SimulatedLight();
            var simulatedClock = new SimulatedClock();
            var simulatedAirCondition = new SimulatedAirCondition();

            var homeAutomationSystem = new HomeAutomationSystem(simulatedThermostat, simulatedLight, simulatedClock, simulatedAirCondition);

            // Set a specific time to simulate night
            simulatedClock.SetTime(new DateTime(2022, 1, 1, 22, 0, 0));

            // Act
            homeAutomationSystem.RunAutomation();
            await Task.Delay(TimeSpan.FromSeconds(2));

            // Assert
            Assert.IsTrue(simulatedLight.IsOn);
        }

        [TestMethod]
        public async Task AutomationLogic_TurnsOffLightDuringDay()
        {
            // Arrange
            var simulatedThermostat = new SimulatedThermostat();
            var simulatedLight = new SimulatedLight();
            var simulatedClock = new SimulatedClock();
            var simulatedAirCondition = new SimulatedAirCondition();

            var homeAutomationSystem = new HomeAutomationSystem(simulatedThermostat, simulatedLight, simulatedClock, simulatedAirCondition);

            // Set a specific time to simulate day
            simulatedClock.SetTime(new DateTime(2022, 1, 1, 12, 0, 0));

            // Act
            homeAutomationSystem.RunAutomation();
            await Task.Delay(TimeSpan.FromSeconds(2));

            // Assert
            Assert.IsFalse(simulatedLight.IsOn);
        }

        [TestMethod]
        public async Task AutomationLogic_SetsAirConditionTemperatureDuringDay()
        {
            // Arrange
            var simulatedThermostat = new SimulatedThermostat();
            var simulatedLight = new SimulatedLight();
            var simulatedClock = new SimulatedClock();
            var simulatedAirCondition = new SimulatedAirCondition();

            var homeAutomationSystem = new HomeAutomationSystem(simulatedThermostat, simulatedLight, simulatedClock, simulatedAirCondition);

            // Set a specific time to simulate day
            simulatedClock.SetTime(new DateTime(2022, 1, 1, 12, 0, 0));

            // Act
            homeAutomationSystem.RunAutomation();
            await Task.Delay(TimeSpan.FromSeconds(2));

            // Assert
            Assert.AreEqual(21, simulatedAirCondition.GetTargetTemperature()); // Daytime temperature
        }
    }
}