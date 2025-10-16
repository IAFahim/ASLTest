using Pool.Runtime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIs
{
    public class ScrollItemView : MonoBehaviour, IPoolCallbackReceiver
    {
        public RectCallBackData rectCallBackData;
        [SerializeField] private Image colorPreview;
        [SerializeField] private RectTransform rect;
        [SerializeField] private Button itemButton;
        [SerializeField] private Vector2 defaultPosition;

        [SerializeField] private UnityEvent<RectTransform> onClick;

        private void OnValidate()
        {
            rect = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            itemButton.onClick.AddListener(OnButtonClicked);
        }

        private void OnDisable()
        {
            itemButton.onClick.RemoveListener(OnButtonClicked);
        }

        public void Bind(RectTransform rectTransform)
        {
            rect = rectTransform;
        }

        private void OnButtonClicked()
        {
            onClick.Invoke(rect);
        }

        public void OnRequest()
        {
            gameObject.SetActive(true);
        }

        public void OnReturn()
        {
            Hide();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}