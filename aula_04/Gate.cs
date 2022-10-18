using System;
namespace Desafio
{

    public abstract class Component
    {
        public Gate connectedGate { get; set; }
        public bool isConnected { get; protected set;}
        public abstract void Connect(Gate gate);
    }

    public abstract class Gate : Component
    {
        
        public Dot Output { get; set; }

        public Gate() 
        {
            this.Output = new OutputDot();
            this.Output.connectedGate = this;
        }

        public bool getOutput() { return this.Output.State; }

        public abstract bool AddInput(Dot dot);
        public abstract bool IsFull();
        protected abstract void SetOutput();
        public void Update() { SetOutput(); }

        public override void Connect(Gate gate)
        {
            if (gate.AddInput(this.Output))
                connectedGate = gate;
                isConnected = true;
        }


    }

    public class GateAND : Gate
    {
        public Dot InputA { get; set; }
        public Dot InputB { get; set; }


        public override bool AddInput(Dot dot)
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

        protected override void SetOutput()
        {
            this.Output.State = this.InputA.State && this.InputB.State;
        }

        public override bool IsFull()
        {
            return (InputA != null) && (InputB != null);
        }

    }

    public class GateOR : Gate
    {
        public Dot InputA { get; set; }
        public Dot InputB { get; set; }

        public override bool AddInput(Dot dot)
        {
            if (!IsFull())
            {
                if (InputA == null) { InputA = dot; }
                else if (InputB == null) { InputB = dot; }

                if(IsFull()) 
                { 
                    SetOutput();
                     
                }

                return true;
            }
            return false;
        }

        protected override void SetOutput()
        {
            Output.State = (InputA.State || InputB.State);

            if (isConnected)
            {
                connectedGate.Update();
            }
        }

        public override bool IsFull()
        {
            return (InputA != null) && (InputB != null);
        }
    }

    public class GateNOT : Gate
    {
        public Dot Input { get; set; }

        public override bool AddInput(Dot dot)
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

            
        }

        public override bool IsFull()
        {
            return (Input != null);
        }
    }
}