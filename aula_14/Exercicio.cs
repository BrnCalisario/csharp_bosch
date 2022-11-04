// MeuDelegate func = delegate(string s)
// {
//     Console.WriteLine("Função Anonima diz " + s);
// };

// void ChameNVezes(MeuDelegate f, int n)
// {
//     for(int i = 0; i < n; i++)
//         f("To dentro do loopkkkk");
// }

// MeuDelegate func2 = s => Console.WriteLine("Lambda diz: " + s);
// ChameNVezes(func, 3);


Transformador<int> aoQuadrado = n => n*n;
Transformador<int> aoCubo = n => n*n*n;

Delegate print = s => Console.WriteLine(s);

int[] arr = new int[] { 2, 3, 4};


List<Pessoa> pessoas = new List<Pessoa>()
{
    new Pessoa()
    {
        Nome = "Edjalma",
        Idade = 400
    },
    new Pessoa()
    {
        Nome = "Trevis",
        Idade = 23
    },
    new Pessoa() { 
        Nome = "Voces", 
        Idade = 16
    }
};


var arr2 = arr.Select(n => n * n);
var idades = pessoas.Select(p => p.Idade);
var edjalma = pessoas.Where(p => p.Idade > 17);

// foreach(var i  in edjalma)
//     print(i.Nome);

var maiorIdade = pessoas.myMax(p => p.Idade);
Console.WriteLine(maiorIdade);

var mediaIdade = pessoas.Average(p => p.Idade);
Console.WriteLine((int)(mediaIdade));




public static class MyExtensionMethods
{
    static IEnumerable<R> Select<T, R>(
        this IEnumerable<T> entrada, 
        Func<T, R> func)
    {
        var it = entrada.GetEnumerator();
        while (it.MoveNext())
            yield return func(it.Current);
    }

    public static IEnumerable<T> Where<T>(
        this IEnumerable<T> coll,
        Func<T, bool> condition
    )
    {
        var it = coll.GetEnumerator();
        while(it.MoveNext())
            if(condition(it.Current))
                yield return it.Current;
    }

    public static int myMax<T>(
        this IEnumerable<T> coll,
        Func<T, int> func
    )
    {
        int max = 0;
        int idade = 0;
        var it = coll.GetEnumerator();
        while(it.MoveNext())
            idade = func(it.Current);
            if (idade > max)
                max = idade;
        return max;
    }

    //Media dos valores
    public static double Average<T>(
        this IEnumerable<T> coll,
        Func<T, double> func
    )
    {
        double average = 0.0;
        var it = coll.GetEnumerator();
        while(it.MoveNext())
            average += func(it.Current);
        return average / coll.Count();
    }
}

public delegate void Delegate(object x);
public delegate T Transformador<T>(T n);

public class Pessoa
{
    public string Nome { get; set;}
    public int Idade { get; set; }


}