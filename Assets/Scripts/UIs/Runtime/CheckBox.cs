using UnityEngine;

namespace UIs
{
    public class CheckBox : MonoBehaviour
    {
        public RectTransform rect;

        private void OnValidate()
        {
            rect = GetComponent<RectTransform>();
        }

        public void Move(RectTransform target)
        {
            rect.parent = target;
            rect.position = target.position;
        }
    }
}