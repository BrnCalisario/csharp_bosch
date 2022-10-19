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



            // Input a = new Input(false);
            // Input b = new Input(false);

            // GateXOR xor = new GateXOR();

            // a.Connect(xor);
            // b.Connect(xor);

            // Console.WriteLine(xor.GetOutput());



            // SumCircuit circ = new SumCircuit(false, true);
            // Console.WriteLine(circ.OutputNext.State + " " + circ.OutputXor.State);
            SumOperator sum = new SumOperator(true, true, true, true);
        }


        
    }
}   