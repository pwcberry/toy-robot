using ToyRobot.Console;

namespace ToyRobot.UnitTests;

public class ControllerTests
{
    [Fact]
    public void Run_With_Example_1_Input_ReturnsCorrectReport()
    {
        // Arrange
        using var reader = new StringReader(Example1);
        using var writer = new StringWriter();

        var controller = new Controller(reader, writer);

        // Act
        controller.Run();
        var output = writer.ToString();
        var expected = Report1 + Environment.NewLine;

        // Assert
        Assert.Equal(expected, output);
    }

    [Fact]
    public void Run_With_Example_2_Input_ReturnsCorrectReport()
    {
        // Arrange
        using var reader = new StringReader(Example2);
        using var writer = new StringWriter();
        var controller = new Controller(reader, writer);

        // Act
        controller.Run();
        var output = writer.ToString();
        var expected = Report2 + Environment.NewLine;

        // Assert
        Assert.Equal(expected, output);
    }

    [Fact]
    public void Run_With_Example_3_Input_ReturnsCorrectReport()
    {
        // Arrange
        using var reader = new StringReader(Example3);
        using var writer = new StringWriter();
        var controller = new Controller(reader, writer);

        // Act
        controller.Run();
        var output = writer.ToString();
        var expected = Report3 + Environment.NewLine;

        // Assert
        Assert.Equal(expected, output);
    }

    [Fact]
    public void Run_With_QuitCommand_ExitsAsExpected()
    {
        // Arrange
        var input = """
            PLACE 2,2,SOUTH
            MOVE
            MOVE
            QUIT
            """;
        using var reader = new StringReader(input);
        using var writer = new StringWriter();
        var controller = new Controller(reader, writer);

        // Act
        controller.Run();
        var output = writer.ToString();
        var expected = "GOODBYE" + Environment.NewLine;

        // Assert
        Assert.Equal(expected, output);
    }


    [Fact]
    public void Run_With_ReportAndQuitCommand_ExitsAsExpected()
    {
        // Arrange
        var input = """
            PLACE 2,2,SOUTH
            MOVE
            REPORT
            QUIT
            """;
        using var reader = new StringReader(input);
        using var writer = new StringWriter();
        var controller = new Controller(reader, writer);

        // Act
        controller.Run();
        var output = writer.ToString();
        var expected = "2,1,SOUTH" + Environment.NewLine + "GOODBYE" + Environment.NewLine;

        // Assert
        Assert.Equal(expected, output);
    }

    [Fact]
    public void Run_With_Invalid_Command_DoesNotThrow()
    {
        // Arrange
        var input = """
            PLACE 0,0,NORTH
            JUMP
            REPORT
            """;
        using var reader = new StringReader(input);
        using var writer = new StringWriter();
        var controller = new Controller(reader, writer);

        // Act & Assert
        var exception = Record.Exception(() => controller.Run());

        Assert.Null(exception);
    }

    private static readonly string Example1 = """
        PLACE 0,0,NORTH
        MOVE
        REPORT
        """;

    private static readonly string Report1 = "0,1,NORTH";

    private static readonly string Example2 = """
        PLACE 0,0,NORTH
        LEFT
        REPORT
        """;

    private static readonly string Report2 = "0,0,WEST";

    private static readonly string Example3 = """
        PLACE 1,2,EAST
        MOVE
        MOVE
        LEFT
        MOVE
        REPORT
        """;

    private static readonly string Report3 = "3,3,NORTH";
}
