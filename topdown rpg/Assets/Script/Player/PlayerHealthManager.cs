using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthManager : GenericHealthSystem
{
    [SerializeField] SignalSender healthSignal;

    public override void Damage(float amount)
    {
        base.Damage(amount);
        MaxHealth.RuntimeValue = CurrentHealth;
        healthSignal.Raise();
    }

    public override void Heal(float amount)
    {
        base.Heal(amount);
    }


}
