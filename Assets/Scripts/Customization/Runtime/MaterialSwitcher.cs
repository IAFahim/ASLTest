
using System;
using UnityEngine;

namespace Customization.Runtime
{
    public class MaterialSwitcher : MonoBehaviour
    {
        [SerializeField] Renderer[] selfRenderer;
        [SerializeField] private ColorPalette colorPalette;


        private MaterialPropertyBlock _materialPropertyBlock;
        private static readonly int Color = Shader.PropertyToID("_BaseColor");

        private void OnValidate()
        {
            selfRenderer = GetComponentsInChildren<Renderer>();
        }

        private void Awake()
        {
            _materialPropertyBlock = new MaterialPropertyBlock();
        }

        private void OnEnable()
        {
            colorPalette.onColorSaved.AddListener(SetColor);
            var color = colorPalette.LoadColor();
            SetColor(color);
        }

        private void SetColor(int index)
        {
            SetColor(colorPalette.colors[index]);
        }

        public void SetColor(Color color)
        {
            foreach (var render in selfRenderer)
            {
                render.GetPropertyBlock(_materialPropertyBlock);
                _materialPropertyBlock.SetColor(Color, color);
                render.SetPropertyBlock(_materialPropertyBlock);
            }
        }

        private void OnDisable()
        {
            colorPalette.onColorSaved.RemoveListener(SetColor);
        }
    }
}