using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TextMeshProUGUI itemNumberText;
    [SerializeField] Image itemImage;

    [Header("Variables from item")]
    /// <summary>
    /// Item form inventoryItem class
    /// </summary>
    [SerializeField] InventoryItem item;
    [SerializeField] InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {

    }
    
    public void Setup(InventoryItem newItem, InventoryManager newManager)
    {
        item = newItem;
        inventoryManager = newManager;

        if (item)
        {
            itemImage.sprite = item.ItemImage;
            itemNumberText.text = item.NumberHold.ToString();
        }
    }


    public void ClickedOn()
    {
        if (item)
        {
            inventoryManager.SetupDescriptionAndButton(item.ItemDescription, item.Usable, item);
        }
    }

}
