using System.Collections.Generic;
using UnityEngine;

public class GameActionTrigger : MonoBehaviour
{
    // [RequireInterface(typeof(IGameAciton))]
    // public MonoBehaviour _example;
    [SerializeField]
    private string target = "Player";

    [SerializeField]
    private List<InterfaceReference<IGameAciton>> _actions;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(target))
        {
            Debug.Log("Trigger Activated");
            
            foreach(var action in _actions){
                action.Value.InvokeGameAction();
            }           
        }
    }
}


// public interface IInteractable
// {
    
// }
