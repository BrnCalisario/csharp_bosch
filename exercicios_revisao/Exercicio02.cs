namespace Exercicios.Ex02;

public class Program
{
    public static void Programa()
    {
        long[] valores = {10, 6, 8};
        int[] pesos = {3, 3, 4};

        Console.WriteLine("Valores: " + valores.toString());
        Console.WriteLine("Média aritmética: " + valores.Aritmetica());
        Console.WriteLine("Média ponderada: " + valores.Ponderada(pesos) + " | Pesos: " + pesos.toString());
        Console.WriteLine("Média harmônica: " + valores.Harmonica());
    }
        
}

public static class Media
{
    public static double Aritmetica(this IEnumerable<long> coll) => coll.Sum() / coll.Count();
    
    public static double Ponderada(this IEnumerable<long> coll, IEnumerable<int> pesos)
    {
        if (coll.Count() != pesos.Count())
            throw new Exception("Pesos de nota não correspondem!");
        
        double soma = 0;
        for(int i = 0; i < coll.Count(); i++)
            soma += coll.ToArray()[i] * pesos.ToArray()[i];

        return soma / pesos.Sum();
    }

    public static double Harmonica(this IEnumerable<long> coll)
    {
        var mmc = coll.MMC();

        double soma = 0;
        for(int i = 0; i < coll.Count(); i++)
            soma += mmc / coll.ToArray()[i];
        return (coll.Count() * mmc) / soma;
    }

    public static string toString<T>(this IEnumerable<T> coll)
    {
        string str = "[ ";
        foreach(var item in coll)
            str += item + " ";
        return str + "]";
    }

    public static double MMC(this IEnumerable<long> coll)
    { 
        var arr = coll.ToArray();
        long aux = arr[0];

        for(int i = 1; i < coll.Count(); i++)
            aux = aux * (arr[i] / MDC(aux, arr[i]));

        return aux;
    }

    public static long MDC(long a, long b)
    {
        while(b != 0)
        {
            long r = a % b;
            a = b;
            b = r;
        }
        return a;
    }
}