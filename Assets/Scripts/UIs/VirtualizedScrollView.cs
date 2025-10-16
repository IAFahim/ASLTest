using Pool.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace UIs
{
    public class VirtualizedScrollView : MonoBehaviour
    {
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private RectTransform content;

        [SerializeField] private int scrollPrewarmCount;
        [SerializeField] private ScrollItemView scrollItemViewPrefab;
        [SerializeField] private ScrollItemView[] activeScrollItemViews;
        private GameObjectPool _scrollItemPool;
        
        [Range(0, 1)] public int selectionIndex;
        public TabComponent[] tabComponent;
        [SerializeField] private CheckBox checkBox;

        private void Awake()
        {
            _scrollItemPool = new GameObjectPool(scrollItemViewPrefab.gameObject);
            _scrollItemPool.Prewarm(scrollPrewarmCount);
            activeScrollItemViews = new ScrollItemView[scrollPrewarmCount];
        }

        private void OnEnable()
        {
            for (int i = 0; i < scrollPrewarmCount; i++)
            {
                activeScrollItemViews[i] = _scrollItemPool.Request().GetComponent<ScrollItemView>();
                activeScrollItemViews[i].rectCallBackData.index = i;
            }

            for (var i = 0; i < tabComponent.Length; i++)
            {
                tabComponent[i].rectCallBackData.index = i;
            }
        }

        private void OnDisable()
        {
            foreach (var view in activeScrollItemViews)
            {
                _scrollItemPool.Return(view.gameObject);
            }
        }
    }
}