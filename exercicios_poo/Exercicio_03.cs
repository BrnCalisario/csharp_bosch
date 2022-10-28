namespace Exercicios.Ex03;



public static class ProgramaEx03
{
    public static void Programa()
    {
        List<Animal> pets = new List<Animal>();

        for(int i = 0; i < 5; i++)
        {
            Console.WriteLine($"\nPet {i+1}: ");
            
            Console.Write($"Informe o tipo do pet: ");
            string tipo = Console.ReadLine();
        
            Console.Write($"Informe o nome do pet: ");
            string nome = Console.ReadLine();


        }
    }
}


public class AnimalFactory
{
    public Animal GetAnimal(string nome, string tipo)
    {
        switch(tipo.ToLower())
        {
            case "gato":
                return new Gato(nome); 
            case "cachorro":
                return new Cachorro(nome);
            case "peixe":
                return new Peixe(nome);
            default:
                throw new InvalidDataException();
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