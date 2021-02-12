using System.Collections;
using UnityEngine;

/// <summary>
/// All the states used by player.
/// </summary>
public enum PlayerState
{
    idle,
    walk,
    run,
    attack,
    interact,
    stagger,
    ability
}

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// The current state of the player
    /// </summary>
    public PlayerState currentPlayerState;

    /// <summary>
    /// startingpos of player when starting the game
    /// </summary>
    public VectorValueOfPlayer startingPosition;

    /// <summary>
    /// Stores The rigidbody of player.
    /// </summary>
    [SerializeField] Rigidbody2D playerRigidbody;

    public Rigidbody2D PlayerRigidbody { get {return playerRigidbody; } set { playerRigidbody = value; } }

    [SerializeField] StaminaManager staminaManager;

    /// <summary>
    /// The movement-speed of the player.
    /// </summary>
    [SerializeField] float playerSpeed = 5f;

    [SerializeField] Animator animator;

    public Animator Animator { get { return animator; } set { animator = value; } }

    /// <summary>
    /// playerspeed used to revert back when it is changed.
    /// </summary>
    float oldPlayerSpeed = 5;

    /// <summary>
    /// let the player stop with walking.
    /// </summary>
    float speedDuringAttacks = 0;

    [SerializeField] Inventory playerInventory;
    [SerializeField] SpriteRenderer recievedItemSprite;

    //split
    [SerializeField] Color flashColor;
    [SerializeField] Color regularColor;
    [SerializeField] float flashDuration;
    [SerializeField] int numberOfFlashes;
    [SerializeField] Collider2D triggerCollider;
    [SerializeField] SpriteRenderer playerSprite;


    /// <summary>
    /// movedirection for player 'move X'.
    /// </summary>
    private float horizontal;
    public float Horizontal { get { return horizontal; } set { horizontal = value; } }

    /// <summary>
    ///  movedirection for player 'move Y'. 
    /// </summary>
    private float vertical;
    public float Vertical { get { return vertical; } set { vertical = value; } }

    [Header("PlayerSignals")]
    /// <summary>
    /// Use to raise signal for screen shake/kick after hit.
    /// </summary>
    [SerializeField] SignalSender playerHit;

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
        // is the player interacting, add to pauze everything.
        if (currentPlayerState == PlayerState.interact)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal == 1 || horizontal == -1 || vertical == 1 || vertical == -1)
        {
            currentPlayerState = PlayerState.walk;
            animator.SetFloat("OldHorizontalValue", horizontal);
            animator.SetFloat("OldVerticalValue", vertical);
            checkIfPlayerCanRun();
        }
        else if (horizontal == 0 || vertical == 0)
        {
            if (currentPlayerState != PlayerState.attack && currentPlayerState != PlayerState.stagger)
                currentPlayerState = PlayerState.idle;

        }


    }

    private void checkIfPlayerCanRun()
    {
        if (Input.GetAxis("Run") == 1 )
        {
            currentPlayerState = PlayerState.run;
 
            if (staminaManager.currentStamina > 5 && currentPlayerState == PlayerState.run)
            {
                playerSpeed = 8f;
                staminaManager.DecreaseStamina(2f);
            }
            if (staminaManager.currentStamina < 5)
            {
                currentPlayerState = PlayerState.walk;
                playerSpeed = oldPlayerSpeed;
            }
        }
        else if (Input.GetAxis("Run") == 0)
        {
            playerSpeed = oldPlayerSpeed;
        }
    }

    internal void SlowPlayerDuringAttack()
    {
        playerSpeed = speedDuringAttacks;
    }

    internal void RevertPlayerSpeed()
    {
        playerSpeed = oldPlayerSpeed;
    }

    //split
    public void RaiseItem()
    {
        if (playerInventory.CurrentItem != null)
        {
            if (currentPlayerState != PlayerState.interact)
            {
                //animator hold hands up.
                currentPlayerState = PlayerState.interact;
                recievedItemSprite.sprite = playerInventory.CurrentItem.ItemSprite;
            }
            else
            {
                // set anim to false
                currentPlayerState = PlayerState.idle;
                recievedItemSprite.sprite = null;
                playerInventory.CurrentItem = null;
            }
        }
    }

    //split
    /// <summary>
    /// starts the coroutine.
    /// </summary>
    /// <param name="enemyRigidbody"> enemyrigidbody</param>
    /// <param name="time"> duration in seconds </param>
    /// <param name="damageAmount"> amount of damage.</param>
    public void KnockBack(float time)
    {
        StartCoroutine(KnockBackTime(time));
    }

    /// <summary>
    /// Knockback time coroutine. puts enemy on idle after the staggered state 
    /// </summary>
    /// <param name="enemyRigidbody"> enemyrigidbody</param>
    /// <param name="time"> duration in seconds </param>
    /// <returns></returns>
    private IEnumerator KnockBackTime(float time)
    {
        playerHit.Raise();

        if (playerRigidbody != null)
        {
            StartCoroutine(FlashCoroutine());
            yield return new WaitForSeconds(time);
            //playerRigidbody.velocity = Vector2.zero;
            currentPlayerState = PlayerState.idle;
            Debug.Log("enemy hit player");
        }
    }

    //split
    private IEnumerator FlashCoroutine()
    {
        int temp = 0;
        triggerCollider.enabled = false;

        while (temp < numberOfFlashes)
        {
            playerSprite.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            playerSprite.color = regularColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        triggerCollider.enabled = true;
    }
}
