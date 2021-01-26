using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldRoom : Room
{
    //========================override Room==============================\\
    //Change activation is in Room-class

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
    protected override void OnTriggerExit2D(Collider2D collision)
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
}
