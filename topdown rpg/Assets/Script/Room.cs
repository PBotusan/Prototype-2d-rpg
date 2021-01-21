using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    /// <summary>
    /// Restore enemies.
    /// </summary>
    [SerializeField] protected EnemyController[] enemies;

    /// <summary>
    /// Restore the Pots/Destructables.
    /// </summary>
    [SerializeField] protected BreakableObjectsController[] breakables;

    /// <summary>
    /// On collision enter, restore the enemies and destructables.
    /// </summary>
    /// <param name="collision"></param>
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            //activate the enemies and destructables.
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], true);
            }

            for (int i = 0; i < breakables.Length; i++)
            {
                ChangeActivation(breakables[i], true);
            }
        }

    }

    /// <summary>
    /// When player leaves room deactivate enemies and breakables.
    /// </summary>
    /// <param name="collision"></param>
    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            //Deactivate the enemies and destructables.
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], false);
            }

            for (int i = 0; i < breakables.Length; i++)
            {
                ChangeActivation(breakables[i], false);
            }

        }
    }

    /// <summary>
    /// De/activate components for performance, and deactivates enemies/pots when entering other room.
    /// </summary>
    /// <param name="component"> The type you want to activate </param>
    /// <param name="activation"> Activation based on true/false.</param>
    protected void ChangeActivation(Component component, bool activation)
    {
        component.gameObject.SetActive(activation);
    }
}
