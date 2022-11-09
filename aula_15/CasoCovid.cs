
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
    public int IdadePaciente { get; set; }
    public List<Vacina> Vacinas { get; set; } = new List<Vacina>();

    public CasoCovid(string evolucao, int idadePaciente)
    {
        this.EvolucaoCaso = getEvo(evolucao);
        this.IdadePaciente = idadePaciente;
    }

    public void addVacina(string data, string lote, string fabricante, int tipoDose)
    {
        var vacina = new Vacina();

        vacina.Data = (data != "\"\"" ? data : "N/A");
        vacina.Lote = (lote != "\"\"" ? lote : "N/A");
        vacina.Fabricante = (fabricante !=  "\"\"" ? fabricante : "N/A");
        vacina.TipoDose = (TipoDose) tipoDose;

        Vacinas.Add(vacina);
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

public class Vacina
{
    public TipoDose TipoDose { get; set; }
    public string Data { get; set; }
    public string Lote { get; set; }
    public string Fabricante { get; set; }
}

