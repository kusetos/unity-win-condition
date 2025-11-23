using UnityEngine;
public interface ISlopeModule
{
    void HandleSlope(Rigidbody rb, bool grounded, float deltaTime);
}

[System.Serializable]
public class SlopeModule : ISlopeModule
{
    public float maxSlope = 45f;
    public float slideSpeed = 6f;
    public LayerMask groundMask;
    public Vector3 offset = new Vector3(0, -0.9f, 0);


    public void HandleSlope(Rigidbody rb, bool grounded, float dt)
    {
        if (!grounded) return;
        if (Physics.Raycast(rb.transform.position + offset, Vector3.down, out RaycastHit h, 1f, groundMask))
        {
            float slope = Vector3.Angle(h.normal, Vector3.up);
            if (slope > maxSlope)
            {
                Vector3 slideDir = Vector3.ProjectOnPlane(Vector3.down, h.normal).normalized;
                rb.linearVelocity += slideDir * slideSpeed * dt;
            }
        }
    }
}