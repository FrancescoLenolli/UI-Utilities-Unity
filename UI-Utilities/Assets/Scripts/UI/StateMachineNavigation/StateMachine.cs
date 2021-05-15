using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField]
    private UIRoot ui;

    private BaseState currentState;

    public UIRoot UI { get => ui; }

    private void Start()
    {
        ChangeState(new MenuState());
    }

    private void Update()
    {
        if(currentState != null)
        {
            currentState.UpdateState();
        }
    }

    public void ChangeState(BaseState newState)
    {
        if(currentState != null)
        {
            currentState.DestroyState();
        }

        currentState = newState;

        if(currentState != null)
        {
            currentState.Owner = this;
            currentState.PrepareState();
        }
    }
}
