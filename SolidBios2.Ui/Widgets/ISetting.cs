namespace SolidBios2.Ui.Widgets;

public interface ISetting : IWidget
{
    string HelpText { get; set; }
    bool Active { get; set; }

    void DisplayHelp();
}