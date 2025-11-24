using UnityEngine;

[CreateAssetMenu(fileName = "CharacterInputScript", menuName = "InputScripts/MoveInputScript", order = 1)]
public class MoveInput : InputScriptable
{
    public override void Init()
    {
    }

    public override void Tick()
    {

    }
    public Vector3 GetDirection =>
        new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

    public void Jump()
    {
        
    }
    
}
