using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State currentState;
    private State previousState;
    private State defaultState;

    public void ChangeState(State newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }
        previousState = currentState;
        currentState = newState;
        currentState.Enter();
    }

    public void SetDefaultState(State state)
    {
        defaultState = state;
        ChangeState(defaultState);
    }

    public void SetPreviousState()
    {
        if(previousState != null)
            ChangeState(previousState);
    }

    void Update()
    {
        currentState?.Execute();
    }
}
