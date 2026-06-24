namespace ToyRobot.Console;

public class RobotAction
{
    public RobotAction(Command command) : this(command, Placement.Nowhere)
    {
    }

    public RobotAction(Command command, Placement placement)
    {
        Command = command;
        Placement = placement;
    }
    
    public Command Command { get; }
    
    public Placement Placement { get; }

    public override string ToString()
    {
        return $"Action: {Command} {Placement}".TrimEnd();
    }
}

