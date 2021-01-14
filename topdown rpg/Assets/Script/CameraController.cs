using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
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

    [SerializeField] Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
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

        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;
    }

    /// <summary>
    /// Small screen shake/kick when enemy hit player. 
    /// </summary>
    public void KickScreen()
    {
        animator.SetBool("Kick", true);
        KickCoroutine();
    }

    private IEnumerator KickCoroutine()
    {
        yield return new WaitForSeconds(0.6f);
        animator.SetBool("Kick", false);
    }
}
