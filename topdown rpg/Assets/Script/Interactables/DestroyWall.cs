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

    [SerializeField] BoolValue DestroyWallState;

    private void Start()
    {
        if (DestroyWallState.RuntimeValue)
        {
            hint.SetActive(false);
            Entrance.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BombExplosion") && collision.isTrigger)
        {
            DestroyWallState.RuntimeValue = true;

            hint.SetActive(false);
            Entrance.SetActive(true);
        }
    }
}
