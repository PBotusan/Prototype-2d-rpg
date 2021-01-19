using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : KnockbackSystem
{
    /// <summary>
    /// compares the tags and sends the correct value to the coroutine in player or enemy.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D target = collision.GetComponent<Rigidbody2D>();
            if (target != null)
            {

                Vector2 difference = target.transform.position - transform.position;
                difference = difference.normalized * knockback;
                target.AddForce(difference, ForceMode2D.Impulse);

                if (collision.gameObject.CompareTag("Player") && collision.isTrigger)
                {
                    if (collision.GetComponent<PlayerController>().currentPlayerState != PlayerState.stagger)
                    {
                        target.GetComponent<PlayerController>().currentPlayerState = PlayerState.stagger;
                        collision.GetComponent<PlayerController>().KnockBack(time, damageAmount);
                    }
                }
            }
        }
    }
}
