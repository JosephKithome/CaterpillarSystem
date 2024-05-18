# Caterpillar Control System

A control system for navigating and managing a caterpillar on a distant planet. The system includes features for moving the caterpillar, handling interactions with spices and boosters, and logging commands.

## Features

- Move caterpillar up, down, left, and right
- Grow and shrink the caterpillar
- Handle interactions with spices and boosters
- Detect and avoid obstacles
- Command logging with undo and redo functionality
- Radar display for navigation

## Getting Started

### Prerequisites

- .NET SDK 5.0 or later

### Installation

1. Clone the repository:
    ```bash
    git clone [https://github.com/JosephKithome/CaterpillarSystem.git]
    ```

2. Navigate to the project directory:
    ```bash
    cd CaterpillarSystem
    ```

3. Open the solution in Visual Studio or your preferred IDE:
    ```bash
    dotnet sln open CaterpillarSystem.sln
    ```

### Usage

1. Build the project:
    ```bash
    dotnet build
    ```

2. Run the project:
    ```bash
    dotnet run --project src/CaterpillarSystem
    ```

### Running Tests

1. Navigate to the tests directory:
    ```bash
    cd CaterpillarSystemTests
    ```

2. Run the tests:
    ```bash
    dotnet test
    ```

## Documentation

For detailed design documentation, please refer to [docs/design_documentation.md](docs/design_documentation.md).

## Contributing

Contributions are welcome! Please read [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.



# Design Documentation

## Overview

The Caterpillar Control System is designed to control and navigate a caterpillar on a planet's surface. It includes functionalities for moving the caterpillar, handling interactions with various elements on the map, and managing commands.

## Classes

### CaterpillarControlSystem

- **Properties**:
  - `Head`: The position of the caterpillar's head.
  - `Tail`: The position of the caterpillar's tail.

- **Methods**:
  - `MoveUp(int steps)`: Moves the caterpillar up.
  - `MoveDown(int steps)`: Moves the caterpillar down.
  - `MoveLeft(int steps)`: Moves the caterpillar left.
  - `MoveRight(int steps)`: Moves the caterpillar right.
  - `HandleSpice()`: Handles interactions with spices.
  - `HandleBooster()`: Handles interactions with boosters.
  - `DetectObstacles()`: Detects obstacles and prevents movement through them.
  - `DisplayRadarImage()`: Displays the radar image around the caterpillar's head.
  - `Undo()`: Undoes the last command.
  - `Redo()`: Redoes the last undone command.

### Planet

- **Properties**:
  - `map`: The 2D array representing the planet's map.

- **Methods**:
  - `GetSymbolAtPosition(int x, int y)`: Gets the symbol at the specified position.
  - `SetSymbolAtPosition(int x, int y, char symbol)`: Sets the symbol at the specified position.

### Utils

- **LogHelper**:
  - Methods for logging commands and interactions.

- **DirectionManager**:
  - Methods for managing caterpillar's movement directions.

## Command Logging

Commands are logged in a stack to enable undo and redo functionality. Each command is serialized to JSON and stored in a log file.

## Error Handling

Proper error handling mechanisms are implemented to ensure smooth operation and prevent crashes.

## Testing

Unit tests are provided for each class to ensure the correctness of the functionalities.


## Output 
![Alt text](/output.PNG?raw=true "Sample Output")


