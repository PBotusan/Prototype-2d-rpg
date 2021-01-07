using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : InteractableSystem
{

    [SerializeField] GameObject dialogBox;

    [SerializeField] Text dialogText;

    [SerializeField] string dialog;




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
