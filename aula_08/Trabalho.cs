// Implementar estrutura de árvore binária


// Classe chamado Arvore com variaveis "Esquerda" e "Direita"
// Filho da Esquerda <= Mãe
// Filho da Direita >= Mãe
// Conter .Add(int i), bool .Contains(int i)

BinaryTree<string> bt = new BinaryTree<string>();
bt.Add("Teste");
bt.Add("abc");
bt.Add("Thiago");
bt.Add("Portugol");

Console.WriteLine(bt.Contains("abc"));

public class BinaryTree<T>
    where T : IComparable<T>
{
    public T? Value { get; set; }
    public BinaryTree<T>? Left { get; set; }  = null;
    public BinaryTree<T>? Right { get; set; } = null;

    public void Add(T i)
    {
        if (this.Value == null || this.Value.CompareTo(default(T)) == 0)
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
