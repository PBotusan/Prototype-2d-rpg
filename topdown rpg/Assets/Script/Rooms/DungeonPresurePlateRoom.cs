using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPresurePlateRoom : DungeonRoom
{
    [SerializeField] Door[] doors;
    [SerializeField] Door door;

    /// <summary>
    /// Check if the enemies are still alive.
    /// </summary>
    public void CheckSwitches()
    {
        for (int i = 0; i < switches.Length; i++)
        {
            //if enemies are active do nothing, if not open the door again.
            if (switches[i].gameObject.activeInHierarchy && i < switches.Length - 1)
            {
                return;
            }
        }
        OpenDoors();
    }

    /*
    /// <summary>
    /// Close door when needed
    /// </summary>
    private void CloseDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].CloseDoor();
        }
    }*/

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
}
