using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItemOnHitController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Breakable") && collision.isTrigger)
        {
            collision.GetComponent<BreakableObjectsController>().DestroyPot();
        }

        /* // this will work when i rework the sword collider, problem is that its reacting to my sword it always active, ez bugfix
        if (collision.CompareTag("Bomb") && collision.isTrigger)
        {
            collision.GetComponent<ExplodeBomb>().Explode();

        }*/ 
    }
}
