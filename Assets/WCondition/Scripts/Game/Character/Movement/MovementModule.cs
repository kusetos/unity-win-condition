using UnityEngine;
public interface IMovementModule
{
    void Move(Rigidbody rb, Vector3 moveDir, bool grounded, bool sprinting, bool crouching, float deltaTime);
}


[System.Serializable]
public class MovementModule : IMovementModule
{
    public float walkSpeed = 3.5f;
    public float runSpeed = 6f;
    public float sprintSpeed = 9f;
    public float accel = 40f;
    public float decel = 30f;

    
    public float airControl = 0.6f;
    public float rotationSpeed = 12f;
    public Transform camera;


    public void Move(Rigidbody rb, Vector3 moveDir, bool grounded, bool sprinting, bool crouching, float dt)
    {
        float targetSpeed = walkSpeed;
        if (sprinting) targetSpeed = sprintSpeed;
        else if (moveDir.magnitude > 0.1f) targetSpeed = runSpeed;
        if (crouching) targetSpeed *= 0.6f;


        Vector3 camF = camera ? camera.forward : Vector3.forward;
        camF.y = 0; camF.Normalize();
        Vector3 camR = camera ? camera.right : Vector3.right;
        camR.y = 0; camR.Normalize();


        Vector3 worldInput = (camR * moveDir.x + camF * moveDir.y).normalized;
        Vector3 horizVel = rb.linearVelocity; horizVel.y = 0;
        Vector3 desired = worldInput * targetSpeed;
        float a = grounded ? accel : accel * airControl;


        Vector3 delta = Vector3.ClampMagnitude(desired - horizVel, a * dt);
        rb.linearVelocity = new Vector3(horizVel.x + delta.x, rb.linearVelocity.y, horizVel.z + delta.z);


        if (worldInput.sqrMagnitude > 0.01f)
        {
            Quaternion t = Quaternion.LookRotation(worldInput);
            rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, t, rotationSpeed * dt);
        }
    }
}