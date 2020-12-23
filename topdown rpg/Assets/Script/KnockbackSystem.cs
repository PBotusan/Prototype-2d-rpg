using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackSystem : MonoBehaviour
{
    [SerializeField] float knockback;

    public float time;

    [SerializeField] EnemyController enemyController;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                enemyController.currentState = EnemyState.stagger;

                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * knockback;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockBackTime(enemy));
            }

        }    
    }

    private IEnumerator KnockBackTime(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(time);
            enemy.velocity = Vector2.zero;
            enemyController.currentState = EnemyState.idle;
        }
    }
}
