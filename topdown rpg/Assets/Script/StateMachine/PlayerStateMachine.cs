using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// All the states used by player.
/// </summary>
public enum PlayerState
{
    idle,
    walk,
    run,
    attack,
    interact,
    stagger,
    ability
}


public class PlayerStateMachine : MonoBehaviour
{

    /// <summary>
    /// The current state of the player
    /// </summary>
    public PlayerState currentPlayerState;


    /// <summary>
    /// used to change the state of the enemy.
    /// </summary>
    /// <param name="newState"></param>
    internal void ChangeState(PlayerState newState)
    {
        if (currentPlayerState != newState)
        {
            currentPlayerState = newState;
        }
    }
}
