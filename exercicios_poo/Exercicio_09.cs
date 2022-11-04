namespace Exercicios.Ex09;

public class Pais
{
    public string Codigo { get; private set; }
    public string Nome { get; private set; }
    public long Populacao { get; private set; }
    public double DimensaoKm2 { get; private set; }
    public List<Pais> Vizinhos { get; set; }

    public Pais(string codigo, string nome, double dimensao)
    {
        this.Codigo = codigo;
        this.Nome = nome;
        this.DimensaoKm2 = dimensao;
    }

    public bool MesmoPais(Pais outro) => this.Codigo == outro.Codigo;

    public bool isVizinho(Pais pais) => Vizinhos.Contains(pais);

    public double getDensidade() => this.Populacao / DimensaoKm2;

    public List<Pais> getCommoms(Pais pais)
    {
        List<Pais> emComum = new List<Pais>();

        foreach(var vizinho in this.Vizinhos)
        {
            if (pais.Vizinhos.Contains(vizinho))
                emComum.Add(vizinho);
        }
        
        return emComum;
    }

}