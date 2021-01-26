using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    /// <summary>
    /// Stores if the switch is active true/false.
    /// </summary>
    [SerializeField] bool active;

    /// <summary>
    /// Stores the value as an boolvalue
    /// </summary>
    [SerializeField] BoolValue storedValue;

    //[SerializeField] Sprite DoorSprite;

    /// <summary>
    /// Sprite renderer used to dislay sprite switch, to change color.
    /// </summary>
    [SerializeField] SpriteRenderer spriteSwitch;

    [Header("Activate Pressureplate Signals")]
    [SerializeField] SignalSender roomSignal;

    /// <summary>
    ///  Start is called before the first frame update
    /// </summary>
    void Start()
    {
        spriteSwitch = GetComponent<SpriteRenderer>();
       
        active = storedValue.RuntimeValue;
        if (active)
        {
            ActivateSwitch();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ActivateSwitch();
        }
    }

    private void ActivateSwitch()
    {
        active = true;
        storedValue.RuntimeValue = active;
        roomSignal.Raise();
        gameObject.SetActive(false);
    }
}
