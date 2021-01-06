using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjectsController : MonoBehaviour
{
    Animator animator;
    BoxCollider2D boxCollider2D;

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
        Debug.Log("BreakableObject");
    }
}
