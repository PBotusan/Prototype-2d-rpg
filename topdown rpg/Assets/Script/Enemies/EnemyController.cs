using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enum that stores all the enemy states.
/// </summary>
public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger,
    dead
}

public class EnemyController : MonoBehaviour
{
    /// <summary>
    /// The current state of the enemy
    /// </summary>
    public EnemyState currentState;

    /// <summary>
    /// Movementspeed used for walking enemy.
    /// </summary>
    [SerializeField] protected float movementSpeed = 3.5f;


    /// <summary>
    /// target/player transform, used to follow the player target position.
    /// </summary>
    [SerializeField] protected Transform target;

    /// <summary>
    /// Enemy rigidbody used to move the enemy
    /// </summary>
    [SerializeField] protected Rigidbody2D enemyRigidbody;

    /// <summary>
    /// Damage done by enemy
    /// </summary>
    [SerializeField] protected float attackDamage = 2;

    /// <summary>
    /// float value used as distance for following.
    /// </summary>
    [SerializeField] protected float followDistance = 8;
   

    /// <summary>
    /// attackdistance that the enemy stops with following. used to  not come to close to push the player.
    /// </summary>
    [SerializeField] protected float attackDistance = 0.75f;

    /// <summary>
    /// amount used as parameter. can be used for time or damage.
    /// </summary>
    protected float amount;


    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateDistance();
    }


    /// <summary>
    /// calculates the difference between enemy and player.
    /// </summary>
    protected virtual void CalculateDistance()
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
    protected virtual void FollowPlayer()
    {
        if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);

            enemyRigidbody.MovePosition(temp);
            ChangeState(EnemyState.walk);
        }

    }

   
    /// <summary>
    /// used to change the state of the enemy.
    /// </summary>
    /// <param name="newState"></param>
    protected virtual void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }


    /// <summary>
    /// starts the coroutine.
    /// </summary>
    /// <param name="enemyRigidbody"> enemyrigidbody</param>
    /// <param name="time"> duration in seconds </param>
    /// <param name="damageAmount"> amount of damage.</param>
    public void KnockBack(float time)
    {
        if (currentState != EnemyState.dead)
        {
            StartCoroutine(KnockBackTime(time));
        }
    }

    /// <summary>
    /// Knockback time coroutine. puts enemy on idle after the staggered state 
    /// </summary>
    /// <param name="enemyRigidbody"> enemyrigidbody</param>
    /// <param name="time"> duration in seconds </param>
    /// <returns></returns>
    private IEnumerator KnockBackTime(float time)
    {
        if (enemyRigidbody != null)
        {
            yield return new WaitForSeconds(time);
            enemyRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
        }
    }
}

