using EventDatas.Runtime;
using UnityEngine;

namespace UIs
{
    public class DefaultTabSettings : MonoBehaviour
    {
        public int defaultTab;
        [SerializeField] private EventBusIndexData tabIndexEventData;
        
        private void Start()
        {
            tabIndexEventData.Publish(defaultTab);
        }
    }
}