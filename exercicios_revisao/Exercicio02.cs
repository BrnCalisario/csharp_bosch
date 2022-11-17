namespace Exercicios.Ex02;

public class Program
{
    public static void Programa()
    {
        double[] valores = {10, 6, 8};
        double[] pesos = {3, 3, 4};

        Console.WriteLine("Valores: " + valores.toString());
        Console.WriteLine("Média aritmética: " + valores.Aritmetica());
        Console.WriteLine("Média ponderada: " + valores.Ponderada(pesos) + " | Pesos: " + pesos.toString());
        Console.WriteLine("Média harmônica: " + valores.Harmonica());
    }
        
}

public static class Media
{
    public static double Aritmetica(this IEnumerable<double> coll) => coll.Sum() / coll.Count();
    
    public static double Ponderada(this IEnumerable<double> coll, IEnumerable<double> pesos)
    {
        if (coll.Count() != pesos.Count())
            throw new Exception("Pesos de nota não correspondem!");
        
        double soma = 0;
        for(int i = 0; i < coll.Count(); i++)
            soma += coll.ToArray()[i] * pesos.ToArray()[i];

        return soma / pesos.Sum();
    }

    public static double Harmonica(this IEnumerable<double> coll)
    {
        double soma = 0;
        var it = coll.GetEnumerator();

        while(it.MoveNext())
            soma += 1 / it.Current;
    
        return coll.Count() / soma;

    }

    public static string toString<T>(this IEnumerable<T> coll)
    {
        string str = "[ ";
        foreach(var item in coll)
            str += item + " ";
        return str + "]";
    }

}