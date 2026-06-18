namespace ToyRobot.Console;

public class OutOfBoundsException : ApplicationException
{
    public OutOfBoundsException(string message) : base(message)
    {
    }
    
    public OutOfBoundsException(int x, int y, int width, int height) : base($"Position ({x}, {y}) is out of bounds for table of size {width}x{height}")
    {
    }
}