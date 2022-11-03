// See https://aka.ms/new-console-template for more information

// var coll = "LAB_PR_COV.csv"
//     .Open()
//     .Skip(1)
//     .Take(1000)
//     .ToList();

// var df = "LAB_PR_COV.csv".Open().Find("CORONAVAC").SumColumn("CORONAVAC");

string[] keywords = {"CORONA", "BUTANTAN", "ASTRAZENECA", "FIOCRUZ", "PFIZER", "SINOVAC", "OXFORD","NAO"};
"LAB_PR_COV.csv".Open().Unify(keywords).Write("RESULTADO.csv");


// string[,] keywordsPrecise = { 
//     {"CORONAVAC", "CORONO", "COR"}, 
//     {"BUTANTAN", "BUT", "IB"}, 
//     {"ASTRAZENECA", "ASTRAZENICA", "AZTRA", "ASTRA"} };
// // string[,]

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

    public static IEnumerable<string> Find(this IEnumerable<string> coll, string keyword)
    {
        var it = coll.GetEnumerator();
        while(it.MoveNext())
            if (it.Current.Contains(keyword))
                yield return it.Current;
    }

    public static string SumColumn(this IEnumerable<string> coll, string keyword)
    {
        int sum = 0;
        var it = coll.GetEnumerator();
        while(it.MoveNext())
        {
            int i = 1; 
            int result;
            string splited = "";
            do
            {
                splited = it.Current.Split(',')[i];  
                i++;
            } while(!int.TryParse(splited, out result));
            
            sum += result;
        }

        return $"{keyword},{sum}";
    }

    public static List<string> Unify(this IEnumerable<string> coll, string[] keywords)
    {
        List<string> KeywordGroups = new List<string>();
        KeywordGroups.Add(coll.SumColumn("TOTAL"));
        for(int i = 0; i < keywords.Length; i++)
        {
            KeywordGroups.Add(coll.Find(keywords[i]).SumColumn(keywords[i]));
        }

        return KeywordGroups;
    }

    public static void Write(this IEnumerable<string> coll, string path)
    {
        var stream =  new StreamWriter(path);

        foreach(var item in coll)
            stream.WriteLine(item);

        stream.Close();
    }


    //TODO
    //SEPARAR AS VACINAS POR GRUPOS

}
