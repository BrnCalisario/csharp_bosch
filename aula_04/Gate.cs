using System;
namespace Desafio
{
    public abstract class Component
    {
        public Gate ConnectedGate { get; set; }
        public bool isConnected { get; protected set;}
        public abstract void Connect(Gate gate);
    }

    public abstract class Gate : Component
    {
        public Input InputA { get; set; }
        public Input InputB { get; set; }
        public Input Output { get; set; }

        public Gate() 
        {
            this.Output = new Input();
            this.Output.ConnectedGate = this;
        }

        public bool GetOutput() => this.Output.State; 
        public void Update() => SetOutput();
        
        public override void Connect(Gate gate)
        {
            if (gate.AddInput(this.Output))
                ConnectedGate = gate;
                isConnected = true;
        }

        public virtual bool AddInput(Input dot)
        {
            if (!IsFull())
            {
                if (InputA == null) { InputA = dot; }
                else if (InputB == null) { InputB = dot; }
                
                if(IsFull()) { SetOutput();}
            
                return true;
            }
            return false;
        }

        public virtual bool IsFull() { return (InputA != null) && (InputB != null); }

        protected abstract void SetOutput();
    }

    public class GateAND : Gate
    {
        protected override void SetOutput()
        {
            this.Output.State = this.InputA.State && this.InputB.State;

            if (isConnected)
                ConnectedGate.Update();
        }
    }

    public class GateOR : Gate
    {
        protected override void SetOutput()
        {
            Output.State = (InputA.State || InputB.State);

            if (isConnected)
                ConnectedGate.Update();
        }
    }

    public class GateNOT : Gate
    {
        public override bool AddInput(Input dot)
        {
            if(!IsFull())
            {
                Output = dot;
                SetOutput();
                return true;
            }
            return false;
        }

        protected override void SetOutput()
        {
            this.Output.SwitchState();
            if (isConnected)
                ConnectedGate.Update();
        }

        public override bool IsFull() => (InputA != null);

    }

    public class GateXOR : Gate
    {
        protected override void SetOutput()
        {
            this.Output.State = InputA.State ^ InputB.State;
        }
        // private GateNOT notGateA = new GateNOT();
        // private GateNOT notGateB = new GateNOT();

        // private GateAND andGateA = new GateAND();
        // private GateAND andGateB = new GateAND(); 

        // private GateOR orGate = new GateOR();

        // protected override void SetOutput()
        // {
        //     Input ramifyA = new Input(InputA.State);
        //     Input ramifyB = new Input(InputB.State);

        //     // Console.WriteLine(ramifyA.State + " " + ramifyB.State);
            
        //     InputA.Connect(notGateA);
        //     InputB.Connect(notGateB);

        //     // Console.WriteLine(notGateA.GetOutput() + " " + notGateB.GetOutput());

        //     notGateA.Connect(andGateA);
        //     ramifyB.Connect(andGateA);

        //     notGateB.Connect(andGateB);
        //     ramifyA.Connect(andGateB);

        //     // Console.WriteLine(andGateB.GetOutput() + " " + andGateB.GetOutput());

        //     andGateA.Connect(orGate);
        //     andGateB.Connect(orGate);

        //     // Console.WriteLine(orGate.GetOutput());

        //     this.Output.State = orGate.GetOutput();

        //     if(isConnected)
        //         ConnectedGate.Update();

        

    }


}