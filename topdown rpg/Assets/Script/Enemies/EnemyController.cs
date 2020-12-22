using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Transform target;

    [SerializeField]float health = 10;

    [SerializeField] float attackDamage = 2;

    [SerializeField]float movementSpeed = 3.5f;

    [SerializeField] float followDistance = 8;

    [SerializeField] float attackDistance = 0.25f;

    float amount;




    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
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

        if (calculateDistance <= followDistance && calculateDistance >= attackDistance)
        {
            FollowPlayer();
        }
        else
        {
            //todo states
        }
    }

    protected virtual void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
    }

    protected virtual void TakeDamage(float amount)
    {
        if (health <= 0)
        {
            Destroy(gameObject, 1f);            
        }

        health -= amount;
    }
}
