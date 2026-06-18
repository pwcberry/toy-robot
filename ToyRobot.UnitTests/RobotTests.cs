using ToyRobot.Console;

namespace ToyRobot.UnitTests;

public class RobotTests
{
    [Fact]
    public void DefaultInstance_AtOrigin_FacingNorth()
    {
        // Arrange
        var table = new Table();

        // Act
        var robot = new Robot(table);

        // Assert
        Assert.Equal(0, robot.Position.X);
        Assert.Equal(0, robot.Position.Y);
        Assert.Equal(Direction.North, robot.Facing);
    }

    [Theory]
    [InlineData(-1, -2)]
    [InlineData(-1, 2)]
    [InlineData(4, -2)]
    [InlineData(5, 2)]
    [InlineData(2, 6)]
    [InlineData(6, 5)]
    public void Constructor_Throws_WhenOutOfBounds(int x, int y)
    {
        // Arrange
        var table = new Table();

        // Act
        Assert.Throws<OutOfBoundsException>(() => new Robot(table, new Position(x, y), Direction.North));
    }

    [Theory]
    [InlineData(0, 0, Direction.East)]
    [InlineData(1, 2, Direction.West)]
    [InlineData(2, 4, Direction.South)]
    [InlineData(4, 2, Direction.North)]
    public void Place_InBounds_DoesNotThrow(int x, int y, Direction facing)
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table);

        // Act
        robot.Place(x, y, facing);

        // Assert
        Assert.Equal(robot.Position.X, x);
        Assert.Equal(robot.Position.Y, y);
        Assert.Equal(robot.Facing, facing);
    }

    [Theory]
    [InlineData(-1, 0, Direction.East)]
    [InlineData(1, -2, Direction.West)]
    [InlineData(6, 4, Direction.South)]
    [InlineData(5, 6, Direction.North)]
    public void Place_OutOfBounds_Throws(int x, int y, Direction facing)
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table);

        // Act
        Assert.Throws<OutOfBoundsException>(() => robot.Place(x, y, facing));
    }

    [Fact]
    public void TurnLeft_FromNorth_FacesWest()
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table);

        // Act
        robot.TurnLeft();

        // Assert
        Assert.Equal(Direction.West, robot.Facing);
    }

    [Fact]
    public void TurnLeft_FromWest_FacesSouth()
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table, Position.Origin, Direction.West);

        // Act
        robot.TurnLeft();

        // Assert
        Assert.Equal(Direction.South, robot.Facing);
    }

    [Fact]
    public void TurnLeft_FromSouth_FacesEast()
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table, Position.Origin, Direction.South);

        // Act
        robot.TurnLeft();

        // Assert
        Assert.Equal(Direction.East, robot.Facing);
    }

    [Fact]
    public void TurnLeft_FromEast_FacesNorth()
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table, Position.Origin, Direction.East);

        // Act
        robot.TurnLeft();

        // Assert
        Assert.Equal(Direction.North, robot.Facing);
    }

    [Fact]
    public void TurnRight_FromNorth_FacesEast()
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table, Position.Origin, Direction.North);

        // Act
        robot.TurnRight();

        // Assert
        Assert.Equal(Direction.East, robot.Facing);
    }

    [Fact]
    public void TurnRight_FromEast_FacesSouth()
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table, Position.Origin, Direction.East);

        // Act
        robot.TurnRight();

        // Assert
        Assert.Equal(Direction.South, robot.Facing);
    }

    [Fact]
    public void TurnRight_FromSouth_FacesWest()
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table, Position.Origin, Direction.South);

        // Act
        robot.TurnRight();

        // Assert
        Assert.Equal(Direction.West, robot.Facing);
    }

    [Fact]
    public void TurnRight_FromWest_FacesNorth()
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table, Position.Origin, Direction.West);

        // Act
        robot.TurnRight();

        // Assert
        Assert.Equal(Direction.North, robot.Facing);
    }

    [Theory]
    [InlineData(2, 0, Direction.North)]
    [InlineData(0, 2, Direction.East)]
    [InlineData(2, 4, Direction.South)]
    [InlineData(4, 2, Direction.West)]
    [InlineData(2, 2, Direction.North)]
    [InlineData(1, 1, Direction.West)]
    [InlineData(3, 3, Direction.East)]
    [InlineData(3, 2, Direction.South)]
    public void Move_AwayFromBoundary_IsSuccessful(int x, int y, Direction facing)
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table, new Position(x, y), facing);

        // Act
        var result = robot.Move();

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData(0, 4, Direction.North)]
    [InlineData(4, 2, Direction.East)]
    [InlineData(4, 0, Direction.South)]
    [InlineData(0, 2, Direction.West)]
    public void Move_PastBoundary_IsFailure(int x, int y, Direction facing)
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table, new Position(x, y), facing);

        // Act
        var result = robot.Move();

        // Assert
        Assert.False(result);
    }
}