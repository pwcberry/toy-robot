namespace ToyRobot.App;

public class Table
{
    public Table()
    {
        Dimensions = new Dimensions(5, 5);
    }

    public Table(int width, int height)
    {
        Dimensions = new Dimensions(width, height);
    }

    public Dimensions Dimensions { get; }

    public bool IsFacingBoundary(int x, int y, Direction facing) => facing switch
    {
        Direction.North => y == Dimensions.Height - 1,
        Direction.East => x == Dimensions.Width - 1,
        Direction.South => y == 0,
        Direction.West => x == 0,
        _ => throw new ArgumentOutOfRangeException(nameof(facing), $"Invalid direction: {facing}")
    };

    public bool IsOutOfBounds(int x, int y) => (x < 0 || x >= Dimensions.Width) || (y < 0 || y >= Dimensions.Height);
}