namespace ToyRobot.Console;

/// <summary>
/// Represents the placement request for the robot on the table, including its X and Y coordinates and the direction it is facing.
/// </summary>
/// <param name="x">The X coordinate of the robot's position on the table.</param>
/// <param name="y">The Y coordinate of the robot's position on the table.</param>
/// <param name="facing">The direction the robot is facing.</param>
public readonly struct Placement(int x, int y, Direction facing)
    : IEquatable<Placement>
{
    public int X => x;
    public int Y => y;
    public Direction Facing => facing;
    
    public static readonly Placement Empty = new(-1, -1, Direction.South);

    public bool IsEmpty => this == Empty;

    #region Equality

    public bool Equals(Placement other) => X == other.X && Y == other.Y && Facing == other.Facing;

    public override bool Equals(object? obj) => obj is Placement other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(X, Y, Facing);

    public static bool operator ==(Placement left, Placement right) => left.Equals(right);

    public static bool operator !=(Placement left, Placement right) => !left.Equals(right);
    #endregion

    /// <summary>
    /// Return the position and facing direction as a tuple.
    /// </summary>
    public void Deconstruct(out int x, out int y, out Direction facing)
    {
        x = X;
        y = Y;
        facing = Facing;
    }

    public static Placement Parse(string inputs)
    {
        var parts = inputs.Split(',');
        return parts.Length == 3 ? Parse(parts) : throw new ArgumentException($"Invalid number of parts: {inputs}");
    }

    public static Placement Parse(string[] inputs)
    {
        if (inputs.Length != 3)
        {
            throw new ArgumentException($"Invalid number of parts: {string.Join(',', inputs)}");
        }

        if (!int.TryParse(inputs[0], out var x))        
        {
            throw new ArgumentException($"Invalid X coordinate: {inputs[0]}");
        }

        if (!int.TryParse(inputs[1], out var y))
        {
            throw new ArgumentException($"Invalid Y coordinate: {inputs[1]}");
        }

        return Enum.TryParse(inputs[2], true, out Direction facing) ?
            new Placement(x, y, facing) :
            throw new ArgumentException($"Invalid direction: {inputs[2]}");
    }
}