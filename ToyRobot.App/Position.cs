namespace ToyRobot.App;

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