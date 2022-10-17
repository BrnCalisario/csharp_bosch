using System;

namespace aula_03
{
    class Program
    {
        static void Main(string[] args)
        {

            // DateTime data = new DateTime(2004, 2, 23);
            // DateTime data2 = data;
            // data2 = data2.AddDays(1);
            // Console.WriteLine(data);


            // Pessoa pessoa = new Pessoa("Bruno", "123");
            // Pessoa pessoa2 = pessoa;
            // pessoa2.Saldo = 80;
            // Console.WriteLine(pessoa.Saldo);


            // pessoa.setSaldo(pessoa.getSaldo() + 1); << Modo Java
            // pessoa.Saldo++; << Modo C#

            Set empty  = new EmptySet();
            Set empty2 = new EmptySet();
            Set empty3 = new EmptySet();
            Set empty4 = new EmptySet();

            PairSet pair = new PairSet(empty, empty2);
            PairSet pair2 = new PairSet(empty3, empty4);

            Set union = pair.Union(pair2);

            empty.Union(pair);
            union.Union(pair);

            Console.WriteLine(union.isIn(empty));
        }
    }
}