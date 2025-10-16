using EventDatas.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace UIs
{
    public class TabComponent : MonoBehaviour
    {
        public int indexData;
        [SerializeField] private Button button;
        [SerializeField] private EventBusIndexData eventBusTabIndexData;

        private void OnValidate()
        {
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
            eventBusTabIndexData.Publish(indexData);
        }
    }
}