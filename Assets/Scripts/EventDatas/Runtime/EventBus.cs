using System;
using UnityEngine;

namespace EventDatas.Runtime
{
    public class EventBus<T> : ScriptableObject
    {
        [SerializeField] public T debugData;
        public event Action<T> OnSelectionChanged;

        public void Publish(T data)
        {
            debugData = data;
            OnSelectionChanged?.Invoke(debugData);
        }
    }
}