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

            // b.ChangeState();

            // Console.WriteLine(xor.GetOutput());
            
            // b.ChangeState();
            // a.ChangeState();

            // Console.WriteLine(xor.GetOutput());

            // b.ChangeState();
    
            // Console.WriteLine(xor.GetOutput());


            Input a = new Input(true);
            Input b = new Input(false);

            Input ramA = new Input(a.State);
            Input ramB = new Input(b.State);


            GateAND and = new GateAND();
            GateOR or = new GateOR();

            a.Connect(and);
            b.Connect(and);

            ramA.Connect(or);
            ramB.Connect(or);

            Console.WriteLine(and.GetOutput() + " " + or.GetOutput());

            

            Console.WriteLine(a.State + " " + ramA.State);

            a.ChangeState();

            Console.WriteLine(a.State + " " + ramA.State);

        }


        
    }
}   