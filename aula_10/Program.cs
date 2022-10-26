using System.Text.RegularExpressions;
using System;

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
                    var click = Console.ReadKey().Key;

                    if (click == ConsoleKey.D0)
                        g.Salgados++;
                    else if (click == ConsoleKey.D1)
                        shopState = true;
                } 
                else
                {
                    g.DrawShop();
                    if(Console.ReadKey().Key == ConsoleKey.D0)
                        shopState = false;
                }


            }
        }
    }


}


public class Game
{
    public int Salgados { get; set; }
    Machine Rolo = new Rolo();
    Machine Batedeira = new Batedeira();
    Machine Chapa = new Chapa();
    Machine Cafeteira = new Cafeteira();
    Machine Forno = new Forno();

    Machine[] Machines = new Machine[5];

    public Game()
    {
        Machines[0] = Rolo;
        Machines[1] = Batedeira;
        Machines[2] = Chapa;
        Machines[3] = Cafeteira;
        Machines[4] = Forno;
    }

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
        Console.WriteLine(Visual.TitleLabel("CASAS BAHIA"));
        
        int count = 0;
        foreach(var maq in this.Machines)
        {   
            count++;
            string str = $"{maq.Name} | {maq.displayInfo()} - [{count}]";
            Console.WriteLine(Visual.DoubleLabel(new string[] {str, maq.Description}));
        }   
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
            if (labelTexts[i].Length > maiorLength)
            {
                maiorLength =  $"║ {labelTexts[i]} ║".Length;
            }
        }

        string pipe = "";
        while (pipe.Length < (75 - 2))
        {
            pipe += "═";
        }
        string top = "╔" + pipe + "╗";
        string bottom = "╚" + pipe + "╝";


        string result = "";
        result += top + "\n";
        foreach(var i in labelTexts)
        {
            var aux = $"║ {i}";
            while(aux.Length < (75 - 1))
            {
                aux += " ";
            }
            aux += "║";
            result += aux + "\n";
        }
        result += bottom;

        return result;
    }

    public static string TitleLabel(string title)
    {
        string label = "║";
         
        while(label.Length < 32)
        {
            label += " ";
        }

        label += title;

        while(label.Length < 73)
        {
            label += " ";
        }
        
        label += " ║";

        string pipe = "";
        while (pipe.Length < (75 - 2))
        {
            pipe += "═";
        }

        string top = "╔" + pipe + "╗";
        string bottom = "╚" + pipe + "╝";

        return top + "\n" + label + "\n" + bottom;
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
