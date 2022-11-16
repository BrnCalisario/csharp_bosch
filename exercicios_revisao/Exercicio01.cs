namespace Exercicios.Ex01;

public class Program
{
    public static void Programa()
    {
        List<char[]> orderedList = new List<char[]>();

        while (true)
        {
            Console.WriteLine("Insira uma lista de caracters para ordenar ou -1 para parar: ");
            var answer = Console.ReadLine();

            if (answer == "-1")
                break;


            char[] characters = answer.Replace(" ", "").ToArray();
            Array.Sort(characters);
            Console.WriteLine(characters);

            orderedList.Add(characters);
        }

        foreach(var arr in orderedList)
            Console.WriteLine(arr);

    }
}