using EventDatas.Runtime;
using UnityEngine;

namespace UIs
{
    public class DefaultTabSettings : MonoBehaviour
    {
        public int defaultTab;
        [SerializeField] private EventBusIndexData eventTabIndexData;
        
        private void Start()
        {
            eventTabIndexData.Publish(defaultTab);
        }
    }
}