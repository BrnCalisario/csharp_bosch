// See https://aka.ms/new-console-template for more information

// var coll = "LAB_PR_COV.csv"
//     .Open()
//     .Skip(1)
//     .Take(1000)
//     .ToList();


// foreach(var i in coll)
// {
//     Console.WriteLine(i);
// }


List<int> list = new List<int>();
int[] arr = list.ToArray();


public static class MyExtensionMethods
{

    public static IEnumerable<T> Skip<T>(this IEnumerable<T> coll, int N)
    {
        var it = coll.GetEnumerator();
        for(int i = 0; i < N && it.MoveNext(); i++);
        
        while(it.MoveNext())
            yield return it.Current;
    }

    public static IEnumerable<T> Take<T>(this IEnumerable<T> coll, int N)
    {
        var it = coll.GetEnumerator();
        for(int i = 0; i < N && it.MoveNext(); i++)
            yield return it.Current;
    }

    public static int Count<T>(this IEnumerable<T> coll)
    {
        int count = 0;

        var it= coll.GetEnumerator();

        while(it.MoveNext())
            count++;
        
        return count;
    }

    public static IEnumerable<T> Append<T>(this IEnumerable<T> coll, T item)
    {
        var it = coll.GetEnumerator();
        while(it.MoveNext())
            yield return it.Current;

        yield return item;
    }

    public static IEnumerable<T> Prepend<T>(this IEnumerable<T> coll, T item)
    {
        var it = coll.GetEnumerator();
        yield return item;
        
        while(it.MoveNext())
            yield return it.Current;

    }

    public static T FirstOrDefault<T>(this IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();
        return it.MoveNext() ? it.Current : default(T);
    }

    public static T LastOrDefault<T>(this IEnumerable<T> coll)
    {
        int count = 0;

        var it = coll.GetEnumerator();
        while(it.MoveNext())
            count++;

        return count == 0 ? default(T) : it.Current;
    }

    public static T[] ToArray<T>(this IEnumerable<T> coll)
    {
        T[] array = new T[coll.Count()];

        var it = coll.GetEnumerator();
        
        for (int i = 0; i < coll.Count() && it.MoveNext(); i++)
            array[i] = it.Current;
        
        return array;
    }

    public static List<T> ToList<T>(this IEnumerable<T> coll)
    {
        List<T> list = new List<T>();

        var it = coll.GetEnumerator();
        while (it.MoveNext())
            list.Add(it.Current);

        return list;
    }


    public static IEnumerable<string> Open(this string file)
    {
        var stream = new StreamReader(file);

        while (!stream.EndOfStream)
        {
            var line = stream.ReadLine();
            yield return line;
        }

        stream.Close();
    }
}

// var coll = infinity();

// foreach(var x in coll)
//     Console.WriteLine(x);


// IEnumerable<long> infinity()
// {
//     for(long i = 0; true; i++)
//         yield return i;
// }