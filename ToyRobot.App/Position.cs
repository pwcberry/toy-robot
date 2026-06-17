namespace ToyRobot.App;

public readonly struct Position(int x, int y)
{
    public int X => x;
    public int Y => y;
}