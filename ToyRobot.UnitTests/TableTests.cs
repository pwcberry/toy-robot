using ToyRobot.App;

namespace ToyRobot.UnitTests;

public class TableTests
{
    [Fact]
    public void DefaultInstance_Has_5x5_Dimensions()
    {
        // Arrange & Act
        var table = new Table();
        
        // Assert
        Assert.Equal(5, table.Dimensions.Width);
        Assert.Equal(5, table.Dimensions.Height);
    }
    
    [Fact]
    public void IsFacingBoundary_North_ReturnsTrue()
    {
        // Arrange
        var table = new Table();
        
        // Act
        var result = table.IsFacingBoundary(0, 4, Direction.North);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void IsFacingBoundary_East_ReturnsTrue()
    {
        // Arrange
        var table = new Table();
        
        // Act
        var result = table.IsFacingBoundary(4, 0, Direction.East);
        
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsFacingBoundary_South_ReturnsTrue()
    {
        // Arrange
        var table = new Table();
        
        // Act
        var result = table.IsFacingBoundary(2, 0, Direction.South);
        
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsFacingBoundary_West_ReturnsTrue()
    {
        // Arrange
        var table = new Table();
        
        // Act
        var result = table.IsFacingBoundary(0, 2, Direction.West);
        
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
        var table = new Table();
        
        // Act
        var result = table.IsFacingBoundary(2, 2, facing);
        
        // Assert
        Assert.False(result);
    }
    
    [Theory]
    [InlineData(0,0)]
    [InlineData(0,3)]
    [InlineData(2,2)]
    [InlineData(3,1)]
    [InlineData(4,4)]
    public void IsOutOfBounds_ReturnsFalse(int x, int y)
    {
        // Range
        var table = new Table();
        
        // Act
        var result = table.IsOutOfBounds(x, y);
        
        // Assert
        Assert.False(result);
    }
    
    [Theory]
    [InlineData(-1, 2)]
    [InlineData(-1, -2)]
    [InlineData(2, -1)]
    [InlineData(5, 2)]
    [InlineData(2, 5)]
    [InlineData(6, 6)]
    public void IsOutOfBounds_ReturnsTrue(int x, int y)
    {
        // Arrange
        var table = new Table();

        // Act
        var result = table.IsOutOfBounds(x, y);

        // Assert
        Assert.True(result);
    }
}
