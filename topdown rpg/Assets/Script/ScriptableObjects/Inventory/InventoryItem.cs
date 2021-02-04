using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]
public class InventoryItem : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] string itemDescription;
    [SerializeField] Sprite itemImage;
    [SerializeField] int numberHold;
    [SerializeField] bool usable;
    [SerializeField] bool unique;
    [SerializeField] UnityEvent unityEvent;

    public string ItemName { get { return itemName; } set { itemName = value; } }
    public string ItemDescription { get { return itemDescription; } set { itemDescription = value; } }
    public Sprite ItemImage { get { return itemImage; } set { itemImage = value; } }
    public int NumberHold { get { return numberHold; } set { numberHold = value; } }
    public bool Usable { get { return usable; } set { usable = value; } }
    public bool Unique { get { return unique; } set { unique = value; } }
    public UnityEvent UnityEvent { get { return unityEvent; } set { unityEvent = value; } }


    public void Use()
    {
        unityEvent.Invoke();
    }

    public void DecreaseAmount(int amount)
    {
        numberHold -= amount;

        if (numberHold < 0)
        {
            numberHold = 0;
        }
    }
}
