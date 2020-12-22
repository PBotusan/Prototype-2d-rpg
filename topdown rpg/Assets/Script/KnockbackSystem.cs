using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackSystem : MonoBehaviour
{
    [SerializeField] float knockback;

    public float time;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
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

        }
    }

}
