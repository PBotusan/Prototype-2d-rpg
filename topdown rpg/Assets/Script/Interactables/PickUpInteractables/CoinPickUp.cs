﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : PickUpController
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            //add coin to inventory
            //playerInventory.Coins += 1;
            PickUpSignal.Raise();
            Destroy(this.gameObject); //destroy after pickup
        }
    }
}
