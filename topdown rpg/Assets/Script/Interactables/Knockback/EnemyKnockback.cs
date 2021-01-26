using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : KnockbackSystem
{
    /// <summary>
    /// compares the tags and sends the correct value to the coroutine in player or enemy.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D target = collision.GetComponent<Rigidbody2D>();
            if (target != null)
            {
                Vector2 difference = target.transform.position - transform.position;
                difference = difference.normalized * knockback;
                target.AddForce(difference, ForceMode2D.Impulse);

                target.GetComponent<EnemyController>().currentState = EnemyState.stagger;
                collision.GetComponent<EnemyController>().KnockBack(target, time, damageAmount);
            }
        }
    }
}
