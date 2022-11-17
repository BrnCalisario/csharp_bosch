namespace Exercicios.Ex04;

public class Program
{
    public static void Programa()
    {
        Ingrediente farinha = new Ingrediente("Farinha", "500g");
        Ingrediente ovo = new Ingrediente("Ovo", "1un");
        Ingrediente oleo = new Ingrediente("Óleo", "20ml");


        Receita omelet = new Receita("Omelete", new Ingrediente[] {farinha, oleo, ovo} );


    }        

    struct Receita
    {
        string nome;
        int quantidadeIngredientes;
        Ingrediente[] ingredientes;

        public Receita(string n, Ingrediente[] ingredientes)
        {
            this.nome = n;
            this.ingredientes = ingredientes;
            this.quantidadeIngredientes = ingredientes.Count();
        }
    }

    struct Ingrediente
    {
        string nome;
        string quantidade;

        public Ingrediente(string n, string q)
        {
            this.nome = n;
            this.quantidade = q;
        }
    }
}
