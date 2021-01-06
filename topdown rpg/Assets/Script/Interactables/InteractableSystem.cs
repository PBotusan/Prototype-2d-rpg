using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSystem : MonoBehaviour
{
    //Singal listeners
    [SerializeField] protected SignalSender interactOn;
    [SerializeField] protected SignalSender interactOf;


    /// <summary>
    /// Activates if player is in range.
    /// </summary>
    [SerializeField] protected bool playerInRange;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
    }
}
