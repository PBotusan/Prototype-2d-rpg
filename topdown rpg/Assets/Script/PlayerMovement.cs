using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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
    float horizontal;

    /// <summary>
    ///  movedirection for player 'move Y'. 
    /// </summary>
    float vertical;
    


    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
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
            animator.SetFloat("OldHorizontalValue", horizontal);
            animator.SetFloat("OldVerticalValue", vertical);
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

}
