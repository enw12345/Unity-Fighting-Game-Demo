using Fighter;
using Health;

namespace FighterAI
{
    public abstract class AI
    {
        protected static readonly float maxDistanceFromOpponent = 1f;
        protected readonly FighterBehaviour _fighterAI;
        protected readonly FighterBehaviour _opponent;
        protected readonly AIStateMachine _stateMachine = new AIStateMachine();
        protected readonly float safeDistanceFromOpponent = maxDistanceFromOpponent * 2;
        protected float _distanceFromOpponent;

        protected readonly FighterHealth _opponentHealth;
        protected readonly float attackWaitTime = 1f;
        protected float damageTakenSinceLastInterval;
        protected readonly float defenseTime = 5f;

        protected const float defensiveDamageThreshold = 15;
        protected float timeInDefense = 0;
        protected float timeSinceLastAttack;

        protected AI(FighterBehaviour fighterAI, FighterBehaviour opponent)
        {
            _fighterAI = fighterAI;
            _opponent = opponent;

            var fighterAIHealth = fighterAI.GetComponent<FighterHealth>();
            fighterAIHealth.OnDamaged += IncreaseDamageTakenSinceLastInterval;

            _opponentHealth = _opponent.GetComponent<FighterHealth>();
        }

        protected abstract void Move();
        protected abstract void Attack();
        protected abstract void Defend();

        private void IncreaseDamageTakenSinceLastInterval(float maxHealth, float currentHealth, float damage)
        {
            damageTakenSinceLastInterval += damage;
        }

        public abstract void Sim();
    }
}