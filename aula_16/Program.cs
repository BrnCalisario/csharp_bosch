using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var covidCases = read()
    .Where(c => c.IsCovid);


var letalGroup = covidCases
    .GroupBy(c => c.Doses)
    .Select(g => new {
        qtdDoses = g.Key,
        letalidade = g.Average(c => c.IsDead ? 1.0 : 0.0)
    });

var vacinados = covidCases
    .Where(c => c.Doses > 0);

var gruposVacinais = vacinados
    .Select(x =>
    {
        if (x.Vacina.Contains("BUT") || x.Vacina.Contains("NAVAC"))
            return new {
                vacina = "Coronavac(Buntantan)",
                caso = x
            };
        
        if (x.Vacina.Contains("TRAZE") || x.Vacina.Contains("SHIELD") || x.Vacina.Contains("OXF") || x.Vacina.Contains("FIO") || x.Vacina.Contains("CRUZ"))
            return new {
                vacina = "Astrazeneca e Fiocruz",
                caso = x
            };

        if (x.Vacina.Contains("PF") || x.Vacina.Contains("ZER") || x.Vacina.Contains("COMINARTY"))
            return new {
                vacina = "Cominarty (Pfizer)",
                caso = x
            };
        
        if (x.Vacina.Contains("JANS") || x.Vacina.Contains("JENS") || x.Vacina.Contains("SEN"))
            return new {
                vacina = "JANSSEN VACINE",
                caso = x
            };

        return new {
                vacina = "DESCONHECIDO",
                caso = x
            };
    })
    .GroupBy(x => x.vacina)
    .Select(g => new {
        nome = g.Key,
        qtdVacinas = g.Count()
    });







// var astrazeneca = gruposVacinais.Select(g => g.Where(g => g.vacina == 3));

// foreach(var i in astrazeneca)
// {
//     foreach(var l in i)
//     {
//         Console.WriteLine(l.caso.Vacina);
//     }
// }

// foreach (var lg in letalGroup)
// {
//     Console.WriteLine($"Doses: {lg.qtdDoses}, " + 
//         $"Letalidade: {lg.letalidade}");
// }

// foreach (var x in vacinados)
// {
//     Console.WriteLine(x.Vacina);
// }
// Console.WriteLine(query
//     .Average(c => c.IsDead ? 1.0 : 0.0));

// foreach (var x in query)
// {
//     Console.WriteLine(x);
// }

IEnumerable<CasoCovid> read()
{
    StreamReader reader = new StreamReader("data/INFLUD21.csv");

    var firstLine = reader.ReadLine();
    var header = firstLine.Split(';').ToList();
    
    int classfin = header.IndexOf("\"CLASSI_FIN\"");
    int evolucao = header.IndexOf("\"EVOLUCAO\"");

    int dose1 = header.IndexOf("\"DOSE_1_COV\"");
    int dose2 = header.IndexOf("\"DOSE_2_COV\"");
    int doseRef = header.IndexOf("\"DOSE_REF\"");

    int lab = header.IndexOf("\"LAB_PR_COV\"");

    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        var data = line.Split(';');

        var caso = new CasoCovid();
        caso.IsCovid = data[classfin] == "5";
        caso.IsDead = data[evolucao] == "2";

        int doses = 0;
        if (data[dose1] != "\"\"")
            doses++;
        if (data[dose2] != "\"\"")
            doses++;
        if (data[doseRef] != "\"\"")
            doses++;

        caso.Doses = doses;

        caso.Vacina = data[lab];

        yield return caso;
    }

    reader.Close();
}

public class CasoCovid
{
    public bool IsCovid { get; set; }
    public bool IsDead { get; set; }
    public int Doses { get; set; }
    public string Vacina { get; set; }

    public override string ToString()
        => $"{IsCovid} {IsDead} {Doses}";
}