using System;
using UnityEngine;

namespace UIs
{
    [Serializable]
    public struct RectCallBackData
    {
        public int index;
        public RectTransform selfRectTransform;

        public void Assign(GameObject parent)
        {
            selfRectTransform = parent.GetComponent<RectTransform>();
        }
    }
}