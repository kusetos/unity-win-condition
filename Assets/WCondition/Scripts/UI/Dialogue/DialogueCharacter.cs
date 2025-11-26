using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Dialogue/New Character", order = 1)]
public class DialogueCharacter : ScriptableObject
{
    public string Name;
    public GameObject prefab;
}
