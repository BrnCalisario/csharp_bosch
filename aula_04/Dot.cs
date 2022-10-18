namespace Desafio
{
    public abstract class Dot : Component
    {
        public bool State { get; set; }
        public void SwitchState() { this.State = !this.State; }                                    
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

        public void ChangeState()
        {
            SwitchState();
            if ( isConnected )
                connectedGate.Update();
        }
    } 

    public class OutputDot : Dot
    {
        public override void Connect(Gate gate)
        {
            throw new System.NotImplementedException();
        }
    }   
}
