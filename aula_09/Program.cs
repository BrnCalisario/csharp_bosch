public class Curso
{
    public int Codigo { get; private set; }
    public string Nome { get; private set; }
    public int CargaHoraria { get; private set; }
    public float MediaGeral { get; set; }

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
    public float[] Notas { get; set; } = new float[2];

    public Aluno(int codCurso, int matricula, string nome)
    {
        this.CodCurso = codCurso;
        this.Matricula = matricula;
        this.Nome = nome;
    }


    public float GetMedia()
    {
        float media = 0;
        foreach (var nota in Notas)
            media += nota;
        return media / Notas.Length;
    }

    public override string ToString()
    {
        return
            "Aluno: " + this.Nome +
            " | Matrícula: " + this.Matricula;
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

    public Aluno InputAluno()
    {
        Console.Write("Digite o código do curso desejado: ");
        int codcurso = 0;

        codcurso = Convert.ToInt16(Console.ReadLine());
        if (!this.containsID(codcurso))
            throw new InvalidDataException();

        Console.Write("\nDigite o nome do aluno: ");
        string nome = Console.ReadLine();

        count += 1;
        int matricula = count;

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

    public void EnumerateCursos()
    {
        for (int i = 0; i < this.Cursos.Count; i++)
            Console.WriteLine($"{i + 1} > {this.Cursos[i].Nome}");
    }

    public static void EnumerateAlunos(List<Aluno> alunosList)
    {
        for (int i = 0; i < alunosList.Count; i++)
            Console.WriteLine($"{i + 1} > {alunosList[i]}");
    }

    static void notImplemented()
    {
        Console.Clear();
        Console.WriteLine("Função não implementada :(");
        Console.ReadKey();
    }

    void PrintEstatisticas()
    {
        if (this.Cursos.Count == 0)
        {
            Console.WriteLine("Nenhum curso cadastrado!");
            return;
        }

        foreach (var curso in this.Cursos)
        {
            List<Aluno> alunosDoCurso = null;
            try
            {
                alunosDoCurso = getAlunosByID(curso.Codigo);
            }
            catch
            {

            }

            if (!(alunosDoCurso == null))
            {
                float mediaGeral = 0;
                foreach (var aluno in alunosDoCurso)
                {
                    mediaGeral += aluno.GetMedia();
                }
                mediaGeral = mediaGeral / alunosDoCurso.Count;

                curso.MediaGeral = mediaGeral;
                Console.WriteLine($"> {curso.Nome} - {curso.MediaGeral} - Cód. do Curso {curso.Codigo} - Quant. Alunos Cadastrados {alunosDoCurso.Count}");
                if (alunosDoCurso.Count > 0)
                    foreach (var aluno in alunosDoCurso)
                    {
                        Console.WriteLine($" > {aluno.Nome} - Média: {aluno.GetMedia()}");
                    }
            }
            else
            {
                Console.WriteLine($"> {curso.Nome} - Cód. do Curso {curso.Codigo}");
                Console.WriteLine(" > Sem alunos cadastrados");
            }
        }
    }

    static void PrintMenu()
    {
        Console.WriteLine("_____SYS ESCOLA_____");
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
        int resposta = -1;
        try
        {
            resposta = Convert.ToInt16(Console.ReadLine());
        }
        catch
        {
            return;
        }


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
                this.Cursos.PrintList();
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
                    catch (InvalidDataException)
                    {
                        Console.WriteLine("Código para curso inválido!\n");
                        Console.ReadKey();
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Valores inválido, tente novamente!\n");
                        Console.ReadKey();
                    }
                }
                break;

            case 4:

                Console.WriteLine("Digite o número do curso desejado: ");
                EnumerateCursos();
                Console.Write("Escolha: ");
                int escolha = Convert.ToInt16(Console.ReadLine());

                if (escolha > 0 && escolha <= this.Cursos.Count)
                {
                    List<Aluno> alunos_encontrados = getAlunosByID(this.Cursos[escolha - 1].Codigo);
                    EnumerateAlunos(alunos_encontrados);
                    Console.Write("Escolha o aluno que deseja dar nota: ");
                    int escolha_aluno = Convert.ToInt16(Console.ReadLine());

                    if (escolha_aluno > 0 && escolha <= alunos_encontrados.Count)
                    {
                        Aluno aluno = alunos_encontrados[escolha_aluno - 1];
                        Console.WriteLine(aluno + " | Curso: " + getCursoByID(aluno.CodCurso).Nome);

                        Console.WriteLine("Insira a nota 1: ");
                        float nota1 = (float)(Convert.ToDouble(Console.ReadLine()));

                        Console.WriteLine("Insira a nota 2: ");
                        float nota2 = (float)(Convert.ToDouble(Console.ReadLine()));

                        aluno.Notas = new float[] { nota1, nota2 };
                        Console.WriteLine("Notas adicionadas com sucesso!");
                        Console.ReadKey();
                    }

                }


                break;
            case 5:
                // Console.WriteLine("Quantidade de cursos cadastrados: " + this.Cursos.Count);
                // Console.WriteLine("Quantidade de alunos cadastrados: " + this.Alunos.Count);
                PrintEstatisticas();
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
    public static void PrintList<T>(this List<T> list)
    {
        foreach (var item in list)
            Console.WriteLine(item);
    }

}