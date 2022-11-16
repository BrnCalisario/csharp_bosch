string pathC = "data/INFLUD21-24-10-2022.csv";

var cabecalho = pathC.Open().First().Replace("\"", "").Split(';');

var dt = pathC.Open().ReadCovid().Take(10000);



// .Average(c => c.isDead ? 1.0 : 0.0)




public delegate void Print(object x);


// double totalCount = dt.Count();
// double mortosCount = dt.Where(caso => caso.EvolucaoCaso == "Óbito").Count();
// double vivosCount = dt.Where(caso => caso.EvolucaoCaso == "Cura").Count();

// var perceMortos = String.Format("{0:0.00}", ((mortosCount / totalCount) * 100)) + "%";
// var perceVivos =  String.Format("{0:0.00}", ((vivosCount / totalCount) * 100)) + "%";

// Console.WriteLine(totalCount);
// Console.WriteLine(mortosCount);
// Console.WriteLine(vivosCount);

// Console.WriteLine("Vivos: " + perceVivos);
// Console.WriteLine("Mortos: " + perceMortos);
