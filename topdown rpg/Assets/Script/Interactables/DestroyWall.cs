using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    /// <summary>
    /// used to disable the hint/sign.
    /// </summary>
    [SerializeField] GameObject hint;

    /// <summary>
    /// Enable entrance when bombed.
    /// </summary>
    [SerializeField] GameObject Entrance;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BombExplosion") && collision.isTrigger)
        {
            hint.SetActive(false);
            Entrance.SetActive(true);
        }
    }
}
