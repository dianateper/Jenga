using Jenga.Block;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Jenga.Camera
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform lookAt;
        [FormerlySerializedAs("_blocks")] [SerializeField] private Jenga jenga;
        private Vector3 _currentPoint;
        private Vector3 _endPoint;
        private bool _isRotated;
        private Vector3 _mouseDelta;
        private float _speed = 10;

        private void Update()
        {
            _mouseDelta = (_endPoint - _currentPoint)* Time.deltaTime;
            if (Input.touchCount <= 0 || jenga.SelectedBlock?.IsDragging == true) return;
           
            Touch touch = Input.GetTouch(0);

            if (!_isRotated && touch.phase == TouchPhase.Began)
            {
                _isRotated = true;
                _currentPoint = Input.mousePosition;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _isRotated = false;
                _endPoint = Input.mousePosition;
            }
            else if (_mouseDelta.sqrMagnitude > 10f)
            {
                RotateCamera();
            }
        }

        private void RotateCamera()
        {
            transform.RotateAround(lookAt.position, Vector3.up, _mouseDelta.normalized.x * _speed);
        }
    }
}
