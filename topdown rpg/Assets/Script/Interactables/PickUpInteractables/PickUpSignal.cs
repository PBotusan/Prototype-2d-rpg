using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSignal : MonoBehaviour
{
    [SerializeField] SignalSender pickUpSignalSender;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            //add item to inventory
            pickUpSignalSender.Raise();
            Destroy(gameObject); 
        }
    }

}
