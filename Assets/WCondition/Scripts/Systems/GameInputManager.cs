using UnityEngine;

public class GameInputManager : MonoBehaviour
{
#region "Singleton"

    public static GameInputManager Instance { get; private set; }

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            LevelManager.Instance.RestartLevel();
        }
    }
}