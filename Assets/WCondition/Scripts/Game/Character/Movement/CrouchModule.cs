using UnityEngine;



public interface ICrouchModule
{
    bool IsCrouching { get; }
    void UpdateCrouch(CapsuleCollider col, float deltaTime);
}

[System.Serializable]
public class CrouchModule : ICrouchModule
{
    public float multiplier = 0.5f;
    public float speed = 8f;
    public bool IsCrouching { get; private set; }
    private float originalH;
    private Vector3 originalC;
    private bool initialized = false;


    public void Set(bool c) => IsCrouching = c;


    public void UpdateCrouch(CapsuleCollider col, float dt)
    {
        if (!initialized) { originalH = col.height; originalC = col.center; initialized = true; }
        float tH = IsCrouching ? originalH * multiplier : originalH;
        col.height = Mathf.Lerp(col.height, tH, dt * speed);
        col.center = Vector3.Lerp(col.center, new Vector3(originalC.x, tH / 2f, originalC.z), dt * speed);
    }
}