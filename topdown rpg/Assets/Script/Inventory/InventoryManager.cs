using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Information")]
    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] GameObject inventorySlot;
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] TextMeshProUGUI descriptionTextUI;
    [SerializeField] GameObject useButton;

    [SerializeField] InventoryItem currentItem;
    public InventoryItem CurrentItem { get {return currentItem; } set { currentItem = value; } }

    // Start is called before the first frame update
    void OnEnable()
    {
        ClearInventorySlots();
        MakeInventorySlots();
        SetTextAndButton("", false);
    }

    public void SetTextAndButton(string description, bool buttonActive)
    {
        descriptionTextUI.text = description;
        useButton.SetActive(buttonActive);
    }


    private void MakeInventorySlots()
    {
        if (playerInventory)
        {
            for (int i = 0; i < playerInventory.CurrentInventory.Count; i++)
            {
                if (playerInventory.CurrentInventory[i].NumberHold > 0)// make with few items that can remain. playerInventory.CurrentInventory[i].itemname == "itemname" 
                {
                    GameObject temp = Instantiate(inventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                    temp.transform.SetParent(inventoryPanel.transform);
                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                    if (newSlot)
                    {
                        newSlot.Setup(playerInventory.CurrentInventory[i], this);
                    }
                }
            }
        }
    }

    internal void SetupDescriptionAndButton(string description, bool buttonActive, InventoryItem selectedItem)
    {
        currentItem = selectedItem;
        descriptionTextUI.text = description;
        useButton.SetActive(buttonActive);
    }

    public void UseButton()
    {
        if (currentItem)
        {
            currentItem.Use();
            //Clear inventory slots
            ClearInventorySlots();
            //update invetory slots
            MakeInventorySlots();

            if (currentItem.NumberHold == 0)
            {
                SetTextAndButton("", false);
            }
        }
    }

    private void ClearInventorySlots()
    {
        for (int i = 0; i < inventoryPanel.transform.childCount; i++)
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }
}
