using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    //private IInteractable _target;

    [SerializeField]
    private List<ActionHandler> _actions;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger Activated");
            
            foreach(var action in _actions){

                action.Invoke();
            }
        }
    }
}


// public interface IInteractable
// {
    
// }
