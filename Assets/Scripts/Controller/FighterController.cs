using Fighter;
using UnityEngine;

namespace Controller
{
    public class FighterController : MonoBehaviour
    {
        private FighterBehaviour _fighterBehaviour;

        private void Awake()
        {
            _fighterBehaviour = GetComponent<FighterBehaviour>();
        }

        private void Update()
        {
            Controls();
        }

        private void Controls()
        {
            if (Input.GetKey(KeyCode.D))
                _fighterBehaviour.MoveRight();
            else if (Input.GetKey(KeyCode.A))
                _fighterBehaviour.MoveLeft();
            else
                _fighterBehaviour.Idle();

            if (Input.GetKeyDown(KeyCode.W)) _fighterBehaviour.Jump();

            // if (Input.GetKeyDown(KeyCode.S))
            // {
            //     _block = true;
            // }

            if (Input.GetMouseButtonDown(0) && !_fighterBehaviour.Attacking) _fighterBehaviour.Punch();

            if (Input.GetMouseButtonDown(1) && !_fighterBehaviour.Attacking) _fighterBehaviour.Kick();
            //
            // if (Input.GetKeyDown(KeyCode.H))
            // {
            //     animator.SetTrigger("hit");
            // }
        }
    }
}