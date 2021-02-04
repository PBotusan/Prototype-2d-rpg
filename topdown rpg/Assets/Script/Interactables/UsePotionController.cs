using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePotionController : MonoBehaviour
{
    [SerializeField] FloatValue playerStamina;
    [SerializeField] FloatValue heartContainers;
    [SerializeField] FloatValue playerHealth;

    [SerializeField] SignalSender staminaSignal;
    [SerializeField] SignalSender healthSignal;


    public void RedPotion(int amountHealth)
    {
        var maxHealth = heartContainers.RuntimeValue * 2;

        playerHealth.RuntimeValue += amountHealth;
        healthSignal.Raise();

        if (playerHealth.RuntimeValue > maxHealth)
        {
            playerHealth.RuntimeValue = maxHealth;
        }

    }

    public void GreenPotion(int amountHealth)
    {
        var maxHealth = heartContainers.RuntimeValue * 2;

        playerStamina.RuntimeValue += 100;
        playerHealth.RuntimeValue += amountHealth;
        staminaSignal.Raise();

        if (playerHealth.RuntimeValue > maxHealth)
        {
            playerHealth.RuntimeValue = maxHealth;
        }

    }
}
