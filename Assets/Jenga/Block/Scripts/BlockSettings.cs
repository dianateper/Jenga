using UnityEngine;

namespace Jenga.Block
{
    [CreateAssetMenu(menuName = "Jenga/Block Settings", fileName = "BlockSettings")]
    public class BlockSettings : ScriptableObject
    {
        public Material[] blockMaterials;
        public Material RandomMaterial => blockMaterials[Random.Range(0, blockMaterials.Length)];
    }
}