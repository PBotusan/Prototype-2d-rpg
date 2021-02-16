using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DoorType
{
    Key,
    Enemy,
    Button,
    UnlockedDoor,
    PressurePlate
}

public class Door : InteractableSystem
{
    [Header("Door Variables")]
    [SerializeField] DoorType thisDoorType;
    [SerializeField] bool open = false;
    [SerializeField] Inventory playerInventory;
    [SerializeField] BoolValue doorState; 

    [Header("Sprite")]
    [SerializeField] SpriteRenderer doorSprite;
    [SerializeField] BoxCollider2D doorCollider;

    [Header("Dialog")]
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] string dialog;


    private void Start()
    {
        if (doorState.RuntimeValue)
        {
            OpenDoor();
        }
    }

    /// <summary>
    /// if interact == to the door type do something.
    /// </summary>
    private void Update()
    {
        if (Input.GetButtonDown("Interact") && thisDoorType == DoorType.Key)
        {
            KeyDoor();
        }

        if (Input.GetButtonDown("Interact") && thisDoorType == DoorType.UnlockedDoor)
        {
            OpenDoor();
        }

        if (Input.GetButtonDown("Interact") && thisDoorType == DoorType.PressurePlate)
        {
           // PressurePlate();
        }
    }

    private void PressurePlate()
    {
        if (playerInRange)
        {
            dialogBox.SetActive(true);
            dialogText.text = dialog;
        }
        else if (!playerInRange)
        {
            dialogBox.SetActive(false);
        }
    }

    private void KeyDoor()
    {
        if (playerInRange)
        {
            // check if player has keys in inventory
            if (playerInventory.NumberOfKeys > 0)
            {
                // delete key from inventory
                playerInventory.NumberOfKeys--;
                dialogBox.SetActive(false);
                doorState.RuntimeValue = true;
                OpenDoor();

            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
        else if (!playerInRange)
        {
            dialogBox.SetActive(false);
        }
    }

    /// <summary>
    /// Open the door, disable the doorsprite and disable the collider to let the player walk in.
    /// </summary>
    internal void OpenDoor()
    {
       
        doorSprite.enabled = false;
        open = true;
        doorCollider.enabled = false;
    }

    internal void CloseDoor()
    {
        doorSprite.enabled = true;
        open = false;
        doorCollider.enabled = true;
    }
}
