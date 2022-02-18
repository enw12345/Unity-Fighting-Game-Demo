namespace FighterAI
{
    public class AIStateMachine
    {
        public enum States
        {
            Offensive,
            Defensive
        }

        public States CurrentState { get; private set; }

        public void ChangeState(States state)
        {
            CurrentState = state;
        }
    }
}