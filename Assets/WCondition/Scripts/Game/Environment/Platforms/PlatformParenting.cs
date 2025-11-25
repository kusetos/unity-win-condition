using UnityEngine;

public class PlatformParenting : MonoBehaviour
{
    [SerializeField]
    private string target = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(target))
        {
            other.GetComponent<PlayerPlatformFix>().SetPlatform(transform);        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(target))
        {
            other.GetComponent<PlayerPlatformFix>().SetPlatform(null);

        }
    }
    
}

