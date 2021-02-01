using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainer : PickUpController
{
    [SerializeField] FloatValue heartContainers;
    //partial 4/4;

    [SerializeField] FloatValue playerHealth;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.isTrigger)
        {
            heartContainers.RuntimeValue += 1;
            playerHealth.RuntimeValue = heartContainers.RuntimeValue * 2;
            PickUpSignal.Raise();
            Destroy(gameObject);
        }
    }

}
