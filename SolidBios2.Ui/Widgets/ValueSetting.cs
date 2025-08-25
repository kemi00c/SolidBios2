namespace SolidBios2.Ui.Widgets;

public class ValueSetting : Setting, IValueSetting
{
    public string Value { get; set; }
    public int ValueMargin { get; set; }

    public ValueSetting(string label, string value, string helpText, int top, int left, int valueMargin) : base(label,
        helpText, top, left)
    {
        Label = label;
        Top = top;
        Left = left;
        Value = value;
        ValueMargin = valueMargin;
        HelpText = helpText;
        Active = false;
    }

    public override void Display()
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        if (Active)
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }

        Console.SetCursorPosition(Left, Top);
        Console.Write(Label);
        Console.CursorLeft = ValueMargin;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write('[');
        if (Active)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        Console.Write(Value);
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.Write(']');
    }
}