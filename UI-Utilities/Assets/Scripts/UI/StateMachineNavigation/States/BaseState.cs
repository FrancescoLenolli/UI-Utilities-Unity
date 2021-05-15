using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    private StateMachine owner;

    public StateMachine Owner { get => owner; set => owner = value; }

    public virtual void PrepareState() { }
    public virtual void UpdateState() { }
    public virtual void DestroyState() { }
}
