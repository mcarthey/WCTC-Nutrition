namespace Nutrition.Helpers;

public static class ConsoleHelper
{
    public static void WriteLineWithColor(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}