namespace ToyRobot.Console;

/// <summary>
/// Represents the position of the robot or other object on the table.
/// </summary>
/// <param name="x">The X coordinate of the table.</param>
/// <param name="y">The Y coordinate of the table.</param>
public readonly struct Position(int x, int y): IEquatable<Position>
{
    public int X => x;
    public int Y => y;
    
    public static Position Origin => new Position(0, 0);
    
    public bool Equals(Position other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        return obj is Position other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public static bool operator ==(Position left, Position right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Position left, Position right)
    {
        return !left.Equals(right);
    }
}