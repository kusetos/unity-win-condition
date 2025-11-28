using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TweenManager : MonoBehaviour
{
    public static TweenManager Instance { get; private set; }
    private Tween currentTween;

    void Awake()
    {
        // Singleton pattern (scene-only)
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void KillTween()
    {
        if (currentTween != null && currentTween.IsActive())
            currentTween.Kill();
    }
    public void FadeInPanel(Image panel, float fadeDuration)
    {
        KillTween();

        currentTween = panel
            .DOFade(1f, fadeDuration)
            .SetUpdate(true);   
    }
    public void FadeOutPanel(Image panel, float fadeDuration)
    {
        KillTween();

        currentTween = panel
            .DOFade(0f, fadeDuration)
            .SetUpdate(true);   
    }

        public void MoveUIElement(
        RectTransform element,
        Vector2 startPos,
        Vector2 endPos,
        float transitionDuration)
    {
        KillTween();

        // Ensure starting position is set immediately
        element.anchoredPosition = startPos;

        currentTween = element
            .DOAnchorPos(endPos, transitionDuration)
            .SetEase(Ease.OutCubic)   // can be changed or exposed
            .SetUpdate(true);
    }
}


///
/// 1. Event system
/// player -> interact, and start action
/// action -> start event
/// 
/// 