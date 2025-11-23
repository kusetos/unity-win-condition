using UnityEngine;
public interface IInputModule
{
    Vector2 GetMove();
    bool JumpPressed();
    bool SprintHeld();
    bool CrouchHeld();
}
public class MoveInputModule : IInputModule
{
    public string horizontal = "Horizontal";
    public string vertical = "Vertical";
    public KeyCode jump = KeyCode.Space;
    public KeyCode sprint = KeyCode.LeftShift;
    public KeyCode crouch = KeyCode.LeftControl;
    public Vector2 GetMove() => new Vector2(Input.GetAxisRaw(horizontal), Input.GetAxisRaw(vertical));
    public bool JumpPressed() => Input.GetKeyDown(jump);
    public bool SprintHeld() => Input.GetKey(sprint);
    public bool CrouchHeld() => Input.GetKey(crouch);
}