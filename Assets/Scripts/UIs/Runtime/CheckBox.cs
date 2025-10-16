using System;
using EventDatas.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace UIs
{
    public class CheckBox : MonoBehaviour
    {
        public RectTransform rect;
        public Image image;
        [SerializeField] private EventBusRectIndexData eventBusRectIndexData;

        private void OnValidate()
        {
            rect = GetComponent<RectTransform>();
            image = GetComponent<Image>();
        }

        private void Awake()
        {
            image.enabled = false;
        }

        private void OnEnable()
        {
            eventBusRectIndexData.OnSelectionChanged += OnSelectionChanged;
        }

        private void OnDisable()
        {
            eventBusRectIndexData.OnSelectionChanged -= OnSelectionChanged;
        }

        private void OnSelectionChanged(RectIndexData data)
        {
            image.enabled = true;
            Move(data.selfRectTransform);
        }

        public void Move(RectTransform target)
        {
            rect.position = target.position;
        }
    }
}