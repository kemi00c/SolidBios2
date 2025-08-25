namespace SolidBios2.Ui.Widgets;

public class TimeSetting : Setting, ITimeSetting
{
    public int ValueMargin { get; set; }
    public int Hour { get; set; }
    public int Minute { get; set; }
    public int Second { get; set; }
    public char Separator { get; set; }

    private int _toggleValue;
    
    public TimeSetting(string label, int hour, int minute, int second, char separator, string helpText, int top, int left, int valueMargin) : base(label, helpText, top, left)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Separator = separator;
        ValueMargin = valueMargin;
        _toggleValue = 0;
    }

    public override void Display()
    {
        Console.SetCursorPosition(Left, Top);
        if (Active)
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }
        Console.Write(Label);

        Console.CursorLeft = ValueMargin;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write('[');
        if (Active)
        {
            if (_toggleValue == 0)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.Write(Hour.ToString("D2"));
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(Separator);
            
            if (_toggleValue == 1)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.Write(Minute.ToString("D2"));
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(Separator);
            
            if (_toggleValue == 2)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.Write(Second.ToString("D2"));
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        else
        {
            Console.Write($"{Hour:D2}{Separator}{Minute:D2}{Separator}{Second:D2}");
        }
        Console.Write(']');

    }

    public void Toggle()
    {
        if (_toggleValue < 2)
        {
            _toggleValue++;
        }
        else
        {
            _toggleValue = 0;
        }
    }
}