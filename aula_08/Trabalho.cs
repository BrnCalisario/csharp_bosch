// Implementar estrutura de árvore binária


// Classe chamado Arvore com variaveis "Esquerda" e "Direita"
// Filho da Esquerda <= Mãe
// Filho da Direita >= Mãe
// Conter .Add(int i), bool .Contains(int i)

BinaryTree<string> bt = new BinaryTree<string>();
bt.Add("tESTE");
bt.Add("a");
bt.Add("B");
bt.Add("testes");

Console.WriteLine(bt.Contains("testes"));

public class BinaryTree<T>
    where T : IComparable<T>
{
    public T? Value { get; set; }
    public BinaryTree<T>? Left { get; set; }  = null;
    public BinaryTree<T>? Right { get; set; } = null;

    public void Add(T i)
    {
        if (this.Value == null)
        {
            this.Value = i;
        }
        else if (i.CompareTo(this.Value) < 0)
        {
            if (Left == null)
                Left = new BinaryTree<T>();
            Left.Add(i);
        }
        else
        {  
            if (Right == null)
                Right = new BinaryTree<T>();
            Right.Add(i);
        }
    }

    public bool Contains(T value)
    {
        if (value.CompareTo(this.Value) == 0)
            return true;
        if (value.CompareTo(this.Value) > 0)
            return Right?.Contains(value) ?? false;
        return Left?.Contains(value) ?? false;
    }
}
