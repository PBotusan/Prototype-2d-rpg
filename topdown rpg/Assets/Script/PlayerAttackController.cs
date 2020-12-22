using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
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
    bool isAttacking = false;


    /// <summary>
    /// Stores the attack type bow/sword
    /// </summary>
    string attackType;


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
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
        if (Input.GetButtonDown("SwordAttack")) StartCoroutine(AttackAnimation(attackType = "IsAttacking"));

        if (Input.GetButtonDown("RangedAttack")) StartCoroutine(AttackAnimation(attackType = "IsAttackingBow"));
    }


    private IEnumerator AttackAnimation(string attackType)
    {
        if (attackType == "IsAttackingBow")
        {
            AttackWithBow();

            yield return new WaitForSecondsRealtime(attackTimer);
            yield break;
        }

        isAttacking = true;
        animator.SetBool(attackType, isAttacking);
        playerController.SlowPlayerDuringAttack();
        yield return new WaitForSecondsRealtime(attackTimer);

        StopAttacking(attackType);
    }

    private void AttackWithBow()
    {
        //todo shoot when standing still

        playerController.SlowPlayerDuringAttack();
        Vector2 shootingDirection = new Vector2(playerController.horizontal, playerController.vertical);
        shootingDirection.Normalize();

        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        
        arrow.GetComponent<Rigidbody2D>().velocity = shootingDirection * 12.0f;
        arrow.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(shootingDirection.y * 10, shootingDirection.x * 10) * Mathf.Rad2Deg);
        Destroy(arrow, 2.0f);

        playerController.RevertPlayerSpeed();
        //todo if i have an animtion for shooting rework to use the stop attacking 
    }

    private void StopAttacking(string attackType)
    {
        isAttacking = false;
        animator.SetBool(attackType, isAttacking);

        playerController.RevertPlayerSpeed();
    }
}

