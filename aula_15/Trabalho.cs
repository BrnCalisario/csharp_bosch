string pathC = "data/INFLUD21-24-10-2022.csv";

var cabecalho = pathC.Open().First().Replace("\"", "").Split(';');

pathC.Open().Read();



// var path = "COVID_21.csv";
// var table = path.Open().ReadCovid();
// foreach(var i in table)
// {

// }

// var vacinas = table.Select(v => v.Vacinas);

// foreach(var l in vacinas)
// {
//     foreach(var v in l)
//     {
//         Console.WriteLine(v.Fabricante);
//     }
// }

// double Media(IEnumerable<int> coll)
// {
//     var soma = 0;
//     foreach(var i in coll)
//     {
//         soma += i;
//     }

//     return soma / coll.Count();
// }

// var vacinadosMort = table
//     .Where(c => c.Vacinas.Count > 0)
//     .Where(c => c.EvolucaoCaso == "Óbito")
//     .Count();
// var naoVacinados = table
//     .Where(c => c.Vacinas.Count == 0)
//     .Where(c => c.EvolucaoCaso == "Óbito")
//     .Count();
// Console.WriteLine(vacinadosMort + " | " + naoVacinados);

// var vacinas = table.Select(t => t.Vacinas).Where(l => l.Count() > 0);
// int i = 0;
// foreach(var ls in vacinas)
// {
//     i++;
//     Console.WriteLine("CASO COVID: " + i);
//     foreach(var vac in ls)
//     {
//         Console.WriteLine("-------------------------");
//         Console.WriteLine("Tipo: " + vac.TipoDose);
//         Console.WriteLine("Data: " + vac.Data);
//         Console.WriteLine("Fab: " + vac.Fabricante);
//         Console.WriteLine("Lote: " + vac.Lote);
//     }
//     Console.WriteLine("");
// }


public delegate void Print(object x);

