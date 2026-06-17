namespace ToyRobot.App;

public readonly struct Dimensions(int width, int height) : IEquatable<Dimensions>
{
    public int Width => width;
    
    public int Height => height;

    /// <summary>
    /// Compare the dimensions with a two-item Tuple.
    /// </summary>
    /// <param name="other">The "duple" to check for equality with.</param>
    /// <returns>True when the two tuple items equal the width and height.</returns>
    public bool Equals(Tuple<int, int> other)
    {
        var (w, h) = other;
        return w == Width && h == Height;
    }
    
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

    /// <summary>
    /// Return the width and height.
    /// </summary>
    public void Deconstruct(out int w, out int h)
    {
        w = Width;
        h = Height;
    }
}