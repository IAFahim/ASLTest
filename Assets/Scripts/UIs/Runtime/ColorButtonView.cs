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
        public ColorPalette colorPalette;
        [SerializeField] private Image colorPreview;
        [SerializeField] private RectTransform rect;
        [SerializeField] private Button itemButton;

        [SerializeField] private EventBusRectIndexData eventBusRectIndexData;


        private void OnValidate()
        {
            rect = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            itemButton.onClick.AddListener(OnButtonClicked);
        }

        private void Start()
        {
            colorPreview.color = colorPalette.colors[rectIndexData.index];
        }

        private void OnDisable()
        {
            itemButton.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            eventBusRectIndexData.Publish(rectIndexData);
        }
    }
}