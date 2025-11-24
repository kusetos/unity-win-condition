using System.Diagnostics.Contracts;
using UnityEditor;
using UnityEngine;
public class MovementManager : MonoBehaviour
{
    [SerializeField]
    private CharacterController _controller;

    [SerializeField]
    private MoveScriptable _moveScript;

    [SerializeField]
    private MoveInput _input;

    public void Start()
    {
        _moveScript.Init(_controller);
        _input.Init();
    }
    [SerializeField]
    private float rotationSpeed;
    private void Update()
    {

        var input_dir = _input.GetDirection;
        _moveScript.Tick(input_dir);
        
        if (input_dir.magnitude > 0.1f) {
            Quaternion targetRot = Quaternion.LookRotation(input_dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }

    }
}
