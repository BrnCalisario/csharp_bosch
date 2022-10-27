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
            bool depositoState = false;

            while (true)
            {
                Console.Clear();
                if (!shopState && !depositoState)
                {
                    g.DrawMain();
                    var click = Console.ReadKey().Key;

                    if (click == ConsoleKey.D0)
                        g.Click();

                    else if (click == ConsoleKey.D1)
                        shopState = true;
                    
                    else if (click == ConsoleKey.D2)
                        depositoState = true;
                } 
                else if (shopState)
                {
                    shopState = g.DrawShop();
                }
                else if (depositoState)
                {
                    depositoState = g.DrawWarehouse();
                }
                


            }
        }
    }


}


public class Game
{
    public int Salgados { get; set; }
    private int clickPower {  get;  set; } = 1;
    
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

    public void Click()
    {
        this.Salgados += clickPower;
    }

    public void DrawMain()
    {
        string title = Visual.Label("Padoca Clicker");
        string money = Visual.Label($"Salgados: {this.Salgados} | Salgados por clique: {this.clickPower}");
        string packTitle = Visual.sideBySide(title, money);

        string click = Visual.Label("Digite 0 para fazer um salgado");
        string shop = Visual.Label("Digite 1 para entrar na loja");
        string warehouse = Visual.Label("Digite 2 para entrar no depósito");
        string pack = Visual.sideBySide(click, shop);


        Console.WriteLine(packTitle);
        Console.WriteLine(pack);
        Console.WriteLine(warehouse);
    }

    public bool DrawShop()
    {
        Console.WriteLine(Visual.TitleLabel("CASAS BAHIA"));
        
        int count = 0;
        foreach(var maq in this.Machines)
        {   
            count++;
            string str = $"{maq.Name} | {maq.displayInfo()} - [{count}]";
            Console.WriteLine(Visual.DoubleLabel(new string[] {str, maq.Description}));
        }   
        Console.WriteLine(Visual.DoubleLabel(new string[] {$"Seu saldo: {this.Salgados}", "Digite o número da máquina que deseja comprar ou 0 para sair: "}));

        var option = Console.ReadKey().Key;

        switch(option)
        {
            case ConsoleKey.D0:
                return false;
            case ConsoleKey.D1:
                buyMachine(0);
                goto case ConsoleKey.U;
            case ConsoleKey.D2:
                buyMachine(1);
                goto case ConsoleKey.U;
            case ConsoleKey.D3:
                buyMachine(2);
                goto case ConsoleKey.U;
            case ConsoleKey.D4:
                buyMachine(3);
                goto case ConsoleKey.U;
            case ConsoleKey.D5:
                buyMachine(4);
                goto case ConsoleKey.U;
            case ConsoleKey.U:
                updateClickPower();
                break;
            default:
                break;
        }

        return true;
    }

    public bool DrawWarehouse()
    {
        Console.WriteLine(Visual.TitleLabel("DEPÓSITO"));

        foreach(var maq in this.Machines)
        {
            Console.WriteLine(Visual.DoubleLabel(new string[] {maq.Name, maq.displayQuant}));
        }

        Console.WriteLine(Visual.Label("Digite 0 para sair"));

        var option = Console.ReadKey().Key;
        return (option != ConsoleKey.D0);
    }

    private void buyMachine(int index)
    {
        if (this.Salgados >= Machines[index].Price)
        {
            Machines[index].Quantidade += 1;
            this.Salgados -= Machines[index].Price;
        }
        else
        {
            Console.WriteLine("\n" + Visual.Label($"Dinheiro Insuficiente para {Machines[index].Name}!"));
            Console.ReadKey();
        }
    }

    private void updateClickPower()
    {
        Console.WriteLine("Teste");
        int total = 1;
        foreach(var maq in this.Machines)
            total += maq.getPower();
        this.clickPower = total;
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
