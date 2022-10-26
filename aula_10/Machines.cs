public abstract class Machine
{
    public int Price { get; protected set; }
    public string? Name { get; protected set;}
    public string? Description { get; protected set; }
    public int Power { get; protected set; }

    public string displayInfo() => $"Preço: R${this.Price} | Poder: {this.Power}/click";

    public virtual int UpdateClick() => this.Power;

}

public class Rolo : Machine
{
    public Rolo()
    {
        this.Name = "Rolo de Massa";
        this.Description = "O bom e velho Rolo para prepara a massa dos seus salgados";
        this.Power = 5;
        this.Price = 10;
    }

}

public class Batedeira : Machine
{
    public Batedeira()
    {
        this.Name = "Batedeira";
        this.Description = "Uma batedeira para melhorar a qualidade da sua massa";
        this.Power = 25;
        this.Price = 15;
    }
}

public class Chapa : Machine
{
    public Chapa()
    {
        this.Name = "Chapa";
        this.Description = "Uma superfície muito quente perfeita para fritar seus salgados";
        this.Power = 25;
        this.Price = 25;
    }
}

public class Cafeteira : Machine
{
    public Cafeteira()
    {
        this.Name = "Cafeitera";
        this.Description = "Um bom salgado precisa acompanhar um bom café";
        this.Power = 25;
        this.Price = 250;
    }
}

public class Forno : Machine
{
    public Forno()
    {
        this.Name = "Forno Elétrico";
        this.Description = "Um incrível forno para assar tudo que há de bom!";
        this.Power = 50;
        this.Price = 500;
    }
}