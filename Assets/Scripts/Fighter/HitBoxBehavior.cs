using UnityEngine;

namespace Fighter
{
    public class HitBoxBehavior : MonoBehaviour
    {
        [SerializeField] private float damage;
        public float Damage => damage;
    }
}