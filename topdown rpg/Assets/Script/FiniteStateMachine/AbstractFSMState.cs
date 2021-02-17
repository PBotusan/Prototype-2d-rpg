using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExcecutionState
{
    NONE,
    ACTIVE,
    COMPLETED,
    TERMINATED    
}

public abstract class AbstractFSMState : ScriptableObject
{
    public ExcecutionState ExcecutionState { get; protected set;}

    public virtual void OnEnable()
    {
        ExcecutionState = ExcecutionState.NONE;
    }

    /// <summary>
    /// enters the firstState/
    /// </summary>
    public virtual bool EnterState()
    {
        ExcecutionState = ExcecutionState.ACTIVE;
        return true;
    }

    public abstract void UpdateState();

    public virtual bool ExitState()
    {
        ExcecutionState = ExcecutionState.COMPLETED;
        return true;
    }

}
