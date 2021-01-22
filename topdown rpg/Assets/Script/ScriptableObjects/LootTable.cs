using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Loot
{
    [SerializeField] internal PickUpController loot;
    [SerializeField] internal int lootChance;
}


[CreateAssetMenu]
public class LootTable : ScriptableObject
{
    [SerializeField] Loot[] loots;

    /// <summary>
    /// Calculate the droprates and drop item, based on percentage.
    /// </summary>
    [SerializeField] internal PickUpController pickUpLoot()
    {
        
        int cumaltiveProbability = 0;
        int currentProbability = Random.Range(0, 100);
        for (int i = 0; i < loots.Length; i++)
        {
            cumaltiveProbability += loots[i].lootChance;
            if (currentProbability <= cumaltiveProbability)
            {
                return loots[i].loot;
            }
        }

        return null;
    }



}
