namespace Exercicios.Ex03;



public static class ProgramaEx03
{
    public static void Programa()
    {

        List<Animal> pets = new List<Animal>();
        AnimalFactory animalFactory = new AnimalFactory();

        for(int i = 0; i < 5; i++)
        {
            Console.WriteLine($"\nPet {i+1}: ");
            
            Console.Write($"Informe o tipo do pet: ");
            string tipo = Console.ReadLine();
        
            Console.Write($"Informe o nome do pet: ");
            string nome = Console.ReadLine();

            pets.Add(animalFactory.GetAnimal(nome, tipo));
        }

        animalFactory.FactoryStatistics();
    }
}


public class AnimalFactory
{
    public int GatoCount { get; private set; } = 0;
    public int CachorroCount { get; private set; } = 0;
    public int PeixeCount { get; private set; } = 0;

    public void FactoryStatistics()
    {
        Console.WriteLine("Quantidade de gatos informados: " + GatoCount);
        Console.WriteLine("Quantidade de cachorros informados: " + CachorroCount);
        Console.WriteLine("Quantidade de peixes informados: " + PeixeCount);
    }

    public Animal GetAnimal(string nome, string tipo)
    {
        
        switch(tipo.ToLower())
        {
            case "gato":
                GatoCount++;
                return new Gato(nome); 
            case "cachorro":
                CachorroCount++;
                return new Cachorro(nome);
            default:
                PeixeCount++;
                return new Peixe(nome);              
        }
    }
}

public abstract class Animal
{
    public string Nome { get; set; }
    public abstract string Tipo { get; }
    public abstract string EmitirSom();
    
    public Animal(string nome)
    {
        this.Nome = nome;
    }

}

public class Gato : Animal
{
    public Gato(string nome) : base(nome) {}

    public override string Tipo => "Gato";
    public override string EmitirSom() => "Miau";
}

public class Cachorro : Animal
{
    public Cachorro(string nome) : base(nome) {}

    public override string Tipo => "Cachorro";
    public override string EmitirSom() => "Au au";
}

public class Peixe : Animal
{
    public Peixe(string nome) : base(nome) {}

    public override string Tipo => "Peixe";
    public override string EmitirSom() => "Glub Glub";
}