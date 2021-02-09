using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealthManager : GenericHealthSystem
{
    public override void Damage(float amount)
    {
        base.Damage(amount);
        MaxHealth.RuntimeValue = CurrentHealth;
    }

    public override void Heal(float amount)
    {
        base.Heal(amount);
    }

}
