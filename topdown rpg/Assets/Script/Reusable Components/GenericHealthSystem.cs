using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericHealthSystem : MonoBehaviour
{

    [SerializeField] FloatValue maxhealth;
    [SerializeField] FloatValue heartContainer;
    [SerializeField] float currentHealth;

    public FloatValue MaxHealth { get { return maxhealth; } set { maxhealth = value; } }
    public float CurrentHealth { get { return currentHealth; } set { currentHealth = value; } }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = heartContainer.RuntimeValue * 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Heal(float amount)
    {
        currentHealth += amount;

        if (currentHealth > maxhealth.RuntimeValue)
        {
            //reset currenthealth back to maxhealth
            currentHealth = maxhealth.RuntimeValue;
        }
    }

    public virtual void FullHeal()
    {
        currentHealth += maxhealth.RuntimeValue;        
    }

    public virtual void Damage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth < 0)
        {
            //dead
            currentHealth = 0;
        }
    }

    public virtual void InstantKill()
    {
        currentHealth = 0;
    }
}
