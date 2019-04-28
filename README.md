# Turtle-Game

## Application Name: TurtleGame

### Configuration: Config.yml
- It contains the input settings for the Board, Turtle, Exit and list of Mines.

### Action paths (Success.yml, MineHit.yml, StillDanger.yml)
- Success.yml: This is a list of movements (Move, Rotate) that leads to Exit.
- StillDanger.yml: This is a list of movements (Move, Rotate) that leads the Turtle to hit the wall.
- MineHit.yml: This is a list of movements (Move, Rotate) that leads the Turtle to hit the mine.

### How to execute the application:
1. Open Command Prompt and change the directory TurtleGame\bin\Debug or Release
2. It can receive two arguments when executing, the first one is the configuration file and the second the actions the Turtle will execute (e.g. TurtleGame <config_filename> <actions_filename>)
3. If no argument is passed it will use the default values: config and Success.
