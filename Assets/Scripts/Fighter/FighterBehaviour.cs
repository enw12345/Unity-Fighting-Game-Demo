using System;
using Health;
using UnityEngine;

namespace Fighter
{
    public class FighterBehaviour : MonoBehaviour
    {
        //Animation Variables
        [SerializeField] private Animator animator;

        //Movement related Variables
        [SerializeField] [Range(0f, 100f)] private float maxSpeed = 1f;
        [SerializeField] [Range(0f, 100f)] private float maxAcceleration = .5f;
        [SerializeField] [Range(0f, 100f)] private float jumpHeight;

        //Hit boxes
        [Header("Hit Boxes")] [SerializeField] private BoxCollider leftArmHitBox;

        [SerializeField] private BoxCollider rightLegHitBox;

        // Animation variables
        private bool _jump;

        public bool Block { get; set; }

        private float _direction;

        //Fighter stats
        private FighterHealth _health;
        // private float _up;
        private Vector3 _velocity;
        [NonSerialized] public bool Attacking;
        
        private static readonly int Kick1 = Animator.StringToHash("kick");
        private static readonly int Attack = Animator.StringToHash("attack");
        private static readonly int Hit1 = Animator.StringToHash("hit");
        private static readonly int Death = Animator.StringToHash("death");
        private static readonly int Velocity = Animator.StringToHash("velocity");
        private static readonly int Direction = Animator.StringToHash("direction");
        private static readonly int Block1 = Animator.StringToHash("block");

        private void Awake()
        {
            if (!animator)
                animator = GetComponent<Animator>();
            if (!_health)
                _health = GetComponent<FighterHealth>();

            leftArmHitBox.enabled = false;
            rightLegHitBox.enabled = false;
        }

        // Update is called once per frame
        private void Update()
        {
            UpdateAnimator();
            if (_health.IsDead)
                Defeat();
        }
        
        public void MoveRight(float direction = 0)
        {
            Movement(1);
            _direction = direction;
        }

        public void MoveLeft(float direction = 1)
        {
            Movement(-1);
            _direction = direction;
        }

        public void Idle()
        {
            if (_velocity.z > 0)
            {
                var maxSpeedChange = maxAcceleration * Time.deltaTime;
                _velocity.z = Mathf.Clamp01(Mathf.Lerp(_velocity.z, 0, maxSpeedChange));
            }
            else
            {
                _velocity = Vector3.zero;
            }
        }

        public void Jump()
        {
            _jump = !_jump;
        }

        public void Kick()
        {
            animator.SetTrigger(Kick1);
        }

        private void Movement(float forwardDirection)
        {
            var desiredVelocity = new Vector3(0, 0, forwardDirection) * maxSpeed;
            var maxSpeedChange = maxAcceleration * Time.deltaTime;
            _velocity.z = Mathf.MoveTowards(_velocity.z, desiredVelocity.z, maxSpeedChange);

            if (_jump)
                _velocity.y += jumpHeight;
            else
                _velocity.y = 0;

            var displacement = _velocity * Time.deltaTime;

            transform.localPosition += displacement;
        }

        public void Punch()
        {
            animator.SetTrigger(Attack);
        }

        public void Hit()
        {
            animator.SetTrigger(Hit1);
            Attacking = false;
        }

        public void TakeDamage(float damage)
        {
            _health.TakeDamage(damage);
        }

        private void Defeat()
        {
            animator.SetBool(Death, true);
        }

        
        private void UpdateAnimator()
        {
            animator.SetFloat(Velocity, Mathf.Abs(_velocity.z));
            animator.SetFloat(Direction, _direction);
            animator.SetBool(Block1, Block);
        }

        public void ActivateLightAttackHitBox()
        {
            leftArmHitBox.enabled = true;
            Attacking = true;
        }

        public void DeactivateLightAttackHitBox()
        {
            leftArmHitBox.enabled = false;
            Attacking = false;
        }

        public void ActivateHeavyAttackHitBox()
        {
            rightLegHitBox.enabled = true;
            Attacking = true;
        }

        public void DeactivateHeavyAttackHitBox()
        {
            rightLegHitBox.enabled = false;
            Attacking = false;
        }
    }
}