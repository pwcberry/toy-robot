using ToyRobot.App;

namespace ToyRobot.UnitTests;

public class GridTests
{
    [Fact]
    public void DefaultInstance_Is_5_by_5_Matrix()
    {
        // Arrange & Act
        var grid = new Grid();
        
        // Assert
        Assert.Equal(5, grid.Dimensions.Width);
        Assert.Equal(5, grid.Dimensions.Height);
    }
    
    [Fact]
    public void IsFacingBoundary_North_ReturnsTrue()
    {
        // Arrange
        var grid = new Grid();
        
        // Act
        var result = grid.IsFacingBoundary(0, 4, Direction.North);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void IsFacingBoundary_East_ReturnsTrue()
    {
        // Arrange
        var grid = new Grid();
        
        // Act
        var result = grid.IsFacingBoundary(4, 0, Direction.East);
        
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsFacingBoundary_South_ReturnsTrue()
    {
        // Arrange
        var grid = new Grid();
        
        // Act
        var result = grid.IsFacingBoundary(2, 0, Direction.South);
        
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsFacingBoundary_West_ReturnsTrue()
    {
        // Arrange
        var grid = new Grid();
        
        // Act
        var result = grid.IsFacingBoundary(0, 2, Direction.West);
        
        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData(Direction.North)]
    [InlineData(Direction.East)]
    [InlineData(Direction.South)]
    [InlineData(Direction.West)]
    public void IsFacingBoundary_FromCenter_ReturnsFalse(Direction facing)
    {
        // Arrange
        var grid = new Grid();
        
        // Act
        var result = grid.IsFacingBoundary(2, 2, facing);
        
        // Assert
        Assert.False(result);
    }
}
