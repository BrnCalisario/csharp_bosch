namespace CopaClicker.Outputs;

public class Button
{
    public string Text { get; set; }
    public bool Selected { get; set; }
    public int Width { get; set; }
    public ConsoleColor BackgroundColor { get; set; }
    public ConsoleColor ForegroundColor { get; set; }


    //╚╝╔╗
    public void Draw()
    {
        if (Selected)
        {
            Console.BackgroundColor = this.ForegroundColor;
            Console.ForegroundColor = this.BackgroundColor;
        }
        Console.BackgroundColor = this.BackgroundColor;
        Console.ForegroundColor = this.ForegroundColor;

        string bt = "╔";
        for(int i = 0; i < Width; i++)
            bt += '-';
        bt += "╗\n";




        bt += "|";
        bt += this.Text;
        bt += "|\n";

        bt += "╚";
        for(int i = 0; i < Width; i++)
            bt += '-';
        bt += "╝\n";


    

        Console.WriteLine(bt);
        void DrawLine()
        {
            int spaces = (Width - text.Length)
        }
    }
}
