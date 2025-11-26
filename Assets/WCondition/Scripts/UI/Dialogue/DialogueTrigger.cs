using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;



public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public string target = "Player"; 

    public bool isLoop = true;
    public bool isStart = false;
    public void Start()
    {
        if (isStart)
            InvokeDialogue();
    }
    public void InvokeDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == target)
        {
            Debug.Log("activate Dialogue Trigger");
            InvokeDialogue();

            if (isLoop)
                this.gameObject.GetComponent<Collider>().enabled = false;
        }   
    }
}
