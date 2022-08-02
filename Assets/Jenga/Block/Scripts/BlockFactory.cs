using Jenga.Services.Common;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Jenga.Block
{
    public class BlockFactory
    {
        private readonly ResourceProvider _resourceProvider;
        private const string BlockPath = "Block/block";
        private readonly BlockSettings _settings;
        
        public BlockFactory(ResourceProvider resourceProvider, BlockSettings settings)
        {
            _resourceProvider = resourceProvider;
            _settings = settings;
        }

        public Block Instantiate(Vector3 at, Transform parent)
        {
            var block = Object.Instantiate(_resourceProvider.LoadGameObject(BlockPath).GetComponent<Block>(), parent);
            block.transform.localPosition = at;
            block.SetMaterial(_settings.RandomMaterial);
            return block;
        }

        public GameObject GetEmptyObject(Vector3 position, Quaternion rotation)
        {
            GameObject blockGroup = new GameObject
            {
                transform =
                {
                    position = position,
                    rotation = rotation
                }
            };
            return blockGroup;
        }
    }
}