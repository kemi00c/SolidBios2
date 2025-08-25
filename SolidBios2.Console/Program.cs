using BiosData;
using SolidBios2.Ui;
using SolidBios2.Ui.Screens;

namespace SolidBios2.Console;

class Program
{
    static void Main(string[] args)
    {
        var cmos = new CmosFactory().Get();
        var escd = new EscdFactory().Get();

        if (cmos != null)
        {
            if (!File.Exists("cmos.json"))
            {
                cmos.SetDefault();
            }
            else
            {
                cmos.Load();
            }
        }

        if (escd != null)
        {
            if (!File.Exists("escd.json"))
            {
                escd.SetDefault();
            }
            else
            {
                escd.Load();
            }
        }


        var screen = new InfoScreen();
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