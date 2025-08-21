namespace SolidBios2.Ui;

public class BaseScreen : IScreen
{
    private const string Title = "Aptio Setup Utility";
    private const string Tabs = "  Info    Config    Security    Boot    Exit";

    protected virtual void Draw()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.Clear();
        
        var titleLeft = (Console.WindowWidth / 2) -  (Title.Length / 2);
        Console.CursorTop = 0;
        Console.CursorLeft = titleLeft;
        Console.Write(Title);

        Console.CursorLeft = 0;
        Console.CursorTop = 1;
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Write(Tabs);
        Console.Write(new string(' ', Console.WindowWidth - Tabs.Length));

        Console.CursorLeft = 0;
        Console.CursorTop = Console.WindowHeight - 2;

        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.ForegroundColor = ConsoleColor.White;
        
        Console.Write("   F1   ");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("Help");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("   \u2191\u2193   ");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("Select Item");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("   +/-   ");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("Change Values");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("       F9   ");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("Setup Defaults");

        Console.CursorLeft = 0;
        Console.CursorTop = Console.WindowHeight - 1;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("   ESC  ");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("Exit");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("   \u2190\u2192   ");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("Select Menu");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("   Enter ");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("Select \u25ba Sub-Menu");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("   F10  ");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("Save and Exit");

    }
    
    public virtual void Run()
    {
        Draw();
        Console.ReadKey();
    }
}