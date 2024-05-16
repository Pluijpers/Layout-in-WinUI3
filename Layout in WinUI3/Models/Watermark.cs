namespace Layout_in_WinUI3.Models;

public class Watermark
{
    public string Text { get; set; } = string.Empty;
    public int TextLength => Text.Length;
}