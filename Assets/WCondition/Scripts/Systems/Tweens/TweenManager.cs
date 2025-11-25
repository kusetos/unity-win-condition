using UnityEngine;

public class TweenManager : MonoBehaviour
{
    public static TweenManager Instance { get; private set; }

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

    public void FadeIn()
    {
        
    }
    public void FadeOut()
    {
        
    }
}
///
/// 1. Event system
/// player -> interact, and start action
/// action -> start event
/// 
/// 