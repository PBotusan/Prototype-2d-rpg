using UnityEngine;
using TMPro;

public class CoinTextManager : MonoBehaviour
{
    /// <summary>
    /// The inventory, used to show the amount of coins stored in inventory
    /// </summary>
    [SerializeField] Inventory playerInventory;

    /// <summary>
    /// Update GUI to show coin amount.
    /// </summary>
    [SerializeField] TextMeshProUGUI coinText;


    public void UpdateCoinText()
    {
        coinText.text = "" + playerInventory.Coins;
    }

}
