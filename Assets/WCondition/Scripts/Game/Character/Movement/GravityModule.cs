using UnityEngine;

public interface IGravityModule
{
    void ApplyGravity(Rigidbody rb, float deltaTime);
}

[System.Serializable]
public class GravityModule : IGravityModule
{
    public float gravity = -24f;
    public void ApplyGravity(Rigidbody rb, float deltaTime)
    {
        Vector3 vel = rb.linearVelocity;
        vel.y += gravity * deltaTime;
        rb.linearVelocity = vel;
    }
}
