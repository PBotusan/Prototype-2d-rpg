using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemyRoom : Room
{
    [SerializeField] Door[] doors;
    [SerializeField] GameObject door;

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
        StartCoroutine(CloseDoorCoroutine());
        
    }

    private IEnumerator CloseDoorCoroutine()
    {
        yield return new WaitForSeconds(.5f);
        door.SetActive(true);
    }

    /// <summary>
    /// Open the door after completing task.
    /// </summary>
    private void OpenDoors()
    {
        door.SetActive(false);
    }

    //==================================Overrides from Room Class=========================================\\
    // ChangeActivation inherited by DungeonRoom -> Room.

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
            virtualCamera.SetActive(true);
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
            OpenDoors();
        }
    }
}
