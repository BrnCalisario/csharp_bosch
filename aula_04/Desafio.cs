using System;

namespace Desafio
{
    class Program 
    {
        static void Main(string[] args)
        {
            // Input a = new Input(true);
            // Input b = new Input(true);
            // Input c = new Input(true);

            // GateAND and = new GateAND();
            // GateOR or = new GateOR();
            // GateNOT not = new GateNOT();

            // a.Connect(and);
            // b.Connect(and);
            
            // c.Connect(or);
            // and.Connect(or);

            // or.Connect(not);

            // Console.WriteLine(not.getOutput());

            // a.ChangeState();
            // c.ChangeState();
            
            // Console.WriteLine(not.getOutput());


            Input a = new Input(true);
            Input b = new Input(true);

            Input a_ramify = new Input(a.State);
            Input b_ramify = new Input(b.State);

            GateNOT not_a = new GateNOT();
            GateNOT not_b = new GateNOT();

            GateAND and_a = new GateAND();
            GateAND and_b = new GateAND();

            a.Connect(not_a);
            b.Connect(not_b);

            not_a.Connect(and_a);
            not_b.Connect(and_b);

            a_ramify.Connect(and_b);
            b_ramify.Connect(and_a);

            GateOR or = new GateOR();

            and_a.Connect(or);
            and_b.Connect(or);

            Console.WriteLine(or.getOutput());

        }
    }
}   