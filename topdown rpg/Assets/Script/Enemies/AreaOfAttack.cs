using UnityEngine;

public class AreaOfAttack : EnemyController
{
    /// <summary>
    /// The boundary used for enemy.
    /// </summary>
    [SerializeField] Collider2D boundary;

    /// <summary>
    /// override  the base class method of the distance, change the distance for the new area of attack/walk.
    /// </summary>
     protected override void CalculateDistance()
     {
        var calculateDistance = Vector3.Distance(target.position, transform.position);
        // looks if the follow distance, attackdistance and is in the boundary.... attack/follow player.
        if (calculateDistance <= followDistance && calculateDistance > attackDistance && boundary.bounds.Contains(target.transform.position))
        {
            FollowPlayer();
        }
        else
        {
            enemyRigidbody.velocity = Vector2.zero;
        }

     }

    /// <summary>
    /// override the base class method, to change the way an enemy follows player.
    /// </summary>
    protected override void FollowPlayer()
    {
        if (stateMachine.currentState == EnemyState.IDLE || stateMachine.currentState == EnemyState.PATROL && stateMachine.currentState == EnemyState.CHASE || stateMachine.currentState != EnemyState.STAGGER)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);

            enemyRigidbody.MovePosition(temp);
            stateMachine.ChangeState(EnemyState.CHASE);
        }

    }

}
