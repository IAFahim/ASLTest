using UnityEngine;

namespace UIs
{
    public class TabComponent : MonoBehaviour
    {
        public RectCallBackData rectCallBackData;

        private void OnValidate()
        {
            rectCallBackData.Assign(gameObject);
        }
    }
}