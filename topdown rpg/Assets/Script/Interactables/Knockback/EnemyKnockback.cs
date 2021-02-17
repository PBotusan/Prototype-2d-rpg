using UnityEngine;
using DG.Tweening;

public class EnemyKnockback : KnockbackSystem
{
    /// <summary>
    /// compares the tags and sends the correct value to the coroutine in player or enemy.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && collision.isTrigger)
        {
            Rigidbody2D target = collision.GetComponentInParent<Rigidbody2D>();
            if (target != null)
            {
                Vector3 difference = target.transform.position - transform.position;
                difference = difference.normalized * knockback;
                target.DOMove(target.transform.position + difference, time);

                target.GetComponentInParent<EnemyController>().stateMachine.ChangeState(EnemyState.STAGGER);
                collision.GetComponentInParent<EnemyController>().KnockBack(time);
            }
        }
    }
}
