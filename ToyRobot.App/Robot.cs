namespace ToyRobot.App;

public class Robot
{
    public Grid Grid { get; private set; }
    public Position Position { get; private set; }
    public Direction Facing { get; private set; }
    
    public Robot(Grid grid): this(grid, new Position(0, 0), Direction.North)
    {
    }
    
    public Robot(Grid grid, Position position, Direction facing)
    {
        Grid = grid;

        if (grid.IsOutOfBounds(position.X, position.Y))
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position is out of bounds");
        }
        
        Position = position;
        Facing = facing;
    }
    
    
}