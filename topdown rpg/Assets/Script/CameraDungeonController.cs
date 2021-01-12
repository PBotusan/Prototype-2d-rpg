using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDungeonController : MonoBehaviour
{
    /// <summary>
    /// Gameobject of player used to move the player.
    /// </summary>
    [SerializeField] Transform target;

    /// <summary>
    /// Smoothing speed, used to give slight bump when you stop.
    /// </summary>
    [SerializeField] float smoothSpeed = 0.1f;

    /// <summary>
    /// offset used as distance for camera.
    /// </summary>
    [SerializeField] Vector3 offset;

    [SerializeField] Vector2 maxPosition;
    public Vector2 MaxPosition { get { return maxPosition; } set { maxPosition = value; } }

    [SerializeField] Vector2 minPosition;
    public Vector2 MinPosition { get { return minPosition; } set { minPosition = value; } }

    private void Start()
    {
        // transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void FixedUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("No Target/player Found");

            return;
        }

        // offst + the target position in gameworld.
        Vector3 desiredPosition = target.position + offset;

        //clamp between min and max value, does not go boyond that.
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minPosition.x, maxPosition.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minPosition.y, maxPosition.y);


        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;


    }
}
