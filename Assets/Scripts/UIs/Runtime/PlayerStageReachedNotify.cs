using EventDatas.Runtime;
using TMPro;
using UnityEngine;

namespace UIs
{
    public class PlayerStageReachedNotify : MonoBehaviour
    {
        public GameObject container;
        public TMP_Text text;
        public string stringFormat;
        public EventBusIndexData playerStageReachedEvent;


        private void OnValidate()
        {
            stringFormat = text.text;
        }

        private void Start()
        {
            container.SetActive(false);
        }
        
        private void OnEnable()
        {
            playerStageReachedEvent.OnSelectionChanged += PlayerStageReachedEventOnOnSelectionChanged;
        }
        
        private void PlayerStageReachedEventOnOnSelectionChanged(int stage)
        {
            container.SetActive(true);
            text.text = string.Format(stringFormat, stage);
        }

        private void OnDisable()
        {
            playerStageReachedEvent.OnSelectionChanged -= PlayerStageReachedEventOnOnSelectionChanged;
        }
    }
}