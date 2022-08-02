using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Jenga.Block
{
    [RequireComponent(
        typeof(BlockRenderer), 
        typeof(BlockPhysic))]
    public class Block : MonoBehaviour
    {
        [SerializeField] private BlockRenderer _blockRenderer;
        [SerializeField] private BlockPhysic _blockPhysic;
        private UnityEngine.Camera _camera;

        private Vector3 _originalPosition;
        private Vector3 _originalScreenTargetPosition;
        private float _selectionDistance;

        public bool IsDragging;
        public bool OnGround { get; set; }
        public event Action<Block> OnBlockSelected;

        private void Awake()
        {
            _camera = UnityEngine.Camera.main;
            _blockRenderer = GetComponent<BlockRenderer>();
            _blockPhysic = GetComponent<BlockPhysic>();
        }

        public void SetMaterial(Material material)
        {
            _blockRenderer.SetMaterial(material);
        }

        public void Deselect()
        {
            _blockRenderer.OnDeselect();
        }

        private void OnMouseDrag()
        {
            if (!enabled) return;
            if(EventSystem.current.IsPointerOverGameObject()) return;
            if(_blockPhysic.IsDraggable == false) return;
            IsDragging = true;
            Vector3 mousePositionOffset = 
                _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _selectionDistance)) - _originalScreenTargetPosition;
            _blockPhysic.SetVelocity(_originalPosition + mousePositionOffset - transform.position);
        }

        private void OnMouseUp()
        {
            if (!enabled) return;
            IsDragging = false;
        }

        private void OnMouseDown()
        {
            if (!enabled) return;
            _selectionDistance = Vector3.Distance(_camera.ScreenPointToRay(Input.mousePosition).origin, transform.position);
            _originalScreenTargetPosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _selectionDistance));
            _originalPosition = transform.position;
            
            if(EventSystem.current.IsPointerOverGameObject()) return;
            _blockRenderer.OnSelect();
            OnBlockSelected?.Invoke(this);
        }

        public void AddForce(DirectionType direction, float force)
        {
            _blockPhysic.AddForce(direction, force);
        }
    }
}
