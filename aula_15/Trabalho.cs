string path = "data/INFLUD21-24-10-2022.csv";


var table = path.Open().Read();
var mortos = table.Where(p => p.EvolucaoCaso == "Óbito").Count();



Console.WriteLine(mortos);

public delegate void Print(object x);

public class CasoCovid 
{
    public string EvolucaoCaso { get; set; }
    public string DataFinal { get; set; }

    public CasoCovid(string evolucao)
    {
        this.EvolucaoCaso = getEvo(evolucao);
    }

    private string getEvo(string evolucao)
    {
        switch(evolucao)
        {
            case "1":
                return "Cura";
            case "2":
                return "Óbito";
            case "3":
                return "Óbito por outras causas";
            case "9":
                return "Ignorado";
            default:
                return "Indefinido";
        }
    }
}

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


    public static IEnumerable<CasoCovid> Read(this IEnumerable<string> csv)
    {
        var it = csv.GetEnumerator();
        it.MoveNext();
        var header = it.Current.Replace("\"", "").Split(';');

        var classIndex = header.ToList().IndexOf("CLASSI_OUT");
        var evoIndex = header.ToList().IndexOf("EVOLUCAO");

        while(it.MoveNext())
        {
            var item = it.Current.Split(";");

            if(item.ElementAt(classIndex + 1) == "5")
            {
                yield return new CasoCovid(item.ElementAt(evoIndex + 1));
            } 
        }
    }
}





// int influ = 0;
// int outroVirus = 0;
// int outroAgente = 0;
// int naoEspecificado = 0;
// int covid = 0;
// foreach(var i in table)
// {
//     switch(i)
//     {
//         case "1":
//             influ++;
//             break;
//         case "2":
//             outroVirus++;
//             break;
//         case "3":
//             outroAgente++;
//             break;
//         case "4":
//             naoEspecificado++;
//             break;
//         case "5":
//             covid++;
//             break;
//         default:
//             if(!i.Contains("") && i.Length > 1)
//             {
//                 Console.WriteLine(i);
//             }
//             break;
//     }
// }