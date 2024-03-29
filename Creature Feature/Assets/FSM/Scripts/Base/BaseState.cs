﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TransitionResponse
{
    public bool CanTransition;
}

[System.Serializable]
public class TransitionCheckEvent : UnityEvent<TransitionResponse> {}

[System.Serializable]
public class Transition
{
    public TransitionCheckEvent OnCanTransition; 
    public BaseState TargetState;
}

public class BaseState : MonoBehaviour
{
    public string StateID;
    public List<Transition> Transitions;

    protected TransitionResponse response = new TransitionResponse();

    public BaseState CheckTransitions()
    {
        // check each transition
        foreach(Transition transition in Transitions)
        {
            transition.OnCanTransition.Invoke(response);

            if (response.CanTransition)
            {
                return transition.TargetState;
            }
        }
        
        return null;
    }

    public virtual void State_Init()
    {

    }

    public virtual void State_Update()
    {

    }

    public virtual void State_Enter()
    {

    }

    public virtual void State_Exit()
    {

    }    
}
