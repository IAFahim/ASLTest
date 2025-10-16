using UnityEngine;

namespace EventDatas.Runtime
{
    [CreateAssetMenu(fileName = "IndexData", menuName = "EventBus/IndexData")]
    public class EventBusIndexData : EventBus<int>
    {
    }
}