using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/New Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}