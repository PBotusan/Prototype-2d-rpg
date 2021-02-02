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

    private void Start()
    {
        uiTextCoin.text = "" + playerInventory.Coins;
        uiTextArrows.text = "" + playerInventory.Arrows;
        uiTextBombs.text = "" + playerInventory.Bombs;
    }

    public void UpdateCoinText()
    {
        uiTextCoin.text = "" + playerInventory.Coins;
    }

    public void UpdateArrowText()
    {
        uiTextArrows.text = "" + playerInventory.Arrows;
    }

    public void UpdateBombText()
    {
        uiTextBombs.text = "" + playerInventory.Bombs;
    }
}
