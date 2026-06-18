namespace ToyRobot.App;

public class RobotAction
{
    public RobotAction(Command command) : this(command, Placement.Empty)
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

