using UnityEngine;

public class PlayerPlatformFix : MonoBehaviour
{
    private Transform activePlatform;
    private Vector3 lastPlatformPos;

    public void SetPlatform(Transform platform)
    {
        activePlatform = platform;

        if (platform != null)
            lastPlatformPos = platform.position;
    }

    void LateUpdate()
    {
        if (activePlatform == null) return;

        // Apply platform delta
        Vector3 delta = activePlatform.position - lastPlatformPos;
        transform.position += delta;

        lastPlatformPos = activePlatform.position;
    }
}
