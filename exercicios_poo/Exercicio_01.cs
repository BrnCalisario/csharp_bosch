namespace Exercicios.Ex01;

public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public void ExibirDados()
    {
        Console.WriteLine($"Nome: {this.Nome} Idade: {this.Idade} ");
    }

    public Pessoa()
    {

    }

    public Pessoa(string nome, int idade)
    {
        this.Nome = nome;
        this.Idade = idade;
    }
}

public static class ProgramaEx01
{
    public static void Programa()
    {

        List<Pessoa> pessoas = new List<Pessoa>();
        
        int count = 0;
        while (count < 3)
        {
            Console.WriteLine($"Pessoa {count + 1}");
            Console.Write("Informe o nome: ");
            string nome = Console.ReadLine();
            
            Console.Write("Informe a idade: ");
            int idade = Convert.ToInt16(Console.ReadLine());

            Pessoa p = new Pessoa(nome, idade); 
            pessoas.Add(p);
            count++;
        }
        
        Pessoa maiorIdade = new Pessoa();
        maiorIdade.Idade = 0;
        foreach(var p in pessoas)
        {
            if (p.Idade > maiorIdade.Idade)
            {
                maiorIdade = p;
            }
        }

        Console.WriteLine("Pessoa com mais idade: ");
        maiorIdade.ExibirDados();
    }
}