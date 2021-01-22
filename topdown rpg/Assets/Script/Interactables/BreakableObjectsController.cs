using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjectsController : MonoBehaviour
{
    Animator animator;
    BoxCollider2D boxCollider2D;

    /// <summary>
    /// Drop Loot when destroyed.
    /// </summary>
    [SerializeField] LootTable loot;

    bool alreadyDestroyed = false;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }


    /// <summary>
    /// on trigger enter used to break objects.
    /// </summary>
    public void DestroyPot()
    {
        animator.SetBool("Destroyed", true);
        boxCollider2D.enabled = false;
        if (!alreadyDestroyed)
        {
            alreadyDestroyed = true;
            DropLoot();
        }
       
        Debug.Log("BreakableObject");
    }

    private void DropLoot()
    {
        if (loot != null)
        {
            PickUpController current = loot.pickUpLoot();
            if (current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }
}
