using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    /// <summary>
    /// Sprite to use to show item.
    /// </summary>
    [SerializeField] Sprite itemSprite;

    /// <summary>
    /// Descrption used as string to describe info about the item.
    /// </summary>
    [SerializeField] string itemDescription;

    /// <summary>
    /// If the item is an key make it true/false
    /// </summary>
    [SerializeField] bool isKey;

   
}
