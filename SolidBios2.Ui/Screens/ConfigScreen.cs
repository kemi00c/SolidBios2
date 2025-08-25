using BiosData;
using SolidBios2.Ui.Widgets;

namespace SolidBios2.Ui.Screens;

public class ConfigScreen : ScreenWithHelp
{
    private const int ValueMargin = 35;
    private Cmos? _cmos;
    public ConfigScreen()
    {
        var timeHelpText = """
                           Hour: Valid range is
                           from 0 to 23.
                           Minute: Valid range is
                           from 0 to 59.
                           Second: Valid range is
                           from 0 to 59.'
                           Increase / Reduce:
                           F6 / F5
                           """;

        var dateHelpText = """
                           Month: Valid range is
                           from 1 to 12.
                           Day: Valid range is
                           from 1 to 31.
                           Year: Valid range is
                           from 2000 to 2099.
                           Increase / Reduce:
                           F6 / F5
                           """;

        var wlanHelpText = """
                           Enable or disable
                           wireless LAN device.
                           <Enabled>
                           All wireless LAN
                           devices are enabled.
                           <Disabled>
                           All wireless LAN
                           devices are disabled.
                           """;

        var powerBeepHelpText = """
                                Enable or disable
                                beep alarm for
                                external power
                                supply changes.
                                <Enabled>
                                The Power Beep is
                                enabled.
                                <Disabled>
                                The Power Beep is
                                disabled.
                                """;

        var hwVmHelpText = """
                              When enabled, a VM
                              software can utilize
                              the additional hardware
                              capabilities provided
                              by Virtual Technology.
                              <Enabled> Virtual
                              Technology is enabled.
                              <Disabled> Virtual
                              Technology is disabled.
                              """;

        var perfModeHelpText = """
                               Select different
                               thermal control method.
                               <Performance>
                               Best performance.
                               <Quiet>
                               Best balance
                               performance and
                               acoustic noise.
                               """;

        _cmos = new CmosFactory().Get();
        
        var now = DateTime.Now;
        if (_cmos != null)
        {
            Widgets =
            [
                new TimeSetting("System Time:", now.Hour, now.Minute, now.Second, ':', timeHelpText, 4, 4, ValueMargin),
                new TimeSetting("System Date:", now.Month, now.Day, now.Year, '/', dateHelpText, 5, 4, ValueMargin),
                
                new ValueSetting("Wireless LAN:", _cmos.Wlan, wlanHelpText, 7, 4, ValueMargin),
                new ValueSetting("Power Beep:", _cmos.PowerBeep, powerBeepHelpText, 8, 4, ValueMargin),
                new ValueSetting("HW-Assisted Virtualization", _cmos.HwVm, hwVmHelpText, 9, 4, ValueMargin),
                new ValueSetting("Performance Mode:", _cmos.PerformanceMode, perfModeHelpText, 10, 4, ValueMargin),
            ];
        }

        if (Widgets != null)
        {
            ((ISetting)Widgets[0]).Active = true;
        }
    }
    protected override void Draw()
    {
        base.Draw();
        Console.SetCursorPosition(9, 1);
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.Write(" Config  ");

        if (Widgets != null)
        {
            foreach (var widget in Widgets)
            {
                widget.Display();
            }

            ((ISetting)Widgets.FirstOrDefault(w => ((ISetting)w).Active)!)?.DisplayHelp();
        }
    }
}