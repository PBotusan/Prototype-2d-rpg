﻿using System.Collections;
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
    [SerializeField] bool chestOpen;

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

     [SerializeField] BoxCollider2D boxColliderTrigger;

    /// <summary>
    /// used as temporary way to shwo closed chest.
    /// </summary>
    [SerializeField] SpriteRenderer changeChestColor;


    void Update()
    {
        if (Input.GetButtonDown("Interact") && playerInRange)
        {
            if (!chestOpen)
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

    /// <summary>
    /// Opens chest, Dialog window on, and add item to inventory list. change dialog text of item show item.
    /// Raise two signals: raise item to show item and interaction
    /// </summary>
    public void OpenChest()
    {
        dialogBox.SetActive(true);
        dialogText.text = contents.ItemDescription;
        playerInventory.AddItem(contents);
        playerInventory.CurrentItem = contents;
        chestOpen = true;

        raiseItem.Raise();
        interaction.Raise();
    }

    public void UsedChest()
    {
        dialogBox.SetActive(false);
        interaction.Raise();
        raiseItem.Raise();
        boxColliderTrigger.enabled = false;
        changeChestColor.color = new Color(0f, 0f, 0f, 255f);
    }
}
