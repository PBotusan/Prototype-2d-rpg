using System;
using UnityEngine;

public class ThrowBomb : MonoBehaviour
{
    /// <summary>
    /// Instantiate the bomb.
    /// </summary>
    [SerializeField] GameObject bomb;

    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] InventoryItem item;

    [Header("Signals")]
    /// <summary>
    /// Use signal to update bomb UI;
    /// </summary>
    [SerializeField] SignalSender UpdateBombUI;


    // Start is called before the first frame update
    void Start()
    {
        

    }


    public void Setup(Vector2 playerPos)

    {
        if (playerInventory.CurrentInventory.Contains(item))
        {
            if (item.NumberHold > 0)
            {
                InstantiateBomb(playerPos);
            }
        }
        /*
        if (Input.GetButtonDown("ThrowBomb"))
        {
            if (playerInventory.CurrentInventory.Contains(item))
            {
                if (item.NumberHold > 0)
                {
                    InstantiateBomb();
                }
            }
           // if (playerInventory.CurrentInventory. > 0)
               // InstantiateBomb();
        }*/
    }

    private void InstantiateBomb(Vector2 playerPos)
    {
        Instantiate(bomb.gameObject, playerPos, Quaternion.identity);
        item.NumberHold -= 1;
        UpdateBombUI.Raise();
    }
}
