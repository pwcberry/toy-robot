namespace ToyRobot.Console;

public readonly struct Dimensions(int width, int height) : IEquatable<Dimensions>
{
    public int Width => width;
    
    public int Height => height;

    #region Equality
    public bool Equals(Dimensions other)
    {
        return Width == other.Width && Height == other.Height;
    }

    public override bool Equals(object? obj)
    {
        return obj is Dimensions other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Width, Height);
    }

    public static bool operator ==(Dimensions left, Dimensions right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Dimensions left, Dimensions right)
    {
        return !left.Equals(right);
    }
    #endregion

    /// <summary>
    /// Return the width and height as a tuple.
    /// </summary>
    public void Deconstruct(out int w, out int h)
    {
        w = Width;
        h = Height;
    }
}