using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
#region "Singleton"

    public static GameUIManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
#endregion

#region "Fade Panel"

    [Header("Fade Panel")]
    [SerializeField]
    private Image _fadePanel;
    [SerializeField]
    private float _fadeDuration;    
    [SerializeField]
    private Color _fadeColor = new Color(0, 0, 0, 1f);

#endregion
    
    public void Start()
    {
        _fadePanel.color = _fadeColor;
        LevelManager.Instance.onLevelStart.AddListener(() => FadeOutPanel());
        LevelManager.Instance.onLevelRestart.AddListener(() => FadeInPanel());
        LevelManager.Instance.onLevelEnd.AddListener(() => FadeInPanel());
    }
    public void FadeInPanel()
    {
        TweenManager
                    .Instance
                    .FadeInPanel(_fadePanel, _fadeDuration);        // StartCoroutine(
        //     DelayedAction(
        //         0, 
        //         () => 
        //     );
    }    
    public void FadeOutPanel()
    {
        StartCoroutine(
            DelayedAction(
                0.3f, 
                () => TweenManager
                    .Instance
                    .FadeOutPanel(_fadePanel, _fadeDuration))
            );
    }

    IEnumerator DelayedAction(float seconds, System.Action onComplete = null)
    {
        Debug.Log("Action started!");
        yield return new WaitForSeconds(seconds); // Wait for 3 seconds
        Debug.Log("Action resumed after " + seconds + " seconds!");
        onComplete?.Invoke();
    }
}
