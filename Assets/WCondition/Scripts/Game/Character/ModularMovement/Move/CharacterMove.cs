using UnityEngine;

[CreateAssetMenu(fileName = "CharacterMoveScript", menuName = "MovementScripts/CharacterMoveScript", order = 1)]

public class CharacterMove : MoveScriptable
{
    [Header("Movement Settings")]
    [SerializeField, Range(0, 100)]
    private float speed;
    [SerializeField, Range(0, 100)]
    private float acceleration = 40f;        

    [SerializeField, Range(0, 100)]
    private float deceleration = 30f;    
    
    [SerializeField, Range(0, 1)]
    private float airControl = 40f;
    [Header("Jump Settings")]
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float jumpCooldown = 0.2f;
    [Header("Gravity Settings")]
    [SerializeField] private float gravity = -15f;
    [SerializeField] private float groundedGravity = -2f;
    private float verticalVelocity;

    private CharacterController characterController;
    private Vector3 currentVelocity;
    private Vector3 targetVelocity;
    private bool isGrounded;
    private float currentSpeed;
    private float lastJumpTime;
    public override void Init(CharacterController controller)
    {
        characterController = controller;
    }

    public override void Tick(Vector3 direction)
    {

        HandleGroundCheck();
        HandleGravity();

        targetVelocity = direction * speed;
        float interpolationRate = targetVelocity.magnitude > 0 ? acceleration : deceleration;
        if (!isGrounded) interpolationRate *= airControl;
        currentVelocity = Vector3.Lerp(currentVelocity, targetVelocity, interpolationRate * Time.deltaTime);
        
        currentSpeed = currentVelocity.magnitude;
        
        Vector3 movement = currentVelocity + Vector3.up * verticalVelocity;
        characterController.Move(movement * Time.deltaTime);

        HandleJump();

    }
    private void HandleGravity()
    {
        if (!isGrounded)
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
    }
    private void HandleGroundCheck()
    {
        isGrounded = characterController.isGrounded;
        
        if (isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = groundedGravity;
        }
    }
    private bool CanJump()
    {
        return isGrounded;// && Time.time >= lastJumpTime + jumpCooldown;
    }
    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && CanJump())
        {
            Jump();
        }
    }
    public void Jump()
    {
        Debug.Log("Jump");
        // Calculate jump velocity using physics formula: v = sqrt(2 * h * g)
        verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        //lastJumpTime = Time.time;
    }
}
