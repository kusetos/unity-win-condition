using UnityEngine;
public interface IJumpModule
{
    void ProcessJump(Rigidbody rb, bool grounded, float deltaTime);
    void BufferJump();
}


[System.Serializable]
public class JumpModule : IJumpModule
{
    public float jumpForce = 7f;
    public float bufferTime = 0.12f;
    public float coyoteTime = 0.12f;
    private float lastPress = -99f;
    private float lastGround = -99f;


    public void BufferJump() => lastPress = Time.time;
    public void OnGrounded() => lastGround = Time.time;


    public void ProcessJump(Rigidbody rb, bool grounded, float dt)
    {
        if (grounded) OnGrounded();
        if ((Time.time - lastPress) <= bufferTime && (grounded || (Time.time - lastGround) <= coyoteTime))
        {
            Vector3 v = rb.linearVelocity;
            v.y = jumpForce;
            rb.linearVelocity = v;
            lastPress = -99f;
        }
    }
}
