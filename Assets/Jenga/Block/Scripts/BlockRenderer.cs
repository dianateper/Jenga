using UnityEngine;
using UnityEngine.Serialization;

namespace Jenga.Block
{
    public class BlockRenderer : MonoBehaviour, ISelectable
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [FormerlySerializedAs("deselectedColor")] [SerializeField] private Color _deselectedColor;
        [FormerlySerializedAs("selectedColor")] [SerializeField] private Color _selectedColor;
        private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

        public void SetMaterial(Material material)
        {
            Material blockMaterial = new Material(material);
            _meshRenderer.material = blockMaterial;
        }

        public void OnSelect()
        {
            _meshRenderer.material.SetColor (EmissionColor, _selectedColor);
            _meshRenderer.material.EnableKeyword("_EMISSION");
        }

        public void OnDeselect()
        {
            _meshRenderer.material.SetColor (EmissionColor, _deselectedColor);
            _meshRenderer.material.EnableKeyword("_EMISSION");
        }
    }
}