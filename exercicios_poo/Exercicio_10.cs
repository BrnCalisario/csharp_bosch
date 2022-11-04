namespace Exercicios.Ex10;

public class Matriz
{
    public int linhas { get; set; }
    public int colunas { get; set; }
    public int[,] matriz;

    public Matriz(int linha, int coluna)
    {
        this.linhas = linha;
        this.colunas = coluna;

        matriz = new int[linha, coluna];
    }

    public Matriz(int[,] arr)
    {
        this.linhas = arr.GetLength(0);
        this.colunas = arr.GetLength(1);

        this.matriz = arr;
    }

    public void Fill(int value = 0)
    {
        for(int i = 0 ; i < this.linhas; i++)
        {
            for (int j = 0; j < this.colunas; j++)
            {
                this.matriz[i,j] = value;
            }
        }
    }

    public void FillRandom()
    {
        Random rnd = new Random();

        for(int i=0; i < this.linhas; i++)
        {
            for(int j=0; j < this.colunas; j++)
            {
                this.matriz[i,j] = rnd.Next(1, 9);
            }
        }
    }

    public void Print()
    {
        for(int i=0; i < this.linhas; i++)
        {
            for(int j=0; j < this.colunas; j++)
            {
                Console.Write($"{this.matriz[i,j]} ");
            }
            Console.WriteLine("");
        }
    }

    public void TransposeSelf()
    {
        int[,] olderMt = this.matriz;
        
        int aux = this.linhas;
        
        this.linhas = this.colunas;
        this.colunas = aux;
        this.matriz = new int[this.linhas, this.colunas];

        for(int i=0; i < this.linhas; i++)
        {
            for(int j=0; j < this.colunas; j++)
            {
                this.matriz[i, j] = olderMt[j, i];
            }
        }
    }

    public int[,] GetTranspose()
    {
        int col  = this.linhas;
        int lin = this.colunas;

        int[,] transposed = new int[lin, col];

        for(int i = 0; i < lin; i++)
        {
            for(int j = 0; j < col; j++)
                transposed[i, j] = this.matriz[j, i];
        }

        return transposed;
    }

    public bool isSymmetrical()
    {
        var otherMt = GetTranspose();

        try
        {
            for(int i = 0; i < this.linhas; i++)
                for(int j = 0; j < this.colunas; j++)
                    if (this.matriz[i, j] != otherMt[i , j])
                        return false;
        }
        catch (System.Exception) { return false; }
    
        return true;
    }

}

public static class ProgramaEx10
{
    public static void Program()
    {
        Matriz mt = new Matriz(4, 4);

        mt.Fill();
        mt.Print();


        Console.WriteLine(mt.isSymmetrical());


        // mt.TransposeSelf();
        // mt.Print();
        // var newMt = new Matriz(mt.GetTranspose());

        // newMt.Print();


    }
}