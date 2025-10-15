using UnityEngine;

namespace Customization.Runtime
{
    public class MaterialSwitcher : MonoBehaviour
    {
        private static readonly int Color = Shader.PropertyToID("_Color");
        [SerializeField] Renderer selfRenderer;
        private MaterialPropertyBlock _materialPropertyBlock;

        private void OnValidate()
        {
            selfRenderer = GetComponent<Renderer>();
        }

        private void Awake()
        {
            _materialPropertyBlock = new MaterialPropertyBlock();
        }

        public void SetColor(Color color)
        {
            selfRenderer.GetPropertyBlock(_materialPropertyBlock);
            _materialPropertyBlock.SetColor(Color, color);
            selfRenderer.SetPropertyBlock(_materialPropertyBlock);
        }
    }
}