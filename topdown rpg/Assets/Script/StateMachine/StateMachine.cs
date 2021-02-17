using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    IDLE,
    CHASE,
    PATROL,
    ATTACK,
    STAGGER,
    DEAD
}

public class StateMachine : MonoBehaviour
{
    /// <summary>
    /// The current state of the enemy
    /// </summary>
    public EnemyState currentState;

    /// <summary>
    /// used to change the state of the enemy.
    /// </summary>
    /// <param name="newState"></param>
    internal void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
