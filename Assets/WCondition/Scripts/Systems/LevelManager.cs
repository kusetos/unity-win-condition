using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using NUnit.Framework.Constraints;
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    [SerializeField]
    private float delayAction;

    [Header("Events")]
    public UnityEvent onLevelStart;
    public UnityEvent onLevelRestart;
    public UnityEvent onLevelEnd;

    //public Text balance; 

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

    void Start()
    {
        StartLevel();
    }


    public void StartLevel()
    {   
        onLevelStart?.Invoke();
    }

    public void EndLevel()
    {
        Debug.Log("[LevelManager] Level complete!");
        onLevelEnd?.Invoke();
    }

    public void RestartLevel()
    {
        Debug.Log("[LevelManager] Restarting level...");
        onLevelRestart?.Invoke();

        StartCoroutine(
            DelayedAction(delayAction,
            () => 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name))
        );

    }
    
    public void GoToNextLevel(string nextSceneName)
    {
        Debug.Log($"[LevelManager] Loading next level: {nextSceneName}");
        StartCoroutine(
            DelayedAction(delayAction,
            () => SceneManager.LoadScene(nextSceneName)));
    }

    IEnumerator DelayedAction(float seconds, System.Action onComplete = null)
    {
        Debug.Log("Action started!");
        yield return new WaitForSeconds(seconds); // Wait for 3 seconds
        Debug.Log("Action resumed after " + seconds + " seconds!");
        onComplete?.Invoke();
    }
}
