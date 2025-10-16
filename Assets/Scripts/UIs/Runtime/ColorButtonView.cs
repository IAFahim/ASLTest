using System;
using Customization.Runtime;
using EventDatas.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace UIs
{
    public class ColorButtonView : MonoBehaviour
    {
        public RectIndexData rectIndexData;
        [SerializeField] private ColorPalette colorPalette;
        [SerializeField] private Image colorPreview;
        [SerializeField] private Button itemButton;

        [SerializeField] private EventBusRectIndexData eventBusRectIndexData;


        private void OnValidate()
        {
            rectIndexData.Assign(gameObject);
        }

        private void OnEnable()
        {
            itemButton.onClick.AddListener(OnButtonClicked);
        }

        public void Init(int index, ColorPalette palette)
        {
            rectIndexData.index = index;
            colorPalette = palette;
            SetColor();
        }
        
        private void Start()
        {
            SetColor();
        }

        private void SetColor()
        {
            colorPreview.color = colorPalette.colors[rectIndexData.index];
            
        }

        
        private void OnButtonClicked()
        {
            eventBusRectIndexData.Publish(rectIndexData);
            colorPalette.SaveColorIndex(rectIndexData.index);
        }
        
        private void OnDisable()
        {
            itemButton.onClick.RemoveListener(OnButtonClicked);
        }
    }
}