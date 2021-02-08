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
            GenericHealthSystem damageCollisionObject = collision.GetComponent<GenericHealthSystem>();
            if (damageCollisionObject)
            {
                damageCollisionObject.Damage(amount);
            }
        }
    }
}
