using System;

namespace Aula_04
{
    class Program 
    {
        static void Main(string[] args)
        {
            InputDot a = new InputDot(true);
            InputDot b = new InputDot(true);
            InputDot c = new InputDot(true);

            GateAND and = new GateAND();
            GateOR or = new GateOR();
            GateNOT not = new GateNOT();

            a.Connect(and);
            b.Connect(and);

            c.Connect(or);
            and.Connect(or);

            or.Connect(not);

            Console.Write(not.getOutput());

            a.ChangeState();
            c.ChangeState();

            Console.Write(not.getOutput());
        }
    }
}   