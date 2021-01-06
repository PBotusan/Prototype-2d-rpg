using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// All the states used by player.
/// </summary>
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
    /// <summary>
    /// The current state of the player
    /// </summary>
    public PlayerState currentPlayerState;

    /// <summary>
    /// 
    /// </summary>
    public SignalSender playerHealthSignal;

    /// <summary>
    /// current health amount
    /// </summary>
    public FloatValue currentHealth;

    /// <summary>
    /// startingpos of player when starting the game
    /// </summary>
    public VectorValueOfPlayer startingPosition;

    /// <summary>
    /// Stores The rigidbody of player.
    /// </summary>
    [SerializeField] Rigidbody2D playerRigidbody;


    /// <summary>
    /// The movement-speed of the player.
    /// </summary>
    [SerializeField] float playerSpeed = 5f;

    /// <summary>
    /// playerspeed used to revert back when it is changed.
    /// </summary>
    float oldPlayerSpeed = 5;

    /// <summary>
    /// let the player stop with walking.
    /// </summary>
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
        transform.position = startingPosition.initialValue;
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


    /// <summary>
    /// move the player and change the animtor velocity
    /// </summary>
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


    /// <summary>
    /// starts the coroutine.
    /// </summary>
    /// <param name="enemyRigidbody"> enemyrigidbody</param>
    /// <param name="time"> duration in seconds </param>
    /// <param name="damageAmount"> amount of damage.</param>
    public void KnockBack(float time, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.RuntimeValue > 0)
        {
            StartCoroutine(KnockBackTime(time));
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Knockback time coroutine. puts enemy on idle after the staggered state 
    /// </summary>
    /// <param name="enemyRigidbody"> enemyrigidbody</param>
    /// <param name="time"> duration in seconds </param>
    /// <returns></returns>
    private IEnumerator KnockBackTime(float time)
    {
        if (playerRigidbody != null)
        {
            yield return new WaitForSeconds(time);
            playerRigidbody.velocity = Vector2.zero;
            currentPlayerState = PlayerState.idle;
            Debug.Log("enemy hit player");
        }
    }

}
