namespace ToyRobot.Console;

/// <summary>
/// Represents the placement request for the robot on the table, including its X and Y coordinates and the direction it is facing.
/// </summary>
/// <param name="x">The X coordinate of the robot's position on the table.</param>
/// <param name="y">The Y coordinate of the robot's position on the table.</param>
/// <param name="facing">The direction the robot is facing.</param>
public readonly record struct Placement(int X, int Y, Direction Facing)
{
    public bool IsNowhere => this == Nowhere;

    public static readonly Placement Nowhere = new(-1, -1, Direction.North);

    public static Placement Parse(string inputs)
    {
        var parts = inputs.Split(',');
        return parts.Length == 3 ? Parse(parts) : Nowhere;
    }

    public static Placement Parse(string[] inputs)
    {
        if (inputs.Length == 3 &&
            int.TryParse(inputs[0], out int x) &&
            int.TryParse(inputs[1], out int y) &&
            Enum.TryParse(inputs[2], true, out Direction facing))
        {
            return new Placement(x, y, facing);
        }

        return Nowhere;
    }

    /// <summary>
    /// Return the position and facing direction as a tuple.
    /// </summary>
    public void Deconstruct(out int x, out int y, out Direction facing)
    {
        x = X;
        y = Y;
        facing = Facing;
    }
}