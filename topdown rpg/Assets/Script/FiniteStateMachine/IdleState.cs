using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="IdleState", menuName = "FiniteStateMachine/States/Idle", order =1)]
public class IdleState : AbstractFSMState
{
    public override bool EnterState()
    {
        base.EnterState();

        Debug.Log("Enter idle state");

        return true;
    }

    public override void UpdateState()
    {
        Debug.Log("Update IdleState");
    }

    public override bool ExitState()
    {
        base.ExitState();
        Debug.Log("Exit IdleState");
        return true;
    }
}
