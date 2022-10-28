namespace Exercicios.Ex02;

public class Quadrilatero
{
    public float Base { get; set; }
    public float Altura { get; set; }
    public float Area { get; set; }
    public string Tipo { get; private set; }

    public Quadrilatero(float baseQ, float altura)
    {
        this.Base = baseQ;
        this.Altura = altura;

        this.Area = baseQ * altura;
        this.Tipo = baseQ == altura ? "Quadrado" : "Retângulo";
    }

    public string GetPropriedades()
    {
        string props = "";
        props += $"Tipo: {this.Tipo}\n";
        props += $"Base: {this.Base}\n";
        props += $"Altura: {this.Altura}\n";
        props += $"Área: {this.Area}\n";

        return props;
    }
}

public static class ProgramaEx02
{
    public static void Programa()
    {
        // Novo quadrado
        Quadrilatero quad = new Quadrilatero(20, 20);

        // Novo retângulo
        Quadrilatero ret = new Quadrilatero(15, 25);

        Console.WriteLine(quad.GetPropriedades());
        Console.WriteLine(ret.GetPropriedades());
    }
}