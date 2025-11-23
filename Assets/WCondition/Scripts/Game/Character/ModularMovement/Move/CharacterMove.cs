using UnityEngine;

[CreateAssetMenu(fileName = "CharacterMoveScript", menuName = "MovementScripts/CharacterMoveScript", order = 1)]

public class CharacterMove : MoveScriptable
{
    [SerializeField, Range(0, 200)]
    private float speed;
    [SerializeField, Range(0, 200)]
    private float accel = 40f;    
    
    [SerializeField, Range(0, 200)]
    private float airControl = 40f;

    // [SerializeField, Range(0, 200)]
    // private float decel = 30f;
    private CharacterController characterController;
    public override void Init(CharacterController controller)
    {
        characterController = controller;
    }
    private bool isGrounded = true;
    public override void Update(Vector3 direction)
    {


        Vector3 worldInput = direction.normalized;
        Vector3 desired = worldInput * speed;
        float a = isGrounded ? accel : accel * airControl;

        Vector3 delta = Vector3.ClampMagnitude(desired, a * Time.deltaTime);
        characterController.Move(delta);
    }
}
