using System.Collections.Generic;
using Customization.Runtime;
using EventDatas.Runtime;
using Pool.Runtime;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UIs
{
    public class ColorScrollView : MonoBehaviour
    {
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private RectTransform content;

        [SerializeField] private int scrollPrewarmCount;
        [SerializeField] private ColorButtonView colorButtonViewPrefab;

        [SerializeField] private CheckBox checkBox;
        
        [SerializeField] private ColorPalette[] colorPalettes;
        [SerializeField] private ColorPalette currentColorPalette;


        [FormerlySerializedAs("eventBusTabIndexData")] [SerializeField] private EventBusIndexData tabIndexEventData;
        [FormerlySerializedAs("eventBusTabIndexData")] [SerializeField] private EventBusRectIndexData colorRectIndexEventBus;

        private GameObjectPool _scrollItemPool;
        private List<ColorButtonView> activeColorButtonView;


        private void Awake()
        {
            _scrollItemPool = new GameObjectPool(colorButtonViewPrefab.gameObject);
            _scrollItemPool.Prewarm(scrollPrewarmCount);
            activeColorButtonView = new List<ColorButtonView>();
        }

        private void OnEnable()
        {
            tabIndexEventData.OnSelectionChanged += TabIndexEventDataOnOnSelectionChanged;
            colorRectIndexEventBus.OnSelectionChanged += OnColorChange;
            LoadColorPalette(currentColorPalette = colorPalettes[0]);
        }
        
        void OnColorChange(RectIndexData obj)
        {
            currentColorPalette.SaveColorIndex(obj.index);
            checkBox.Move(obj.selfRectTransform);
        }


        private void TabIndexEventDataOnOnSelectionChanged(int tabIndex)
        {
            ReturnToPool();
            currentColorPalette = colorPalettes[tabIndex];
            LoadColorPalette(currentColorPalette);
        }

        private void LoadColorPalette(ColorPalette colorPalette)
        {
            var loadedData = colorPalette.LoadColorIndex();
            
            for (int i = 0; i < colorPalette.colors.Length; i++)
            {
                var colorButtonView = _scrollItemPool.Request(content).GetComponent<ColorButtonView>();
                if (i == loadedData)
                {
                    checkBox.Move(colorButtonView.rectIndexData.selfRectTransform);
                }
                colorButtonView.Init(i, colorPalette);
                activeColorButtonView.Add(colorButtonView);
            }

            
            for (var i = 0; i < activeColorButtonView.Count; i++)
            {
                var colorButtonView = activeColorButtonView[i];
                colorButtonView.transform.SetSiblingIndex(colorButtonView.rectIndexData.index);
            }
            
        }

        private void ReturnToPool()
        {
            foreach (var colorButtonView in activeColorButtonView)
            {
                _scrollItemPool.Return(colorButtonView.gameObject);
            }
        }

        private void OnDisable()
        {
            ReturnToPool();
            tabIndexEventData.OnSelectionChanged -= TabIndexEventDataOnOnSelectionChanged;
            colorRectIndexEventBus.OnSelectionChanged -= OnColorChange;
        }

        private void OnDestroy()
        {
            _scrollItemPool.Dispose();
        }
    }
}