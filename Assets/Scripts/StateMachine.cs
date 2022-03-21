using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public State currentState;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public abstract void InitializeState(State state);
    public abstract void SetState(State state);

}
