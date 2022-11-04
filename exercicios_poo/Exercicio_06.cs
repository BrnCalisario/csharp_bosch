namespace Exercicios.Ex06;

public static class TestarLivros
{
    public static void Programa()
    {
        Livro livroFavorito = new Livro();
        
        livroFavorito.Titulo = "O Pequeno Príncipe";
        livroFavorito.QtdPaginas = 98;

        Console.WriteLine($"O livro {livroFavorito.Titulo} possui {livroFavorito.QtdPaginas} páginas");

        livroFavorito.LerPaginas(20);
        livroFavorito.VerificarProgresso();

        livroFavorito.QtdPaginas = 50;
        livroFavorito.VerificarProgresso();
        
    }
}



public class Livro
{
    private string titulo { get; set; }
    private int qtdPaginas { get; set; }
    private int paginasLidas { get; set; }

    public string Titulo 
    {
        get => this.titulo;
        set { this.titulo = value; }
    }

    public int QtdPaginas
    {
        get => this.qtdPaginas;
        set { this.qtdPaginas = value; paginasLidas = 0; }
    }


    public Livro() {}

    public Livro(string nome, int qtdPaginas)
    {
        this.titulo = nome;
        this.qtdPaginas = qtdPaginas;
    }

    public void VerificarProgresso()
    {
        float porcentagem = paginasLidas * 100 / qtdPaginas;
        Console.WriteLine($"Você já leu {porcentagem}% do livro ");
    }

    public void LerPaginas(int qtd)
    {
        if ((paginasLidas + qtd) > qtdPaginas) 
            return;

        paginasLidas += qtd;
    }

}


