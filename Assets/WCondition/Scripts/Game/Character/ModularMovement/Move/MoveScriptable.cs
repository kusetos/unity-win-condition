using System;
using UnityEngine;

public abstract class MoveScriptable : ScriptableObject
{
    public abstract void Init(CharacterController characterController);
    public abstract void Tick(Vector3 direction);

}