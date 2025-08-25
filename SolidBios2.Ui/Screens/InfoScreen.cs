using BiosData;
using SolidBios2.Ui.Misc;
using SolidBios2.Ui.Widgets;

namespace SolidBios2.Ui.Screens;

public class InfoScreen : BaseScreen
{
    private const int ValueMargin = 24;
    public InfoScreen()
    {
        var cmos = new CmosFactory().Get();
        var escd = new EscdFactory().Get();

        if (cmos != null && escd != null)
        {
            Widgets =
            [
                new DataLabel("BIOS Version", escd.BiosVersion, 5, 4, ValueMargin),
                new DataLabel("EC Version", escd.EcVersion, 6, 4, ValueMargin),
                new DataLabel("Serial Number", escd.Serial, 7, 4, ValueMargin),
                new DataLabel("UUID", escd.Uuid, 8, 4, ValueMargin),

                new DataLabel("CPU", escd.Cpu, 10, 4, ValueMargin),
                new DataLabel("Memory", escd.Ram.ToString(), 11, 4, ValueMargin),
                new DataLabel("Secure Boot", cmos.SecureBoot, 12, 4, ValueMargin)
            ];
        }
    }
    protected override void Draw()
    {
        base.Draw();
        Console.CursorLeft = 1;
        Console.CursorTop = 1;
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.Write(" Info  ");
        
        Console.CursorLeft = 0;
        Console.CursorTop = 2;
        Console.ForegroundColor = ConsoleColor.Black;
        
        Console.Write(Box.TlCorner);
        Console.Write(new string(Box.Horizontal[0], Console.WindowWidth - 2));
        Console.Write(Box.TrCorner);

        for (var i = 0; i < Console.WindowHeight - 6; i++)
        {
            Console.Write(Box.Vertical);
            Console.Write(new string(' ', Console.WindowWidth - 2));
            Console.Write(Box.Vertical);
        }
        
        Console.Write(Box.BlCorner);
        Console.Write(new string(Box.Horizontal[0], Console.WindowWidth - 2));
        Console.Write(Box.BrCorner);

        if (Widgets != null)
        {
            foreach (var widget in Widgets)
            {
                widget.Display();
            }
        }
    }
}