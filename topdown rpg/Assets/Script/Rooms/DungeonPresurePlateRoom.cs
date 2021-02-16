using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPresurePlateRoom : Room
{
    [SerializeField] Door[] doors;
    [SerializeField] Door door;

    int count = 0;

    /// <summary>
    /// Check if the enemies are still alive.
    /// </summary>
    public void CheckSwitches()
    {
        
        for (int i = 0; i < switches.Length; i++)
        {
            
            if (switches[i].gameObject.activeInHierarchy && i < switches.Length)
            {
                count += 1;
                if (count == switches.Length)
                {
                    OpenDoors();
                }
                return;
            }
            
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
}
