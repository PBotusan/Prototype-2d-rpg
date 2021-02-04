using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/PlayerInventory")]
[System.Serializable]
public class PlayerInventory : ScriptableObject
{
    [SerializeField] List<InventoryItem> currentInventory = new List<InventoryItem>();

    public List<InventoryItem> CurrentInventory { get{ return currentInventory;} set{ currentInventory = value ;} }
}
