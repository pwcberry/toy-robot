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
            try
            {
                var line = input.ReadLine() ?? string.Empty;
                var action = InputParser.Parse(line);

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
            catch (OutOfBoundsException obEx)
            {
                output.WriteLine(obEx.Message);
            }
            catch (ArgumentException argEx)
            {
                output.WriteLine($"Error in placement arguments:\n{argEx.Message}");
                isRunning = false;
            }
            catch (Exception ex)
            {
                output.WriteLine(ex.ToString());
                isRunning = false;
            }
        }
    }

    private void PlaceRobot(Robot robot, Placement placement)
    {
        if (placement.IsEmpty)
        {
            output.WriteLine("Invalid PLACE command: missing arguments");
            return;
        }

        var (x, y, facing) = placement;
        robot.Place(x, y, facing);
    }

    private void ReportRobotStatus(Robot robot)
    {
        output.WriteLine(robot);
    }
}
