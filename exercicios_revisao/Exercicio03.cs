namespace Exercicios.Ex03;

public class Program
{
    public static void Programa()
    {
        int[,] arr = new int[5, 25];

        arr.PopulateRandom();
        arr.PrintArr();

        arr.blockOdds();
        arr.PrintArr();
    }        
}


public static class Methods
{
    public static void PopulateRandom(this int[,] coll)
    {
        var rnd = new Random();
        for(int i = 0; i < coll.GetLength(0); i++)
            for(int j = 0; j < coll.GetLength(1); j++)
                coll[i,j] = rnd.Next(0, 10);
    }

    public static void PrintArr(this int[,] coll)
    {
        for(int i = 0; i < coll.GetLength(0); i++)
        {
            for(int j = 0; j < coll.GetLength(1); j++)
                Console.Write(coll[i, j] + " ");
            Console.WriteLine("");
        }
        Console.WriteLine("");
    }

    public static void blockOdds(this int[,] coll)
    {
        for(int i = 0; i < coll.GetLength(0); i++)
            for(int j = 0; j < coll.GetLength(1); j++)
                if(coll[i,j] % 2 != 0)
                    coll[i,j] = 0;
    }

}
