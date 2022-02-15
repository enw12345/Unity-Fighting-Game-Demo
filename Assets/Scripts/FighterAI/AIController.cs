using Fighter;
using UnityEngine;

namespace FighterAI
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private FighterBehaviour _fighterAI;
        [SerializeField] private FighterBehaviour _opponent;
        [SerializeField] private float healthLossThreshHold;

        //AI
        private OffensiveAI _offenseiveAI;

        private void Awake()
        {
            _fighterAI = GetComponent<FighterBehaviour>();
        }

        private void Start()
        {
            _offenseiveAI = new OffensiveAI(_fighterAI, _opponent);
        }

        private void Update()
        {
            _offenseiveAI.Sim();
        }

    }
}