using UnityEngine;

namespace Camera
{
    public class CameraController : MonoBehaviour
    {
        private CameraMidpoint _cameraMidpoint;
        
        private float _initialPositionX;
        
        // Start is called before the first frame update
        private void Start()
        {
            _cameraMidpoint = GetComponentInParent<CameraMidpoint>();
            _initialPositionX = transform.localPosition.x;
        }

        // Update is called once per frame
        private void Update()
        {
            var position = transform.localPosition;
            position = new Vector3(_initialPositionX + _cameraMidpoint.DistanceBetweenFighters, position.y, position.z);
            transform.localPosition = position;
            
        }
    }
}
