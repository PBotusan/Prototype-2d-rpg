using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : PickUpController
{
    [SerializeField] FloatValue playerHealth;
    [SerializeField] FloatValue heartContainers;

    /// <summary>
    /// Amount of health to heal player
    /// </summary>
    [SerializeField] float amount;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerHealth.RuntimeValue += amount;
            
            // Looks if the playerhalth is not more than the amount of heartcontainers the player has. 2* because you can have half heart
            if (playerHealth.RuntimeValue > heartContainers.RuntimeValue * 2f)
            {
                playerHealth.RuntimeValue = heartContainers.RuntimeValue * 2f;
            }
            PickUpSignal.Raise();

            Destroy(this.gameObject);
        }
    }
}
