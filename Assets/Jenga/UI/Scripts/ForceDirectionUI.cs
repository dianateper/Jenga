using System;
using Jenga.Block;
using UnityEngine;
using UnityEngine.UI;

namespace Jenga.UI
{
    public class ForceDirectionUI : MonoBehaviour
    {
        [SerializeField] private Button _upButton;
        [SerializeField] private Button _downButton;
        [SerializeField] private Button _rightButton;
        [SerializeField] private Button _leftButton;

        public event Action<DirectionType> AddForce;

        public void Start()
        {
            _upButton.onClick.AddListener(() => ClickForceDirection(DirectionType.Up));
            _downButton.onClick.AddListener(() => ClickForceDirection(DirectionType.Down));
            _rightButton.onClick.AddListener(() => ClickForceDirection(DirectionType.Right));
            _leftButton.onClick.AddListener(() => ClickForceDirection(DirectionType.Left));
        }
        
        private void ClickForceDirection(DirectionType direction)
        {
            AddForce?.Invoke(direction);
        }
    }
}
