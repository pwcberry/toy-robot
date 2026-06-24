using ToyRobot.Console;

namespace ToyRobot.UnitTests;

public class RobotTests
{
    [Fact]
    public void Constructor_WithTable_InitializesNowherePlacement()
    {
        // Arrange
        var table = new Table();

        // Act
        var robot = new Robot(table);

        // Assert
        Assert.Same(table, robot.Table);
        Assert.Equal(Placement.Nowhere, robot.Placement);
    }

    [Theory]
    [InlineData(-1, -2)]
    [InlineData(-1, 2)]
    [InlineData(4, -2)]
    [InlineData(5, 2)]
    [InlineData(2, 6)]
    [InlineData(6, 5)]
    public void Place_OutOfBounds_DoesNotChangePlacement(int x, int y)
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table);

        // Act
        robot.Place(x, y, Direction.North);

        // Assert
        Assert.Equal(Placement.Nowhere, robot.Placement);
    }

    [Theory]
    [InlineData(0, 0, Direction.East)]
    [InlineData(1, 2, Direction.West)]
    [InlineData(2, 4, Direction.South)]
    [InlineData(4, 2, Direction.North)]
    public void Place_InBounds_UpdatesPlacement(int x, int y, Direction facing)
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table);

        // Act
        robot.Place(x, y, facing);

        // Assert
        Assert.Equal(new Placement(x, y, facing), robot.Placement);
    }

    [Fact]
    public void TurnLeft_FromNorth_FacesWest()
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table, new Placement(1, 1, Direction.North));

        // Act
        robot.TurnLeft();

        // Assert
        Assert.Equal(Direction.West, robot.Placement.Facing);
    }

    [Fact]
    public void TurnLeft_FromWest_FacesSouth()
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table, new Placement(1, 1, Direction.West));

        // Act
        robot.TurnLeft();

        // Assert
        Assert.Equal(Direction.South, robot.Placement.Facing);
    }

    [Fact]
    public void TurnLeft_FromSouth_FacesEast()
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table, new Placement(1, 1, Direction.South));

        // Act
        robot.TurnLeft();

        // Assert
        Assert.Equal(Direction.East, robot.Placement.Facing);
    }

    [Fact]
    public void TurnLeft_FromEast_FacesNorth()
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table, new Placement(1, 1, Direction.East));

        // Act
        robot.TurnLeft();

        // Assert
        Assert.Equal(Direction.North, robot.Placement.Facing);
    }

    [Fact]
    public void TurnRight_FromNorth_FacesEast()
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table, new Placement(1, 1, Direction.North));

        // Act
        robot.TurnRight();

        // Assert
        Assert.Equal(Direction.East, robot.Placement.Facing);
    }

    [Fact]
    public void TurnRight_FromEast_FacesSouth()
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table, new Placement(1, 1, Direction.East));

        // Act
        robot.TurnRight();

        // Assert
        Assert.Equal(Direction.South, robot.Placement.Facing);
    }

    [Fact]
    public void TurnRight_FromSouth_FacesWest()
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table, new Placement(1, 1, Direction.South));

        // Act
        robot.TurnRight();

        // Assert
        Assert.Equal(Direction.West, robot.Placement.Facing);
    }

    [Fact]
    public void TurnRight_FromWest_FacesNorth()
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table, new Placement(1, 1, Direction.West));

        // Act
        robot.TurnRight();

        // Assert
        Assert.Equal(Direction.North, robot.Placement.Facing);
    }

    [Theory]
    [InlineData(2, 0, Direction.North, 2, 1)]
    [InlineData(0, 2, Direction.East, 1, 2)]
    [InlineData(2, 4, Direction.South, 2, 3)]
    [InlineData(4, 2, Direction.West, 3, 2)]
    [InlineData(2, 2, Direction.North, 2, 3)]
    [InlineData(1, 1, Direction.West, 0, 1)]
    [InlineData(3, 3, Direction.East, 4, 3)]
    [InlineData(3, 2, Direction.South, 3, 1)]
    public void Move_AwayFromBoundary_IsSuccessful(int x, int y, Direction facing, int expectedX, int expectedY)
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table, new Placement(x, y, facing));

        // Act
        var result = robot.Move();

        // Assert
        Assert.True(result);
        Assert.Equal(new Placement(expectedX, expectedY, facing), robot.Placement);
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
        var robot = new Robot(table, new Placement(x, y, facing));

        // Act
        var result = robot.Move();

        // Assert
        Assert.False(result);
        Assert.Equal(new Placement(x, y, facing), robot.Placement);
    }

    [Fact]
    public void ToString_Returns_CurrentPlacement()
    {
        // Arrange
        var table = new Table();
        var robot = new Robot(table, new Placement(2, 3, Direction.West));

        // Act
        var result = robot.ToString();

        // Assert
        Assert.Equal("2,3,WEST", result);
    }
}