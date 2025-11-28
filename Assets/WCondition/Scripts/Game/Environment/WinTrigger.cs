using UnityEditor.Search;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public string target = "Player"; 
    public string scene = "next";
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == target)
        {
            LevelManager.Instance.EndLevel();
            LevelManager.Instance.GoToNextLevel(scene);
            
        }   
    }
}
