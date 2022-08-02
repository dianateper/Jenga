using UnityEngine;

namespace Jenga.Block
{
    [RequireComponent(typeof(Rigidbody))]
    public class BlockPhysic : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;
        private UnityEngine.Camera _camera;

        public bool IsDraggable => !HasBlockOnTop();

        private void Start()
        {
            _camera = UnityEngine.Camera.main;
        }
        
        private bool HasBlockOnTop()
        {
            RaycastHit hit;
            if (Physics.Raycast(new Ray(transform.position, _camera.transform.up), out hit, transform.localScale.y))
                if (hit.collider.TryGetComponent(out Block hitBlock) && hitBlock != this)
                    return true;
            return false;
        }

        public void AddForce(DirectionType directionType, float force)
        {
            Vector3 direction = Vector3.zero;
            switch (directionType)
            {
                case  DirectionType.Up : direction = _camera.transform.forward; break;
                case  DirectionType.Down : direction = -_camera.transform.forward; break;
                case  DirectionType.Left : direction = -_camera.transform.right; break;
                case  DirectionType.Right : direction = _camera.transform.right; break;
            }
            
            direction.Normalize();
            _rigidbody.AddForce(direction * force, ForceMode.Impulse);
        }
        
    
        public void SetVelocity(Vector3 velocity)
        {
            _rigidbody.velocity = velocity * _speed;
        }
    }
}