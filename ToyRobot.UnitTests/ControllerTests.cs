using ToyRobot.Console;

namespace ToyRobot.UnitTests;

public class ControllerTests
{
    [Fact]
    public void Run_With_Example_1_Input_ReturnsCorrectReport()
    {
        // Arrange
        using var reader = new StringReader(ExampleFixture1);
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
        using var reader = new StringReader(ExampleFixture2);
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
        using var reader = new StringReader(ExampleFixture3);
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

        // Act
        controller.Run();

        // Assert
        var output = writer.ToString();
        Assert.Contains("Invalid Action: Invalid Placement", output);
        Assert.Contains("0,0,NORTH", output);
    }

    [Fact]
    public void Run_IgnoresCommandsBeforeFirstPlace()
    {
        // Arrange
        using var reader = new StringReader(IgnoreBeforePlaceFixture);
        using var writer = new StringWriter();
        var controller = new Controller(reader, writer);

        // Act
        controller.Run();

        // Assert
        Assert.Equal("0,0,NORTH" + Environment.NewLine, writer.ToString());
    }

    [Fact]
    public void Run_StillProcessesCommandsAfterFirstPlace()
    {
        // Arrange
        using var reader = new StringReader(ProcessAfterPlaceFixture);
        using var writer = new StringWriter();
        var controller = new Controller(reader, writer);

        // Act
        controller.Run();

        // Assert
        Assert.Equal("2,1,EAST" + Environment.NewLine, writer.ToString());
    }

    private static readonly string ExampleFixture1 = """
        PLACE 0,0,NORTH
        MOVE 
        REPORT 
        """;

    private static readonly string Report1 = "0,1,NORTH";

    private static readonly string ExampleFixture2 = """
        PLACE 0,0,NORTH
        LEFT 
        REPORT 
        """;

    private static readonly string Report2 = "0,0,WEST";

    private static readonly string ExampleFixture3 = """
        PLACE 1,2,EAST
        MOVE 
        MOVE 
        LEFT 
        MOVE 
        REPORT 
        """;

    private static readonly string Report3 = "3,3,NORTH";

    private static readonly string IgnoreBeforePlaceFixture = """
        MOVE 
        LEFT 
        RIGHT 
        REPORT 
        PLACE 0,0,NORTH
        REPORT 
        """;

    private static readonly string ProcessAfterPlaceFixture = """
        JUMP 
        REPORT 
        PLACE 1,1,EAST
        MOVE 
        REPORT 
        """;
}
