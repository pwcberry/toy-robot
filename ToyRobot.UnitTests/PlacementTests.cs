using ToyRobot.Console;

namespace ToyRobot.UnitTests;

public class PlacementTests
{
    [Fact]
    public void Constructor_StoresProperties()
    {
        // Arrange & Act
        var placement = new Placement(2, 3, Direction.East);

        // Assert
        Assert.Equal(2, placement.X);
        Assert.Equal(3, placement.Y);
        Assert.Equal(Direction.East, placement.Facing);
    }

    [Theory]
    [InlineData(0, 0, Direction.North)]
    [InlineData(4, 4, Direction.South)]
    [InlineData(1, 2, Direction.East)]
    [InlineData(3, 1, Direction.West)]
    public void Constructor_WithVariousValues(int x, int y, Direction facing)
    {
        // Arrange & Act
        var placement = new Placement(x, y, facing);

        // Assert
        Assert.Equal(x, placement.X);
        Assert.Equal(y, placement.Y);
        Assert.Equal(facing, placement.Facing);
    }

    [Fact]
    public void Nowhere_HasCorrectValues()
    {
        // Arrange & Act
        var empty = Placement.Nowhere;

        // Assert
        Assert.Equal(-1, empty.X);
        Assert.Equal(-1, empty.Y);
        Assert.Equal(Direction.North, empty.Facing);
    }

    [Fact]
    public void Equals_WithSameValues_ReturnsTrue()
    {
        // Arrange
        var left = new Placement(2, 3, Direction.West);
        var right = new Placement(2, 3, Direction.West);

        // Act & Assert
        Assert.True(left.Equals(right));
        Assert.True(left == right);
        Assert.False(left != right);
        Assert.Equal(left.GetHashCode(), right.GetHashCode());
    }

    [Fact]
    public void Equals_WithDifferentValues_ReturnsFalse()
    {
        // Arrange
        var left = new Placement(2, 3, Direction.West);
        var right = new Placement(3, 3, Direction.West);

        // Act & Assert
        Assert.False(left.Equals(right));
        Assert.False(left == right);
        Assert.True(left != right);
    }


    [Fact]
    public void Parse_WithValidStringInput_ReturnsPlacement()
    {
        // Arrange
        var input = "1,2,NORTH";

        // Act
        var placement = Placement.Parse(input);

        // Assert
        Assert.Equal(1, placement.X);
        Assert.Equal(2, placement.Y);
        Assert.Equal(Direction.North, placement.Facing);
    }

    [Theory]
    [InlineData("0,0,NORTH")]
    [InlineData("4,4,SOUTH")]
    [InlineData("2,3,EAST")]
    [InlineData("1,1,WEST")]
    public void Parse_WithVariousValidStrings(string input)
    {
        // Arrange & Act
        var placement = Placement.Parse(input);

        // Assert
        Assert.NotEqual(-1, placement.X);
    }

    [Fact]
    public void Parse_WithInvalidDirection_ReturnsNowhere()
    {
        // Arrange
        var input = "1,2,INVALID";

        // Act
        var placement = Placement.Parse(input);

        // Assert
        Assert.Equal(Placement.Nowhere, placement);
    }

    [Fact]
    public void Parse_WithInvalidXCoordinate_ReturnsNowhere()
    {
        // Arrange
        var input = "abc,2,NORTH";

        // Act
        var placement = Placement.Parse(input);

        // Assert
        Assert.Equal(Placement.Nowhere, placement);
    }

    [Fact]
    public void Parse_WithInvalidYCoordinate_ReturnsNowhere()
    {
        // Arrange
        var input = "1,xyz,NORTH";

        // Act
        var placement = Placement.Parse(input);

        // Assert
        Assert.Equal(Placement.Nowhere, placement);
    }

    [Fact]
    public void Parse_WithTooFewParts_ReturnsNowhere()
    {
        // Arrange
        var input = "1,NORTH";

        // Act
        var placement = Placement.Parse(input);

        // Assert
        Assert.Equal(Placement.Nowhere, placement);
    }

