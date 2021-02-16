using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class GenericDamageSystem : MonoBehaviour
{
    /// <summary>
    /// amount of damage
    /// </summary>
    [SerializeField] float amount;
    [SerializeField] string otherTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(otherTag) && collision.isTrigger)
        {

            if (otherTag == "Player")
            {
                GenericHealthSystem damageCollisionObject = collision.GetComponent<GenericHealthSystem>();
                DamagePlayer(damageCollisionObject);

            }
            else if (otherTag == "Enemy")
            {
                EnemyHealthManager damageCollisionObject = collision.GetComponent<EnemyHealthManager>();
                DamageEnemy(damageCollisionObject);
            }
            else
            {
                return;
            }        
        }
    }

    void DamagePlayer(GenericHealthSystem _damageCollisionObject)
    {
        Debug.Log("damageCollisionobject = " + _damageCollisionObject);
        if (_damageCollisionObject)
        {
            _damageCollisionObject.Damage(amount);
        }
    }

    void DamageEnemy(EnemyHealthManager _damageCollisionObject)
    {
        Debug.Log("damageCollisionobject = " + _damageCollisionObject);
        if (_damageCollisionObject)
        {
            _damageCollisionObject.Damage(amount);
        }
    }
}
