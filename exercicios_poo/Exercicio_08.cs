namespace Exercicios.Ex08;

public static class ProgramaEx08
{
    public static void Programa()
    {
        DespesaMes hamburguer = new DespesaMes(1, 200);
        DespesaMes coca = new DespesaMes(1, 200);
        DespesaMes uber = new DespesaMes(1, 600);


        DespesasUsuario joao = new DespesasUsuario("11122233344", new DespesaMes[] {hamburguer, coca, uber});

        DespesaMes total = joao.totalixaMes(1);

        Console.WriteLine(total.Mes + " " +  total.Valor);
        
    }
}


public class DespesaMes
{
    public int Mes { get; private set; }
    public float Valor { get; private set; }

    public DespesaMes(int mes, float valor)
    {
        this.Mes = mes;
        this.Valor = valor;
    }
}

public class DespesaDia : DespesaMes
{
    public int Dia { get; private set; }

    public DespesaDia(int dia, int mes, float valor) : base(mes, valor) { this.Dia = dia; } 

}

public class DespesasUsuario
{
    public string CPF { get; private set; }
    public DespesaMes[] Despesas { get; private set; }

    public DespesasUsuario(string cpf, DespesaMes[] despesas)
    {
        this.CPF = cpf;
        this.Despesas = despesas;
    }

    public DespesaMes totalixaMes(int mes)
    {
        float somaTotal = 0;

        foreach(var desp in this.Despesas)
        {
            if (desp.Mes == mes)
                somaTotal += desp.Valor;
        }

        return new DespesaMes(mes, somaTotal);
    }


}