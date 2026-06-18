namespace ToyRobot.Console;

public static class InputParser
{
    public static RobotAction Parse(string input)
    {
        var parts = input.ToUpperInvariant().Split(' ');
        var arguments = parts.Length > 1 ? parts[1] : string.Empty;

        var command = parts[0] switch
        {
            "PLACE" => Command.Place,
            "MOVE" => Command.Move,
            "LEFT" => Command.Left,
            "RIGHT" => Command.Right,
            "REPORT" => Command.Report,
            "QUIT" => Command.Quit,
            _ => Command.Invalid
        };

        return !arguments.Contains(',') ?
            new RobotAction(command, Placement.Empty) :
            new RobotAction(command, Placement.Parse(arguments));
    }
}