using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    [SerializeField] SignalSender pickUpSignal;
    public SignalSender PickUpSignal { get { return pickUpSignal; } set { pickUpSignal = value; } }

    [SerializeField] internal Inventory playerInventory;


    // Start is called before the first frame update
    void Start()
    {
        PickUpSignal.Raise();
    }
    
}
