using System;
using System.Collections;
using Jenga.Block;
using Jenga.Services.Common;
using Jenga.UI;
using UnityEngine;

namespace Jenga
{
    public class Jenga : MonoBehaviour
    {
        [SerializeField] private BlockSettings _settings;
        [SerializeField] private ForceDirectionUI _forceDirectionUI;
        [SerializeField] private float _force;
        
        private BlockSpawner _blockSpawner;
        private BlockFactory _blockFactory;
        private Block.Block[] _blocks;
        private Block.Block _selectedBlock;
        private bool initialized;
        public bool Initialized;
        
        public Block.Block SelectedBlock => _selectedBlock;
        public event Action SceneInitialized;

        private IEnumerator Start()
        {
            _blockFactory = new BlockFactory(new ResourceProvider(), _settings);
            _blockSpawner = new BlockSpawner(_blockFactory);
            yield return StartCoroutine(_blockSpawner.SpawnBlock(this));
            _blocks = _blockSpawner.Blocks;
            InitializeBlocks();
            _forceDirectionUI.AddForce += AddForce;
            initialized = true;
            SceneInitialized?.Invoke();
        }

        private void InitializeBlocks()
        {
            foreach (var block in _blocks)
            {
                block.enabled = true;
                block.OnBlockSelected += OnBlockSelected;
            }
        }

        private void OnBlockSelected(Block.Block block)
        {
            if (initialized == false || block == _selectedBlock) return;
            _selectedBlock?.Deselect();
            _selectedBlock = block;
        }

        private void OnDestroy()
        {
            foreach (var block in _blocks)
            {
                block.OnBlockSelected -= OnBlockSelected;
            }
        }

        private void AddForce(DirectionType direction)
        {
            _selectedBlock?.AddForce(direction, _force);
        }
    }
}