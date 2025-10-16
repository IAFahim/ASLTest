using System;
using UnityEngine;

namespace UIs
{
    public class EventBus<T> : ScriptableObject
    {
        public EventBus<T> Instance { get; private set; }
        
        public event Action<T> OnSelectionChanged;

        private void Awake()
        {
            Instance = this;
        }

        public void PublishSelection(T data)
        {
            OnSelectionChanged?.Invoke(data);
        }
    }
}