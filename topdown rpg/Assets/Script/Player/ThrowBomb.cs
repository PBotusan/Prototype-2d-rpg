using System;
using UnityEngine;

public class ThrowBomb : MonoBehaviour
{
    /// <summary>
    /// Instantiate the bomb.
    /// </summary>
    [SerializeField] GameObject bomb;
    [SerializeField] Inventory playerInventory;

    [Header("Signals")]
    /// <summary>
    /// Use signal to update bomb UI;
    /// </summary>
    [SerializeField] SignalSender UpdateBombUI;


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (Input.GetButtonDown("ThrowBomb"))
        {
            if(playerInventory.Bombs > 0)
                InstantiateBomb();
        }
    }

    private void InstantiateBomb()
    {
        Instantiate(bomb.gameObject, transform.position, Quaternion.identity);
        playerInventory.Bombs -= 1;
        UpdateBombUI.Raise();
    }
}
