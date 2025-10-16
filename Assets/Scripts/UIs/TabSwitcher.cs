using System;
using UnityEngine;

namespace UIs
{
    public class TabSwitcher : MonoBehaviour
    {
        [SerializeField] private int currentTab;
        [SerializeField] private TabComponent[] tabComponents;
        [SerializeField] private GameObject[] tabPanels;
        [SerializeField] private EventBusRectCallBackData eventBusRectCallBackData;

        private void OnEnable()
        {
            for (var i = 0; i < tabComponents.Length; i++)
            {
                tabComponents[i].rectCallBackData.index = i;
            }

            eventBusRectCallBackData.OnSelectionChanged += OnTabSelected;
            ShowTab(currentTab);
        }

        private void OnDisable()
        {
            eventBusRectCallBackData.OnSelectionChanged -= OnTabSelected;
        }

        private void OnTabSelected(RectCallBackData data)
        {
            ShowTab(data.index);
        }

        private void ShowTab(int index)
        {
            Debug.Log(index);
        }
    }
}