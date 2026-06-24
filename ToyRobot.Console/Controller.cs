namespace ToyRobot.Console;

/// <summary>
/// Represents the main controller for the toy robot application, responsible for processing user input commands, controlling the robot's actions, and managing the application's flow.
/// </summary>
/// <param name="input">The input stream for reading user commands.</param>
/// <param name="output">The output stream for writing responses and status messages.</param>
public class Controller(TextReader input, TextWriter output)

{
    public void Run()
    {
        var isRunning = true;
        var table = new Table();
        var robot = new Robot(table);

        while (isRunning && input.Peek() != -1)
        {
            var line = input.ReadLine() ?? string.Empty;
            var action = InputParser.Parse(line);

            // Do not execute any command other than PLACE until the robot has been placed on the table
            if (robot.Placement.IsNowhere && action.Command != Command.Place)
            {
                continue;
            }
    
            switch (action.Command)
            {
                case Command.Place:
                    PlaceRobot(robot, action.Placement);
                    break;
                case Command.Move:
                    robot.Move();
                    break;
                case Command.Left:
                    robot.TurnLeft();
                    break;
                case Command.Right:
                    robot.TurnRight();
                    break;
                case Command.Report:
                    ReportRobotStatus(robot);
                    break;
                case Command.Quit:
                    output.WriteLine("GOODBYE");
                    isRunning = false;
                    break;
                case Command.Invalid:
                    output.WriteLine($"Invalid {action}");
                    break;
            }
        }
    }

    private void PlaceRobot(Robot robot, Placement placement)
    {
        if (placement.IsNowhere)
        {
            output.WriteLine("Invalid PLACE command");
            return;
        }

        var (x, y, facing) = placement;
        robot.Place(x, y, facing);
    }

    private void ReportRobotStatus(Robot robot)
    {
        if (robot != null && !robot.Placement.IsNowhere)
        {
            output.WriteLine(robot);
        }
        else
        {
            output.WriteLine("NOWHERE");
        }
    }
}
