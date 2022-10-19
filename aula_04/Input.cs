namespace Desafio
{
    public class Input : Component
    {
        public bool State { get; set; }
        public void SwitchState() { this.State = !this.State; }        

        public Input(bool state)
        {
            this.State = state;
            isConnected = false;
        }

        public Input()
        {
            isConnected = false;
        }

        public override void Connect(Gate gate)
        {
            if (gate.AddInput(this))
                ConnectedGate = gate;
                isConnected = true;
        }

        public void ChangeState()
        {
            SwitchState();
            if (isConnected)
                ConnectedGate.Update();
        }
    } 
}
