using ToyRobot.App;

namespace ToyRobot.UnitTests;

public class InputParserTests
{
    [Fact]
    public void Parse_PlaceCommand_ReturnsCorrectAction()
    {
        // Arrange
        var input = "PLACE 1,2,NORTH";

        // Act
        var result = InputParser.Parse(input);

        // Assert
        Assert.Equal(Command.Place, result.Command);
        Assert.Equal(1, result.Placement.X);
        Assert.Equal(2, result.Placement.Y);
        Assert.Equal(Direction.North, result.Placement.Facing);
    }

    [Theory]
    [InlineData("PLACE 0,0,NORTH", 0, 0, Direction.North)]
    [InlineData("PLACE 4,4,SOUTH", 4, 4, Direction.South)]
    [InlineData("PLACE 2,3,EAST", 2, 3, Direction.East)]
    [InlineData("PLACE 1,1,WEST", 1, 1, Direction.West)]
    public void Parse_PlaceCommandWithVariousPositions_ReturnsCorrectAction(
        string input, int expectedX, int expectedY, Direction expectedDirection)
    {
        // Act
        var result = InputParser.Parse(input);

        // Assert
        Assert.Equal(Command.Place, result.Command);
        Assert.Equal(expectedX, result.Placement.X);
        Assert.Equal(expectedY, result.Placement.Y);
        Assert.Equal(expectedDirection, result.Placement.Facing);
    }

    [Fact]
    public void Parse_PlaceCommandLowercase_ReturnsCorrectAction()
    {
        // Arrange
        var input = "place 3,2,east";

        // Act
        var result = InputParser.Parse(input);

        // Assert
        Assert.Equal(Command.Place, result.Command);
        Assert.Equal(3, result.Placement.X);
        Assert.Equal(2, result.Placement.Y);
        Assert.Equal(Direction.East, result.Placement.Facing);
    }

    [Fact]
    public void Parse_MoveCommand_ReturnsCorrectAction()
    {
        // Arrange
        var input = "MOVE ";

        // Act
        var result = InputParser.Parse(input);

        // Assert
        Assert.Equal(Command.Move, result.Command);
        Assert.Equal(Placement.Empty, result.Placement);
    }

    [Fact]
    public void Parse_LeftCommand_ReturnsCorrectAction()
    {
        // Arrange
        var input = "LEFT ";

        // Act
        var result = InputParser.Parse(input);

        // Assert
        Assert.Equal(Command.Left, result.Command);
        Assert.Equal(Placement.Empty, result.Placement);
    }

    [Fact]
    public void Parse_RightCommand_ReturnsCorrectAction()
    {
        // Arrange
        var input = "RIGHT ";

        // Act
        var result = InputParser.Parse(input);

        // Assert
        Assert.Equal(Command.Right, result.Command);
        Assert.Equal(Placement.Empty, result.Placement);
    }

    [Fact]
    public void Parse_ReportCommand_ReturnsCorrectAction()
    {
        // Arrange
        var input = "REPORT ";

        // Act
        var result = InputParser.Parse(input);

        // Assert
        Assert.Equal(Command.Report, result.Command);
        Assert.Equal(Placement.Empty, result.Placement);
    }

    [Theory]
    [InlineData("move ")]
    [InlineData("left ")]
    [InlineData("right ")]
    [InlineData("report ")]
    public void Parse_CommandsLowercase_ReturnsCorrectCommand(string input)
    {
        // Act
        var result = InputParser.Parse(input);

        // Assert
        var expectedCommand = input.Trim().ToUpperInvariant() switch
        {
            "MOVE" => Command.Move,
            "LEFT" => Command.Left,
            "RIGHT" => Command.Right,
            "REPORT" => Command.Report,
            _ => Command.Invalid
        };
        Assert.Equal(expectedCommand, result.Command);
    }

    [Fact]
    public void Parse_InvalidCommand_ReturnsInvalidAction()
    {
        // Arrange
        var input = "INVALID ";

        // Act
        var result = InputParser.Parse(input);

        // Assert
        Assert.Equal(Command.Invalid, result.Command);
    }

    [Theory]
    [InlineData("UNKNOWN ")]
    [InlineData("JUMP ")]
    [InlineData("ROTATE ")]
    public void Parse_UnknownCommands_ReturnsInvalidAction(string input)
    {
        // Act
        var result = InputParser.Parse(input);

        // Assert
        Assert.Equal(Command.Invalid, result.Command);
    }

    [Theory]
    [InlineData("MOVE ")]
    [InlineData("LEFT ")]
    [InlineData("RIGHT ")]
    public void Parse_CommandsWithTrailingSpace_ReturnsCorrectAction(string input)
    {
        // Act
        var result = InputParser.Parse(input);

        // Assert
        var expectedCommand = input.Trim().ToUpperInvariant() switch
        {
            "MOVE" => Command.Move,
            "LEFT" => Command.Left,
            "RIGHT" => Command.Right,
            _ => Command.Invalid
        };
        Assert.Equal(expectedCommand, result.Command);
        Assert.Equal(Placement.Empty, result.Placement);
    }
}
