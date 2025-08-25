namespace SolidBios2.Ui.Widgets;

public class DataLabel : IValueWidget, IValueMarginWidget
{
    public string Label { get; set; }
    public int Top { get; set; }
    public int Left { get; set; }
    public string Value { get; set; }
    public int ValueMargin { get; set; }
    
    public void Display()
    {
        Console.CursorLeft = Left;
        Console.CursorTop = Top;
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write(Label);
        Console.CursorLeft = ValueMargin;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write(Value);
    }

    public DataLabel(string label, string value, int top, int left, int valueMargin)
    {
        Label = label;
        Value = value;
        Top = top;
        Left = left;
        ValueMargin = valueMargin;
    }
}