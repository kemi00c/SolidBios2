using SolidBios2.Ui.Misc;

namespace SolidBios2.Ui.Screens;

public class ScreenWithHelp : BaseScreen
{

    private const string HelpTitle = "   Item Specific Help   ";
    
    protected bool WindowDrawn { get; private set; }

    public ScreenWithHelp()
    {
        WindowDrawn = false;
    }

    protected void ResetWindow()
    {
        WindowDrawn = false;
    }

    protected override void Draw()
    {
        base.Draw();
        if (!WindowDrawn)
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 2;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;

            var mainWindowWidth = Console.WindowWidth - HelpTitle.Length - 2;

            Console.Write(Box.TlCorner);
            Console.Write(new string(Box.Horizontal, mainWindowWidth - 1));
            Console.Write(Box.TTee);
            Console.Write(new string(Box.Horizontal, HelpTitle.Length));
            Console.Write(Box.TrCorner);

            Console.Write(Box.Vertical);
            Console.Write(new string(' ', mainWindowWidth - 1));
            Console.Write(Box.Vertical + HelpTitle + Box.Vertical);

            Console.Write(Box.Vertical);
            Console.Write(new string(' ', mainWindowWidth - 1));
            Console.Write(Box.LTee);
            Console.Write(new string(Box.Horizontal, HelpTitle.Length));
            Console.Write(Box.RTee);

            for (var i = 0; i < Console.WindowHeight - 8; i++)
            {
                Console.Write(Box.Vertical);
                Console.Write(new string(' ', mainWindowWidth - 1));
                Console.Write(Box.Vertical);
                Console.Write(new string(' ', HelpTitle.Length));
                Console.Write(Box.Vertical);
            }
            
            Console.Write(Box.BlCorner);
            Console.Write(new string(Box.Horizontal, mainWindowWidth - 1));
            Console.Write(Box.BTee);
            Console.Write(new string(Box.Horizontal, HelpTitle.Length));
            Console.Write(Box.BrCorner);
            
            WindowDrawn = true;
        }




    }
}