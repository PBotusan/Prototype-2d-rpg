using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemyRoom : DungeonRoom
{
    [SerializeField] Door[] doors;

    /// <summary>
    /// Check if the enemies are still alive.
    /// </summary>
    public void CheckEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            //if enemies are active do nothing, if not open the door again.
            if (enemies[i].gameObject.activeInHierarchy && i < enemies.Length - 1)
            {
                return;
            }
        }
        OpenDoors();
    }

    /// <summary>
    /// Close door when needed
    /// </summary>
    private void CloseDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].CloseDoor();
        }
    }

    /// <summary>
    /// Open the door after completing task.
    /// </summary>
    private void OpenDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].OpenDoor();
        }
    }

    //==================================Overrides from Room Class=========================================\\
    // ChangeActivation inherited by DungeonRoom -> Room.

    /// <summary>
    /// On collision enter, restore the enemies and destructables.
    /// </summary>
    /// <param name="collision"></param>
    protected override void OnTriggerEnter2D(Collider2D collision)
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

            CloseDoors();
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
