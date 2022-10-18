using System;

namespace Aula_04
{
    
    public abstract class Dot
    {
        public Gate connectedGate { get; set; }
        public bool isConnected { get; protected set; }
        public bool State { get; set; }
        public void SwitchState() { State = !State; }
        public abstract void Connect(Gate gate);
    }

    public class InputDot : Dot
    {
        public InputDot(bool state)
        {
            this.State = state;
            isConnected = false;
        }

        public override void Connect(Gate gate)
        {
            if (gate.AddInput(this))
                connectedGate = gate;
                isConnected = true;

        }

        public void Switch()
        {
            SwitchState();
            if( isConnected )
            {
                connectedGate.Update();
            }
        }

    }

    public class OutputDot : Dot
    {
        public override void Connect(Gate gate)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class Gate
    {
        public Gate connectedGate { get; set; }
        public abstract bool AddInput(Dot dot);
        public abstract bool IsFull();
        public abstract void SetOutput();
        public abstract void Update();
        public abstract void Connect(Gate gate);
    }

    public class GateAND : Gate
    {
        public Dot InputA { get; set; }
        public Dot InputB { get; set; }
        public Dot Output { get; set; }
        

        public GateAND()
        {
            this.Output = new OutputDot();
            this.Output.connectedGate = this;
        }
        
        public override bool AddInput(Dot dot)
        {
            if (!IsFull())
            {
                if (InputA == null)
                    InputA = dot;
                else if (InputB == null)
                    InputB = dot;

                if (IsFull())
                    SetOutput();
                
                return true;
            }
            return false;
        }

        public override void SetOutput()
        {
            this.Output.State = this.InputA.State && this.InputB.State;
        }

        public override bool IsFull()
        {
            return (InputA != null) && (InputB != null);
        }
    
        public override void Update()
        {
            SetOutput();
        }

        public override void Connect(Gate gate)
        {
            if (gate.AddInput(Output))
                connectedGate = gate;
        }
    }

    public class GateOR : Gate
    {
        public Dot InputA { get; set; }
        public Dot InputB { get; set; }
        public Dot Output { get; set; }

        public override bool AddInput(Dot dot)
        {
            if (!IsFull()) 
            {
                if (InputA == null) { InputA = dot; }
                else if (InputB == null) { InputB = dot; }

                if (IsFull()) { SetOutput(); }
            }
            return false;
        }

        public override bool IsFull()
        {
            return (InputA != null) && (InputB != null);
        }

        public override void SetOutput()
        {
            Output.State = (InputA.State || InputB.State);
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Connect(Gate gate)
        {

        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            InputDot a = new InputDot(true);
            InputDot b = new InputDot(false);
            InputDot c = new InputDot(false);

            GateAND and = new GateAND();

            a.Connect(and);
            b.Connect(and);

            GateOR or = new GateOR();

            and.Connect(or);

            Console.WriteLine(or.InputA);

        }
    }
}   