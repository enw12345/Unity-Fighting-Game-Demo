using Fighter;
using Health;
using UnityEngine;

namespace Controller
{
    public class FighterController : MonoBehaviour
    {
        private FighterBehaviour _fighterBehaviour;
        private FighterHealth _health;

        private void Awake()
        {
            _fighterBehaviour = GetComponent<FighterBehaviour>();
            _health = GetComponent<FighterHealth>();
        }

        private void Update()
        {
            if (!_health.IsDead && GameManager.GameManager.Instance.RoundStart)
                Controls();
        }

        private void Controls()
        {
            if (_fighterBehaviour.Attacking) return;
            _fighterBehaviour.Block = Input.GetKey(KeyCode.S);
            if (_fighterBehaviour.Block) return;
                
            if (Input.GetKey(KeyCode.D))
                _fighterBehaviour.MoveRight();
            else if (Input.GetKey(KeyCode.A))
                _fighterBehaviour.MoveLeft();
            else
                _fighterBehaviour.Idle();

            // if (Input.GetKeyDown(KeyCode.W)) _fighterBehaviour.Jump();

            if (Input.GetMouseButtonDown(0)) _fighterBehaviour.Punch();

            if (Input.GetMouseButtonDown(1)) _fighterBehaviour.Kick();
        }
    }
}