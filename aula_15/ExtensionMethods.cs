public static class ExtensionMethods
{
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

    public static IEnumerable<string[]> mySplit(this IEnumerable<string> coll)
    {
        foreach (var el in coll)
        {
            yield return el.Split(';');
        }
    }

    public static IEnumerable<string> GetCollumn(this IEnumerable<string[]> coll, int index)
    {
        var it = coll.GetEnumerator();

        while(it.MoveNext())
        {
            yield return it.Current.ToList().ElementAt(index);
        }   
    }

    public static string[] ColltoArray(this IEnumerable<string[]> coll)
    {
        if (coll.Count() == 1)
        {
            var it = coll.GetEnumerator();
            it.MoveNext();
            string[] arr = it.Current;
            return arr;
        }
        throw new Exception();
    }

    public static void WriteCSV(this string[] coll, string path)
    {
        var stream = new StreamWriter(path, true);
    
        stream.WriteLine(string.Join(';', coll));

        stream.Close();
    }

    public static void Read(this IEnumerable<string> csv)
    {
        var it = csv.GetEnumerator();
        it.MoveNext();
        var header = it.Current.Replace("\"", "").Split(';');
        var classIndex = header.ToList().IndexOf("CLASSI_FIN");
        header.WriteCSV("COVID_21.csv");
        while(it.MoveNext())
        {
            var item = it.Current.Split(";");

            if(item[classIndex] == "5") { 
                item.WriteCSV("COVID_21.csv"); 
            } 
        }
    }



    public static IEnumerable<CasoCovid> ReadCovid(this IEnumerable<string> csv)
    {
        var it = csv.GetEnumerator();
        it.MoveNext();
        var header = it.Current.Replace("\"", "").Split(';').ToList();

        var evoIndex = header.IndexOf("EVOLUCAO");
        var covIndex = header.IndexOf("VACINA_COV");
        var idadeIndex = header.IndexOf("NU_IDADE_N");
        var classIndex = header.ToList().IndexOf("CLASSI_FIN");



        while(it.MoveNext())
        {
            var item = it.Current.Split(";");

            CasoCovid caso = new CasoCovid(item[evoIndex], Convert.ToInt16(item[idadeIndex].Replace("\"", "")));

            Console.WriteLine(item[classIndex]);
            if (item[covIndex] == "1")
            {
                string[] vals = new string[] { "1_COV", "2_COV", "REF"};
                string[] fabs  = new string[] { "COV_1", "COV_2", "COVREF"};
                for(int i = 0; i < 3; i++)
                {  
                    var data = item[(header.IndexOf($"DOSE_{vals[i]}"))];
                    var lote = item[(header.IndexOf($"LOTE_{vals[i]}"))];
                    var fab = item[(header.IndexOf($"FAB_{fabs[i]}"))];

                    if (data != "\"\""  || lote != "\"\""  || fab != "\"\"")
                    {      
                        caso.addVacina(data, lote, fab, i);
                    }
                }   
            }

            yield return caso;

        }
    }
}