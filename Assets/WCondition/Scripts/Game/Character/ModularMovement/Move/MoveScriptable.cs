using System;
using UnityEngine;

public abstract class MoveScriptable : ScriptableObject
{
    public abstract void Init(CharacterController characterController);
    public abstract void Update(Vector3 direction);

}