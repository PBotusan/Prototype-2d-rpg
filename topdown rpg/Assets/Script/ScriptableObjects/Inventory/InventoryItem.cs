using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]
public class InventoryItem : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] string itemDescription;
    [SerializeField] Sprite itemImage;
    [SerializeField] int numberHold;
    [SerializeField] bool usable;
    [SerializeField] bool unique;

    public string ItemName { get { return itemName; } set { itemName = value; } }
    public string ItemDescription { get { return itemDescription; } set { itemDescription = value; } }
    public Sprite ItemImage { get { return itemImage; } set { itemImage = value; } }
    public int NumberHold { get { return numberHold; } set { numberHold = value; } }
    public bool Usable { get { return usable; } set { usable = value; } }
    public bool Unique { get { return unique; } set { unique = value; } }
}
