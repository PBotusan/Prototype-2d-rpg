using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    idle,
    walk,
    attack,
    interact,
    stagger
}



public class PlayerController : MonoBehaviour
{
    public PlayerState currentPlayerState;

    /// <summary>
    /// Stores The rigidbody of player.
    /// </summary>
    [SerializeField] Rigidbody2D playerRigidbody;


    /// <summary>
    /// The movement-speed of the player.
    /// </summary>
    [SerializeField] float playerSpeed = 5f;


    float oldPlayerSpeed = 5;

    float speedDuringAttacks = 0;


    [SerializeField] Animator animator;


    /// <summary>
    /// movedirection for player 'move X'.
    /// </summary>
    public float horizontal;

    /// <summary>
    ///  movedirection for player 'move Y'. 
    /// </summary>
    public float vertical;
    


    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        currentPlayerState = PlayerState.idle;
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        oldPlayerSpeed = playerSpeed;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        playerRigidbody.velocity = new Vector2(horizontal * playerSpeed, vertical * playerSpeed).normalized * playerSpeed;
        animator.SetFloat("Horizontal", playerRigidbody.velocity.x);
        animator.SetFloat("Vertical", playerRigidbody.velocity.y);
    }

    /// <summary>
    /// 'Handles the player input'
    /// </summary>
    private void PlayerInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal == 1 || horizontal == -1 || vertical == 1 || vertical == -1)
        {
            currentPlayerState = PlayerState.walk;
            animator.SetFloat("OldHorizontalValue", horizontal);
            animator.SetFloat("OldVerticalValue", vertical);
        }
        else if (horizontal == 0 || vertical == 0)
        {
            if (currentPlayerState != PlayerState.attack && currentPlayerState != PlayerState.stagger)
                currentPlayerState = PlayerState.idle;

        }


    }

    public void SlowPlayerDuringAttack()
    {
        playerSpeed = speedDuringAttacks;
    }

    public void RevertPlayerSpeed()
    {
        playerSpeed = oldPlayerSpeed;
    }

    public void KnockBack(float time)
    {
        StartCoroutine(KnockBackTime(time));
    }

    private IEnumerator KnockBackTime(float time)
    {
        if (playerRigidbody != null)
        {
            yield return new WaitForSeconds(time);
            playerRigidbody.velocity = Vector2.zero;
            currentPlayerState = PlayerState.idle;
        }
    }

}
