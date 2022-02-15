using UnityEngine;

namespace Health
{
    public class FighterHealth : MonoBehaviour
    {
        public delegate void TookDamage(float maxHealth, float currentHealth, float damage);

        [SerializeField] private float maxHealth;

        private float _currentHealth;

        public bool IsDead => _currentHealth <= 0;

        private void Start()
        {
            _currentHealth = maxHealth;
        }

        public event TookDamage OnDamaged;

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            OnDamaged?.Invoke(maxHealth, _currentHealth, damage);
        }
    }
}