using Fighter;
using Health;

namespace FighterAI
{
    public abstract class AI
    {
        protected readonly FighterBehaviour _opponent;
        protected readonly FighterBehaviour _fighterAI;
        protected FighterHealth _fighterAIHealth;
        
        protected readonly float maxDistanceFromOpponent = 1f;
        protected float _distanceFromOpponent;
        protected float attackWaitTime = 2f;
        protected float timeSinceLastAttack;
        
        protected float defensiveDamageThreshold = 15;
        protected float blockDamageThreshold = 10;
        protected float damageTakenSinceLastInterval = 0;
        protected float timeInDefense = 0;
        protected float defenseTime = 5f;
        protected readonly AIStateMachine _stateMachine = new AIStateMachine();
        
        protected AI(FighterBehaviour fighterAI, FighterBehaviour opponent)
        {
            _fighterAI = fighterAI;
            _opponent = opponent;
            _fighterAIHealth = fighterAI.GetComponent<FighterHealth>();
            _fighterAIHealth.OnDamaged += IncreaseDamageTaken;
        }

        protected abstract void Move();
        protected abstract void Attack();
        protected abstract void Defend();

        private void IncreaseDamageTaken(float maxHealth, float currentHealth, float damage)
        {
            damageTakenSinceLastInterval += damage;
        }
        
        public abstract void Sim();
    }
}