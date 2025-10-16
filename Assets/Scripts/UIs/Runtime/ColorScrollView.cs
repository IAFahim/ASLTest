using Customization.Runtime;
using EventDatas.Runtime;
using Pool.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace UIs
{
    public class ColorScrollView : MonoBehaviour
    {
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private RectTransform content;

        [SerializeField] private int scrollPrewarmCount;
        [SerializeField] private ColorButtonView colorButtonViewPrefab;
        private GameObjectPool _scrollItemPool;

        [SerializeField] private ColorPalette manColorPalette;
        [SerializeField] private ColorPalette islandColorPalette;

        [SerializeField] private EventBusIndexData eventBusTabIndexData;
        [SerializeField] private EventBusRectIndexData eventBusRectIndexData;


        private void Awake()
        {
            _scrollItemPool = new GameObjectPool(colorButtonViewPrefab.gameObject);
            _scrollItemPool.Prewarm(scrollPrewarmCount);
        }

        private void OnEnable()
        {
            eventBusTabIndexData.OnSelectionChanged += EventBusTabIndexDataOnOnSelectionChanged;
        }

        private void EventBusTabIndexDataOnOnSelectionChanged(int index)
        {
            if(index == 0) LoadManColorPalette();
            else if(index == 1) LoadManColorPalette();
        }

        private void LoadManColorPalette()
        {
            for (int i = 0; i < manColorPalette.colors.Length; i++)
            {
                var colorButtonView = _scrollItemPool.Request(content).GetComponent<ColorButtonView>();
                colorButtonView.rectIndexData.index = i;
                colorButtonView.colorPalette = manColorPalette;
            }
        }

        private void LoadIslandColorPalette()
        {
            for (int i = 0; i < islandColorPalette.colors.Length; i++)
            {
                var colorButtonView = _scrollItemPool.Request(content).GetComponent<ColorButtonView>();
                colorButtonView.rectIndexData.index = i;
                colorButtonView.colorPalette = manColorPalette;
            }
        }


        private void OnDisable()
        {
            eventBusTabIndexData.OnSelectionChanged -= EventBusTabIndexDataOnOnSelectionChanged;
            _scrollItemPool.Dispose();
        }
    }
}