using ToyRobot.Console;

TextReader input = Console.In;

if (Console.IsInputRedirected)
{
    input = Console.In;
}

var controller = new Controller(input, Console.Out);
controller.Run();
