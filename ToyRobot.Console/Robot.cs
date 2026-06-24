namespace ToyRobot.Console;

public class Robot
{
    public Table Table { get; private set; }
    public Placement Placement { get; private set; }

    public Robot(Table table) : this(table, Placement.Nowhere)
    {
    }

    public Robot(Table table, Placement placement)
    {
        Table = table;
        Placement = placement;
    }

    public void Place(int x, int y, Direction facing)
    {
        if (!Table.IsOutOfBounds(x, y))
        {
            Placement = new Placement(x, y, facing);
        }
    }

    public void TurnLeft()
    {
        Placement = Placement with
        {
            Facing = Placement.Facing switch
            {
                Direction.North => Direction.West,
                Direction.East => Direction.North,
                Direction.South => Direction.East,
                Direction.West => Direction.South,
                _ => Placement.Facing
            }
        };
    }

    public void TurnRight()
    {
        Placement = Placement with
        {
            Facing = Placement.Facing switch
            {
                Direction.North => Direction.East,
                Direction.East => Direction.South,
                Direction.South => Direction.West,
                Direction.West => Direction.North,
                _ => Placement.Facing
            }
        };
    }

    /// <summary>
    /// Move the robot by one table position in the direction it is facing.
    /// </summary>
    /// <returns>True if the robot moved.</returns>
    public bool Move()
    {
        var (x, y, facing) = Placement;

        if (Table.IsFacingBoundary(x, y, facing))
        {
            return false;
        }

        var newPosition = facing switch
        {
            Direction.North => Placement with { Y = y + 1 },
            Direction.East => Placement with { X = x + 1 },
            Direction.South => Placement with { Y = y - 1 },
            Direction.West => Placement with { X = x - 1 },
            _ => Placement  
        };

        if (newPosition.Equals(Placement))
        {
            return false;
        }

        Placement = Placement with { X = newPosition.X, Y = newPosition.Y };
        return true;
    }

    public override string ToString() => $"{Placement.X},{Placement.Y},{Placement.Facing.ToString().ToUpperInvariant()}";
}