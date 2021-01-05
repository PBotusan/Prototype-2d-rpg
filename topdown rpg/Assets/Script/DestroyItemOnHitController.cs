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
    }
}
