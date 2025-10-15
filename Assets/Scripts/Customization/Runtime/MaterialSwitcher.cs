
using UnityEngine;

namespace Customization.Runtime
{
    public class MaterialSwitcher : MonoBehaviour, ISaveLoadAble
    {
        [SerializeField] Renderer[] selfRenderer;
        [SerializeField] private ColorPalette colorPalette;

        public string colorSaveKey = "playerColor";
        public Color currentColor;
        public int currentColorIndex;

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
            Load();
            SetColor(currentColor);
        }
        
        public void SetColor(Color color)
        {
            currentColor = color;
            foreach (var render in selfRenderer)
            {
                render.GetPropertyBlock(_materialPropertyBlock);
                _materialPropertyBlock.SetColor(Color, color);
                render.SetPropertyBlock(_materialPropertyBlock);
            }
        }

        public string SaveLoadKey
        {
            get => colorSaveKey;
            set => colorSaveKey = value;
        }

        public void Save()
        {
            PlayerPrefs.SetInt(colorSaveKey, currentColorIndex);
        }
        
        public void Load()
        {
            currentColorIndex = PlayerPrefs.GetInt(colorSaveKey, currentColorIndex);
            currentColor = colorPalette.colors[currentColorIndex];
        }
    }
}