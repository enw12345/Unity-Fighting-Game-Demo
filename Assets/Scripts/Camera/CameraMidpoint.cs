using Fighter;
using UnityEngine;

namespace Camera
{
    public class CameraMidpoint : MonoBehaviour
    {
        [SerializeField]private FighterBehaviour _fighterOne;

        [SerializeField]private FighterBehaviour _fighterTwo;

        private float _previousMidPoint;

        public float MidPoint => FindMidPointBetweenFighters();

        public float DistanceBetweenFighters => FindDistanceBetweenFighters();
        // Start is called before the first frame update
       private  void Start()
        {
            _previousMidPoint = FindMidPointBetweenFighters();

        }

        // Update is called once per frame
        private void Update()
        {
            var position = transform.position;
            position = new Vector3(position.x, position.y, FindMidPointBetweenFighters());
            transform.position = position;
        }

        private float FindMidPointBetweenFighters()
        {
            return (_fighterOne.transform.position.z + _fighterTwo.transform.position.z) * 0.5f;
        }

        private float FindDistanceBetweenFighters()
        {
            return Mathf.Abs((Mathf.Abs(_fighterOne.transform.position.magnitude) - Mathf.Abs(_fighterTwo.transform.position.magnitude)));
        }
    }
}
