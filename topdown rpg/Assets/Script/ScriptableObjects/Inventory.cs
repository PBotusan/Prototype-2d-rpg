using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    /// <summary>
    /// Used to store the item value as scriptable-object.
    /// </summary>
    [SerializeField] Item currentItem;

    /// <summary>
    /// list of items to store all the items the player has in his inventory.
    /// </summary>
    [SerializeField] List<Item> items = new List<Item>();

    /// <summary>
    /// The amount of keys the player has.
    /// </summary>
    [SerializeField] int numberOfKeys;

    public Item CurrentItem { get { return currentItem; } }

    public List<Item> Items { get { return items; } }

    public int NumberOfKeys { get { return numberOfKeys; } }
}
