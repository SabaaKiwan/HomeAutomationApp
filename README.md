## Description

HomeAutomationApp is a simple home automation application developed in WPF. The application connects to various sensors and devices to automate home settings, including a thermostat sensor, clock, smart light, and air conditioner.

## Features

1. **Thermostat Sensor**: Monitors the outside temperature.
2. **Clock**: Manages time-related events.
3. **Smart Light**: Controls the lighting system.
4. **Air Conditioner**: Regulates the indoor temperature.

## Automation Logic

### Lighting

- **Night Mode**: Turns on the lights during the night until midnight.
- **Day Mode**: Lights are turned off during the day.

### Air Conditioning

- **Daytime Temperature**: Sets the target temperature to 21 degrees Celsius during the day.
- **Nighttime Temperature**: Lowers the target temperature to 18 degrees Celsius after midnight.
- **Mode Control**: Adjusts the air conditioning mode based on the outside temperature from the thermostat.

## Simulator

The application includes a simulator for the thermostat sensor, allowing users to control and test the sensor's behavior directly from the GUI.

## GUI

The graphical user interface (GUI) displays the current state of the system, providing users with a clear overview of the automation settings and sensor readings.

## How to Use

1. Clone the repository.
2. Open the project in your preferred WPF development environment.
3. Build and run the application.
4. Explore the GUI to monitor and control the home automation system.

Feel free to contribute, report issues, or suggest improvements!

## License

This project is licensed under the [MIT License](LICENSE).