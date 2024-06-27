using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePanel : MonoBehaviour
{
    private Tween fadeTween;


    [SerializeField] private CanvasGroup canvasGroup;
    
    void Start()
    {
        StartCoroutine(Panel());
    }

    private IEnumerator Panel()
    {
        yield return new WaitForSeconds(2f);
        FadeOut(1f);
        yield return new WaitForSeconds(3f);
        FadeIn(1f);
    }
    public void FadeIn(float duration)
    {
        Fade(1f, duration, () =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        });
    }

    public void FadeOut(float duration)
    {
        Fade(0f, duration, () =>
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        });
    }

    private void Fade(float endValue,float duration,TweenCallback onEnd)
    {
        if(fadeTween != null)
        {
            fadeTween.Kill(false);

        }
        fadeTween=canvasGroup.DOFade(endValue,duration);
        fadeTween.onComplete += onEnd;
    }
  
}
