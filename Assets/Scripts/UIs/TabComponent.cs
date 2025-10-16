using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIs
{
    public class TabComponent : MonoBehaviour
    {
        public RectCallBackData rectCallBackData;
        [SerializeField] private Button button;
        [SerializeField] private EventBusRectCallBackData eventBusRectCallBackData;

        private void OnValidate()
        {
            rectCallBackData.Assign(gameObject);
            button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            button.onClick.AddListener(OnButtonClicked);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            eventBusRectCallBackData.PublishSelection(rectCallBackData);
        }
    }
}