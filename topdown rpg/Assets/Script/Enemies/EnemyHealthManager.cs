﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealthManager : GenericHealthSystem
{
    [SerializeField] EnemyController enemyController;

    [SerializeField] GameObject enemy;

    /// <summary>
    /// Drop Loot when dead.
    /// </summary>
    [SerializeField] LootTable loot;

    [Header("Death Signals")]
    [SerializeField] SignalSender roomSignal;

    private void OnEnable()
    {
        CurrentHealth = MaxHealth.InitialValue;
        enemyController.stateMachine.currentState = EnemyState.IDLE;
    }

    public override void Damage(float amount)
    {
        MaxHealth.RuntimeValue = CurrentHealth;
        CurrentHealth -= amount;
        

        if (MaxHealth.RuntimeValue <= 0)
        {
            //particles
            enemyController.stateMachine.currentState = EnemyState.DEAD;
            DropLoot();
            roomSignal.Raise();
            enemy.SetActive(false);
        }
       
    }

    public override void Heal(float amount)
    {
        base.Heal(amount);
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
