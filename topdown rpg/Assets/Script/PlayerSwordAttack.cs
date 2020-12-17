using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordAttack : MonoBehaviour
{
    /// <summary>
    /// Animator used for player
    /// </summary>
    [SerializeField] Animator animator;

    PlayerMovement playermovement;

    /// <summary>
    /// Puts the input in variable.
    /// </summary>
    bool swordAttack;

    ///timers
    float attackTimer = 0.25f;



    bool isAttacking = false;


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        animator = GetComponent<Animator>();
        playermovement = GetComponent<PlayerMovement>();
    }

    /// <summary>
    ///  Update is called once per frame
    /// </summary>
    void Update()
    {
        PlayerInput();
        AttackAnimation();
    }

    private void PlayerInput()
    {
        if (Input.GetButtonDown("SwordAttack")) StartCoroutine(AttackAnimation());
    }

    private IEnumerator AttackAnimation()
    {
        isAttacking = true;
        animator.SetBool("IsAttacking", isAttacking);

        playermovement.SlowPlayerDuringAttack();

        yield return new WaitForSecondsRealtime(attackTimer);

        StopAttacking();
    }

    private void StopAttacking()
    {
        isAttacking = false;
        animator.SetBool("IsAttacking", isAttacking);

        playermovement.RevertPlayerSpeed();

        Debug.Log("stopt met aanvallen");
    }

    
}
