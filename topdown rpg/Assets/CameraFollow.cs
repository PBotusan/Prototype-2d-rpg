using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /// <summary>
    /// Gameobject of player used to move the player.
    /// </summary>
    [SerializeField] Transform target;

    [SerializeField] float smoothSpeed = 0.1f;

    [SerializeField] Vector3 offset;


    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void FixedUpdate()
    {

        if (target == null)
        {
            Debug.LogWarning("No Target/player Found");
        }

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;


    }
}
