// string pathC = "data/INFLUD21-24-10-2022.csv";

// var cabecalho = pathC.Open().First().Replace("\"", "").Split(';');
// var indexVac = cabecalho.ToList().IndexOf("VACINA_COV");
// Console.WriteLine(indexVac);

// var table = pathC.Open().Read();


// foreach(var i in table)
// {
//     Console.WriteLine(i.EvolucaoCaso);
// }

var path = "COVID_21.csv";

var table = path.Open().ReadCovid();
Console.WriteLine(table.Count());

public delegate void Print(object x);


public enum TipoDose
{
    Indefinido = -1,
    PrimeiraDose = 0,
    SegundaDose = 1,
    DoseReforco = 2
}

public class CasoCovid 
{



    public string EvolucaoCaso { get; set; }
    public string DataFinal { get; set; }
    public List<Vacina> Vacinas { get; set; }

    public void addVacina(string data=null, string lote=null, string fabricante=null, int tipoDose = -1)
    {
        var vacina = new Vacina();

        vacina.Data = (data != null ? data : "N/A");
        vacina.Lote = (lote != null ? lote : "N/A");
        vacina.Fabricante = (fabricante != null ? fabricante : "N/A");
        vacina.TipoDose = ( tipoDose > -1 ? (TipoDose) tipoDose : TipoDose.Indefinido) ;

        Vacinas.Add(vacina);
    }

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

public struct Vacina
{
    public TipoDose TipoDose { get; set; }
    public string Data { get; set; }
    public string Lote { get; set; }
    public string Fabricante { get; set; }
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

    public static void WriteCSV(this string[] coll, string path)
    {
        var stream = new StreamWriter(path, true);
    
        stream.WriteLine(string.Join(';', coll));

        stream.Close();
    }

    public static IEnumerable<CasoCovid> Read(this IEnumerable<string> csv)
    {
        var it = csv.GetEnumerator();
        it.MoveNext();
        var header = it.Current.Replace("\"", "").Split(';');

        var classIndex = header.ToList().IndexOf("CLASSI_FIN");
        var evoIndex = header.ToList().IndexOf("EVOLUCAO");

        header.WriteCSV("COVID_21.csv");

        while(it.MoveNext())
        {
            var item = it.Current.Split(";");

            if(item.ElementAt(classIndex + 1) == "5")
            {
                item.WriteCSV("COVID_21.csv");
                yield return new CasoCovid(item.ElementAt(evoIndex + 1));
            } 
        }
    }

    public static IEnumerable<CasoCovid> ReadCovid(this IEnumerable<string> csv)
    {
        var it = csv.GetEnumerator();
        it.MoveNext();
        var header = it.Current.Replace("\"", "").Split(';').ToList();

        var evoIndex = header.IndexOf("EVOLUCAO") + 1;
        var covIndex = header.IndexOf("VACINA_COV") + 1;

        while(it.MoveNext())
        {
            var item = it.Current.Split(";");

            CasoCovid caso = new CasoCovid(item.ElementAt(evoIndex));


            if (item.ElementAt(covIndex) == "1")
            {
                string[] vals = new string[] { "1_COV", "2_COV", "REF"};
                string[] fabs  = new string[] { "COV_1", "COV_2", "COVREF"};
                for(int i = 0; i < 3; i++)
                {  
                    var data = item.ElementAt(header.IndexOf($"DOSE_{vals[i]}") + 1);
                    var lote = item.ElementAt(header.IndexOf($"LOTE_{vals[i]}") + 1);
                    var fab = item.ElementAt(header.IndexOf($"FAB_{fabs[i]}") + 1);

                    caso.addVacina(data, lote, fab, i);
                }   
                
              
            }

            yield return caso;

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