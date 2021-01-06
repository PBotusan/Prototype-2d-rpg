using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignSystem : MonoBehaviour
{
    //Singal listeners
    [SerializeField] SignalSender interactOn;
    [SerializeField] SignalSender interactOf;


    [SerializeField] GameObject dialogBox;

    [SerializeField] Text dialogText;

    [SerializeField] string dialog;

    /// <summary>
    /// Activates if player is in range.
    /// </summary>
    [SerializeField] bool playerInRange;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactOn.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactOf.Raise();
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
