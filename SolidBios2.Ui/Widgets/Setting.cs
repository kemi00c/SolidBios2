namespace SolidBios2.Ui.Widgets;

public class Setting : ISetting
{
    public string Label { get; set; }
    public int Top { get; set; }
    public int Left { get; set; }
    public string HelpText { get; set; }
    public bool Active { get; set; }

    public Setting(string label, string helpText, int top, int left)
    {
        Label = label;
        HelpText = helpText;
        Top = top;
        Left = left;
        Active = false;
    }
    
    public virtual void Display()
    {
        Console.CursorLeft = Left;
        Console.CursorTop = Top;
        if (Active)
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }
        Console.Write(Label);
    }
    
    public void DisplayHelp()
    {
        var helpTitle = "   Item Specific Help   ";

        var x = Console.WindowWidth - helpTitle.Length;
        var y = 6;
        
        var helpLines = HelpText.Split('\n');

        foreach (var helpLine in helpLines)
        {
            var trimHelpLine = helpLine.Trim();
            Console.CursorLeft = x;
            Console.CursorTop = y;
            Console.Write(trimHelpLine);
            Console.Write(new string(' ', helpLine.Length - trimHelpLine.Length));
            y++;
        }

        for (var i = 0; i < Console.WindowHeight - y - 9; i++)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;
            Console.Write(new string(' ', helpTitle.Length - 1));
        }
    }
}