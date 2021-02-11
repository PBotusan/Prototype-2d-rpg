using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] float staminaCost;

    /// <summary>
    /// Animator used for player
    /// </summary>
    [SerializeField] Animator animator;


    /// <summary>
    /// prefab that stores the arrow
    /// </summary>
    [SerializeField] GameObject arrowPrefab;

    /// <summary>
    /// Playercontroller used from the playercontroller script
    /// </summary>
    PlayerController playerController;

    [SerializeField] Inventory playerInventory;
    [SerializeField] StaminaManager staminaManager;

    /// <summary>
    /// Used to instantiate arrow.
    /// </summary>
    [SerializeField] GameObject projectile;

    [SerializeField] GenericAbility currentAbility;

    private Vector2 facingDirection = Vector2.zero;

    /// <summary>
    /// Puts the input in variable.
    /// </summary>
    bool swordAttack;

    /// <summary>
    /// timer used for attack
    /// </summary>
    float attackTimer = 0.25f;


    /// <summary>
    /// Is attacking used to set the bool of the animator
    /// </summary>
    public bool isAttacking = false;



    /// <summary>
    /// Stores the attack type bow/sword
    /// </summary>
    string attackType;


    [Header("PlayerSignals")]
    /// <summary>
    /// Use signal to decrease Stamina
    /// </summary>
    [SerializeField] SignalSender decreaseStamina;
    [SerializeField] SignalSender UpdateArrowUI;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        //playerInventory = GetComponent<Inventory>();
        // find prefab of arrow
    }

    /// <summary>
    ///  Update is called once per frame
    /// </summary>
    void Update()
    {
        PlayerInput();
        AttackAnimation(attackType);
    }

    private void PlayerInput()
    {
        if (Input.GetButtonDown("SwordAttack") && playerController.currentPlayerState != PlayerState.attack
            && playerController.currentPlayerState != PlayerState.stagger)
            StartCoroutine(AttackAnimation(attackType = "IsAttacking"));

        if (Input.GetButtonDown("Ability1"))
        {
            if (currentAbility)
            {
                StartCoroutine(Ability1Coroutine(currentAbility.Duration));
            }
        }

       if (Input.GetButtonDown("RangedAttack") && playerController.currentPlayerState != PlayerState.attack
            && playerController.currentPlayerState != PlayerState.stagger)
            StartCoroutine(AttackAnimation(attackType = "IsAttackingBow"));
    }



    private IEnumerator AttackAnimation(string attackType)
    {
        if (playerController.currentPlayerState != PlayerState.interact)
        {
            playerController.currentPlayerState = PlayerState.attack;

            if (attackType == "IsAttackingBow")
            {
                AttackWithBow();

                yield return new WaitForSecondsRealtime(attackTimer);
                if (playerController.currentPlayerState != PlayerState.interact)
                {
                    playerController.currentPlayerState = PlayerState.idle;
                }
                yield break;
            }
            if (staminaManager.currentStamina > 5)
            {
                isAttacking = true;
                staminaManager.DecreaseStamina(30);
                animator.SetBool(attackType, isAttacking);
                playerController.SlowPlayerDuringAttack();
                yield return new WaitForSecondsRealtime(attackTimer);

                StopAttacking(attackType);
            }
        } 
    }

    private void AttackWithBow()
    {
        playerController.SlowPlayerDuringAttack();
        InstantiateArrow();

        playerController.RevertPlayerSpeed();
        //todo if i have an animtion for shooting rework to use the stop attacking 
    }

    /// <summary>
    /// Instantiate arrrow in game.
    /// </summary>
    private void InstantiateArrow()
    {
        // if player has enough stamina, shoot arrow.
        if (staminaManager.currentStamina > 5 && playerInventory.Arrows > 0)
        {
            var amountOfStamina = 30;
            staminaManager.DecreaseStamina(amountOfStamina);
            playerInventory.Arrows -= 1;
            UpdateArrowUI.Raise();


            Vector2 tempPos = new Vector2(animator.GetFloat("OldHorizontalValue"), animator.GetFloat("OldVerticalValue"));
            FireArrow projectile = Instantiate(arrowPrefab, transform.position, Quaternion.identity).GetComponent<FireArrow>();
            projectile.Setup(tempPos, ArrowFacingDirection());
        }
    }

    /// <summary>
    /// changes the direction of the arrow to the animator old values.
    /// </summary>
    /// <returns>  Vector3(0, 0, temp); </returns>
    Vector3 ArrowFacingDirection()
    {
        float temp = Mathf.Atan2(animator.GetFloat("OldHorizontalValue"), animator.GetFloat("OldVerticalValue")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }

    private void StopAttacking(string attackType)
    {
        isAttacking = false;

        animator.SetBool(attackType, isAttacking);

        if (playerController.currentPlayerState != PlayerState.interact)
        {
            playerController.currentPlayerState = PlayerState.idle;
        }

        playerController.RevertPlayerSpeed();
    }

    public IEnumerator Ability1Coroutine(float abilityDuration)
    {
        playerController.currentPlayerState = PlayerState.ability;
       

        yield return new WaitForSeconds(abilityDuration);
        playerController.currentPlayerState = PlayerState.idle;
    }
}