    [Fact]
    public void Parse_WithTooManyParts_ReturnsNowhere()
    {
        // Arrange
        var input = "1,2,NORTH,EXTRA";

        // Act
        var placement = Placement.Parse(input);

        // Assert
        Assert.Equal(Placement.Nowhere, placement);
    }

    [Fact]
    public void Parse_WithArrayInput_ReturnsPlacement()
    {
        // Arrange
        var input = new[] { "1", "2", "NORTH" };

        // Act
        var placement = Placement.Parse(input);

        // Assert
        Assert.Equal(1, placement.X);
        Assert.Equal(2, placement.Y);
        Assert.Equal(Direction.North, placement.Facing);
    }

    [Theory]
    [InlineData("0", "0", "NORTH")]
    [InlineData("4", "4", "SOUTH")]
    [InlineData("2", "3", "EAST")]
    [InlineData("1", "1", "WEST")]
    public void Parse_WithArrayInputVariousValues(string x, string y, string direction)
    {
        // Arrange
        var input = new[] { x, y, direction };

        // Act
        var placement = Placement.Parse(input);

        // Assert
        Assert.NotEqual(-1, placement.X);
    }

    [Fact]
    public void Parse_WithArrayInputLowercaseDirection_ReturnsPlacement()
    {
        // Arrange
        var input = new[] { "1", "2", "south" };

        // Act
        var placement = Placement.Parse(input);

        // Assert
        Assert.Equal(1, placement.X);
        Assert.Equal(2, placement.Y);
        Assert.Equal(Direction.South, placement.Facing);
    }

    [Fact]
    public void Parse_WithArrayInputInvalidDirection_ReturnsNowhere()
    {
        // Arrange
        var input = new[] { "1", "2", "INVALID" };

        // Act
        var placement = Placement.Parse(input);

        // Assert
        Assert.Equal(Placement.Nowhere, placement);
    }

    [Fact]
    public void Parse_WithArrayInputInvalidXCoordinate_ReturnsNowhere()
    {
        // Arrange
        var input = new[] { "notanumber", "2", "NORTH" };

        // Act
        var placement = Placement.Parse(input);

        // Assert
        Assert.Equal(Placement.Nowhere, placement);
    }

    [Fact]
    public void Parse_WithArrayInputInvalidYCoordinate_ReturnsNowhere()
    {
        // Arrange
        var input = new[] { "1", "notanumber", "NORTH" };

        // Act
        var placement = Placement.Parse(input);

        // Assert
        Assert.Equal(Placement.Nowhere, placement);
    }

    [Fact]
    public void Parse_WithArrayInputTooFewElements_ReturnsNowhere()
    {
        // Arrange
        var input = new[] { "1", "NORTH" };

        // Act
        var placement = Placement.Parse(input);

        // Assert
        Assert.Equal(Placement.Nowhere, placement);
    }

    [Fact]
    public void Parse_WithArrayInputTooManyElements_ReturnsNowhere()
    {
        // Arrange
        var input = new[] { "1", "2", "NORTH", "EXTRA" };

        // Act
        var placement = Placement.Parse(input);

        // Assert
        Assert.Equal(Placement.Nowhere, placement);
    }

    [Fact]
    public void Parse_WithNegativeCoordinates_ReturnsPlacement()
    {
        // Arrange
        var input = "-1,-2,WEST";

        // Act
        var placement = Placement.Parse(input);

        // Assert
        Assert.Equal(-1, placement.X);
        Assert.Equal(-2, placement.Y);
        Assert.Equal(Direction.West, placement.Facing);
    }

    [Fact]
    public void Parse_WithLargeCoordinates_ReturnsPlacement()
    {
        // Arrange
        var input = "1000,99999,EAST";

        // Act
        var placement = Placement.Parse(input);

        // Assert
        Assert.Equal(1000, placement.X);
        Assert.Equal(99999, placement.Y);
        Assert.Equal(Direction.East, placement.Facing);
    }
}

