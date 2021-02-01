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
    [SerializeField] TextMeshProUGUI uiText;

    private void Awake()
    {
        uiText.text = "" + playerInventory.Coins;
        uiText.text = "" + playerInventory.Arrows;
        uiText.text = "" + playerInventory.Bombs;
    }

    public void UpdateCoinText()
    {
        uiText.text = "" + playerInventory.Coins;
    }

    public void UpdateArrowText()
    {
        uiText.text = "" + playerInventory.Arrows;
    }

    public void UpdateBombText()
    {
        uiText.text = "" + playerInventory.Bombs;
    }
}
