using UnityEngine;

namespace FighterAI
{
    public class AIStateMachine
    {
        public enum States
        {
            Offensive,
            Defensive
        }

        private States _currentState;
        public States CurrentState => _currentState;
        
        public void ChangeState(States state)
        {
            _currentState = state;
            Debug.Log("Switching to " + state + " state");
        }
    }
}