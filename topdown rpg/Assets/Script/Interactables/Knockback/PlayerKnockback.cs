using DG.Tweening;
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
        if (collision.gameObject.CompareTag("Player") && collision.isTrigger)
        {
            Rigidbody2D target = collision.GetComponentInParent<Rigidbody2D>();
            if (target != null)
            {
                Vector3 difference = transform.position - collision.transform.position;
                difference = difference.normalized * knockback;
                target.DOMove(target.transform.position + difference, time);

                if (collision.GetComponentInParent<PlayerController>().currentPlayerState != PlayerState.stagger)
                {
                    target.GetComponentInParent<PlayerController>().currentPlayerState = PlayerState.stagger;
                    collision.GetComponentInParent<PlayerController>().KnockBack(time);
                }
            }
        }
    }
}
