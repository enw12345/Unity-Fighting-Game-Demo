using Fighter;
using Health;
using UnityEngine;

namespace FighterAI
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private FighterBehaviour _fighterAI;
        [SerializeField] private FighterBehaviour _opponent;

        private FighterHealth _health;

        //AI
        private OffensiveAI _offensiveAI;

        private void Awake()
        {
            _fighterAI = GetComponent<FighterBehaviour>();
            _health = GetComponent<FighterHealth>();
        }

        private void Start()
        {
            _offensiveAI = new OffensiveAI(_fighterAI, _opponent);
        }

        private void Update()
        {
            if (!_health.IsDead && GameManager.GameManager.Instance.RoundStart)
                _offensiveAI.Sim();
        }
    }
}