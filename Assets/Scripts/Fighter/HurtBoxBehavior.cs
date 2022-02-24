using Effects;
using Health;
using UnityEngine;

namespace Fighter
{
    public class HurtBoxBehavior : MonoBehaviour
    {
        [Range(0, 1)] [SerializeField] private float hitPauseTime = 0.15f;

        private FighterBehaviour _fighterBehaviour;

        private FighterHealth _health;

        // Start is called before the first frame update
        private void Start()
        {
            _fighterBehaviour = GetComponentInParent<FighterBehaviour>();
            _health = GetComponentInParent<FighterHealth>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out HitBoxBehavior hitBox)) return;
            _fighterBehaviour.Hit();

            StartCoroutine(HitPauseEffect.HitPause(hitPauseTime));
            _health.TakeDamage(hitBox.Damage);
        }
    }
}