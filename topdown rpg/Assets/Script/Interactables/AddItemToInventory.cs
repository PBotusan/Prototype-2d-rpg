using UnityEngine;

public class AddItemToInventory : MonoBehaviour
{
    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] InventoryItem item;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
            AddItemInventory();
            Destroy(gameObject); // can also disable
        }
    }

    private void AddItemInventory()
    {
        if (playerInventory && item)
        {
            if (playerInventory.CurrentInventory.Contains(item))
            {
                item.NumberHold += 1;
            }
            else
            {
                playerInventory.CurrentInventory.Add(item);
                item.NumberHold += 1;
            }
        }
    }
}
