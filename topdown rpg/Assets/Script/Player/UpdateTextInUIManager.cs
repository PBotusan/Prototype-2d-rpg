using UnityEngine;
using TMPro;

public class UpdateTextInUIManager : MonoBehaviour
{
    /// <summary>
    /// The inventory, used to show the amount of coins stored in inventory
    /// </summary>
    [SerializeField] Inventory playerInventory;

    /// <summary>
    /// Update GUI to show coin amount.
    /// </summary>
    [SerializeField] TextMeshProUGUI uiTextCoin;
    [SerializeField] TextMeshProUGUI uiTextArrows;
    [SerializeField] TextMeshProUGUI uiTextBombs;


    [SerializeField] InventoryItem coins;
    [SerializeField] InventoryItem arrows;
    [SerializeField] InventoryItem bombs;

    private void Start()
    {
        uiTextCoin.text = "" + coins.NumberHold;
        uiTextArrows.text = "" + arrows.NumberHold;
        uiTextBombs.text = "" + bombs.NumberHold;
    }

    public void UpdateCoinText()
    {
        uiTextCoin.text = "" + coins.NumberHold;
    }

    public void UpdateArrowText()
    {
        uiTextArrows.text = "" + arrows.NumberHold;
    }

    public void UpdateBombText()
    {
        uiTextBombs.text = "" + bombs.NumberHold;
    }
}
