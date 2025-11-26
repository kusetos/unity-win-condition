using System.Collections;
using DG.Tweening;
using UnityEngine;

public class SpinningPlatform : MonoBehaviour, IGameAciton
{
    [Header("Rotation Settings")]
    public Vector3 rotationAmount = new Vector3(0, 90, 0); 
    public float duration = 1.2f;
    public Ease ease = Ease.OutCubic;   

    private bool isBusy;
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    public void InvokeGameAction()
    {
        RotateOnce();
    }

    public void RotateOnce()
    {
        if (isBusy) return;
        isBusy = true;

        // target rotation
        Quaternion targetRotation = initialRotation * Quaternion.Euler(rotationAmount);

        // tween
        transform
            .DORotateQuaternion(targetRotation, duration)
            .SetEase(ease)
            .OnComplete(() =>
            {
                initialRotation = targetRotation;
                isBusy = false;
            });
    }
}
