
![Logo](Pics/Logo.png)


[![Apache License](https://img.shields.io/badge/License-Apache2.0-green.svg)](https://choosealicense.com/licenses/apache-2.0/) ![state](https://img.shields.io/badge/state-development-blue) ![version](https://img.shields.io/badge/version-0.1.0-blue)


# Statemachine Generator

The **Statemachine Generator** is a Unity tool designed to simplify and streamline the creation of state machines in your project. This tool eliminates the redundancy of manually copying and re-writing code for different states, allowing you to focus more on gameplay logic rather than boilerplate code.

## Screenshots

<img src="Pics/Screenshots/1.png" alt="App Screenshot" width="400"/>
<img src="Pics/Screenshots/2.png" alt="App Screenshot" width="400"/>
<img src="Pics/Screenshots/3.png" alt="App Screenshot" width="400"/>
<img src="Pics/Screenshots/4.png" alt="App Screenshot" width="400"/>

## How to Use

1. Open the tool from **Tools > IcarusTools > State machine Generator**.
2. Use the **Base Scripts** panel to create your foundational state machine scripts.
3. Switch to the **Player Scripts** panel to create and manage player-specific states and transitions.
4. Use the **Enemy Base Scripts** panel for creating enemy base logic.
5. Finally, use the **Enemy States** panel to create new enemies and define their behaviors.

Each panel is designed to minimize redundancy and generate clean, organized code for you.



## Code Structure

The generated code follows a well-organized structure, keeping your state machine classes modular and manageable. You can review the class hierarchy and relationships in the diagram below.

![UML](Assets/Diagrams/TheStructureOfTheStatemachine.png)

*Note: The full diagram file is available in `Assets/Diagrams` if the image is not fully visible.*

## Installation

1. Download the package from [Link to Download](https://github.com/alithegreat74/State-Machine-Generator/releases).
2. Import the package into your Unity project.
3. Open the **State Machine Generator** from the Tools menu.
