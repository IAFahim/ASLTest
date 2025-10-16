using System;
using UnityEngine;

namespace EventDatas.Runtime
    
{
    [Serializable]
    public struct RectIndexData
    {
        public RectTransform selfRectTransform;
        public int index;

        public void Assign(GameObject parent)
        {
            selfRectTransform = parent.GetComponent<RectTransform>();
        }
    }
}