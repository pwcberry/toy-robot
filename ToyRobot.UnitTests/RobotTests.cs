using ToyRobot.App;

namespace ToyRobot.UnitTests;

public class RobotTests
{
    [Fact]
    public void DefaultInstance_AtOrigin_FacingNorth()
    {
        // Arrange
        var grid = new Grid();
        
        // Act
        var robot = new Robot(grid);
        
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
        var grid = new Grid();
        
        // Act
        Assert.Throws<ArgumentOutOfRangeException>(() => new Robot(grid, new Position(x, y), Direction.North));
    }
}