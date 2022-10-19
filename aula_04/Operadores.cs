using System;

namespace Desafio
{
    public class SumCircuit : Gate
    {
        public Input OutputXor = new Input();
        public Input OutputNext = new Input();

        private Input ramA0 = new Input();
        private Input ramB0 = new Input();

        private GateAND and = new GateAND();
        private GateXOR xor = new GateXOR();

        public SumCircuit(bool a0, bool b0)
        {
            Input a = new Input(a0);
            Input b = new Input(b0);

            a.Connect(this);
            b.Connect(this);
        }

        public SumCircuit()
        {

        }

        protected override void SetOutput()
        {
            InputA.Connect(xor);
            InputB.Connect(xor);
        
            ramA0.Connect(and);
            ramB0.Connect(and);

            this.OutputXor.State = xor.GetOutput();
            this.OutputNext.State = and.GetOutput();

            if (isConnected)
                ConnectedGate.Update();
        }
    }

    public class SumOperator : Gate
    {
        Input output0 = new Input();
        Input output1 = new Input();
        Input output2 = new Input();

        SumCircuit c0 = new SumCircuit();
        SumCircuit c1 = new SumCircuit();
        SumCircuit cAux = new SumCircuit();

        GateAND and = new GateAND();
        
        public SumOperator(bool a0, bool b0, bool a1, bool b1)
        {
            SumCircuit c0 = new SumCircuit(a0, b0);
            SumCircuit c1 = new SumCircuit(a1, b1);
            SumCircuit cAux = new SumCircuit(c0.OutputNext.State, c1.OutputXor.State);

            SetOutput();
        }

        protected override void SetOutput()
        {
            this.output0.State = c0.OutputXor.State;
            this.output1.State = cAux.OutputXor.State;
            
            and.AddInput(c1.OutputNext);
            and.AddInput(cAux.OutputNext);

            this.output2.State = and.GetOutput();

        }
    }
}