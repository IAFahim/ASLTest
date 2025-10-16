using System;
using UnityEngine;
using System.Collections;

public class FadeAndMoveUp : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float duration = 2f;
    [SerializeField] private float moveDistance = 100f;
    [SerializeField] private Vector3 startPos;

    private Coroutine coroutine;
    void OnEnable()
    {
        coroutine = StartCoroutine(AnimateCoroutine());
    }

    private void Awake()
    {
        startPos = transform.position - new Vector3(0, moveDistance, 0);
    }

    private IEnumerator AnimateCoroutine()
    {
        canvasGroup.alpha = 0f;
        Vector3 endPos = startPos + new Vector3(0, moveDistance*2, 0);
        
        float elapsed = 0f;
        float fadeInDuration = duration * 0.25f;
        float fadeOutStart = duration * 0.75f;
        
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            
            // Move upward
            transform.position = Vector3.Lerp(startPos, endPos, t);
            
            // Fade in then fade out
            if (elapsed < fadeInDuration)
            {
                canvasGroup.alpha = elapsed / fadeInDuration;
            }
            else if (elapsed > fadeOutStart)
            {
                float fadeOutT = (elapsed - fadeOutStart) / (duration - fadeOutStart);
                canvasGroup.alpha = 1f - fadeOutT;
            }
            else
            {
                canvasGroup.alpha = 1f;
            }
            
            yield return null;
        }
        
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        StopCoroutine(coroutine);
    }
}