using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    Key,
    Enemy,
    UnlockedDoor

}

public class Door : InteractableSystem
{

    [Header("Door Variables")]
    [SerializeField] DoorType thisDoorType;
    [SerializeField] bool open = false;
    [SerializeField] Inventory playerInventory;

    [SerializeField] SpriteRenderer doorSprite;
    [SerializeField] BoxCollider2D doorCollider;


    /// <summary>
    /// if interact == to the door type do something.
    /// </summary>
    private void Update()
    {
        if (Input.GetButtonDown("Interact") && thisDoorType == DoorType.Key)
        {
            if (playerInRange)
            {
                // check if player has keys in inventory
                if (playerInventory.NumberOfKeys > 0)
                {
                    // delete key from inventory
                    playerInventory.NumberOfKeys--;
                    OpenDoor();
                }
            }
        }        
    }

    /// <summary>
    /// Open the door, disable the doorsprite and disable the collider to let the player walk in.
    /// </summary>
    private void OpenDoor()
    {
        doorSprite.enabled = false;
        open = true;
        doorCollider.enabled = false;
    }

    private void CloseDoor()
    {

    }
}
