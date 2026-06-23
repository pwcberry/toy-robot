# Specification

## Valid commands

|---|---|
| Command | Description |
|---|---|
| PLACE X,Y,F | Put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST |
| MOVE | move the toy robot one unit forward in the direction it is currently facing |
| LEFT | Rotate robot 90 degrees to the left without changing the position of the robot |
| RIGHT | Rotate robot 90 degrees to the right without changing the position of the robot |
| REPORT | Announce the position and facing direction of the robot |

## Rules

1. The toy robot must not fall off the table during movement. This also includes the initial placement of the toy robot. Any move that would cause the robot to fall must be ignored
2. The first valid command to the robot is a PLACE command, after that, any sequence of commands may be issued, in any order, including another PLACE command. The application should discard all commands in the sequence until a valid PLACE command has been executed
3. The origin (0,0) can be considered to be the SOUTH WEST most corner
4. A robot that is not on the table can choose to ignore the MOVE, LEFT, RIGHT and REPORT commands
5. Input can be from a file, or from standard input
6. No obstructions are present on the table surface
