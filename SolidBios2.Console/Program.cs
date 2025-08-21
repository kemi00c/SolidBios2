using SolidBios2.Ui;

namespace SolidBios2.Console;

class Program
{
    static void Main(string[] args)
    {
        var screen = new BaseScreen();
        try
        {
            screen.Run();
        }
        finally
        {
            System.Console.ResetColor();
            System.Console.Clear();
        }
    }
}