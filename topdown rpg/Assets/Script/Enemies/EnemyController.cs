﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class EnemyController : MonoBehaviour
{

    public EnemyState currentState;

    [SerializeField] FloatValue maxHealth;

    public float movementSpeed = 3.5f;

    private Transform target;

    [SerializeField] Rigidbody2D enemyRigidbody;

    private float health;

    [SerializeField] float attackDamage = 2;

    [SerializeField] float followDistance = 8;

    [SerializeField] float attackDistance = 0.25f;

    float amount;




    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth.initialValue;

        target = FindObjectOfType<PlayerController>().transform;
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateDistance();
        
    }

    private void Update()
    {
        TakeDamage(amount);
    }

    private void CalculateDistance()
    {
        var calculateDistance = Vector3.Distance(target.position, transform.position);

        if (calculateDistance <= followDistance && calculateDistance > attackDistance)
        {
            FollowPlayer();
        }
        else
        {
            enemyRigidbody.velocity = Vector2.zero;
        }

    }

    protected virtual void FollowPlayer()
    {
        if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);

            enemyRigidbody.MovePosition(temp);
            ChangeState(EnemyState.walk);
        }

    }

   

    protected virtual void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }

    public void KnockBack(Rigidbody2D enemyRigidbody, float time, float damageAmount)
    {
        StartCoroutine(KnockBackTime(enemyRigidbody, time));
        TakeDamage(damageAmount);
    }


    private IEnumerator KnockBackTime(Rigidbody2D enemyRigidbody, float time)
    {
        if (enemyRigidbody != null)
        {
            yield return new WaitForSeconds(time);
            enemyRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
        }
    }

    protected virtual void TakeDamage(float amount)
    {
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }

        health -= amount;
    }
}
