using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefRangedAttack : EnemyController
{
    [SerializeField] GameObject projectile;

    [SerializeField] float fireDelay;
    [SerializeField] float time;

    [SerializeField] bool canFire = true;

    private void Update()
    {
        
    }

    /// <summary>
    /// calculates the difference between enemy and player.
    /// </summary>
    protected override void CalculateDistance()
    {
        var calculateDistance = Vector3.Distance(target.position, transform.position);

        if (calculateDistance <= followDistance && calculateDistance > attackDistance)
        {
           AttackPlayer();

            //run away from player
        }
        else
        {
            enemyRigidbody.velocity = Vector2.zero;
        }
    }

    /// <summary>
    /// Used to follow the player, the enemy moves to the player. And changes the state of the enemy to walk.
    /// </summary>
    protected void AttackPlayer()
    {
        if (stateMachine.currentState == EnemyState.IDLE || stateMachine.currentState == EnemyState.PATROL && stateMachine.currentState != EnemyState.STAGGER)
        {
            RangedAttackTimer();
            //run away from player 
            if (canFire)
            {
                // calculate the position of the player to attack him.
                Vector3 tempVector = target.transform.position - transform.position;
                //shoot projectile.
                GameObject currentProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
                currentProjectile.GetComponent<Projectile>().Launch(tempVector);
                canFire = false;
                stateMachine.ChangeState(EnemyState.CHASE);
            }
        }
    }

    /// <summary>
    /// Delay between attacks, timer counts down when starts to attack.
    /// </summary>
    private void RangedAttackTimer()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            canFire = true;
            time = fireDelay;
        }
    }
}
