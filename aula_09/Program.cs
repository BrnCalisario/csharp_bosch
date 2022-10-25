public class Curso
{
    public int Codigo { get; private set; }
    public string Nome { get; private set; }
    public int CargaHoraria { get; private set; }

    public Curso(int codigo, string nome, int cargaH)
    {
        this.Codigo = codigo;
        this.Nome = nome;
        this.CargaHoraria = cargaH;
    }

    public override string ToString()
    {
        return
            "Código: " + this.Codigo +
            " | Nome: " + this.Nome +
            " | Carga Horária: " + this.CargaHoraria + " horas";
    }
}

public class Aluno
{
    public int CodCurso { get; private set; }
    public int Matricula { get; private set; }
    public string Nome { get; private set; }

    public Aluno(int codCurso, int matricula, string nome)
    {
        this.CodCurso = codCurso;
        this.Matricula = matricula;
        this.Nome = nome;
    }

    public override string ToString()
    {
        return
            "Nome do Aluno: " + this.Nome +
            " | Matrícula: " + this.Matricula +
            " | Código do curso: " + this.CodCurso;
    }
}



class Program
{
    private static int count { get; set; }
    public List<Curso> Cursos { get; set; } = new List<Curso>();
    public List<Aluno> Alunos { get; set; } = new List<Aluno>();
    public bool Running { get; set; } = true;


    public Curso getCursoByID(int id)
    {
        foreach (var curso in this.Cursos)
            if (curso.Codigo == id)
                return curso;
        throw new KeyNotFoundException();
    }

    public bool containsID(int id)
    {
        foreach (var curso in this.Cursos)
            if (curso.Codigo == id)
                return true;
        return false;
    }

    public List<Aluno> getAlunosByID(int id)
    {
        List<Aluno> result = new List<Aluno>();
        foreach (var aluno in this.Alunos)
        {
            if (aluno.CodCurso == id)
                result.Add(aluno);
        }
        if (result.Count > 0)
            return result;
        throw new KeyNotFoundException();
    }

    public static Aluno InputAluno()
    {
        Console.Write("Digite o código do curso desejado: ");
        int codcurso = Convert.ToInt16(Console.ReadLine());

        count += 1;
        int matricula = count;

        Console.Write("\nDigite o nome do aluno: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Aluno " + nome + " cadastrado com sucesso!");
        Console.ReadKey();

        return new Aluno(codcurso, matricula, nome);
    }

    public static Curso InputCurso()
    {
        Console.Write("Digite o código do curso: ");
        int cod = Convert.ToInt16(Console.ReadLine());

        Console.Write("\nDigite o nome do curso: ");
        string nome = Console.ReadLine();

        Console.Write("\nDigite a carga horário do curso: ");
        int carga = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Curso " + nome + " cadastrado com sucesso!");
        Console.ReadKey();
        return new Curso(cod, nome, carga);
    }

    static void notImplemented()
    {
        Console.Clear();
        Console.WriteLine("Função não implementada :(");
        Console.ReadKey();
    }

    static void PrintMenu()
    {
        Console.WriteLine("___SYS ESCOLA___");
        Console.WriteLine("1 - Cadastrar Curso");
        Console.WriteLine("2 - Listar Cursos");
        Console.WriteLine("3 - Cadastrar Alunos");
        Console.WriteLine("4 - Dar notas ( por Curso) ");
        Console.WriteLine("5 - Estatísticas");
        Console.WriteLine("6 - Sair");
    }

    public void Sistema()
    {
        Console.Clear();
        PrintMenu();
        Console.Write("Escolha: ");
        int resposta = Convert.ToInt16(Console.ReadLine());

        switch (resposta)
        {
            case 1:
                while (true)
                {
                    try
                    {
                        this.Cursos.Add(InputCurso());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Valor inválido, tente novamente!\n");
                    }
                }
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("Cursos Cadastrados");
                this.Cursos.printList();
                Console.ReadKey();
                break;

            case 3:
                while (true)
                {
                    try
                    {
                        this.Alunos.Add(InputAluno());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Valor inválido, tente novamente!\n");
                    }
                }

                this.Alunos.Add(InputAluno());
                break;

            case 4:

                foreach (var curso in this.Cursos)
                {
                    getAlunosByID(curso.Codigo).printList();
                    Console.ReadKey();
                }

                break;
            case 5:
                Console.WriteLine("Quantidade de cursos cadastrados: " + this.Cursos.Count);
                Console.WriteLine("Quantidade de alunos cadastrados: " + this.Alunos.Count);
                Console.ReadKey();
                break;
            case 6:
                this.Running = false;
                break;
            default:
                Console.WriteLine("Opção Inválida");
                break;
        }
    }
}

public class Application
{
    static void Main(string[] args)
    {
        Console.Clear();
        Program pg = new Program();

        while (pg.Running)
        {
            pg.Sistema();
        }
    }
}

public static class MyExtensionMethods
{
    public static void printList<T>(this List<T> list)
    {
        foreach (var item in list)
            Console.WriteLine(item);
    }
}