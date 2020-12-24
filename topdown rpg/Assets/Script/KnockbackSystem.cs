using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackSystem : MonoBehaviour
{
    [SerializeField] float knockback;

    [SerializeField] float damageAmount;

    public float time = 0.25f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D target = collision.GetComponent<Rigidbody2D>();
            if (target != null)
            {
                Vector2 difference = target.transform.position - transform.position;
                difference = difference.normalized * knockback;
                target.AddForce(difference, ForceMode2D.Impulse);

                if (collision.gameObject.CompareTag("Player"))
                {

                    if (collision.GetComponent<PlayerController>().currentPlayerState != PlayerState.stagger)
                    {
                        target.GetComponent<PlayerController>().currentPlayerState = PlayerState.stagger;
                        collision.GetComponent<PlayerController>().KnockBack(time, damageAmount);
                    }
                }

                if (collision.gameObject.CompareTag("Enemy") && collision.isTrigger)
                {  
                    target.GetComponent<EnemyController>().currentState = EnemyState.stagger;
                    collision.GetComponent<EnemyController>().KnockBack(target, time, damageAmount);
                }

            }
        }    
    }    
}
