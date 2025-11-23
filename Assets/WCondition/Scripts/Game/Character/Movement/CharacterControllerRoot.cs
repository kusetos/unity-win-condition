using UnityEngine;

public class CharacterControllerRoot : MonoBehaviour
{
    public Rigidbody rb;
    public CapsuleCollider col;
    public IInputModule input;
    public GravityModule gravity = new GravityModule();
    public MovementModule movement = new MovementModule();
    public JumpModule jump = new JumpModule();
    public SlopeModule slope = new SlopeModule();
    public CrouchModule crouch = new CrouchModule();
    public LayerMask groundMask;


    public bool grounded;


    void Awake()
    {
        if (!rb) rb = GetComponent<Rigidbody>();
        if (!col) col = GetComponent<CapsuleCollider>();
        if (input == null) input = new MoveInputModule();
        rb.useGravity = false;
    }


    void Update()
    {
        if (input.JumpPressed()) jump.BufferJump();
        crouch.Set(input.CrouchHeld());
        crouch.UpdateCrouch(col, Time.deltaTime);
    }


    void FixedUpdate()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, out _, 1.1f, groundMask);
        Vector2 inp = input.GetMove();
        bool sprint = input.SprintHeld();


        gravity.ApplyGravity(rb, Time.fixedDeltaTime);
        movement.Move(rb, inp, grounded, sprint, crouch.IsCrouching, Time.fixedDeltaTime);
        jump.ProcessJump(rb, grounded, Time.fixedDeltaTime);
        slope.HandleSlope(rb, grounded, Time.fixedDeltaTime);
    }
}