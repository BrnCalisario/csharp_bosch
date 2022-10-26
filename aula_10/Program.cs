using System.Text.RegularExpressions;

public class Program
{


    static void Main(string[] args)
    {
        while (true)
        {
            Game g = new Game();

            bool shopState = false;


            while (true)
            {
                Console.Clear();
                if (!shopState)
                {
                    g.DrawMain();
                    if (Console.ReadKey().Key == ConsoleKey.D0)
                        g.Salgados++;
                    else if (Console.ReadKey().Key == ConsoleKey.D1)
                        shopState = true;
                } 
                else
                {
                    g.DrawShop();
                }


            }
        }
    }


}


public class Game
{
    public int Salgados { get; set; }
    Machine Rolo = new Rolo();

    public void DrawMain()
    {
        string title = Visual.Label("Padoca Clicker");
        string money = Visual.Label($"Salgados: {this.Salgados}");
        string packTitle = Visual.sideBySide(title, money);

        string click = Visual.Label("Digite 0 para fazer um salgado");
        string shop = Visual.Label("Digite 1 para entrar na loja");
        string pack = Visual.sideBySide(click, shop);
        Console.WriteLine(packTitle);
        Console.WriteLine(pack);
    }

    public void DrawShop()
    {
        Console.WriteLine(Visual.DoubleLabel(new string[] {Rolo.Name, Rolo.Description}));
    }
}

public class Visual
{
    public static string Label(string labelText)
    {
        string label = $"║ {labelText} ║";
        string pipe = "";
        while (pipe.Length < (label.Length - 2))
        {
            pipe += "═";
        }

        string top = "╔" + pipe + "╗";
        string bottom = "╚" + pipe + "╝";

        return top + "\n" + label + "\n" + bottom;
    }

    public static string DoubleLabel(string[] labelTexts)
    {

        int maiorLength = 0;
        for(int i = 0; i < labelTexts.Length; i++)
        {
            if (labelTexts[0].Length > maiorLength)
            {
                maiorLength = labelTexts[0].Length;
            }
        }

        string pipe = "";
        while (pipe.Length < (maiorLength - 2))
        {
            pipe += "═";
        }
        string top = "╔" + pipe + "╗";
        string bottom = "╚" + pipe + "╝";

        return "";
    }

    public static string sideBySide(string label1, string label2)
    {
        string subL1 = label1.Substring(0, label1.IndexOf("\n") + 1);
        string subL2 = label2.Substring(0, label2.IndexOf("\n") + 1);
        string line1 = subL1.Replace("\n", "") + subL2.Replace("\n", "");

        label1 = label1.Replace(subL1, "");
        label2 = label2.Replace(subL2, "");

        subL1 = label1.Substring(0, label1.IndexOf("\n") + 1);
        subL2 = label2.Substring(0, label2.IndexOf("\n") + 1);
        string line2 = subL1.Replace("\n", "") + subL2.Replace("\n", "");

        label1 = label1.Replace(subL1, "");
        label2 = label2.Replace(subL2, "");

        string line3 = label1 + label2;

        return line1 + "\n" + line2 + "\n" + line3;
    }

    public static void Print(object obj)
    {
        Console.Write(obj);
    }

    public static void Println(object obj)
    {
        Console.WriteLine(obj);
    }
}
