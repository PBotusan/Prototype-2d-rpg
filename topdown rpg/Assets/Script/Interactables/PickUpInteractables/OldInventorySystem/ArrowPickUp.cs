using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPickUp : PickUpController
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            //add coin to inventory
           // playerInventory.Arrows += 1;
            PickUpSignal.Raise();
            Destroy(this.gameObject); //destroy after pickup
        }
    }
}
