using Pathfinding;
using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Enum that stores all the enemy states.
/// </summary>
/*public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger,
    dead
}*/

public class EnemyController : MonoBehaviour
{
    /// <summary>
    /// The current state of the enemy
    /// </summary>
    public EnemyStateMachine stateMachine;

    bool patrol = false;

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

    Pathfinding.Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;
    public float nextWaypointDistance = 3;

    [SerializeField] Seeker seeker;



    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
        enemyRigidbody = GetComponent<Rigidbody2D>();
        //seeker = GetComponent<Seeker>();

        InvokeRepeating("UpdatePath", 0f, .5f);

    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(enemyRigidbody.position, target.position, OnPathComplete);
    }

    private void OnPathComplete(Path path)
    {
        if (!path.error)
        {
            this.path = path;
            currentWayPoint = 0;
        }
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
        if (path == null)
        {
            return;
        }

        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        var calculateDistance = Vector3.Distance(target.position, transform.position);

        if (calculateDistance <= followDistance && calculateDistance > attackDistance)
        {
            FollowPlayer();
        }
        else
        {
            Patrol();
        }

    }

    private void Patrol()
    {
        stateMachine.ChangeState(EnemyState.PATROL);
        
    }

    /// <summary>
    /// Used to follow the player, the enemy moves to the player. And changes the state of the enemy to walk.
    /// </summary>
    protected virtual void FollowPlayer()
    {
        if (stateMachine.currentState == EnemyState.IDLE || stateMachine.currentState == EnemyState.PATROL && stateMachine.currentState == EnemyState.CHASE || stateMachine.currentState != EnemyState.STAGGER)
        {
            // Vector3 temp = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
            //enemyRigidbody.MovePosition(temp);

            Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - enemyRigidbody.position).normalized;
            Vector2 force = direction * movementSpeed * Time.deltaTime;

            enemyRigidbody.AddForce(force);

            float distance = Vector2.Distance(enemyRigidbody.position, path.vectorPath[currentWayPoint]);
            if (distance < nextWaypointDistance)
            {
                currentWayPoint++;
            }

            stateMachine.ChangeState(EnemyState.CHASE);
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
        if (stateMachine.currentState != EnemyState.DEAD)
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
            stateMachine.ChangeState(EnemyState.IDLE);
        }
    }
}

