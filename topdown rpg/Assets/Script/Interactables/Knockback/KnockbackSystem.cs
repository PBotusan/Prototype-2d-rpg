using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackSystem : MonoBehaviour
{
    /// <summary>
    /// Knockbak power
    /// </summary>
    [SerializeField] protected float knockback;

    /// <summary>
    /// The amount of damage done by enemy/player
    /// </summary>
    [SerializeField] protected float damageAmount;

    /// <summary>
    /// amount in seconds
    /// </summary>
    [SerializeField] protected float time = 0.25f;
}
