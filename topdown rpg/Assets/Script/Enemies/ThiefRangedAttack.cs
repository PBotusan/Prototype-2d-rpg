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
        time -= Time.deltaTime;
        if (fireDelay <=0)
        {
            canFire = true;
            time = fireDelay;
        }
    }

    /// <summary>
    /// calculates the difference between enemy and player.
    /// </summary>
    protected override void CalculateDistance()
    {
        var calculateDistance = Vector3.Distance(target.position, transform.position);

        if (calculateDistance <= followDistance && calculateDistance > attackDistance)
        {
            FollowPlayer();
        }
        else
        {
            enemyRigidbody.velocity = Vector2.zero;
        }
    }

    /// <summary>
    /// Used to follow the player, the enemy moves to the player. And changes the state of the enemy to walk.
    /// </summary>
    protected override void FollowPlayer()
    {
        if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
        {
            if (canFire)
            {
                // calculate the position of the player to attack him.
                Vector3 tempVector = target.transform.position - transform.position;
                //shoot projectile.
                GameObject currentProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
                currentProjectile.GetComponent<Projectile>().Launch(tempVector);
                canFire = false;
                ChangeState(EnemyState.walk);
            }
        }
    }
}
