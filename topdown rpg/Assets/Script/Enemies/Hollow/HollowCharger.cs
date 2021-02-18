using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollowCharger : EnemyController
{
    /// <summary>
    /// timer for charge attack
    /// </summary>
    float counter = 0f;
    float counterOldValue = 2.5f;

    float chargeSpeed = 25f;



    protected override void CalculateDistance()
    {
        var calculateDistance = Vector3.Distance(target.position, transform.position);

        if (calculateDistance <= followDistance && calculateDistance > attackDistance)
        {
            counter -= Time.deltaTime;
            if (counter < 0)
            {
                ChargePlayer();
            }
            else
            {
                FollowPlayer();
            }

        }
        else
        {
            counter = counterOldValue;
            //patrol
            
            stateMachine.ChangeState(EnemyState.PATROL);
            enemyRigidbody.velocity = Vector2.zero;
        }

    }

    /// <summary>
    /// Used to follow the player, the enemy moves to the player. And changes the state of the enemy to walk.
    /// </summary>
    protected void ChargePlayer()
    {
        if (stateMachine.currentState == EnemyState.IDLE || stateMachine.currentState == EnemyState.PATROL && stateMachine.currentState == EnemyState.CHASE || stateMachine.currentState != EnemyState.STAGGER)
        {
            StartCoroutine(ChargeCoroutine());
        }

    }

    private IEnumerator ChargeCoroutine()
    {
        Vector3 temp = Vector3.MoveTowards(transform.position, target.position, chargeSpeed * Time.deltaTime);
        enemyRigidbody.MovePosition(temp);
        stateMachine.ChangeState(EnemyState.CHASE);
        yield return new WaitForSeconds(1);
        counter = counterOldValue;
    }
}
