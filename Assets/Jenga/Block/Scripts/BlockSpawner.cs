using System.Collections;
using UnityEngine;

namespace Jenga.Block
{
    public class BlockSpawner 
    {
        private const int NumberOfBlocks = 54;
        private const int NumberOfLayers = 18;
        private const int BlocksPerLayer = 3;
        private const float BlockHeight = 1.5f;
        private const float BlockWidth = 2.5f;
        private const float RangeZ = BlockWidth * BlocksPerLayer / 2 - BlockWidth / 2;
        private const float Angle90 = 90f;

        private BlockFactory _blockFactory;
        private Block[] _blocks;
        public Block[] Blocks => _blocks;
        
        public BlockSpawner(BlockFactory blockFactory)
        {
            _blockFactory = blockFactory;
        }

        public IEnumerator SpawnBlock(MonoBehaviour monoBehaviour)
        {
            yield return monoBehaviour.StartCoroutine(SpawnBlock());
        }

        private IEnumerator SpawnBlock()
        {
            _blocks = new Block[NumberOfBlocks];
            var blockPosition = Vector3.zero;
            var blockIndex = 0;
            var spawnDelay = new WaitForSeconds(0.2f);
            for (var i = 0; i < NumberOfLayers; i++)
            {
                var blockGroup = _blockFactory.GetEmptyObject(
                    GetBlockGroupPosition(i),
                    GetBlockGroupRotation(i));
                
                for (var z = -RangeZ;
                     z <= RangeZ;
                     z += BlockWidth)
                {
                    blockPosition.z = z;
                    _blocks[blockIndex] = _blockFactory.Instantiate(blockPosition, blockGroup.transform);
                   blockIndex++;
                }
                yield return spawnDelay;
            }
        }

        private static Quaternion GetBlockGroupRotation(int i)
        {
            return Quaternion.Euler(0, i * Angle90, 0);
        }

        private static Vector3 GetBlockGroupPosition(int i)
        {
            return new Vector3(0, i * BlockHeight + BlockHeight / 2 + Offset, 0);
        }

        private const float Offset = 4f;
    }
}
