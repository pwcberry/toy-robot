namespace ToyRobot.App;

public class Robot
{
    public Table Table { get; private set; }
    public Position Position { get; private set; }
    public Direction Facing { get; private set; }

    public Robot(Table table) : this(table, new Position(0, 0), Direction.North)
    {
    }

    public Robot(Table table, Position position, Direction facing)
    {
        Table = table;

        if (table.IsOutOfBounds(position.X, position.Y))
        {
            throw new OutOfBoundsException(position.X, position.Y, table.Dimensions.Width, table.Dimensions.Height);
        }

        Position = position;
        Facing = facing;
    }

    public void Place(int x, int y, Direction facing)
    {
        if (Table.IsOutOfBounds(x, y))
        {
            throw new OutOfBoundsException(x, y, Table.Dimensions.Width, Table.Dimensions.Height);
        }

        Position = new Position(x, y);
        Facing = facing;
    }

    public void TurnLeft()
    {
        Facing = Facing switch
        {
            Direction.North => Direction.West,
            Direction.East => Direction.North,
            Direction.South => Direction.East,
            Direction.West => Direction.South,
            _ => Facing
        };
    }

    public void TurnRight()
    {
        Facing = Facing switch
        {
            Direction.North => Direction.East,
            Direction.East => Direction.South,
            Direction.South => Direction.West,
            Direction.West => Direction.North,
            _ => Facing
        };
    }

    /// <summary>
    /// Move the robot by one table position in the direction it is facing.
    /// </summary>
    /// <returns>True if the robot moved.</returns>
    public bool Move()
    {
        if (Table.IsFacingBoundary(Position.X, Position.Y, Facing))
        {
            return false;
        }

        var newPosition = Facing switch
        {
            Direction.North => new Position(Position.X, Position.Y + 1),
            Direction.East => new Position(Position.X + 1, Position.Y),
            Direction.South => new Position(Position.X, Position.Y - 1),
            Direction.West => new Position(Position.X - 1, Position.Y),
            _ => Position
        };

        if (newPosition.Equals(Position))
        {
            return false;
        }
        
        Position = newPosition;
        return true;
    }
}