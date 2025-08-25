namespace SolidBios2.Ui.Widgets;

public interface IWidget
{
    string Label { get; set; }
    int Top { get; set; }
    int Left { get; set; }

    void Display();
}