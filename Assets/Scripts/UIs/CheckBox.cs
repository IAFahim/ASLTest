using UnityEngine;

namespace UIs
{
    public class CheckBox : MonoBehaviour
    {
        public RectTransform rect;
        [SerializeField] private EventBusRectCallBackData eventBusRectCallBackData;

        private void OnValidate()
        {
            rect = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            eventBusRectCallBackData.OnSelectionChanged += OnSelectionChanged;
        }

        private void OnDisable()
        {
            eventBusRectCallBackData.OnSelectionChanged -= OnSelectionChanged;
        }

        private void OnSelectionChanged(RectCallBackData data)
        {
            Move(data.selfRectTransform);
        }

        public void Move(RectTransform target)
        {
            rect.position = target.position;
        }
    }
}