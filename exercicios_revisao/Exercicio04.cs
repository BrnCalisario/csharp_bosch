namespace Exercicios.Ex04;

public class Program
{
    public static void Programa()
    {

    }        

    struct Receita
    {
        string nome;
        int quantidadeIngredientes;
        Ingrediente[] ingredientes;
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
