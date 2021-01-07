using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : InteractableSystem
{
    /// <summary>
    /// Item stored in chest.
    /// </summary>
    [SerializeField] Item contents;

    [SerializeField] Inventory playerInventory;

    /// <summary>
    /// Show if chest is already opened.
    /// </summary>
    [SerializeField] bool open;

    /// <summary>
    /// Signalsender used to show the player item.
    /// </summary>
    [SerializeField] SignalSender raiseItem;

    /// <summary>
    /// Dialog enable/disable, to show item info.
    /// </summary>
    [SerializeField] GameObject dialogBox;

    /// <summary>
    /// Item info as string to show text.
    /// </summary>
    [SerializeField] Text dialogText;



    void Update()
    {
        if (Input.GetButtonDown("Interact") && playerInRange)
        {
            if (!open)
            {
                //Open the Chest
                OpenChest();
            }
            else
            {
                //Chest Already open
                UsedChest();
            }
        }
    }

    public void OpenChest()
    {
        dialogBox.SetActive(true);
       // dialogText.text = contents.itemDescription;

       // playerInventory.currentItem;


    }

    public void UsedChest()
    {

    }

}
