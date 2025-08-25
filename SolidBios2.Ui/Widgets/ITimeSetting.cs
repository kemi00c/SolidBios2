namespace SolidBios2.Ui.Widgets;

public interface ITimeSetting : ISetting, IValueMarginWidget
{
    int Hour { get; set; }
    int Minute { get; set; }
    int Second { get; set; }
    char Separator { get; set; }

    void Toggle();
}